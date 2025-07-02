using Quantaventis.Trading.Modules.Orders.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Domain.Services
{
    internal class OrderEnricher
    {
        private TradingAccountSelector TradingAccountSelector { get; }
        private TradeModeSelector TradeModeSelector { get; }
        private ExecutionProfileSelector ExecutionProfileSelector { get; }
        private  BrokerSelector BrokerSelector { get; }

        private EfrpDetector EfrpDetector { get; }
        public OrderEnricher(BrokerSelector brokerSelector,
            TradeModeSelector tradeModeSelector,
            ExecutionProfileSelector executionProfileSelector,
            TradingAccountSelector tradingAccountSelector,
            EfrpDetector efrpDetector     
            )
        {
            TradingAccountSelector = tradingAccountSelector;
            TradeModeSelector = tradeModeSelector;
            ExecutionProfileSelector = executionProfileSelector;
            BrokerSelector = brokerSelector;
            EfrpDetector = efrpDetector;
        }
        internal IEnumerable<Order> Enrich(IEnumerable<BaseOrder> BaseOrders)
         => BaseOrders
            .Select(x => Enrich(x))
            .ToList();
        internal Order Enrich(BaseOrder baseOrder) {
            Broker broker = BrokerSelector.Select(baseOrder);
            bool isEfrp = EfrpDetector.IsEfrp(baseOrder, broker);
            TradeMode tradeMode = TradeModeSelector.Select(baseOrder, broker, isEfrp);
            ExecutionProfile executionProfile = ExecutionProfileSelector.Select(baseOrder, broker, tradeMode);
            TradingAccount tradingAccount = TradingAccountSelector.Select(baseOrder, broker, tradeMode);
            return new Order(baseOrder,broker, executionProfile, tradeMode, baseOrder.OrderReason, tradingAccount) ;

        }
    }
}
