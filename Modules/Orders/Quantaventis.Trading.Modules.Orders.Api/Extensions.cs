using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Modules.Orders.Api.ACL;
using Quantaventis.Trading.Modules.Orders.Api.Clients;
using Quantaventis.Trading.Modules.Orders.Api.Services;
using Quantaventis.Trading.Modules.Orders.Domain;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Dao;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Entities;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Repositories;
//using Quantaventis.Trading.Modules.Portfolios.Domain.Repositories;
//using Quantaventis.Trading.Modules.Weights.Infrastructure.Files;
using Quantaventis.Trading.Modules.Orders.Infrastructure;

namespace Quantaventis.Trading.Modules.Orders.Api
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
         => services
           .AddScoped<IEFRPModuleClient, EFRPModuleClient>();

        private static IServiceCollection AddACL(this IServiceCollection services)
              => services.AddDomainServices()
                .AddScoped<IRebalancingOrderTranslator, RebalancingOrderTranslator>()
            .AddScoped<IRollOrderTranslator, RollOrderTranslator>();

        private static IServiceCollection AddServices(this IServiceCollection services)
          => services.AddDomainServices()
            .AddScoped<IOrderEnrichmentService, OrderEnrichmentService>()
            .AddScoped<IOrderGenerationService, OrderGenerationService>()
            .AddScoped<IOrderEventDispatcher, OrderEventDispatcher>()
            .AddScoped<IOrderRoutingService, OrderRoutingService>();
            





    }
}
