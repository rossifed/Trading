using System.Runtime.CompilerServices;

using Microsoft.Extensions.DependencyInjection;


[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.EmsGateway.Api")]
[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.EmsGateway.Infrastructure")]

namespace Quantaventis.Trading.Modules.EmsGateway.Domain
{
    internal static class Extensions
    {


        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            return services;


        }



    }
}
