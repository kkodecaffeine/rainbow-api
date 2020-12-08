﻿using System.Collections.Generic;
using System.Threading.Tasks;
using RainbowApp.Core.Entities;

namespace RainbowApp.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<AuthenticateResponse> Authenticate(string mailAddr, string password);

        Task<int> AddUser(RegisterRequest model, string origin);

        Task<IEnumerable<User>> GetAll();
        Task<User> GetUser(int userId);
        Task<User> GetUser(string mailAddr);
        Task<User> GetUser(string mailAddr, string password);

        Task ForgotPassword(ForgotPasswordRequest model, string origin);
    }
}