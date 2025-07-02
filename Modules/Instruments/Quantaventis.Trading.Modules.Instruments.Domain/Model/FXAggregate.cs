using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Instruments.Domain.Model
{
    internal class FXAggregate
    {

        internal CurrencyPair CurrencyPair { get; }

        internal CurrencyPair InverseCurrencyPair { get; }

        internal IEnumerable<FxForward> FxForwards { get; }
        internal IEnumerable<FxForward> InverseFxForwards { get; }
        public FXAggregate(CurrencyPair CurrencyPair, CurrencyPair inverseCurrencyPair, IEnumerable<FxForward> FxForwards, IEnumerable<FxForward> inverseFxForwards)
        {
            this.CurrencyPair = CurrencyPair;
            this.InverseCurrencyPair= inverseCurrencyPair;
            this.FxForwards= FxForwards;
            this.InverseFxForwards= inverseFxForwards;
        }
    }
}
