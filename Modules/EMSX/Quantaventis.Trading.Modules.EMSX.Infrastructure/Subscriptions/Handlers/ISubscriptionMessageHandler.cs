using Quantaventis.Trading.Modules.EMSX.Infrastructure.Subscriptions;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Subscriptions.Handlers
{
    internal interface ISubscriptionMessageHandler<TSubscriptionMessage> where TSubscriptionMessage : ISubscriptionMessage
    {
        Task OnSubscriptionMessageAsync(TSubscriptionMessage message);

        Task OnCreationEventAsync(TSubscriptionMessage message);

        Task OnDeletionEventAsync(TSubscriptionMessage message);

        Task OnUpdateEventAsync(TSubscriptionMessage message);

        Task OnInitialPaintEndAsync(IEnumerable<TSubscriptionMessage> initialPaintMessages);
    }
}
