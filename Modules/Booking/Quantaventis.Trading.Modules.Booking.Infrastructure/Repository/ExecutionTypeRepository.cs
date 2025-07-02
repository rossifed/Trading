using Quantaventis.Trading.Modules.Booking.Domain.Model;
using Quantaventis.Trading.Modules.Booking.Domain.Repositories;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Mappers;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Repository
{
    internal class ExecutionTypeRepository : IExecutionTypeRepository
    {
     private   IExecutionTypeDao ExecutionTypeDao { get; }

        public ExecutionTypeRepository(IExecutionTypeDao executionTypeDao)
        {
            ExecutionTypeDao = executionTypeDao;
        }

    
        public async Task<ExecutionType?> GetExecutionTypeAsync(int executionDeskId, string strategy)
        {
            Entities.ExecutionType? entity = await ExecutionTypeDao.GetExecutionTypeAsync(executionDeskId, strategy);
            return entity?.Map();
        }

        public async Task<ExecutionType?> GetDefaultExecutionTypeAsync(int executionDeskId)
        {
            return await GetExecutionTypeAsync(executionDeskId, "*");
        }
    }
}
