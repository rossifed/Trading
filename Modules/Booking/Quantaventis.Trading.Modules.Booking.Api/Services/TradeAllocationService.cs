using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Booking.Domain.Exceptions;
using Quantaventis.Trading.Modules.Booking.Domain.Model;
using Quantaventis.Trading.Modules.Booking.Domain.Repositories;
using Quantaventis.Trading.Modules.Booking.Domain.Service;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
namespace Quantaventis.Trading.Modules.Booking.Api.Services
{
    internal interface ITradeAllocationService
    {
        Task<IEnumerable<RawTradeAllocation>> AllocateTradeAsync(RawTrade trade);
        Task ForceAllocationAsync(int tradeId, byte portfolioId, string positionSide);
    }
    internal class TradeAllocationService : ITradeAllocationService
    {
        private IAllocationRule AllocationRule { get; }
        private IOrderAllocationRepository OrderAllocationRepository { get; }
        private IRawTradeAllocationRepository RawTradeAllocationRepository { get; }
        private IRawTradeRepository RawTradeRepository { get; }
        private IMessageBroker MessageBroker { get; }
        private ILogger<TradeAllocationService> Logger { get; }
        public TradeAllocationService(IAllocationRule allocationRule,
            IOrderAllocationRepository orderAllocationRepository,
            IRawTradeRepository rawTradeRepository,
            IRawTradeAllocationRepository tradeAllocationRepository,
            IMessageBroker messageBroker,
            ILogger<TradeAllocationService> logger)
        {
            AllocationRule = allocationRule;
            OrderAllocationRepository = orderAllocationRepository;
            RawTradeRepository = rawTradeRepository;
            RawTradeAllocationRepository = tradeAllocationRepository;
            MessageBroker = messageBroker;
            Logger = logger;
        }


        public async Task ForceAllocationAsync(int tradeId, byte portfolioId, string positionSide)
        {
            Logger.LogInformation($"Forced Trade Allocation Creation TradeId:{tradeId} PortfolioId:{portfolioId} PositionSide:{positionSide}");
            RawTrade? rawTrade = await RawTradeRepository.GetByTradeId(tradeId);
            if (rawTrade == null)
            {
                string message = $"Manual Allocation Error. No Trade with TradeId:{tradeId} found.";
                Logger.LogError(message);
                throw new InvalidOperationException(message);
            }
            else
            {
                IEnumerable<RawTradeAllocation> existingAllocations = await RawTradeAllocationRepository.GetByTradeId(tradeId);
                if (existingAllocations.Any())
                {
                    string message = $"Trade: {rawTrade} is already allocated. Allocation can only be enforced  on non allocated trades";
                    Logger.LogError(message);
                    throw new InvalidOperationException(message);
                }
                else
                {
                    RawTradeAllocation rawTradeAllocation = RawTradeAllocation.Create(rawTrade.TradeId,
                        portfolioId,
                        rawTrade.Quantity,
                        rawTrade.Quantity,
                        positionSide
                        );

                    await RawTradeAllocationRepository.AddAsync(rawTradeAllocation);
                    Logger.LogInformation($"RawTradeAllocation {rawTradeAllocation} created.");
                }
            }

        }

        public async Task<IEnumerable<RawTradeAllocation>> AllocateTradeAsync(RawTrade trade)
        {
            try
            {
                Logger.LogInformation($"Allocating trade {trade}");
                IEnumerable<RawTradeAllocation> rawTradeAllocations = await RawTradeAllocationRepository.GetByTradeId(trade.TradeId);

                if (rawTradeAllocations.Any())
                {
                    Logger.LogInformation($"Trade:{trade} is already allocated.");
                    return rawTradeAllocations;
                }

                if (trade.OrderReferenceId.HasValue)
                {
                    IEnumerable<OrderAllocation> orderAllocations = await OrderAllocationRepository.GetByOrderIdAsync(trade.OrderReferenceId.Value);
                    IEnumerable<RawTradeAllocation> tradeAllocations = AllocationRule.AllocateTrade(trade, orderAllocations);
                    tradeAllocations = await RawTradeAllocationRepository.AddRangeAsync(tradeAllocations);
                    Logger.LogInformation($"Trade {trade} allocated.");
                    return tradeAllocations;
                }
                else
                {
                    var errorMessage = $"Trade {trade} can't be allocated because no Order associated found...";
                    Logger.LogError(errorMessage);
                    throw new InvalidOperationException(errorMessage);

                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw new TradeAllocationException(trade.TradeId, ex.Message, ex);
            }
        }
    }
}
