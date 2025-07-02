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

    internal interface IEquityConversionRuleRepository
    {


        Task<IEnumerable<IContractConversionRule>> GetByPortfolioIdAsync(byte portfolioId);
    }
    internal class EquityConversionRuleRepository : IEquityConversionRuleRepository
    {
        private IInstrumentMappingDao InstrumentMappingDao { get; }
        private IEquityConversionRuleDao EquityConversionRuleDao { get; }
        public EquityConversionRuleRepository(IEquityConversionRuleDao equityConversionRuleDao, IInstrumentMappingDao instrumentMappingDao) {
            this.EquityConversionRuleDao = equityConversionRuleDao;
            this.InstrumentMappingDao = instrumentMappingDao;
        }
        public async Task<IEnumerable<IContractConversionRule>> GetByPortfolioIdAsync(byte portfolioId)
        {
            IEnumerable<Entities.InstrumentMapping> equToCfdMappings = await InstrumentMappingDao.GetByTypeAsync(InstrumentMappingType.EquityToCfd.Mnemonic);
            InstrumentMapping equToCfdMapping = equToCfdMappings.Map(InstrumentMappingType.EquityToCfd);

            IEnumerable<Entities.EquityConversionRule> equityConversionRules = await EquityConversionRuleDao.GetByPortfolioIdAsync(portfolioId);
            return equityConversionRules.Select(x => new EquityConversionRule(portfolioId,x.ConvertToCfd, equToCfdMapping)).ToList(); 
        }
    }
}
