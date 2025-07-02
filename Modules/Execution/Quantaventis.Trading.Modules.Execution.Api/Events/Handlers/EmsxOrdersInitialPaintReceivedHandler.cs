using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Modules.Execution.Api.Events.In;
using Quantaventis.Trading.Modules.Execution.Api.Services;
namespace Quantaventis.Trading.Modules.Execution.Api.Events.Handlers
{
    internal class EmsxOrdersInitialPaintReceivedHandler : IEventHandler<EmsxOrdersInitialPaintReceived>
    {

        private IMessageBroker MessageBroker { get; }

        private ILogger<EmsxOrdersInitialPaintReceivedHandler> Logger { get; }
        private IEmsxOrderService EmsxOrderService { get; }

        public EmsxOrdersInitialPaintReceivedHandler(IEmsxOrderService emsxOrderService, ILogger<EmsxOrdersInitialPaintReceivedHandler> logger)
        {
            Logger = logger;
            EmsxOrderService = emsxOrderService;
        }


        public async Task HandleAsync(EmsxOrdersInitialPaintReceived @event, CancellationToken cancellationToken = default)
        {

           await EmsxOrderService.OnEmsxOrderInitialPaintReceivedAsync(@event.EmsxOrders);
        }

    }

}
