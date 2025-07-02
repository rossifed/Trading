using Quantaventis.Trading.Shared.Abstractions.Commands;

namespace Quantaventis.Trading.Modules.Booking.Api.Commands.In
{
    internal record TriggerSyncTradeById(int TradeId) : ICommand;
}
