using Quantaventis.Trading.Modules.Rolling.Api.Dto;
using Entities = Quantaventis.Trading.Modules.Rolling.Infrastructure.Entities;
using Quantaventis.Trading.Modules.Rolling.Domain.Model;
namespace Quantaventis.Trading.Modules.Rolling.Api.Mappers
{
    internal static class Extensions
    {
    
        internal static IEnumerable<PositionRolloverDto> Map(this IEnumerable<PositionRollover> dtos)
        {
            return dtos.Select(x => x.Map());
        }
        private static PositionRolloverDto Map(this PositionRollover rollOrder)
        {

            return new PositionRolloverDto()
            {
                PortfolioId = rollOrder.PortfolioId,
                ExpiringContractId = rollOrder.ExpiringContract.ContractId,
                ExpiringQuantity = rollOrder.ExpiringQuantity,
                NextContractId = rollOrder.NextContract.ContractId,
                NextQuantity = rollOrder.NextQuantity,
                RollDate = rollOrder.RollDate,
            };

        }
    }
}
