using Quantaventis.Trading.Shared.Abstractions.Commands;
namespace Quantaventis.Trading.Modules.Valuation.Api.Commands
{
    internal record ValuateTargetAllocation(byte PortfolioId) :ICommand
    {
    }
}
