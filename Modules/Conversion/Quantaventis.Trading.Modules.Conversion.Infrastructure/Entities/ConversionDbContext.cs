using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Quantaventis.Trading.Modules.Conversion.Infrastructure.Entities;

public partial class ConversionDbContext : DbContext
{
    public ConversionDbContext()
    {
    }

    public ConversionDbContext(DbContextOptions<ConversionDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CurrencyPairConversionRule> CurrencyPairConversionRules { get; set; }

    public virtual DbSet<EquityConversionRule> EquityConversionRules { get; set; }

    public virtual DbSet<FutureConversionRule> FutureConversionRules { get; set; }

    public virtual DbSet<Instrument> Instruments { get; set; }

    public virtual DbSet<InstrumentMapping> InstrumentMappings { get; set; }

    public virtual DbSet<InstrumentMappingType> InstrumentMappingTypes { get; set; }

    public virtual DbSet<Portfolio> Portfolios { get; set; }

    public virtual DbSet<TargetAllocationConversion> TargetAllocationConversions { get; set; }

    public virtual DbSet<TargetWeightConversion> TargetWeightConversions { get; set; }

    public virtual DbSet<VwInstrumentMapping> VwInstrumentMappings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=TradingDatabase");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CS_AS");

        modelBuilder.Entity<CurrencyPairConversionRule>(entity =>
        {
            entity
                .ToTable("CurrencyPairConversionRule", "conv")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("CurrencyPairConversionRule_H", "conv");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));
        });

        modelBuilder.Entity<EquityConversionRule>(entity =>
        {
            entity
                .ToTable("EquityConversionRule", "conv")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("EquityConversionRule_H", "conv");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));
        });

        modelBuilder.Entity<FutureConversionRule>(entity =>
        {
            entity
                .ToTable("FutureConversionRule", "conv")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("FutureConversionRule_H", "conv");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));
        });

        modelBuilder.Entity<Instrument>(entity =>
        {
            entity.HasKey(e => e.InstrumentId).HasName("PK_InstrumentId");

            entity.ToTable("Instrument", "conv");

            entity.Property(e => e.InstrumentId).ValueGeneratedNever();
            entity.Property(e => e.InstrumentType).HasMaxLength(10);
            entity.Property(e => e.Symbol).HasMaxLength(30);
        });

        modelBuilder.Entity<InstrumentMapping>(entity =>
        {
            entity.HasKey(e => new { e.FromInstrumentId, e.InstrumentMappingTypeId, e.ToInstrumentId });

            entity
                .ToTable("InstrumentMapping", "conv")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("InstrumentMapping_H", "conv");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasOne(d => d.FromInstrument).WithMany(p => p.InstrumentMappingFromInstruments)
                .HasForeignKey(d => d.FromInstrumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InstrumentMapping_FromInstrument");

            entity.HasOne(d => d.InstrumentMappingType).WithMany(p => p.InstrumentMappings)
                .HasForeignKey(d => d.InstrumentMappingTypeId)
                .HasConstraintName("FK_InstrumentMapping_InstrumentMappingType");

            entity.HasOne(d => d.ToInstrument).WithMany(p => p.InstrumentMappingToInstruments)
                .HasForeignKey(d => d.ToInstrumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InstrumentMapping_ToInstrument");
        });

        modelBuilder.Entity<InstrumentMappingType>(entity =>
        {
            entity
                .ToTable("InstrumentMappingType", "conv")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("InstrumentMappingType_H", "conv");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasIndex(e => e.Mnemonic, "UC_InstrumentType_Mnemonic").IsUnique();

            entity.Property(e => e.InstrumentMappingTypeId).ValueGeneratedOnAdd();
            entity.Property(e => e.Mnemonic).HasMaxLength(30);
        });

        modelBuilder.Entity<Portfolio>(entity =>
        {
            entity.HasKey(e => e.PortfolioId).HasName("PK_PortfolioId");

            entity.ToTable("Portfolio", "conv");

            entity.Property(e => e.Mnemonic).HasMaxLength(6);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<TargetAllocationConversion>(entity =>
        {
            entity.ToTable("TargetAllocationConversion", "conv");
        });

        modelBuilder.Entity<TargetWeightConversion>(entity =>
        {
            entity.HasKey(e => e.TargetWeightConversionId).HasName("PK_TargetWeightConversionId");

            entity.ToTable("TargetWeightConversion", "conv");

            entity.Property(e => e.FromWeight).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.ToWeight).HasColumnType("decimal(18, 6)");

            entity.HasOne(d => d.FromInstrument).WithMany(p => p.TargetWeightConversionFromInstruments)
                .HasForeignKey(d => d.FromInstrumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TargetWeightConversion_FromInstrument");

            entity.HasOne(d => d.TargetAllocationConversion).WithMany(p => p.TargetWeightConversions)
                .HasForeignKey(d => d.TargetAllocationConversionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TargetWeightConversion_TargetAllocationConversion");

            entity.HasOne(d => d.ToInstrument).WithMany(p => p.TargetWeightConversionToInstruments)
                .HasForeignKey(d => d.ToInstrumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TargetWeightConversion_ToInstrument");
        });

        modelBuilder.Entity<VwInstrumentMapping>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwInstrumentMapping", "conv");

            entity.Property(e => e.FromSymbol).HasMaxLength(30);
            entity.Property(e => e.Mnemonic).HasMaxLength(30);
            entity.Property(e => e.ToSymbol).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
