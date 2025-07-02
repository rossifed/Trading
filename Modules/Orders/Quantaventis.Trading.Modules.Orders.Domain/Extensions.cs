using System.Runtime.CompilerServices;

using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Modules.Orders.Domain.Repositories;
using Quantaventis.Trading.Modules.Orders.Domain.Services;

[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Orders.Api")]
[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Orders.Infrastructure")]

namespace Quantaventis.Trading.Modules.Orders.Domain
{
    internal static class Extensions
    {


        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            return services;


        }



    }
}
