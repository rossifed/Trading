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
    internal class InstrumentMappingRepository : IInstrumentMappingRepository
    {
        private IInstrumentMappingDao InstrumentMappingDao { get; }


        public InstrumentMappingRepository(IInstrumentMappingDao instrumentMappingDao)
        {
            InstrumentMappingDao = instrumentMappingDao;
        }

        public async Task<IDictionary<InstrumentMappingType, Domain.Model.InstrumentMapping>> GetAllAsync()
        {
            IEnumerable<Entities.InstrumentMapping> instrumentMappings = await InstrumentMappingDao.GetAllAsync();
            return instrumentMappings.Map();
        }

        public async Task<InstrumentMapping> GetByTypeAsync(InstrumentMappingType mappingType)
        {
            IEnumerable<Entities.InstrumentMapping> instrumentMappings = await InstrumentMappingDao.GetByTypeAsync(mappingType.Mnemonic);
            return instrumentMappings.Map().Single().Value;
        }
    }
}
