using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Weights.Api.Events.Out;
using Quantaventis.Trading.Modules.Weights.Api.Mappers;
using Quantaventis.Trading.Modules.Weights.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Weights.Infrastructure.Entities;
using Quantaventis.Trading.Modules.Weights.Infrastructure.Files;
using Quantaventis.Trading.Shared.Abstractions.Messaging;

namespace Quantaventis.Trading.Modules.Weights.Api.Services
{
    interface ITargetAllocationGenerationService {
        Task GenerateTargetAllocation(byte portfolioId, string fileName);
        Task GenerateTargetAllocation(byte portfolioId);
    }
    internal class TargetAllocationGenerationService : ITargetAllocationGenerationService
    {
        private IAzureBlobFileReader AzureBlobFileReader { get; }
        private ISymbolToInstrumentMappingService SymbolToInstrumentMappingService { get; }
        private ITargetAllocationDao TargetAllocationDao { get; }
        private IMessageBroker MessageBroker { get; }
        private ILogger<TargetAllocationGenerationService> Logger { get; }
        public TargetAllocationGenerationService(IAzureBlobFileReader azureBlobFileReader,
            ISymbolToInstrumentMappingService symbolToInstrumentMappingService, 
            ITargetAllocationDao targetAllocationDao, 
            IMessageBroker messageBroker,
            ILogger<TargetAllocationGenerationService> logger)
        {
            AzureBlobFileReader = azureBlobFileReader;
            SymbolToInstrumentMappingService = symbolToInstrumentMappingService;
            TargetAllocationDao = targetAllocationDao;
            MessageBroker = messageBroker;
            Logger = logger;
        }


        public async Task GenerateTargetAllocation(byte portfolioId)
        {
            string fileName = $"Weights_ALL_{DateTime.UtcNow.ToString("yyyyMMdd")}.txt";// TODO: to be injected by config
            await GenerateTargetAllocation(portfolioId, fileName);
        }

        public async Task GenerateTargetAllocation(byte portfolioId, string fileName) {

             Logger.LogInformation($"Integrating Model Weights from file {fileName}...");
            ModelWeightingFile modelWeightFile = await AzureBlobFileReader.ReadAsync(portfolioId, fileName);
            if (DateOnly.FromDateTime(modelWeightFile.ModifiedOn) < DateOnly.FromDateTime(DateTime.Now))
                throw new InvalidOperationException($"Model weights can't be integrated because the file is too old. Last Modifed date = {modelWeightFile.ModifiedOn}");

            IDictionary<string, Instrument> instrumentSymbolMapping = await SymbolToInstrumentMappingService.MapAsync(modelWeightFile.Symbols);
            var entity = modelWeightFile.Map(portfolioId, instrumentSymbolMapping);
            var targetAllocationId = await TargetAllocationDao.CreateAsync(entity);
            await MessageBroker.PublishAsync(new TargetAllocationGenerated(portfolioId, targetAllocationId, modelWeightFile.ModifiedOn, entity.TargetWeights.Map()));

        }
    }
}
