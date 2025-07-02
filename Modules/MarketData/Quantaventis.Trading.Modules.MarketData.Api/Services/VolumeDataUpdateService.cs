using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.MarketData.Api.Events.Out;
using Quantaventis.Trading.Modules.MarketData.Infrastructure.Entities;
using Quantaventis.Trading.Modules.MarketData.Infrastructure.Services;
using Quantaventis.Trading.Shared.Abstractions.Messaging;

namespace Quantaventis.Trading.Modules.MarketData.Api.Services
{
    internal interface IVolumeDataUpdateService
    {


        Task UpdateAsync(string refDataBlobFileName);
    }
    internal class VolumeDataUpdateService : IVolumeDataUpdateService
    {
        private IAzureBlobFileIntegrationService<StgVolumeDatum> AzureBlobFileIntegrationService { get; }
        private Infrastructure.Services.IVolumeDataRepository VolumeDataRepository { get; }
        ILogger<VolumeDataUpdateService> Logger { get; }

        IMessageBroker MessageBroker { get; }
        public VolumeDataUpdateService(
            IAzureBlobFileIntegrationService<StgVolumeDatum> azureBlobFileIntegrationService,
            Infrastructure.Services.IVolumeDataRepository volumeDataRepository,
            ILogger<VolumeDataUpdateService> logger,
            IMessageBroker messageBroker)
        {
            AzureBlobFileIntegrationService = azureBlobFileIntegrationService;
            VolumeDataRepository = volumeDataRepository;
            Logger = logger;
            MessageBroker = messageBroker;
        }

        public async Task UpdateAsync(string marketDataBlobFileName)
        {

            Logger.LogInformation($"Updating MaketData from Azure Blob Storage File{marketDataBlobFileName}");
            await AzureBlobFileIntegrationService.IntegrateAzureBlobFileIntoDb(marketDataBlobFileName);
    
            await VolumeDataRepository.UpdateMarketDataAsync();

            await MessageBroker.PublishAsync(new VolumeDataUpdated());

        }
    }
}
