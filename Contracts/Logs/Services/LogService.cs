using Contracts.Logs.DTOs;
using Contracts.Logs.Interfaces;
using Contracts.Logs.Messaging;
using Microsoft.Extensions.Hosting;

namespace Contracts.Logs.Services
{
    public class LogService : ILogService
    {
        private readonly IRabbitMqLogPublisher _publisher;
        private readonly IHostEnvironment _environment;
        private readonly string _microserviceName;

        public LogService(IRabbitMqLogPublisher publisher, IHostEnvironment environment, string microserviceName)
        {
            _publisher = publisher;
            _environment = environment;
            _microserviceName = microserviceName;
        }

        public async Task LogInfo(string message, string? exception = null)
        {
            await SendLogAsync("INFO", message, exception);
        }

        public async Task LogWarning(string message, string? exception = null)
        {
            await SendLogAsync("WARNING", message, exception);
        }

        public async Task LogError(string message, string? exception = null)
        {
            await SendLogAsync("ERROR", message, exception);
        }

        private async Task SendLogAsync(string level, string message, string? exception)
        {
            var log = new LogMessageDto
            {
                Level = level,
                MicroserviceName = _microserviceName,
                Message = message,
                Exception = exception,
                Environment = _environment.EnvironmentName
            };

            await _publisher.SendLog(log);
        }
    }
}
