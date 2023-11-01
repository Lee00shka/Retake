using GenAns.Services.Interfaces;

namespace GenAns.Config
{
    public static class ConfigDefaultBuckets
    {
        public static async Task CreateBuckets(this WebApplication app)
        {
            using var serviceScope = app.Services.CreateScope();
            var dataService = serviceScope.ServiceProvider.GetRequiredService<IDataService>();
        }
    }
}
