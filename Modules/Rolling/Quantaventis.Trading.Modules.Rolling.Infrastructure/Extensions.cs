using Microsoft.Extensions.DependencyInjection;
using Entities =Quantaventis.Trading.Modules.Rolling.Infrastructure.Entities;
using Quantaventis.Trading.Modules.Rolling.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Rolling.Infrastructure.Repositories;
using Quantaventis.Trading.Shared.Infrastructure.Database;
using Quantaventis.Trading.Modules.Rolling.Domain.Repositories;
using Quantaventis.Trading.Modules.Rolling.Domain.Model;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Rolling.Api")]
namespace Quantaventis.Trading.Modules.Rolling.Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services
                 .AddDatabase<Entities.RollingDbContext>()
                .AddDaos()
                .AddRepositories();

        }

        private static IServiceCollection AddDaos(this IServiceCollection services)
            => services.AddScoped<IForwardContractDao, ForwardContractDao>()
            .AddScoped<IFutureContractDao, FutureContractDao>()
            .AddScoped<IPositionDao, PositionDao>()
            .AddScoped<IFutureRollInfoDao, FutureRollInfoDao>()
            .AddScoped<IFxForwardRollInfoDao, FxForwardRollInfoDao>();



        private static IServiceCollection AddRepositories(this IServiceCollection services)
              => services.AddScoped<IContractRollInfoRepository, ContractRollInfoRepository>()
            .AddScoped<IPositionRepository, PositionRepository>();




    }
}
