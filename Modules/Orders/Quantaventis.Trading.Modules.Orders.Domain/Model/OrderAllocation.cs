using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Domain.Model
{
    internal class OrderAllocation
    {
  
        internal Quantity Quantity { get; }
        internal Portfolio Portfolio { get; }

        internal PositionSide PositionSide { get; }
        internal TradingAccount TradingAccount { get; }
        internal OrderAllocation(Portfolio portfolio, 
            TradingAccount tradingAccount, 
            Quantity quantity, 
            PositionSide positionSide)
        {
            this.Portfolio = portfolio;
            this.TradingAccount = tradingAccount;
            this.Quantity = quantity;
            this.PositionSide = positionSide;
        }

        public override string? ToString()
        {
            return $"{Portfolio} ${PositionSide} {Quantity} {TradingAccount}";
        }
    }
}
