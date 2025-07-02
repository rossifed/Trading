using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Modules.Risk.Api.Services;
using Quantaventis.Trading.Modules.Risk.Domain;
using Quantaventis.Trading.Modules.Risk.Infrastructure;
namespace Quantaventis.Trading.Modules.Risk.Api
{
    internal static class Extensions
    {
        public static IServiceCollection AddModule(this IServiceCollection services)
        {
            services.AddInfrastructure()
               .AddServices()
               .AddDomain()
               .AddSwaggerGen();
            services.AddControllers();
            return services;

        }
        private static IServiceCollection AddServices(this IServiceCollection services)
          => services.AddScoped<ITargetAllocationCheckService, TargetAllocationCheckService>();


    }
}
