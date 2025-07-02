using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Trades.Api.Commands;
using Quantaventis.Trading.Modules.Trades.Api.Events.Out;
using Quantaventis.Trading.Modules.Trades.Api.Mappers;
using Quantaventis.Trading.Modules.Trades.Api.Services;
using Quantaventis.Trading.Modules.Trades.Infrastructure.Dao;
using Quantaventis.Trading.Shared.Abstractions.Commands;
using Quantaventis.Trading.Shared.Abstractions.Messaging;

namespace Quantaventis.Trading.Modules.Trades.Api.Commands.Handlers
{
    internal class TriggerTradesSyncEventHandler : ICommandHandler<TriggerTradesSyncEvent>
    {

        private IMessageBroker MessageBroker { get; }
        private ITradeDao TradeDao { get; }



        private ILogger<TriggerTradesSyncEventHandler> Logger { get; }


        public TriggerTradesSyncEventHandler(
            ITradeDao tradeDao,
            IMessageBroker messageBroker,
            ILogger<TriggerTradesSyncEventHandler> logger)
        {
            this.TradeDao = tradeDao;
            this.MessageBroker = messageBroker;
            this.Logger = logger;
        }


        public async Task HandleAsync(TriggerTradesSyncEvent command, CancellationToken cancellationToken = default)
        {

          var entities =  await TradeDao.GetTopTradesAsync(3000);
           await MessageBroker.PublishAsync(new TradesSyncEvent(entities.Map()));
        }

    }

}
