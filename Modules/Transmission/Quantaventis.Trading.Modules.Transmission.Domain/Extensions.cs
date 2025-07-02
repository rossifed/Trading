using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Modules.Transmission.Domain.Services;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Transmission.Api")]
[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Transmission.Infrastructure")]

namespace Quantaventis.Trading.Modules.Trades.Domain
{
    internal static class Extensions
    {


        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            return services.AddScoped<IFileNameGenerator, FileNameGenerator>()
                .AddScoped<IFileTransmitter, FileTransmitter>();


        }



    }
}
