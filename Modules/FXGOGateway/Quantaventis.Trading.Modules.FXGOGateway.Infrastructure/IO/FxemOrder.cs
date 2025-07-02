using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.FXGOGateway.Infrastructure.IO
{
    internal class FxemOrder
    {

        public string Instrument { get; set; }

        public string CurrencyPair { get; set; }
        public string Side { get; set; }
        public string? Tenor { get; set; }
        public DateOnly ValueDate { get; set; }
        public long Amount { get; set; }
        public string Currency { get; set; }


        public long? FarAmount { get; set; }

        public string? FarCurrency { get; set; }

        public string Notes { get; set; }
        public string Account { get; set; }

        public byte PortfolioId { get; set; }
        public int? RebalancingId { get; set; }
        public string PositionSide { get; set; }





    }
}
