using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Instruments.Domain.Model;
namespace Quantaventis.Trading.Modules.Instruments.Domain.Repositories
{
    internal interface IGenericFutureRepository
    {
        Task<GenericFuture?> GetBySymbolAsync(string symbol);

        Task<IEnumerable<GenericFuture>> GetBySymbolsAsync(IEnumerable<string> symbols);

        Task<IEnumerable<GenericFuture>> GetAllAsync();

        Task UpdateAsync(IEnumerable<GenericFuture> genericFutures);

        Task<GenericFuture> AddAsync(GenericFuture genericFuture);
    }
}
