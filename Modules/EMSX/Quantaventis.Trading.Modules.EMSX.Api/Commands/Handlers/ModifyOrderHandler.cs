using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EMSX.Api.Commands.In;
using Quantaventis.Trading.Modules.EMSX.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Commands;

namespace Quantaventis.Trading.Modules.EMSX.Api.Queries.Handlers
{
    internal sealed class ModifyOrderHandler : ICommandHandler<ModifyOrder>
    {
        private IEmsxApiRequestService EmsxApiRequestService { get; }

        private ILogger<ModifyOrderHandler> Logger { get; }
        public ModifyOrderHandler(IEmsxApiRequestService emsxApiRequestService,
            ILogger<ModifyOrderHandler> logger)
        {

            this.EmsxApiRequestService = emsxApiRequestService;

            this.Logger = logger;
        }

        public async Task HandleAsync(ModifyOrder command, CancellationToken cancellationToken = default)
        {
             await EmsxApiRequestService.ModifyOrderAsync(command.ModifyOrderRequest);
        }
    }

}
