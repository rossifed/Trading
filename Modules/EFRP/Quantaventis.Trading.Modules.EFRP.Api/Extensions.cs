using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Modules.EFRP.Api.Services;
using Quantaventis.Trading.Modules.EFRP.Domain;
using Quantaventis.Trading.Modules.EFRP.Infrastructure;

//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Dao;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Entities;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Repositories;
//using Quantaventis.Trading.Modules.Portfolios.Domain.Repositories;
//using Quantaventis.Trading.Modules.Weights.Infrastructure.Files;

namespace Quantaventis.Trading.Modules.EFRP.Api
{
    internal static class Extensions
    {
        public static IServiceCollection AddModule(this IServiceCollection services)
        {
            services.AddControllers();
            return services.AddInfrastructure()
                .AddDomainServices()
            .AddServices();
          
           

        }
        private static IServiceCollection AddServices(this IServiceCollection services)
          => services.AddScoped<IEfrpConversionService, EfrpConversionService>()
            .AddScoped<IMsTradeAffirmService, MsTradeAffirmService>();


    }
}
