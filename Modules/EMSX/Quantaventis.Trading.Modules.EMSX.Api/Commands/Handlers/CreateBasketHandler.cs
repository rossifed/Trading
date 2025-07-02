using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EMSX.Api.Commands.In;
using Quantaventis.Trading.Modules.EMSX.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Commands;

namespace Quantaventis.Trading.Modules.EMSX.Api.Queries.Handlers
{
    internal sealed class CreateBasketHandler : ICommandHandler<CreateBasket>
    {
        private IEmsxApiRequestService EmsxApiRequestService { get; }

        private ILogger<CreateBasketHandler> Logger { get; }
        public CreateBasketHandler(IEmsxApiRequestService emsxApiRequestService,
            ILogger<CreateBasketHandler> logger)
        {

            this.EmsxApiRequestService = emsxApiRequestService;

            this.Logger = logger;
        }

        public async Task HandleAsync(CreateBasket command, CancellationToken cancellationToken = default)
        {
             await EmsxApiRequestService.CreateBasketAsync(command.BasketName, command.Sequences);
        }
    }

}
