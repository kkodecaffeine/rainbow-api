using System.Collections.Generic;
using MediatR;
using RainbowApp.Application.Model;

namespace RainbowApp.Application.Tasks.Queries
{
    public class GetAccountsQuery : IRequest<List<TblAccount>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
