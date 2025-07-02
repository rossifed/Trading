using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Risk.Api.Dto
{
    public class TargetAllocationBreachDto
    {
        public int TargetAllocationId { get; set; }
        public int TargetAllocationCheckId { get; set; }
        public byte PortfolioId { get; set; }


    }
}
