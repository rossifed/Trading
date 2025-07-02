using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Trades.Api")]
[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Trades.Infrastructure")]

namespace Quantaventis.Trading.Modules.Trades.Domain
{
    internal static class Extensions
    {


        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            return services; ;


        }



    }
}
