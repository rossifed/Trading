using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Booking.Api.Dto;
using Quantaventis.Trading.Modules.Booking.Api.Events.Out;
using Quantaventis.Trading.Modules.Booking.Api.Mappers;
using Quantaventis.Trading.Modules.Booking.Domain.Model;
using Quantaventis.Trading.Modules.Booking.Domain.Repositories;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
namespace Quantaventis.Trading.Modules.Booking.Api.Services
{
    internal interface ITradeSynchronizationService
    {
        Task TriggerSyncTradesByTradeDate(DateOnly tradeDate);
        Task TriggerSyncTradesByInstrument(int instrumentId);
        Task TriggerSyncTradeById(int tradeId);
    }
    internal class TradeSynchronizationService : ITradeSynchronizationService
    {
        private IBookedTradeRepository BookedTradeRepository { get; }

        private ILogger<TradeSynchronizationService> Logger { get; }
        private IMessageBroker MessageBroker { get; }

        public TradeSynchronizationService(
            IBookedTradeRepository bookedTradeRepository,
            ILogger<TradeSynchronizationService> logger,
            IMessageBroker messageBroker)
        {
            BookedTradeRepository = bookedTradeRepository;
            Logger = logger;
            MessageBroker = messageBroker;
        }

        public async Task TriggerSyncTradesByTradeDate(DateOnly tradeDate)
        {
            Logger.LogInformation($"Publishing Sync Trades By Trades Date {tradeDate.ToString("yyyyMMdd")}..");
            IEnumerable<BookedTrade> trades = await BookedTradeRepository.GetByTradeDate(tradeDate);
            Logger.LogInformation($"{trades.Count()} found to synchronize");
            await MessageBroker.PublishAsync(new BookedTradesSync(trades.Map()));
        }

        public async Task TriggerSyncTradesByInstrument(int instrumentId)
        {
            Logger.LogInformation($"Publishing Sync Trades By InstrumentId:{instrumentId}..");
            IEnumerable<BookedTrade> trades = await BookedTradeRepository.GetByInstrumentId(instrumentId);
            Logger.LogInformation($"{trades.Count()} found to synchronize");
            await MessageBroker.PublishAsync(new BookedTradesSync(trades.Map()));
        }

        public async Task TriggerSyncTradeById(int tradeId)
        {
            Logger.LogInformation($"Publishing Sync Trades By Id:{tradeId}..");
            BookedTrade? trade = await BookedTradeRepository.GetByTradeId(tradeId);
            if (trade != null)
            {
                Logger.LogInformation($"Trade {trade} found");
                await MessageBroker.PublishAsync(new BookedTradesSync(new List<BookedTradeDto> { trade.Map() }));
            }
            else
            {
                Logger.LogWarning($"SyncTradeById couldn't be triggered, no Trade found with Id {tradeId}");
            }
        }
    }
}
