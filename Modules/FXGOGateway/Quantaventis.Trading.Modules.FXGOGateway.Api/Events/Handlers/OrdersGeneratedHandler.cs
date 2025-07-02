using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.FXGOGateway.Api.Events.In;
using Quantaventis.Trading.Modules.FXGOGateway.Api.ACL;
using Quantaventis.Trading.Modules.FXGOGateway.Api.Dto;
using Quantaventis.Trading.Modules.FXGOGateway.Api.Services;
using Quantaventis.Trading.Modules.FXGOGateway.Infrastructure.IO;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Shared.Abstractions.Messaging;

namespace Quantaventis.Trading.Modules.FXGOGateway.Api.Events.Handlers
{
    internal class OrdersGeneratedHandler : IEventHandler<OrdersGenerated>
    {

        private IMessageBroker MessageBroker { get; }

        private ILogger<OrdersGeneratedHandler> Logger { get; }
        private IFXGOFileGenerationService<OrderDto> FXGOFileGenerationService { get;}


        public OrdersGeneratedHandler(
        IFXGOFileGenerationService<OrderDto> fXGOFileGenerationService,

            IMessageBroker messageBroker,

            ILogger<OrdersGeneratedHandler> logger)              
        {
            this.FXGOFileGenerationService = fXGOFileGenerationService;
            this.MessageBroker = messageBroker;
            this.Logger = logger;
            this.MessageBroker = messageBroker;

        }

     
        public async Task HandleAsync(OrdersGenerated @event, CancellationToken cancellationToken = default)
        {      if (@event.ExecutionChannel == "FXGO" && @event.TradeMode == "STANDARD")
            {
                await FXGOFileGenerationService.GenerateFXGOFileAsync(@event.Orders);
            }
        }

    }

}
