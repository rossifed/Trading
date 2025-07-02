using Quantaventis.Trading.Modules.Conversion.Domain.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Conversion.Api.Dto
{
    public class PortfolioDto
    {
        public byte Id { get; set; }

        public string Mnemonic { get; set; }

        public string Name { get; set; }

        public string Currency { get; set; }
    }
}
