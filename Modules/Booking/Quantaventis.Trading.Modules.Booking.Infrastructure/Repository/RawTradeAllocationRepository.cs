using Quantaventis.Trading.Modules.Booking.Domain.Model;
using Quantaventis.Trading.Modules.Booking.Domain.Repositories;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Repository
{
    internal class RawTradeAllocationRepository : IRawTradeAllocationRepository
    {
        private IRawTradeAllocationDao RawTradeAllocationDao { get; }

        public RawTradeAllocationRepository(IRawTradeAllocationDao rawTradeAllocationDao)
        {
            RawTradeAllocationDao = rawTradeAllocationDao;
        }

        public async Task<IEnumerable<RawTradeAllocation>> UpsertRangeAsync(IEnumerable<RawTradeAllocation> tradeAllocations)
        {
            var entities = tradeAllocations.Map();
            await RawTradeAllocationDao.UpsertRangeAsync(entities);
            return entities.Map();
        }

        public async Task<IEnumerable<RawTradeAllocation>> GetByTradeId(int tradeId)
        {
            var entities = await RawTradeAllocationDao.GetByTradeId(tradeId);
            return entities.Map();
        }

        public async Task AddAsync(RawTradeAllocation tradeAllocation)
        {
            await RawTradeAllocationDao.CreateAsync(tradeAllocation.Map());
        }

        public async Task<IEnumerable<RawTradeAllocation>> AddRangeAsync(IEnumerable<RawTradeAllocation> tradeAllocations)
        {
            var entities = await RawTradeAllocationDao.CreateRangeAsync(tradeAllocations.Map());
            return entities.Map();
        }
    }
}
