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
    internal interface IFutureConversionRuleRepository
    {


        Task<IEnumerable<IContractConversionRule>> GetByPortfolioIdAsync(byte portfolioId);
    }
    internal class FutureConversionRuleRepository : IFutureConversionRuleRepository
    {
        private IInstrumentMappingDao InstrumentMappingDao { get; }

        public FutureConversionRuleRepository(IInstrumentMappingDao instrumentMappingDao) {
            this.InstrumentMappingDao = instrumentMappingDao;
        }
        public async Task<IEnumerable<IContractConversionRule>> GetByPortfolioIdAsync(byte portfolioId)
        {
            IEnumerable<Entities.InstrumentMapping> gen2futEntities= await InstrumentMappingDao.GetByTypeAsync(InstrumentMappingType.GenericToFuture.Mnemonic);
            IEnumerable<Entities.InstrumentMapping> gen2fwdEntities = await InstrumentMappingDao.GetByTypeAsync(InstrumentMappingType.FutureToForward.Mnemonic);
            InstrumentMapping generic2FutureMapping = gen2futEntities.Map(InstrumentMappingType.GenericToFuture);
            InstrumentMapping genericToforwardMappings = gen2fwdEntities.Map(InstrumentMappingType.FutureToForward);
            return new List<IContractConversionRule>() { new FutureConversionRule(generic2FutureMapping, genericToforwardMappings) }; 
        }
    }
}
