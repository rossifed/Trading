using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Conversion.Domain.Model;
namespace Quantaventis.Trading.Modules.Conversion.Domain.Repositories
{
    internal interface IInstrumentMappingRepository
    {

        Task<InstrumentMapping> GetByTypeAsync(InstrumentMappingType mappingType);
        Task<IDictionary<InstrumentMappingType, InstrumentMapping>> GetAllAsync();
    }
}
