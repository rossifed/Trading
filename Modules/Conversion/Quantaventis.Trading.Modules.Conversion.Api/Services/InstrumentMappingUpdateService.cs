using Quantaventis.Trading.Modules.Conversion.Domain.Model;
using Quantaventis.Trading.Modules.Conversion.Infrastructure.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities = Quantaventis.Trading.Modules.Conversion.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Conversion.Api.Services
{
    internal interface IInstrumentMappingUpdateService {
        Task CreateOrUpdateAsync(int fromInstrumentId, int toInstrumentId, InstrumentMappingType mappingType);
    }
    internal class InstrumentMappingUpdateService : IInstrumentMappingUpdateService
    {
        private IInstrumentMappingDao InstrumentMappingDao;

        public InstrumentMappingUpdateService(IInstrumentMappingDao instrumentMappingDao)
        {
            InstrumentMappingDao = instrumentMappingDao;
        }
  
        public async Task CreateOrUpdateAsync(int fromInstrumentId, int toInstrumentId, InstrumentMappingType mappingType) {
            Entities.InstrumentMapping? entity = await InstrumentMappingDao.GetByFromInstrumentAndMappingTypeAsync(fromInstrumentId, mappingType.Id);
            if (entity != null)
            {
                entity.ToInstrumentId = toInstrumentId;
                await InstrumentMappingDao.UpdateAsync(entity);
            }
            else
            {
                entity = new Entities.InstrumentMapping()
                {
                    FromInstrumentId = fromInstrumentId,
                    ToInstrumentId = toInstrumentId,
                    InstrumentMappingTypeId =  mappingType.Id,
                };

                await InstrumentMappingDao.CreateAsync(entity);
            }

        }
    }
}
