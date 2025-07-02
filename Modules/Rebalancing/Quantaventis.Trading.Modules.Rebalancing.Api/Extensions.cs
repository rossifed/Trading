using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Shared.Infrastructure;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Dao;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Entities;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Repositories;
//using Quantaventis.Trading.Modules.Portfolios.Domain.Repositories;
//using Quantaventis.Trading.Modules.Weights.Infrastructure.Files;
using Quantaventis.Trading.Modules.Rebalancing.Infrastructure;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;
using Quantaventis.Trading.Modules.Rebalancing.Domain;
using Quantaventis.Trading.Modules.Rebalancing.Api.Services;
using Quantaventis.Trading.Modules.Rebalancing.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Rebalancing.Api.Options;
using Quantaventis.Trading.Modules.Rebalancing.Domain.Services;

namespace Quantaventis.Trading.Modules.Rebalancing.Api
{
    internal static class Extensions
    {
        public static IServiceCollection AddModule(this IServiceCollection services)
        {
            AddOptions(services);
            services.AddControllers();
            return services.AddInfrastructure()
            .AddServices();                   
        }

       public static IServiceCollection AddOptions(this IServiceCollection services)
        {

            RebalancingOptions config = services.GetOptions<RebalancingOptions>("rebalancing");
            services.AddSingleton(config);
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
          => services.AddDomainServices()
            .AddScoped<IPortfolioDriftService, PortfolioDriftService>()
       
            .AddScoped<IRebalancingService, RebalancingService>();


    }
}
