using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities = Quantaventis.Trading.Modules.Conversion.Infrastructure.Entities;
using Quantaventis.Trading.Modules.Conversion.Infrastructure.Exceptions;
using DomainModel = Quantaventis.Trading.Modules.Conversion.Domain.Model;
using System.Security.Cryptography.X509Certificates;

namespace Quantaventis.Trading.Modules.Conversion.Infrastructure.Mapping
{
    internal static class Extensions
    {
      
        internal static DomainModel.InstrumentMappingType Map(this Entities.InstrumentMappingType entity)
         => new DomainModel.InstrumentMappingType(entity.InstrumentMappingTypeId, entity.Mnemonic);


        internal static IEnumerable<DomainModel.Instrument> Map(this IEnumerable<Entities.Instrument> entities)
             => entities.Select(x=>x.Map());
        internal static DomainModel.Instrument Map(this Entities.Instrument entity)
         => new DomainModel.Instrument(entity.InstrumentId, entity.Symbol, entity.InstrumentType);


        internal static IDictionary<DomainModel.InstrumentMappingType, DomainModel.InstrumentMapping> Map(this IEnumerable<Entities.InstrumentMapping> instrumentMappings)
        => instrumentMappings.GroupBy(x => x.InstrumentMappingType.Map()).ToDictionary(x => x.Key, x =>new DomainModel.InstrumentMapping(x.Key, x.ToDictionary(y => y.FromInstrument.Map(), y => y.ToInstrument.Map())));


        internal static DomainModel.InstrumentMapping Map(this IEnumerable<Entities.InstrumentMapping> instrumentMappings, Domain.Model.InstrumentMappingType mappingType)
        {
            IDictionary< DomainModel.InstrumentMappingType, DomainModel.InstrumentMapping> mappings = instrumentMappings.Map();
            if (mappings.ContainsKey(mappingType))
                return mappings[mappingType];
                return DomainModel.InstrumentMapping.Empty(mappingType);
            }


    }
}
