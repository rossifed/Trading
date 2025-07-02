using Quantaventis.Trading.Modules.Orders.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Domain.Model
{
    internal class ExecutionProfileSelectionRule
    {

        private Portfolio? Portfolio { get; }
        private Broker? Broker { get; }
        private InstrumentType? InstrumentType { get; }
        private Exchange? Exchange { get; }
        internal TradeMode? TradeMode { get; }
        internal ExecutionProfile ExecutionProfile { get; }

        public ExecutionProfileSelectionRule(Portfolio? portfolio,
            Broker? broker,
            InstrumentType? instrumentType,
            Exchange? exchange,
            TradeMode? tradeMode,
            ExecutionProfile executionProfile)
        {
            Portfolio = portfolio;
            Broker = broker;
            InstrumentType = instrumentType;
            Exchange = exchange;
            TradeMode = tradeMode;
            ExecutionProfile = executionProfile;
        }
        internal int GetPriority(ISelectionRulePrioritization selectionRulePrioritization)
        {
            return selectionRulePrioritization.GetPriority( Portfolio, Broker, InstrumentType, Exchange );
        }
        
        internal bool IsSatisfied(Portfolio portfolio, Broker broker,  Instrument instrument, TradeMode tradeMode)
        {
            return (InstrumentType == null || instrument.InstrumentType.Equals(InstrumentType))
                && (Portfolio == null || portfolio.Equals(Portfolio))
                && (Broker == null || broker.Equals(Broker))
                && (TradeMode == null || tradeMode.Equals(TradeMode))
                && (Exchange == null || (instrument.Exchange != null && instrument.Exchange.Equals(Exchange)));

        }
    }
}
