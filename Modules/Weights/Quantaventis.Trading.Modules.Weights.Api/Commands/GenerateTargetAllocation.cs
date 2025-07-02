using Newtonsoft.Json;
using Quantaventis.Trading.Shared.Abstractions.Commands;
namespace Quantaventis.Trading.Modules.Weights.Api.Commands
{
    public record GenerateTargetAllocation(byte PortfolioId) : ICommand;
}
