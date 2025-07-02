using Bloomberglp.Blpapi;
using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.Handlers;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Options;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Subscriptions;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Subscriptions.Handlers;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Subscriptions.Parsers;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Services
{
    internal interface IOrderSubscriptionService : ISubscriptionService<OrderSubscriptionMessage>
    {

    }

    internal class OrderSubscriptionService : AbstractSubscriptionService<OrderSubscriptionMessage>, IOrderSubscriptionService
    {
        public OrderSubscriptionService(EmsxApiOptions apiOptions,
            ISubscriptionMessageParser<OrderSubscriptionMessage> messageParser, 
            ILogger<AbstractSubscriptionService<OrderSubscriptionMessage>> logger) : base(apiOptions, messageParser, logger)
        {
        }

        // internal ISessionManager SessionManager { get; }


        protected override ISubscription CreateSubscription()
        {
            return new OrderSubscription();
        }
    }
}
