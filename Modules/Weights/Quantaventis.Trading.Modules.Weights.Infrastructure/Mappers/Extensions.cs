namespace Quantaventis.Trading.Modules.Weights.Infrastructure.Mapping
{
    internal static class Extensions
    {
        //internal static DomainModel.Instrument Map(this Entities.Instrument entity)
        //    => new Domain.Model.Instrument(entity.InstrumentId, entity.Symbol, entity.InstrumentType);


        //internal static IEnumerable<DomainModel.Instrument> Map(this IEnumerable<Entities.Instrument> entities)
        //     => entities.Select(x => x.Map());

        //internal static IDictionary<string, DomainModel.InstrumentMapping> Map(this IEnumerable<Entities.InstrumentMapping> instrumentMappings)
        //=> instrumentMappings.GroupBy(x => x.InstrumentMappingType.Mnemonic).ToDictionary(x => x.Key, x =>new DomainModel.InstrumentMapping(x.Key, x.ToDictionary(y => y.SourceInstrument.Map(), y => y.TargetInstrument.Map())));

        //internal static DomainModel.InstrumentMapping Map(this IEnumerable<Entities.InstrumentMapping> instrumentMappings, string mappingType)
        //    => instrumentMappings.Map()[mappingType];
        //internal static IEnumerable<DomainModel.ModelWeight> Map(this IEnumerable<Entities.ModelWeight> entities)
        //    => entities.Select(x => x.Map());

    //    internal static DomainModel.ModelWeight Map(this Entities.ModelWeight entity)
    //      => new Domain.Model.ModelWeight((byte)entity.ModelWeighting.PortfolioId, entity.Instrument.Map(),
    //             Convert.ToDouble(entity.Weight),
    //             entity.ModelWeighting.GeneratedOn
    //             );

    //    internal static DomainModel.ModelWeighting Map(this Entities.ModelWeighting entity)
    //=> new Domain.Model.ModelWeighting(entity.ModelWeightingId, 
    //    (byte)entity.PortfolioId,
    //    entity.GeneratedOn, 
    //    entity.ModelWeights.Map() 
    //       );

    }
}
