using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Modules.Positions.Domain.Repositories;
using Quantaventis.Trading.Modules.Positions.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Positions.Infrastructure.Entities;
using Quantaventis.Trading.Modules.Positions.Infrastructure.Repositories;
using Quantaventis.Trading.Shared.Infrastructure.Database;


using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Positions.Api")]
namespace Quantaventis.Trading.Modules.Positions.Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services.AddDatabase<PositionsDbContext>().AddDaos().AddRepositories();

        }

        private static IServiceCollection AddDaos(this IServiceCollection services)
            => services.AddScoped<ITradeAllocationDao, TradeAllocationDao>()
            .AddScoped<IPositionDao, PositionDao>();


        private static IServiceCollection AddRepositories(this IServiceCollection services)
        => services
            .AddScoped<IPositionRepository, PositionRepository>()
            .AddScoped<ITradeAllocationRepository, TradeAllocationRepository>();




    }
}
