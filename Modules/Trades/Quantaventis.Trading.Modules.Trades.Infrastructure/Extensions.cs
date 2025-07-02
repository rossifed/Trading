using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Modules.Trades.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Trades.Infrastructure.Entities;
using Quantaventis.Trading.Modules.Trades.Infrastructure.Repositories;
using Quantaventis.Trading.Modules.Trades.Infrastructure.Services;
using Quantaventis.Trading.Shared.Infrastructure.Database;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Trades.Api")]
namespace Quantaventis.Trading.Modules.Trades.Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services.AddDatabase<TradesDbContext>()
                .AddDaos()
                .AddRepositories()
                .AddServices();


        }

        private static IServiceCollection AddDaos(this IServiceCollection services)
            => services.AddScoped<ITradeDao, TradeDao>()
            .AddScoped<IEmsxOrderDao, EmsxOrderDao>()
            .AddScoped<IInstrumentDao, InstrumentDao>();


        private static IServiceCollection AddRepositories(this IServiceCollection services)
            => services.AddScoped<ITradeBookingRepository, TradeBookingRepository>()
            .AddScoped<ITradeValidationRepository, TradeValidationRepository>()
               .AddScoped<ITradeStagingRepository, TradeStagingRepository>();
        private static IServiceCollection AddServices(this IServiceCollection services)
             => services.AddScoped<ICsvReaderService, CsvReaderService>()
            .AddScoped<IFileIntegrationService, FileIntegrationService>()
            .AddScoped<ITradeFileImportService, TradeFileImportService>();


    }
}
