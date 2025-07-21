using Contracts;
using PatientControl.Infrastructure.Interfaces;

namespace PatientControl.Infrastructure.Services
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
                MicroserviceName = "PatientControl",
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
                MicroserviceName = "PatientControl",
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
                MicroserviceName = "PatientControl",
                Message = message,
                Exception = exception,
                Environment = _environment.EnvironmentName
            };

            _publisher.SendLog(log);
        }
    }
}
