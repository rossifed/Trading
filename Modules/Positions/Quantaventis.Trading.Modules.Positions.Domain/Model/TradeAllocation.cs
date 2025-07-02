using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Positions.Domain.Model
{
    internal class TradeAllocation
    {

        internal int Id { get; }
        internal byte PortfolioId { get; }
        internal int Quantity { get; }
        internal int TradeId { get; }
        internal decimal NominalQuantity { get; }
        internal int InstrumentId => InvestedInstrument.InstrumentId;
        internal Money GrossAveragePriceLocal { get; }

        internal Money GrossAveragePriceBase { get; }
        internal Money NetAveragePriceLocal { get; }

        internal Money NetAveragePriceBase { get; }
        internal FxRate LocalToBaseFxRate { get; }

        internal Money GrossPrincipalLocal { get; }

        internal Money GrossPrincipalBase { get; }

        internal Money NetPrincipalLocal { get; }

        internal Money NetPrincipalBase { get; }

        internal Money GrossTradeValueLocal { get; }

        internal Money GrossTradeValueBase { get; }

        internal Money NetTradeValueLocal { get; }

        internal Money NetTradeValueBase { get; }

        internal string TradeInstrumentType { get; }

        internal bool IsSwap =>InvestedInstrument.IsSwap;
        internal Money CommissionAmountLocal { get; }

        internal Money CommissionAmountBase { get; }
        internal Currency LocalCurrency { get; }

        internal Currency BaseCurrency { get; }

        internal DateOnly TradeDate { get; }

        internal InvestedInstrument InvestedInstrument { get; }
        public TradeAllocation(int id,
            int tradeId,
       byte portfolioId,
       int quantity,
       decimal nominalQuantity,
       InvestedInstrument investedInstrument,
       
       DateOnly tradeDate,
       decimal grossAveragePriceLocal,
       decimal grossAveragePriceBase,
       decimal netAveragePriceLocal,
       decimal netAveragePriceBase,
       decimal grossTradeValueLocal,
       decimal grossTradeValueBase,
       decimal netTradeValueLocal,
       decimal netTradeValueBase,
         decimal grossPrincipalLocal,
       decimal grossPrincipalBase,
       decimal netPrincipalLocal,
       decimal netPrincipalBase,
       decimal commissionAmountLocal,
       decimal commissionAmountBase,
       Currency localCurrency,
       Currency baseCurrency,
       decimal localToBaseFxRate
       ) : this(id,
          tradeId,
          portfolioId,
          quantity,
          nominalQuantity,
          investedInstrument,
          tradeDate,
          new Money(grossAveragePriceLocal, localCurrency),
          new Money(grossAveragePriceBase, baseCurrency),
          new Money(netAveragePriceLocal, localCurrency),
          new Money(netAveragePriceBase, baseCurrency),
          new Money(grossTradeValueLocal, localCurrency),
          new Money(grossTradeValueBase, baseCurrency),
          new Money(netTradeValueLocal, localCurrency),
          new Money(netTradeValueBase, baseCurrency),
          new Money(grossPrincipalLocal, localCurrency),
          new Money(grossPrincipalBase, baseCurrency),
          new Money(netPrincipalLocal, localCurrency),
          new Money(netPrincipalBase, baseCurrency),
          new Money(commissionAmountLocal, localCurrency),
          new Money(commissionAmountBase, baseCurrency),
      new FxRate(localToBaseFxRate, localCurrency, baseCurrency))
        { }

        public TradeAllocation(int id,
                int tradeid,
                byte portfolioId,
                int quantity,
                decimal nominalQuantity,
                 InvestedInstrument investedInstrument,
                DateOnly tradeDate,
                Money grossAveragePriceLocal,
                Money grossAveragePriceBase,
                Money netAveragePriceLocal,
                Money netAveragePriceBase,
                Money grossTradeValueLocal,
                Money grossTradeValueBase,
                Money netTradeValueLocal,
                Money netTradeValueBase,
                Money grossPrincipalLocal,
                Money grossPrincipalBase,
                Money netPrincipalLocal,
                Money netPrincipalBase,
                Money commissionAmountLocal,
                Money commissionAmountBase,
                FxRate localToBaseFxRate
                )
        {
            Id = id;
            TradeId = tradeid;
            PortfolioId = portfolioId;
            Quantity = quantity;
            NominalQuantity = nominalQuantity;
            InvestedInstrument = investedInstrument;
            GrossAveragePriceLocal = grossAveragePriceLocal;
            GrossAveragePriceBase = grossAveragePriceBase;
            LocalToBaseFxRate = localToBaseFxRate;
            GrossTradeValueLocal = grossTradeValueLocal;
            GrossTradeValueBase = grossTradeValueBase;
            NetTradeValueLocal = netTradeValueLocal;
            NetTradeValueBase = netTradeValueBase;
           
            GrossPrincipalLocal = grossPrincipalLocal;
            GrossPrincipalBase = grossPrincipalBase;
            NetPrincipalLocal = netPrincipalLocal;
            NetPrincipalBase = netPrincipalBase;
            NetAveragePriceBase = netAveragePriceBase;
            NetAveragePriceLocal = netAveragePriceLocal;
         
            CommissionAmountLocal = commissionAmountLocal;
            CommissionAmountBase = commissionAmountBase;
            LocalCurrency = LocalToBaseFxRate.BaseCurrency;
            BaseCurrency = LocalToBaseFxRate.QuoteCurrency;
            TradeDate = tradeDate;
        }
    }
}
