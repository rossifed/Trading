using System.Runtime.CompilerServices;

using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Modules.Booking.Domain.Service;


[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Booking.Api")]
[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Booking.Infrastructure")]
[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Booking.Domain.Tests")]
namespace Quantaventis.Trading.Modules.Rebalancing.Domain
{
    internal static class Extensions
    {


        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            return services.AddScoped<IAllocationRule, SinglePortfolioAllocation>()
                .AddScoped<ITradeEnricher, TradeEnricher>()
                .AddScoped<ITradeAllocationEnricher, TradeAllocationEnricher>();


        }



    }
}
