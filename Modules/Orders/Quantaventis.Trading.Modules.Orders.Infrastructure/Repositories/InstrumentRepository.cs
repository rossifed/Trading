using Quantaventis.Trading.Modules.Orders.Domain.Model;
using Quantaventis.Trading.Modules.Orders.Domain.Repositories;
using Quantaventis.Trading.Modules.Orders.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Orders.Infrastructure.Mappers;
using Entities = Quantaventis.Trading.Modules.Orders.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;

namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Repositories
{
    internal class InstrumentRepository : IInstrumentRepository
    {
        private IInstrumentDao InstrumentDao { get; }
        public InstrumentRepository(IInstrumentDao instrumentDao)
        {
            this.InstrumentDao = instrumentDao;
        }

        public async Task AddAsync(Instrument instrument) {
           await InstrumentDao.CreateAsync(instrument.Map());
        }
        public async Task<IEnumerable<Instrument>> GetByIdsAsync(IEnumerable<int> instrumentIds)
        {
            IEnumerable<Entities.Instrument> entities = await InstrumentDao.GetByIdsAsync(instrumentIds);
            return entities.Map();

        }
    }
}
