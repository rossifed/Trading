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
    internal class TradeCancelledHandler : IEventHandler<TradeCancelled>
    {

        private IPositionKeepingService PositionKeepingService { get; }

        private ILogger<TradeCancelledHandler> Logger { get; }
        public TradeCancelledHandler(IPositionKeepingService positionKeepingService, ILogger<TradeCancelledHandler> logger)
        {

       
            PositionKeepingService = positionKeepingService;
            Logger = logger;
        }
        public async Task HandleAsync(TradeCancelled @event, CancellationToken cancellationToken = default)
        {
           await PositionKeepingService.OnTradeCancelledAsync(@event.Trade.TradeId);
        }
    }
}
