using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Positions.Domain.Model;
using Quantaventis.Trading.Modules.Positions.Domain.Repositories;

namespace Quantaventis.Trading.Modules.Positions.Domain.Services
{
    internal interface IPositionGenerator
    {
        Task<IEnumerable<Position>> GenerateAllPositionsFromInceptionAsync(byte portfolioId);
   
        Task<IEnumerable<Position>> GenerateAllPositionsFromDateAsync(byte portfolioId, DateOnly fromDate);
        Task<IEnumerable<Position>> GeneratePositionsFromInceptionAsync(byte portfolioId, InvestedInstrument investedInstrument);
        Task<IEnumerable<Position>> GeneratePositionsFromDateAsync(byte portfolioId, InvestedInstrument investedInstrument, DateOnly fromDate);
    }

    internal class PositionGenerator : IPositionGenerator
    {
        private ITradeAllocationRepository TradeAllocationRepository { get; }
        private IPositionRepository PositionRepository { get; }



        private ILogger<PositionGenerator> Logger { get; }

        public PositionGenerator(
            ITradeAllocationRepository tradeAllocationRepository,
            IPositionRepository positionRepository,
            ILogger<PositionGenerator> logger)
        {
            TradeAllocationRepository = tradeAllocationRepository;
            PositionRepository = positionRepository;
            Logger = logger;
        }

        private IEnumerable<DateOnly> GenerateDates(DateOnly startDate, DateOnly endDate)
        {
            int numberOfDays = endDate.DayNumber - startDate.DayNumber + 1;
            return Enumerable.Range(0, numberOfDays)
                             .Select(offset => startDate.AddDays(offset));
        }

        private DateOnly Max(DateOnly startDate, DateOnly endDate)
        {
            return startDate > endDate ? startDate : endDate;
        }

        private IEnumerable<Position> GeneratePositions(IEnumerable<TradeAllocation> tradeAllocations)
        {
            if (!tradeAllocations.Any())
                return Enumerable.Empty<Position>();

            var groupedTradeAllocations = tradeAllocations
                .GroupBy(trade => new { trade.PortfolioId, trade.InstrumentId, trade.IsSwap });

            List<Position> allPositions = new List<Position>();

            foreach (var group in groupedTradeAllocations)
            {
                var positions = InitializeAndGeneratePositions(group);
                allPositions.AddRange(positions);
            }

            return allPositions;
        }

        private IEnumerable<Position> InitializeAndGeneratePositions(IEnumerable<TradeAllocation> tradeAllocations)
        {
            if (!tradeAllocations.Any())
                return Enumerable.Empty<Position>();

            var portfolioId = tradeAllocations.First().PortfolioId;
            var instrumentId = tradeAllocations.First().InstrumentId;
            var isSwap = tradeAllocations.First().IsSwap;

            if (tradeAllocations.Any(ta => ta.PortfolioId != portfolioId || ta.InstrumentId != instrumentId || ta.IsSwap != isSwap))
            {
                throw new InvalidOperationException("All trade allocations must have the same PortfolioId, InstrumentId, and IsSwap.");
            }

            var startDate = tradeAllocations.Min(tr => tr.TradeDate);

            // Filter out trades with the minimum trade date
            var predicate = (TradeAllocation x) => x.TradeDate == startDate;
            var initialTrades = tradeAllocations.Where(predicate);

            var remaingingTrades = tradeAllocations.Where(x => !predicate(x));


            var initialPosition = new Position(initialTrades);

            return GeneratePositionsFromInitial(initialPosition, remaingingTrades);
        }

        private IEnumerable<Position> GeneratePositionsFromInitial(Position initialPosition, IEnumerable<TradeAllocation> tradeAllocations)
        {
            var position = initialPosition;
            DateOnly startDate = initialPosition.PositionDate;
            ILookup<DateOnly, TradeAllocation> tradeAllocLookup = tradeAllocations.Where(x => x.TradeDate > startDate).ToLookup(x => x.TradeDate);

            IEnumerable<DateOnly> dates = GenerateDates(startDate, DateOnly.FromDateTime(DateTime.Today)).Skip(1);
            List<Position> positions = new List<Position>() { position };

            foreach (DateOnly date in dates)
            {
                if (tradeAllocLookup.Contains(date))
                {
                    foreach (var trade in tradeAllocLookup[date])
                    {
                        position = position.Add(trade);
                    }
                }
                else
                {
                    position = position.CopyAsOf(date);
                }

                positions.Add(position);

            }
            return positions;
        }

        public async Task<IEnumerable<Position>> GeneratePositionsFromDateAsync(byte portfolioId, InvestedInstrument investedInstrument, DateOnly fromDate)
        {
            Position? initialPosition = await PositionRepository.GetLastBeforeDateAsync(portfolioId, investedInstrument, fromDate);
            IEnumerable<TradeAllocation> tradeAllocations = await TradeAllocationRepository.GetFromDateAsync(
                portfolioId,
               investedInstrument,
               fromDate
            );
            if (initialPosition != null)
            {
                return GeneratePositionsFromInitial(initialPosition, tradeAllocations);
            }
            else
            {
                return GeneratePositions(tradeAllocations);
            }

        }

        public async Task<IEnumerable<Position>> GeneratePositionsFromInceptionAsync(byte portfolioId, InvestedInstrument investedInstrument)
        {

            // Fetch trade allocations from the given date
            IEnumerable<TradeAllocation> tradeAllocations = await TradeAllocationRepository.GetFromInceptionAsync(
                portfolioId,
               investedInstrument
            );
            return GeneratePositions(tradeAllocations);
        }

        public async Task<IEnumerable<Position>> GenerateAllPositionsFromInceptionAsync(byte portfolioId)
        {
            IEnumerable<TradeAllocation> allTradeAllocations = await TradeAllocationRepository.GetAllByPortfolioIdFromDateAsync(
               portfolioId,
              DateOnly.FromDateTime(DateTime.MinValue)
           );
            return GeneratePositions(allTradeAllocations);
        }

        public async Task<IEnumerable<Position>> GenerateAllPositionsFromDateAsync(byte portfolioId, DateOnly fromDate)
        {
            IEnumerable<TradeAllocation> allTradeAllocations = await TradeAllocationRepository.GetAllByPortfolioIdFromDateAsync(portfolioId, fromDate);
            ILookup<InvestedInstrument, TradeAllocation> tradeAllocationLookup = allTradeAllocations.ToLookup(x => x.InvestedInstrument);

            foreach (var grouping in tradeAllocationLookup)
            {
                var investmentInstrument = grouping.Key;
                var tradeAllocations = grouping;
                Position? initialPosition = await PositionRepository.GetLastBeforeDateAsync(portfolioId, investmentInstrument, fromDate);
                if (initialPosition != null)
                {
                    return GeneratePositionsFromInitial(initialPosition, tradeAllocations);
                }
                else
                {
                    return GeneratePositions(tradeAllocations);
                }
            }
            return Enumerable.Empty<Position>();
        }


    }
}
