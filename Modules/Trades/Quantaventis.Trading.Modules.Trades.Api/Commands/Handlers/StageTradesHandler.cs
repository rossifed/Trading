using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Trades.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Commands;
using Quantaventis.Trading.Shared.Abstractions.Messaging;

namespace Quantaventis.Trading.Modules.Trades.Api.Commands.Handlers
{
    internal class StageTradesHandler : ICommandHandler<StageTrades>
    {

        private IMessageBroker MessageBroker { get; }
        private ITradeBookingService TradeBookingService { get; }



        private ILogger<BookTradesHandler> Logger { get; }


        public StageTradesHandler(
            ITradeBookingService tradeBookingService,
            IMessageBroker messageBroker,
            ILogger<BookTradesHandler> logger)
        {
            this.TradeBookingService = tradeBookingService;
            this.MessageBroker = messageBroker;
            this.Logger = logger;
        }


        public async Task HandleAsync(StageTrades command, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"Command {command} received...");
            await TradeBookingService.StageTradesAsync();

        }

    }

}
