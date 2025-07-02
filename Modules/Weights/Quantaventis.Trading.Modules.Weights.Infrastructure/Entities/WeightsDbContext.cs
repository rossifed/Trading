using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Quantaventis.Trading.Modules.Weights.Infrastructure.Entities;

public partial class WeightsDbContext : DbContext
{
    public WeightsDbContext()
    {
    }

    public WeightsDbContext(DbContextOptions<WeightsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Instrument> Instruments { get; set; }

    public virtual DbSet<StgTargetWeight> StgTargetWeights { get; set; }

    public virtual DbSet<TargetAllocation> TargetAllocations { get; set; }

    public virtual DbSet<TargetWeight> TargetWeights { get; set; }

    public virtual DbSet<VwLastTargetAllocation> VwLastTargetAllocations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=TradingDatabase");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CS_AS");

        modelBuilder.Entity<Instrument>(entity =>
        {
            entity.HasKey(e => e.InstrumentId).HasName("PK_InstrumentId");

            entity.ToTable("Instrument", "wght");

            entity.Property(e => e.InstrumentId).ValueGeneratedNever();
            entity.Property(e => e.Symbol).HasMaxLength(30);
        });

        modelBuilder.Entity<StgTargetWeight>(entity =>
        {
            entity.HasKey(e => new { e.Weight, e.PortfolioId });

            entity.ToTable("StgTargetWeight", "wght");

            entity.Property(e => e.Weight).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.Symbol).HasMaxLength(30);
        });

        modelBuilder.Entity<TargetAllocation>(entity =>
        {
            entity.HasKey(e => e.TargetAllocationId).HasName("PK_TargeAllocationId");

            entity.ToTable("TargetAllocation", "wght");
        });

        modelBuilder.Entity<TargetWeight>(entity =>
        {
            entity.HasKey(e => new { e.InstrumentId, e.TargetAllocationId }).HasName("PK_TargetWeightId");

            entity.ToTable("TargetWeight", "wght");

            entity.Property(e => e.Weight).HasColumnType("decimal(9, 6)");

            entity.HasOne(d => d.Instrument).WithMany(p => p.TargetWeights)
                .HasForeignKey(d => d.InstrumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TargetWeight_Instrument");

            entity.HasOne(d => d.TargetAllocation).WithMany(p => p.TargetWeights)
                .HasForeignKey(d => d.TargetAllocationId)
                .HasConstraintName("FK_TargetWeight_TargetAllocation");
        });

        modelBuilder.Entity<VwLastTargetAllocation>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwLastTargetAllocation", "wght");

            entity.Property(e => e.Symbol).HasMaxLength(30);
            entity.Property(e => e.Weight).HasColumnType("decimal(9, 6)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
