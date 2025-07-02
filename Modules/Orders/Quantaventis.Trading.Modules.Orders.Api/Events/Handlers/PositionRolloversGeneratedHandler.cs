using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Orders.Api.ACL;
using Quantaventis.Trading.Modules.Orders.Api.Dto;
using Quantaventis.Trading.Modules.Orders.Api.Events.In;
using Quantaventis.Trading.Modules.Orders.Api.Events.Out;
using Quantaventis.Trading.Modules.Orders.Api.Mappers;
using Quantaventis.Trading.Modules.Orders.Api.Services;
using Quantaventis.Trading.Modules.Orders.Domain.Model;
using Quantaventis.Trading.Modules.Orders.Domain.Repositories;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Shared.Abstractions.Messaging;

namespace Quantaventis.Trading.Modules.Orders.Api.Commands.Handlers
{
    internal class PositionRolloversGeneratedHandler : IEventHandler<PositionRolloversGenerated>
    {

        private IMessageBroker MessageBroker { get; }


        private IOrderGenerationService OrderGenerationService { get; }
        private ILogger<PositionRolloversGeneratedHandler> Logger { get; }
        private IInstrumentRepository InstrumentRepository { get; }

        private IRollOrderTranslator RollOrderTranslator { get; }
        public PositionRolloversGeneratedHandler(
            IOrderGenerationService orderGenerationService,
            IRollOrderTranslator rollOrderTranslator,
            IMessageBroker messageBroker,
            ILogger<PositionRolloversGeneratedHandler> logger)
        {

            this.MessageBroker = messageBroker;
            this.Logger = logger;
            this.OrderGenerationService = orderGenerationService;
            this.MessageBroker = messageBroker;
            this.RollOrderTranslator = rollOrderTranslator;
        }

     
        public async Task HandleAsync(PositionRolloversGenerated @event, CancellationToken cancellationToken = default)
        {
      
          //  await MessageBroker.PublishAsync(new OrderFlaggingStarted(rebalancingSessionDto.RebalancingSessionId, baseOrders));
            var rollOrders = await RollOrderTranslator.TranslateAsync(@event.PositionRollovers);
            await OrderGenerationService.GenerateRollOrdersAsync(rollOrders);
        }

    }

}
