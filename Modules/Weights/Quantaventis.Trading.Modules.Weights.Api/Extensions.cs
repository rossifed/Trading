using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Modules.Weights.Api.Clients;
using Quantaventis.Trading.Modules.Weights.Api.Services;
using Quantaventis.Trading.Modules.Weights.Infrastructure;
using Quantaventis.Trading.Modules.Weights.Infrastructure.Options;
using Quantaventis.Trading.Shared.Infrastructure;
using System.Configuration;
namespace Quantaventis.Trading.Modules.Weights.Api
{
    internal static class Extensions
    {
        public static IServiceCollection AddModule(this IServiceCollection services)
        {

            services
                .AddInfrastructure()
               
                .AddClients()
               .AddServices()
               .AddSwaggerGen();
            services.AddControllers();
            return services;

        }
      
        private static IServiceCollection AddClients(this IServiceCollection services)
         => services.AddScoped<IInstrumentsClient, InstrumentsClient>();

        private static IServiceCollection AddServices(this IServiceCollection services)
          => services
            .AddScoped<ISymbolToInstrumentMappingService, SymbolToInstrumentMappingService>()
            .AddScoped<ITargetAllocationGenerationService, TargetAllocationGenerationService>();


    }
}
