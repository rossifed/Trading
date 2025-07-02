using Quantaventis.Trading.Modules.Rebalancing.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Rebalancing.Domain.Repositories
{
    internal interface IRebalancingSessionRepository
    {

        Task<RebalancingSession?> GetByIdAsync(int rebalancingSessionId);
        Task<RebalancingSession> AddAsync(RebalancingSession rebalancing);
        Task UpdateStatusAsync(RebalancingSession rebalancing);

        Task<RebalancingSession?> GetRebalancingInProgress();
    }
}
