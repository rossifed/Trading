using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Modules.Orders.Infrastructure.Entities;
using System.Runtime.CompilerServices;
using Quantaventis.Trading.Shared.Infrastructure.Database;
using Quantaventis.Trading.Modules.Orders.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Orders.Domain.Repositories;
using Quantaventis.Trading.Modules.Orders.Infrastructure.Repositories;


[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Orders.Api")]
namespace Quantaventis.Trading.Modules.Orders.Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services.AddDatabase<OrdersDbContext>()
                .AddDaos()
                .AddRepositories()
                .AddServices();


        }

        private static IServiceCollection AddDaos(this IServiceCollection services)
            => services.AddScoped<IOrderDao, OrderDao>()
            .AddScoped<IInstrumentDao, InstrumentDao>()

            .AddScoped<IBrokerSelectionRuleDao, BrokerSelectionRuleDao>()
            .AddScoped<IExecutionProfileSelectionRuleDao, ExecutionProfileSelectionRuleDao>()
            .AddScoped<ITradeModeSelectionRuleDao, TradeModeSelectionRuleDao>()
            .AddScoped<ITradingAccountSelectionRuleDao, TradingAccountSelectionRuleDao>()
            .AddScoped<IOrderAllocationDao, OrderAllocationDao>()
            .AddScoped<IPortfolioDao, PortfolioDao>()
            .AddScoped<IBrokerSelectionRuleOverrideDao, BrokerSelectionRuleOverrideDao>()
            .AddScoped<IExecutionProfileSelectionRuleOverrideDao, ExecutionProfileSelectionRuleOverrideDao>();


        private static IServiceCollection AddRepositories(this IServiceCollection services)
            => services.AddScoped<IOrderRepository, OrderRepository>()
            .AddScoped<IAccountSelectionRuleRepository, AccountSelectionRuleRepository>()
            .AddScoped<IInstrumentRepository, InstrumentRepository>()
            .AddScoped<IBrokerSelectionRuleRepository, BrokerSelectionRuleRepository>()
            .AddScoped<IExecutionProfileSelectionRuleRepository, ExecutionProfileSelectionRuleRepository>()
            .AddScoped<ITradeModeSelectionRuleRepository, TradeModeSelectionRuleRepository>()
            .AddScoped<IPortfolioRepository, PortfolioRepository>()
            .AddScoped<IOrderRepository, OrderRepository>()
            .AddScoped<IBrokerSelectionRuleOverrideRepository, BrokerSelectionRuleOverrideRepository>()
            .AddScoped<IExecutionProfileSelectionRuleOverrideRepository, ExecutionProfileSelectionRuleOverrideRepository>();
        private static IServiceCollection AddServices(this IServiceCollection services)
             => services;


    }
}
