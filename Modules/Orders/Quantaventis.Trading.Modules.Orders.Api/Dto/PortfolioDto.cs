using Quantaventis.Trading.Modules.Orders.Domain.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Api.Dto
{
    public class PortfolioDto
    {
        public byte Id { get; set; }

        public string Mnemonic { get; set; }

        public string Name { get; set; }

        public string Currency { get; set; }
    }
}
