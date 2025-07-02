using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Quantaventis.Trading.Modules.Portfolios.Infrastructure.Entities;

public partial class PortfoliosDbContext : DbContext
{
    public PortfoliosDbContext()
    {
    }

    public PortfoliosDbContext(DbContextOptions<PortfoliosDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BookedTradeAllocation> BookedTradeAllocations { get; set; }

    public virtual DbSet<FxRate> FxRates { get; set; }

    public virtual DbSet<Instrument> Instruments { get; set; }

    public virtual DbSet<Portfolio> Portfolios { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Trade> Trades { get; set; }

    public virtual DbSet<TradeAllocation> TradeAllocations { get; set; }

    public virtual DbSet<VwClosedPosition> VwClosedPositions { get; set; }

    public virtual DbSet<VwLastClosedPosition> VwLastClosedPositions { get; set; }

    public virtual DbSet<VwLastOpenPosition> VwLastOpenPositions { get; set; }

    public virtual DbSet<VwLastPosition> VwLastPositions { get; set; }

    public virtual DbSet<VwOpenPosition> VwOpenPositions { get; set; }

    public virtual DbSet<VwPosition> VwPositions { get; set; }

    public virtual DbSet<ZzzPosition> ZzzPositions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=TradingDatabase");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CS_AS");

        modelBuilder.Entity<BookedTradeAllocation>(entity =>
        {
            entity.HasKey(e => e.TradeAllocationId).HasName("PK_BookedTradeAllocationId");

            entity.ToTable("BookedTradeAllocation", "port");

            entity.Property(e => e.TradeAllocationId).ValueGeneratedNever();
            entity.Property(e => e.Commission).HasColumnType("decimal(16, 6)");
            entity.Property(e => e.Fees).HasColumnType("decimal(16, 6)");
            entity.Property(e => e.GrossAmount).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.NetAmount).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.TradeCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TradePrice).HasColumnType("decimal(12, 6)");

            entity.HasOne(d => d.Instrument).WithMany(p => p.BookedTradeAllocations)
                .HasForeignKey(d => d.InstrumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BookedTradeAllocation_Instrument");

            entity.HasOne(d => d.Portfolio).WithMany(p => p.BookedTradeAllocations)
                .HasForeignKey(d => d.PortfolioId)
                .HasConstraintName("FK_BookedTradeAllocation_Portfolio");
        });

        modelBuilder.Entity<FxRate>(entity =>
        {
            entity.HasKey(e => new { e.BaseCurrency, e.QuoteCurrency });

            entity.ToTable("FxRate", "port");

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

            entity.ToTable("Instrument", "port");

            entity.Property(e => e.InstrumentId).ValueGeneratedNever();
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.InstrumentType).HasMaxLength(8);
            entity.Property(e => e.MarketSector).HasMaxLength(6);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Symbol).HasMaxLength(30);
        });

        modelBuilder.Entity<Portfolio>(entity =>
        {
            entity.HasKey(e => e.PortfolioId).HasName("PK_PortfolioId");

            entity
                .ToTable("Portfolio", "port")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("Portfolio_H", "port");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasIndex(e => e.Mnemonic, "UC_Portfolio_Mnemonic").IsUnique();

            entity.Property(e => e.PortfolioId).ValueGeneratedOnAdd();
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Mnemonic).HasMaxLength(6);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => new { e.PortfolioId, e.InstrumentId, e.Currency, e.IsSwap, e.PositionDate }).HasName("PK_TestPosition");

            entity.ToTable("Position", "port");

            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PositionDate).HasColumnType("date");
            entity.Property(e => e.AvgEntryPriceLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.GrossTotalCostLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.NetTotalCostLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PositionValueLocal).HasColumnType("decimal(24, 6)");
            entity.Property(e => e.TotalCommissionLocal).HasColumnType("decimal(18, 6)");

            entity.HasOne(d => d.Portfolio).WithMany(p => p.Positions)
                .HasForeignKey(d => d.PortfolioId)
                .HasConstraintName("FK_TestPosition_Portfolio");
        });

        modelBuilder.Entity<Trade>(entity =>
        {
            entity.HasKey(e => e.TradeId).HasName("PK_TradeId");

            entity.ToTable("Trade", "port");

            entity.HasIndex(e => new { e.SecurityId, e.PortfolioId, e.ExecutedOn }, "UC_Trade").IsUnique();

            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.ExecutionPrice).HasColumnType("decimal(12, 4)");
        });

        modelBuilder.Entity<TradeAllocation>(entity =>
        {
            entity.HasKey(e => e.TradeAllocationId).HasName("PK_TradeAllocationId");

            entity.ToTable("TradeAllocation", "port");

            entity.HasIndex(e => e.InstrumentId, "Idx_InstrumentId");

            entity.HasIndex(e => e.LastTradeDate, "Idx_LastTradeDate");

            entity.Property(e => e.TradeAllocationId).ValueGeneratedNever();
            entity.Property(e => e.Commission).HasColumnType("decimal(16, 6)");
            entity.Property(e => e.Fees).HasColumnType("decimal(16, 6)");
            entity.Property(e => e.GrossAmount).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.NetAmount).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.TradeCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TradePrice).HasColumnType("decimal(12, 6)");

            entity.HasOne(d => d.Instrument).WithMany(p => p.TradeAllocations)
                .HasForeignKey(d => d.InstrumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TradeAllocation_Instrument");

            entity.HasOne(d => d.Portfolio).WithMany(p => p.TradeAllocations)
                .HasForeignKey(d => d.PortfolioId)
                .HasConstraintName("FK_TradeAllocation_Portfolio");
        });

        modelBuilder.Entity<VwClosedPosition>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwClosedPosition", "port");

            entity.Property(e => e.AvgEntryPriceLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.BaseCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.GrossTotalCostLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.InstrumentName).HasMaxLength(100);
            entity.Property(e => e.InstrumentType).HasMaxLength(8);
            entity.Property(e => e.MarketSector).HasMaxLength(6);
            entity.Property(e => e.Mnemonic).HasMaxLength(6);
            entity.Property(e => e.NetTotalCostLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PositionDate).HasColumnType("date");
            entity.Property(e => e.PositionValueLocal).HasColumnType("decimal(24, 6)");
            entity.Property(e => e.Symbol).HasMaxLength(30);
        });

        modelBuilder.Entity<VwLastClosedPosition>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwLastClosedPosition", "port");

            entity.Property(e => e.AvgEntryPriceLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.BaseCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.GrossTotalCostLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.InstrumentName).HasMaxLength(100);
            entity.Property(e => e.InstrumentType).HasMaxLength(8);
            entity.Property(e => e.LastClosingPositionDate).HasColumnType("date");
            entity.Property(e => e.MarketSector).HasMaxLength(6);
            entity.Property(e => e.Mnemonic).HasMaxLength(6);
            entity.Property(e => e.NetTotalCostLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PositionValueLocal).HasColumnType("decimal(24, 6)");
            entity.Property(e => e.Symbol).HasMaxLength(30);
        });

        modelBuilder.Entity<VwLastOpenPosition>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwLastOpenPosition", "port");

            entity.Property(e => e.AvgEntryPriceLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.BaseCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.GrossTotalCostLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.InstrumentName).HasMaxLength(100);
            entity.Property(e => e.InstrumentType).HasMaxLength(8);
            entity.Property(e => e.MarketSector).HasMaxLength(6);
            entity.Property(e => e.Mnemonic).HasMaxLength(6);
            entity.Property(e => e.NetTotalCostLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PositionDate).HasColumnType("date");
            entity.Property(e => e.PositionValueLocal).HasColumnType("decimal(24, 6)");
            entity.Property(e => e.Symbol).HasMaxLength(30);
        });

        modelBuilder.Entity<VwLastPosition>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwLastPosition", "port");

            entity.Property(e => e.AvgEntryPriceLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.BaseCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.GrossTotalCostLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.InstrumentName).HasMaxLength(100);
            entity.Property(e => e.InstrumentType).HasMaxLength(8);
            entity.Property(e => e.MarketSector).HasMaxLength(6);
            entity.Property(e => e.Mnemonic).HasMaxLength(6);
            entity.Property(e => e.NetTotalCostLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PositionDate).HasColumnType("date");
            entity.Property(e => e.PositionValueLocal).HasColumnType("decimal(24, 6)");
            entity.Property(e => e.Symbol).HasMaxLength(30);
        });

        modelBuilder.Entity<VwOpenPosition>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwOpenPosition", "port");

            entity.Property(e => e.AvgEntryPriceLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.BaseCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.GrossTotalCostLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.InstrumentName).HasMaxLength(100);
            entity.Property(e => e.InstrumentType).HasMaxLength(8);
            entity.Property(e => e.MarketSector).HasMaxLength(6);
            entity.Property(e => e.Mnemonic).HasMaxLength(6);
            entity.Property(e => e.NetTotalCostLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PositionDate).HasColumnType("date");
            entity.Property(e => e.PositionValueLocal).HasColumnType("decimal(24, 6)");
            entity.Property(e => e.Symbol).HasMaxLength(30);
        });

        modelBuilder.Entity<VwPosition>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwPosition", "port");

            entity.Property(e => e.AvgEntryPriceLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.BaseCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.GrossTotalCostLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.InstrumentName).HasMaxLength(100);
            entity.Property(e => e.InstrumentType).HasMaxLength(8);
            entity.Property(e => e.MarketSector).HasMaxLength(6);
            entity.Property(e => e.Mnemonic).HasMaxLength(6);
            entity.Property(e => e.NetTotalCostLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PositionDate).HasColumnType("date");
            entity.Property(e => e.PositionValueLocal).HasColumnType("decimal(24, 6)");
            entity.Property(e => e.Symbol).HasMaxLength(30);
        });

        modelBuilder.Entity<ZzzPosition>(entity =>
        {
            entity.HasKey(e => new { e.PortfolioId, e.InstrumentId, e.Currency, e.PositionDate }).HasName("PK_Position");

            entity.ToTable("ZZZ_Position", "port");

            entity.HasIndex(e => new { e.PortfolioId, e.PositionDate }, "Idx_PortfolioId_PositionDate");

            entity.HasIndex(e => e.Quantity, "Idx_Position_Quantity");

            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PositionDate).HasColumnType("date");
            entity.Property(e => e.AvgEntryPriceLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.GrossTotalCostLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.NetTotalCostLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PositionValueLocal).HasColumnType("decimal(24, 6)");
            entity.Property(e => e.PreviousAvgEntryPriceLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PreviousGrossTotalCostLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PreviousNetTotalCostLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PreviousPositionDate).HasColumnType("date");
            entity.Property(e => e.PreviousPositionValueLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.TotalCommissionLocal).HasColumnType("decimal(18, 6)");

            entity.HasOne(d => d.Portfolio).WithMany(p => p.ZzzPositions)
                .HasForeignKey(d => d.PortfolioId)
                .HasConstraintName("FK_Position_Portfolio");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
