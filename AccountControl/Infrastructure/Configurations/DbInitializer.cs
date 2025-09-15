using AccountControl.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AccountControl.Infrastructure.Configurations
{
    public static class DbInitializer
    {
        public static void UseDatabaseInitialization(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AccountDbContext>();

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
