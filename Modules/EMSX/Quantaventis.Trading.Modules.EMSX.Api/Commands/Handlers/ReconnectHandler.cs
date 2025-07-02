using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EMSX.Api.Commands.In;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Services;
using Quantaventis.Trading.Shared.Abstractions.Commands;

namespace Quantaventis.Trading.Modules.EMSX.Api.Queries.Handlers
{
    internal sealed class ReconnectHandler : ICommandHandler<Reconnect>
    {
        private IEmsxApiClientService EmsxApiClientService { get; }

        private ILogger<ReconnectHandler> Logger { get; }
        public ReconnectHandler(IEmsxApiClientService emsxApiClientService,
            ILogger<ReconnectHandler> logger)
        {

            this.EmsxApiClientService = emsxApiClientService;

            this.Logger = logger;
        }

        public async Task HandleAsync(Reconnect command, CancellationToken cancellationToken = default)
        {
             await EmsxApiClientService.ConnectAsync();
        }
    }

}
