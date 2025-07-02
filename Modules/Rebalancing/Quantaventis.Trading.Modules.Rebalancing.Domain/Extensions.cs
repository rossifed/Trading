using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Modules.Rebalancing.Domain.Services;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Rebalancing.Api")]
[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Rebalancing.Infrastructure")]
[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Rebalancing.Tests")]
namespace Quantaventis.Trading.Modules.Rebalancing.Domain
{
    internal static class Extensions
    {


        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            return services.AddScoped<ITradeDateResolver, TradeDateResolver>();


        }



    }
}
