using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Weights.Domain.Model;
namespace Quantaventis.Trading.Modules.Weights.Domain.Repositories
{
    internal interface IInstrumentMappingRepository
    {

        Task<InstrumentMapping> GetByTypeAsync(string mappingType);
        Task<IDictionary<string, InstrumentMapping>> GetAllAsync();
    }
}
