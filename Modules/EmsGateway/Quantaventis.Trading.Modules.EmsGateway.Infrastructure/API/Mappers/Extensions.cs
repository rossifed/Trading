using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.Mappers
{
    public static class Extensions
    {
        public static IServiceCollection Map(this IServiceCollection services)
        {
            return services;


        }

        private static IServiceCollection AddDaos(this IServiceCollection services)
            => services;


        private static IServiceCollection AddRepositories(this IServiceCollection services)
            => services;
        private static IServiceCollection AddServices(this IServiceCollection services)
             => services;


    }
}
