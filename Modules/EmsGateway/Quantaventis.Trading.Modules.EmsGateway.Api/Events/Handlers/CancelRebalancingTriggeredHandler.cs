using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EmsGateway.Api.Mappers;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API;
using Quantaventis.Trading.Modules.EmsGateway.Api.Services;
using Quantaventis.Trading.Modules.EmsGateway.Api.Dto;
using Quantaventis.Trading.Modules.EmsGateway.Api.Events.In;
using Quantaventis.Trading.Modules.EmsGateway.Api.ACL;
using Quantaventis.Trading.Modules.EmsGateway.Api.Events.In;
using Quantaventis.Trading.Modules.Rebalancing.Api.Events.Out;

namespace Quantaventis.Trading.Modules.EmsGateway.Api.Events.Handlers
{
    internal class CancelRebalancingTriggeredHandler : IEventHandler<CancelRebalancingTriggered>
    {

        private IMessageBroker MessageBroker { get; }

        private ILogger<CancelRebalancingTriggeredHandler> Logger { get; }
        private IEmsxGatewayService EmsxGatewayService { get;}
        private IOrderToEmsxTranslator OrderToEmsxTranslator { get; }
        public CancelRebalancingTriggeredHandler(
        IEmsxGatewayService emsxGatewayService,
            IMessageBroker messageBroker,
            IOrderToEmsxTranslator orderToEmsxTranslator,
            ILogger<CancelRebalancingTriggeredHandler> logger)              
        {
            OrderToEmsxTranslator = orderToEmsxTranslator;
            this.EmsxGatewayService = emsxGatewayService;
            this.MessageBroker = messageBroker;
            this.Logger = logger;
            this.MessageBroker = messageBroker;
        }

     
        public async Task HandleAsync(CancelRebalancingTriggered @event, CancellationToken cancellationToken = default)
        {         
                await EmsxGatewayService.CancelEmsxOrderByRebalancingIdAsync(@event.RebalancingSessionId);            
        }

    }

}
