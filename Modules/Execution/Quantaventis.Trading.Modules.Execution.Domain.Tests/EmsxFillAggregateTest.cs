using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using Quantaventis.Trading.Modules.Execution.Domain.Model;
using System.Collections.Generic;
using Xunit.Sdk;
namespace Quantaventis.Trading.Modules.Execution.Domain.Model.Tests
{
    public class EmsxFillAggregateTest
    {
        [Theory]
        [MemberData(nameof(GetEmsxFillData))]
        internal void TestEmsxFillAggregate(IEnumerable<EmsxFill> fills, ExpectedAggregateResult expected)
        {
            var aggregate = new EmsxFillAggregate( fills);

            // Assert
            Assert.Equal(expected.EmsxOrderId, aggregate.EmsxOrderId);
            Assert.Equal(expected.Symbol, aggregate.Symbol);
            Assert.Equal(expected.Account, aggregate.Account);
            Assert.Equal(expected.AssetClass, aggregate.AssetClass);
            Assert.Equal(expected.BasketId, aggregate.BasketId);
            Assert.Equal(expected.BbgId, aggregate.BbgId);
            Assert.Equal(expected.Broker, aggregate.Broker);
            Assert.Equal(expected.ContractExpDate, aggregate.ContractExpDate);
            Assert.Equal(expected.Cusip, aggregate.Cusip);
            Assert.Equal(expected.AvgPrice, aggregate.AvgPrice);
            Assert.Equal(expected.MaxFillPrice, aggregate.MaxFillPrice);
            Assert.Equal(expected.MinFillPrice, aggregate.MinFillPrice);
            Assert.Equal(expected.FilledQuantity, aggregate.FilledQuantity);
            Assert.Equal(expected.OrderQuantity, aggregate.OrderQuantity);
            Assert.Equal(expected.IsCFD, aggregate.IsCFD);
            Assert.Equal(expected.Isin, aggregate.Isin);
            Assert.Equal(expected.LocalExchangeSymbol, aggregate.LocalExchangeSymbol);
            Assert.Equal(expected.OrderHandlingInstruction, aggregate.OrderHandlingInstruction);
            Assert.Equal(expected.OrderReferenceId, aggregate.OrderReferenceId);
            Assert.Equal(expected.SecurityName, aggregate.SecurityName);
            Assert.Equal(expected.Sedol, aggregate.Sedol);
            Assert.Equal(expected.SettlementDate, aggregate.SettlementDate);
            Assert.Equal(expected.StrategyType, aggregate.StrategyType);
            Assert.Equal(expected.TraderName, aggregate.TraderName);
            Assert.Equal(expected.TraderUUId, aggregate.TraderUUId);
            Assert.Equal(expected.OrderType, aggregate.OrderType);
            Assert.Equal(expected.FirstFillTime, aggregate.FirstFillDateTimeUtc);
            Assert.Equal(expected.LastFillTime, aggregate.LastFillDateTimeUtc);
        }

      
        public static IEnumerable<object[]> GetEmsxFillData()
        {
           
          var fills = new List<EmsxFill>
            {
               
                new EmsxFill(13319536, 3, "Buy",810, 654, 34.360000m, "USD", "US", "WTRG", "Equity", true){
                Account = "MS1CFD",
                AssetClass = "Equity",
                BasketId = 415,
                BbgId = "BBG000BRMJN6",
                Broker = "MSET",
                ContractExpDate = DateOnly.Parse("2024-04-13"),
                Cusip = "29670G102",
                DateTimeOfFillUtc = DateTime.Parse("2024-04-12 20:00:25.0866667"),
                ExecType = "FILL",
                ExecutingBroker = "MSCS",
                Isin = "US29670G1022",
                LocalExchangeSymbol = "WTRG",
                OrderHandlingInstruction = "AUTO",
                OrderReferenceId = "174894",
                RouteId = 2,
                RouteNetMoney =22471.440000m,
                RouteShares = 810,
                SecurityName = "ESSENTIAL UTILIT",
                Sedol = "BLCF3J9",
                SettlementDate = DateOnly.Parse("2024-04-16"),
                StrategyType = "CLOSE",
                TraderName= "PHUBER24",
                TraderUUId = 31934002,
                OrderType = "MKT"
                }, new EmsxFill(13319536, 4, "Buy",810, 156, 34.360000m, "USD", "US", "WTRG", "Equity", true){
                Account = "MS1CFD",
                AssetClass = "Equity",
                BasketId = 415,
                BbgId = "BBG000BRMJN6",
                Broker = "MSET",
                ContractExpDate = DateOnly.Parse("2024-04-13"),
                Cusip = "29670G102",
                DateTimeOfFillUtc = DateTime.Parse("2024-04-12 20:00:25.2166667"),
                ExecType = "FILL",
                ExecutingBroker = "MSCS",
                Isin = "US29670G1022",
                LocalExchangeSymbol = "WTRG",
                OrderHandlingInstruction = "AUTO",
                OrderReferenceId = "174894",
                RouteId = 2,
                RouteNetMoney =22471.440000m,
                RouteShares = 810,
                SecurityName = "ESSENTIAL UTILIT",
                Sedol = "BLCF3J9",
                SettlementDate = DateOnly.Parse("2024-04-16"),
                StrategyType = "CLOSE",
                TraderName= "PHUBER24",
                TraderUUId = 31934002,
                OrderType = "MKT"
                },
            };
           var expected = new ExpectedAggregateResult() {
               Symbol = "WTRG US Equity",//Expected Symbol
               EmsxOrderId = 13319536,
               Account = "MS1CFD",
               AssetClass = "Equity",
               BasketId = 415,
               BbgId = "BBG000BRMJN6",
               Broker = "MSET",
               ContractExpDate = DateOnly.Parse("2024-04-13"),
               Cusip = "29670G102",
               AvgPrice = 34.360000m,
               MaxFillPrice = 34.360000m,
               MinFillPrice = 34.360000m,
               FilledQuantity = 810,
               OrderQuantity = 810,
               IsCFD = true,
               ExecType = "FILL",
               ExecutingBroker = "MSCS",
               Isin = "US29670G1022",
               LocalExchangeSymbol = "WTRG",
               OrderHandlingInstruction = "AUTO",
               OrderReferenceId = "174894",
           
               SecurityName = "ESSENTIAL UTILIT",
               Sedol = "BLCF3J9",
               SettlementDate = DateOnly.Parse("2024-04-16"),
               StrategyType = "CLOSE",
               TraderName = "PHUBER24",
               TraderUUId = 31934002,
               OrderType = "MKT",
               FirstFillTime = DateTime.Parse("2024-04-12 20:00:25.0866667"),
               LastFillTime =  DateTime.Parse("2024-04-12 20:00:25.2166667"),
           };

            yield return new object[] { fills, expected };
        }
        internal class ExpectedAggregateResult
        {
            internal string Symbol { get; set; }

            internal int EmsxOrderId { get; set; }

            internal string? Account { get; set; }
            internal int OrderQuantity { get; set; }
            internal string? AssetClass { get; set; }
            internal int? BasketId { get; set; }
            internal string? BbgId { get; set; }
            internal string? BlockId { get; set; }
            internal string? Broker { get; set; }
            internal string? ClearingAccount { get; set; }
            internal string? ClearingFirm { get; set; }
            internal DateOnly? ContractExpDate { get; set; }
            internal int? CorrectedFillId { get; set; }
            internal string Currency { get; set; }
            internal string? Cusip { get; set; }
            internal DateTime DateTimeOfFill { get; set; }
            internal string Exchange { get; set; }
            internal int? ExecPrevSeqNo { get; set; }
            internal string? ExecType { get; set; }
            internal string? ExecutingBroker { get; set; }
            internal int FillId { get; set; }
            internal decimal FillPrice { get; set; }
            internal int FilledQuantity { get; set; }
            internal string? InvestorId { get; set; }
            internal bool IsCFD { get; set; }
            internal string? Isin { get; set; }
            internal bool? IsLeg { get; set; }
            internal string? LastCapacity { get; set; }
            internal string? LastMarket { get; set; }
            internal decimal? LimitPrice { get; set; }
            internal string? Liquidity { get; set; }
            internal string? LocalExchangeSymbol { get; set; }
            internal string? LocateBroker { get; set; }
            internal string? LocateId { get; set; }
            internal bool? LocateRequired { get; set; }
            internal string? MultiLegId { get; set; }
            internal string? OccSymbol { get; set; }
            internal string? OrderExecutionInstruction { get; set; }
            internal string? OrderHandlingInstruction { get; set; }

            internal string? OrderInstruction { get; set; }
            internal string? OrderOrigin { get; set; }
            internal string? OrderReferenceId { get; set; }
            internal int? OriginatingTraderUUId { get; set; }
            internal string? ReroutedBroker { get; set; }
            internal decimal? RouteCommissionAmount { get; set; }
            internal decimal? RouteCommissionRate { get; set; }
            internal string? RouteExecutionInstruction { get; set; }
            internal string? RouteHandlingInstruction { get; set; }
            internal int? RouteId { get; set; }
            internal decimal? RouteNetMoney { get; set; }
            internal string? RouteNotes { get; set; }
            internal int? RouteShares { get; set; }
            internal string? SecurityName { get; set; }
            internal string? Sedol { get; set; }
            internal DateOnly? SettlementDate { get; set; }
            internal string Side { get; set; }
            internal decimal? StopPrice { get; set; }
            internal string? StrategyType { get; set; }
            internal string Ticker { get; set; }
            internal string? Tif { get; set; }
            internal string? TraderName { get; set; }
            internal int? TraderUUId { get; set; }
            internal string? OrderType { get; set; }
            internal decimal? UserCommissionAmount { get; set; }
            internal decimal? UserCommissionRate { get; set; }
            internal decimal? UserFees { get; set; }
            internal decimal? UserNetMoney { get; set; }
            internal string YellowKey { get; set; }
            public DateOnly FirstFillDate { get; set; }
            public DateOnly LastFillDate { get; set; }
            public DateTime FirstFillTime { get; set; }
            public DateTime LastFillTime { get; set; }

            public decimal AvgPrice { get; set; }
            public decimal MaxFillPrice { get; set; }
            public decimal MinFillPrice { get; set; }
            // Add additional fields as needed
        }
    }
}
