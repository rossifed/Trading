using Quantaventis.Trading.Modules.Valuation.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Valuation.Domain.Repositories
{
    internal interface IPortfolioRepository
    {
        Task<Portfolio?> GetByIdAsync(byte portfolioId);

        Task<IEnumerable<Portfolio>> GetAllAsync();
        Task<Money> GetPortfolioValueAsync(byte portfolioId);
    }
}
