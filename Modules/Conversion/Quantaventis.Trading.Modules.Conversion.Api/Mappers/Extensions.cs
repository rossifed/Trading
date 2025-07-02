using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Shared.Abstractions.Mapping;
using DomainModel = Quantaventis.Trading.Modules.Conversion.Domain.Model;
using Entities = Quantaventis.Trading.Modules.Conversion.Infrastructure.Entities;

using Quantaventis.Trading.Modules.Conversion.Api.Dto;
using Quantaventis.Trading.Modules.Conversion.Domain.Model;
using Quantaventis.Trading.Modules.Conversion.Domain.Repositories;
using Quantaventis.Trading.Modules.Conversion.Infrastructure.Dao;

namespace Quantaventis.Trading.Modules.Conversion.Api.Mappers
{
    internal static class Extensions
    {

        internal static IEnumerable<TargetWeight> Map(this IEnumerable<TargetWeightDto> dtos, byte portfolioId, IEnumerable<Instrument> instruments)
             => dtos.Map(portfolioId, instruments.ToDictionary(x => x.Id));
        internal static IEnumerable<TargetWeight> Map(this IEnumerable<TargetWeightDto> dtos, byte portfolioId, IDictionary<InstrumentId, Instrument> instruments)
        => dtos.Select(x => x.Map(portfolioId, instruments));



        internal static TargetWeight Map(this TargetWeightDto dto, byte portfolioId, IDictionary<InstrumentId, Instrument> instruments)
        {
            if (instruments.ContainsKey(dto.InstrumentId))
                return new TargetWeight(portfolioId, instruments[dto.InstrumentId], dto.Weight);
            throw new InvalidOperationException($"TargetWeight can't be mapped. The Instrument {dto.InstrumentId} was not found");
        }


        internal static TargetWeightConversionDto ToDto(this DomainModel.TargetWeightConversion targetWeightConversion)
            => new TargetWeightConversionDto()
            {

                FromInstrumentId = targetWeightConversion.FromInstrumentId,
                FromWeight = (double)targetWeightConversion.FromWeight,
                ToInstrumentId = targetWeightConversion.ToInstrumentId,
                ToWeight = (double)targetWeightConversion.ToWeight
            };
        internal static IEnumerable<TargetWeightConversionDto> ToDtos(this IEnumerable<DomainModel.TargetWeightConversion> targetWeightConversions)
           => targetWeightConversions.Select(x => x.ToDto());

        internal static IEnumerable<TargetWeightDto> Map(this IEnumerable<DomainModel.TargetWeightConversion> targetWeightConversions)
            => targetWeightConversions.Select(x => x.Map());
        internal static TargetWeightDto Map(this DomainModel.TargetWeightConversion targetWeightConversion)
          => new TargetWeightDto()
          {

              InstrumentId = targetWeightConversion.ToInstrumentId,
              Weight = (double)targetWeightConversion.ToWeight
          };
        internal static Entities.Instrument Map(this InstrumentDto dto)
         => new Entities.Instrument()
         {
             InstrumentId = dto.Id,
             Symbol = dto.Symbol,
             InstrumentType = dto.InstrumentType
         };

        internal static IEnumerable<Entities.Portfolio> Map(this IEnumerable<PortfolioDto> dtos)
         => dtos.Select(x => x.Map());
        internal static Entities.Portfolio Map(this PortfolioDto dto)
       => new Entities.Portfolio()
       {
           PortfolioId = dto.Id,
           Mnemonic = dto.Mnemonic,
           Name = dto.Name,

       };
    }
}
