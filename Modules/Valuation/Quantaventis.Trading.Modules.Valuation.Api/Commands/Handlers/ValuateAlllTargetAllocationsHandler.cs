using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Valuation.Api.Services;
using Quantaventis.Trading.Modules.Valuation.Domain.Repositories;
using Quantaventis.Trading.Shared.Abstractions.Commands;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
namespace Quantaventis.Trading.Modules.Valuation.Api.Commands.Handlers
{
    internal class ValuateAllTargetAllocationsHandler : ICommandHandler<ValuateAllTargetAllocations>
    {
        private ILogger<ValuateAllTargetAllocationsHandler> Logger { get; }
        private ITargetAllocationValuationService TargetAllocationValuationService { get; }
        public ValuateAllTargetAllocationsHandler(
            ITargetAllocationValuationService targetAllocationValuationService,
            ILogger<ValuateAllTargetAllocationsHandler> logger)
        {

            this.TargetAllocationValuationService = targetAllocationValuationService;
            this.Logger = logger;
        }


        public async Task HandleAsync(ValuateAllTargetAllocations command, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"Received Command {command}");
            await TargetAllocationValuationService.ValuateAllTargetAllocationsAsync();
        }
    }

}
