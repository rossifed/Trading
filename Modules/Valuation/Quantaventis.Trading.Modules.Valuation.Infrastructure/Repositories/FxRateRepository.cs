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
using Quantaventis.Trading.Shared.Infrastructure;

namespace Quantaventis.Trading.Modules.Valuation.Infrastructure.Repositories
{
    internal class FxRateRepository : IFxRateRepository
    {
        private IFxRateDao FxRateDao { get; }
        public FxRateRepository(IFxRateDao fxRateDao)
        {
            this.FxRateDao = fxRateDao;
        }
        public async Task<FxRate> GetAsync(Currency fromCurrency, Currency toCurrency)
        {
           Entities.FxRate entity = await FxRateDao.GetAsync(fromCurrency, toCurrency);
            return new FxRate(entity.Value,entity.BaseCurrency, entity.QuoteCurrency);
        }

        public async Task<IEnumerable<FxRate>> GetByQuoteCurrencyAsync(Currency quoteCurrency)
        {
           var entities =  await FxRateDao.GetByQuoteCurrencyAsync(quoteCurrency);
            return entities.Map();
        }
    }
}
