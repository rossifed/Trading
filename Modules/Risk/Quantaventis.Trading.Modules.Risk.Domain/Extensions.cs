using System.Runtime.CompilerServices;

using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Modules.Risk.Domain.Model.Constraints;

[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Risk.Api")]
[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Risk.Infrastructure")]

namespace Quantaventis.Trading.Modules.Risk.Domain
{
    internal static class Extensions
    {


        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            return services.AddScoped<IConstraintFactory, ConstraintFactory>();

        }



    }
}
