using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Trades.Api.Commands;
using Quantaventis.Trading.Modules.Trades.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Commands;
using Quantaventis.Trading.Shared.Abstractions.Messaging;

namespace Quantaventis.Trading.Modules.Trades.Api.Commands.Handlers
{
    internal class ValidateTradesHandler : ICommandHandler<ValidateTrades>
    {

        private IMessageBroker MessageBroker { get; }
        private ITradeValidationService TradeValidationService { get; }



        private ILogger<ValidateTradesHandler> Logger { get; }


        public ValidateTradesHandler(
            ITradeValidationService tradeValidationService,
            IMessageBroker messageBroker,
            ILogger<ValidateTradesHandler> logger)
        {
            this.TradeValidationService = tradeValidationService;
            this.MessageBroker = messageBroker;
            this.Logger = logger;
        }


        public async Task HandleAsync(ValidateTrades command, CancellationToken cancellationToken = default)
        {

            await TradeValidationService.ValidateTradesAsync();

        }

    }

}
