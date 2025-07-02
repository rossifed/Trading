using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Shared.Infrastructure;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Dao;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Entities;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Repositories;
//using Quantaventis.Trading.Modules.Portfolios.Domain.Repositories;
//using Quantaventis.Trading.Modules.Weights.Infrastructure.Files;
using Quantaventis.Trading.Modules.EmsGateway.Infrastructure;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;
using Quantaventis.Trading.Modules.EmsGateway.Api.Mappers;
using Quantaventis.Trading.Modules.EmsGateway.Api.Options;
using Quantaventis.Trading.Modules.EmsGateway.Api.ACL;
using Quantaventis.Trading.Modules.EmsGateway.Api.Dto;
using Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API;
using Quantaventis.Trading.Modules.EmsGateway.Api.Services;
using Quantaventis.Trading.Modules.EmsGateway.Api.Schedulers;
using Quantaventis.Trading.Shared.Infrastructure.Scheduling;
namespace Quantaventis.Trading.Modules.EmsGateway.Api
{
    internal static class Extensions
    {
        public static IServiceCollection AddModule(this IServiceCollection services)
        {
            services.AddOptions();
            services.AddControllers();
            return services.AddInfrastructure()
            .AddServices()
            .AddSchedulers();

        }

        private static IServiceCollection AddOptions(this IServiceCollection services)
        {
            EmsxOrderSyncTaskOptions emsxOrderSyncTaskOptions = services.GetOptions<EmsxOrderSyncTaskOptions>("emsgateway:EmsxOrderSyncTask");
            services.AddSingleton(emsxOrderSyncTaskOptions);


            IServiceCollection AddOrderMappingOptions() {

                OrderMappingConfig mappingOptions = services.GetOptions<OrderMappingConfig>("emsgateway:OrderMapping");
                services.AddSingleton(mappingOptions);
                return services;
            }

            IServiceCollection AddEMSXSessionOptions()
            {

                EmsxSessionOptions mappingOptions = services.GetOptions<EmsxSessionOptions>("emsgateway:EMSXSession");
                services.AddSingleton(mappingOptions);
                return services;
            }
            AddOrderMappingOptions();
            AddEMSXSessionOptions();
            return services;
        }
        private static IServiceCollection AddServices(this IServiceCollection services)
          => services.AddSingleton<IOrderToEmsxTranslator, OrderToEmsxTranslator>()
            .AddSingleton<IEmsxGatewayService, EmsxGatewayService>()
             .AddSingleton<IBasketNameGenerator, BasketNameGenerator>();

        private static IServiceCollection AddSchedulers(this IServiceCollection services)
            => services.AddSingleton<IScheduledTask, EmsxOrderSyncTask>();
    }
}
