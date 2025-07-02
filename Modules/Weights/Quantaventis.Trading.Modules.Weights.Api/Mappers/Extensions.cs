using Quantaventis.Trading.Modules.Weights.Api.Dto;
using Quantaventis.Trading.Modules.Weights.Api.Services;
using Quantaventis.Trading.Modules.Weights.Infrastructure.Entities;
using Quantaventis.Trading.Modules.Weights.Infrastructure.Files;

using Entities = Quantaventis.Trading.Modules.Weights.Infrastructure.Entities;

namespace Quantaventis.Trading.Modules.Weights.Api.Mappers
{
    internal static class Extensions
    {
        internal static IEnumerable<TargetWeightDto> Map(this IEnumerable<Entities.TargetWeight> entities)
       => entities.Select(x => x.Map());
        internal static TargetWeightDto Map(this Entities.TargetWeight entity)
       => new TargetWeightDto()
       {
           InstrumentId = entity.InstrumentId,
           Weight = (double)entity.Weight
       };
        internal static Instrument Map(this InstrumentDto dto)
            => new Instrument()
                {
                    InstrumentId = dto.Id,
                    Symbol = dto.Symbol
                };

       
        internal static Entities.TargetAllocation Map(this ModelWeightingFile modelWeightFile,byte portfolioId, IDictionary<string, Instrument> mapping)
        {
            IEnumerable<Entities.TargetWeight> targetWeights = modelWeightFile
               .ModelWeights.Where(x=> mapping.ContainsKey(x.Symbol))
               .Select(x => new Entities.TargetWeight()
               {
                   InstrumentId = mapping[x.Symbol].InstrumentId,
                   Weight = (decimal)x.Weight
               });
            Entities.TargetAllocation entity = new Entities.TargetAllocation()
            {
                PortfolioId = portfolioId,
                GeneratedOn = modelWeightFile.ModifiedOn,
            };
            targetWeights
                .ToList()
                .ForEach(x => entity.TargetWeights
                .Add(x));
            return entity;
        }
    }
}
