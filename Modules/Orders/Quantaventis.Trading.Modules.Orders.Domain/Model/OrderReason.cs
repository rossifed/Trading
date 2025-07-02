namespace Quantaventis.Trading.Modules.Orders.Domain.Model
{
    internal struct OrderReason
    {
    
        internal string Mnemonic { get; }
        private OrderReason(string mnemonic)
        {
 
            this.Mnemonic = mnemonic;
        }
        internal static readonly OrderReason Rebalancing = new OrderReason("REBAL");

        internal static readonly OrderReason Rollover = new OrderReason("ROLL");

        internal static OrderReason FromMnemonic(string mnemonic) {
            IEnumerable<OrderReason> orderSides = new List<OrderReason>() { Rebalancing, Rollover };
            OrderReason? foundSide = orderSides.FirstOrDefault(o => o.Mnemonic==mnemonic.Trim().ToUpper());
            if (foundSide == null)
            throw new InvalidOperationException($"Order Reason can't be crated from mnemmonic {mnemonic}");
            return foundSide.Value;
        }
        

       
        public override string? ToString()
        {
            return Mnemonic;
        }

        public override bool Equals(object? obj)
        {
            return obj is OrderReason reason &&
                   Mnemonic == reason.Mnemonic;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Mnemonic);
        }
    }
}
