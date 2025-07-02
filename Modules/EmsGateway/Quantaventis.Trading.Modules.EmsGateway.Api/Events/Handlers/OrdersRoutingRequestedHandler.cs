using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EmsGateway.Api.Mappers;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API;
using Quantaventis.Trading.Modules.EmsGateway.Api.Services;
using Quantaventis.Trading.Modules.EmsGateway.Api.Dto;
using Quantaventis.Trading.Modules.EmsGateway.Api.Events.In;
using Quantaventis.Trading.Modules.EmsGateway.Api.ACL;

namespace Quantaventis.Trading.Modules.EmsGateway.Api.Events.Handlers
{
    internal class OrdersRoutingRequestedHandler : IEventHandler<OrdersRoutingRequested>
    {

        private IMessageBroker MessageBroker { get; }

        private ILogger<OrdersRoutingRequestedHandler> Logger { get; }
        private IEmsxGatewayService EmsxGatewayService { get;}
        private IOrderToEmsxTranslator OrderToEmsxTranslator { get; }
        public OrdersRoutingRequestedHandler(
        IEmsxGatewayService emsxGatewayService,
            IMessageBroker messageBroker,
            IOrderToEmsxTranslator orderToEmsxTranslator,
            ILogger<OrdersRoutingRequestedHandler> logger)              
        {
            OrderToEmsxTranslator = orderToEmsxTranslator;
            this.EmsxGatewayService = emsxGatewayService;
            this.MessageBroker = messageBroker;
            this.Logger = logger;
            this.MessageBroker = messageBroker;
        }

     
        public async Task HandleAsync(OrdersRoutingRequested @event, CancellationToken cancellationToken = default)
        {
            if (@event.ExecutionChannel == "EMSX")
            {
                Logger.LogInformation($"Routing Orders Requested");
         
                await EmsxGatewayService.RouteEmsxOrdersAsync(@event.Routes);
            }
    
        }

    }

}
