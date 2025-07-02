using Quantaventis.Trading.Modules.Risk.Domain.Model;
using Quantaventis.Trading.Modules.Risk.Domain.Model.Constraints;
using Quantaventis.Trading.Modules.Risk.Domain.Repositories;
using Entities =Quantaventis.Trading.Modules.Risk.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Risk.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Risk.Infrastructure.Mappers;

namespace Quantaventis.Trading.Modules.Risk.Infrastructure.Repositories
{
    internal class ConstraintRepository : IConstraintRepository
    {
        private IConstraintDao ConstraintDao { get; }
        private IConstraintFactory ConstraintFactory { get; }

        public ConstraintRepository(IConstraintDao constraintDao, IConstraintFactory constraintFactory)
        {
            this.ConstraintDao = constraintDao;
            this.ConstraintFactory = constraintFactory;
        }

        public async Task<IEnumerable<Constraint>> GetByPortfolioIdAsync(PortfolioId portfolioId)
        {
            IEnumerable<Entities.Constraint> entities =await  ConstraintDao.GetByPortfolioIdAsync(portfolioId);
            return entities.Map(ConstraintFactory);
        }
    }
}
