﻿using MediatR;
using RainbowApp.Core.Entities;

namespace RainbowApp.Application.Tasks.Commands
{
    public class CreateAuthCommand : IRequest<AuthenticateResponse>
    {
        //public int UserId { get; set; }
        //public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //public string Domain { get; set; }
        //public DateTime CreatedYmd { get; set; }
        //public DateTime? ChangedYmd { get; set; }
    }
}
