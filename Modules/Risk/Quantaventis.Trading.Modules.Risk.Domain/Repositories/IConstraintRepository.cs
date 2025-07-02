using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Risk.Domain.Model;
using Quantaventis.Trading.Modules.Risk.Domain.Model.Constraints;
namespace Quantaventis.Trading.Modules.Risk.Domain.Repositories
{
    internal interface IConstraintRepository
    {

        Task<IEnumerable<Constraint>> GetByPortfolioIdAsync(PortfolioId portfolioId);
    }
}
