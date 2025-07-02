using Newtonsoft.Json;
using Quantaventis.Trading.Shared.Abstractions.Commands;
namespace Quantaventis.Trading.Modules.Weights.Api.Commands
{
    public record GenerateTargetAllocationFromFile(byte PortfolioId,string FilePath) : ICommand;
}
