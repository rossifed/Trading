using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Orders.Api.ACL;
using Quantaventis.Trading.Modules.Orders.Api.Dto;
using Quantaventis.Trading.Modules.Orders.Api.Events.In;
using Quantaventis.Trading.Modules.Orders.Api.Mappers;
using Quantaventis.Trading.Modules.Orders.Api.Services;
using Quantaventis.Trading.Modules.Orders.Domain.Model;
using Quantaventis.Trading.Modules.Orders.Domain.Repositories;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Shared.Abstractions.Messaging;

namespace Quantaventis.Trading.Modules.Orders.Api.Commands.Handlers
{
    internal class RebalancingValidatedHandler : IEventHandler<RebalancingValidated>
    {

        private IMessageBroker MessageBroker { get; }


        private IOrderGenerationService OrderGenerationService { get; }
        private ILogger<RebalancingValidatedHandler> Logger { get; }
        private IInstrumentRepository InstrumentRepository { get; }

        private IRebalancingOrderTranslator RebalancingOrderTranslator { get; }
        public RebalancingValidatedHandler(
            IOrderGenerationService orderGenerationService,
            IRebalancingOrderTranslator orderTranslator,
            IMessageBroker messageBroker,
            ILogger<RebalancingValidatedHandler> logger)
        {

            this.MessageBroker = messageBroker;
            this.Logger = logger;
            this.OrderGenerationService = orderGenerationService;
            this.MessageBroker = messageBroker;
            this.RebalancingOrderTranslator = orderTranslator;
        }

     
        public async Task HandleAsync(RebalancingValidated @event, CancellationToken cancellationToken = default)
        {
            var rebalancingSessionDto = @event.RebalancingSession;
            IEnumerable<RebalancingOrderDto> rebalancingOrderDtos = rebalancingSessionDto.Orders;
            IEnumerable<BaseOrder> baseOrders = await RebalancingOrderTranslator.TranslateAsync(rebalancingOrderDtos);
            await OrderGenerationService.GenerateOrdersAsync(rebalancingSessionDto.RebalancingSessionId,rebalancingSessionDto.TradeDate, baseOrders);
          //  await MessageBroker.PublishAsync(new OrderFlaggingStarted(rebalancingSessionDto.RebalancingSessionId, baseOrders));
            //var individualOrders = await BaseOrderTranslator.TranslateAsync(rebalancingSessionDto.Orders);
            //await OrderGenerationService.GenerateOrdersAsync(rebalancingSessionDto.RebalancingSessionId,individualOrders);
        }

    }

}
