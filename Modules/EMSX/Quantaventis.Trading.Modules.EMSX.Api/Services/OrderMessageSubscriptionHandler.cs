using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EMSX.Api.Events.Out;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Subscriptions;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Subscriptions.Handlers;
using Quantaventis.Trading.Shared.Abstractions.Messaging;

namespace Quantaventis.Trading.Modules.EMSX.Api.Services
{
    internal class OrderMessageSubscriptionHandler : IOrderMessageHandler
    {
        private IMessageBroker MessageBroker { get; }
        private ILogger<OrderMessageSubscriptionHandler> Logger { get; }

        public OrderMessageSubscriptionHandler(IMessageBroker messageBroker, ILogger<OrderMessageSubscriptionHandler> logger)
        {
            MessageBroker = messageBroker;
            Logger = logger;
        }

        public async Task OnInitialPaintEndAsync(IEnumerable<OrderSubscriptionMessage> initialPaintMessages)
        {
            Logger.LogInformation($"Initial Paint received with {initialPaintMessages.Count()} orders...");
            var orders = initialPaintMessages.Select(x => x.EmsxOrder).ToList();
            if(orders.Any())
            await MessageBroker.PublishAsync(new EmsxOrdersInitialPaintReceived(orders));
        }

        public async Task OnSubscriptionMessageAsync(OrderSubscriptionMessage message)
        {
            Logger.LogInformation($"Order message received {message.EmsxOrder.ToString()}");
            await MessageBroker.PublishAsync(new EmsxOrderEventReceived(message.EmsxOrder));

        }

        public async Task OnCreationEventAsync(OrderSubscriptionMessage message)
        {
            Logger.LogInformation($"Order Created {message.EmsxOrder.ToString()}");
            await MessageBroker.PublishAsync(new EmsxOrderCreated(message.EmsxOrder));
        }

        public async Task OnDeletionEventAsync(OrderSubscriptionMessage message)
        {
            Logger.LogInformation($"Order Deleted {message.EmsxOrder.ToString()}");
            await MessageBroker.PublishAsync(new EmsxOrderDeleted(message.EmsxOrder.Sequence));
        }

        public async Task OnUpdateEventAsync(OrderSubscriptionMessage message)
        {
            Logger.LogInformation($"Order Updated {message.EmsxOrder.ToString()}");
            await MessageBroker.PublishAsync(new EmsxOrderUpdated(message.EmsxOrder));
        }
    }
}
