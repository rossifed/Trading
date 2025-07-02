using Quantaventis.Trading.Modules.Rolling.Domain.Model;


namespace Quantaventis.Trading.Modules.Rolling.Infrastructure.Mappers
{
    internal static class Extensions
    {
    
        internal static IEnumerable<Position> Map(this IEnumerable<Entities.Position> entities)
        {
            return entities.Select(x => x.Map());
        }
        internal static Position Map(this Entities.Position entity)
        {
            return new Position(
                entity.PortfolioId,
                new RollableContract(entity.GenericId, entity.ContractId),
                entity.Quantity
                );
        }

        internal static IEnumerable<ContractRollInfo> Map(this IEnumerable<Entities.VwFutureContractRollInfo> entities)
        {
            return entities.Select(x => x.Map());
        }
        internal static ContractRollInfo Map(this Entities.VwFutureContractRollInfo entity)
        {
            return new ContractRollInfo(
                entity.GenericFutureId,
                entity.CurrentContractId,
                entity.NextContractId.Value,
                entity.IsRollingPeriod ==1
                );
        }

        internal static IEnumerable<ContractRollInfo> Map(this IEnumerable<Entities.VwFxForwardRollInfo> entities)
        {
            return entities.Select(x => x.Map());
        }
        internal static ContractRollInfo Map(this Entities.VwFxForwardRollInfo entity)
        {
            return new ContractRollInfo(
                entity.CurrencyPairId,
                entity.CurrentContractId,
                entity.NextContractId.Value,
                entity.IsRollingPeriod ==1
                );
        }
    }
}
