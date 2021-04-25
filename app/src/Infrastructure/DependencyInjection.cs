using Application;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // AppDbContext will use DbContextConfigurator to load model configuration from this assembly
            // this decouples Application and Infrastructure layers
            services.AddTransient<IDbContextConfigurator, DbContextConfigurator>();
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection"),
                    builder =>
                    {
                        builder.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                    });
            });
            return services;
        }
    }
}