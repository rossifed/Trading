using Quantaventis.Trading.Modules.Orders.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Domain.Model
{
    internal class BrokerSelectionRule
    {


        internal InstrumentType? InstrumentType { get; }
        internal Portfolio? Portfolio { get; }
        internal Broker Broker { get; }


        internal BrokerSelectionRule(Portfolio? portfolio, InstrumentType? instrumentType, Broker broker )
        {
            InstrumentType = instrumentType;
            Portfolio = portfolio;
            Broker = broker;
        }
        internal int GetPriority(ISelectionRulePrioritization selectionRulePrioritization)
        {
            return selectionRulePrioritization.GetPriority( Portfolio, InstrumentType);
        }
        
        internal bool IsSatisfied(Portfolio portfolio, Instrument instrument)
        {  
            return (InstrumentType == null || instrument.InstrumentType.Equals(InstrumentType))
                && (Portfolio == null || portfolio.Equals(Portfolio));
           
        }

   
    }
}
