using Quantaventis.Trading.Modules.EFRP.Domain.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EFRP.Domain.Model
{
    internal class EfrpConversionInfo
    {
        internal IEfrpCandidate EfrpCandidate { get; }
        internal bool IsConversionEnabled { get; }

        internal bool IsEfrp => FutureContract != null && FxForward != null && IsConversionEnabled;
        internal FutureContract? FutureContract { get; }
        internal FxForward? FxForward { get; }

        internal EfrpConversionInfo(IEfrpCandidate efrpCandidate) : this (efrpCandidate, null, null,false)
        {

        }
        internal EfrpConversionInfo(IEfrpCandidate efrpCandidate, 
           
            FutureContract? futureContract,
            FxForward? fxForward,
            bool isConversionEnabled
            )
        {
            EfrpCandidate = efrpCandidate;
            FutureContract = futureContract;
            FxForward = fxForward;
            IsConversionEnabled = isConversionEnabled;
        }
        private FutureContract GetFutureContract()
        {
            if (IsEfrp && FutureContract != null)
            {
                return FutureContract;
            }
            throw new InvalidOperationException("FxForward is not available");
        }
        private FxForward GetFxForward()
        {
            if (IsEfrp && FxForward != null)
            {
                return FxForward;
            }
            throw new InvalidOperationException("FxForward is not available");
        }

        public bool TryConvertToEfrpOrder(Order order, out EfrpOrder? efrpOrder)
        {
           
           
            if (IsEfrp)
            {
                FxForward fxForward = GetFxForward();
                FutureContract futureContract = GetFutureContract();
                FutureContractOrder futureContractOrder = order.ToFutureContractOrder(futureContract);
                long fwdQuantity =Convert.ToInt64(order.Quantity *futureContract.ContractSize);
                FxForwardOrder fxForwardOrder = new FxForwardOrder(fxForward, fwdQuantity);
                efrpOrder = new EfrpOrder(order.ToFutureContractOrder(futureContract), fxForwardOrder);
                return true;
            }
            efrpOrder= null;
            return false;
        }
    }
}
