using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;
using System.Runtime.CompilerServices;
using Quantaventis.Trading.Shared.Infrastructure.Database;
using Quantaventis.Trading.Modules.Instruments.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Instruments.Domain.Repositories;
using Quantaventis.Trading.Modules.Instruments.Infrastructure.Repositories;
using Quantaventis.Trading.Modules.Instruments.Infrastructure;
using Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;
using Quantaventis.Trading.Modules.Instruments.Infrastructure.Services;

[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Instruments.Api")]
namespace Quantaventis.Trading.Modules.Instruments.Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services.AddDatabase<InstrumentsDbContext>()
       
                .AddDaos()
                .AddRepositories()
                .AddServices()
                .AddUnitOfWork<InstrumentsUnitOfWork>();


        }

        private static IServiceCollection AddDaos(this IServiceCollection services)
            => services.AddScoped<ICurrencyPairDao, CurrencyPairDao>()
            .AddScoped<IInstrumentDao, InstrumentDao>()
            .AddScoped<IFxForwardDao, FxForwardDao>()
            .AddScoped<IFutureContractDao, FutureContractDao>()
            .AddScoped<IGenericFutureDao, GenericFutureDao>()
               .AddScoped<ICurrencyDao, CurrencyDao>()
               .AddScoped<IExchangeDao, ExchangeDao>()
               .AddScoped<IMarketSectorDao, MarketSectorDao>()
               .AddScoped<IInstrumentTypeDao, InstrumentTypeDao>()
              .AddScoped<IFutureContractMonthDao, FutureContractMonthDao>()
            .AddScoped<IStgRefDataDao, StgRefDataDao>();


        private static IServiceCollection AddRepositories(this IServiceCollection services)
            => services
            .AddScoped<IInstrumentRepository, InstrumentRepository>()
            .AddScoped<ICurrencyRepository, CurrencyRepository>()
            .AddScoped<IMarketSectorRepository, MarketSectorRepository>()
            .AddScoped<IInstrumentTypeRepository, InstrumentTypeRepository>()
            .AddScoped<IExchangeRepository, ExchangeRepository>()
            .AddScoped<IGenericFutureRepository, GenericFutureRepository>()
            .AddScoped<IEquityRepository, EquityRepository>()
            .AddScoped<ICurrencyPairRepository, CurrencyPairRepository>()
            .AddScoped<IFxForwardRepository, FxForwardRepository>()
            .AddScoped<IFutureContractRepository, FutureContractRepository>()
            .AddScoped<IFutureContractMonthRepository, FutureContractMonthRepository>();
        private static IServiceCollection AddServices(this IServiceCollection services)
             => services.AddScoped<IFileDecompressionService, FileDecompressionService>()
            .AddScoped<IAzureBlobFileDownloadService, AzureBlobFileDownloadService>()
            .AddScoped<IAzureBlobFileIntegrationService, AzureBlobFileIntegrationService>()
            .AddScoped<IFileDecompressionService, FileDecompressionService>()
            .AddScoped<IDBIntegrationService<StgRefDatum>, StgRefDataUpdateService>()
            .AddScoped<IFileParsingService<StgRefDatum>, StgRefDataParsingService>()
            .AddScoped<IInstrumentDataIntegrationService, InstrumentDataIntegrationService>()
            .AddScoped<IFileToDBIntegrationService, FileToDBIntegrationService>();


    }
}
