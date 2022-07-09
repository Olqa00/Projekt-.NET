using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
namespace Projekt_2.Infrastructure
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ErrorMiddleware
    {
        
        private readonly RequestDelegate _next;

        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await _next(httpContext);
            switch(httpContext.Response.StatusCode)
            {
                case 404:
                    httpContext.Response.Redirect("/Error"); //tu cyk stronka
                    break;
                case 500:
                    //nothing to do (now)...
                    break;
                default:
                    //nothing to do (now)...
                    break;
            }
            //return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ErrorMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorMiddleware>();
        }
    }
}
