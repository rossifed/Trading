using Quantaventis.Trading.Modules.Weights.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Commands;
namespace Quantaventis.Trading.Modules.Weights.Api.Commands.Handlers
{
    internal class GenerateTargetAllocationHandler : ICommandHandler<GenerateTargetAllocation>
    {

       private ITargetAllocationGenerationService TargetAllocationGenerationService { get; }
        public GenerateTargetAllocationHandler(

            ITargetAllocationGenerationService targetAllocationGenerationService
            )
        {    
            this.TargetAllocationGenerationService = targetAllocationGenerationService;

        }


        public async Task HandleAsync(GenerateTargetAllocation command, CancellationToken cancellationToken = default)
        {
    
  
           await TargetAllocationGenerationService.GenerateTargetAllocation(command.PortfolioId);
         
        }

   
    }

}
