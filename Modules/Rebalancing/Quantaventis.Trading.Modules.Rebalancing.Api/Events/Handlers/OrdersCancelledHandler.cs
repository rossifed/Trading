using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Rebalancing.Api.Events.In;
using Quantaventis.Trading.Modules.Rebalancing.Api.Services;

using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Shared.Abstractions.Messaging;

namespace Quantaventis.Trading.Modules.Rebalancing.Api.Events.Handlers
{
    internal class OrdersCancelledHandler : IEventHandler<OrdersCancelled>
    {

        private IRebalancingService RebalancingService { get; }

        private ILogger<PortfolioValuatedHandler> Logger { get; }


        private IMessageBroker MessageBroker { get; }
        public OrdersCancelledHandler(
            IRebalancingService rebalancingService,        
            IMessageBroker messageBroker,
            ILogger<PortfolioValuatedHandler> logger)
        {

            Logger = logger;
            this.MessageBroker = messageBroker;
           
            this.RebalancingService = rebalancingService;
        }


        public async Task HandleAsync(OrdersCancelled @event, CancellationToken cancellationToken = default)
        {
  


        }
    }
}
