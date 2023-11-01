using GenAns.Services;
using GenAns.Services.Interfaces;

namespace GenAns.Config
{
    public static class ConfigService
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddScoped<IDataService, DataService>();
            services.AddScoped<IMaterialService, MaterialService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ISegmentationService, SegmentationService>();
            return services;
        }
    }
}
