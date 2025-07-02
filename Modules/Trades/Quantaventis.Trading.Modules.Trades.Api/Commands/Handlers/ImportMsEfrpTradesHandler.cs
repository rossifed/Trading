using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Trades.Api.Commands;
using Quantaventis.Trading.Modules.Trades.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Commands;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Modules.Trades.Infrastructure.Services;
using CsvHelper;

namespace Quantaventis.Trading.Modules.Trades.Api.Commands.Handlers
{
    internal class ImportMsEfrpTradesHandler : ICommandHandler<ImportMsEfrpTrades>
    {

        private IMessageBroker MessageBroker { get; }


        private ITradeFileImportService TradeFileImportService { get; }

        private ILogger<ImportMsEfrpTradesHandler> Logger { get; }


        public ImportMsEfrpTradesHandler(
            ITradeFileImportService tradeFileImportService,
            IMessageBroker messageBroker,
            ILogger<ImportMsEfrpTradesHandler> logger)
        {
            this.TradeFileImportService = tradeFileImportService;
            this.MessageBroker = messageBroker;
            this.Logger = logger;
        }


        public async Task HandleAsync(ImportMsEfrpTrades command, CancellationToken cancellationToken = default)
        {
            await TradeFileImportService.ImportTradesFileAsync(command.TradeFilePath, "[trd].[MSEfrpTradeAffirm]", true);
    
        }

    }

}
