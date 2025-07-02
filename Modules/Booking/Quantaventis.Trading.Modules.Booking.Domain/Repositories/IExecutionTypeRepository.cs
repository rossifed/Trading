using Quantaventis.Trading.Modules.Booking.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Booking.Domain.Repositories
{
    interface IExecutionTypeRepository
    {
        Task<ExecutionType?> GetExecutionTypeAsync(int executionDeskId, string strategy);

        Task<ExecutionType?> GetDefaultExecutionTypeAsync(int executionDeskId);
    }


}
