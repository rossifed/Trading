using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Portfolios.Domain.Model
{
    internal class TradeAllocation
    {
        internal int Id { get; }
        internal Instrument Instrument { get; }

        internal int Quantity { get; }
        internal byte PortfolioId { get; }

        internal Money TradePrice { get; }
        internal DateTime TradeDate { get; }
        internal Money TotalCost => Quantity* TradePrice;
        internal Currency TradeCurrency=> TradePrice.Currency;
        public TradeAllocation(
            Instrument instrument, 
            int quantity, 
            byte portfolioId,
            Money tradePrice, 
            DateTime tradeDate)
        {
            Instrument = instrument;
            Quantity = quantity;
            PortfolioId = portfolioId;
            TradePrice = tradePrice;
            TradeDate = tradeDate;

        }
    }
}
