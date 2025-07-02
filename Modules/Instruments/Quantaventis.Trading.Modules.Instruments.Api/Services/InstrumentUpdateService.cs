using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Instruments.Api.Events.Out;
using Quantaventis.Trading.Modules.Instruments.Infrastructure.Services;
using Quantaventis.Trading.Shared.Abstractions.Messaging;

namespace Quantaventis.Trading.Modules.Instruments.Api.Services
{
    internal interface IInstrumentUpdateService
    {


        Task UpdateAsync(string refDataBlobFileName);
    }
    internal class InstrumentUpdateService : IInstrumentUpdateService
    {
        private IAzureBlobFileIntegrationService AzureBlobFileIntegrationService { get; }
        private IInstrumentDataIntegrationService InstrumentDataIntegrationService { get; }
        private ILogger<InstrumentUpdateService> Logger { get; }
        private IEnumerable<IContractChainsPublisher> ContractChainsPublishers { get; }
        IMessageBroker MessageBroker { get; }
        public InstrumentUpdateService(
            IAzureBlobFileIntegrationService azureBlobFileIntegrationService,
            IInstrumentDataIntegrationService instrumentDataIntegrationService,
            IEnumerable<IContractChainsPublisher> contractChainsPublishers,
            ILogger<InstrumentUpdateService> logger,
            IMessageBroker messageBroker)
        {
            AzureBlobFileIntegrationService = azureBlobFileIntegrationService;
            InstrumentDataIntegrationService = instrumentDataIntegrationService;
            ContractChainsPublishers = contractChainsPublishers;
            Logger = logger;
            MessageBroker = messageBroker;
        }

        public async Task UpdateAsync(string refDataBlobFileName)
        {

            Logger.LogInformation($"Updating Instruments from Azure Blob Storage File{refDataBlobFileName}");
            await AzureBlobFileIntegrationService.IntegrateAzureBlobFileIntoDb(refDataBlobFileName);
            await InstrumentDataIntegrationService.UpdateInstrumentData();
            await MessageBroker.PublishAsync(new InstrumentsUpdated(DateTime.UtcNow));
       //     await PublishContractChains();
        }

        private async Task PublishContractChains()
        {

            foreach (IContractChainsPublisher contractChainsPublisher in ContractChainsPublishers)
            {
                await contractChainsPublisher.PublishContractChainsAsync();
            }


        }
    }
}
