using Quantaventis.Trading.Modules.Valuation.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Valuation.Domain.Repositories
{
    internal interface IFxRateRepository
    {
        Task<FxRate> GetAsync(Currency fromCurrency, Currency toCurrency);
        Task<IEnumerable<FxRate>> GetByQuoteCurrencyAsync(Currency quoteCurrency);
    }
}
