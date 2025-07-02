using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Booking.Api.Dto;
using Quantaventis.Trading.Modules.Booking.Api.Events.Out;
using Quantaventis.Trading.Modules.Booking.Api.Mappers;
using Quantaventis.Trading.Modules.Booking.Domain.Model;
using Quantaventis.Trading.Modules.Booking.Domain.Repositories;
using Quantaventis.Trading.Shared.Abstractions.Messaging;

namespace Quantaventis.Trading.Modules.Booking.Api.Services
{
    internal interface ITradeCorrectionService
    {
        Task FlagTradeAllocationAsCorrectedAsync(int tradeAllocationId);
        Task FlagTradeAsCorrectedAsync(int tradeId, bool flagAllocations);
        Task CorrectTradeAsync(int tradeId, TradeCorrectionDto tradeCorrection);
        Task CorrectTradeAllocationAsync(int tradeAllocationId, TradeAllocationCorrectionDto tradeAllocationCorrection);
    }

    internal class TradeCorrectionService : ITradeCorrectionService
    {
        private IBookedTradeRepository BookedTradeRepository { get; }
        private IMessageBroker MessageBroker { get; }
        private ILogger<TradeCorrectionService> Logger { get; }
        public TradeCorrectionService(IBookedTradeRepository bookedTradeRepository,
            IMessageBroker messageBroker,
            ILogger<TradeCorrectionService> logger)
        {
            BookedTradeRepository = bookedTradeRepository;
            MessageBroker = messageBroker;
            Logger = logger;
        }

        public async Task CorrectTradeAsync(int tradeId, TradeCorrectionDto tradeCorrectionDto)
        {
            BookedTrade? bookedTrade = await BookedTradeRepository.GetByTradeId(tradeId);
            if (bookedTrade == null)
            {
                Logger.LogError($"Correction can't be applied because Trade {tradeId} was not found");
            }
            else
            {
                TradeCorrection tradeCorrection = tradeCorrectionDto.Map();
                BookedTrade correctedTrade = bookedTrade.Correct(tradeCorrection);
                await BookedTradeRepository.UpdateAsync(correctedTrade);
                Logger.LogWarning($"Trade {correctedTrade} Corrected");
                await MessageBroker.PublishAsync(new TradeCorrected(correctedTrade.Map()));
            }
        }

        public async Task CorrectTradeAllocationAsync(int tradeAllocationId, TradeAllocationCorrectionDto tradeAllocationCorrection)
        {
            BookedTrade? bookedTrade = await BookedTradeRepository.GetByTradeAllocationId(tradeAllocationId);
            if (bookedTrade == null)
            {
                Logger.LogError($"Correction can't be applied because no Trade asw found for TradeAllocation {tradeAllocationId}");
            }
            else
            {
                TradeAllocationCorrection tradeAllocCorrection = tradeAllocationCorrection.Map();
                BookedTrade correctedTrade = bookedTrade.Correct(tradeAllocationId, tradeAllocCorrection);
                if (bookedTrade.LastCorrectionDateUtc == null || correctedTrade.IsCorrectedAfter(bookedTrade.LastCorrectionDateUtc.Value))
                {
                    await BookedTradeRepository.UpdateAsync(correctedTrade);
                    await MessageBroker.PublishAsync(new TradeCorrected(correctedTrade.Map()));
                }
            }
        }

        public async Task FlagTradeAsCorrectedAsync(int tradeId, bool flagAllocations)
        {
            BookedTrade? bookedTrade = await BookedTradeRepository.GetByTradeId(tradeId);
            if (bookedTrade == null)
            {
                Logger.LogError($"Correction can't be applied because  Trade  {tradeId} was not found");
            }
            else
            {
                BookedTrade correctedTrade = bookedTrade.AsCorrected(flagAllocations);
                await BookedTradeRepository.UpdateAsync(correctedTrade);
                await MessageBroker.PublishAsync(new TradeCorrected(correctedTrade.Map()));
            }
        }

        public async Task FlagTradeAllocationAsCorrectedAsync(int tradeAllocationId)
        {
            BookedTrade? bookedTrade = await BookedTradeRepository.GetByTradeAllocationId(tradeAllocationId);
            if (bookedTrade == null)
            {
                Logger.LogError($"Correction can't be applied because no Trade asw found for TradeAllocation {tradeAllocationId}");
            }

            BookedTradeAllocation? tradeAllocation = bookedTrade.GetAllocationById(tradeAllocationId);
            if (tradeAllocation == null)
            {
                Logger.LogError($"TradeAllocation:{tradeAllocationId} was not found in trade{bookedTrade.TradeId}");
            }
            else
            {
                BookedTrade correctedTrade = bookedTrade.FlagAllocationAsCorrected(tradeAllocationId);
                await BookedTradeRepository.UpdateAsync(correctedTrade);
                await MessageBroker.PublishAsync(new TradeAllocationCorrected(tradeAllocation.Map()));
                await MessageBroker.PublishAsync(new TradeCorrected(correctedTrade.Map()));
            }
        }
    }
}
