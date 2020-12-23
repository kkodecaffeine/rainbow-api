using MediatR;
using RainbowApp.Core.Entities;

namespace RainbowApp.Application.Tasks.Queries
{
    public class GetAccountsQuery : IRequest<ApiResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
