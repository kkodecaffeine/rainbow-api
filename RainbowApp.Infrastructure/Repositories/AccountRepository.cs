using Dapper;
using BC = BCrypt.Net.BCrypt;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using RainbowApp.Application.Interfaces;
using RainbowApp.Core.Entities;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System;
using RainbowApp.Application.Model;
using System.Security.Cryptography;

namespace RainbowApp.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private readonly string _secret;


        public AccountRepository(IRainbowContext context, IConfiguration configuration)
        {

            _connectionString = context.GetDbConnection();
            _configuration = configuration;
            _secret = _configuration.GetSection("AppSettings:Secret").Value;
        }

        public async Task<AuthenticateResponse> Authenticate(string email, string password)
        {
            var user = await GetUser(email, password);

            // return null if user not found
            if (user == null)
            {
                return null;
            }

            // authentication successful so generate jwt token
            var token = GenerateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public async Task<int> AddUser(RegisterRequest model, string origin)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var name = model.Email.Split('@').FirstOrDefault();
            var verificationToken = RandomTokenString();
            var domain = model.Email.Split('@').LastOrDefault();

            model.Password = BC.HashPassword(model.Password);

            var sql = $"INSERT INTO tblAccount (Name, Email, Password, VerificationToken, Domain, CreatedYmd) Values ('{name}', '{model.Email}', '{model.Password}', '{verificationToken}', '{domain}', '{DateTime.UtcNow:yyyy-MM-dd hh:mm:ss}');";

            var affectedRows = await connection.ExecuteAsync(sql);
            return affectedRows;

            // send email
            //sendVerificationEmail(account, origin);
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            var sql = @"SELECT * FROM tblMember";


            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var result = await connection.QueryAsync<Account>(sql);
            return result;
        }

        public async Task<Account> GetUser(int userId)
        {
            var sql = @"SELECT * FROM tblMember WHERE UserId = @UserId";

            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var result = await connection.QueryAsync<Account>(sql, new { UserId = userId });
            return result.FirstOrDefault();
        }

        public async Task<Account> GetUser(string email)
        {
            var sql = @"SELECT * FROM tblMember WHERE Email = @Email";

            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var result = await connection.QueryAsync<Account>(sql, new { Email = email });
            return result.FirstOrDefault();
        }

        public async Task<Account> GetUser(string email, string password)
        {
            var sql = @"SELECT * FROM tblMember WHERE Email = @Email AND Password = @Password";

            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var result = await connection.QueryAsync<Account>(sql, new { Email = email, Password = password });
            return result.FirstOrDefault();
        }

        #region Generate token
        private string GenerateJwtToken(Account user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.UserId.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private string RandomTokenString()
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[40];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            // convert random bytes to hex string
            return BitConverter.ToString(randomBytes).Replace("-", "");
        }
        #endregion

        public async Task ForgotPassword(ForgotPasswordRequest model, string origin)
        {
            var sql = @"SELECT * FROM tblAccount WHERE Email = @Email";

            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var result = await connection.QuerySingleOrDefaultAsync<Account>(sql, new { model.Email });

            // always return ok response to prevent email enumeration
            if (result == null) return;

            // create reset token that expires after 1 day
            result.ResetToken = RandomTokenString();
            result.ResetTokenExpiredYmd = DateTime.UtcNow.AddDays(1);

            connection.Execute("UPDATE tblAccount SET ResetToken = @ResetToken, ResetTokenExpiredYmd = @ResetTokenExpiredYmd WHERE ID = @ID"
                , new
                {
                    result.ResetToken,
                    result.ResetTokenExpiredYmd,
                    result.UserId
                });

            // send email
            //sendPasswordResetEmail(account, origin);
        }

        public async Task<int> ResetPassword(ResetPasswordRequest model, int userId)
        {
            var sql = $@"SELECT * FROM tblAccount WHERE ResetToken = @ResetToken AND ResetTokenExpires > {DateTime.UtcNow}";

            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var result = await connection.QuerySingleOrDefaultAsync<Account>(sql, new { model.Token });

            if (result == null) throw new Exception("Invalid token");

            // Update password and remove reset token
            result.Password = BC.HashPassword(model.Password);
            result.PasswordResetYmd = DateTime.UtcNow;
            result.ResetToken = null;
            result.ResetTokenExpiredYmd = null;

            var affectedRows = await connection.ExecuteAsync("UPDATE tblAccount SET Password = @Password, PasswordResetYmd = @PasswordResetYmd, ResetToken = null, ResetTokenExpiredYmd = null WHERE ID = @ID"
                , new
                {
                    result.ResetToken,
                    result.PasswordResetYmd,
                    result.ResetTokenExpiredYmd,
                    userId
                });

            return affectedRows;
        }
    }
}