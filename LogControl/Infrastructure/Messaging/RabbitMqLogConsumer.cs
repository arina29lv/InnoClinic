//using LogControl.Application.Interfaces;
//using LogControl.Domain.Entity;
//using RabbitMQ.Client;
//using RabbitMQ.Client.Events;
//using System.Text;
//using System.Text.Json;

//namespace LogControl.Infrastructure.Messaging
//{
//    public class RabbitMqLogConsumer : BackgroundService
//    {
//        private readonly IServiceScopeFactory _scopeFactory;
//        private IConnection _connection;
//        private IModel _channel;
//        private readonly string _queueName = "log_queue";

//        public RabbitMqLogConsumer(IServiceScopeFactory scopeFactory)
//        {
//            _scopeFactory = scopeFactory;
//            InitializeRabbitMqListener();
//        }

//        private void InitializeRabbitMqListener()
//        {
//            var factory = new ConnectionFactory
//            {
//                HostName = "localhost",
//                Port = 5672,
//                UserName = "guest",
//                Password = "guest"
//            };

//            _connection = factory.CreateConnection();
//            _channel = _connection.CreateModel();

//            _channel.QueueDeclare(queue: _queueName,
//                                  durable: true,
//                                  exclusive: false,
//                                  autoDelete: false,
//                                  arguments: null);
//        }

//        protected override Task ExecuteAsync(CancellationToken stoppingToken)
//        {
//             var consumer = new EventingBasicConsumer(_channel);

//            consumer.Received += async (model, ea) =>
//            {
//                try
//                {
//                    var body = ea.Body.ToArray();
//                    var json = Encoding.UTF8.GetString(body);
//                    var logMessage = JsonSerializer.Deserialize<Log>(json);

//                    if (logMessage != null)
//                    {
//                        using var scope = _scopeFactory.CreateScope();
//                        var logService = scope.ServiceProvider.GetRequiredService<ILogService>();

//                        await logService.HandleLogAsync(logMessage);
//                    }

//                    _channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine("Error handling message: " + ex.Message);
//                }
//            };

//            _channel.BasicConsume(queue: _queueName,
//                                  autoAck: false,
//                                  consumer: consumer);

//            return Task.CompletedTask;
//        }

//        public override void Dispose()
//        {
//            _channel?.Close();
//            _connection?.Close();
//            base.Dispose();
//        }
//    }
//}
