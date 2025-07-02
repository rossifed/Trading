using Microsoft.Extensions.DependencyInjection;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Dao;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Entities;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Repositories;
//using Quantaventis.Trading.Modules.Portfolios.Domain.Repositories;
//using Quantaventis.Trading.Modules.Weights.Infrastructure.Files;
using System.Runtime.CompilerServices;
using Quantaventis.Trading.Modules.EMSX.Infrastructure;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Options;
using Quantaventis.Trading.Modules.EMSX.Api.Services;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.Handlers;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Subscriptions.Handlers;
using Quantaventis.Trading.Modules.EMSX.Api.Options;
using Quantaventis.Trading.Modules.EMSX.Api.ScheduledTasks;
using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Shared.Infrastructure;
using Quantaventis.Trading.Shared.Infrastructure.Scheduling;
[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.EMSX.Api")]
[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.EMSX.Infrastructure")]

namespace Quantaventis.Trading.Modules.EMSX.Api
{
    internal static class Extensions
    {
        public static IServiceCollection AddModule(this IServiceCollection services)
        {
            services.AddOptions();
            services.AddControllers();
            return services.AddInfrastructure()
            .AddServices()
            .AddScheduledTasks();

        }
        private static IServiceCollection AddOptions(this IServiceCollection services)
        {
            FillHistoryOptions fillHistoryOptions = services.GetOptions<FillHistoryOptions>("emsx:FillHistory");
            services.AddSingleton(fillHistoryOptions);
            return services;
        }
        private static IServiceCollection AddServices(this IServiceCollection services)
          => services.AddSingleton<IFillHistoryService, FillHistoryService>()
            .AddSingleton<IOrderMessageHandler, OrderMessageSubscriptionHandler>()
             .AddSingleton<IEmsxApiRequestService, EmsxApiRequestService>()
                  .AddSingleton<IRouteMessageHandler, RouteMessageSubscriptionHandler>()
             .AddHostedService<EmsxSessionHostedService>();
        private static IServiceCollection AddScheduledTasks(this IServiceCollection services)
        {
            return services.AddScheduledTask<FetchFillsTask>();

        }
        private static IServiceCollection AddSchedulers(this IServiceCollection services)
            => services;
    }
}
