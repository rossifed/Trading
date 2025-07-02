using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Conversion.Api.Dto
{
    public class CfdDto :InstrumentDto
    {
 
        public InstrumentDto Underlying { get; set; }

     
    }
}
