using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Conversion.Api.Events.Out;
using Quantaventis.Trading.Modules.Conversion.Api.Services;
using Quantaventis.Trading.Modules.Conversion.Domain.Model;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
namespace Quantaventis.Trading.Modules.Conversion.Api.Events.Handlers
{
    internal class ForwardContractRolledHandler : IEventHandler<ForwardContractRolled>
    {

        private IInstrumentMappingUpdateService InstrumentMappingUpdateService;
        private IMessageBroker MessageBroker { get; }

        private ILogger<ForwardContractRolledHandler> Logger { get; }
        public ForwardContractRolledHandler(IInstrumentMappingUpdateService instrumentMappingUpdateService,
            IMessageBroker messageBroker,
            ILogger<ForwardContractRolledHandler> logger) { 
            this.InstrumentMappingUpdateService = instrumentMappingUpdateService;
            this.MessageBroker = messageBroker;
            this.Logger = logger;

        
        }
        public async Task HandleAsync(ForwardContractRolled @event, CancellationToken cancellationToken = default)
        {
           await InstrumentMappingUpdateService.CreateOrUpdateAsync(
               @event.CurrencyPairId, 
               @event.NewContractId, 
               InstrumentMappingType.CurrencyPairToForward);

        }
    }
}
