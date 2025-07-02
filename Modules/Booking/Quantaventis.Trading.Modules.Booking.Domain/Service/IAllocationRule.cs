using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Booking.Domain.Model;
namespace Quantaventis.Trading.Modules.Booking.Domain.Service
{
    internal interface IAllocationRule
    {
        IEnumerable<RawTradeAllocation> AllocateTrade(RawTrade trade, IEnumerable<OrderAllocation> orderAllocations);
    }
}
