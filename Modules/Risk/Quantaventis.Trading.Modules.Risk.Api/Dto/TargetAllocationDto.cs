using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Risk.Api.Dto
{
    internal class TargetAllocationDto
    {
        public int TargetAllocationId { get; set; }

        public byte PortfolioId { get; set; }

        public DateTime GeneratedOn { get; set; }
        public IEnumerable<TargetWeightDto> TargetWeights { get; set; }    
    }
}
