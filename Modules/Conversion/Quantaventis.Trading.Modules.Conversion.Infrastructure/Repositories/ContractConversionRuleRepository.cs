using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using  Quantaventis.Trading.Modules.Conversion.Domain.Model;
using Quantaventis.Trading.Modules.Conversion.Domain.Repositories;
using Entities = Quantaventis.Trading.Modules.Conversion.Infrastructure.Entities;
using Quantaventis.Trading.Modules.Conversion.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Conversion.Infrastructure.Mapping;

namespace Quantaventis.Trading.Modules.Conversion.Infrastructure.Repositories
{
    internal class ContractConversionRuleRepository : IContractConversionRuleRepository
    {
        private ICurrencyPairConversionRuleRepository CurrencyPairConversionRuleRepository { get; }
        private IFutureConversionRuleRepository FutureConversionRuleRepository { get; }

        private IEquityConversionRuleRepository EquityConversionRuleRepository { get; }
        public ContractConversionRuleRepository(ICurrencyPairConversionRuleRepository CurrencyPairConversionRuleRepository,
        IFutureConversionRuleRepository futureConversionRuleRepository,
        IEquityConversionRuleRepository equityConversionRuleRepository)
        {
            this.CurrencyPairConversionRuleRepository = CurrencyPairConversionRuleRepository;
            this.EquityConversionRuleRepository = equityConversionRuleRepository;
            this.FutureConversionRuleRepository=    futureConversionRuleRepository;
        }
     
        public async Task<IEnumerable<IContractConversionRule>> GetByPortfolioIdAsync(byte portfolioId)
        {
            IEnumerable<IContractConversionRule> CurrencyPairConversionRules = await CurrencyPairConversionRuleRepository.GetByPortfolioIdAsync(portfolioId);
         
            IEnumerable<IContractConversionRule> futureConversionRules = await FutureConversionRuleRepository.GetByPortfolioIdAsync(portfolioId);
            IEnumerable<IContractConversionRule> equityConversionRules = await EquityConversionRuleRepository.GetByPortfolioIdAsync(portfolioId);
            return CurrencyPairConversionRules
                .Union(futureConversionRules)
                .Union(equityConversionRules);
        }
    }
}
