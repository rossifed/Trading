using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EFRP.Domain.Model
{
    internal interface IEfrpCandidate
    {

        int InstrumentId { get; }
        int BrokerId { get; }
    }
}
