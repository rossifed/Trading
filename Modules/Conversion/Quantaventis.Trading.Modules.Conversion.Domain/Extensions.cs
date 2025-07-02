using System.Runtime.CompilerServices;
using Quantaventis.Trading.Modules.Conversion.Domain.Model;
using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Modules.Conversion.Domain.Services;

[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Conversion.Api")]
[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Conversion.Infrastructure")]

namespace Quantaventis.Trading.Modules.Conversion.Domain
{
    internal static class Extensions
    {



        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            return services.AddScoped<ITargetWeightConversionService, TargetWeightConversionService>();

        }


    }
}
