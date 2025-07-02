using Bloomberglp.Blpapi;
using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.Handlers;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Options;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Subscriptions;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Subscriptions.Handlers;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Subscriptions.Parsers;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Services
{
    internal interface IRouteSubscriptionService : ISubscriptionService<RouteSubscriptionMessage>
    {

    }

    internal class RouteSubscriptionService : AbstractSubscriptionService<RouteSubscriptionMessage>, IRouteSubscriptionService
    {
        public RouteSubscriptionService(EmsxApiOptions apiOptions,
            ISubscriptionMessageParser<RouteSubscriptionMessage> messageParser, 
            ILogger<AbstractSubscriptionService<RouteSubscriptionMessage>> logger) : base(apiOptions, messageParser, logger)
        {
        }



        protected override ISubscription CreateSubscription()
        {
            return new RouteSubscription();
        }
    }
}
