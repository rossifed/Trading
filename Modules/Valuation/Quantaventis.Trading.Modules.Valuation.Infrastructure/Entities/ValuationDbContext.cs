using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Quantaventis.Trading.Modules.Valuation.Infrastructure.Entities;

public partial class ValuationDbContext : DbContext
{
    public ValuationDbContext()
    {
    }

    public ValuationDbContext(DbContextOptions<ValuationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<FutureContract> FutureContracts { get; set; }

    public virtual DbSet<FxRate> FxRates { get; set; }

    public virtual DbSet<Instrument> Instruments { get; set; }

    public virtual DbSet<InstrumentPricing> InstrumentPricings { get; set; }

    public virtual DbSet<InstrumentValuation> InstrumentValuations { get; set; }

    public virtual DbSet<Portfolio> Portfolios { get; set; }

    public virtual DbSet<PortfolioValuation> PortfolioValuations { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<PositionValuation> PositionValuations { get; set; }

    public virtual DbSet<TargetAllocation> TargetAllocations { get; set; }

    public virtual DbSet<TargetAllocationValuation> TargetAllocationValuations { get; set; }

    public virtual DbSet<TargetWeight> TargetWeights { get; set; }

    public virtual DbSet<TargetWeightValuation> TargetWeightValuations { get; set; }

    public virtual DbSet<VwLastInstrumentValuation> VwLastInstrumentValuations { get; set; }

    public virtual DbSet<VwLastPositionValuation> VwLastPositionValuations { get; set; }

    public virtual DbSet<VwLastPositionValuation2> VwLastPositionValuation2s { get; set; }

    public virtual DbSet<VwLastPositionValuationV2> VwLastPositionValuationV2s { get; set; }

    public virtual DbSet<VwPositionValuationPnL> VwPositionValuationPnLs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=TradingDatabase");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CS_AS");

        modelBuilder.Entity<FutureContract>(entity =>
        {
            entity.HasKey(e => e.FutureContractId).HasName("PK_FutureContractId");

            entity.ToTable("FutureContract", "val");

            entity.Property(e => e.FutureContractId).ValueGeneratedNever();
            entity.Property(e => e.PointValue).HasColumnType("decimal(14, 6)");
            entity.Property(e => e.PointValueCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.FutureContractNavigation).WithOne(p => p.FutureContract)
                .HasForeignKey<FutureContract>(d => d.FutureContractId)
                .HasConstraintName("FK_FutureContract_Instrument");
        });

        modelBuilder.Entity<FxRate>(entity =>
        {
            entity.HasKey(e => new { e.BaseCurrency, e.QuoteCurrency });

            entity.ToTable("FxRate", "val");

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

            entity.ToTable("Instrument", "val");

            entity.Property(e => e.InstrumentId).ValueGeneratedNever();
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.InstrumentType).HasMaxLength(10);
            entity.Property(e => e.Symbol).HasMaxLength(30);
        });

        modelBuilder.Entity<InstrumentPricing>(entity =>
        {
            entity.HasKey(e => e.InstrumentId);

            entity.ToTable("InstrumentPricing", "val");

            entity.Property(e => e.InstrumentId).ValueGeneratedNever();
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 6)");

            entity.HasOne(d => d.Instrument).WithOne(p => p.InstrumentPricing)
                .HasForeignKey<InstrumentPricing>(d => d.InstrumentId)
                .HasConstraintName("FK_InstrumentPricing_Instrument");
        });

        modelBuilder.Entity<InstrumentValuation>(entity =>
        {
            entity.HasKey(e => new { e.InstrumentId, e.PriceDate, e.Currency });

            entity.ToTable("InstrumentValuation", "val");

            entity.Property(e => e.PriceDate).HasColumnType("date");
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.InstrumentValue).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PreviousInstrumentValue).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PreviousPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PreviousPriceDate).HasColumnType("date");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PriceReturn).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.ValuationFactor).HasColumnType("decimal(18, 6)");
        });

        modelBuilder.Entity<Portfolio>(entity =>
        {
            entity.HasKey(e => e.PortfolioId).HasName("PK_PortfolioId");

            entity.ToTable("Portfolio", "val");

            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Mnemonic).HasMaxLength(6);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.TotalValue).HasColumnType("decimal(18, 6)");
        });

        modelBuilder.Entity<PortfolioValuation>(entity =>
        {
            entity.HasKey(e => e.PortfolioValuationId).HasName("PK_PortfolioValuationId");

            entity.ToTable("PortfolioValuation", "val");

            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.GrossExposure).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.NetExposure).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PnL).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Roi)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("ROI");
            entity.Property(e => e.TotalValue).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.ValuationDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => new { e.PortfolioId, e.InstrumentId, e.Currency, e.PositionDate });

            entity.ToTable("Position", "val");

            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PositionDate).HasColumnType("date");
            entity.Property(e => e.AvgEntryPriceLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.GrossTotalCostLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.NetTotalCostLocal).HasColumnType("decimal(18, 6)");

            entity.HasOne(d => d.Instrument).WithMany(p => p.Positions)
                .HasForeignKey(d => d.InstrumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Position_Instrument");

            entity.HasOne(d => d.Portfolio).WithMany(p => p.Positions)
                .HasForeignKey(d => d.PortfolioId)
                .HasConstraintName("FK_Position_Portfolio");
        });

        modelBuilder.Entity<PositionValuation>(entity =>
        {
            entity.ToTable("PositionValuation", "val");

            entity.HasIndex(e => new { e.PortfolioValuationId, e.InstrumentId }, "UC_PositionValuation").IsUnique();

            entity.Property(e => e.FxRate).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.GrossExposure).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.InstrumentPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.InstrumentPriceCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.InstrumentValue).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.NetExposure).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PnL).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Roi)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("ROI");
            entity.Property(e => e.ValuationCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Weight).HasColumnType("decimal(18, 6)");

            entity.HasOne(d => d.PortfolioValuation).WithMany(p => p.PositionValuations)
                .HasForeignKey(d => d.PortfolioValuationId)
                .HasConstraintName("FK_PositionValuation_PortfolioValuation");
        });

        modelBuilder.Entity<TargetAllocation>(entity =>
        {
            entity.HasKey(e => e.TargetAllocationId).HasName("PK_TargetAllocationId");

            entity.ToTable("TargetAllocation", "val");

            entity.Property(e => e.TargetAllocationId).ValueGeneratedNever();

            entity.HasOne(d => d.Portfolio).WithMany(p => p.TargetAllocations)
                .HasForeignKey(d => d.PortfolioId)
                .HasConstraintName("FK_TargetAllocation_Portfolio");
        });

        modelBuilder.Entity<TargetAllocationValuation>(entity =>
        {
            entity.HasKey(e => e.TargetAllocationValuationId).HasName("PK_TargetAllocationValuationId");

            entity.ToTable("TargetAllocationValuation", "val");

            entity.HasIndex(e => new { e.TargetAllocationId, e.ValuatedOn }, "UC_TargetAllocationValuation").IsUnique();

            entity.Property(e => e.PortfolioValue).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.TargetGrossExposure).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.TargetNetExposure).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.TotalWeight).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.ValuationCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<TargetWeight>(entity =>
        {
            entity.HasKey(e => e.TargetWeightId).HasName("PK_TargetWeightId");

            entity.ToTable("TargetWeight", "val");

            entity.HasIndex(e => new { e.TargetWeightId, e.InstrumentId }, "UC_TargetWeight").IsUnique();

            entity.Property(e => e.Weight).HasColumnType("decimal(9, 6)");

            entity.HasOne(d => d.Instrument).WithMany(p => p.TargetWeights)
                .HasForeignKey(d => d.InstrumentId)
                .HasConstraintName("FK_TargetWeight_Instrument");

            entity.HasOne(d => d.TargetAllocation).WithMany(p => p.TargetWeights)
                .HasForeignKey(d => d.TargetAllocationId)
                .HasConstraintName("FK_TargetWeight_TargetAllocation");
        });

        modelBuilder.Entity<TargetWeightValuation>(entity =>
        {
            entity.ToTable("TargetWeightValuation", "val");

            entity.HasIndex(e => new { e.TargetAllocationValuationId, e.InstrumentId }, "UC_TargetWeightValuation").IsUnique();

            entity.Property(e => e.InstrumentValue).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PriceCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TargetGrossExposure).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.TargetNetExposure).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Weight).HasColumnType("decimal(12, 6)");

            entity.HasOne(d => d.TargetAllocationValuation).WithMany(p => p.TargetWeightValuations)
                .HasForeignKey(d => d.TargetAllocationValuationId)
                .HasConstraintName("FK_TargetWeightValuation_TargetAllocationValuation");
        });

        modelBuilder.Entity<VwLastInstrumentValuation>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwLastInstrumentValuation", "val");

            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.InstrumentType).HasMaxLength(10);
            entity.Property(e => e.InstrumentValue).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PreviousInstrumentValue).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PreviousPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PreviousPriceDate).HasColumnType("date");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PriceDate).HasColumnType("date");
            entity.Property(e => e.PriceReturn).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Symbol).HasMaxLength(30);
            entity.Property(e => e.ValuationFactor).HasColumnType("decimal(18, 6)");
        });

        modelBuilder.Entity<VwLastPositionValuation>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwLastPositionValuation", "val");

            entity.Property(e => e.BaseCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FxRate).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.InstrumentCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.InstrumentPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.InstrumentPriceCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.InstrumentType).HasMaxLength(10);
            entity.Property(e => e.InstrumentValue).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PortfolioGrossExposure).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PortfolioNetExposure).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PortfolioPnl).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PortfolioRoi).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PortfolioTotalValue).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PositionGrossExposure).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PositionNetExposure).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PositionPnl).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PositionRoi).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PositionWeight).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Symbol).HasMaxLength(30);
            entity.Property(e => e.ValuationCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ValuationDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<VwLastPositionValuation2>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwLastPositionValuation2", "val");

            entity.Property(e => e.AvgEntryPriceLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.GrossTotalCostLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.InstrumentType).HasMaxLength(10);
            entity.Property(e => e.InstrumentValue).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.MarketValue).HasColumnType("decimal(29, 6)");
            entity.Property(e => e.NetTotalCostLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Pnl).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.PositionCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PositionDate).HasColumnType("date");
            entity.Property(e => e.PreviousInstrumentValue).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PreviousPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PreviousPriceDate).HasColumnType("date");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PriceDate).HasColumnType("date");
            entity.Property(e => e.PriceReturn).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Symbol).HasMaxLength(30);
            entity.Property(e => e.ValuationFactor).HasColumnType("decimal(18, 6)");
        });

        modelBuilder.Entity<VwLastPositionValuationV2>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwLastPositionValuationV2", "val");

            entity.Property(e => e.AvgEntryPriceLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.GrossExposure).HasColumnType("decimal(38, 9)");
            entity.Property(e => e.GrossTotalCostLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.InstrumentValue).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.LocalDailyPnl).HasColumnType("decimal(30, 6)");
            entity.Property(e => e.Mnemonic).HasMaxLength(6);
            entity.Property(e => e.NetExposure).HasColumnType("decimal(38, 9)");
            entity.Property(e => e.NetTotalCostLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PortfolioCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PortfolioTotalValue).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PositionDate).HasColumnType("date");
            entity.Property(e => e.PreviousAvgEntryPriceLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PreviousGrossTotalCostLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PreviousInstrumentValue).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PreviousNetTotalCostLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PreviousPositionDate).HasColumnType("date");
            entity.Property(e => e.PreviousPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PreviousPriceDate).HasColumnType("date");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PriceCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PriceDate).HasColumnType("date");
            entity.Property(e => e.PriceReturn).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.ValuationFactor).HasColumnType("decimal(18, 6)");
        });

        modelBuilder.Entity<VwPositionValuationPnL>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwPositionValuationPnL", "val");

            entity.Property(e => e.AvgEntryPriceBase).HasColumnType("decimal(37, 12)");
            entity.Property(e => e.AvgEntryPriceLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.DailyPnLchange)
                .HasColumnType("decimal(38, 6)")
                .HasColumnName("DailyPnLChange");
            entity.Property(e => e.FxRate).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.GrossTotalCostBase).HasColumnType("decimal(37, 12)");
            entity.Property(e => e.GrossTotalCostLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.InstrumentCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.InstrumentType).HasMaxLength(8);
            entity.Property(e => e.InstrumentValueBase).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.InstrumentValueLocal).HasColumnType("decimal(33, 12)");
            entity.Property(e => e.NetTotalCostBase).HasColumnType("decimal(37, 12)");
            entity.Property(e => e.NetTotalCostLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PnL).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.PointValue).HasColumnType("decimal(14, 6)");
            entity.Property(e => e.PortfolioCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PositionCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PositionDate).HasColumnType("date");
            entity.Property(e => e.PositionValueBase).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.PositionValueLocal).HasColumnType("decimal(38, 11)");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PriceCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Symbol).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
