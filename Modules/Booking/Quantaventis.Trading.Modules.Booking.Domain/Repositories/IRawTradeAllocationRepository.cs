using Quantaventis.Trading.Modules.Booking.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Booking.Domain.Repositories
{
    internal interface IRawTradeAllocationRepository
    {
        Task AddAsync(RawTradeAllocation tradeAllocation);

        Task<IEnumerable<RawTradeAllocation>> AddRangeAsync(IEnumerable<RawTradeAllocation> tradeAllocations);
        Task<IEnumerable<RawTradeAllocation>> UpsertRangeAsync(IEnumerable<RawTradeAllocation> tradeAllocations);
        Task<IEnumerable<RawTradeAllocation>> GetByTradeId(int tradeId);
    }
}
