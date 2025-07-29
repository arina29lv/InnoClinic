using Contracts.Logs.Interfaces;
using System.Net;
using System.Text.Json;

namespace AppointmentControl.Infrastructure.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogService _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogService logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(
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

                await context.Response.WriteAsync(JsonSerializer.Serialize(response)).ConfigureAwait(false);
            }
        }
    }
}
