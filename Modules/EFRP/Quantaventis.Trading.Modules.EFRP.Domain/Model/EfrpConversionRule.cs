using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EFRP.Domain.Model
{
    internal class EfrpConversionRule
    {
        internal Broker Broker { get; }
        internal CurrencyPair CurrencyPair { get; }
        internal GenericFuture GenericFuture { get; }
        internal string CmeClearPortTicker { get; }
        internal bool IsActive { get; }
        internal Currency BaseCurrency => CurrencyPair.BaseCurrency;

        internal Currency QuoteCurrency => CurrencyPair.QuoteCurrency;
        public EfrpConversionRule(CurrencyPair currencyPair,
            Broker broker,
            GenericFuture genericFuture,
            string cmeClearPortTicker,
            bool isActive)
        {
            CurrencyPair = currencyPair;
            Broker = broker;
            GenericFuture = genericFuture;
            CmeClearPortTicker = cmeClearPortTicker;
            IsActive = isActive;
        }

    
        internal bool ApplyTo(FutureContract futureContract)
         => futureContract.GenericFuture.Equals(GenericFuture);
        internal bool ApplyTo(FutureContractOrder futureContractOrder)
        => ApplyTo(futureContractOrder.FutureContract);

        internal FxForward GetFxForward(DateOnly maturity)
            => new FxForward(CurrencyPair, maturity);
   
   
    }
}
