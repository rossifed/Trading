using System.Runtime.CompilerServices;

using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Modules.Positions.Domain.Repositories;
using Quantaventis.Trading.Modules.Positions.Domain.Services;


[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Positions.Api")]
[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Positions.Infrastructure")]

namespace Quantaventis.Trading.Modules.Weights.Domain
{
    internal static class Extensions
    {

        internal static IServiceCollection AddDomain(this IServiceCollection services)
        => services
        .AddScoped<IPositionGenerator, PositionGenerator>();




    }
}
