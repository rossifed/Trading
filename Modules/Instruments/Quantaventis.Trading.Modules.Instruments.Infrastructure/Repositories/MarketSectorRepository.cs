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
    internal class MarketSectorRepository : IMarketSectorRepository
    {
        private IMarketSectorDao MarketSectorDao { get; }

        public MarketSectorRepository(IMarketSectorDao marketSectorDao)
        {
            MarketSectorDao = marketSectorDao;
        }
        public async Task<IEnumerable<MarketSector>> GetAllAsync()
        {
            var entities = await MarketSectorDao.GetAllAsync();
            return entities.Map();
        }
    }
}
