using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Dto
{
    internal class BLPAPIResponseDto
    {
       public string Symbol { get; set; }
        public IDictionary<string, object> ReferenceData { get; set; }

        public IEnumerable<IDictionary<string, object>> BulkData { get; set; }

    }
}
