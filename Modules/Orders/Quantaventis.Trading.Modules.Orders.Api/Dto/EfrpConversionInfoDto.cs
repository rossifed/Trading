using Quantaventis.Trading.Modules.Orders.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Api.Dto
{
    public class EfrpConversionInfoDto
    {
        public int InstrumentId { get; set; }
        public int BrokerId { get; set; }
        public bool IsEfrp { get; set; }



    }
}
