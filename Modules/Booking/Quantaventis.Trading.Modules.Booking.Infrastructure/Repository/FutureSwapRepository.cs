using Quantaventis.Trading.Modules.Booking.Domain.Model;
using Quantaventis.Trading.Modules.Booking.Domain.Repositories;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Mappers;
using Entitites =Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Repository
{
    internal class FutureSwapRepository : IFutureSwapRepository
    {
        private IFutureSwapDao FutureSwapDao { get; }
        private IInstrumentDao InstrumentDao { get; }

        public FutureSwapRepository(IFutureSwapDao futureSwapDao, 
            IInstrumentDao instrumentDao)
        {
            FutureSwapDao = futureSwapDao;
            InstrumentDao = instrumentDao;
        }

        public async Task<bool> IsTradedAsFutureSwapAsync(Instrument instrument, Counterparty executionBroker)
        {
            Entities.Instrument? instument = await InstrumentDao.GetByInstrumentIdAsync(instrument.Id);
            Entities.FutureSwap? entity = null;
            if (instument != null && instument.GenericFutureId != null)
            entity = await FutureSwapDao.GetAsync( instument.GenericFutureId.Value, executionBroker.Id);
            return entity != null;
        }
    }
}
