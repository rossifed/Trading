using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using Quantaventis.Trading.Modules.EmsGateway.Infrastructure.Services;
using Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API;

[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.EmsGateway.Api")]
[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.EmsGateway.Infrastructure.IntegrationTests")]
namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services
                .AddDaos()
                .AddRepositories()
                .AddServices();


        }

        private static IServiceCollection AddDaos(this IServiceCollection services)
            => services;


        private static IServiceCollection AddRepositories(this IServiceCollection services)
            => services;
        private static IServiceCollection AddServices(this IServiceCollection services)
             => services
            .AddSingleton<IEmsxSessionFactory, EmsxSessionFactory>()
            .AddSingleton<IEmsxService, EmsxService>()
            .AddSingleton<IEmsxErrorHandler, EmsxErrorHandler>();
    }
}
