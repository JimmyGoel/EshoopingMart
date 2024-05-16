using Microsoft.EntityFrameworkCore;

namespace DiscountgRPC.Data
{
    public static class Extension
    {
        public static IApplicationBuilder UseMigration(this IApplicationBuilder app)
        {
            using var scop = app.ApplicationServices.CreateScope();
            using var dbcontext = app.ApplicationServices.GetRequiredService<DiscountContext>();
            dbcontext.Database.MigrateAsync().Wait();
            return app;
        }
    }
}
