using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using DomainModel = Quantaventis.Trading.Modules.Conversion.Domain.Model;
using Quantaventis.Trading.Modules.Conversion.Domain.Repositories;
using Entities = Quantaventis.Trading.Modules.Conversion.Infrastructure.Entities;
using Quantaventis.Trading.Modules.Conversion.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Conversion.Infrastructure.Mapping;
using Quantaventis.Trading.Modules.Conversion.Domain.Model;

namespace Quantaventis.Trading.Modules.Conversion.Infrastructure.Repositories
{

    internal interface ICurrencyPairConversionRuleRepository
    {


        Task<IEnumerable<IContractConversionRule>> GetByPortfolioIdAsync(byte portfolioId);
    }
    internal class CurrencyPairConversionRuleRepository  : ICurrencyPairConversionRuleRepository
    {
        private IInstrumentMappingDao InstrumentMappingDao { get; }
        private ICurrencyPairConversionRuleDao CurrencyPairConversionRuleDao { get; }
        public CurrencyPairConversionRuleRepository(ICurrencyPairConversionRuleDao CurrencyPairConversionRuleDao, IInstrumentMappingDao instrumentMappingDao) {
            this.CurrencyPairConversionRuleDao = CurrencyPairConversionRuleDao;
            this.InstrumentMappingDao = instrumentMappingDao;
        }
        public async Task<IEnumerable<IContractConversionRule>> GetByPortfolioIdAsync(byte portfolioId)
        {
            IEnumerable<Entities.InstrumentMapping> CurrencyPairToForwardMappings = await InstrumentMappingDao.GetByTypeAsync(InstrumentMappingType.CurrencyPairToForward.Mnemonic);
            IEnumerable<Entities.InstrumentMapping> CurrencyPairToInverseMappings = await InstrumentMappingDao.GetByTypeAsync(InstrumentMappingType.CurrencyPairToInverse.Mnemonic); ;
            InstrumentMapping CurrencyPairToForwardMapping = CurrencyPairToForwardMappings.Map(InstrumentMappingType.CurrencyPairToForward);
            InstrumentMapping CurrencyPairToInverseMapping = CurrencyPairToInverseMappings.Map(InstrumentMappingType.CurrencyPairToInverse);
            IEnumerable<Entities.CurrencyPairConversionRule> CurrencyPairConversionRules = await CurrencyPairConversionRuleDao.GetByPortfolioIdAsync(portfolioId);
            return CurrencyPairConversionRules.Select(x => new CurrencyPairConversionRule(portfolioId, CurrencyPairToInverseMapping, CurrencyPairToForwardMapping, x.ConvertToForward, x.InvertPair)).ToList(); 
        }
    }
}
