using Microsoft.Extensions.DependencyInjection;
using DataAccess;

namespace Services
{
    public static class StartupService
    {
        public static void AddDbContext(this IServiceCollection services, string ConnectionString)
        {
            StartupDataAccess.AddDbContext(services, ConnectionString);
        }
    }
}
