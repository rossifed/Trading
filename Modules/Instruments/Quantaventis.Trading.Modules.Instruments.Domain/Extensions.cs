using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Instruments.Api")]
[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Instruments.Infrastructure")]

namespace Quantaventis.Trading.Modules.Instruments.Domain
{
    internal static class Extensions
    {


        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            return services; ;


        }



    }
}
