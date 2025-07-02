using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Booking.Domain.Model;
using Quantaventis.Trading.Modules.Booking.Domain.Repositories;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Mappers;
using Quantaventis.Trading.Shared.Infrastructure;
namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Repository
{
    internal class RawTradeRepository : IRawTradeRepository
    {
        private IRawTradeDao RawTradeDao { get; }

        public RawTradeRepository(IRawTradeDao tradeDao)
        {
            RawTradeDao = tradeDao;
        }


        public async Task<RawTrade> CreateAsync(RawTrade trade)
        {
            var entity = trade.Map();
            var newEntity = await RawTradeDao.CreateAsync(trade.Map());
            return newEntity.Map();
        }

        public async Task<RawTrade?> GetByEmsxOrderId(int emsxOrderId)
        {

            var entity = await RawTradeDao.GetByEmsxOrderIdAsync(emsxOrderId);
            return entity?.Map();
        }

        public async Task UpdateAsync(RawTrade trade)
        {
            var entity = trade.Map();
            await RawTradeDao.CreateAsync(trade.Map());

        }

        public async Task<RawTrade?> GetByTradeId(int tradeId)
        {
            var entity = await RawTradeDao.GetByTradeId(tradeId);
            return entity?.Map();
        }

        public async Task<RawTrade> UpsertOnEmsxOrderIdAsync(RawTrade trade)
        {
            if (trade.EmsxOrderId != null)
            {
                var existingEntity = await RawTradeDao.GetByEmsxOrderIdAsync(trade.EmsxOrderId.Value);
                Entities.RawTrade mappedEntity = trade.Map();
                if (existingEntity != null)
                {
                    mappedEntity.TradeId = existingEntity.TradeId;
                    await RawTradeDao.UpdateAsync(mappedEntity);
                }
                else
                {
                    existingEntity = await RawTradeDao.CreateAsync(mappedEntity);
                }
                return existingEntity.Map();
            }
            else
            {
                throw new InvalidOperationException($"Trade {trade} can't be upserted because the  EmsxOrderId is null.");
            }
        }

        public async Task<RawTrade> UpsertByEmsxOrderIdAsync(RawTrade executedTrade)
        {
            Entities.RawTrade entity = executedTrade.Map();
            await RawTradeDao.UpsertByEmsxOrderIdAsync(entity);
            Entities.RawTrade? upsertedEntity = await RawTradeDao.GetByEmsxOrderIdAsync(entity.EmsxOrderId.Value);
            return upsertedEntity?.Map();
        }

        public async Task<IEnumerable<RawTrade>> GetNonBookedAsync()
        {
            IEnumerable<Entities.RawTrade> entities = await RawTradeDao.GetNonBookedAsync();
            return entities.Map();
        }

        public async Task<RawTrade> UpsertByOrderRefIdAsync(RawTrade trade)
        {
            if (trade.OrderReferenceId != null)
            {
                var existingEntity = await RawTradeDao.GetByOrderRefIdAsync(trade.OrderReferenceId.Value);
                Entities.RawTrade mappedEntity = trade.Map();
                if (existingEntity != null)
                {
                    mappedEntity.TradeId = existingEntity.TradeId;
                    await RawTradeDao.UpdateAsync(mappedEntity);
                }
                else
                {
                    existingEntity = await RawTradeDao.CreateAsync(mappedEntity);
                }
                return existingEntity.Map();
            }
            else
            {
                throw new InvalidOperationException($"Trade {trade} can't be upserted because the  OrderReferenceId is null.");
            }
        }
    }
}
