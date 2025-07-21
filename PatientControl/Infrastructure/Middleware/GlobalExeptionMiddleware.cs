using PatientControl.Infrastructure.Interfaces;
using System.Net;
using System.Text.Json;

namespace PatientControl.Infrastructure.Middleware
{
    public class GlobalExeptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogService _logService;

        public GlobalExeptionMiddleware(RequestDelegate next, ILogService logService)
        {
            _next = next;
            _logService = logService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logService.LogError(
                    $"Exeption caught in middleware. Path: {context.Request.Path}",
                    ex.ToString()
                    );

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var response = new
                {
                    error = "An unexpected error occured.",
                    message = ex.Message
                };

                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        }
    }
}
