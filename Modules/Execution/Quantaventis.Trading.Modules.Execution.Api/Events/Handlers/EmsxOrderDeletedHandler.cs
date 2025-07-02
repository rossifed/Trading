using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Modules.Execution.Api.Events.In;
using Quantaventis.Trading.Modules.Execution.Api.Services;
namespace Quantaventis.Trading.Modules.Execution.Api.Events.Handlers
{
    internal class EmsxOrderDeletedHandler : IEventHandler<EmsxOrderDeleted>
    {

        private IMessageBroker MessageBroker { get; }

        private ILogger<EmsxOrderDeletedHandler> Logger { get; }
        private IEmsxOrderService EmsxOrderService { get; }

        public EmsxOrderDeletedHandler(IEmsxOrderService emsxOrderService, ILogger<EmsxOrderDeletedHandler> logger)
        {
            Logger = logger;
            EmsxOrderService = emsxOrderService;
        }


        public async Task HandleAsync(EmsxOrderDeleted @event, CancellationToken cancellationToken = default)
        {

           await EmsxOrderService.OnEmsxOrderDeletedAsync(@event.OrderId);
        }

    }

}
