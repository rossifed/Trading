using Quantaventis.Trading.Modules.Valuation.Domain.Model;
using Quantaventis.Trading.Modules.Valuation.Domain.Repositories;
using Quantaventis.Trading.Modules.Valuation.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Valuation.Infrastructure.Mappers;
using Entities = Quantaventis.Trading.Modules.Valuation.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Quantaventis.Trading.Modules.Valuation.Infrastructure.Factories;

namespace Quantaventis.Trading.Modules.Valuation.Infrastructure.Repositories
{
    internal class InstrumentRepository : IInstrumentRepository
    {
        private IInstrumentFactory InstrumentFactory { get; }
        private IInstrumentDao InstrumentDao { get; }
        public InstrumentRepository(IInstrumentDao instrumentDao)
        {
            this.InstrumentDao = instrumentDao;
        }
   

        public async Task<IEnumerable<Instrument>> GetByIdsAsync(IEnumerable<int> instrumentIds)
        {
            IEnumerable<Entities.Instrument> entities = await InstrumentDao.GetByIdsAsync(instrumentIds);
            return InstrumentFactory.CreateInstruments(entities);

        }
    }
}
