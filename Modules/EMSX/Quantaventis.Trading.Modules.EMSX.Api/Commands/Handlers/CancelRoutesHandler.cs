using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EMSX.Api.Commands.In;
using Quantaventis.Trading.Modules.EMSX.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Commands;

namespace Quantaventis.Trading.Modules.EMSX.Api.Queries.Handlers
{
    internal sealed class CancelRoutesHandler : ICommandHandler<CancelRoutes>
    {
        private IEmsxApiRequestService EmsxApiRequestService { get; }

        private ILogger<CancelRoutesHandler> Logger { get; }
        public CancelRoutesHandler(IEmsxApiRequestService emsxApiRequestService,
            ILogger<CancelRoutesHandler> logger)
        {

            this.EmsxApiRequestService = emsxApiRequestService;

            this.Logger = logger;
        }

        public async Task HandleAsync(CancelRoutes command, CancellationToken cancellationToken = default)
        {
             await EmsxApiRequestService.CancelRoutesAsync(command.CancelRouteRequests);
        }
    }

}
