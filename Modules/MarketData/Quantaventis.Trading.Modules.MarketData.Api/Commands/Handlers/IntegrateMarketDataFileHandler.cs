using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.MarketData.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Commands;
using Quantaventis.Trading.Shared.Abstractions.Messaging;

namespace Quantaventis.Trading.Modules.MarketData.Api.Commands.Handlers
{
    internal class IntegrateMarketDataFileHandler : ICommandHandler<IntegrateMarketDataFile>
    {

        private IMessageBroker MessageBroker { get; }
        private IMarketDataUpdateService MarketDataUpdateService { get; }



        private ILogger<IntegrateMarketDataFileHandler> Logger { get; }


        public IntegrateMarketDataFileHandler(
            IMarketDataUpdateService marketDataUpdateService,
            IMessageBroker messageBroker,
            ILogger<IntegrateMarketDataFileHandler> logger)
        {
            this.MarketDataUpdateService = marketDataUpdateService;
            this.MessageBroker = messageBroker;
            this.Logger = logger;
        }


        public async Task HandleAsync(IntegrateMarketDataFile command, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"Integrating Market Data from {command.AzureBlobFile}");


            await MarketDataUpdateService.UpdateAsync(command.AzureBlobFile);





        }

    }

}
