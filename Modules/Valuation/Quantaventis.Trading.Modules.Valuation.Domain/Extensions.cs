using System.Runtime.CompilerServices;

using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Modules.Valuation.Domain.Repositories;


[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Valuation.Api")]
[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Valuation.Infrastructure")]

namespace Quantaventis.Trading.Modules.Valuation.Domain
{
    internal static class Extensions
    {


        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            return services;

        }



    }
}
