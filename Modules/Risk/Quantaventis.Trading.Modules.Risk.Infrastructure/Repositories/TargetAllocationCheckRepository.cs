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
    internal class TargetAllocationCheckRepository : ITargetAllocationCheckRepository
    {
        private ITargetAllocationCheckDao TargetAllocationCheckDao { get; }


        public TargetAllocationCheckRepository(ITargetAllocationCheckDao targetAllocationCheckDao)
        {
            this.TargetAllocationCheckDao = targetAllocationCheckDao;

        }


        public Task<TargetAllocationCheck?> GetByTargetAllocationIdAsync(int targetAllocationId)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(TargetAllocationCheck targetAllocationCheck)
        {     var entity = targetAllocationCheck.Map();
            await TargetAllocationCheckDao.CreateAsync(entity);
        }
    }
}
