using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Portfolios.Api.Events.In;
using Quantaventis.Trading.Modules.Portfolios.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Portfolios.Api.Mappers;
namespace Quantaventis.Trading.Modules.Portfolios.Api.Commands.Handlers
{
    internal class BookedTradesSyncHandler : IEventHandler<BookedTradesSync>
    {

    

        private IBookedTradeAllocationDao BookedTradeAllocationDao { get; }
        private IPositionUpdateService PositionUpdateService { get; }
        private ILogger<BookedTradesSyncHandler> Logger { get; }
        private IMessageBroker MessageBroker { get; }

        public BookedTradesSyncHandler(IBookedTradeAllocationDao bookedTradeAllocationDao, 
            IPositionUpdateService positionUpdateService,
            ILogger<BookedTradesSyncHandler> logger, 
            IMessageBroker messageBroker)
        {
            BookedTradeAllocationDao = bookedTradeAllocationDao;
            PositionUpdateService = positionUpdateService;
            Logger = logger;
            MessageBroker = messageBroker;
        }

        public async Task HandleAsync(BookedTradesSync @event, CancellationToken cancellationToken = default)
        {

            Logger.LogInformation($"{@event} received....");
            await BookedTradeAllocationDao.UpsertRangeAsync(@event.Trades.Map());
            //await PositionUpdateService.ComputePositions(1);

        }

    }

}
