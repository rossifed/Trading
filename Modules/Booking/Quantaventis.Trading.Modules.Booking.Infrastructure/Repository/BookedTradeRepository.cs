using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Booking.Domain.Model;
using Quantaventis.Trading.Modules.Booking.Domain.Repositories;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Mappers;
using Quantaventis.Trading.Shared.Infrastructure.Database;
namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Repository
{
    internal class BookedTradeRepository : IBookedTradeRepository
    {  
        private ITradeDao TradeDao { get; }
        private ITradeAllocationDao TradeAllocationDao { get; }
        private IUnitOfWork UnitOfWork { get; }

        public BookedTradeRepository(
            ITradeDao tradeDao, 
            ITradeAllocationDao tradeAllocationDao, 
            IUnitOfWork unitOfWork)
        {
            TradeDao = tradeDao;
            TradeAllocationDao = tradeAllocationDao;
            UnitOfWork = unitOfWork;
        }

        public async Task<BookedTrade?> GetByEmsxOrderId(int emsxOrderId)
        {
           
           var entity = await TradeDao.GetByEmsxOrderId(emsxOrderId);
            return entity?.Map();
        }

        public async Task UpdateAsync(BookedTrade trade)
        {
            var entity = trade.Map();
          await TradeDao.UpdateAsync(entity);
           
        }

        public async Task<BookedTrade?> GetByTradeId(int tradeId)
        {
            var entity = await TradeDao.GetByTradeId(tradeId);
            return entity?.Map();
        }

        public async Task<BookedTrade> AddAsync(BookedTrade trade)
        {
            var entity = trade.Map();
            Entities.Trade newtrade = await TradeDao.CreateAsync(entity);
            return newtrade.Map();
        }

        public async Task<IEnumerable<BookedTrade>> GetByTradeDate(DateOnly tradeDate)
        {
            IEnumerable<Entities.Trade> entities = await TradeDao.GetByTradeDateAsync(tradeDate);
            return entities.Map();
        }

        public async Task<IEnumerable<BookedTrade>> GetByInstrumentId(int instrumentId)
        {
            IEnumerable<Entities.Trade> entities = await TradeDao.GetByInstrumentIdAsync(instrumentId);
            return entities.Map();
        }

        public async Task<IEnumerable<BookedTrade>> GetByBookingDate(DateOnly bookingDate)
        {
            IEnumerable<Entities.Trade> entities = await TradeDao.GetByBookingDateAsync(bookingDate);
            return entities.Map();
        }

        public async Task<BookedTrade?> GetByTradeAllocationId(int tradeAllocationId)
        {       Entities.Trade? entity = await TradeDao.GetByTradeAllocationId(tradeAllocationId);
            return entity?.Map();
        }

        public async Task UpsertAsync(BookedTrade trade)
        {
            await UnitOfWork.ExecuteAsync(async () =>
            {

                await TradeDao.UpsertAsync(trade.Map());
                await TradeAllocationDao.UpsertRangeAsync(trade.BookedTradeAllocations.Map());

            });


        }

        public async Task RemoveAsync(int tradeId)
        {
            await TradeDao.DeleteAsync(tradeId);
        }
    }
}
