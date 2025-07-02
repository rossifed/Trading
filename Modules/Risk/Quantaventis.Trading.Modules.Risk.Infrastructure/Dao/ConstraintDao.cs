
using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Risk.Domain.Model;
using Quantaventis.Trading.Modules.Risk.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Risk.Infrastructure.Dao
{   internal interface IConstraintDao {

        Task<IEnumerable<Constraint>> GetByPortfolioIdAsync(byte portfolioId);

    }
    internal class ConstraintDao : IConstraintDao
    {
        private RiskDbContext DbContext { get; }

        public ConstraintDao(RiskDbContext dbContext)
        {

            this.DbContext = dbContext;
        }

        public async Task<IEnumerable<Constraint>> GetByPortfolioIdAsync(byte portfolioId)
        {
              return   await DbContext.Constraints
                .Include(x => x.RelationalOperator)
                .Include(x => x.ConstraintType)
                .Join(DbContext.PortfolioConstraints, a => a.ConstraintId, b => b.ConstraintId , (a, b) => new { PortfolioId = b.PortfolioId, Constraint =  a})
                .Where(x => x.PortfolioId == portfolioId)                  
                .Select(x=>x.Constraint)
                .ToListAsync();
        }
    }
}
