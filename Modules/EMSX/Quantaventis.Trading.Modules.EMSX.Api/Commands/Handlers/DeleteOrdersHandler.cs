using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EMSX.Api.Commands.In;
using Quantaventis.Trading.Modules.EMSX.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Commands;

namespace Quantaventis.Trading.Modules.EMSX.Api.Queries.Handlers
{
    internal sealed class DeleteOrdersHandler : ICommandHandler<DeleteOrders>
    {
        private IEmsxApiRequestService EmsxApiRequestService { get; }

        private ILogger<DeleteOrdersHandler> Logger { get; }
        public DeleteOrdersHandler(IEmsxApiRequestService emsxApiRequestService,
            ILogger<DeleteOrdersHandler> logger)
        {

            this.EmsxApiRequestService = emsxApiRequestService;

            this.Logger = logger;
        }

        public async Task HandleAsync(DeleteOrders command, CancellationToken cancellationToken = default)
        {
             await EmsxApiRequestService.DeleteOrdersAsync(command.Sequences);
        }
    }

}
