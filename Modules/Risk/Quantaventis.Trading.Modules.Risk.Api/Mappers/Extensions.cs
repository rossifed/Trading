using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities = Quantaventis.Trading.Modules.Risk.Infrastructure.Entities;
using Quantaventis.Trading.Modules.Risk.Domain.Model;
using Quantaventis.Trading.Modules.Risk.Api.Dto;
namespace Quantaventis.Trading.Modules.Risk.Api.Mappers
{
    internal static class Extensions
    {
        internal static IEnumerable<Entities.Portfolio> Map(this IEnumerable<PortfolioDto> dtos)
             => dtos.Select(x => x.Map());
        internal static Entities.Portfolio Map(this PortfolioDto dto)
        {
            return new Entities.Portfolio()
            {
                PortfolioId = dto.Id,
                Mnemonic = dto.Mnemonic,
                Currency = dto.Currency,
                Name = dto.Name,


            };
        }
        internal static Entities.Instrument Map(this InstrumentDto dto)
        {
            return new Entities.Instrument()
            {
                InstrumentId = dto.Id,
                Symbol = dto.Symbol,
                Currency = dto.Currency,
                InstrumentType = dto.InstrumentType,


            };
        }
        internal static TargetWeight Map(this TargetWeightDto dto)
            => new TargetWeight(new Instrument(dto.InstrumentId), dto.Weight);

        internal static IEnumerable<TargetWeight> Map(this IEnumerable<TargetWeightDto> dtos)
             => dtos.Select(x => x.Map());
    }

}
