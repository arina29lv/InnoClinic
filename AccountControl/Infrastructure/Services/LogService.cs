using AccountControl.Infrastructure.Interfaces;
using Contracts;

namespace AccountControl.Infrastructure.Service
{
    public class LogService : ILogService
    {
        private readonly IRabbitMqLogPublisher _publisher;
        private readonly IHostEnvironment _environment;

        public LogService(IRabbitMqLogPublisher publisher, IHostEnvironment environment)
        {
            _publisher = publisher;
            _environment = environment;
        }

        public void LogInfo(string message, string? exception = null)
        {
            var log = new LogMessageDto
            {
                Level = "INFO",
                MicroserviceName = "AccountControl",
                Message = message,
                Exception = exception,
                Environment = _environment.EnvironmentName
            };

            _publisher.SendLog(log);
        }

        public void LogWarning(string message, string? exception = null)
        {
            var log = new LogMessageDto
            {
                Level = "WARNING",
                MicroserviceName = "AccountControl",
                Message = message,
                Exception = exception,
                Environment = _environment.EnvironmentName
            };

            _publisher.SendLog(log);
        }

        public void LogError(string message, string? exception = null)
        {
            var log = new LogMessageDto
            {
                Level = "ERROR",
                MicroserviceName = "AccountControl",
                Message = message,
                Exception = exception,
                Environment = _environment.EnvironmentName
            };

            _publisher.SendLog(log);
        }
    }
}
