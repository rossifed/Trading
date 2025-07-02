using Quantaventis.Trading.Modules.Instruments.Domain.Model;
using Quantaventis.Trading.Modules.Instruments.Domain.Repositories;
using Quantaventis.Trading.Modules.Instruments.Infrastructure.Dao;
using Entities = Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Instruments.Infrastructure.Mappers;

namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Repositories
{
    internal class InstrumentRepository : IInstrumentRepository
    {
        private IInstrumentDao InstrumentDao { get; }

        public InstrumentRepository(IInstrumentDao instrumentDao)
        {
            InstrumentDao = instrumentDao;
        }
        public async Task<IEnumerable<Instrument>> GetBySymbolsAsync(IEnumerable<string> symbols)
        {
            IEnumerable<Entities.Instrument> entities = await InstrumentDao.GetBySymbolsAsync(symbols);

            return entities.Map();
        }

        public async Task<IEnumerable<Instrument>> GetAllAsync()
        {
            IEnumerable<Entities.Instrument> entities = await InstrumentDao.GetAllAsync();

            return entities.Map();
        }
    }
}
