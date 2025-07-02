using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EMSX.Api.Commands.In;
using Quantaventis.Trading.Modules.EMSX.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Commands;

namespace Quantaventis.Trading.Modules.EMSX.Api.Queries.Handlers
{
    internal sealed class FetchFillsByDateHandler : ICommandHandler<FetchFillsByDate>
    {
        private IFillHistoryService FillHistoryService { get; }

        private ILogger<FetchFillsByDateHandler> Logger { get; }
        public FetchFillsByDateHandler(IFillHistoryService fillHistoryService,
            ILogger<FetchFillsByDateHandler> logger)
        {

            this.FillHistoryService = fillHistoryService;

            this.Logger = logger;
        }

        public async Task HandleAsync(FetchFillsByDate command, CancellationToken cancellationToken = default)
        {
             await FillHistoryService.FetchFillsByDate(command.FillDate);
        }
    }

}
