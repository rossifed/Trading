using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Weights.Domain.Model;
namespace Quantaventis.Trading.Modules.Weights.Domain.Repositories
{
    internal interface IModelWeightRepository
    {


        Task<IEnumerable<ModelWeight>> GetByPortfolioIdAsync(int portfolioId);

        Task<IEnumerable<ModelWeight>> GetByModelWeightingIdAsync(int modelWeightingId);
    }
}
