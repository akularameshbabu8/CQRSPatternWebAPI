using System.Net.Mime;
using System.Net;
using System.Text;
using CQRSPatternWebAPI.Dto;


namespace CQRSPatternWebAPI.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            if (!context.Response.HasStarted)
            {
                context.Response.ContentType = MediaTypeNames.Application.Json;
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                string message = "Internal Server error.";

                byte[] error = Encoding.ASCII.GetBytes(new ErrorDetails() { StatusCode = context.Response.StatusCode, Message = message }.ToString());
                await context.Response.Body.WriteAsync(error, 0, error.Length);
            }
        }
    }

}
