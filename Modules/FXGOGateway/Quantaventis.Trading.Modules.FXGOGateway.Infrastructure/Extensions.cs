using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Modules.FXGOGateway.Infrastructure.IO;

[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.FXGOGateway.Api")]
namespace Quantaventis.Trading.Modules.FXGOGateway.Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services.AddFileWriters();


        }

        private static IServiceCollection AddFileWriters(this IServiceCollection services)
            => services.AddScoped<IFXGOOrderFileWriter, FxemOrderFileWriter>();


 


    }
}
