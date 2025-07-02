using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EMSX.Api.Commands.In;
using Quantaventis.Trading.Modules.EMSX.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Commands;

namespace Quantaventis.Trading.Modules.EMSX.Api.Queries.Handlers
{
    internal sealed class CreateOrdersHandler : ICommandHandler<CreateOrders>
    {
        private IEmsxApiRequestService EmsxApiRequestService { get; }

        private ILogger<CreateOrdersHandler> Logger { get; }
        public CreateOrdersHandler(IEmsxApiRequestService emsxApiRequestService,
            ILogger<CreateOrdersHandler> logger)
        {

            this.EmsxApiRequestService = emsxApiRequestService;

            this.Logger = logger;
        }

        public async Task HandleAsync(CreateOrders command, CancellationToken cancellationToken = default)
        {
             await EmsxApiRequestService.CreateOrdersAsync(command.CreateOrderRequests);
        }
    }

}
