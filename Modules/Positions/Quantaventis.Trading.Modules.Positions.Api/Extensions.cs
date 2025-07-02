
using Microsoft.Extensions.DependencyInjection;

//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Dao;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Entities;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Repositories;
//using Quantaventis.Trading.Modules.Portfolios.Domain.Repositories;
//using Quantaventis.Trading.Modules.Weights.Infrastructure.Files;
using Quantaventis.Trading.Modules.Positions.Infrastructure;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;
using Quantaventis.Trading.Modules.Positions.Api.Services;
using Quantaventis.Trading.Modules.Weights.Domain;

namespace Quantaventis.Trading.Modules.Positions.Api
{
    internal static class Extensions
    {
        public static IServiceCollection AddModule(this IServiceCollection services)
        {
            return services.AddInfrastructure()
                .AddDomain()
            .AddServices()
           .AddSwaggerGen();
            services.AddControllers();


        }
        private static IServiceCollection AddServices(this IServiceCollection services)
          => services.AddScoped<IPositionKeepingService, PositionKeepingService>();


    }
}
