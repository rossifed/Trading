using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Quantaventis.Trading.Modules.Rebalancing.Infrastructure.Entities;

public partial class RebalancingDbContext : DbContext
{
    public RebalancingDbContext()
    {
    }

    public RebalancingDbContext(DbContextOptions<RebalancingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Instrument> Instruments { get; set; }

    public virtual DbSet<Portfolio> Portfolios { get; set; }

    public virtual DbSet<PortfolioDrift> PortfolioDrifts { get; set; }

    public virtual DbSet<PortfolioValuation> PortfolioValuations { get; set; }

    public virtual DbSet<PositionDrift> PositionDrifts { get; set; }

    public virtual DbSet<PositionValuation> PositionValuations { get; set; }

    public virtual DbSet<RebalancingSession> RebalancingSessions { get; set; }

    public virtual DbSet<TargetAllocationValuation> TargetAllocationValuations { get; set; }

    public virtual DbSet<TargetWeightValuation> TargetWeightValuations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=TradingDatabase");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CS_AS");

        modelBuilder.Entity<Instrument>(entity =>
        {
            entity.HasKey(e => e.InstrumentId).HasName("PK_InstrumentId");

            entity.ToTable("Instrument", "rebal");

            entity.Property(e => e.InstrumentId).ValueGeneratedNever();
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.InstrumentType).HasMaxLength(30);
            entity.Property(e => e.Symbol).HasMaxLength(30);
        });

        modelBuilder.Entity<Portfolio>(entity =>
        {
            entity.HasKey(e => e.PortfolioId).HasName("PK_PortfolioId");

            entity.ToTable("Portfolio", "rebal");

            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Mnemonic).HasMaxLength(6);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<PortfolioDrift>(entity =>
        {
            entity.ToTable("PortfolioDrift", "rebal");

            entity.Property(e => e.ComputedOn).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.GrossExposureDrift).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.NetExposureDrift).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PortfolioGrossExposure).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PortfolioNetExposure).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.TargetGrossExposure).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.TargetNetExposure).HasColumnType("decimal(18, 6)");
        });

        modelBuilder.Entity<PortfolioValuation>(entity =>
        {
            entity.HasKey(e => e.PortfolioValuationId).HasName("PK_PortfolioValuationId");

            entity.ToTable("PortfolioValuation", "rebal");

            entity.Property(e => e.PortfolioValuationId).ValueGeneratedNever();
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.GrossExposure).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.NetExposure).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.TotalValue).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.ValuationDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<PositionDrift>(entity =>
        {
            entity.HasKey(e => new { e.PortfolioDriftId, e.InstrumentId });

            entity.ToTable("PositionDrift", "rebal");

            entity.Property(e => e.CurrentWeight).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.TargetWeight).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.WeightDrift).HasColumnType("decimal(18, 6)");

            entity.HasOne(d => d.PortfolioDrift).WithMany(p => p.PositionDrifts)
                .HasForeignKey(d => d.PortfolioDriftId)
                .HasConstraintName("FK_PositionDrift_PortfolioDrift");
        });

        modelBuilder.Entity<PositionValuation>(entity =>
        {
            entity.HasKey(e => new { e.PortfolioValuationId, e.InstrumentId });

            entity.ToTable("PositionValuation", "rebal");

            entity.Property(e => e.Weight).HasColumnType("decimal(18, 6)");

            entity.HasOne(d => d.PortfolioValuation).WithMany(p => p.PositionValuations)
                .HasForeignKey(d => d.PortfolioValuationId)
                .HasConstraintName("FK_PositionValuation_PortfolioValuation");
        });

        modelBuilder.Entity<RebalancingSession>(entity =>
        {
            entity.ToTable("RebalancingSession", "rebal");

            entity.Property(e => e.StartedBy)
                .HasMaxLength(50)
                .HasDefaultValueSql("('Unknown')");
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.StatusReason).HasMaxLength(40);
            entity.Property(e => e.TradeDate).HasColumnType("date");

            entity.HasMany(d => d.PortfolioDrifts).WithMany(p => p.RebalancingSessions)
                .UsingEntity<Dictionary<string, object>>(
                    "RebalancingSessionPortfolioDrift",
                    r => r.HasOne<PortfolioDrift>().WithMany()
                        .HasForeignKey("PortfolioDriftId")
                        .HasConstraintName("FK_RebalancingSessionPortfolioDrift_PortfolioDrift"),
                    l => l.HasOne<RebalancingSession>().WithMany()
                        .HasForeignKey("RebalancingSessionId")
                        .HasConstraintName("FK_RebalancingSessionPortfolioDrift_RebalancingSession"),
                    j =>
                    {
                        j.HasKey("RebalancingSessionId", "PortfolioDriftId");
                        j.ToTable("RebalancingSessionPortfolioDrift", "rebal");
                    });
        });

        modelBuilder.Entity<TargetAllocationValuation>(entity =>
        {
            entity.HasKey(e => e.TargetAllocationValuationId).HasName("PK_TargetAllocationValuationId");

            entity.ToTable("TargetAllocationValuation", "rebal");

            entity.HasIndex(e => new { e.TargetAllocationId, e.ValuatedOn }, "UC_TargetAllocationValuation").IsUnique();

            entity.Property(e => e.TargetAllocationValuationId).ValueGeneratedNever();
            entity.Property(e => e.PortfolioValue).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.TargetGrossExposure).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.TargetNetExposure).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.TotalWeight).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.ValuationCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<TargetWeightValuation>(entity =>
        {
            entity.HasKey(e => new { e.TargetAllocationValuationId, e.InstrumentId });

            entity.ToTable("TargetWeightValuation", "rebal");

            entity.Property(e => e.Weight).HasColumnType("decimal(12, 6)");

            entity.HasOne(d => d.TargetAllocationValuation).WithMany(p => p.TargetWeightValuations)
                .HasForeignKey(d => d.TargetAllocationValuationId)
                .HasConstraintName("FK_TargetWeightValuation_TargetAllocationValuation");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
