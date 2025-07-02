using Quantaventis.Trading.Modules.Orders.Domain.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Domain.Model
{
    internal class BaseOrder
    {
        internal Exchange? Exchange => Instrument.Exchange;
        internal int? RebalancingSessionId { get; }
        internal Instrument Instrument { get; }
        internal InstrumentType InstrumentType => Instrument.InstrumentType;
        internal Portfolio Portfolio { get; }
        internal Quantity Quantity { get; }
        internal OrderSide OrderSide { get; }
        internal PositionSide PositionSide { get; }
        internal DateOnly TradeDate { get; }
        internal OrderReason OrderReason { get; }

        public BaseOrder(
     Portfolio portfolio,
     Instrument instrument,
     Quantity quantity,
     OrderSide side,
     PositionSide positionSide,
     DateOnly tradeDate,
     OrderReason orderReason
) : this(null, portfolio, instrument, quantity, side, positionSide, tradeDate, orderReason) { }
        public BaseOrder(
            int? rebalancingSessionId,
            Portfolio portfolio,
            Instrument instrument,
            Quantity quantity,
            OrderSide side,
            PositionSide positionSide,
            DateOnly tradeDate,
            OrderReason orderReason
       )
        {
            this.RebalancingSessionId = rebalancingSessionId;
            this.Portfolio = portfolio;
            this.Instrument = instrument;
            this.Quantity = quantity;
            this.OrderSide = side;
            this.TradeDate = tradeDate;
            this.PositionSide = positionSide;
            this.OrderReason = orderReason;
        }


        public override string? ToString()
        {
            return $"{OrderSide} {Quantity} {Instrument} {Portfolio}";
        }


    }
}
