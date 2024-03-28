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

            var azureDB = Convert.ToBoolean(Convert.ToInt32(configuration.GetConnectionString("AzureDB")));

            if (!azureDB)
            {
                services.AddDbContext<EDucaTdaContext>(
                option => option.UseSqlServer(
                    configuration.GetConnectionString("PersitenceConnection"),
                    b => b.MigrationsAssembly(assembly)), ServiceLifetime.Transient);
            }
            else
            {
                services.AddDbContext<EDucaTdaContext>(
                option => option.UseSqlServer(
                    configuration.GetConnectionString("AzureConnection"),
                    b => b.MigrationsAssembly(assembly)), ServiceLifetime.Transient);
            }

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}
