using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Modules.Trades.Api.Services;

//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Dao;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Entities;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Repositories;
//using Quantaventis.Trading.Modules.Portfolios.Domain.Repositories;
//using Quantaventis.Trading.Modules.Weights.Infrastructure.Files;
using Quantaventis.Trading.Modules.Trades.Infrastructure;

namespace Quantaventis.Trading.Modules.Trades.Api
{
    internal static class Extensions
    {
        public static IServiceCollection AddModule(this IServiceCollection services)
        {
            services.AddControllers();
            return services.AddInfrastructure()
                .AddACL()
                .AddModuelClients()
            .AddServices();
          
           

        }
        private static IServiceCollection AddModuelClients(this IServiceCollection services)
         => services;

        private static IServiceCollection AddACL(this IServiceCollection services)
              => services;

        private static IServiceCollection AddServices(this IServiceCollection services)
          => services.AddScoped<ITradeBookingService, TradeBookingService>()
            .AddScoped<ITradeValidationService, TradeValidationService>();
 


    }
}
