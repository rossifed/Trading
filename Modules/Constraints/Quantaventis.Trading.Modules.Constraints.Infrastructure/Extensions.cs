using Microsoft.Extensions.DependencyInjection;


using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Constraints.Api")]
namespace Quantaventis.Trading.Modules.Constraints.Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services;

        }

        private static IServiceCollection AddDaos(this IServiceCollection services)
            => services;


        private static IServiceCollection AddRepositories(this IServiceCollection services)
        => services;




    }
}
