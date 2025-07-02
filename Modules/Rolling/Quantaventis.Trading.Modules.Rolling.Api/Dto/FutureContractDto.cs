using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Rolling.Api.Dto
{
    public class FutureContractDto : InstrumentDto
    {

        
        public DateOnly FirstNoticeDate { get; set; }
        public DateOnly LastTradeDate { get; set; }

        public string Month { get; set; }
        public int Year { get; set; }
    }
}
