using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Instruments.Domain.Model;
namespace Quantaventis.Trading.Modules.Instruments.Domain.Repositories
{
    internal interface ICurrencyPairRepository
    {

        Task<IEnumerable<CurrencyPair>> GetBySymbolsAsync(IEnumerable<string> symbols);

        Task<IEnumerable<CurrencyPair>> AddAsync(IEnumerable<CurrencyPair> CurrencyPaires);

        Task<CurrencyPair> AddAsync(CurrencyPair CurrencyPair);
    }
}
