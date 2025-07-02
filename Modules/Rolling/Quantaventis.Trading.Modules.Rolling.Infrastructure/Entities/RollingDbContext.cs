using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Quantaventis.Trading.Modules.Rolling.Infrastructure.Entities;

public partial class RollingDbContext : DbContext
{
    public RollingDbContext()
    {
    }

    public RollingDbContext(DbContextOptions<RollingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<FutureContract> FutureContracts { get; set; }

    public virtual DbSet<FutureCurrentContract> FutureCurrentContracts { get; set; }

    public virtual DbSet<FutureRollOrder> FutureRollOrders { get; set; }

    public virtual DbSet<FxForward> FxForwards { get; set; }

    public virtual DbSet<FxForwardRollOrder> FxForwardRollOrders { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<VwCompareCurrentContract> VwCompareCurrentContracts { get; set; }

    public virtual DbSet<VwFutureContractRollInfo> VwFutureContractRollInfos { get; set; }

    public virtual DbSet<VwFutureContractRollInfo2> VwFutureContractRollInfo2s { get; set; }

    public virtual DbSet<VwFutureContractRollInfoOld> VwFutureContractRollInfoOlds { get; set; }

    public virtual DbSet<VwFutureContractRollingPeriod> VwFutureContractRollingPeriods { get; set; }

    public virtual DbSet<VwFutureContractVolumeRank> VwFutureContractVolumeRanks { get; set; }

    public virtual DbSet<VwFutureCurrentContract> VwFutureCurrentContracts { get; set; }

    public virtual DbSet<VwFuturePositionRollInfo> VwFuturePositionRollInfos { get; set; }

    public virtual DbSet<VwFxForwardRollInfo> VwFxForwardRollInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=TradingDatabase");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CS_AS");

        modelBuilder.Entity<FutureContract>(entity =>
        {
            entity.HasKey(e => e.FutureContractId).HasName("PK_FutureContractId");

            entity.ToTable("FutureContract", "roll");

            entity.Property(e => e.FutureContractId).ValueGeneratedNever();
            entity.Property(e => e.FirstDeliveryDate).HasColumnType("date");
            entity.Property(e => e.FirstNoticeDate).HasColumnType("date");
            entity.Property(e => e.LastTradeDate).HasColumnType("date");
            entity.Property(e => e.RollDate).HasColumnType("date");
            entity.Property(e => e.Symbol).HasMaxLength(30);
            entity.Property(e => e.Volume).HasColumnType("decimal(18, 6)");
        });

        modelBuilder.Entity<FutureCurrentContract>(entity =>
        {
            entity.HasKey(e => e.GenericFutureId).HasName("PK_GenericFutureId");

            entity
                .ToTable("FutureCurrentContract", "roll")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("FutureCurrentContract_H", "roll");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.GenericFutureId).ValueGeneratedNever();
        });

        modelBuilder.Entity<FutureRollOrder>(entity =>
        {
            entity.HasKey(e => new { e.PortfolioId, e.ExpiringContractId, e.NextContractId });

            entity.ToTable("FutureRollOrder", "roll");

            entity.Property(e => e.ExpiringContractMaturity).HasColumnType("date");
            entity.Property(e => e.ExpiringContractSymbol).HasMaxLength(30);
            entity.Property(e => e.GenericFutureSymbol).HasMaxLength(30);
            entity.Property(e => e.NextContractMaturity).HasColumnType("date");
            entity.Property(e => e.NextContractSymbol).HasMaxLength(30);
            entity.Property(e => e.RollDate).HasColumnType("date");
        });

        modelBuilder.Entity<FxForward>(entity =>
        {
            entity.ToTable("FxForward", "roll");

            entity.Property(e => e.FxForwardId).ValueGeneratedNever();
            entity.Property(e => e.MaturityDate).HasColumnType("date");
            entity.Property(e => e.Symbol).HasMaxLength(30);
        });

        modelBuilder.Entity<FxForwardRollOrder>(entity =>
        {
            entity.HasKey(e => new { e.PortfolioId, e.ExpiringContractId, e.NextContractId });

            entity.ToTable("FxForwardRollOrder", "roll");

            entity.Property(e => e.CurrencyPairSymbol).HasMaxLength(30);
            entity.Property(e => e.ExpiringContractMaturity).HasColumnType("date");
            entity.Property(e => e.ExpiringContractSymbol).HasMaxLength(30);
            entity.Property(e => e.NextContractMaturity).HasColumnType("date");
            entity.Property(e => e.NextContractSymbol).HasMaxLength(30);
            entity.Property(e => e.RollDate).HasColumnType("date");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => new { e.PortfolioId, e.ContractId, e.Currency, e.PositionDate, e.IsSwap });

            entity.ToTable("Position", "roll");

            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PositionDate).HasColumnType("date");
        });

        modelBuilder.Entity<VwCompareCurrentContract>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwCompareCurrentContracts", "roll");

            entity.Property(e => e.TableRollingPeriodEnd).HasColumnType("date");
            entity.Property(e => e.TableRollingPeriodStart).HasColumnType("date");
            entity.Property(e => e.TableSymbol).HasMaxLength(30);
            entity.Property(e => e.TableVolume).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.ViewRollingPeriodEnd).HasColumnType("date");
            entity.Property(e => e.ViewRollingPeriodStart).HasColumnType("date");
            entity.Property(e => e.ViewSymbol).HasMaxLength(30);
            entity.Property(e => e.ViewVolume).HasColumnType("decimal(18, 6)");
        });

        modelBuilder.Entity<VwFutureContractRollInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwFutureContractRollInfo", "roll");

            entity.Property(e => e.MaturityDate).HasColumnType("date");
            entity.Property(e => e.RollingPeriodStartDate).HasColumnType("date");
            entity.Property(e => e.Symbol).HasMaxLength(30);
            entity.Property(e => e.Volume).HasColumnType("decimal(18, 6)");
        });

        modelBuilder.Entity<VwFutureContractRollInfo2>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwFutureContractRollInfo2", "roll");

            entity.Property(e => e.RollingPeriodEnd).HasColumnType("date");
            entity.Property(e => e.RollingPeriodStart).HasColumnType("date");
            entity.Property(e => e.Symbol).HasMaxLength(30);
            entity.Property(e => e.Volume).HasColumnType("decimal(18, 6)");
        });

        modelBuilder.Entity<VwFutureContractRollInfoOld>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwFutureContractRollInfo_Old", "roll");

            entity.Property(e => e.CurrentOpenInterest).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.CurrentSymbol).HasMaxLength(30);
            entity.Property(e => e.ExpiryDate).HasColumnType("date");
            entity.Property(e => e.NextMaturityDate).HasColumnType("date");
            entity.Property(e => e.NextOpenInterest).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.NextSymbol).HasMaxLength(30);
            entity.Property(e => e.RollingPeriodStartDate).HasColumnType("date");
        });

        modelBuilder.Entity<VwFutureContractRollingPeriod>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwFutureContractRollingPeriod", "roll");

            entity.Property(e => e.RollingPeriodEnd).HasColumnType("date");
            entity.Property(e => e.RollingPeriodStart).HasColumnType("date");
            entity.Property(e => e.Symbol).HasMaxLength(30);
        });

        modelBuilder.Entity<VwFutureContractVolumeRank>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwFutureContractVolumeRank", "roll");

            entity.Property(e => e.Symbol).HasMaxLength(30);
            entity.Property(e => e.Volume).HasColumnType("decimal(18, 6)");
        });

        modelBuilder.Entity<VwFutureCurrentContract>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwFutureCurrentContract", "roll");

            entity.Property(e => e.RollingPeriodEnd).HasColumnType("date");
            entity.Property(e => e.RollingPeriodStart).HasColumnType("date");
            entity.Property(e => e.Symbol).HasMaxLength(30);
            entity.Property(e => e.Volume).HasColumnType("decimal(18, 6)");
        });

        modelBuilder.Entity<VwFuturePositionRollInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwFuturePositionRollInfo", "roll");

            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CurrentContractVolume).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.FirstNoticeDate).HasColumnType("date");
            entity.Property(e => e.LastTradeDate).HasColumnType("date");
            entity.Property(e => e.PositionCurrentSymbol).HasMaxLength(30);
            entity.Property(e => e.PositionDate).HasColumnType("date");
            entity.Property(e => e.ToSymbol).HasMaxLength(30);
            entity.Property(e => e.ToVolume).HasColumnType("decimal(18, 6)");
        });

        modelBuilder.Entity<VwFxForwardRollInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwFxForwardRollInfo", "roll");

            entity.Property(e => e.CurrentSymbol).HasMaxLength(30);
            entity.Property(e => e.ExpiryDate).HasColumnType("date");
            entity.Property(e => e.NextMaturityDate).HasColumnType("date");
            entity.Property(e => e.NextSymbol).HasMaxLength(30);
            entity.Property(e => e.RollingPeriodStartDate).HasColumnType("date");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
