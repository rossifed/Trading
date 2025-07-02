using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Modules.MarketData.Infrastructure.Dao;
using Quantaventis.Trading.Modules.MarketData.Infrastructure.Entities;
using Quantaventis.Trading.Modules.MarketData.Infrastructure.Services;
using Quantaventis.Trading.Shared.Infrastructure.Database;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.MarketData.Api")]
namespace Quantaventis.Trading.Modules.MarketData.Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services.AddDatabase<MarketDataDbContext>()
       
                .AddDaos()
                .AddRepositories()
                .AddServices()
                ;


        }

        private static IServiceCollection AddDaos(this IServiceCollection services)
            => services.AddScoped<IStgMarketDataDao, StgMarketDataDao>()
            .AddScoped<IStgVolumeDataDao, StgVolumeDataDao>();


        private static IServiceCollection AddRepositories(this IServiceCollection services)
            => services;
        private static IServiceCollection AddServices(this IServiceCollection services)
             => services
            .AddScoped<IAzureBlobFileDownloadService, AzureBlobFileDownloadService>()
            .AddScoped<IAzureBlobFileIntegrationService<StgMarketDatum>, AzureBlobFileIntegrationService<StgMarketDatum>>()
            .AddScoped<IFileDecompressionService, FileDecompressionService>()
            .AddScoped<IDBIntegrationService<StgMarketDatum>, StgMarketDataUpdateService>()
            .AddScoped<IFileParsingService<StgMarketDatum>, StgMarketDataParsingService>()
            .AddScoped<IMarketDataRepository, MarketDataRepository>()
            .AddScoped<IFileImportService<StgMarketDatum>, FileImportService<StgMarketDatum>>()
            .AddScoped<IFileImportService<StgVolumeDatum>, FileImportService<StgVolumeDatum>>()
            .AddScoped<IFxRateIntegrationService, FxRateIntegrationService>()
            .AddScoped<IDBIntegrationService<StgVolumeDatum>, StgVolumeDataUpdateService>()
            .AddScoped<IFileParsingService<StgVolumeDatum>, StgVolumeDataParsingService>()
            .AddScoped<IVolumeDataRepository, VolumeDataRepository>()
            .AddScoped<IAzureBlobFileIntegrationService<StgVolumeDatum>, AzureBlobFileIntegrationService<StgVolumeDatum>>();


    }
}
