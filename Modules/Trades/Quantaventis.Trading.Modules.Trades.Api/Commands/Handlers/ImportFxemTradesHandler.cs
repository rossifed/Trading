using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Trades.Api.Commands;
using Quantaventis.Trading.Modules.Trades.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Commands;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Modules.Trades.Infrastructure.Services;
using CsvHelper;

namespace Quantaventis.Trading.Modules.Trades.Api.Commands.Handlers
{
    internal class ImportFxemTradesHandler : ICommandHandler<ImportFxemTrades>
    {

        private IMessageBroker MessageBroker { get; }


        private ITradeFileImportService TradeFileImportService { get; }

        private ILogger<ImportFxemTradesHandler> Logger { get; }


        public ImportFxemTradesHandler(
            ITradeFileImportService tradeFileImportService,
            IMessageBroker messageBroker,
            ILogger<ImportFxemTradesHandler> logger)
        {
            this.TradeFileImportService = tradeFileImportService;
            this.MessageBroker = messageBroker;
            this.Logger = logger;
        }


        public async Task HandleAsync(ImportFxemTrades command, CancellationToken cancellationToken = default)
        {
            await TradeFileImportService.ImportTradesFileAsync(command.TradeFilePath, "[trd].[FxemTrade]", true);
    
        }

    }

}
