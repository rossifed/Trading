using Quantaventis.Trading.Modules.Instruments.Domain.Model;
using Quantaventis.Trading.Modules.Instruments.Domain.Repositories;
using Quantaventis.Trading.Modules.Instruments.Infrastructure.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Instruments.Infrastructure.Mappers;
namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Repositories
{
    internal class InstrumentTypeRepository : IInstrumentTypeRepository
    {
        private IInstrumentTypeDao InstrumentTypeDao { get; }

        public InstrumentTypeRepository(IInstrumentTypeDao instrumentTypeDao)
        {
            InstrumentTypeDao = instrumentTypeDao;
        }
        public async Task<IEnumerable<InstrumentType>> GetAllAsync()
        {
           var entities = await InstrumentTypeDao.GetAllAsync();
            return entities.Map();
        }

        public async Task<InstrumentType?> GetByMnemonicAsync(string mnemonic)
        {
            var entity = await InstrumentTypeDao.GetByMnemonicAsync(mnemonic);
            return entity?.Map();
        }
    }
}
