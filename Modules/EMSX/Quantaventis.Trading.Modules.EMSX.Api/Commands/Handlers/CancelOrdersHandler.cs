using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EMSX.Api.Commands.In;
using Quantaventis.Trading.Modules.EMSX.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Commands;

namespace Quantaventis.Trading.Modules.EMSX.Api.Queries.Handlers
{
    internal sealed class CancelOrdersHandler : ICommandHandler<CancelOrders>
    {
        private IEmsxApiRequestService EmsxApiRequestService { get; }

        private ILogger<CancelOrdersHandler> Logger { get; }
        public CancelOrdersHandler(IEmsxApiRequestService emsxApiRequestService,
            ILogger<CancelOrdersHandler> logger)
        {

            this.EmsxApiRequestService = emsxApiRequestService;

            this.Logger = logger;
        }

        public async Task HandleAsync(CancelOrders command, CancellationToken cancellationToken = default)
        {
             await EmsxApiRequestService.CancelOrdersAsync(command.Sequences);
        }
    }

}
