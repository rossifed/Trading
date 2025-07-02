using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Execution.Domain.Model;
namespace Quantaventis.Trading.Modules.Execution.Domain.Repositories
{
    internal interface IEmsxOrderExecutionRepository
    {

        Task<Model.EmsxTrade?> GetByEmsxOrderIdAsync(int orderId);


    }
}
