using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Shared.Infrastructure.Database;
using System.Runtime.CompilerServices;
using Quantaventis.Trading.Modules.Execution.Infrastructure.Entities;
using Quantaventis.Trading.Modules.Execution.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Execution.Domain.Repositories;
using Quantaventis.Trading.Modules.Execution.Infrastructure.Repositories;
[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Execution.Api")]
namespace Quantaventis.Trading.Modules.Execution.Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services.AddDatabase<ExecutionDbContext>()
                .AddDaos()
                .AddRepositories()
                .AddServices();


        }

        private static IServiceCollection AddDaos(this IServiceCollection services)
            => services.AddScoped<IEmsxFillDao, EmsxFillDao>()
            .AddScoped<IEmsxOrderDao, EmsxOrderDao>()
            .AddScoped<IEmsxRouteDao, EmsxRouteDao>();


        private static IServiceCollection AddRepositories(this IServiceCollection services)
            => services
            .AddScoped<IEmsxOrderExecutionRepository, EmsxOrderExecutionRepository>()
            .AddScoped<IEmsxOrderRepository, EmsxOrderRepository>();
        private static IServiceCollection AddServices(this IServiceCollection services)
             => services;


    }
}
