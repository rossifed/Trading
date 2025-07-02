using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Booking.Domain.Model;
using Quantaventis.Trading.Modules.Booking.Domain.Repositories;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Mappers;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Repository
{
    internal class TradeBookingErrorRepository : ITradeBookingErrorRepository
    {  
        private ITradeBookingErrorDao TradeBookingErrorDao { get; }

        public TradeBookingErrorRepository(ITradeBookingErrorDao tradeBookingErrorDao)
        {
            TradeBookingErrorDao = tradeBookingErrorDao;
        }

        public async Task CreateAsync(TradeBookingError error)
        {
           await  TradeBookingErrorDao.CreateAsync(error.Map());
        }

        public async Task DeleteByTradeIdAsync(int tradeId)
        {
          await TradeBookingErrorDao.DeleteByTradeIdAsync(tradeId);
        }

        public async Task<IEnumerable<TradeBookingError>> GetByTradeIdAsync(int tradeId)
        {
            IEnumerable<Entities.TradeBookingError> entities = await TradeBookingErrorDao.GetByTradeIdAsync(tradeId);
            return entities.Map();
        }

        public async Task<IEnumerable<TradeBookingError>> GeAllAsync()
        {
            IEnumerable<Entities.TradeBookingError> entities = await TradeBookingErrorDao.GetAllAsync();
            return entities.Map();
        }
    }
}
