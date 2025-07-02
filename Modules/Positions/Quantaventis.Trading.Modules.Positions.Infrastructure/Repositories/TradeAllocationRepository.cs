using Quantaventis.Trading.Modules.Positions.Domain.Model;
using Quantaventis.Trading.Modules.Positions.Domain.Repositories;
using Quantaventis.Trading.Modules.Positions.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Positions.Infrastructure.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Positions.Infrastructure.Repositories
{
    internal class TradeAllocationRepository : ITradeAllocationRepository
    {
       private ITradeAllocationDao TradeAllocationDao { get; }

        public TradeAllocationRepository(ITradeAllocationDao tradeAllocationDao)
        {
            TradeAllocationDao = tradeAllocationDao;
        }

        public async Task<IEnumerable<TradeAllocation>> GetFromInceptionAsync(byte portfolioId,InvestedInstrument investedInstrument)
        {
           IEnumerable<Entities.TradeAllocation> entities =await  TradeAllocationDao
                .GetFromInceptionAsync(
                portfolioId,
                investedInstrument.InstrumentId, 
                investedInstrument.IsSwap);
            return entities.Map();
        }

        public async Task<IEnumerable<TradeAllocation>> GetByTradeIdAsync(int tradeid)
        {
            IEnumerable<Entities.TradeAllocation> entities = await TradeAllocationDao.GetByTradeIdAsync(tradeid);
            return entities.Map();
        }

        public async Task<IEnumerable<TradeAllocation>> GetAfterDateAsync(byte portfolioId, InvestedInstrument investedInstrument, DateOnly tradeDate)
        {
            IEnumerable<Entities.TradeAllocation> entities = await TradeAllocationDao.GetAfterDateAsync(
                portfolioId,
                investedInstrument.InstrumentId, 
                investedInstrument.IsSwap, tradeDate);
            return entities.Map();
        }

        public async  Task RemoveAsync(int tradeAllocationId)
        {
         await TradeAllocationDao.RemoveAsync(tradeAllocationId);
         
        }

        public async Task UpsertAsync(TradeAllocation tradeAllocation)
        {
            await TradeAllocationDao.UpsertAsync(tradeAllocation.Map());
        }

        public async Task UpsertRangeAsync(IEnumerable<TradeAllocation> tradeAllocations)
        {
            await TradeAllocationDao.UpsertRangeAsync(tradeAllocations.Map());
        }

     

        public async Task<IEnumerable<TradeAllocation>> GetAllByPortfolioIdFromDateAsync(byte portfolioId, DateOnly fromDate)
        {
            var entities = await TradeAllocationDao.GetAllByPortfolioIdFromDateAsync(portfolioId, fromDate);
            return entities.Map();
        }

        public async Task<IEnumerable<TradeAllocation>> GetFromDateAsync(byte portfolioId, InvestedInstrument investedInstrument, DateOnly fromTradeDate)
        {
            var entities = await TradeAllocationDao.GetFromDateAsync(
                portfolioId,
                investedInstrument.InstrumentId,
                investedInstrument.IsSwap, 
                fromTradeDate);
            return entities.Map();
        }

   
    }
}
