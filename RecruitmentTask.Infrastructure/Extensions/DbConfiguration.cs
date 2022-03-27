using Microsoft.Extensions.DependencyInjection;
using RecruitmentTask.DataAccess;

namespace RecruitmentTask.Infrastructure.Extensions
{
    public static class DbConfiguration
    {
        public static IServiceCollection ConfigureDatabase(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ApplicationDbContext>();

            return serviceCollection;
        }
    }
}
