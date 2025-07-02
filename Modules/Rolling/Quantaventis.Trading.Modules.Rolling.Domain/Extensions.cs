using System.Runtime.CompilerServices;

using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Modules.Rolling.Domain.Services;


[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Rolling.Api")]
[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Rolling.Infrastructure")]

namespace Quantaventis.Trading.Modules.Rolling.Domain
{
    internal static class Extensions
    {


        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            return services.AddScoped<IPositionRolloverGenerator, PositionRolloverGenerator>();

        }



    }
}
