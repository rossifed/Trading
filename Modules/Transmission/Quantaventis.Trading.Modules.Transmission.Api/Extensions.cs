using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Modules.Transmission.Api.Services;
using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Shared.Infrastructure;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Dao;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Entities;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Repositories;
//using Quantaventis.Trading.Modules.Portfolios.Domain.Repositories;
//using Quantaventis.Trading.Modules.Weights.Infrastructure.Files;
using Quantaventis.Trading.Modules.Transmission.Api;
using Quantaventis.Trading.Modules.Transmission.Infrastructure;
using Quantaventis.Trading.Modules.Transmission.Api.Options;
using Quantaventis.Trading.Modules.Transmission.Api.Services;
using Quantaventis.Trading.Modules.Transmission.Domain.Services;
using Quantaventis.Trading.Modules.Trades.Domain;
namespace Quantaventis.Trading.Modules.Transmission.Api
{
    internal static class Extensions
    {
        public static IServiceCollection AddModule(this IServiceCollection services)
        {
            services.AddControllers();
            return services.AddOptions()
                .AddInfrastructure()
                .AddDomainServices()
                .AddACL()
                .AddModuelClients()
            .AddServices();
          
           

        }

        private static IServiceCollection AddOptions(this IServiceCollection services) {


            FileGenerationOptions fileGeneration = services.GetOptions<FileGenerationOptions>("transmission:FileGeneration");
            services.AddSingleton(fileGeneration);

         

            FileTransmissionOptions fileTransmission = services.GetOptions<FileTransmissionOptions>("transmission:FileTransmission");
            services.AddSingleton(fileTransmission);
            return services;
      
        }
        private static IServiceCollection AddModuelClients(this IServiceCollection services)
         => services;

        private static IServiceCollection AddACL(this IServiceCollection services)
              => services;

        private static IServiceCollection AddServices(this IServiceCollection services)
          => services.AddScoped<IFileTransmissionService, FileTransmissionService>()
            .AddScoped<IFileGenerationService, FileGenerationService>();
 


    }
}
