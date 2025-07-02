using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Booking.Api.Events.Out;
using Quantaventis.Trading.Modules.Booking.Api.Mappers;
using Quantaventis.Trading.Modules.Booking.Domain.Model;
using Quantaventis.Trading.Modules.Booking.Domain.Repositories;
using Quantaventis.Trading.Shared.Abstractions.Messaging;

namespace Quantaventis.Trading.Modules.Booking.Api.Services
{
    internal interface ITradeCancellationService
    {
        Task CancelTradeAsync(int tradeId);
    }

    internal class TradeCancellationService : ITradeCancellationService
    {
        private IBookedTradeRepository BookedTradeRepository { get; }
        private IMessageBroker MessageBroker { get; }
        private ILogger<TradeCancellationService> Logger { get; }

        public TradeCancellationService(IBookedTradeRepository bookedTradeRepository,
            IMessageBroker messageBroker,
            ILogger<TradeCancellationService> logger)
        {
            BookedTradeRepository = bookedTradeRepository;
            MessageBroker = messageBroker;
            Logger = logger;
        }

        public async Task CancelTradeAsync(int tradeId)
        {
            BookedTrade? bookedTrade = await BookedTradeRepository.GetByTradeId(tradeId);
            if (bookedTrade == null)
            {
                Logger.LogError($"Trade cancellation error. Trade {tradeId} was not found");
            }
            else if (bookedTrade.IsCancelled)
            {
                Logger.LogError($"Trade {bookedTrade} is already cancelled. no action will be done");
            }
            else
            {
                BookedTrade cancelledTrade = bookedTrade.Cancel();
                await BookedTradeRepository.RemoveAsync(cancelledTrade.TradeId);
                Logger.LogWarning($"Trade {cancelledTrade} deleted");
                await MessageBroker.PublishAsync(new TradeCancelled(cancelledTrade.Map()));
            }
        }
    }
}
