using LogControl.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LogControl.Infrastructure.Configurations
{
    public static class DbInitializer
    {
        public static void UseDatabaseInitialization(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<LogDbContext>();

            try
            {
                db.Database.Migrate();
            }
            catch
            {
                db.Database.EnsureCreated();
            }
        }
    }
}
