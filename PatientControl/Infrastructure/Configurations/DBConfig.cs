using Microsoft.EntityFrameworkCore;
using PatientControl.Infrastructure.Persistence;

namespace PatientControl.Infrastructure.Configurations
{
    public static class DBConfig
    {
        public static void AddDatabaseContext(this WebApplicationBuilder builder) 
        {
            builder.Services.AddDbContext<PatientDbContext>(options =>
              options.UseSqlServer(
                 builder.Configuration.GetConnectionString("DefaultConnection"),
                 sql => sql.EnableRetryOnFailure(
                     maxRetryCount: 5,
                     maxRetryDelay: TimeSpan.FromSeconds(10),
                     errorNumbersToAdd: null)));
        }
    }
}
