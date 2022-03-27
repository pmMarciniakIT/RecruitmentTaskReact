using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace RecruitmentTask.Infrastructure.Extensions
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "ASP.NET 6 React", Version = "v1" });
            });

            return services;
        }

        public static WebApplication ConfigureSwaggerUI(this WebApplication webapp)
        {
            webapp.UseSwaggerUI(options =>
            {
                options.DocumentTitle = "ASP.NET 6 React";
                options.SwaggerEndpoint("swagger/v1/swagger.json", "Web API to Todolists.");
                options.RoutePrefix = string.Empty;
            });

            return webapp;
        }
    }
}
