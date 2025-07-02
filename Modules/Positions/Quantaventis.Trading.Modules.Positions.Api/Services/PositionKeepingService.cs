using Quantaventis.Trading.Modules.Positions.Api.Dto;
using Quantaventis.Trading.Modules.Positions.Domain.Repositories;
using Quantaventis.Trading.Modules.Positions.Domain.Model;
using System.Linq;
using Quantaventis.Trading.Modules.Positions.Api.Mappers;
using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Modules.Positions.Api.Events.Out;
using Quantaventis.Trading.Modules.Positions.Domain.Services;

namespace Quantaventis.Trading.Modules.Positions.Api.Services
{
    public interface IPositionKeepingService
    {
        Task ComputePositionsFromDateAsync(byte portfolioId, int instrumentId, bool isSwap, DateOnly fromDate);
        Task ComputePositionsFromInceptionAsync(byte portfolioId, int instrumentId, bool isSwap);
        Task ComputeAllPositionsFromDateAsync(byte portfolioId, DateOnly fromDate);

        Task ComputeAllPositionsFromInceptionAsync(byte portfolioId);

        Task ComputeMissingPositionsAsync(byte portfolioId);
        Task OnTradeCorrectedAsync(BookedTradeDto trade);

        Task OnTradeCancelledAsync(int tradeId);

        Task OnTradesBookedAsync(IEnumerable<BookedTradeDto> trades);
        Task OnTradeBookedAsync(BookedTradeDto trade);
    }
    internal class PositionKeepingService : IPositionKeepingService
    {
     
        private IPositionRepository PositionRepository { get; }
        private ITradeAllocationRepository TradeAllocationRepository { get; }
        private IPositionGenerator PositionGenerator { get; }
        private IMessageBroker MessageBroker { get; }
        private ILogger<PositionKeepingService> Logger { get; }

        public PositionKeepingService(IPositionRepository positionRepository,
            ITradeAllocationRepository tradeAllocationRepository, 
            IPositionGenerator positionGenerator, 
            IMessageBroker messageBroker,
            ILogger<PositionKeepingService> logger)
        {
            PositionRepository = positionRepository;
            TradeAllocationRepository = tradeAllocationRepository;
            PositionGenerator = positionGenerator;
            MessageBroker = messageBroker;
            Logger = logger;
        }

        public async Task OnTradeBookedAsync(BookedTradeDto trade)
        {
            try
            {
                IEnumerable<TradeAllocation> newAllocations = trade.MapTradeAllocations();
                await TradeAllocationRepository.UpsertRangeAsync(newAllocations);

                List<Position> generatedPositions = new List<Position>();
                foreach (TradeAllocation tradeAllocation in newAllocations)
                {

                    IEnumerable<Position> positions =  await PositionGenerator.GeneratePositionsFromDateAsync(
                        tradeAllocation.PortfolioId,
                        tradeAllocation.InvestedInstrument,
                        tradeAllocation.TradeDate);
                    generatedPositions.AddRange(positions);
                }

                await PositionRepository.UpsertRangeAsync(generatedPositions);
                await PublishPositionUpdatedAsync(generatedPositions);
              
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error processing trade booking for trade {trade.TradeId}");
                throw;
            }
        }

     

        public async Task OnTradeCancelledAsync(int tradeId)
        {
            try
            {
                IEnumerable<TradeAllocation> allocations = await TradeAllocationRepository.GetByTradeIdAsync(tradeId);
                List<Position> generatedPositions = new List<Position>();
                foreach (TradeAllocation tradeAllocation in allocations)
                {
                    await TradeAllocationRepository.RemoveAsync(tradeAllocation.Id);
                    IEnumerable<Position> positions = await PositionGenerator.GeneratePositionsFromDateAsync(
                        tradeAllocation.PortfolioId,
                        tradeAllocation.InvestedInstrument,
                        tradeAllocation.TradeDate);
                    generatedPositions.AddRange(positions);
                }
                await PositionRepository.UpsertRangeAsync(generatedPositions);
                await PublishPositionUpdatedAsync(generatedPositions);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error processing trade cancellation for trade {tradeId}");
                throw;
            }
        }

      
        public async Task OnTradeCorrectedAsync(BookedTradeDto trade)
        {
            try
            {
                IEnumerable<TradeAllocation> correctedAllocations = trade.MapTradeAllocations();
                await TradeAllocationRepository.UpsertRangeAsync(correctedAllocations);
                List<Position> generatedPositions = new List<Position>();
                foreach (TradeAllocation tradeAllocation in correctedAllocations)
                {
                    
                    IEnumerable<Position> positions =  await PositionGenerator.GeneratePositionsFromDateAsync(
                        tradeAllocation.PortfolioId,
                        tradeAllocation.InvestedInstrument,
                        tradeAllocation.TradeDate);
                }
                await PositionRepository.UpsertRangeAsync(generatedPositions);
                await PublishPositionUpdatedAsync(generatedPositions);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error processing trade booking for trade {TradeId}", trade.TradeId);
                throw;
            }

        }
   

        private async Task PublishPositionUpdatedAsync(IEnumerable<Position> positions)
        {
            foreach (var position in positions)
            {
                await MessageBroker.PublishAsync(new PositionUpdated(position.Map()));

            }
        }

        public async Task OnTradesBookedAsync(IEnumerable<BookedTradeDto> trades)
        {
            foreach (var trade in trades)
            {
                await OnTradeBookedAsync(trade);

            }
        }

        public async Task ComputePositionsFromDateAsync(byte portfolioId, int instrumentId, bool isSwap, DateOnly fromDate)
        {
           IEnumerable<Position> positions = await PositionGenerator.GeneratePositionsFromDateAsync(portfolioId, new InvestedInstrument(instrumentId, isSwap), fromDate);

           await  PositionRepository.UpsertRangeAsync(positions);
        }

        public async Task ComputePositionsFromInceptionAsync(byte portfolioId, int instrumentId, bool isSwap)
        {
            IEnumerable<Position> positions = await PositionGenerator.GeneratePositionsFromInceptionAsync(portfolioId, new InvestedInstrument(instrumentId, isSwap));

            await PositionRepository.UpsertRangeAsync(positions);
        }

        public async Task ComputeAllPositionsFromDateAsync(byte portfolioId, DateOnly fromDate)
        {
            IEnumerable<Position> positions = await PositionGenerator.GenerateAllPositionsFromDateAsync(portfolioId, fromDate);
            await PositionRepository.UpsertRangeAsync(positions);
        }

        public async Task ComputeAllPositionsFromInceptionAsync(byte portfolioId)
        {
            await ComputeAllPositionsFromDateAsync(portfolioId, DateOnly.FromDateTime(DateTime.MinValue));
        }

        public async Task ComputeMissingPositionsAsync(byte portfolioId)
        {
            DateOnly? maxPosDate = await PositionRepository.GetMaxPositionDateAsync(portfolioId);
            if (maxPosDate != null)
            {
                await ComputeAllPositionsFromDateAsync(portfolioId, maxPosDate.Value);
            }
            else {
                await ComputeAllPositionsFromInceptionAsync(portfolioId);
            }
           
        }
    }
}
