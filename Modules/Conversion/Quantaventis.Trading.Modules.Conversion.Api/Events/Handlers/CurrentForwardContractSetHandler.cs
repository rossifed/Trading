using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Conversion.Api.Events.Out;
using Quantaventis.Trading.Modules.Conversion.Api.Services;
using Quantaventis.Trading.Modules.Conversion.Domain.Model;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
namespace Quantaventis.Trading.Modules.Conversion.Api.Events.Handlers
{
    internal class CurrentForwardContractSetHandler : IEventHandler<CurrentForwardContractSet>
    {

        private IInstrumentMappingUpdateService InstrumentMappingUpdateService;
        private IMessageBroker MessageBroker { get; }

        private ILogger<CurrentForwardContractSetHandler> Logger { get; }
        public CurrentForwardContractSetHandler(IInstrumentMappingUpdateService instrumentMappingUpdateService,
            IMessageBroker messageBroker,
            ILogger<CurrentForwardContractSetHandler> logger) { 
            this.InstrumentMappingUpdateService = instrumentMappingUpdateService;
            this.MessageBroker = messageBroker;
            this.Logger = logger;

        
        }
        public async Task HandleAsync(CurrentForwardContractSet @event, CancellationToken cancellationToken = default)
        {
           await InstrumentMappingUpdateService.CreateOrUpdateAsync(
               @event.CurrencyPairId, 
               @event.ForwardContractId, 
               InstrumentMappingType.CurrencyPairToForward);

        }
    }
}
