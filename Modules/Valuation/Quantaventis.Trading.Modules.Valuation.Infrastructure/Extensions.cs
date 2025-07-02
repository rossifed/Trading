using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Modules.Valuation.Domain.Repositories;
using Quantaventis.Trading.Modules.Valuation.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Valuation.Infrastructure.Entities;
using Quantaventis.Trading.Modules.Valuation.Infrastructure.Factories;
using Quantaventis.Trading.Modules.Valuation.Infrastructure.Repositories;
using Quantaventis.Trading.Shared.Infrastructure.Database;


using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Valuation.Api")]
[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Valuation.Gui")]
namespace Quantaventis.Trading.Modules.Valuation.Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services
                .AddDatabase<ValuationDbContext>()
                .AddDaos()
                .AddFactoriess()
                .AddRepositories();

        }

        private static IServiceCollection AddDaos(this IServiceCollection services)
            => services
            .AddScoped<IPortfolioValuationDao, PortfolioValuationDao>()
            .AddScoped<IInstrumentPricingDao, InstrumentPricingDao>()
            .AddScoped<IFxRateDao, FxRateDao>()
             .AddScoped<IFutureContractDao, FutureContractDao>()
            .AddScoped<IInstrumentDao, InstrumentDao>()
            .AddScoped<IPortfolioDao, PortfolioDao>()
            .AddScoped<IPositionDao, PositionDao>()
            .AddScoped<ITargetAllocationDao, TargetAllocationDao>()
            .AddScoped<ITargetAllocationValuationDao, TargetAllocationValuationDao>();



        private static IServiceCollection AddRepositories(this IServiceCollection services)
        => services.AddScoped<IFxRateRepository, FxRateRepository>()
                .AddScoped<IInstrumentRepository, InstrumentRepository>()
                 .AddScoped<ITargetAllocationRepository, TargetAllocationRepository>()
                .AddScoped<IPortfolioValuationRepository, PortfolioValuationRepository>()
                .AddScoped<IInstrumentPricingRepository, InstrumentPricingRepository>()
                .AddScoped<IFxRateRepository, FxRateRepository>()
            .AddScoped<IPortfolioRepository, PortfolioRepository>()
            .AddScoped<ITargetAllocationValuationRepository, TargetAllocationValuationRepository>();

        private static IServiceCollection AddFactoriess(this IServiceCollection services)
=> services.AddScoped<IInstrumentFactory, InstrumentFactory>();


    }
}
