using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Shared.Infrastructure.Database;
using Quantaventis.Trading.Modules.Rebalancing.Infrastructure.Repositories;
using Quantaventis.Trading.Modules.Rebalancing.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Rebalancing.Infrastructure.Entities;
using System.Runtime.CompilerServices;
using Quantaventis.Trading.Modules.Rebalancing.Domain.Repositories;

[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Rebalancing.Api")]
namespace Quantaventis.Trading.Modules.Rebalancing.Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services.AddDatabase<RebalancingDbContext>()
                .AddDaos()
                .AddRepositories();


        }

        private static IServiceCollection AddDaos(this IServiceCollection services)
            => services.AddScoped<IPortfolioDriftDao, PortfolioDriftDao>()

            .AddScoped<IPortfolioValuationDao, PortfolioValuationDao>()
            .AddScoped<ITargetAllocationValuationDao, TargetAllocationValuationDao>()
            .AddScoped<IRebalancingSessionDao, RebalancingSessionDao>()
            .AddScoped<IInstrumentDao, InstrumentDao>()
             .AddScoped<IPortfolioDao, PortfolioDao>();


        private static IServiceCollection AddRepositories(this IServiceCollection services)
            => services.AddScoped<IPortfolioDriftRepository, PortfolioDriftRepository>()
            
            .AddScoped<IPortfolioValuationRepository, PortfolioValuationRepository>()
            .AddScoped<ITargetAllocationValuationRepository, TargetAllocationValuationRepository>()
            .AddScoped<IRebalancingSessionRepository, RebalancingSessionRepository>();
        

    }
}
