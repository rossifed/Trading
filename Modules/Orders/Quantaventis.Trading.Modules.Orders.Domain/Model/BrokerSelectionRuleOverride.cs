using Quantaventis.Trading.Modules.Orders.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Domain.Model
{
    internal class BrokerSelectionRuleOverride
    {
        internal Portfolio Portfolio { get; }

        internal Instrument Instrument { get; }
       
        internal Broker Broker { get; }


        internal BrokerSelectionRuleOverride(Portfolio portfolio, Instrument instrument, Broker broker )
        {
            Instrument = instrument;
            Portfolio = portfolio;
            Broker = broker;
        }
    
        
        internal bool IsSatisfied(Portfolio portfolio,Instrument instrument)
        {
            return this.Portfolio == portfolio
              
               && this.Instrument == instrument || Instrument.IsParentOf(instrument);
           
        }

        public override bool Equals(object? obj)
        {
            return obj is BrokerSelectionRuleOverride @override &&
                   EqualityComparer<Instrument>.Default.Equals(Instrument, @override.Instrument) &&
                   EqualityComparer<Portfolio>.Default.Equals(Portfolio, @override.Portfolio);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Instrument, Portfolio);
        }
    }
}
