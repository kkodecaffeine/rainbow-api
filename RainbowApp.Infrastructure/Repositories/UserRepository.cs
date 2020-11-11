using Dapper;
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

namespace RainbowApp.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _secret;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _secret = _configuration.GetSection("AppSettings:Secret").Value;
        }

        public async Task<AuthenticateResponse> Authenticate(string mailAddr, string password)
        {
            var user = await GetUser(mailAddr, password);

            // return null if user not found
            if (user == null)
            {
                return null;
            }

            // authentication successful so generate jwt token
            var token = GenerateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var sql = @"SELECT * FROM tblMember";

            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var result = await connection.QueryAsync<User>(sql);
            return result;
        }

        public async Task<User> GetUser(int userId)
        {
            var sql = @"SELECT * FROM tblMember WHERE UserId = @UserId";

            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var result = await connection.QueryAsync<User>(sql, new { UserId = userId });
            return result.FirstOrDefault();
        }

        public async Task<User> GetUser(string mailAddr, string password)
        {
            var sql = @"SELECT * FROM tblMember WHERE MailAddr = @MailAddr AND Password = @Password";

            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var result = await connection.QueryAsync<User>(sql, new { MailAddr = mailAddr, Password = password });
            return result.FirstOrDefault();
        }

        private string GenerateJwtToken(User user)
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
    }
}