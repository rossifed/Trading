using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EMSX.Api.Commands.In;
using Quantaventis.Trading.Modules.EMSX.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Commands;

namespace Quantaventis.Trading.Modules.EMSX.Api.Queries.Handlers
{
    internal sealed class RouteOrdersHandler : ICommandHandler<RouteOrders>
    {
        private IEmsxApiRequestService EmsxApiRequestService { get; }

        private ILogger<RouteOrdersHandler> Logger { get; }
        public RouteOrdersHandler(IEmsxApiRequestService emsxApiRequestService,
            ILogger<RouteOrdersHandler> logger)
        {

            this.EmsxApiRequestService = emsxApiRequestService;

            this.Logger = logger;
        }

        public async Task HandleAsync(RouteOrders command, CancellationToken cancellationToken = default)
        {
             await EmsxApiRequestService.RouteOrdersAsync(command.RouteOrderRequests);
        }
    }

}
