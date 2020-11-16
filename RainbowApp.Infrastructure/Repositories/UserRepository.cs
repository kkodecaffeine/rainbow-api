﻿using Dapper;
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
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private readonly string _secret;


        public UserRepository(IRainbowContext context, IConfiguration configuration)
        {

            _connectionString = context.GetDbConnection();
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

        public async Task<int> AddUser(RegisterRequest model, string origin)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var name = model.MailAddr.Split('@').FirstOrDefault();
            var verificationToken = RandomTokenString();
            var domain = model.MailAddr.Split('@').LastOrDefault();

            model.Password = BC.HashPassword(model.Password);

            var sql = $"INSERT INTO tblUser (Name, MailAddr, Password, VerificationToken, Domain, CreatedYmd) Values ('{name}', '{model.MailAddr}', '{model.Password}', '{verificationToken}', '{domain}', '{DateTime.UtcNow:yyyy-MM-dd hh:mm:ss}');";

            var affectedRows = await connection.ExecuteAsync(sql);
            return affectedRows;

            // send email
            //sendVerificationEmail(account, origin);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var sql = @"SELECT * FROM tblMember";


            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var result = await connection.QueryAsync<User>(sql);
            return result;
        }

        public async Task<User> GetUser(int userId)
        {
            var sql = @"SELECT * FROM tblMember WHERE UserId = @UserId";

            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var result = await connection.QueryAsync<User>(sql, new { UserId = userId });
            return result.FirstOrDefault();
        }

        public async Task<User> GetUser(string mailAddr)
        {
            var sql = @"SELECT * FROM tblMember WHERE MailAddr = @MailAddr";

            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var result = await connection.QueryAsync<User>(sql, new { MailAddr = mailAddr });
            return result.FirstOrDefault();
        }

        public async Task<User> GetUser(string mailAddr, string password)
        {
            var sql = @"SELECT * FROM tblMember WHERE MailAddr = @MailAddr AND Password = @Password";

            using var connection = new SqlConnection(_connectionString);
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

        private string RandomTokenString()
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[40];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            // convert random bytes to hex string
            return BitConverter.ToString(randomBytes).Replace("-", "");
        }
    }
}