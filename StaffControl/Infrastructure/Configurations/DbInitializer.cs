using Microsoft.EntityFrameworkCore;
using StaffControl.Infrastructure.Persistence;

namespace StaffControl.Infrastructure.Configurations
{
    public static class DbInitializer
    {
        public static void UseDatabaseInitialization(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<StaffDbContext>();

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
