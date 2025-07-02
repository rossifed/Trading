using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Modules.Booking.Domain.Repositories;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Repository;
using Quantaventis.Trading.Shared.Infrastructure.Database;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Booking.Api")]
namespace Quantaventis.Trading.Modules.Booking.Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services.AddDatabase<BookingDbContext>()
                .AddDaos()
                 .AddUnitOfWork<BookingUnitOfWork>()
                .AddRepositories()
                .AddServices();
        }

        private static IServiceCollection AddDaos(this IServiceCollection services)
            => services
            .AddScoped<IInstrumentDao, InstrumentDao>()
    
             .AddScoped<ITradeDao, TradeDao>()
            .AddScoped<IOrderAllocationDao, OrderAllocationDao>()
            .AddScoped<ITradeAllocationDao, TradeAllocationDao>()
            .AddScoped<IRawTradeAllocationDao, RawTradeAllocationDao>()
            .AddScoped<IClearingAccountDao, ClearingAccountDao>()
            .AddScoped<ICommissionScheduleDao, CommissionScheduleDao>()
            .AddScoped<ICounterpartyRoleSetupDao, CounterpartyRoleSetupDao>()
            .AddScoped<IRawTradeDao, RawTradeDao>()
            .AddScoped<IExecutionDeskDao, ExecutionDeskDao>()
            .AddScoped<IExecutionTypeDao, ExecutionTypeDao>()
            .AddScoped<IFutureSwapDao, FutureSwapDao>()
            .AddScoped<IFxRateDao, FxRateDao>()
            .AddScoped<IPortfolioDao, PortfolioDao>()
            .AddScoped<ISettlementInfoDao, SettlementInfoDao>()
            .AddScoped<ITradeInstrumentTypeDao, TradeInstrumentTypeDao>()
            .AddScoped<ITradeBookingErrorDao, TradeBookingErrorDao>()
            .AddScoped<IOrderDao, OrderDao>();


        private static IServiceCollection AddRepositories(this IServiceCollection services)
            => services.AddScoped<IRawTradeAllocationRepository, RawTradeAllocationRepository>()
            .AddScoped<IOrderAllocationRepository, OrderAllocationRepository>()
             .AddScoped<IClearingAccountRepository, ClearingAccountRepository>()
             .AddScoped<ICommissionRepository, CommissionRepository>()
             .AddScoped<ICounterpartyRoleSetupRepository, CounterpartyRoleSetupRepository>()
             .AddScoped<IRawTradeRepository, RawTradeRepository>()
              .AddScoped<IBookedTradeRepository, BookedTradeRepository>()
             .AddScoped<IExecutionDeskRepository, ExecutionDeskRepository>()
             .AddScoped<IExecutionTypeRepository, ExecutionTypeRepository>()
             .AddScoped<IFutureSwapRepository, FutureSwapRepository>()
             .AddScoped<IFxRateRepository, FxRateRepository>()
             .AddScoped<IInstrumentRepository, InstrumentRepository>()
             .AddScoped<ISettlementInfoRepository, SettlementInfoRepository>()
            .AddScoped<IPortfolioRepository, PortfolioRepository>()
                 .AddScoped<ITradeBookingErrorRepository, TradeBookingErrorRepository>()
             .AddScoped<ITradeInstrumentTypeRepository, TradeInstrumentTypeRepository>()
            .AddScoped<IOrderRepository, OrderRepository>();

        private static IServiceCollection AddServices(this IServiceCollection services)
             => services;

      

 
    }
}
