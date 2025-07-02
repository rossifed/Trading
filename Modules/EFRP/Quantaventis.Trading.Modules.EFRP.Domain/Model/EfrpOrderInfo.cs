using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EFRP.Domain.Model
{
    internal class EfrpOrderInfo
    {


        internal FutureContractOrder FutureContractOrder { get; }
     
        internal FxForwardOrder FxForwardOrder { get; }

    
        public EfrpOrderInfo(FutureContractOrder futureContractOrder, FxForwardOrder fxForwardOrder)
        {

            FutureContractOrder = futureContractOrder;
            FxForwardOrder = fxForwardOrder;
        }
    }
}
