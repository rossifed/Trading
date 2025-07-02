using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Conversion.Api.Events.Out;
using Quantaventis.Trading.Modules.Conversion.Api.Services;
using Quantaventis.Trading.Modules.Conversion.Domain.Model;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
namespace Quantaventis.Trading.Modules.Conversion.Api.Events.Handlers
{
    internal class CurrentFutureContractSetHandler : IEventHandler<CurrentFutureContractSet>
    {

        private IInstrumentMappingUpdateService InstrumentMappingUpdateService;
        private IMessageBroker MessageBroker { get; }

        private ILogger<CurrentFutureContractSetHandler> Logger { get; }
        public CurrentFutureContractSetHandler(IInstrumentMappingUpdateService instrumentMappingUpdateService,
            IMessageBroker messageBroker,
            ILogger<CurrentFutureContractSetHandler> logger) { 
            this.InstrumentMappingUpdateService = instrumentMappingUpdateService;
            this.MessageBroker = messageBroker;
            this.Logger = logger;

        
        }
        public async Task HandleAsync(CurrentFutureContractSet @event, CancellationToken cancellationToken = default)
        {
           await InstrumentMappingUpdateService.CreateOrUpdateAsync(
               @event.GenericFutureId, 
               @event.FutureContractId, 
               InstrumentMappingType.GenericToFuture);

        }
    }
}
