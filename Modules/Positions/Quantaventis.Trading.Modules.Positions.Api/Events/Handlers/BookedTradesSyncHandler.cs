using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Modules.Positions.Api.Events.In;
using Quantaventis.Trading.Modules.Positions.Api.Services;
namespace Quantaventis.Trading.Modules.Positions.Api.Events.Handlers
{
    internal class BookedTradesSyncHandler : IEventHandler<BookedTradesSync>
    {
        private IPositionKeepingService PositionKeepingService { get; }
        private ILogger<BookedTradesSyncHandler> Logger { get; }

        public BookedTradesSyncHandler(
            IPositionKeepingService positionKeepingService,
            ILogger<BookedTradesSyncHandler> logger)
        {
            this.Logger = logger;
            this.PositionKeepingService = positionKeepingService;
        }


        public async Task HandleAsync(BookedTradesSync @event, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"Event {@event} received...");

            await PositionKeepingService.OnTradesBookedAsync(@event.Trades);
        }

    }

}
