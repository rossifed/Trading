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
    internal class ExchangeRepository : IExchangeRepository
    {
        private IExchangeDao ExchangeDao { get; }

        public ExchangeRepository(IExchangeDao exchangeDao)
        {
            ExchangeDao = exchangeDao;
        }
        public async Task<IEnumerable<Exchange>> GetAllAsync()
        {
           var entities = await ExchangeDao.GetAllAsync();
            return entities.Map();
        }
    }
}
