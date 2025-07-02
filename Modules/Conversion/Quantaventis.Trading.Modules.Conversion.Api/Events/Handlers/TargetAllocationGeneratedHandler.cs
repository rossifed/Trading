using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Conversion.Api.Events.Out;
using Quantaventis.Trading.Modules.Conversion.Api.Mappers;
using Quantaventis.Trading.Modules.Conversion.Api.Services;
using Quantaventis.Trading.Modules.Conversion.Domain.Model;
using Quantaventis.Trading.Modules.Conversion.Domain.Repositories;
using Quantaventis.Trading.Modules.Conversion.Domain.Services;
using Quantaventis.Trading.Modules.Conversion.Infrastructure.Repositories;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Quantaventis.Trading.Modules.Conversion.Infrastructure.Dao;
namespace Quantaventis.Trading.Modules.Conversion.Api.Events.Handlers
{
    internal class TargetAllocationGeneratedHandler : IEventHandler<TargetAllocationGenerated>
    {

        private ITargetWeightConversionService TargetWeightConversionService;
        private IMessageBroker MessageBroker { get; }
        private IInstrumentRepository InstrumentRepository { get; }
        private ILogger<TargetAllocationGeneratedHandler> Logger { get; }
        public TargetAllocationGeneratedHandler(ITargetWeightConversionService targetWeightConversionService,
            IInstrumentRepository instrumentRepository,
            IMessageBroker messageBroker,
            ILogger<TargetAllocationGeneratedHandler> logger) { 
            this.TargetWeightConversionService = targetWeightConversionService;
            this.InstrumentRepository = instrumentRepository;
            this.MessageBroker = messageBroker;
            this.Logger = logger;

        
        }
        public async Task HandleAsync(TargetAllocationGenerated @event, CancellationToken cancellationToken = default)
        {
            //var targetAllocation = new TargetAllocation(@event.TargetAllocationId, @event.PortfolioId, @event.GeneratedOn);

            //IEnumerable<TargetWeight> targetWeights = @event.TargetWeights.Map(targetAllocation);
            //IEnumerable<TargetWeightConversion> convertedWeights = await TargetWeightConversionService.ConvertAsync(targetWeights);

            //await MessageBroker.PublishAsync(new TargetAllocationConverted(@event.PortfolioId, @event.TargetAllocationId, DateTime.UtcNow, convertedWeights.ToDtos()));
            IEnumerable<int> instrumentIds = @event.TargetWeights.Select(x => x.InstrumentId);
            IEnumerable<Instrument> instruments =await InstrumentRepository.GetByIdsAsync(instrumentIds);
            IEnumerable<TargetWeight> targetWeights = @event.TargetWeights.Map(@event.PortfolioId, instruments);
            IEnumerable<TargetWeightConversion> convertedWeights = await TargetWeightConversionService.ConvertAsync(targetWeights);

            await MessageBroker.PublishAsync(new TargetWeightsConverted(

                @event.PortfolioId,
                @event.TargetAllocationId, 
                @event.GeneratedOn,
                DateTime.UtcNow,
                convertedWeights.Map()));
        }
    }
}
