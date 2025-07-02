using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Orders.Domain.Model;
namespace Quantaventis.Trading.Modules.Orders.Domain.Repositories
{
    internal interface IPortfolioRepository
    {
        Task UpdateAsync(Portfolio portfolio);
        Task AddAsync(Portfolio portfolio);
        Task<IEnumerable<Portfolio>> GetAllAsync();
    }
}
