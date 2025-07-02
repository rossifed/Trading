using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EMSX.Api.Queries.In;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Services;
using Quantaventis.Trading.Shared.Abstractions.Queries;
namespace Quantaventis.Trading.Modules.EMSX.Api.Queries.Handlers
{
    internal sealed class GetSessionStatusHandler : IQueryHandler<GetSessionStatus,string>
    {
        private IEmsxApiClientService EmsxApiClientService { get; }

        private ILogger<GetSessionStatusHandler> Logger { get; }
        public GetSessionStatusHandler(IEmsxApiClientService emsxApiClientService,
            ILogger<GetSessionStatusHandler> logger)
        {

            this.EmsxApiClientService = emsxApiClientService;

            this.Logger = logger;
        }

        public async Task<string> HandleAsync(GetSessionStatus query, CancellationToken cancellationToken = default)
        {
            return await EmsxApiClientService.GetConnectionStatusAsync();
        }
    }

}
