using System.Runtime.CompilerServices;
using Quantaventis.Trading.Modules.Weights.Domain.Model;
using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Modules.Weights.Domain.Services;

[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Weights.Api")]
[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Weights.Infrastructure")]

namespace Quantaventis.Trading.Modules.Weights.Domain
{
    internal static class Extensions
    {



        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            return services.AddScoped<IContractConversionService, ContractConversionService>();

        }


    }
}
