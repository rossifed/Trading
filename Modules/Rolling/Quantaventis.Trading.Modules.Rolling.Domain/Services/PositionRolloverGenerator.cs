using Quantaventis.Trading.Modules.Rolling.Domain.Model;

namespace Quantaventis.Trading.Modules.Rolling.Domain.Services
{
    internal interface IPositionRolloverGenerator
    {
        IEnumerable<PositionRollover> GenerateRollovers(IEnumerable<Position> positions, IEnumerable<ContractRollInfo> contractRollInfos);
    }
    internal class PositionRolloverGenerator: IPositionRolloverGenerator
    {
        public PositionRolloverGenerator() { }
        public IEnumerable<PositionRollover> GenerateRollovers(IEnumerable<Position> positions, IEnumerable<ContractRollInfo> contractRollInfos)
        {
            List<PositionRollover> rollOrders = new List<PositionRollover>();
            foreach (var position in positions)
            {
                PositionRollover? rollOrder = position.GenerateRollover(contractRollInfos);
                if (rollOrder != null)
                {
                    rollOrders.Add(rollOrder);
                }
            }
            return rollOrders;
        }

    }
}
