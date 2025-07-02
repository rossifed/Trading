using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Trades.Api.Dto;
using Quantaventis.Trading.Modules.Trades.Api.Events.In;
using Quantaventis.Trading.Modules.Trades.Api.Mappers;
using Quantaventis.Trading.Modules.Trades.Api.Services;
using Quantaventis.Trading.Modules.Trades.Infrastructure.Dao;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Entities =Quantaventis.Trading.Modules.Trades.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Trades.Api.Events.Handlers
{
    internal class EmsxOrdersSyncEventHandler : IEventHandler<EmsxOrdersSyncEvent>
    {

        private IMessageBroker MessageBroker { get; }
        private IEmsxOrderDao EmsxOrderDao { get; }
        private ILogger<EmsxOrdersSyncEventHandler> Logger { get; }
         private ITradeBookingService TradeBookingService { get; }
        public EmsxOrdersSyncEventHandler(

            IMessageBroker messageBroker,
            IEmsxOrderDao emsxOrderDao,
            ITradeBookingService tradeBookingService,
            ILogger<EmsxOrdersSyncEventHandler> logger)              
        {
        
            this.EmsxOrderDao = emsxOrderDao;
            this.Logger = logger;
            this.MessageBroker = messageBroker;
            this.TradeBookingService = tradeBookingService;
        }

     
        public async Task HandleAsync(EmsxOrdersSyncEvent @event, CancellationToken cancellationToken = default)
        {
            IEnumerable<EmsxOrderDto> emsxOrderDtos = @event.EmsxOrders;
            IEnumerable<EmsxOrderDto> executedOrders = emsxOrderDtos.Where(x => x.Status == "FILLED" || x.Status == "PARTFILL" ).ToList();

            Logger.LogInformation($"{executedOrders.Count()} Emsx Orders Execution received...");
            IEnumerable<Entities.EmsxOrder> entities = executedOrders.Map();
            await EmsxOrderDao.UpsertAsync(entities);
            if(entities.Any())
            await TradeBookingService.StageAndBookTradesAsync();


        }

    }

}
