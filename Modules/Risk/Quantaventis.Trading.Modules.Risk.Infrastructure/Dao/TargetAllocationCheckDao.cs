
using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Risk.Domain.Model;
using Quantaventis.Trading.Modules.Risk.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Risk.Infrastructure.Dao
{   internal interface ITargetAllocationCheckDao {

        Task<TargetAllocationCheck?> GetByTargetAllocationIdAsync(int targetAllocationId);
        Task CreateAsync(TargetAllocationCheck targetAllocationCheck);

    }
    internal class TargetAllocationCheckDao : ITargetAllocationCheckDao
    {
        private RiskDbContext DbContext { get; }

        public TargetAllocationCheckDao(RiskDbContext dbContext)
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

        public async Task<TargetAllocationCheck?> GetByTargetAllocationIdAsync(int targetAllocationId)
        {
            return await DbContext.TargetAllocationChecks
                .AsNoTracking()
                .Where(x => x.TargetAllocationId == targetAllocationId)
            .Include(x => x.ConstraintBreaches)
            .ThenInclude(x => x.Constraint)
            .FirstOrDefaultAsync();
        }

        public async Task CreateAsync(TargetAllocationCheck targetAllocationCheck)
        {
            await DbContext.AddAsync(targetAllocationCheck);
            await DbContext.SaveChangesAsync();
        }
    }
}
