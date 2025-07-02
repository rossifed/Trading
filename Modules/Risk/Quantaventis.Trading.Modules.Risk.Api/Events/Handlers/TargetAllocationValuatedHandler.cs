using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Risk.Api.Mappers;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Modules.Risk.Api.Events.In;
namespace Quantaventis.Trading.Modules.Risk.Api.Events.Handlers
{
    internal class TargetAllocationValuatedHandler : IEventHandler<TargetAllocationValuated>
    {

        private ILogger<TargetAllocationValuatedHandler> Logger { get; }
   


        public TargetAllocationValuatedHandler(

            ILogger<TargetAllocationValuatedHandler> logger)
        {

            Logger = logger;

        }

    
        public async Task HandleAsync(TargetAllocationValuated @event, CancellationToken cancellationToken = default)
        {
            var dto = @event.TargetAllocationValuation;
    
 
        }
    }
}
