using Quantaventis.Trading.Modules.Orders.Domain.Model;
using Quantaventis.Trading.Modules.Orders.Domain.Repositories;
using Quantaventis.Trading.Modules.Orders.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Orders.Infrastructure.Mappers;

namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Repositories
{
    internal class ExecutionProfileSelectionRuleRepository : IExecutionProfileSelectionRuleRepository
    {

        private IExecutionProfileSelectionRuleDao ExecutionProfileSelectionRuleDao { get; }

        public ExecutionProfileSelectionRuleRepository(IExecutionProfileSelectionRuleDao executionProfileSelectionRuleDao)
        {
            ExecutionProfileSelectionRuleDao = executionProfileSelectionRuleDao;
        }


       public async Task<IEnumerable<ExecutionProfileSelectionRule>> GetAllAsync()
        {
            IEnumerable<Entities.ExecutionProfileSelectionRule> entities = await ExecutionProfileSelectionRuleDao.GetAllAsync();
            return entities.Map();
 
        }

   
    } 
}
