using Microsoft.Extensions.DependencyInjection;

//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Dao;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Entities;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Repositories;
//using Quantaventis.Trading.Modules.Portfolios.Domain.Repositories;
//using Quantaventis.Trading.Modules.Weights.Infrastructure.Files;
using Quantaventis.Trading.Shared.Infrastructure;
using Quantaventis.Trading.Modules.MarketData.Infrastructure.Options;
using Quantaventis.Trading.Modules.MarketData.Infrastructure;
using Quantaventis.Trading.Modules.MarketData.Api.Services;

namespace Quantaventis.Trading.Modules.MarketData.Api
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
          => services.AddScoped<IMarketDataUpdateService, MarketDataUpdateService>()
            .AddScoped<IVolumeDataUpdateService, VolumeDataUpdateService>();
    




        private static IServiceCollection AddOptions(this IServiceCollection services)
        {
           

                AzureBlobStorageOptions blobStorageOptions = services.GetOptions<AzureBlobStorageOptions>("MarketData:AzureBlobStorage");
                services.AddSingleton(blobStorageOptions);
                return services;
            
        }
    }
}
