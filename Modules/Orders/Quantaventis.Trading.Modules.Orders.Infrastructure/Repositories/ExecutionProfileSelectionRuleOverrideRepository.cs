using Quantaventis.Trading.Modules.Orders.Domain.Model;
using Quantaventis.Trading.Modules.Orders.Domain.Repositories;
using Quantaventis.Trading.Modules.Orders.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Orders.Infrastructure.Mappers;

namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Repositories
{
    internal class ExecutionProfileSelectionRuleOverrideRepository : IExecutionProfileSelectionRuleOverrideRepository
    {

        private IExecutionProfileSelectionRuleOverrideDao ExecutionProfileSelectionRuleOverrideDao { get; }

        public ExecutionProfileSelectionRuleOverrideRepository(IExecutionProfileSelectionRuleOverrideDao executionProfileSelectionRuleOverrideDao)
        {
            ExecutionProfileSelectionRuleOverrideDao = executionProfileSelectionRuleOverrideDao;
        }


       public async Task<IEnumerable<ExecutionProfileSelectionRuleOverride>> GetAllAsync()
        {
            IEnumerable<Entities.ExecutionProfileSelectionRuleOverride> entities = await ExecutionProfileSelectionRuleOverrideDao.GetAllAsync();
            return entities.Map();
 
        }

   
    } 
}
