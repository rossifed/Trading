using Domain = Quantaventis.Trading.Modules.Conversion.Domain.Model;
using Quantaventis.Trading.Modules.Conversion.Domain.Repositories;
using Quantaventis.Trading.Modules.Conversion.Infrastructure.Dao;
using Entities = Quantaventis.Trading.Modules.Conversion.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Conversion.Infrastructure.Mapping;
using Quantaventis.Trading.Modules.Conversion.Domain.Model;

namespace Quantaventis.Trading.Modules.Conversion.Infrastructure.Repositories
{
    internal class InstrumentRepository : IInstrumentRepository
    {
        private IInstrumentDao InstrumentDao { get; }


        public InstrumentRepository(IInstrumentDao instrumentDao)
        {
            InstrumentDao = instrumentDao;
        }

        public async Task<IEnumerable<Instrument>> GetByIdsAsync(IEnumerable<int> instrumentIds)
        {
            var entities = await InstrumentDao.GetByIdsAsync(instrumentIds);
            return entities.Map();
        }
    }
}
