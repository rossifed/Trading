using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Dao;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Entities;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Repositories;
//using Quantaventis.Trading.Modules.Portfolios.Domain.Repositories;
//using Quantaventis.Trading.Modules.Weights.Infrastructure.Files;
using Quantaventis.Trading.Modules.Portfolios.Infrastructure;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;
using Quantaventis.Trading.Modules.Portfolios.Api.Services;
using Quantaventis.Trading.Shared.Infrastructure.Scheduling;
using Quantaventis.Trading.Modules.Portfolios.Api.ScheduledTasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Quantaventis.Trading.Shared.Infrastructure;

namespace Quantaventis.Trading.Modules.Portfolios.Api
{
    internal static class Extensions
    {
        public static IServiceCollection AddModule(this IServiceCollection services)
        {
            return services.AddInfrastructure()
            .AddServices()
           .AddSwaggerGen()
           .AddScheduledTasks();
            services.AddControllers();
           

        }
        private static IServiceCollection AddServices(this IServiceCollection services)
          => services.AddScoped<IPositionUpdateService, PositionUpdateService>();

        private static IServiceCollection AddScheduledTasks(this IServiceCollection services)
        {
          return  services.AddScheduledTask<ComputeDailyPositionsTask>();      
          
        }
    }
}
