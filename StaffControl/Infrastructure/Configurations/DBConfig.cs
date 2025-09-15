using Microsoft.EntityFrameworkCore;
using StaffControl.Infrastructure.Persistence;

namespace StaffControl.Infrastructure.Configurations
{
    public static class DBConfig
    {
        public static void AddDatabaseContext(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<StaffDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                        sql => sql.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(10),
                        errorNumbersToAdd: null)));
        }
    }
}
