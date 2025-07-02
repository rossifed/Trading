namespace Quantaventis.Trading.Modules.Rolling.Domain.Model
{
    internal class ContractRollInfo
    {
        internal int GenericId { get; }
        internal int CurrentContractId { get; }
        internal int NextContractId { get; }
        internal bool IsRollingPeriod { get; }
        public ContractRollInfo(int genericId, 
            int currentContractId, 
            int nextContractId,
            bool isRollingPeriod)
        {
            GenericId = genericId;
            CurrentContractId = currentContractId;
            IsRollingPeriod = isRollingPeriod;          
            NextContractId = nextContractId;

        }
     
        public override bool Equals(object? obj)
        {
            return obj is ContractRollInfo info &&
                   GenericId == info.GenericId &&
                   CurrentContractId == info.CurrentContractId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(GenericId, CurrentContractId);
        }
    }
}
