using Microsoft.Extensions.DependencyInjection;
using RecruitmentTask.DataAccess.Repositories;
using RecruitmentTask.Domain.Repositories;
using RecruitmentTask.Domain.Services;
using RecruitmentTask.Infrastructure.Services;

namespace RecruitmentTask.Infrastructure.Extensions
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(TRepository<>));
            services.AddScoped<ITodoRepository, TodoRepository>();
            services.AddScoped<ITodoService, TodoService>();

            return services;
        }
    }
}