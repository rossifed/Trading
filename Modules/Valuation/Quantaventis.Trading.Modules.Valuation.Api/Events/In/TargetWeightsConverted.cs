using Quantaventis.Trading.Modules.Valuation.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Events;

namespace Quantaventis.Trading.Modules.Valuation.Api.Events.In
{
    internal record TargetWeightsConverted(
        byte PortfolioId, 
        int TargetAllocationId, 
        DateTime GeneratedOn,
        DateTime ConvertedOn, 
        IEnumerable<TargetWeightDto> ConvertedTargetWeights) : IEvent
    {
    }
}
