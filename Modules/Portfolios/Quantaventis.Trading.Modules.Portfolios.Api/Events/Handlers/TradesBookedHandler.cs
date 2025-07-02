using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Portfolios.Api.Events.In;
using Quantaventis.Trading.Modules.Portfolios.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Shared.Abstractions.Messaging;

namespace Quantaventis.Trading.Modules.Portfolios.Api.Commands.Handlers
{
    internal class TradesBookedHandler : IEventHandler<TradesBooked>
    {

        private IMessageBroker MessageBroker { get; }

        private IPositionUpdateService PositionUpdateService { get; }

        private ILogger<TradesBookedHandler> Logger { get; }

        public TradesBookedHandler(
            IMessageBroker messageBroker,
            IPositionUpdateService positionUpdateService,
            ILogger<TradesBookedHandler> logger)
        {
            this.PositionUpdateService = positionUpdateService;
            this.MessageBroker = messageBroker;
            this.Logger = logger;
            this.MessageBroker = messageBroker;
        }


        public async Task HandleAsync(TradesBooked @event, CancellationToken cancellationToken = default)
        {

            Logger.LogInformation($"{@event} received....");
         //   await PositionUpdateService.UpdatePositionsAsync(@event.Trades);

        }

    }

}
