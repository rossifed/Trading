using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.Handlers;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.Processors;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Options;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Services;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Subscriptions;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Subscriptions.Parsers;
using Quantaventis.Trading.Shared.Infrastructure;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.EMSX.Api")]

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services
                .AddOptions()
                .AddDaos()
                .AddRepositories()
                .AddSubscriptionMessageParsers()
                .AddServices()
                .AddMessageProcessors();


        }

        private static IServiceCollection AddDaos(this IServiceCollection services)
            => services;


        private static IServiceCollection AddRepositories(this IServiceCollection services)
            => services;







        private static IServiceCollection AddOptions(this IServiceCollection services)
        {


            EmsxApiOptions mappingOptions = services.GetOptions<EmsxApiOptions>("emsx:EMSXSession");
            services.AddSingleton(mappingOptions);

            return services;
        }
        private static IServiceCollection AddSubscriptionMessageParsers(this IServiceCollection services)
        {

            services.AddSingleton<ISubscriptionMessageParser<OrderSubscriptionMessage>, OrderMessageParser>()
                .AddSingleton<ISubscriptionMessageParser<RouteSubscriptionMessage>, RouteMessageParser>();


            return services;
        }


        private static IServiceCollection AddServices(this IServiceCollection services)
        {

            services
                .AddSingleton<SessionManager>()
                .AddSingleton<ISessionManager>(x => x.GetRequiredService<SessionManager>())
                .AddSingleton<ISessionMessageHandler>(x => x.GetRequiredService<SessionManager>())
                .AddSingleton<IServiceMessageHandler>(x => x.GetRequiredService<SessionManager>())
                .AddSingleton<IMiscMessageHandler>(x => x.GetRequiredService<SessionManager>());


            services.AddSingleton<RequestResponseService>()
                .AddSingleton<IRequestResponseService>(x => x.GetRequiredService<RequestResponseService>())
                .AddSingleton<IResponseMessageHandler>(x => x.GetRequiredService<RequestResponseService>());

            services.AddSingleton<OrderSubscriptionService>()
              .AddSingleton<IOrderSubscriptionService>(x => x.GetRequiredService<OrderSubscriptionService>())
              .AddSingleton<ISubscriptionDataMessageHandler>(x => x.GetRequiredService<OrderSubscriptionService>());

            services.AddSingleton<RouteSubscriptionService>()
            .AddSingleton<IRouteSubscriptionService>(x => x.GetRequiredService<RouteSubscriptionService>())
            .AddSingleton<ISubscriptionDataMessageHandler>(x => x.GetRequiredService<RouteSubscriptionService>());



            services.AddSingleton<HistoryRequestService>()
                      .AddSingleton<IHistoryRequestService>(x => x.GetRequiredService<HistoryRequestService>())
                      .AddSingleton<IResponseMessageHandler>(x => x.GetRequiredService<HistoryRequestService>())
       
                .AddSingleton<IEmsxEventHandler, EmsxEventHandler>()
                .AddSingleton<IEmsxApiClientService, EmsxApiClientService>();


            return services;


        }
    }
}
