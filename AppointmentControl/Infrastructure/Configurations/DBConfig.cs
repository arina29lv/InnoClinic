using AppointmentControl.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AppointmentControl.Infrastructure.Configurations
{
    public static class DBConfig
    {
        public static void AddDatabaseContext(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppointmentDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                        sql => sql.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(10),
                        errorNumbersToAdd: null)));
        }
    }
}
