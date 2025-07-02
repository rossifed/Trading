using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Modules.Booking.Api.Services;
using Quantaventis.Trading.Shared.Infrastructure;
using Quantaventis.Trading.Modules.Booking.Infrastructure;
using Quantaventis.Trading.Modules.Rebalancing.Domain;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Entities;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Repositories;
//using Quantaventis.Trading.Modules.Portfolios.Domain.Repositories;
//using Quantaventis.Trading.Modules.Weights.Infrastructure.Files;
namespace Quantaventis.Trading.Modules.Booking.Api

{
    internal static class Extensions
    {
        public static IServiceCollection AddModule(this IServiceCollection services)
        {
            services.AddOptions();
            services.AddControllers();
            return services.AddInfrastructure()
                .AddDomainServices()
            .AddServices();

        }

        private static IServiceCollection AddOptions(this IServiceCollection services)
        {
            return services;
        }
        private static IServiceCollection AddServices(this IServiceCollection services)
          => services
            .AddScoped<ITradeBookingService, TradeBookingService>()
            .AddScoped<IEmsxTradeCaptureService, EmsxTradeCaptureService>()
              .AddScoped<IEfrpTradeCaptureService, EfrpTradeCaptureService>()
            .AddScoped<ITradeAllocationService, TradeAllocationService>()
              .AddScoped<ITradeEnrichmentService, TradeEnrichmentService>()
            .AddScoped<ITradeValidationService, TradeValidationService>()
                 .AddScoped<ITradeCancellationService, TradeCancellationService>()
                 .AddScoped<ITradeCorrectionService, TradeCorrectionService>()
            .AddScoped<ITradeSynchronizationService, TradeSynchronizationService>()
               .AddScoped<IManualTradeCaptureService, ManualTradeCaptureService>();





    }
}
