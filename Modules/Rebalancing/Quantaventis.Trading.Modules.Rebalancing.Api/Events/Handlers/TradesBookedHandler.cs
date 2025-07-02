using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Rebalancing.Api.Events.In;
using Quantaventis.Trading.Modules.Rebalancing.Api.Services;

using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Shared.Abstractions.Messaging;

namespace Quantaventis.Trading.Modules.Rebalancing.Api.Events.Handlers
{
    internal class TradesBookedHandler : IEventHandler<TradesBooked>
    {

        private IRebalancingService RebalancingService { get; }

        private ILogger<TradesBookedHandler> Logger { get; }


        private IMessageBroker MessageBroker { get; }
        public TradesBookedHandler(
            IRebalancingService rebalancingService,        
            IMessageBroker messageBroker,
            ILogger<TradesBookedHandler> logger)
        {

            Logger = logger;
            this.MessageBroker = messageBroker;
           
            this.RebalancingService = rebalancingService;
        }


        public async Task HandleAsync(TradesBooked @event, CancellationToken cancellationToken = default)
        {
                


        }
    }
}
