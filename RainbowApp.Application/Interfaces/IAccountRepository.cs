using System.Collections.Generic;
using System.Threading.Tasks;
using RainbowApp.Core.Entities;

namespace RainbowApp.Application.Interfaces
{
    public interface IAccountRepository
    {
        Task<AuthenticateResponse> Authenticate(string mailAddr, string password);

        Task<int> AddUser(RegisterRequest model, string origin);

        Task<IEnumerable<Account>> GetAll();
        Task<Account> GetUser(int userId);
        Task<Account> GetUser(string mailAddr);
        Task<Account> GetUser(string mailAddr, string password);

        Task ForgotPassword(ForgotPasswordRequest model, string origin);
        Task<int> ResetPassword(ResetPasswordRequest model, int userId);
    }
}