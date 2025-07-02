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
    internal class ExecutionDeskRepository : IExecutionDeskRepository
    {
     private   IExecutionDeskDao ExecutionDeskDao { get; }

        public ExecutionDeskRepository(IExecutionDeskDao executionDeskDao)
        {
            ExecutionDeskDao = executionDeskDao;
        }

        public async Task<ExecutionDesk?> GetByCodeAsync(string code)
        {
            Entities.ExecutionDesk? entity = await ExecutionDeskDao.GetByCodeAsync(code);
            return entity?.Map();
        }
    }
}
