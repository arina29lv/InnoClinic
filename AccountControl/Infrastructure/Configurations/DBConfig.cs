using AccountControl.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AccountControl.Infrastructure.Configurations
{
    public static class DBConfig
    {
        public static void AddDatabaseContext(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AccountDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                        sql => sql.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(10),
                        errorNumbersToAdd: null)));

        }
    }
}
