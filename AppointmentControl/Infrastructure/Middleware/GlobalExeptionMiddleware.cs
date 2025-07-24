using Contracts.Logs.Interfaces;
using System.Net;
using System.Text.Json;

namespace AppointmentControl.Infrastructure.Middleware
{
    public class GlobalExeptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExeptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var logService = context.RequestServices.GetRequiredService<ILogService>();

            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                logService.LogError(
                    $"Exception caught in middleware. Path: {context.Request.Path}",
                    ex.ToString()
                );

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var response = new
                {
                    error = "An unexpected error occurred.",
                    message = ex.Message
                };

                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        }
    }
}
