using Quantaventis.Trading.Modules.Execution.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Quantaventis.Trading.Modules.Execution.Domain.Model
{
    internal class EmsxTrade
    {
        private EmsxOrder? EmsxOrder { get; }
        private EmsxFillAggregate EmsxFillAggregate { get; }

        internal string Symbol => YellowKey == "Equity" ? $"{Ticker} {Exchange} {YellowKey}" : $"{Ticker} {YellowKey}";
        internal IEnumerable<EmsxFill> EmsxFills => EmsxFillAggregate.EmsxFills;

        internal int EmsxOrderId => EmsxFillAggregate.EmsxOrderId;

        internal string? Account => EmsxFillAggregate.Account;
        internal int OrderQuantity => EmsxFillAggregate.OrderQuantity;
        internal string? AssetClass => EmsxFillAggregate.AssetClass;
        internal int? BasketId => EmsxFillAggregate.BasketId;
        internal string? BbgId => EmsxFillAggregate.BbgId;
        internal string? BlockId => EmsxFillAggregate.BlockId;
        internal string? Broker => EmsxFillAggregate.Broker;
        internal string? ClearingAccount => EmsxFillAggregate.ClearingAccount;
        internal string? ClearingFirm => EmsxFillAggregate.ClearingFirm;
        internal DateOnly? ContractExpDate => EmsxFillAggregate.ContractExpDate;
        internal string Currency => EmsxFillAggregate.Currency;
        internal string? Cusip => EmsxFillAggregate.Cusip;

        internal string Exchange => EmsxFillAggregate.Exchange;

        internal int FilledQuantity => EmsxFillAggregate.FilledQuantity;
        internal string? InvestorId => EmsxFillAggregate.InvestorId;
        internal bool IsCFD => EmsxFillAggregate.IsCFD;
        internal string? Isin => EmsxFillAggregate.Isin;

        internal decimal? LimitPrice => EmsxFillAggregate.LimitPrice;

        internal string? LocalExchangeSymbol => EmsxFillAggregate.LocalExchangeSymbol;

        internal string? OrderExecutionInstruction => EmsxFillAggregate.OrderExecutionInstruction;
        internal string? OrderHandlingInstruction => EmsxFillAggregate.OrderHandlingInstruction;

        internal string? OrderInstruction => EmsxFillAggregate.OrderInstruction;
        internal string? OrderOrigin => EmsxFillAggregate.OrderOrigin;
        internal string? OrderReferenceId => EmsxFillAggregate.OrderReferenceId;
        internal int? OriginatingTraderUUId => EmsxFillAggregate.OriginatingTraderUUId;



        internal string? SecurityName => EmsxFillAggregate.SecurityName;
        internal string? Sedol => EmsxFillAggregate.Sedol;
        internal DateOnly? SettlementDate => EmsxFillAggregate.SettlementDate;
        internal string Side => EmsxFillAggregate.Side;
        internal decimal? StopPrice => EmsxFillAggregate.StopPrice;
        internal string? StrategyType => EmsxFillAggregate.StrategyType;
        internal string Ticker => EmsxFillAggregate.Ticker;
        internal string? Tif => EmsxFillAggregate.Tif;
        internal string? TraderName => EmsxFillAggregate.TraderName;
        internal int? TraderUUId => EmsxFillAggregate.TraderUUId;
        internal string? OrderType => EmsxFillAggregate.OrderType;
        internal decimal? UserCommissionAmount => EmsxFillAggregate.UserCommissionAmount;
        internal decimal? UserCommissionRate => EmsxFillAggregate.UserCommissionRate;
        internal decimal? UserFees => EmsxFillAggregate.UserFees;
        internal decimal? UserNetMoney => EmsxFillAggregate.UserNetMoney;
        internal string YellowKey => EmsxFillAggregate.YellowKey;
        public DateTime FirstFillDateTimeUtc => EmsxFillAggregate.FirstFillDateTimeUtc;
        public DateTime LastFillDateTimeUtc => EmsxFillAggregate.LastFillDateTimeUtc;

        public int NumberOfFills => EmsxFillAggregate.NumberOfFills;
        public decimal AvgPrice => EmsxFillAggregate.AvgPrice;
        public decimal MaxFillPrice => EmsxFillAggregate.MaxFillPrice;
        public decimal MinFillPrice => EmsxFillAggregate.MinFillPrice;


        public EmsxTrade(EmsxOrder? emsxOrder, EmsxFillAggregate emsxFillAggregate)
        {
            EmsxOrder = emsxOrder;
            EmsxFillAggregate = emsxFillAggregate;
            if (emsxOrder != null && emsxOrder.EmsxOrderId != emsxFillAggregate.EmsxOrderId)
                throw new InvalidOperationException($"The id of the EmsxOrder {emsxOrder.EmsxOrderId} don't match the fills order id {emsxFillAggregate.EmsxOrderId}");
        }

        public EmsxTrade(EmsxOrder? emsxOrder, IEnumerable<EmsxFill> emsxFills)
            : this(emsxOrder, new EmsxFillAggregate(emsxFills))
        {

        }



        internal void Validate()
        {



            if (EmsxOrder != null && (EmsxOrder.IsFilled || EmsxOrder.IsPartiallyFilled))
            {
                if (FilledQuantity != EmsxOrder.Filled)
                    throw new InvalidOperationException($"The  filled quantity of the EmsxOrder {EmsxOrder.EmsxOrderId} doesn't match the order quantity of the fills.{EmsxOrder.Filled} <> {FilledQuantity}");
                if (EmsxOrder.EmsxOrderId != EmsxOrderId)
                    throw new InvalidOperationException($"The EmsxOrderId {EmsxOrder.EmsxOrderId} doesn't match the EmsxOrderId of the fills {EmsxOrderId}");
                if (EmsxOrder.Amount != OrderQuantity)
                    throw new InvalidOperationException($"The  amouunt of the EmsxOrder {EmsxOrder.EmsxOrderId} doesn't match the order quantity of the fills. {EmsxOrder.Amount} <> {OrderQuantity}");
                if (EmsxOrder.Ticker != Symbol)
                    throw new InvalidOperationException($"The  Symbol of the EmsxOrder {EmsxOrder.EmsxOrderId} doesn't match the symbol of the fills. {EmsxOrder.Ticker} <> {Symbol}");
                if (EmsxOrder.Broker != Broker)
                    throw new InvalidOperationException($"The  Broker of the EmsxOrder {EmsxOrder.EmsxOrderId} doesn't match the symbol of the fills. {EmsxOrder.Broker} <> {Broker}");
                if (EmsxOrder.Side?.First() != Side.First())
                    throw new InvalidOperationException($"The  Side of the EmsxOrder {EmsxOrder.EmsxOrderId} doesn't match the Side of the fills. {EmsxOrder.Side} <> {Side}");
                if (EmsxOrder.AvgPrice != null && Math.Round(EmsxOrder.AvgPrice.Value, 2) != Math.Round(AvgPrice, 2))
                    throw new InvalidOperationException($"The  AvgPrice of the EmsxOrder {EmsxOrder.EmsxOrderId} doesn't match the AvgPrice of the fills. {EmsxOrder.AvgPrice} <> {AvgPrice}");
                //if (EmsxOrder.Date!= null && DateOnly.FromDateTime(EmsxOrder.Date.Value) != FirstFillDate)
                //    throw new InvalidOperationException($"The  Date of the EmsxOrder {EmsxOrder.EmsxOrderId} doesn't match the AvgPrice of the fills. {EmsxOrder.Date} <> {FirstFillDate}");
                if (EmsxOrder.IsCfd != IsCFD)
                    throw new InvalidOperationException($"The  Cffd flag of the EmsxOrder {EmsxOrder.EmsxOrderId} doesn't match the Cffd flag of the fills. {EmsxOrder.IsCfd} <> {IsCFD}");
                if (EmsxOrder.OrderRefId != OrderReferenceId)
                    throw new InvalidOperationException($"The  OrderRefId of the EmsxOrder {EmsxOrder.EmsxOrderId} doesn't match the OrderRefId of the fills. {EmsxOrder.OrderRefId} <> {OrderReferenceId}");
            }
        }
        internal bool IsComplete()
        {
            return ((EmsxOrder != null) && (EmsxOrder.IsFilled || EmsxOrder.IsPartiallyFilled))
                || (EmsxFillAggregate.FilledQuantity == EmsxFillAggregate.OrderQuantity)
                || DateOnly.FromDateTime(LastFillDateTimeUtc) < DateOnly.FromDateTime(DateTime.UtcNow);

        }

        public override string? ToString()
        {
            return $"{Side} {FilledQuantity} {Symbol} EmsxOrderId:{EmsxOrderId}";
        }

        public override bool Equals(object? obj)
        {
            return obj is EmsxTrade trade &&
                   EmsxOrderId == trade.EmsxOrderId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(EmsxOrderId);
        }
    }
}
