using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Modules.Instruments.Api.Services;

//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Dao;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Entities;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Repositories;
//using Quantaventis.Trading.Modules.Portfolios.Domain.Repositories;
//using Quantaventis.Trading.Modules.Weights.Infrastructure.Files;
using Quantaventis.Trading.Modules.Instruments.Infrastructure;
using Quantaventis.Trading.Modules.Instruments.Infrastructure.Options;
using Quantaventis.Trading.Shared.Infrastructure;
namespace Quantaventis.Trading.Modules.Instruments.Api
{
    internal static class Extensions
    {
        public static IServiceCollection AddModule(this IServiceCollection services)
        {
     
            services.AddControllers();
            return services
                .AddOptions()
                .AddInfrastructure()
                .AddServices();



        }


        private static IServiceCollection AddServices(this IServiceCollection services)
          => services.AddScoped<IInstrumentUpdateService, InstrumentUpdateService>()
            .AddScoped<IContractChainsPublisher, FxForwardContractChainPublisher>()
            .AddScoped<IContractChainsPublisher, FutureContractChainPublisher>();
    




        private static IServiceCollection AddOptions(this IServiceCollection services)
        {
           

                AzureBlobStorageOptions blobStorageOptions = services.GetOptions<AzureBlobStorageOptions>("instruments:AzureBlobStorage");
                services.AddSingleton(blobStorageOptions);
                return services;
            
        }
    }
}
