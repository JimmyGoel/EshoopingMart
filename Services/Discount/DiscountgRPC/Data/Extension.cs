using Microsoft.EntityFrameworkCore;

namespace DiscountgRPC.Data
{
    public static class Extensions
    {
        public static IApplicationBuilder UseMigration(this IApplicationBuilder app)
        {
            using var scop = app.ApplicationServices.CreateScope();
            var dbcontext = scop.ServiceProvider.GetRequiredService<DiscountContext>();
            dbcontext.Database.MigrateAsync();

            return app;
        }
    }
}
