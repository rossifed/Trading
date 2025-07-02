using Quantaventis.Trading.Modules.Booking.Domain.Model;
using Quantaventis.Trading.Modules.Booking.Domain.Repositories;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Mappers;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Repository
{
    internal class TradeInstrumentTypeRepository : ITradeInstrumentTypeRepository
    {
     private   ITradeInstrumentTypeDao TradeInstrumentTypeDao { get; }

        public TradeInstrumentTypeRepository(ITradeInstrumentTypeDao tradeInstrumentTypeDao)
        {
            TradeInstrumentTypeDao = tradeInstrumentTypeDao;
        }

    
    

        public async Task<TradeInstrumentType?> GetAsync(string instrumentType, bool isSwap)
        {
           Entities.TradeInstrumentType? entity = await TradeInstrumentTypeDao.GetAsync(instrumentType, isSwap);
            return entity?.Map();
        }
    }
}
