using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;


[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Locates.Api")]
namespace Quantaventis.Trading.Modules.Locates.Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services//.AddDatabase<OrdersDbContext>()
                .AddDaos()
                .AddRepositories()
                .AddServices();


        }

        private static IServiceCollection AddDaos(this IServiceCollection services)
            => services;


        private static IServiceCollection AddRepositories(this IServiceCollection services)
            => services;
        private static IServiceCollection AddServices(this IServiceCollection services)
             => services;


    }
}
