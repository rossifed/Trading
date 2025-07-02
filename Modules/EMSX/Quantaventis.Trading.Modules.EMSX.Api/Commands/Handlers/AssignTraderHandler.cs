using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EMSX.Api.Commands.In;
using Quantaventis.Trading.Modules.EMSX.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Commands;

namespace Quantaventis.Trading.Modules.EMSX.Api.Queries.Handlers
{
    internal sealed class AssignTraderHandler : ICommandHandler<AssignTrader>
    {
        private IEmsxApiRequestService EmsxApiRequestService { get; }

        private ILogger<AssignTraderHandler> Logger { get; }
        public AssignTraderHandler(IEmsxApiRequestService emsxApiRequestService,
            ILogger<AssignTraderHandler> logger)
        {

            this.EmsxApiRequestService = emsxApiRequestService;

            this.Logger = logger;
        }

        public async Task HandleAsync(AssignTrader command, CancellationToken cancellationToken = default)
        {
             await EmsxApiRequestService.AssignTraderAsync(command.AssigneeTraderUuid, command.Sequences);
        }
    }

}
