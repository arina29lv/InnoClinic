using PatientControl.Application.DTOs.Logs;
using PatientControl.Infrastructure.Interfaces;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace PatientControl.Infrastructure.Messaging
{
    public class RabbitMqLogPublisher : IRabbitMqLogPublisher
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private const string QueueName = "log_queue";

        public RabbitMqLogPublisher()
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                Port = 5672,
                UserName = "guest",
                Password = "guest"
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(queue: QueueName,
                                  durable: true,
                                  exclusive: false,
                                  autoDelete: false,
                                  arguments: null);
        }

        public void SendLog(LogMessageDto log)
        {
            var json = JsonSerializer.Serialize(log);
            var body = Encoding.UTF8.GetBytes(json);

            var properties = _channel.CreateBasicProperties();
            properties.Persistent = true;

            _channel.BasicPublish(exchange: "",
                                  routingKey: QueueName,
                                  basicProperties: properties,
                                  body: body);
        }

        public void Dispose()
        {
            _channel.Close();
            _connection.Close();
        }
    }
}