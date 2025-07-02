using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EFRP.Domain.Model
{
    internal class EfrpCandidate : IEfrpCandidate
    {
        public int InstrumentId { get; }

        public int BrokerId { get; }

        public EfrpCandidate(int instrumentId, int brokerId)
        {
            InstrumentId = instrumentId;
            BrokerId = brokerId;
        }

        public override bool Equals(object? obj)
        {
            return obj is EfrpCandidate candidate &&
                   InstrumentId == candidate.InstrumentId &&
                   BrokerId == candidate.BrokerId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(InstrumentId, BrokerId);
        }
    }
}
