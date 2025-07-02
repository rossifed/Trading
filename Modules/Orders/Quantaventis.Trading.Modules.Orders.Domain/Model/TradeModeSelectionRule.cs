using Quantaventis.Trading.Modules.Orders.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Domain.Model
{
    internal class TradeModeSelectionRule
    {

        internal Broker? Broker { get; }
        internal InstrumentType? InstrumentType { get; }
        internal TradeMode TradeMode { get; }
        internal Portfolio? Portfolio { get; }
        internal bool? IsEfrp { get; }

        public TradeModeSelectionRule(Broker? broker,
            Portfolio? portfolio,
            InstrumentType? instrumentType,
            bool? isEfrp,
            TradeMode tradeMode)
        {
            Broker = broker;
            Portfolio = portfolio;
            InstrumentType = instrumentType;
            IsEfrp = isEfrp;
            TradeMode = tradeMode;

        }
        internal int GetPriority(ISelectionRulePrioritization selectionRulePrioritization)
        {
            return selectionRulePrioritization.GetPriority(Portfolio, InstrumentType, Broker );
        }

        internal bool IsSatisfied(BaseOrder order, Broker broker, bool isEfrp)
        {
            return (InstrumentType == null || order.InstrumentType.Equals(InstrumentType))
                  && (Portfolio == null || order.Portfolio.Equals(Portfolio))
                  && (Broker == null || broker.Equals(Broker))
                  && (IsEfrp == null || IsEfrp == isEfrp);
        }
    }
}
