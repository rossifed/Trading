using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Conversion.Api.Events.Out;
using Quantaventis.Trading.Modules.Conversion.Api.Services;
using Quantaventis.Trading.Modules.Conversion.Domain.Model;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
namespace Quantaventis.Trading.Modules.Conversion.Api.Events.Handlers
{
    internal class CurrencyPairAddedHandlerHandler : IEventHandler<CurrencyPairAdded>
    {

        private IInstrumentMappingUpdateService InstrumentMappingUpdateService;


        private ILogger<CurrencyPairAddedHandlerHandler> Logger { get; }
        public CurrencyPairAddedHandlerHandler(IInstrumentMappingUpdateService instrumentMappingUpdateService,

            ILogger<CurrencyPairAddedHandlerHandler> logger) { 
            this.InstrumentMappingUpdateService = instrumentMappingUpdateService;
 
            this.Logger = logger;

        
        }
        public async Task HandleAsync(CurrencyPairAdded @event, CancellationToken cancellationToken = default)
        {
           await InstrumentMappingUpdateService.CreateOrUpdateAsync(
               @event.CurrencyPair.Id, 
               @event.InverseCurrencyPair.Id, 
               InstrumentMappingType.CurrencyPairToInverse);

        }
    }
}
