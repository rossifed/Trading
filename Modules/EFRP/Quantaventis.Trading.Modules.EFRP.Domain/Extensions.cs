using System.Runtime.CompilerServices;

using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Modules.EFRP.Domain.Repositories;
using Quantaventis.Trading.Modules.EFRP.Domain.Services;

[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.EFRP.Api")]
[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.EFRP.Infrastructure")]

namespace Quantaventis.Trading.Modules.EFRP.Domain
{
    internal static class Extensions
    {


        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            return services.AddScoped<IEfrpDealAggregator, EfrpDealAggregator>();


        }



    }
}
