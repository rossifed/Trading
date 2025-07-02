using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Positions.Domain.Model;
using Quantaventis.Trading.Modules.Positions.Domain.Repositories;
using Quantaventis.Trading.Shared.Abstractions.Dispatchers;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Modules.Positions.Api.Mappers;
using Quantaventis.Trading.Modules.Positions.Api.Events.In;
using Quantaventis.Trading.Modules.Positions.Api.Services;
namespace Quantaventis.Trading.Modules.Positions.Api.Events.Handlers
{
    internal class TradeBookedHandler : IEventHandler<TradeBooked>
    {

        private IPositionKeepingService PositionKeepingService { get; }

        private ILogger<TradeBookedHandler> Logger { get; }
        public TradeBookedHandler(IPositionKeepingService positionKeepingService, ILogger<TradeBookedHandler> logger)
        {

       
            PositionKeepingService = positionKeepingService;
            Logger = logger;
        }
        public async Task HandleAsync(TradeBooked @event, CancellationToken cancellationToken = default)
        {
           await PositionKeepingService.OnTradeBookedAsync(@event.Trade);
        }
    }
}
