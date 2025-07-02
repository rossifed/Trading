using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Quantaventis.Trading.Modules.Execution.Infrastructure.Entities;

public partial class ExecutionDbContext : DbContext
{
    public ExecutionDbContext()
    {
    }

    public ExecutionDbContext(DbContextOptions<ExecutionDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EmsxFill> EmsxFills { get; set; }

    public virtual DbSet<EmsxOrder> EmsxOrders { get; set; }

    public virtual DbSet<EmsxRoute> EmsxRoutes { get; set; }

    public virtual DbSet<Instrument> Instruments { get; set; }

    public virtual DbSet<VwEmsxFillAggregate> VwEmsxFillAggregates { get; set; }

    public virtual DbSet<VwEmsxOrderExecution> VwEmsxOrderExecutions { get; set; }

    public virtual DbSet<VwFilledOrder> VwFilledOrders { get; set; }

    public virtual DbSet<VwTestCompareBookedTrade> VwTestCompareBookedTrades { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=TradingDatabase");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CS_AS");

        modelBuilder.Entity<EmsxFill>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.FillId });

            entity
                .ToTable("EmsxFill", "exec")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("H_EmsxFill", "exec");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.Account).HasMaxLength(50);
            entity.Property(e => e.AssetClass).HasMaxLength(50);
            entity.Property(e => e.Bbgid).HasMaxLength(15);
            entity.Property(e => e.BlockId).HasMaxLength(50);
            entity.Property(e => e.Broker).HasMaxLength(10);
            entity.Property(e => e.ClearingAccount).HasMaxLength(20);
            entity.Property(e => e.ClearingFirm).HasMaxLength(50);
            entity.Property(e => e.ContractExpDate).HasColumnType("date");
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Cusip).HasMaxLength(10);
            entity.Property(e => e.Exchange).HasMaxLength(5);
            entity.Property(e => e.ExecType).HasMaxLength(20);
            entity.Property(e => e.ExecutingBroker).HasMaxLength(10);
            entity.Property(e => e.FillPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.InvestorId).HasMaxLength(50);
            entity.Property(e => e.IsCfd).HasColumnName("IsCFD");
            entity.Property(e => e.Isin).HasMaxLength(12);
            entity.Property(e => e.LastCapacity).HasMaxLength(20);
            entity.Property(e => e.LastMarket).HasMaxLength(20);
            entity.Property(e => e.LimitPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Liquidity).HasMaxLength(50);
            entity.Property(e => e.LocalExchangeSymbol).HasMaxLength(8);
            entity.Property(e => e.LocateBroker).HasMaxLength(10);
            entity.Property(e => e.LocateId).HasMaxLength(50);
            entity.Property(e => e.MultiLegId).HasMaxLength(50);
            entity.Property(e => e.OccSymbol).HasMaxLength(50);
            entity.Property(e => e.OrderExecutionInstruction).HasMaxLength(50);
            entity.Property(e => e.OrderHandlingInstruction).HasMaxLength(20);
            entity.Property(e => e.OrderInstruction).HasMaxLength(50);
            entity.Property(e => e.OrderOrigin).HasMaxLength(10);
            entity.Property(e => e.OrderReferenceId).HasMaxLength(50);
            entity.Property(e => e.OriginatingTraderUuid).HasColumnName("OriginatingTraderUUId");
            entity.Property(e => e.ReroutedBroker).HasMaxLength(20);
            entity.Property(e => e.RouteCommissionAmount).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.RouteCommissionRate).HasColumnType("decimal(10, 6)");
            entity.Property(e => e.RouteExecutionInstruction).HasMaxLength(50);
            entity.Property(e => e.RouteHandlingInstruction).HasMaxLength(50);
            entity.Property(e => e.RouteNetMoney).HasColumnType("decimal(24, 6)");
            entity.Property(e => e.RouteNotes).HasMaxLength(200);
            entity.Property(e => e.SecurityName).HasMaxLength(200);
            entity.Property(e => e.Sedol).HasMaxLength(10);
            entity.Property(e => e.SettlementDate).HasColumnType("date");
            entity.Property(e => e.Side).HasMaxLength(2);
            entity.Property(e => e.StopPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.StrategyType).HasMaxLength(20);
            entity.Property(e => e.Ticker).HasMaxLength(30);
            entity.Property(e => e.Tif).HasMaxLength(10);
            entity.Property(e => e.TraderName).HasMaxLength(20);
            entity.Property(e => e.TraderUuid).HasColumnName("TraderUUId");
            entity.Property(e => e.Type).HasMaxLength(50);
            entity.Property(e => e.UserCommissionAmount).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.UserCommissionRate).HasColumnType("decimal(8, 6)");
            entity.Property(e => e.UserFees).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.UserNetMoney).HasColumnType("decimal(24, 6)");
            entity.Property(e => e.YellowKey).HasMaxLength(10);
        });

        modelBuilder.Entity<EmsxOrder>(entity =>
        {
            entity.HasKey(e => e.EmsxSequence).HasName("PK__EmsxOrde__8D17D0B5B1C3BBE6");

            entity
                .ToTable("EmsxOrder", "exec")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("H_EmsxOrder", "exec");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.EmsxSequence).ValueGeneratedNever();
            entity.Property(e => e.Account).HasMaxLength(255);
            entity.Property(e => e.ArrivalPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.AssetClass).HasMaxLength(255);
            entity.Property(e => e.AssignedTrader).HasMaxLength(255);
            entity.Property(e => e.AvgPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.BasketName).HasMaxLength(255);
            entity.Property(e => e.BookName).HasMaxLength(255);
            entity.Property(e => e.Broker).HasMaxLength(255);
            entity.Property(e => e.BrokerComm).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.BseAvgPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.CfdFlag).HasMaxLength(255);
            entity.Property(e => e.ClearingAccount).HasMaxLength(255);
            entity.Property(e => e.ClearingFirm).HasMaxLength(255);
            entity.Property(e => e.CommDiffFlag).HasMaxLength(255);
            entity.Property(e => e.CommRate).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.CurrencyPair).HasMaxLength(255);
            entity.Property(e => e.CustomNote1).HasMaxLength(255);
            entity.Property(e => e.CustomNote2).HasMaxLength(255);
            entity.Property(e => e.CustomNote3).HasMaxLength(255);
            entity.Property(e => e.CustomNote4).HasMaxLength(255);
            entity.Property(e => e.CustomNote5).HasMaxLength(255);
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.DayAvgPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.DirBrokerFlag).HasMaxLength(255);
            entity.Property(e => e.Exchange).HasMaxLength(255);
            entity.Property(e => e.ExchangeDestination).HasMaxLength(255);
            entity.Property(e => e.ExecInstruction).HasMaxLength(255);
            entity.Property(e => e.GtdDate).HasColumnType("date");
            entity.Property(e => e.HandInstruction).HasMaxLength(255);
            entity.Property(e => e.InvestorId).HasMaxLength(255);
            entity.Property(e => e.Isin).HasMaxLength(255);
            entity.Property(e => e.LimitPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.LocateBroker).HasMaxLength(255);
            entity.Property(e => e.LocateId).HasMaxLength(255);
            entity.Property(e => e.LocateReq).HasMaxLength(255);
            entity.Property(e => e.LocateRequest).HasMaxLength(255);
            entity.Property(e => e.Notes).HasMaxLength(255);
            entity.Property(e => e.NseAvgPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.OrderOrigin).HasMaxLength(255);
            entity.Property(e => e.OrderRefId).HasMaxLength(255);
            entity.Property(e => e.OrderType).HasMaxLength(255);
            entity.Property(e => e.OriginateTrader).HasMaxLength(255);
            entity.Property(e => e.OriginateTraderFirm).HasMaxLength(255);
            entity.Property(e => e.PercentRemain).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PortMgr).HasMaxLength(255);
            entity.Property(e => e.PortName).HasMaxLength(255);
            entity.Property(e => e.Position).HasMaxLength(255);
            entity.Property(e => e.Principal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Product).HasMaxLength(255);
            entity.Property(e => e.ReasonCode).HasMaxLength(255);
            entity.Property(e => e.ReasonDescription).HasMaxLength(255);
            entity.Property(e => e.RemainBalance).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.RoutePrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.RouteRefId).HasMaxLength(255);
            entity.Property(e => e.SecName).HasMaxLength(255);
            entity.Property(e => e.Sedol).HasMaxLength(255);
            entity.Property(e => e.SettleAmount).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.SettleDate).HasColumnType("date");
            entity.Property(e => e.SettlementCurrency).HasMaxLength(255);
            entity.Property(e => e.SettlementDate).HasColumnType("date");
            entity.Property(e => e.SettlementPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.SettlementType).HasMaxLength(255);
            entity.Property(e => e.Side).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(255);
            entity.Property(e => e.StepOutBrooker).HasMaxLength(255);
            entity.Property(e => e.StopPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Strategy).HasMaxLength(255);
            entity.Property(e => e.StrategyPartRate1).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.StrategyPartRate2).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.StrategyStyle).HasMaxLength(255);
            entity.Property(e => e.StrategyType).HasMaxLength(255);
            entity.Property(e => e.Ticker).HasMaxLength(255);
            entity.Property(e => e.TimeInForce).HasMaxLength(255);
            entity.Property(e => e.TradeDesk).HasMaxLength(255);
            entity.Property(e => e.Trader).HasMaxLength(255);
            entity.Property(e => e.TraderNotes).HasMaxLength(255);
            entity.Property(e => e.Type).HasMaxLength(255);
            entity.Property(e => e.UnderlyingTicker).HasMaxLength(255);
            entity.Property(e => e.UserCommAmount).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.UserCommRate).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.UserFees).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.UserNetMoney).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.UserWorkPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Warnings).HasMaxLength(255);
            entity.Property(e => e.YellowKey).HasMaxLength(255);
        });

        modelBuilder.Entity<EmsxRoute>(entity =>
        {
            entity.HasKey(e => new { e.Sequence, e.RouteId });

            entity.ToTable("EmsxRoute", "exec");

            entity.Property(e => e.Account).HasMaxLength(255);
            entity.Property(e => e.AvgPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Broker).HasMaxLength(255);
            entity.Property(e => e.BrokerComm).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.BseAvgPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.ClearingAccount).HasMaxLength(255);
            entity.Property(e => e.ClearingFirm).HasMaxLength(255);
            entity.Property(e => e.CommDiffFlag).HasMaxLength(255);
            entity.Property(e => e.CommRate).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.CurrencyPair).HasMaxLength(255);
            entity.Property(e => e.CustomAccount).HasMaxLength(255);
            entity.Property(e => e.DayAvgPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.ExchangeDestination).HasMaxLength(255);
            entity.Property(e => e.ExecInstruction).HasMaxLength(255);
            entity.Property(e => e.ExecuteBroker).HasMaxLength(255);
            entity.Property(e => e.HandInstruction).HasMaxLength(255);
            entity.Property(e => e.LastMarket).HasMaxLength(255);
            entity.Property(e => e.LastPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.LimitPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.MiscFees)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Misc_fees");
            entity.Property(e => e.MlPercentFilled).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.MlRation).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.MlRemainBalance).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.MlStrategy).HasMaxLength(255);
            entity.Property(e => e.NseAvgPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.OrderType).HasMaxLength(255);
            entity.Property(e => e.Pa).HasMaxLength(255);
            entity.Property(e => e.PercentRemain).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Principal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.ReasonCode).HasMaxLength(255);
            entity.Property(e => e.ReasonDescription).HasMaxLength(255);
            entity.Property(e => e.RemainBalance).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.RoutePrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.RouteRefId).HasMaxLength(255);
            entity.Property(e => e.SettleAmount).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Status).HasMaxLength(255);
            entity.Property(e => e.StopPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.StrategyPartRate1).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.StrategyPartRate2).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.StrategyStyle).HasMaxLength(255);
            entity.Property(e => e.StrategyType).HasMaxLength(255);
            entity.Property(e => e.Tif).HasMaxLength(255);
            entity.Property(e => e.Type).HasMaxLength(255);
            entity.Property(e => e.UserCommAmount).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.UserCommRate).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.UserFees).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.UserNetMoney).HasColumnType("decimal(18, 6)");
        });

        modelBuilder.Entity<Instrument>(entity =>
        {
            entity.HasKey(e => e.InstrumentId).HasName("PK_InstrumentId");

            entity.ToTable("Instrument", "exec");

            entity.Property(e => e.InstrumentId).ValueGeneratedNever();
            entity.Property(e => e.BbgUniqueId).HasMaxLength(30);
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Exchange).HasMaxLength(5);
            entity.Property(e => e.FuturePointValue).HasColumnType("decimal(14, 6)");
            entity.Property(e => e.InstrumentType).HasMaxLength(10);
            entity.Property(e => e.Isin)
                .HasMaxLength(12)
                .HasColumnName("ISIN");
            entity.Property(e => e.MarketSector).HasMaxLength(6);
            entity.Property(e => e.MaturityDate).HasColumnType("date");
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.PriceScalingFactor).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.PrimaryMic).HasMaxLength(10);
            entity.Property(e => e.QuoteCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Symbol).HasMaxLength(30);
        });

        modelBuilder.Entity<VwEmsxFillAggregate>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwEmsxFillAggregate", "exec");

            entity.Property(e => e.Account).HasMaxLength(50);
            entity.Property(e => e.AssetClass).HasMaxLength(50);
            entity.Property(e => e.AvgPrice).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.Bbgid).HasMaxLength(15);
            entity.Property(e => e.BlockId).HasMaxLength(50);
            entity.Property(e => e.Broker).HasMaxLength(10);
            entity.Property(e => e.ClearingAccount).HasMaxLength(20);
            entity.Property(e => e.ClearingFirm).HasMaxLength(50);
            entity.Property(e => e.ContractExpDate).HasColumnType("date");
            entity.Property(e => e.ContractMultiplier).HasColumnType("decimal(14, 6)");
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Cusip).HasMaxLength(10);
            entity.Property(e => e.Exchange).HasMaxLength(5);
            entity.Property(e => e.ExecutingBroker).HasMaxLength(10);
            entity.Property(e => e.FirstFillTime).HasColumnType("datetime");
            entity.Property(e => e.GrossMarketValue).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.GrossNotionalAmount).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.InstrumentType).HasMaxLength(10);
            entity.Property(e => e.IsCfd).HasColumnName("IsCFD");
            entity.Property(e => e.Isin).HasMaxLength(12);
            entity.Property(e => e.LastFillTime).HasColumnType("datetime");
            entity.Property(e => e.LimitPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.LocalExchangeSymbol).HasMaxLength(8);
            entity.Property(e => e.MaxFillPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.MinFillPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.OrderExecutionInstruction).HasMaxLength(50);
            entity.Property(e => e.OrderHandlingInstruction).HasMaxLength(20);
            entity.Property(e => e.OrderInstruction).HasMaxLength(50);
            entity.Property(e => e.OrderOrigin).HasMaxLength(10);
            entity.Property(e => e.OrderReferenceId).HasMaxLength(50);
            entity.Property(e => e.OriginatingTraderUuid).HasColumnName("OriginatingTraderUUId");
            entity.Property(e => e.SecurityName).HasMaxLength(200);
            entity.Property(e => e.Sedol).HasMaxLength(10);
            entity.Property(e => e.SettlementDate).HasColumnType("date");
            entity.Property(e => e.Side).HasMaxLength(2);
            entity.Property(e => e.StopPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.StrategyType).HasMaxLength(20);
            entity.Property(e => e.Symbol).HasMaxLength(47);
            entity.Property(e => e.Ticker).HasMaxLength(30);
            entity.Property(e => e.Tif).HasMaxLength(10);
            entity.Property(e => e.TradeDate).HasColumnType("date");
            entity.Property(e => e.TraderName).HasMaxLength(20);
            entity.Property(e => e.TraderUuid).HasColumnName("TraderUUId");
            entity.Property(e => e.Type).HasMaxLength(50);
            entity.Property(e => e.UserCommissionAmount).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.UserCommissionRate).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.UserFees).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.UserNetMoney).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.YellowKey).HasMaxLength(10);
        });

        modelBuilder.Entity<VwEmsxOrderExecution>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwEmsxOrderExecution", "exec");

            entity.Property(e => e.Account).HasMaxLength(50);
            entity.Property(e => e.AssetClass).HasMaxLength(50);
            entity.Property(e => e.AvgPrice).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.Bbgid).HasMaxLength(15);
            entity.Property(e => e.BlockId).HasMaxLength(50);
            entity.Property(e => e.Broker).HasMaxLength(10);
            entity.Property(e => e.ClearingAccount).HasMaxLength(20);
            entity.Property(e => e.ClearingFirm).HasMaxLength(50);
            entity.Property(e => e.ContractExpDate).HasColumnType("date");
            entity.Property(e => e.ContractMultiplier).HasColumnType("decimal(14, 6)");
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Cusip).HasMaxLength(10);
            entity.Property(e => e.Exchange).HasMaxLength(5);
            entity.Property(e => e.ExecutingBroker).HasMaxLength(10);
            entity.Property(e => e.FirstFillTime).HasColumnType("datetime");
            entity.Property(e => e.GrossMarketValue).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.GrossNotionalAmount).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.InstrumentType).HasMaxLength(10);
            entity.Property(e => e.IsCfd).HasColumnName("IsCFD");
            entity.Property(e => e.Isin).HasMaxLength(12);
            entity.Property(e => e.LastFillTime).HasColumnType("datetime");
            entity.Property(e => e.LimitPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.LocalExchangeSymbol).HasMaxLength(8);
            entity.Property(e => e.MaxFillPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.MinFillPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.OrderExecutionInstruction).HasMaxLength(50);
            entity.Property(e => e.OrderHandlingInstruction).HasMaxLength(20);
            entity.Property(e => e.OrderInstruction).HasMaxLength(50);
            entity.Property(e => e.OrderOrigin).HasMaxLength(10);
            entity.Property(e => e.OrderReferenceId).HasMaxLength(50);
            entity.Property(e => e.OriginatingTraderUuid).HasColumnName("OriginatingTraderUUId");
            entity.Property(e => e.SecurityName).HasMaxLength(200);
            entity.Property(e => e.Sedol).HasMaxLength(10);
            entity.Property(e => e.SettlementDate).HasColumnType("date");
            entity.Property(e => e.Side).HasMaxLength(2);
            entity.Property(e => e.StopPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.StrategyType).HasMaxLength(20);
            entity.Property(e => e.Symbol).HasMaxLength(47);
            entity.Property(e => e.Ticker).HasMaxLength(30);
            entity.Property(e => e.Tif).HasMaxLength(10);
            entity.Property(e => e.TradeDate).HasColumnType("date");
            entity.Property(e => e.TraderName).HasMaxLength(20);
            entity.Property(e => e.TraderUuid).HasColumnName("TraderUUId");
            entity.Property(e => e.Type).HasMaxLength(50);
            entity.Property(e => e.UserCommissionAmount).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.UserCommissionRate).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.UserFees).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.UserNetMoney).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.YellowKey).HasMaxLength(10);
        });

        modelBuilder.Entity<VwFilledOrder>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwFilledOrder", "exec");

            entity.Property(e => e.Account).HasMaxLength(50);
            entity.Property(e => e.AvgPrice).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.BasketName).HasMaxLength(255);
            entity.Property(e => e.Broker).HasMaxLength(10);
            entity.Property(e => e.CfdFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ClearingAccount).HasMaxLength(20);
            entity.Property(e => e.ClearingFirm).HasMaxLength(50);
            entity.Property(e => e.CustomNote1).HasMaxLength(255);
            entity.Property(e => e.CustomNote2).HasMaxLength(255);
            entity.Property(e => e.CustomNote4).HasMaxLength(255);
            entity.Property(e => e.CustomNote5).HasMaxLength(255);
            entity.Property(e => e.DayAvgPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.EmsxDate).HasColumnType("date");
            entity.Property(e => e.Exchange).HasMaxLength(5);
            entity.Property(e => e.HandlingInstruction).HasMaxLength(20);
            entity.Property(e => e.Isin)
                .HasMaxLength(12)
                .HasColumnName("ISIN");
            entity.Property(e => e.LastFillDate).HasColumnType("date");
            entity.Property(e => e.LimitPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Notes).HasMaxLength(50);
            entity.Property(e => e.OrderRefId).HasMaxLength(50);
            entity.Property(e => e.OrderType).HasMaxLength(50);
            entity.Property(e => e.PercentRemain).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Principal).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.Sedol).HasMaxLength(10);
            entity.Property(e => e.SettleAmount).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.SettleCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SettlementDate).HasColumnType("date");
            entity.Property(e => e.Side)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.Status).HasMaxLength(255);
            entity.Property(e => e.Strategy).HasMaxLength(20);
            entity.Property(e => e.Ticker).HasMaxLength(47);
            entity.Property(e => e.TimeInForce).HasMaxLength(10);
            entity.Property(e => e.TimeStamp).HasColumnType("datetime");
            entity.Property(e => e.Trader).HasMaxLength(20);
            entity.Property(e => e.TraderUuid).HasColumnName("TraderUUId");
            entity.Property(e => e.YellowKey).HasMaxLength(10);
        });

        modelBuilder.Entity<VwTestCompareBookedTrade>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwTestCompareBookedTrades", "exec");

            entity.Property(e => e.AvgPriceDiff).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.BookedAvgPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.BookedInstrumentType).HasMaxLength(10);
            entity.Property(e => e.BookedPrincipal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.BookedSedol).HasMaxLength(7);
            entity.Property(e => e.BookedTradeCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.BookedTradeDate).HasColumnType("date");
            entity.Property(e => e.OrderReferenceId).HasMaxLength(50);
            entity.Property(e => e.Principal).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.PrincipalDiff).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.Symbol).HasMaxLength(47);
            entity.Property(e => e.TradeAvgPrice).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.TradeCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TradeDate).HasColumnType("date");
            entity.Property(e => e.TradeInstrumentType).HasMaxLength(10);
            entity.Property(e => e.TradeIsCfd).HasColumnName("TradeIsCFD");
            entity.Property(e => e.TradeSedol).HasMaxLength(10);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
