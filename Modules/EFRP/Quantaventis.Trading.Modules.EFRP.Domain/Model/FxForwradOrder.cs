using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EFRP.Domain.Model
{
    internal class FxForwardOrder 
    {
        internal string BaseCurrency => FxForward.BaseCurrency;
        internal string QuoteCurrency => FxForward.QuoteCurrency;

        internal DateOnly ValueDate => FxForward.MaturityDate;
        internal FxForward FxForward { get; }
        internal long Quantity { get; }

        internal string Symbol => FxForward.Symbol; 

        internal FxForwardOrder(FxForward fxForward, long quantity)
         
        {
            this.FxForward = fxForward;
            this.Quantity = quantity;
        }
    


     

    }
}
