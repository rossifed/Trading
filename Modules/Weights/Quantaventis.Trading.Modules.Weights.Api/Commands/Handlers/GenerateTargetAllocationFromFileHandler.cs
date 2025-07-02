using Quantaventis.Trading.Modules.Weights.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Commands;
namespace Quantaventis.Trading.Modules.Weights.Api.Commands.Handlers
{
    internal class GenerateTargetAllocationFromFileHandler : ICommandHandler<GenerateTargetAllocationFromFile>
    {

       private ITargetAllocationGenerationService TargetAllocationGenerationService { get; }
        public GenerateTargetAllocationFromFileHandler(

            ITargetAllocationGenerationService targetAllocationGenerationService
            )
        {    
            this.TargetAllocationGenerationService = targetAllocationGenerationService;

        }


        public async Task HandleAsync(GenerateTargetAllocationFromFile command, CancellationToken cancellationToken = default)
        {
    
            
           await TargetAllocationGenerationService.GenerateTargetAllocation(command.PortfolioId, command.FilePath);
          
        }

   
    }

}
