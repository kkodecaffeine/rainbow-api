﻿using System;
using System.Net;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RainbowApp.Infrastructure.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ValidationException)
            {
                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new JsonResult(
                    ((ValidationException)context.Exception).Message);

                return;
            }

            var code = HttpStatusCode.InternalServerError;

            if (context.Exception is NotFoundException)
            {
                code = HttpStatusCode.NotFound;
            }

            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)code;
            context.Result = new JsonResult(new
            {
                StatusCode = (int)code,
                error = new[] { context.Exception.Message }
            });
        }

        public class NotFoundException : Exception
        {
            public NotFoundException(string entityName, int key)
                : base($"Entity {entityName} with primary key {key} was not found.")
            {
            }
        }
    }
}
