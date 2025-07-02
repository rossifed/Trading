using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;

public partial class BookingDbContext : DbContext
{
    public BookingDbContext()
    {
    }

    public BookingDbContext(DbContextOptions<BookingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ClearingAccount> ClearingAccounts { get; set; }

    public virtual DbSet<CommissionSchedule> CommissionSchedules { get; set; }

    public virtual DbSet<CommissionType> CommissionTypes { get; set; }

    public virtual DbSet<Counterparty> Counterparties { get; set; }

    public virtual DbSet<CounterpartyRoleAssignment> CounterpartyRoleAssignments { get; set; }

    public virtual DbSet<CounterpartyRoleSetup> CounterpartyRoleSetups { get; set; }

    public virtual DbSet<ExecutionDesk> ExecutionDesks { get; set; }

    public virtual DbSet<ExecutionType> ExecutionTypes { get; set; }

    public virtual DbSet<ExecutionTypeMapping> ExecutionTypeMappings { get; set; }

    public virtual DbSet<FutureSwap> FutureSwaps { get; set; }

    public virtual DbSet<FxRate> FxRates { get; set; }

    public virtual DbSet<Instrument> Instruments { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderAllocation> OrderAllocations { get; set; }

    public virtual DbSet<Portfolio> Portfolios { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<RawTrade> RawTrades { get; set; }

    public virtual DbSet<RawTradeAllocation> RawTradeAllocations { get; set; }

    public virtual DbSet<SettlementInfo> SettlementInfos { get; set; }

    public virtual DbSet<Trade> Trades { get; set; }

    public virtual DbSet<TradeAllocation> TradeAllocations { get; set; }

    public virtual DbSet<TradeBookingError> TradeBookingErrors { get; set; }

    public virtual DbSet<TradeInstrumentType> TradeInstrumentTypes { get; set; }

    public virtual DbSet<VwClearingAccount> VwClearingAccounts { get; set; }

    public virtual DbSet<VwCommissionSchedule> VwCommissionSchedules { get; set; }

    public virtual DbSet<VwDailyBookedTrade> VwDailyBookedTrades { get; set; }

    public virtual DbSet<VwFutureOnSwap> VwFutureOnSwaps { get; set; }

    public virtual DbSet<VwNonAllocatedTrade> VwNonAllocatedTrades { get; set; }

    public virtual DbSet<VwNonBookedTrade> VwNonBookedTrades { get; set; }

    public virtual DbSet<VwSettlementInfo> VwSettlementInfos { get; set; }

    public virtual DbSet<VwTradeAllocation> VwTradeAllocations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=TradingDatabase");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CS_AS");

        modelBuilder.Entity<ClearingAccount>(entity =>
        {
            entity
                .ToTable("ClearingAccount", "book")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("H_ClearingAccount", "book");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasIndex(e => new { e.PortfolioId, e.TradeInstrumentTypeId, e.ClearingBrokerId }, "UC_ClearingAccount").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(12);
            entity.Property(e => e.Description).HasMaxLength(200);

            entity.HasOne(d => d.ClearingBroker).WithMany(p => p.ClearingAccounts)
                .HasForeignKey(d => d.ClearingBrokerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClearingAccount_Counterparty");

            entity.HasOne(d => d.TradeInstrumentType).WithMany(p => p.ClearingAccounts)
                .HasForeignKey(d => d.TradeInstrumentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClearingAccount_TradeInstrumentType");
        });

        modelBuilder.Entity<CommissionSchedule>(entity =>
        {
            entity
                .ToTable("CommissionSchedule", "book")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("H_CommissionSchedule", "book");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasIndex(e => new { e.InstrumentId, e.ExecutionBrokerId, e.CounterpartyRoleSetupId, e.ExecutionTypeId }, "UC_CommissionSchedule").IsUnique();

            entity.Property(e => e.CommissionValue).HasColumnType("decimal(18, 6)");

            entity.HasOne(d => d.CommissionType).WithMany(p => p.CommissionSchedules)
                .HasForeignKey(d => d.CommissionTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CommissionSchedule_CommissionType");

            entity.HasOne(d => d.CounterpartyRoleSetup).WithMany(p => p.CommissionSchedules)
                .HasForeignKey(d => d.CounterpartyRoleSetupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CommissionSchedule_CounterpartyRoleSetup");

            entity.HasOne(d => d.ExecutionBroker).WithMany(p => p.CommissionSchedules)
                .HasForeignKey(d => d.ExecutionBrokerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CommissionSchedule_ExecutionBroker");

            entity.HasOne(d => d.ExecutionType).WithMany(p => p.CommissionSchedules)
                .HasForeignKey(d => d.ExecutionTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CommissionSchedule_ExecutionType");

            entity.HasOne(d => d.Instrument).WithMany(p => p.CommissionSchedules)
                .HasForeignKey(d => d.InstrumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CommissionSchedule_Instrument");
        });

        modelBuilder.Entity<CommissionType>(entity =>
        {
            entity
                .ToTable("CommissionType", "book")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("H_CommissionType", "book");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasIndex(e => e.Code, "UC_CommissionTypeCode").IsUnique();

            entity.Property(e => e.Code)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<Counterparty>(entity =>
        {
            entity
                .ToTable("Counterparty", "book")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("H_Counterparty", "book");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasIndex(e => e.Code, "UC_CounterpartyCode").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(6);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<CounterpartyRoleAssignment>(entity =>
        {
            entity
                .ToTable("CounterpartyRoleAssignment", "book")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("H_CounterpartyRoleAssignment", "book");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasIndex(e => new { e.PortfolioId, e.InstrumentId, e.ExecutionBrokerId }, "UC_CounterpartyRoleAssignment").IsUnique();

            entity.HasOne(d => d.CounterpartyRoleSetup).WithMany(p => p.CounterpartyRoleAssignments)
                .HasForeignKey(d => d.CounterpartyRoleSetupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CounterpartyRoleAssignment_CounterpartyRoleSetup");

            entity.HasOne(d => d.ExecutionBroker).WithMany(p => p.CounterpartyRoleAssignments)
                .HasForeignKey(d => d.ExecutionBrokerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CounterpartyRoleAssignment_ExecutionBroker");

            entity.HasOne(d => d.Instrument).WithMany(p => p.CounterpartyRoleAssignments)
                .HasForeignKey(d => d.InstrumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CounterpartyRoleAssignment_Instrument");
        });

        modelBuilder.Entity<CounterpartyRoleSetup>(entity =>
        {
            entity
                .ToTable("CounterpartyRoleSetup", "book")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("H_CounterpartyRoleSetup", "book");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasIndex(e => new { e.ClearingBrokerId, e.PrimeBrokerId, e.CustodianId }, "UC_CounterpartyRoleSetup").IsUnique();

            entity.HasOne(d => d.ClearingBroker).WithMany(p => p.CounterpartyRoleSetupClearingBrokers)
                .HasForeignKey(d => d.ClearingBrokerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CounterpartyRoleSetup_ClearingBroker");

            entity.HasOne(d => d.Custodian).WithMany(p => p.CounterpartyRoleSetupCustodians)
                .HasForeignKey(d => d.CustodianId)
                .HasConstraintName("FK_CounterpartyRoleSetup_Custodian");

            entity.HasOne(d => d.PrimeBroker).WithMany(p => p.CounterpartyRoleSetupPrimeBrokers)
                .HasForeignKey(d => d.PrimeBrokerId)
                .HasConstraintName("FK_CounterpartyRoleSetup_PrimeBroker");
        });

        modelBuilder.Entity<ExecutionDesk>(entity =>
        {
            entity
                .ToTable("ExecutionDesk", "book")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("H_ExecutionDesk", "book");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasIndex(e => e.Code, "UC_ExecutionDeskCode").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(6);
            entity.Property(e => e.Description).HasMaxLength(200);

            entity.HasOne(d => d.ExecutionBroker).WithMany(p => p.ExecutionDesks)
                .HasForeignKey(d => d.ExecutionBrokerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExecutionDesk_ExecutionBroker");
        });

        modelBuilder.Entity<ExecutionType>(entity =>
        {
            entity
                .ToTable("ExecutionType", "book")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("H_ExecutionType", "book");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasIndex(e => e.Code, "UC_ExecutionTypeCode").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(5);
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<ExecutionTypeMapping>(entity =>
        {
            entity.HasKey(e => new { e.ExecutionDeskId, e.Strategy });

            entity
                .ToTable("ExecutionTypeMapping", "book")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("H_ExecutionTypeMapping", "book");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.Strategy).HasMaxLength(15);

            entity.HasOne(d => d.ExecutionDesk).WithMany(p => p.ExecutionTypeMappings)
                .HasForeignKey(d => d.ExecutionDeskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExecutionTypeMapping_ExecutionDesk");

            entity.HasOne(d => d.ExecutionType).WithMany(p => p.ExecutionTypeMappings)
                .HasForeignKey(d => d.ExecutionTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExecutionTypeMapping_ExecutionType");
        });

        modelBuilder.Entity<FutureSwap>(entity =>
        {
            entity.HasKey(e => new { e.ExecutionBrokerId, e.GenericFutureId });

            entity
                .ToTable("FutureSwap", "book")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("H_FutureSwap", "book");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasOne(d => d.ExecutionBroker).WithMany(p => p.FutureSwaps)
                .HasForeignKey(d => d.ExecutionBrokerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FutureSwap_ExecutionBroker");
        });

        modelBuilder.Entity<FxRate>(entity =>
        {
            entity.HasKey(e => new { e.BaseCurrency, e.QuoteCurrency, e.Date });

            entity.ToTable("FxRate", "book");

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

        modelBuilder.Entity<Instrument>(entity =>
        {
            entity.HasKey(e => e.InstrumentId).HasName("PK_InstrumentId");

            entity.ToTable("Instrument", "book");

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

            entity.HasOne(d => d.GenericFuture).WithMany(p => p.InverseGenericFuture)
                .HasForeignKey(d => d.GenericFutureId)
                .HasConstraintName("FK_Instrument_GenericFuture");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order", "book");

            entity.Property(e => e.OrderId).ValueGeneratedNever();
            entity.Property(e => e.ExecutionAccount).HasMaxLength(10);
            entity.Property(e => e.ExecutionAlgo).HasMaxLength(10);
            entity.Property(e => e.ExecutionDesk).HasMaxLength(10);
            entity.Property(e => e.OrderType).HasMaxLength(10);
            entity.Property(e => e.Symbol).HasMaxLength(100);
            entity.Property(e => e.TimeInForce).HasMaxLength(10);
            entity.Property(e => e.TradeDate).HasColumnType("date");
            entity.Property(e => e.TradeMode).HasMaxLength(10);
        });

        modelBuilder.Entity<OrderAllocation>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.PortfolioId });

            entity.ToTable("OrderAllocation", "book");

            entity.Property(e => e.PositionSide).HasMaxLength(2);

            entity.HasOne(d => d.Order).WithMany(p => p.OrderAllocations)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_OrderAllocation_Order");
        });

        modelBuilder.Entity<Portfolio>(entity =>
        {
            entity.HasKey(e => e.PortfolioId).HasName("PK_PortfolioId");

            entity.ToTable("Portfolio", "book");

            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Mnemonic).HasMaxLength(6);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => new { e.PortfolioId, e.InstrumentId });

            entity.ToTable("Position", "book");

            entity.Property(e => e.PositionDate).HasColumnType("date");

            entity.HasOne(d => d.Instrument).WithMany(p => p.Positions)
                .HasForeignKey(d => d.InstrumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Position_Instrument");

            entity.HasOne(d => d.Portfolio).WithMany(p => p.Positions)
                .HasForeignKey(d => d.PortfolioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Position_Portfolio");
        });

        modelBuilder.Entity<RawTrade>(entity =>
        {
            entity.HasKey(e => e.TradeId);

            entity
                .ToTable("RawTrade", "book")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("H_RawTrade", "book");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.AvgPrice).HasColumnType("decimal(20, 8)");
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Cusip).HasMaxLength(10);
            entity.Property(e => e.Exchange).HasMaxLength(5);
            entity.Property(e => e.ExecutionAccount).HasMaxLength(10);
            entity.Property(e => e.ExecutionBroker).HasMaxLength(10);
            entity.Property(e => e.ExecutionChannel).HasMaxLength(10);
            entity.Property(e => e.ExecutionDesk).HasMaxLength(10);
            entity.Property(e => e.FirstFillTimeUtc).HasColumnType("datetime");
            entity.Property(e => e.IsCfd).HasColumnName("IsCFD");
            entity.Property(e => e.Isin).HasMaxLength(12);
            entity.Property(e => e.LastFillTimeUtc).HasColumnType("datetime");
            entity.Property(e => e.LimitPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.LocalExchangeSymbol).HasMaxLength(20);
            entity.Property(e => e.MaxFillPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.MinFillPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.OrderExecutionInstruction).HasMaxLength(100);
            entity.Property(e => e.OrderHandlingInstruction).HasMaxLength(100);
            entity.Property(e => e.OrderInstruction).HasMaxLength(100);
            entity.Property(e => e.OrderType).HasMaxLength(20);
            entity.Property(e => e.OriginatingTraderUuid).HasColumnName("OriginatingTraderUUId");
            entity.Property(e => e.SecurityName).HasMaxLength(100);
            entity.Property(e => e.Sedol).HasMaxLength(20);
            entity.Property(e => e.SettlementDate).HasColumnType("date");
            entity.Property(e => e.Side).HasMaxLength(10);
            entity.Property(e => e.StopPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.StrategyType).HasMaxLength(10);
            entity.Property(e => e.Symbol).HasMaxLength(30);
            entity.Property(e => e.Tif).HasMaxLength(10);
            entity.Property(e => e.TradeDate).HasColumnType("date");
            entity.Property(e => e.TraderName).HasMaxLength(20);
            entity.Property(e => e.TraderUuid).HasColumnName("TraderUUId");
            entity.Property(e => e.UserCommissionAmount).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.UserCommissionRate).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.UserFees).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.UserNetMoney).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.YellowKey).HasMaxLength(10);
        });

        modelBuilder.Entity<RawTradeAllocation>(entity =>
        {
            entity.HasKey(e => e.TradeAllocationId);

            entity
                .ToTable("RawTradeAllocation", "book")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("H_RawTradeAllocation", "book");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasIndex(e => new { e.TradeId, e.PortfolioId }, "UC_RawTradeAllocation").IsUnique();

            entity.Property(e => e.PositionSide)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Trade).WithMany(p => p.RawTradeAllocations)
                .HasForeignKey(d => d.TradeId)
                .HasConstraintName("FK_RawTradeAllocation_RawTrade");
        });

        modelBuilder.Entity<SettlementInfo>(entity =>
        {
            entity.HasKey(e => new { e.CounterpartyId, e.InstrumentId, e.IsSwap });

            entity
                .ToTable("SettlementInfo", "book")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("H_SettlementInfo", "book");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.SettleCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Counterparty).WithMany(p => p.SettlementInfos)
                .HasForeignKey(d => d.CounterpartyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SettlementInfo_Counterparty");

            entity.HasOne(d => d.Instrument).WithMany(p => p.SettlementInfos)
                .HasForeignKey(d => d.InstrumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SettlementInfo_Instrument");
        });

        modelBuilder.Entity<Trade>(entity =>
        {
            entity
                .ToTable("Trade", "book")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("H_Trade", "book");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.TradeId).ValueGeneratedNever();
            entity.Property(e => e.AvgPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.ContractMultiplier).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Cusip).HasMaxLength(10);
            entity.Property(e => e.Exchange).HasMaxLength(5);
            entity.Property(e => e.ExecutionAccount).HasMaxLength(20);
            entity.Property(e => e.ExecutionBroker).HasMaxLength(5);
            entity.Property(e => e.ExecutionChannel).HasMaxLength(10);
            entity.Property(e => e.ExecutionDesk).HasMaxLength(6);
            entity.Property(e => e.ExecutionType).HasMaxLength(5);
            entity.Property(e => e.FirstFillTimeUtc).HasColumnType("datetime");
            entity.Property(e => e.InstrumentType).HasMaxLength(8);
            entity.Property(e => e.Isin).HasMaxLength(12);
            entity.Property(e => e.LastFillTimeUtc).HasColumnType("datetime");
            entity.Property(e => e.LimitPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.LocalExchangeSymbol).HasMaxLength(20);
            entity.Property(e => e.MaxFillPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.MinFillPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.NominalQuantity).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.OrderExecutionInstruction).HasMaxLength(100);
            entity.Property(e => e.OrderHandlingInstruction).HasMaxLength(100);
            entity.Property(e => e.OrderInstruction).HasMaxLength(100);
            entity.Property(e => e.OrderType).HasMaxLength(20);
            entity.Property(e => e.OriginatingTraderUuid).HasColumnName("OriginatingTraderUUId");
            entity.Property(e => e.PriceScalingFactor).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.Principal).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.SecurityName).HasMaxLength(100);
            entity.Property(e => e.Sedol).HasMaxLength(20);
            entity.Property(e => e.SettlementDate).HasColumnType("date");
            entity.Property(e => e.StopPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.StrategyType).HasMaxLength(10);
            entity.Property(e => e.Symbol).HasMaxLength(30);
            entity.Property(e => e.TimeInForce).HasMaxLength(10);
            entity.Property(e => e.TradeCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TradeDate).HasColumnType("date");
            entity.Property(e => e.TradeInstrumentType).HasMaxLength(8);
            entity.Property(e => e.TradeSide).HasMaxLength(10);
            entity.Property(e => e.TradeStatus)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TradeValue).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.TraderName).HasMaxLength(20);
            entity.Property(e => e.TraderUuid).HasColumnName("TraderUUId");
            entity.Property(e => e.UserCommissionAmount).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.UserCommissionRate).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.UserFees).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.UserNetMoney).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.YellowKey).HasMaxLength(10);
        });

        modelBuilder.Entity<TradeAllocation>(entity =>
        {
            entity
                .ToTable("TradeAllocation", "book")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("H_TradeAllocation", "book");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasIndex(e => new { e.TradeId, e.PortfolioId }, "UC_TradeAllocation").IsUnique();

            entity.Property(e => e.TradeAllocationId).ValueGeneratedNever();
            entity.Property(e => e.BaseCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ClearingAccount).HasMaxLength(20);
            entity.Property(e => e.ClearingBroker).HasMaxLength(6);
            entity.Property(e => e.CommissionAmountBase).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.CommissionAmountLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.CommissionAmountSettle).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.CommissionType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CommissionValue).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.ContractMultiplier).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Custodian).HasMaxLength(6);
            entity.Property(e => e.GrossAvgPriceBase).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.GrossAvgPriceLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.GrossAvgPriceSettle).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.GrossPrincipalBase).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.GrossPrincipalLocal).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.GrossPrincipalSettle).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.GrossTradeValueBase).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.GrossTradeValueLocal).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.GrossTradeValueSettle).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.LocalCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LocalToBaseFxRate).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.LocalToSettleFxRate).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.MiscFeesBase).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.MiscFeesLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.MiscFeesSettle).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.NetAvgPriceBase).HasColumnType("decimal(18, 8)");
            entity.Property(e => e.NetAvgPriceLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.NetAvgPriceSettle).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.NetPrincipalBase).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.NetPrincipalLocal).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.NetPrincipalSettle).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.NetTradeValueBase).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.NetTradeValueLocal).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.NetTradeValueSettle).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.NominalQuantity).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.OrderAllocationNominalQuantity).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PositionSide)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PriceCommissionBase).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PriceCommissionLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PriceCommissionSettle).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PrimeBroker).HasMaxLength(6);
            entity.Property(e => e.SettlementCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SettlementDate).HasColumnType("date");
            entity.Property(e => e.TradeStatus)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Trade).WithMany(p => p.TradeAllocations)
                .HasForeignKey(d => d.TradeId)
                .HasConstraintName("FK_TradeAllocation_Trade");
        });

        modelBuilder.Entity<TradeBookingError>(entity =>
        {
            entity.ToTable("TradeBookingError", "book");

            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.ErrorType).HasMaxLength(20);
            entity.Property(e => e.Message).HasMaxLength(500);

            entity.HasOne(d => d.Trade).WithMany(p => p.TradeBookingErrors)
                .HasForeignKey(d => d.TradeId)
                .HasConstraintName("FK_TradeBookingError_RawTrade");
        });

        modelBuilder.Entity<TradeInstrumentType>(entity =>
        {
            entity
                .ToTable("TradeInstrumentType", "book")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("H_TradeInstrumentType", "book");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasIndex(e => new { e.IsSwap, e.InstrumentType }, "UC_InstrumentTypeIsSwap").IsUnique();

            entity.HasIndex(e => e.Mnemonic, "UC_TradeInstrumentTypeMnemonic").IsUnique();

            entity.Property(e => e.TradeInstrumentTypeId).ValueGeneratedNever();
            entity.Property(e => e.InstrumentType).HasMaxLength(10);
            entity.Property(e => e.Mnemonic).HasMaxLength(8);
            entity.Property(e => e.Name).HasMaxLength(200);
        });

        modelBuilder.Entity<VwClearingAccount>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwClearingAccount", "book");

            entity.Property(e => e.ClearingAccount).HasMaxLength(12);
            entity.Property(e => e.ClearingBroker).HasMaxLength(6);
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.PortfolioMnemonic).HasMaxLength(6);
            entity.Property(e => e.TradeInstrumentType).HasMaxLength(200);
        });

        modelBuilder.Entity<VwCommissionSchedule>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwCommissionSchedule", "book");

            entity.Property(e => e.ClearingBroker).HasMaxLength(6);
            entity.Property(e => e.CommissionType).HasMaxLength(20);
            entity.Property(e => e.CommissionValue).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Custodian).HasMaxLength(6);
            entity.Property(e => e.ExecutionBroker).HasMaxLength(6);
            entity.Property(e => e.ExecutionType).HasMaxLength(20);
            entity.Property(e => e.PrimeBroker).HasMaxLength(6);
            entity.Property(e => e.Symbol).HasMaxLength(30);
        });

        modelBuilder.Entity<VwDailyBookedTrade>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwDailyBookedTrades", "book");

            entity.Property(e => e.AvgPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.ContractMultiplier).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Cusip).HasMaxLength(10);
            entity.Property(e => e.Exchange).HasMaxLength(5);
            entity.Property(e => e.ExecutionAccount).HasMaxLength(20);
            entity.Property(e => e.ExecutionBroker).HasMaxLength(5);
            entity.Property(e => e.ExecutionChannel).HasMaxLength(10);
            entity.Property(e => e.ExecutionDesk).HasMaxLength(6);
            entity.Property(e => e.ExecutionType).HasMaxLength(5);
            entity.Property(e => e.FirstFillTimeUtc).HasColumnType("datetime");
            entity.Property(e => e.InstrumentType).HasMaxLength(8);
            entity.Property(e => e.Isin).HasMaxLength(12);
            entity.Property(e => e.LastFillTimeUtc).HasColumnType("datetime");
            entity.Property(e => e.LimitPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.LocalExchangeSymbol).HasMaxLength(20);
            entity.Property(e => e.MaxFillPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.MinFillPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.NominalQuantity).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.OrderExecutionInstruction).HasMaxLength(100);
            entity.Property(e => e.OrderHandlingInstruction).HasMaxLength(100);
            entity.Property(e => e.OrderInstruction).HasMaxLength(100);
            entity.Property(e => e.OrderType).HasMaxLength(20);
            entity.Property(e => e.OriginatingTraderUuid).HasColumnName("OriginatingTraderUUId");
            entity.Property(e => e.PriceScalingFactor).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.Principal).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.SecurityName).HasMaxLength(100);
            entity.Property(e => e.Sedol).HasMaxLength(20);
            entity.Property(e => e.SettlementDate).HasColumnType("date");
            entity.Property(e => e.StopPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.StrategyType).HasMaxLength(10);
            entity.Property(e => e.Symbol).HasMaxLength(30);
            entity.Property(e => e.TimeInForce).HasMaxLength(10);
            entity.Property(e => e.TradeCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TradeDate).HasColumnType("date");
            entity.Property(e => e.TradeInstrumentType).HasMaxLength(8);
            entity.Property(e => e.TradeSide).HasMaxLength(10);
            entity.Property(e => e.TradeStatus)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TradeValue).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.TraderName).HasMaxLength(20);
            entity.Property(e => e.TraderUuid).HasColumnName("TraderUUId");
            entity.Property(e => e.UserCommissionAmount).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.UserCommissionRate).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.UserFees).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.UserNetMoney).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.YellowKey).HasMaxLength(10);
        });

        modelBuilder.Entity<VwFutureOnSwap>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwFutureOnSwap", "book");

            entity.Property(e => e.ExecutionBrokerCode).HasMaxLength(6);
            entity.Property(e => e.SettleCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Symbol).HasMaxLength(30);
        });

        modelBuilder.Entity<VwNonAllocatedTrade>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwNonAllocatedTrade", "book");

            entity.Property(e => e.Symbol).HasMaxLength(30);
            entity.Property(e => e.TradeDate).HasColumnType("date");
        });

        modelBuilder.Entity<VwNonBookedTrade>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwNonBookedTrade", "book");

            entity.Property(e => e.Symbol).HasMaxLength(30);
            entity.Property(e => e.TradeDate).HasColumnType("date");
        });

        modelBuilder.Entity<VwSettlementInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwSettlementInfo", "book");

            entity.Property(e => e.Counterparty).HasMaxLength(6);
            entity.Property(e => e.Exchange).HasMaxLength(5);
            entity.Property(e => e.InstrumentType).HasMaxLength(10);
            entity.Property(e => e.SettleCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Symbol).HasMaxLength(30);
        });

        modelBuilder.Entity<VwTradeAllocation>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwTradeAllocation", "book");

            entity.Property(e => e.BaseCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ClearingAccount).HasMaxLength(20);
            entity.Property(e => e.ClearingBroker)
                .HasMaxLength(6)
                .HasColumnName("CLearingBroker");
            entity.Property(e => e.CommissionAmountBase).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.CommissionAmountLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.CommissionAmountSettle).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.CommissionType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CommissionValue).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.ContractMultiplier).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Cusip).HasMaxLength(10);
            entity.Property(e => e.Custodian).HasMaxLength(6);
            entity.Property(e => e.Exchange).HasMaxLength(5);
            entity.Property(e => e.ExecutionAccount).HasMaxLength(20);
            entity.Property(e => e.ExecutionBroker).HasMaxLength(5);
            entity.Property(e => e.ExecutionChannel).HasMaxLength(10);
            entity.Property(e => e.ExecutionDesk).HasMaxLength(6);
            entity.Property(e => e.ExecutionType).HasMaxLength(5);
            entity.Property(e => e.FirstFillTimeUtc).HasColumnType("datetime");
            entity.Property(e => e.GrossAvgPriceBase).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.GrossAvgPriceLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.GrossAvgPriceSettle).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.GrossPrincipalBase).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.GrossPrincipalLocal).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.GrossPrincipalSettle).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.GrossTradeValueBase).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.GrossTradeValueLocal).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.GrossTradeValueSettle).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.InstrumentType).HasMaxLength(8);
            entity.Property(e => e.Isin).HasMaxLength(12);
            entity.Property(e => e.LastFillTimeUtc).HasColumnType("datetime");
            entity.Property(e => e.LimitPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.LocalCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LocalExchangeSymbol).HasMaxLength(20);
            entity.Property(e => e.LocalToBaseFxRate).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.LocalToSettleFxRate).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.MaxFillPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.MinFillPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.MiscFeesBase).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.MiscFeesLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.MiscFeesSettle).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.NetAvgPriceBase).HasColumnType("decimal(18, 8)");
            entity.Property(e => e.NetAvgPriceLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.NetAvgPriceSettle).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.NetPrincipalBase).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.NetPrincipalLocal).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.NetPrincipalSettle).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.NetTradeValueBase).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.NetTradeValueLocal).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.NetTradeValueSettle).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.NominalQuantity).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.OrderAllocationNominalQuantity).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.OrderExecutionInstruction).HasMaxLength(100);
            entity.Property(e => e.OrderHandlingInstruction).HasMaxLength(100);
            entity.Property(e => e.OrderInstruction).HasMaxLength(100);
            entity.Property(e => e.OrderType).HasMaxLength(20);
            entity.Property(e => e.OriginatingTraderUuid).HasColumnName("OriginatingTraderUUId");
            entity.Property(e => e.PositionSide)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PriceCommissionBase).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PriceCommissionLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PriceCommissionSettle).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PrimeBroker).HasMaxLength(6);
            entity.Property(e => e.SecurityName).HasMaxLength(100);
            entity.Property(e => e.Sedol).HasMaxLength(20);
            entity.Property(e => e.SettlementCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SettlementDate).HasColumnType("date");
            entity.Property(e => e.StopPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.StrategyType).HasMaxLength(10);
            entity.Property(e => e.Symbol).HasMaxLength(30);
            entity.Property(e => e.TimeInForce).HasMaxLength(10);
            entity.Property(e => e.TradeAvgPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.TradeCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TradeDate).HasColumnType("date");
            entity.Property(e => e.TradeInstrumentType).HasMaxLength(8);
            entity.Property(e => e.TradePrincipal).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.TradeSide).HasMaxLength(10);
            entity.Property(e => e.TradeStatus)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TradeValue).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.TraderName).HasMaxLength(20);
            entity.Property(e => e.TraderUuid).HasColumnName("TraderUUId");
            entity.Property(e => e.UserCommissionAmount).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.UserCommissionRate).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.UserFees).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.UserNetMoney).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.YellowKey).HasMaxLength(10);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
