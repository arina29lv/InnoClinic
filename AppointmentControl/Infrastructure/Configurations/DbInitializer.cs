using AppointmentControl.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AppointmentControl.Infrastructure.Configurations
{
    public static class DbInitializer
    {
        public static void UseDatabaseInitialization(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppointmentDbContext>();

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
