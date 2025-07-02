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
    internal class CurrencyRepository : ICurrencyRepository
    {
        private ICurrencyDao CurrencyDao { get; }

        public CurrencyRepository(ICurrencyDao currencyDao)
        {
            CurrencyDao = currencyDao;
        }
        public async Task<IEnumerable<Currency>> GetAllAsync()
        {
            var entities = await CurrencyDao.GetAllAsync();
            return entities.Map();
        }
    }
}
