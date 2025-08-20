using Contracts.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Data.SqlClient; 
using RabbitMQ.Client;

namespace Contracts.Startup
{
    public static class StartupCheck
    {
        public static async Task ValidateSqlServerAsync(IServiceProvider serviceProvider, string connectionStringName)
        {
            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider), "Service provider is required.");
            }

            if (string.IsNullOrWhiteSpace(connectionStringName))
            {
                throw new ArgumentException(nameof(connectionStringName), "Connection string name must be provided.");
            }

            var config = serviceProvider.GetRequiredService<IConfiguration>();
            var connectionString = config.GetConnectionString(connectionStringName);

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException($"Connection string '{connectionStringName}' was not found or is empty.");
            }

            try
            {
                await using var connection = new SqlConnection(connectionString);
                await connection.OpenAsync();
                await connection.CloseAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    "Failed to connect to SQL Server. Make sure the database container is running and the connection string is correct.",
                    ex);
            }
        }

        public static async Task ValidateRabbitMqAsync(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider), "Service provider is required.");
            }

            var settings = serviceProvider.GetRequiredService<IOptions<RabbitMqSettings>>().Value;

            if (string.IsNullOrWhiteSpace(settings?.Host))
            {
                throw new InvalidOperationException("RabbitMQ host is not configured.");
            }

            if (string.IsNullOrWhiteSpace(settings.Username) || string.IsNullOrWhiteSpace(settings.Password))
                throw new InvalidOperationException("RabbitMQ credentials are not configured.");

            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = settings.Host,
                    UserName = settings.Username,
                    Password = settings.Password
                };

                using var _ = factory.CreateConnectionAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    "Failed to connect to RabbitMQ. Ensure the broker container is running and credentials are valid.",
                    ex);
            }
        }
    }
}
