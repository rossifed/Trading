using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Portfolios.Api.Events.In;
using Quantaventis.Trading.Modules.Portfolios.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Shared.Abstractions.Messaging;

namespace Quantaventis.Trading.Modules.Portfolios.Api.Commands.Handlers
{
    internal class TradesSyncEventHandler : IEventHandler<TradesSyncEvent>
    {

        private IMessageBroker MessageBroker { get; }

        private IPositionUpdateService PositionUpdateService { get; }

        private ILogger<TradesSyncEventHandler> Logger { get; }

        public TradesSyncEventHandler(
            IMessageBroker messageBroker,
            IPositionUpdateService positionUpdateService,
            ILogger<TradesSyncEventHandler> logger)
        {
            this.PositionUpdateService = positionUpdateService;
            this.MessageBroker = messageBroker;
            this.Logger = logger;
            this.MessageBroker = messageBroker;
        }


        public async Task HandleAsync(TradesSyncEvent @event, CancellationToken cancellationToken = default)
        {

            Logger.LogInformation($"{@event} received...");
  
         //   await PositionUpdateService.UpdatePositionsAsync(@event.Trades);
           
        }

    }

}
