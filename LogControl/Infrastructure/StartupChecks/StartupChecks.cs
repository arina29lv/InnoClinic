using Microsoft.Data.SqlClient;
using RabbitMQ.Client;

namespace LogControl.Infrastructure.StartupCheck
{
    public static class StartupChecks
    {
        public static async Task ValidateSqlServerAsync(string connectionString)
        {
            try
            {
                await using var connection = new SqlConnection(connectionString);
                await connection.OpenAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to connect to SQL Server.", ex);
            }
        }

        public static async Task ValidateRabbitMqAsync(string host, string username, string password)
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = host,
                    UserName = username,
                    Password = password
                };

                using var connection = await factory.CreateConnectionAsync(); // нормальное имя переменной
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to connect to RabbitMQ.", ex);
            }
        }
    }
}
