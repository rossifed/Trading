using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Dao;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Entities;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Repositories;
//using Quantaventis.Trading.Modules.Portfolios.Domain.Repositories;
//using Quantaventis.Trading.Modules.Weights.Infrastructure.Files;
using Quantaventis.Trading.Modules.Valuation.Infrastructure;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;
using Quantaventis.Trading.Modules.Valuation.Domain;
using Quantaventis.Trading.Modules.Valuation.Api.Services;

namespace Quantaventis.Trading.Modules.Valuation.Api
{
    internal static class Extensions
    {
        public static IServiceCollection AddModule(this IServiceCollection services)
        {
            services.AddControllers();
            return services.AddInfrastructure()
            .AddServices()          
           .AddSwaggerGen();
          
           

        }
        private static IServiceCollection AddServices(this IServiceCollection services)
          => services.AddDomainServices()
            .AddScoped<IPortfolioValuationService, PortfolioValuationService>()
            .AddScoped<ITargetAllocationValuationService, TargetAllocationValuationService>();


    }
}
