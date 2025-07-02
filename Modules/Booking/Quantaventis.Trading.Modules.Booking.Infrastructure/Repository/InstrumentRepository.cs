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
    internal class InstrumentRepository : IInstrumentRepository
    {
     private   IInstrumentDao InstrumentDao { get; }

        public InstrumentRepository(IInstrumentDao instrumentDao)
        {
            InstrumentDao = instrumentDao;
        }

        public async Task<Instrument?> GetBySymbolAsync(string symbol)
        {
            Entities.Instrument? entity = await InstrumentDao.GetBySymbolAsync(symbol);

            return entity?.Map();
        }
    }
}
