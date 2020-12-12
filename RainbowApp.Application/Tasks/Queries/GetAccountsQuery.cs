using System.Collections.Generic;
using MediatR;
using RainbowApp.Core.Entities;

namespace RainbowApp.Application.Tasks.Queries
{
    public class GetAccountsQuery : IRequest<List<Account>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
