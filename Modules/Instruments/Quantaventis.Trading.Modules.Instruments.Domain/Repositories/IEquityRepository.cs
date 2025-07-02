using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Instruments.Domain.Model;
namespace Quantaventis.Trading.Modules.Instruments.Domain.Repositories
{
    internal interface IEquityRepository
    {
        Task<IEnumerable<Equity>> GetAllAsync();
        Task<IEnumerable<Equity>> GetBySymbolsAsync(IEnumerable<string> symbols);

        Task<IEnumerable<Equity>> AddAsync(IEnumerable<Equity> equitites);
        Task<Equity> AddAsync(Equity equity);
        Task UpdateAsync(IEnumerable<Equity> equitites);
    }
}
