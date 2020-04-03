using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public static class StartupDataAccess
    {
        public static void AddDbContext(this IServiceCollection services, string ConnectionString) =>
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(ConnectionString, providerOptions => providerOptions.CommandTimeout(60))
                          .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
    }
}
