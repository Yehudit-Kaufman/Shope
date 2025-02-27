﻿
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Shope
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class TryCatchMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<TryCatchMiddleware> _logger;
        
        public TryCatchMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, ILogger<TryCatchMiddleware> _logger)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                _logger.LogCritical($"Logged From My Middleware {e.Message}  {e.StackTrace}");
                httpContext.Response.StatusCode = 500;
                await httpContext.Response.WriteAsync("Internal Error In Server");
            }

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ErrorHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TryCatchMiddleware>();
        }
    }
}
