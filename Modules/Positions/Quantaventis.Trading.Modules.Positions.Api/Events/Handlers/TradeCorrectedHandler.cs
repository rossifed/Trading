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
    internal class TradeCorrectedHandler : IEventHandler<TradeCorrected>
    {

        private IPositionKeepingService PositionKeepingService { get; }

        private ILogger<TradeCorrectedHandler> Logger { get; }
        public TradeCorrectedHandler(IPositionKeepingService positionKeepingService, ILogger<TradeCorrectedHandler> logger)
        {

       
            PositionKeepingService = positionKeepingService;
            Logger = logger;
        }
        public async Task HandleAsync(TradeCorrected @event, CancellationToken cancellationToken = default)
        {
           await PositionKeepingService.OnTradeBookedAsync(@event.Trade);
        }
    }
}
