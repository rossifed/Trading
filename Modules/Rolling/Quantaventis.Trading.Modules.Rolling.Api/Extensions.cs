using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Modules.Rolling.Domain;
using Quantaventis.Trading.Modules.Rolling.Domain.Services;
using Quantaventis.Trading.Modules.Rolling.Infrastructure;

namespace Quantaventis.Trading.Modules.Rolling.Api
{
    internal static class Extensions
    {
        public static IServiceCollection AddModule(this IServiceCollection services)
        {
            services.AddControllers();
            return services.AddInfrastructure()
                .AddDomainServices()
            .AddServices()          
           .AddSwaggerGen();
          
           

        }
        private static IServiceCollection AddServices(this IServiceCollection services)
          => services.AddScoped<IPositionRollingService, PositionRollingService>();


    }
}
