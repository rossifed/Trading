using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Rebalancing.Api.Events.In;
using Quantaventis.Trading.Modules.Rebalancing.Api.Events.Out;
using Quantaventis.Trading.Modules.Rebalancing.Api.Mappers;
using Quantaventis.Trading.Modules.Rebalancing.Domain.Model;
using Quantaventis.Trading.Modules.Rebalancing.Domain.Repositories;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Shared.Abstractions.Messaging;

namespace Quantaventis.Trading.Modules.Rebalancing.Api.Events.Handlers
{
    internal class RiskPreTradeCheckedHandler : IEventHandler<RiskPreTradeChecked>
    {

        private IRebalancingSessionRepository RebalancingSessionRepository { get; }

        private ILogger<RiskPreTradeCheckedHandler> Logger { get; }


        private IMessageBroker MessageBroker { get; }
        public RiskPreTradeCheckedHandler(
            IRebalancingSessionRepository rebalancingSessionRepository,        
            IMessageBroker messageBroker,
            ILogger<RiskPreTradeCheckedHandler> logger)
        {

            Logger = logger;
            this.MessageBroker = messageBroker;
           
            this.RebalancingSessionRepository = rebalancingSessionRepository;
        }


        public async Task HandleAsync(RiskPreTradeChecked @event, CancellationToken cancellationToken = default)
        {
          RebalancingSession? rebalancingSession =  await  RebalancingSessionRepository.GetByIdAsync(@event.RebalancingSessionId);
            if (rebalancingSession == null)
                throw new InvalidOperationException($"RebalancingSession {@event.RebalancingSessionId} was not found");
            if (@event.IsBreach) {
                Logger.LogWarning($"Rebalancing {rebalancingSession} breached the pre trade risk constraint check");
                RebalancingSession breachedSession = rebalancingSession.Breached();
                await RebalancingSessionRepository.UpdateStatusAsync(breachedSession);
            } else {
                RebalancingSession validatedSession = rebalancingSession.Validated();
                await RebalancingSessionRepository.UpdateStatusAsync(validatedSession);
                await MessageBroker.PublishAsync(new RebalancingValidated(validatedSession.Map()));
                Logger.LogWarning($"Rebalancing {rebalancingSession} passed the pre trade risk constraint check");
            }


        }
    }
}
