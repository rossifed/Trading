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
    internal class OrdersGeneratedHandler : IEventHandler<OrdersGenerated>
    {

        private IMessageBroker MessageBroker { get; }

        private ILogger<OrdersGeneratedHandler> Logger { get; }
        private IEmsxGatewayService EmsxOrderManagementService { get;}
        private IOrderToEmsxTranslator OrderToEmsxTranslator { get; }
        public OrdersGeneratedHandler(
        IEmsxGatewayService orderManagementService,
            IMessageBroker messageBroker,
            IOrderToEmsxTranslator orderToEmsxTranslator,
            ILogger<OrdersGeneratedHandler> logger)              
        {
            OrderToEmsxTranslator = orderToEmsxTranslator;
            this.EmsxOrderManagementService = orderManagementService;
            this.MessageBroker = messageBroker;
            this.Logger = logger;
            this.MessageBroker = messageBroker;
        }

     
        public async Task HandleAsync(OrdersGenerated @event, CancellationToken cancellationToken = default)
        {
            if ( @event.ExecutionChannel == "EMSX")
            {
                Logger.LogInformation($"{@event} received. Order Creation start...");
                IEnumerable<OrderDto> orders = @event.Orders;
                IEnumerable<EmsxOrder> emsxOrders = OrderToEmsxTranslator.Translate(orders);
                await EmsxOrderManagementService.CreateEmsxOrdersAsync(emsxOrders);
            }
    
        }

    }

}
