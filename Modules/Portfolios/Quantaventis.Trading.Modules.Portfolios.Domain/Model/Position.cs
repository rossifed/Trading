using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Portfolios.Domain.Model
{
    internal class Position
    {
        internal int Id { get; }
        internal Instrument Instrument { get; }
        internal int LastTradeAllocationId { get; }

        internal Currency TradeCurrency { get; }
        internal Position Update(TradeAllocation trade) {
            if (!trade.PortfolioId.Equals(PortfolioId))
                throw new InvalidOperationException($"Position {this} can't be updated by trade {trade}. Portfolio mismmtach");
            if (!trade.Instrument.Equals(Instrument))
                throw new InvalidOperationException($"Position {this} can't be updated by trade {trade}. Instrument mismmtach");
            var tradeTotalCost = trade.TotalCost;
            var positionTotalCost = TotalCost;
            var overallTotalCost = tradeTotalCost + positionTotalCost;
            var overallQuantity = trade.Quantity + Quantity;
            var newAverageEntryPrice = overallTotalCost / overallQuantity;
            return new Position(Id, PortfolioId,Instrument, Quantity + trade.Quantity, newAverageEntryPrice, trade.TradeDate);
        }

        private void Validate(IEnumerable<TradeAllocation> tradeAllocs) {
            if (tradeAllocs.Where(x => x.Instrument != Instrument).Any())
            {
                throw new InvalidOperationException($"Position {this} can't be updated.Some trade allocations have a different Instrument than the position");
            }
            if (tradeAllocs.Where(x => x.PortfolioId != PortfolioId).Any())
            {
                throw new InvalidOperationException($"Position {this} can't be updated.Some trade allocations have a different Currency than the position");
            }
            if (tradeAllocs.Where(x => x.TradeCurrency != TradeCurrency).Any())
            {
                throw new InvalidOperationException($"Position {this} can't be updated.Some trade allocations have a different Portfolio than the position");
            }
        }
     
        internal static Position FromTrade(TradeAllocation trade) {
            return new Position(trade.PortfolioId,trade.Instrument, trade.Quantity, trade.TradePrice, trade.TradeDate);
        }
        internal int Quantity { get; }
        internal bool IsFlat => Quantity == 0;
        internal byte PortfolioId { get; }
        internal Money AverageEntryPrice { get; }
        internal Money TotalCost => Quantity * AverageEntryPrice;
        internal Currency Currency => AverageEntryPrice.Currency;
        internal DateTime LastTradeDate { get; }
        internal Position WithId(int id)
            => new Position(id, PortfolioId, Instrument, Quantity, AverageEntryPrice, LastTradeDate);
        internal Position(int id, 
            byte portfolioId, 
            Instrument instrument, 
            int quantity, 
            Money averageEntryPrice, 
            DateTime lastTradeDate)
        {
            this.Id = id;
            this.PortfolioId = portfolioId;
            this.Instrument = instrument;
            this.Quantity = quantity;
            this.AverageEntryPrice = averageEntryPrice;
            this.LastTradeDate = lastTradeDate;
        }
        internal Position(byte portfolioId,
            Instrument instrument,
            int quantity,
            Money averageEntryPrice,
            DateTime lastTradeDate) : this(
                0,
                portfolioId,
                instrument,
                quantity,
                averageEntryPrice,
                lastTradeDate)
        { }
        
    }
}
