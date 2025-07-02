namespace Quantaventis.Trading.Modules.Rolling.Domain.Model
{
    internal class Position
    {
      internal  byte PortfolioId { get; }
      internal RollableContract Contract { get; }
      
      internal int Quantity { get; }

        public Position(byte portfolioId, RollableContract contract, int quantity)
        {
            PortfolioId = portfolioId;
            Contract = contract;
            Quantity = quantity;
        }



      internal  PositionRollover? GenerateRollover(IEnumerable<ContractRollInfo> contractRollInfos)
        {
            ContractRollInfo? contractRollInfo = contractRollInfos.SingleOrDefault(x => x.GenericId == Contract.GenericId && x.CurrentContractId == Contract.ContractId && x.IsRollingPeriod);
            if (contractRollInfo != null)
            {
                
                    RollableContract nextContract = new RollableContract(contractRollInfo.GenericId, contractRollInfo.NextContractId);
                    var rollDate = DateOnly.FromDateTime(DateTime.UtcNow);//TODO: to be extracted ina domain service
                    return new PositionRollover(PortfolioId, Contract, nextContract, -Quantity, Quantity, rollDate);
                
              

            }
            return null;
        }
    }
}
