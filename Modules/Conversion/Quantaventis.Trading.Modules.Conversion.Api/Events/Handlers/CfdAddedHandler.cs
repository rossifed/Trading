using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Conversion.Api.Events.Out;
using Quantaventis.Trading.Modules.Conversion.Api.Services;
using Quantaventis.Trading.Modules.Conversion.Domain.Model;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
namespace Quantaventis.Trading.Modules.Conversion.Api.Events.Handlers
{
    internal class CfdAddedHandlerHandler : IEventHandler<CfdAdded>
    {

        private IInstrumentMappingUpdateService InstrumentMappingUpdateService;


        private ILogger<CfdAddedHandlerHandler> Logger { get; }
        public CfdAddedHandlerHandler(IInstrumentMappingUpdateService instrumentMappingUpdateService,

            ILogger<CfdAddedHandlerHandler> logger) { 
            this.InstrumentMappingUpdateService = instrumentMappingUpdateService;
 
            this.Logger = logger;

        
        }
        public async Task HandleAsync(CfdAdded @event, CancellationToken cancellationToken = default)
        {
           await InstrumentMappingUpdateService.CreateOrUpdateAsync(
               @event.Cfd.Underlying.Id,
               @event.Cfd.Id,
               InstrumentMappingType.EquityToCfd);

        }
    }
}
