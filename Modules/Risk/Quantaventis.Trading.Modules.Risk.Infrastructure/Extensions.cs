using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Modules.Risk.Domain.Repositories;
using Quantaventis.Trading.Modules.Risk.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Risk.Infrastructure.Entities;
using Quantaventis.Trading.Modules.Risk.Infrastructure.Repositories;
using System.Runtime.CompilerServices;
using Quantaventis.Trading.Shared.Infrastructure.Database;
[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Risk.Api")]
namespace Quantaventis.Trading.Modules.Risk.Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services
                .AddDatabase<RiskDbContext>()
                 .AddDaos()
                .AddRepositories()
                .AddFileReaders();

        }

        private static IServiceCollection AddDaos(this IServiceCollection services)
            => services.AddScoped<IConstraintDao, ConstraintDao>()
            .AddScoped<ITargetAllocationCheckDao, TargetAllocationCheckDao>()
                .AddScoped<IInstrumentDao, InstrumentDao>()
             .AddScoped<IPortfolioDao, PortfolioDao>();


        private static IServiceCollection AddRepositories(this IServiceCollection services)
        => services.AddScoped<IConstraintRepository, ConstraintRepository>()
            .AddScoped<ITargetAllocationCheckRepository, TargetAllocationCheckRepository>();
        private static IServiceCollection AddFileReaders(this IServiceCollection services)
        {
            return services;
        }

    }
}
