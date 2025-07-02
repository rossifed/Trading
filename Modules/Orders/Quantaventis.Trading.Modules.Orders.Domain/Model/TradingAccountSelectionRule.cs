using Quantaventis.Trading.Modules.Orders.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Domain.Model
{
    internal class TradingAccountSelectionRule
    {
        private InstrumentType InstrumentType { get; }
        private Portfolio Portfolio { get; }
        private Broker Broker { get; }
        private TradeMode RoutingMethod { get; }

        internal TradingAccount TradingAccount { get; }
        internal TradingAccountSelectionRule(Portfolio portfolio, 
            Broker broker, 
            TradeMode routingMethod,
            InstrumentType instrumentType, 
            TradingAccount account )
        {
            InstrumentType = instrumentType;
            Broker = broker;
            RoutingMethod = routingMethod;
            Portfolio = portfolio;
            TradingAccount = account;
        }

     

        internal bool IsSatisfied(BaseOrder order,Broker broker, TradeMode routingMethod)
        {
            return order.InstrumentType.Equals(InstrumentType) 
                && order.Portfolio.Equals(Portfolio) 
                && broker.Equals(Broker)
                && routingMethod.Equals(RoutingMethod);
           
        }

    
    }
}
