using Quantaventis.Trading.Modules.EFRP.Domain.Model;
using Quantaventis.Trading.Modules.EFRP.Domain.Repositories;
using Quantaventis.Trading.Modules.EFRP.Infrastructure.Dao;
using Quantaventis.Trading.Modules.EFRP.Infrastructure.Mappers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EFRP.Infrastructure.Repositories
{
    internal class EfrpConversionRuleRepository : IEfrpConversionRuleRepository
    {
        private IEfrpConversionRuleDao EfrpConversionRuleDao { get;}

        public EfrpConversionRuleRepository(IEfrpConversionRuleDao efrpConversionRuleDao)
        {
            EfrpConversionRuleDao = efrpConversionRuleDao;
        }

        public async Task<IEnumerable<EfrpConversionRule>> GetAllAsync()
        {
            var entities = await EfrpConversionRuleDao.GetAllAsync();
            return entities.Map();
        }

    
    }
}
