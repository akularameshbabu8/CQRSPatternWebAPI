using Domain.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Net.Mime;
using System.Text;

namespace Infrastructure.Middleware
{
    public static class ExceptionMiddlewareExtention
    {
        public static void ConfigureGlobalExceptionHandler(this IApplicationBuilder app)
        {

            app.UseExceptionHandler(appError => appError.Run(async context => {

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = MediaTypeNames.Application.Json;

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {                   
                    byte[] error = Encoding.ASCII.GetBytes(new ErrorDetails() { StatusCode = context.Response.StatusCode, Message = "Internal Service Error" }.ToString());
                    await context.Response.Body.WriteAsync(error, 0, error.Length);
                }
            })); ;
        }

        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<GlobalExceptionMiddleware>();
        }
    }
}
