using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("UsersDb");

            services.AddDbContext<UsersDbContext>(
                options => options.UseNpgsql(connectionString)
                );

            services.AddScoped<DbContext, UsersDbContext>();

            return services;
        }
    }
}
