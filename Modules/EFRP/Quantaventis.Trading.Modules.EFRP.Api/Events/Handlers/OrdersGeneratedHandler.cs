using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EFRP.Api.Events.In;
using Quantaventis.Trading.Modules.EFRP.Api.Mappers;
using Quantaventis.Trading.Modules.EFRP.Domain.Model;
using Quantaventis.Trading.Modules.EFRP.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Shared.Abstractions.Messaging;

namespace Quantaventis.Trading.Modules.EFRP.Api.Events.Handlers
{
    internal class OrdersGeneratedHandler : IEventHandler<OrdersGenerated>
    {

        private IMessageBroker MessageBroker { get; }

        private ILogger<OrdersGeneratedHandler> Logger { get; }
        private IEfrpConversionService EfrpConversionService { get;}
        public OrdersGeneratedHandler(
        IEfrpConversionService efrpConversionService,
            IMessageBroker messageBroker,

            ILogger<OrdersGeneratedHandler> logger)              
        {
            this.EfrpConversionService = efrpConversionService;
            this.MessageBroker = messageBroker;
            this.Logger = logger;
            this.MessageBroker = messageBroker;
        }

     
        public async Task HandleAsync(OrdersGenerated @event, CancellationToken cancellationToken = default)
        {
            if (@event.TradeMode == "EFRP")
            {
                Logger.LogInformation($"{@event} received. Order Creation start...");
                IEnumerable<Order> orders = @event.Orders.Map();

                await EfrpConversionService.ConvertEfrpOrdersAsync(orders);
            }
        }

    }

}
