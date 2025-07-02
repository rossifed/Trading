using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Trades.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Commands;
using Quantaventis.Trading.Shared.Abstractions.Messaging;

namespace Quantaventis.Trading.Modules.Trades.Api.Commands.Handlers
{
    internal class StageAndBookTradesHandler : ICommandHandler<StageAndBookTrades>
    {

        private IMessageBroker MessageBroker { get; }
        private ITradeBookingService TradeBookingService { get; }



        private ILogger<StageAndBookTradesHandler> Logger { get; }


        public StageAndBookTradesHandler(
            ITradeBookingService tradeBookingService,
            IMessageBroker messageBroker,
            ILogger<StageAndBookTradesHandler> logger)
        {
            this.TradeBookingService = tradeBookingService;
            this.MessageBroker = messageBroker;
            this.Logger = logger;
        }


        public async Task HandleAsync(StageAndBookTrades command, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"Command {command} received...");

            await TradeBookingService.StageAndBookTradesAsync();

        }

    }

}
