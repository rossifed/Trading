using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Domain.Model
{
    internal class EfrpSelectionRule
    {

        internal int BrokerId { get; }
        internal int InstrumentId { get; }
        internal bool IsEfrp { get; }

        public EfrpSelectionRule(int brokerId,
            int instrumentId,
            bool isEfrp)
        {
            BrokerId = brokerId;
            InstrumentId = instrumentId;
            IsEfrp = isEfrp;
        }

    
        internal bool IsSatisfied(BaseOrder order, Broker broker)
        {
          return order.Instrument.Id.Equals(InstrumentId)
               && broker.Id.Equals(BrokerId);
        }

        public override bool Equals(object? obj)
        {
            return obj is EfrpSelectionRule rule &&
                   BrokerId == rule.BrokerId &&
                   InstrumentId == rule.InstrumentId &&
                   IsEfrp == rule.IsEfrp;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(BrokerId, InstrumentId, IsEfrp);
        }
    }
}
