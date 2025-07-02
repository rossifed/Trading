using Quantaventis.Trading.Modules.Valuation.Domain.Model;
using Quantaventis.Trading.Modules.Valuation.Domain.Repositories;
using Quantaventis.Trading.Modules.Valuation.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Valuation.Infrastructure.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Valuation.Infrastructure.Repositories
{
    internal class InstrumentPricingRepository : IInstrumentPricingRepository
    {
        private IInstrumentPricingDao InstrumentPricingDao { get; }
        public InstrumentPricingRepository(IInstrumentPricingDao instrumentPricingDao)
        {
            this.InstrumentPricingDao = instrumentPricingDao;
        }
        public async Task<InstrumentPricing> GetByInstrumentIdAsync(int instrumentId)
        {
            Entities.InstrumentPricing entity = await InstrumentPricingDao.GetByInstrumentIdAsync(instrumentId);

            if (entity == null)
                throw new Exception($"Not Pricing has been found for the instrument {instrumentId}");

            return new InstrumentPricing(entity.InstrumentId, new Money(entity.Price, entity.Currency), entity.Date);
        }

        public async Task<IEnumerable<InstrumentPricing>> GetByInstrumentIdsAsync(IEnumerable<InstrumentId> instrumentIds)
        {
            IEnumerable<Entities.InstrumentPricing> entities = await InstrumentPricingDao.GetByInstrumentIdsAsync(instrumentIds.Select(x=>(int)x));
            return entities.Map();
        }
    }
}
