using Microsoft.EntityFrameworkCore;
using PatientControl.Infrastructure.Persistence;

namespace PatientControl.Infrastructure.Configurations
{
    public static class DbInitializer
    {
        public static void UseDatabaseInitialization(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<PatientDbContext>();

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
