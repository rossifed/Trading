using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.MarketData.Api.Events.Out;
using Quantaventis.Trading.Modules.MarketData.Infrastructure.Entities;
using Quantaventis.Trading.Modules.MarketData.Infrastructure.Services;
using Quantaventis.Trading.Shared.Abstractions.Messaging;

namespace Quantaventis.Trading.Modules.MarketData.Api.Services
{
    internal interface IMarketDataUpdateService
    {


        Task UpdateAsync(string refDataBlobFileName);
    }
    internal class MarketDataUpdateService : IMarketDataUpdateService
    {
        private IAzureBlobFileIntegrationService<StgMarketDatum> AzureBlobFileIntegrationService { get; }
        private Infrastructure.Services.IMarketDataRepository MarketDataRepository { get; }
        private IFxRateIntegrationService FxRateIntegrationService { get; }
        ILogger<MarketDataUpdateService> Logger { get; }

        IMessageBroker MessageBroker { get; }
        public MarketDataUpdateService(
            IAzureBlobFileIntegrationService<StgMarketDatum> azureBlobFileIntegrationService,
            Infrastructure.Services.IMarketDataRepository marketDataRepository,
            IFxRateIntegrationService fxRateIntegrationService,
            ILogger<MarketDataUpdateService> logger,
            IMessageBroker messageBroker)
        {
            AzureBlobFileIntegrationService = azureBlobFileIntegrationService;
            MarketDataRepository = marketDataRepository;
            FxRateIntegrationService = fxRateIntegrationService;
            Logger = logger;
            MessageBroker = messageBroker;
        }

        public async Task UpdateAsync(string marketDataBlobFileName)
        {

            Logger.LogInformation($"Updating MaketData from Azure Blob Storage File{marketDataBlobFileName}");
            await AzureBlobFileIntegrationService.IntegrateAzureBlobFileIntoDb(marketDataBlobFileName);

            await FxRateIntegrationService.UpdateFxRatesAsync();
            await MarketDataRepository.UpdateMarketDataAsync();

            await MessageBroker.PublishAsync(new MarketDataUpdated());

        }
    }
}
