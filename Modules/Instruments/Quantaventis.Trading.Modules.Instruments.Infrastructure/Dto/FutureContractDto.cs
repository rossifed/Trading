using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Dto
{
    public class FutureContractDto
    {
        public string Symbol { get; set; }
        public string Month { get; set; }

        public int Year { get; set; }

        public DateOnly LastTradeDate { get; set; }

        public DateOnly FirstNoticeDate { get; set; }
    }
}
