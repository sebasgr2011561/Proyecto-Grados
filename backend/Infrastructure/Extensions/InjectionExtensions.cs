using Infrastructure.FileStorage;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Interfaces;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = typeof(EDucaTdaContext).Assembly.FullName;

            var ConnectionId = Convert.ToInt32(configuration.GetConnectionString("IdConnection"));

            if (ConnectionId == 0)
            {
                // PersistenceConnection
                services.AddDbContext<EDucaTdaContext>(
                option => option.UseSqlServer(
                    configuration.GetConnectionString("Persistence"),
                    b => b.MigrationsAssembly(assembly)), ServiceLifetime.Transient);
            }
            else if (ConnectionId == 1)
            {
                // LocalConnection
                services.AddDbContext<EDucaTdaContext>(
                option => option.UseSqlServer(
                    configuration.GetConnectionString("Azure"),
                    b => b.MigrationsAssembly(assembly)), ServiceLifetime.Transient);
            }

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IAzureStorage, AzureStorage>();
            services.AddTransient<IFileStorageLocal, FileStorageLocal>();

            return services;
        }
    }
}
