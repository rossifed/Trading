using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Entities;
using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Repositories;
using Quantaventis.Trading.Shared.Infrastructure.Database;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Portfolios.Api")]
namespace Quantaventis.Trading.Modules.Portfolios.Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services.AddDatabase<PortfoliosDbContext>()
                 .AddDaos()
                .AddRepositories();

        }

        private static IServiceCollection AddDaos(this IServiceCollection services)
            => services.AddScoped<IPortfolioDao, PortfolioDao>()
            .AddScoped<IVwPositionDao, VwPositionDao>()
            .AddScoped<IInstrumentDao, InstrumentDao>()
            .AddScoped<ITradeAllocationDao, TradeAllocationDao>()
            .AddScoped<IBookedTradeAllocationDao, BookedTradeAllocationDao>()
            .AddScoped<IPositionDao, PositionDao>();


        private static IServiceCollection AddRepositories(this IServiceCollection services)
        => services.AddScoped<IPositionUpdateRepository, PositionUpdateRepository>();


    }
}
