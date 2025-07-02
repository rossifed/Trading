using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Quantaventis.Trading.Modules.Trades.Infrastructure.Entities;

public partial class TradesDbContext : DbContext
{
    public TradesDbContext()
    {
    }

    public TradesDbContext(DbContextOptions<TradesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EmsxOrder> EmsxOrders { get; set; }

    public virtual DbSet<FutureCommission> FutureCommissions { get; set; }

    public virtual DbSet<FutureSwap> FutureSwaps { get; set; }

    public virtual DbSet<FxRate> FxRates { get; set; }

    public virtual DbSet<FxemTrade> FxemTrades { get; set; }

    public virtual DbSet<Instrument> Instruments { get; set; }

    public virtual DbSet<MsefrpTradeAffirm> MsefrpTradeAffirms { get; set; }

    public virtual DbSet<StgTradeAllocToBook> StgTradeAllocToBooks { get; set; }

    public virtual DbSet<StgTradeToBook> StgTradeToBooks { get; set; }

    public virtual DbSet<Trade> Trades { get; set; }

    public virtual DbSet<TradeAllocation> TradeAllocations { get; set; }

    public virtual DbSet<TradeAllocationBackup> TradeAllocationBackups { get; set; }

    public virtual DbSet<TradeFill> TradeFills { get; set; }

    public virtual DbSet<VwDailyBookedTrade> VwDailyBookedTrades { get; set; }

    public virtual DbSet<VwEfrpTrade> VwEfrpTrades { get; set; }

    public virtual DbSet<VwEfrpTradeToBook> VwEfrpTradeToBooks { get; set; }

    public virtual DbSet<VwEmsxTradeReconciliation> VwEmsxTradeReconciliations { get; set; }

    public virtual DbSet<VwEmsxTradeToBook> VwEmsxTradeToBooks { get; set; }

    public virtual DbSet<VwEmsxTradeToBookBackup> VwEmsxTradeToBookBackups { get; set; }

    public virtual DbSet<VwFutureCommission> VwFutureCommissions { get; set; }

    public virtual DbSet<VwFutureSwap> VwFutureSwaps { get; set; }

    public virtual DbSet<VwFxemTradeToBook> VwFxemTradeToBooks { get; set; }

    public virtual DbSet<VwMsefrpFutureTradeAffirm> VwMsefrpFutureTradeAffirms { get; set; }

    public virtual DbSet<VwTrade> VwTrades { get; set; }

    public virtual DbSet<VwTradeAllocation> VwTradeAllocations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=TradingDatabase");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CS_AS");

        modelBuilder.Entity<EmsxOrder>(entity =>
        {
            entity.HasKey(e => e.EmsxSequence);

            entity
                .ToTable("EmsxOrder", "trd")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("H_EmsxOrder", "trd");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.EmsxSequence).ValueGeneratedNever();
            entity.Property(e => e.Account).HasMaxLength(20);
            entity.Property(e => e.AvgPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.BasketName).HasMaxLength(20);
            entity.Property(e => e.Broker).HasMaxLength(30);
            entity.Property(e => e.BrokerCommm).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.CfdFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ClearingAccount).HasMaxLength(30);
            entity.Property(e => e.ClearingFirm).HasMaxLength(30);
            entity.Property(e => e.CommmRate).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.CustomNote1).HasMaxLength(100);
            entity.Property(e => e.CustomNote2).HasMaxLength(100);
            entity.Property(e => e.CustomNote3).HasMaxLength(100);
            entity.Property(e => e.CustomNote4).HasMaxLength(100);
            entity.Property(e => e.CustomNote5).HasMaxLength(100);
            entity.Property(e => e.DayAvgPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.EmsxDate).HasColumnType("date");
            entity.Property(e => e.Exchange).HasMaxLength(10);
            entity.Property(e => e.HandInstruction).HasMaxLength(10);
            entity.Property(e => e.Isin)
                .HasMaxLength(12)
                .HasColumnName("ISIN");
            entity.Property(e => e.LastFillDate).HasColumnType("date");
            entity.Property(e => e.LimitPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.MiscFees).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.Notes).HasMaxLength(300);
            entity.Property(e => e.OrderRefId).HasMaxLength(30);
            entity.Property(e => e.OrderType).HasMaxLength(10);
            entity.Property(e => e.Principal).HasColumnType("decimal(24, 6)");
            entity.Property(e => e.Sedol).HasMaxLength(7);
            entity.Property(e => e.SettleAmount).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.SettleCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SettleDate).HasColumnType("date");
            entity.Property(e => e.Side).HasMaxLength(10);
            entity.Property(e => e.Status).HasMaxLength(15);
            entity.Property(e => e.Strategy).HasMaxLength(10);
            entity.Property(e => e.Ticker).HasMaxLength(30);
            entity.Property(e => e.TimeInForce).HasMaxLength(10);
            entity.Property(e => e.Trader).HasMaxLength(30);
            entity.Property(e => e.YellowKey).HasMaxLength(10);
        });

        modelBuilder.Entity<FutureCommission>(entity =>
        {
            entity.HasKey(e => e.FutureCommissionId).HasName("PK_FutureBrokerCommission");

            entity
                .ToTable("FutureCommission", "trd")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("H_FutureCommission", "trd");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasIndex(e => new { e.BrokerCode, e.GenericFutureId }, "UC_FutureCommission").IsUnique();

            entity.Property(e => e.BrokerCode).HasMaxLength(10);
            entity.Property(e => e.CommPerLot).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.CommRate).HasColumnType("decimal(8, 6)");
            entity.Property(e => e.ExecDeskCommPerLot).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.ExecDeskCommRate).HasColumnType("decimal(8, 6)");
        });

        modelBuilder.Entity<FutureSwap>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("FutureSwap", "trd");

            entity.Property(e => e.SettlementCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<FxRate>(entity =>
        {
            entity.HasKey(e => new { e.BaseCurrency, e.QuoteCurrency, e.Date });

            entity.ToTable("FxRate", "trd");

            entity.Property(e => e.BaseCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.QuoteCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Value).HasColumnType("decimal(12, 6)");
        });

        modelBuilder.Entity<FxemTrade>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("FxemTrade", "trd");

            entity.Property(e => e.Account).HasMaxLength(50);
            entity.Property(e => e.AllInRate)
                .HasMaxLength(50)
                .HasColumnName("All_In_Rate");
            entity.Property(e => e.AmountCcy1)
                .HasMaxLength(50)
                .HasColumnName("Amount_Ccy1");
            entity.Property(e => e.AmountCcy2)
                .HasMaxLength(50)
                .HasColumnName("Amount_Ccy2");
            entity.Property(e => e.Ccy).HasMaxLength(50);
            entity.Property(e => e.Ccys).HasMaxLength(50);
            entity.Property(e => e.ContraCcy)
                .HasMaxLength(50)
                .HasColumnName("Contra_Ccy");
            entity.Property(e => e.Counterparty).HasMaxLength(50);
            entity.Property(e => e.DateTime)
                .HasMaxLength(50)
                .HasColumnName("Date_Time");
            entity.Property(e => e.DealCode)
                .HasMaxLength(50)
                .HasColumnName("Deal_Code");
            entity.Property(e => e.DealType)
                .HasMaxLength(50)
                .HasColumnName("Deal_Type");
            entity.Property(e => e.FwdPoints)
                .HasMaxLength(50)
                .HasColumnName("Fwd_Points");
            entity.Property(e => e.FxemOrderId)
                .HasMaxLength(50)
                .HasColumnName("FXEM_Order_ID");
            entity.Property(e => e.Header).HasMaxLength(50);
            entity.Property(e => e.PortfolioId).HasMaxLength(50);
            entity.Property(e => e.PositionSide).HasMaxLength(50);
            entity.Property(e => e.Product).HasMaxLength(50);
            entity.Property(e => e.RebalancingId).HasMaxLength(50);
            entity.Property(e => e.Side).HasMaxLength(50);
            entity.Property(e => e.SpotRate)
                .HasMaxLength(50)
                .HasColumnName("Spot_Rate");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TradeDate)
                .HasMaxLength(50)
                .HasColumnName("Trade_Date");
            entity.Property(e => e.TradeId)
                .HasMaxLength(50)
                .HasColumnName("Trade_ID");
            entity.Property(e => e.Trader).HasMaxLength(50);
            entity.Property(e => e.ValueDate)
                .HasMaxLength(50)
                .HasColumnName("Value_Date");
        });

        modelBuilder.Entity<Instrument>(entity =>
        {
            entity.HasKey(e => e.InstrumentId).HasName("PK_InstrumentId");

            entity.ToTable("Instrument", "trd");

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

        modelBuilder.Entity<MsefrpTradeAffirm>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("MSEfrpTradeAffirm", "trd");

            entity.Property(e => e.Account).HasMaxLength(50);
            entity.Property(e => e.Ccy1).HasMaxLength(50);
            entity.Property(e => e.Ccy1Amt)
                .HasMaxLength(50)
                .HasColumnName("Ccy1_Amt");
            entity.Property(e => e.Ccy1Side)
                .HasMaxLength(50)
                .HasColumnName("Ccy1_Side");
            entity.Property(e => e.Ccy2).HasMaxLength(50);
            entity.Property(e => e.Ccy2Amt)
                .HasMaxLength(50)
                .HasColumnName("Ccy2_Amt");
            entity.Property(e => e.Ccy2Side)
                .HasMaxLength(50)
                .HasColumnName("Ccy2_Side");
            entity.Property(e => e.DealEntryTime)
                .HasMaxLength(50)
                .HasColumnName("Deal_Entry_Time");
            entity.Property(e => e.DealId)
                .HasMaxLength(50)
                .HasColumnName("Deal_ID");
            entity.Property(e => e.EntryUser)
                .HasMaxLength(50)
                .HasColumnName("Entry_User");
            entity.Property(e => e.LastUpdateTime)
                .HasMaxLength(50)
                .HasColumnName("Last_Update_Time");
            entity.Property(e => e.SpotRate)
                .HasMaxLength(50)
                .HasColumnName("Spot_Rate");
            entity.Property(e => e.TradeDate)
                .HasMaxLength(50)
                .HasColumnName("Trade_Date");
            entity.Property(e => e.Type).HasMaxLength(50);
            entity.Property(e => e.ValueDate)
                .HasMaxLength(50)
                .HasColumnName("Value_Date");
        });

        modelBuilder.Entity<StgTradeAllocToBook>(entity =>
        {
            entity.ToTable("StgTradeAllocToBook", "trd");

            entity.Property(e => e.Commission).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Fees).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.GrossAmount).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.NetAmount).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PositionSide)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Price).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.TradingAccount).HasMaxLength(30);

            entity.HasOne(d => d.StgTradeToBook).WithMany(p => p.StgTradeAllocToBooks)
                .HasForeignKey(d => d.StgTradeToBookId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_StgTradeAllocToBook_StgTradeToBook");
        });

        modelBuilder.Entity<StgTradeToBook>(entity =>
        {
            entity.HasKey(e => e.StgTradeToBookId).HasName("PK_StgTradeToBookId");

            entity.ToTable("StgTradeToBook", "trd");

            entity.Property(e => e.AvgPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.BrokerCode).HasMaxLength(10);
            entity.Property(e => e.BrokerCommission).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.BuySellIndicator)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CommissionRate).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DayAveragePrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.EmsxOrderCreatedOn).HasColumnType("date");
            entity.Property(e => e.ExchangeCode).HasMaxLength(20);
            entity.Property(e => e.ExecutionChannel).HasMaxLength(10);
            entity.Property(e => e.FxCurrency1)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FxCurrency2)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Fxcurrency1Amount)
                .HasColumnType("decimal(24, 6)")
                .HasColumnName("FXCurrency1Amount");
            entity.Property(e => e.Fxcurrency2Amount)
                .HasColumnType("decimal(24, 6)")
                .HasColumnName("FXCurrency2Amount");
            entity.Property(e => e.MiscFees).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.NetAmount).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Notes).HasMaxLength(300);
            entity.Property(e => e.Principal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Sedol).HasMaxLength(7);
            entity.Property(e => e.SettlementCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SettlementDate).HasColumnType("date");
            entity.Property(e => e.TotalCharges).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.TradeCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TradeDate).HasColumnType("date");
            entity.Property(e => e.TradeDesk).HasMaxLength(10);
            entity.Property(e => e.TradeStatus)
                .HasMaxLength(5)
                .HasDefaultValueSql("('NEW')");
            entity.Property(e => e.Trader).HasMaxLength(30);

            entity.HasOne(d => d.Instrument).WithMany(p => p.StgTradeToBooks)
                .HasForeignKey(d => d.InstrumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StgTradeToBook_Instrument");
        });

        modelBuilder.Entity<Trade>(entity =>
        {
            entity
                .ToTable("Trade", "trd")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("H_Trade", "trd");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.AvgPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.BookedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.BrokerCode).HasMaxLength(10);
            entity.Property(e => e.BrokerCommission).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.BuySellIndicator)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CommissionRate).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DayAveragePrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.EmsxOrderCreatedOn).HasColumnType("date");
            entity.Property(e => e.ExchangeCode).HasMaxLength(20);
            entity.Property(e => e.ExecutionChannel).HasMaxLength(10);
            entity.Property(e => e.FxCurrency1)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FxCurrency2)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Fxcurrency1Amount)
                .HasColumnType("decimal(24, 6)")
                .HasColumnName("FXCurrency1Amount");
            entity.Property(e => e.Fxcurrency2Amount)
                .HasColumnType("decimal(24, 6)")
                .HasColumnName("FXCurrency2Amount");
            entity.Property(e => e.MiscFees).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.NetAmount).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Notes).HasMaxLength(300);
            entity.Property(e => e.Principal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Sedol).HasMaxLength(7);
            entity.Property(e => e.SettlementCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SettlementDate).HasColumnType("date");
            entity.Property(e => e.TotalCharges).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.TradeCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TradeDate).HasColumnType("date");
            entity.Property(e => e.TradeDesk).HasMaxLength(10);
            entity.Property(e => e.TradeStatus)
                .HasMaxLength(5)
                .HasDefaultValueSql("('NEW')");
            entity.Property(e => e.Trader).HasMaxLength(30);

            entity.HasOne(d => d.Instrument).WithMany(p => p.Trades)
                .HasForeignKey(d => d.InstrumentId)
                .HasConstraintName("FK_Trade_Instrument");
        });

        modelBuilder.Entity<TradeAllocation>(entity =>
        {
            entity
                .ToTable("TradeAllocation", "trd")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("H_TradeAllocation", "trd");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasIndex(e => e.TradeId, "Idx_TradeAllocation_TradeId");

            entity.Property(e => e.Commission).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Fees).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.GrossAmount).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.NetAmount).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PositionSide)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Price).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.TradingAccount).HasMaxLength(30);

            entity.HasOne(d => d.Trade).WithMany(p => p.TradeAllocations)
                .HasForeignKey(d => d.TradeId)
                .HasConstraintName("FK_TradeAllocation_Trade");
        });

        modelBuilder.Entity<TradeAllocationBackup>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TradeAllocation_Backup", "trd");

            entity.Property(e => e.Commission).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Fees).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.GrossAmount).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.NetAmount).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PositionSide)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Price).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.TradeAllocationId).ValueGeneratedOnAdd();
            entity.Property(e => e.TradingAccount).HasMaxLength(30);
        });

        modelBuilder.Entity<TradeFill>(entity =>
        {
            entity.ToTable("TradeFill", "trd");

            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.FilledOn).HasColumnType("date");
            entity.Property(e => e.FilledPrice).HasColumnType("decimal(18, 6)");

            entity.HasOne(d => d.Trade).WithMany(p => p.TradeFills)
                .HasForeignKey(d => d.TradeId)
                .HasConstraintName("FK_TradeFill_Trade");
        });

        modelBuilder.Entity<VwDailyBookedTrade>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwDailyBookedTrade", "trd");

            entity.Property(e => e.AvgPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.BookedOn).HasColumnType("datetime");
            entity.Property(e => e.BrokerCode).HasMaxLength(10);
            entity.Property(e => e.BrokerCommission).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.BuySellIndicator)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CommissionRate).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DayAveragePrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.EmsxOrderCreatedOn).HasColumnType("date");
            entity.Property(e => e.ExchangeCode).HasMaxLength(20);
            entity.Property(e => e.ExecutionChannel).HasMaxLength(10);
            entity.Property(e => e.FxCurrency1)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FxCurrency2)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Fxcurrency1Amount)
                .HasColumnType("decimal(24, 6)")
                .HasColumnName("FXCurrency1Amount");
            entity.Property(e => e.Fxcurrency2Amount)
                .HasColumnType("decimal(24, 6)")
                .HasColumnName("FXCurrency2Amount");
            entity.Property(e => e.InstrumentType).HasMaxLength(10);
            entity.Property(e => e.MiscFees).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.NetAmount).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Notes).HasMaxLength(300);
            entity.Property(e => e.Principal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Sedol).HasMaxLength(7);
            entity.Property(e => e.SettlementCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SettlementDate).HasColumnType("date");
            entity.Property(e => e.Symbol).HasMaxLength(30);
            entity.Property(e => e.TotalCharges).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.TradeCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TradeDate).HasColumnType("date");
            entity.Property(e => e.TradeDesk).HasMaxLength(10);
            entity.Property(e => e.TradeStatus).HasMaxLength(5);
            entity.Property(e => e.Trader).HasMaxLength(30);
        });

        modelBuilder.Entity<VwEfrpTrade>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwEfrpTrade", "trd");

            entity.Property(e => e.BuySellIndicator).HasMaxLength(1);
            entity.Property(e => e.Ccy2Amt)
                .HasColumnType("decimal(38, 8)")
                .HasColumnName("Ccy2_Amt");
            entity.Property(e => e.Currency).HasMaxLength(50);
            entity.Property(e => e.Exchange).HasMaxLength(50);
            entity.Property(e => e.FuturePointValue).HasColumnType("decimal(14, 6)");
            entity.Property(e => e.InstrumentCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SpotRate).HasColumnName("Spot_Rate");
            entity.Property(e => e.Symbol).HasMaxLength(30);
            entity.Property(e => e.TradeDate)
                .HasColumnType("date")
                .HasColumnName("Trade_Date");
        });

        modelBuilder.Entity<VwEfrpTradeToBook>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwEfrpTradeToBook", "trd");

            entity.Property(e => e.Account).HasMaxLength(50);
            entity.Property(e => e.BrokerCode)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.CommissionRate).HasColumnType("decimal(8, 6)");
            entity.Property(e => e.ExchangeCode).HasMaxLength(50);
            entity.Property(e => e.ExecutionChannel)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.Notes)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.PositionSide).HasMaxLength(2);
            entity.Property(e => e.SettlementCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SettlementDate).HasColumnType("date");
            entity.Property(e => e.Side).HasMaxLength(1);
            entity.Property(e => e.Symbol).HasMaxLength(30);
            entity.Property(e => e.TradeCurrency).HasMaxLength(50);
            entity.Property(e => e.TradeDate).HasColumnType("date");
            entity.Property(e => e.TradeDesk)
                .HasMaxLength(4)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwEmsxTradeReconciliation>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwEmsxTradeReconciliation", "trd");

            entity.Property(e => e.BookedCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.BookedPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.BookedSymbol).HasMaxLength(30);
            entity.Property(e => e.BookedTradeDate).HasColumnType("date");
            entity.Property(e => e.EmsxCurrency).HasMaxLength(50);
            entity.Property(e => e.EmsxPrice).HasMaxLength(50);
            entity.Property(e => e.EmsxSymbol).HasMaxLength(50);
            entity.Property(e => e.EmsxTradeDate).HasMaxLength(50);
            entity.Property(e => e.PriceDiff).HasColumnType("decimal(19, 6)");
        });

        modelBuilder.Entity<VwEmsxTradeToBook>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwEmsxTradeToBook", "trd");

            entity.Property(e => e.Account).HasMaxLength(20);
            entity.Property(e => e.AvgPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Broker).HasMaxLength(30);
            entity.Property(e => e.BrokerCommm).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.CommPerLot).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.CommRate).HasColumnType("decimal(8, 6)");
            entity.Property(e => e.CommmRate).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DayAvgPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.EmsxDate).HasColumnType("date");
            entity.Property(e => e.EmsxOrderRefId).HasMaxLength(30);
            entity.Property(e => e.ExchangeCode).HasMaxLength(5);
            entity.Property(e => e.ExecutionChannel)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.HandInstruction).HasMaxLength(10);
            entity.Property(e => e.MiscFees).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.NetAmount).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.Notes).HasMaxLength(300);
            entity.Property(e => e.OrderType).HasMaxLength(10);
            entity.Property(e => e.PositionSide)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Principal).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.Sedol).HasMaxLength(7);
            entity.Property(e => e.SettleCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SettleDate).HasColumnType("date");
            entity.Property(e => e.Side).HasMaxLength(1);
            entity.Property(e => e.Strategy).HasMaxLength(10);
            entity.Property(e => e.Symbol).HasMaxLength(30);
            entity.Property(e => e.TimeInForce).HasMaxLength(10);
            entity.Property(e => e.TotalCharges).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.TradeCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TradeDate).HasColumnType("date");
            entity.Property(e => e.Trader).HasMaxLength(30);
        });

        modelBuilder.Entity<VwEmsxTradeToBookBackup>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwEmsxTradeToBook_Backup", "trd");

            entity.Property(e => e.Account).HasMaxLength(20);
            entity.Property(e => e.AvgPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Broker).HasMaxLength(30);
            entity.Property(e => e.BrokerCommm).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.CommPerLot).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.CommRate).HasColumnType("decimal(8, 6)");
            entity.Property(e => e.CommmRate).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DayAvgPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.EmsxDate).HasColumnType("date");
            entity.Property(e => e.EmsxOrderRefId).HasMaxLength(30);
            entity.Property(e => e.ExchangeCode).HasMaxLength(5);
            entity.Property(e => e.ExecutionChannel)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.HandInstruction).HasMaxLength(10);
            entity.Property(e => e.MiscFees).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.NetAmount).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.Notes).HasMaxLength(300);
            entity.Property(e => e.OrderType).HasMaxLength(10);
            entity.Property(e => e.PositionSide)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Principal).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.Sedol).HasMaxLength(7);
            entity.Property(e => e.SettleCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SettleDate).HasColumnType("date");
            entity.Property(e => e.Side).HasMaxLength(1);
            entity.Property(e => e.Strategy).HasMaxLength(10);
            entity.Property(e => e.Symbol).HasMaxLength(30);
            entity.Property(e => e.TimeInForce).HasMaxLength(10);
            entity.Property(e => e.TotalCharges).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.TradeCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TradeDate).HasColumnType("date");
            entity.Property(e => e.Trader).HasMaxLength(30);
        });

        modelBuilder.Entity<VwFutureCommission>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwFutureCommission", "trd");

            entity.Property(e => e.BrokerCode).HasMaxLength(10);
            entity.Property(e => e.CommPerLot).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.CommRate).HasColumnType("decimal(8, 6)");
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ExecDeskCommPerLot).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.ExecDeskCommRate).HasColumnType("decimal(8, 6)");
            entity.Property(e => e.InstrumentType).HasMaxLength(10);
            entity.Property(e => e.Symbol).HasMaxLength(30);
        });

        modelBuilder.Entity<VwFutureSwap>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwFutureSwap", "trd");

            entity.Property(e => e.SettlementCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Symbol).HasMaxLength(30);
        });

        modelBuilder.Entity<VwFxemTradeToBook>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwFxemTradeToBook", "trd");

            entity.Property(e => e.Account).HasMaxLength(50);
            entity.Property(e => e.AmountCcy1)
                .HasColumnType("decimal(24, 6)")
                .HasColumnName("Amount_Ccy1");
            entity.Property(e => e.AmountCcy2)
                .HasColumnType("decimal(24, 6)")
                .HasColumnName("Amount_Ccy2");
            entity.Property(e => e.AvgPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.BrokerCode).HasMaxLength(50);
            entity.Property(e => e.BuySellIndicator).HasMaxLength(1);
            entity.Property(e => e.Ccy1).HasMaxLength(50);
            entity.Property(e => e.Ccy2).HasMaxLength(50);
            entity.Property(e => e.EmsxOrderCreatedOn).HasColumnType("date");
            entity.Property(e => e.ExecutionChannel)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.FilledQuantity).HasColumnType("decimal(24, 6)");
            entity.Property(e => e.FxemOrderId).HasMaxLength(50);
            entity.Property(e => e.FxemTradeId).HasMaxLength(50);
            entity.Property(e => e.NetAmount).HasColumnType("decimal(24, 6)");
            entity.Property(e => e.OrderQuantity).HasColumnType("decimal(24, 6)");
            entity.Property(e => e.PositionSide).HasMaxLength(50);
            entity.Property(e => e.Principal).HasColumnType("decimal(24, 6)");
            entity.Property(e => e.SettlementDate).HasColumnType("date");
            entity.Property(e => e.TradeCurrency).HasMaxLength(50);
            entity.Property(e => e.TradeDate)
                .HasColumnType("date")
                .HasColumnName("Trade_Date");
            entity.Property(e => e.TradeDesk).HasMaxLength(50);
            entity.Property(e => e.Trader).HasMaxLength(50);
        });

        modelBuilder.Entity<VwMsefrpFutureTradeAffirm>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwMSEfrpFutureTradeAffirm", "trd");

            entity.Property(e => e.Account).HasMaxLength(50);
            entity.Property(e => e.Ccy1).HasMaxLength(50);
            entity.Property(e => e.Ccy1Amt)
                .HasMaxLength(50)
                .HasColumnName("Ccy1_Amt");
            entity.Property(e => e.Ccy1Side)
                .HasMaxLength(50)
                .HasColumnName("Ccy1_Side");
            entity.Property(e => e.Ccy2).HasMaxLength(50);
            entity.Property(e => e.Ccy2Amt)
                .HasColumnType("decimal(38, 6)")
                .HasColumnName("Ccy2_Amt");
            entity.Property(e => e.DealEntryTime)
                .HasMaxLength(50)
                .HasColumnName("Deal_Entry_Time");
            entity.Property(e => e.DealId)
                .HasMaxLength(50)
                .HasColumnName("Deal_ID");
            entity.Property(e => e.EntryUser)
                .HasMaxLength(50)
                .HasColumnName("Entry_User");
            entity.Property(e => e.LastUpdateTime)
                .HasMaxLength(50)
                .HasColumnName("Last_Update_Time");
            entity.Property(e => e.SpotRate)
                .HasColumnType("decimal(38, 6)")
                .HasColumnName("Spot_Rate");
            entity.Property(e => e.TradeDate)
                .HasMaxLength(50)
                .HasColumnName("Trade_Date");
            entity.Property(e => e.Type).HasMaxLength(50);
            entity.Property(e => e.ValueDate)
                .HasMaxLength(50)
                .HasColumnName("Value_Date");
        });

        modelBuilder.Entity<VwTrade>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwTrade", "trd");

            entity.Property(e => e.AvgPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.BookedOn).HasColumnType("datetime");
            entity.Property(e => e.BrokerCode).HasMaxLength(10);
            entity.Property(e => e.BrokerCommission).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.BuySellIndicator)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CommissionRate).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DayAveragePrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.EmsxOrderCreatedOn).HasColumnType("date");
            entity.Property(e => e.ExchangeCode).HasMaxLength(20);
            entity.Property(e => e.ExecutionChannel).HasMaxLength(10);
            entity.Property(e => e.FxCurrency1)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FxCurrency2)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Fxcurrency1Amount)
                .HasColumnType("decimal(24, 6)")
                .HasColumnName("FXCurrency1Amount");
            entity.Property(e => e.Fxcurrency2Amount)
                .HasColumnType("decimal(24, 6)")
                .HasColumnName("FXCurrency2Amount");
            entity.Property(e => e.InstrumentType).HasMaxLength(10);
            entity.Property(e => e.MiscFees).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.NetAmount).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Notes).HasMaxLength(300);
            entity.Property(e => e.Principal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Sedol).HasMaxLength(7);
            entity.Property(e => e.SettlementCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SettlementDate).HasColumnType("date");
            entity.Property(e => e.Symbol).HasMaxLength(30);
            entity.Property(e => e.TotalCharges).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.TradeCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TradeDate).HasColumnType("date");
            entity.Property(e => e.TradeDesk).HasMaxLength(10);
            entity.Property(e => e.TradeStatus).HasMaxLength(5);
            entity.Property(e => e.Trader).HasMaxLength(30);
        });

        modelBuilder.Entity<VwTradeAllocation>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwTradeAllocation", "trd");

            entity.Property(e => e.AllocationCommission).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.AllocationFees).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.AllocationGrossAmount).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.AllocationNetAmount).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.AvgPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.BookedOn).HasColumnType("datetime");
            entity.Property(e => e.BrokerCode).HasMaxLength(10);
            entity.Property(e => e.BrokerCommission).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.BuySellIndicator)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CommissionRate).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DayAveragePrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.EmsxOrderCreatedOn).HasColumnType("date");
            entity.Property(e => e.ExchangeCode).HasMaxLength(20);
            entity.Property(e => e.ExecutionChannel).HasMaxLength(10);
            entity.Property(e => e.FxCurrency1)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FxCurrency2)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Fxcurrency1Amount)
                .HasColumnType("decimal(24, 6)")
                .HasColumnName("FXCurrency1Amount");
            entity.Property(e => e.Fxcurrency2Amount)
                .HasColumnType("decimal(24, 6)")
                .HasColumnName("FXCurrency2Amount");
            entity.Property(e => e.InstrumentType).HasMaxLength(10);
            entity.Property(e => e.MiscFees).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.NetAmount).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Notes).HasMaxLength(300);
            entity.Property(e => e.PositionSide)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Price).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Principal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Sedol).HasMaxLength(7);
            entity.Property(e => e.SettlementCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SettlementDate).HasColumnType("date");
            entity.Property(e => e.Symbol).HasMaxLength(30);
            entity.Property(e => e.TotalCharges).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.TradeCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TradeDate).HasColumnType("date");
            entity.Property(e => e.TradeDesk).HasMaxLength(10);
            entity.Property(e => e.TradeStatus).HasMaxLength(5);
            entity.Property(e => e.Trader).HasMaxLength(30);
            entity.Property(e => e.TradingAccount).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
