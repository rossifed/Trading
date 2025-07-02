using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Rolling.Domain.Model
{
    internal class PositionRollover
    {
        internal byte PortfolioId { get; }
        internal RollableContract ExpiringContract { get; }

        internal RollableContract NextContract { get; }
        internal int ExpiringQuantity { get; }

        internal int NextQuantity { get; }
        internal DateOnly RollDate { get; }
        public PositionRollover(byte portfolioId,
            RollableContract expiringContract,
            RollableContract nextContract, 
            int expiringQuantity,
            int nextQuantity,
            DateOnly rollDate)
        {
            PortfolioId = portfolioId;
            ExpiringContract = expiringContract;
            NextContract = nextContract;
            ExpiringQuantity = expiringQuantity;
            NextQuantity = nextQuantity;
            RollDate = rollDate;
        }
    }
}
