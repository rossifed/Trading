using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Execution.Api")]
[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Execution.Infrastructure")]
[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Execution.Domain.Tests")]
namespace Quantaventis.Trading.Modules.Rebalancing.Domain
{
    internal static class Extensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
