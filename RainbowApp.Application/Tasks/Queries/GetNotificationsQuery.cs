﻿using System.Collections.Generic;
using MediatR;
using RainbowApp.Application.Tasks.Dto;

namespace RainbowApp.Application.Tasks.Queries
{
    public class GetNotificationsQuery : IRequest<List<NotificationDto>>
    {
    }
}
