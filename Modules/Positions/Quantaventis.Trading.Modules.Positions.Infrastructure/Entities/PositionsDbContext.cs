using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Quantaventis.Trading.Modules.Positions.Infrastructure.Entities;

public partial class PositionsDbContext : DbContext
{
    public PositionsDbContext()
    {
    }

    public PositionsDbContext(DbContextOptions<PositionsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Instrument> Instruments { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<TradeAllocation> TradeAllocations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=TradingDatabase");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CS_AS");

        modelBuilder.Entity<Instrument>(entity =>
        {
            entity.HasKey(e => e.InstrumentId).HasName("PK_InstrumentId");

            entity.ToTable("Instrument", "pos");

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

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => new { e.InstrumentId, e.IsSwap, e.PortfolioId, e.LocalCurrency, e.PositionDate });

            entity
                .ToTable("Position", "pos")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("Position_H", "pos");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.LocalCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PositionDate).HasColumnType("date");
            entity.Property(e => e.BaseCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FirstTradeDate).HasColumnType("date");
            entity.Property(e => e.GrossEntryPriceBase).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.GrossEntryPriceLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.GrossNotionalValueBase).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.GrossNotionalValueLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.GrossTradeValueBase).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.GrossTradeValueLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.LastTradeDate).HasColumnType("date");
            entity.Property(e => e.NetEntryPriceBase).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.NetEntryPriceLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.NetNotionalValueBase).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.NetNotionalValueLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.NetTradeValueBase).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.NetTradeValueLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.NominalQuantity).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.TotalCommissionBase).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.TotalCommissionLocal).HasColumnType("decimal(18, 6)");

            entity.HasOne(d => d.Instrument).WithMany(p => p.Positions)
                .HasForeignKey(d => d.InstrumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Position_Instrument");
        });

        modelBuilder.Entity<TradeAllocation>(entity =>
        {
            entity.ToTable("TradeAllocation", "pos");

            entity.Property(e => e.TradeAllocationId).ValueGeneratedNever();
            entity.Property(e => e.BaseCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CommissionAmountBase).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.CommissionAmountLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Cusip).HasMaxLength(10);
            entity.Property(e => e.GrossAvgPriceBase).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.GrossAvgPriceLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.GrossPrincipalBase).HasColumnType("decimal(24, 6)");
            entity.Property(e => e.GrossPrincipalLocal).HasColumnType("decimal(24, 6)");
            entity.Property(e => e.GrossTradeValueBase).HasColumnType("decimal(24, 6)");
            entity.Property(e => e.GrossTradeValueLocal).HasColumnType("decimal(24, 6)");
            entity.Property(e => e.Isin).HasMaxLength(12);
            entity.Property(e => e.LocalCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LocalToBaseFxRate).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.LocalToSettleFxRate).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.NetAvgPriceBase).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.NetAvgPriceLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.NetPrincipalBase).HasColumnType("decimal(24, 6)");
            entity.Property(e => e.NetPrincipalLocal).HasColumnType("decimal(24, 6)");
            entity.Property(e => e.NetTradeValueBase).HasColumnType("decimal(24, 6)");
            entity.Property(e => e.NetTradeValueLocal).HasColumnType("decimal(24, 6)");
            entity.Property(e => e.NominalQuantity).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.SecurityName).HasMaxLength(100);
            entity.Property(e => e.Sedol).HasMaxLength(20);
            entity.Property(e => e.TradeDate).HasColumnType("date");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
