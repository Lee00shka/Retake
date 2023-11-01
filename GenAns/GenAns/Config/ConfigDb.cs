using GenAns.Data;
using Microsoft.EntityFrameworkCore;

namespace GenAns.Config
{
    public static class ConfigDb
    {
        public static void ConfigureDb(this WebApplicationBuilder builder)
        {
            var connection = builder.Configuration.GetConnectionString("Connection");
            builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));
        }
        public static void ConfigureDb(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<DbContext>();
                dbContext?.Database.Migrate();
            }
        }
    }
}
