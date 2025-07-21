using Contracts.Logs.DTOs;
using LogControl.Application.Interfaces;
using LogControl.Domain.Entity;
using MassTransit;

namespace LogControl.Infrastructure.Messaging
{
    public class LogMessageConsumer : IConsumer<LogMessageDto>
    {
        private readonly ILogService _logService;

        public LogMessageConsumer(ILogService logService)
        {
            _logService = logService;
        }

        public async Task Consume(ConsumeContext<LogMessageDto> context)
        {
            var dto = context.Message;

            var log = new Log
            {
                Level = dto.Level,
                MicroserviceName = dto.MicroserviceName,
                Message = dto.Message,
                Exception = dto.Exception,
                Environment = dto.Environment
            };

            await _logService.HandleLogAsync(log);
        }
    }
}
