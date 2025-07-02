using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Locates.Api")]
[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Locates.Infrastructure")]

namespace Quantaventis.Trading.Modules.Locates.Domain
{
    internal static class Extensions
    {


        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            return services;


        }



    }
}
