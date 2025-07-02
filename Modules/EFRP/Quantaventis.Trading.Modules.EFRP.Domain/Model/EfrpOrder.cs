using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EFRP.Domain.Model
{
    internal class EfrpOrder
    {
        internal int Id { get; }
        internal FutureContractOrder OriginalOrder { get; }
        internal int OriginalOrderId => OriginalOrder.OrderId;
        internal string BaseCurrency => FxForwardOrder.BaseCurrency;
        internal string QuoteCurrency => FxForwardOrder.QuoteCurrency;
        internal string OrderReason => OriginalOrder.OrderReason;
        internal DateOnly ValueDate => FxForwardOrder.ValueDate;
        internal FxForward FxForward => FxForwardOrder.FxForward;
        internal long Quantity => FxForwardOrder.Quantity;
        internal string TradingDesk => OriginalOrder.TradingDesk;
        internal string FxForwardSymbol => FxForward.Symbol;
        internal FxForwardOrder FxForwardOrder { get; }

        internal int? RebalancingId => OriginalOrder.RebalancingId;
        internal byte PortfolioId => OriginalOrder.PortfolioId;
        internal string PositionSide => OriginalOrder.PositionSide;

        internal EfrpOrder(int id, FutureContractOrder originalOrder,  FxForwardOrder fxForwardOrder)
        {
            Id = id;
            OriginalOrder = originalOrder;
            FxForwardOrder = fxForwardOrder;

            
        }
        internal EfrpOrder(FutureContractOrder originalOrder, FxForwardOrder fxForwardOrder)
        : this(0, originalOrder, fxForwardOrder)
        {
  

        }


    }
}
