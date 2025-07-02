using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Rebalancing.Domain.Model
{
    internal struct Order
    {
        internal int RebalancingSessionId { get; }
        internal Instrument Instrument { get; }
        internal Quantity Quantity => QuantityDrift.Amount;
        internal PortfolioId PortfolioId { get; }
        internal QuantityDrift QuantityDrift { get; }

        internal DateOnly TradeDate { get; }

        internal Quantity CurrentPositionQuantity => QuantityDrift.CurrentQuantity;

        internal Quantity TargetPositionQuantity => QuantityDrift.TargetQuantity;
        public Order(int rebalancingSessionId, DateOnly tradeDate, PortfolioId portfolioId, Instrument instrument, QuantityDrift quantityDrift)
        {
            RebalancingSessionId = rebalancingSessionId;
            Instrument = instrument;
            TradeDate= tradeDate;
            QuantityDrift = quantityDrift;
            PortfolioId = portfolioId;
        }
    }
}
