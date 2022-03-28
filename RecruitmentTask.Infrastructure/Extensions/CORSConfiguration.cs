using Microsoft.Extensions.DependencyInjection;

namespace RecruitmentTask.Infrastructure.Extensions
{
    public static class CORSConfiguration
    {
        public static IServiceCollection ConfigureCORS(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddCors(options =>
            {
                options.AddPolicy("Default", builder =>
                {
                    builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            return serviceCollection;
        }
    }
}
