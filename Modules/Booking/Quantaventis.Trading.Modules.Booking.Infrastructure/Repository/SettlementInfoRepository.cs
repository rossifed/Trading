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
    internal class SettlementInfoRepository : ISettlementInfoRepository
    {
     private   ISettlementInfoDao SettlementInfoDao { get; }

        public SettlementInfoRepository(ISettlementInfoDao settlementInfoDao)
        {
            SettlementInfoDao = settlementInfoDao;
        }

 

        public async Task<SettlementInfo?> GetByCounterpartyAndInstrumentAsync(int counterparty, int instrumentId, bool isSwap)
        {
            Entities.SettlementInfo? entity = await SettlementInfoDao.GetByCounterpartyAndInstrumentAsync(counterparty,instrumentId, isSwap);
            return entity?.Map();
        }
    }
}
