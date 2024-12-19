using Microsoft.EntityFrameworkCore;
using SchoolPortal.Infrastruct.Domain.Context;

namespace SchoolPortal.Api.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();
            using SchoolPortalDbContext dbContext = scope.ServiceProvider.GetRequiredService<SchoolPortalDbContext>();
            dbContext.Database.Migrate();
        }
    }
}
