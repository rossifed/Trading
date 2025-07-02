using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Quantaventis.Trading.Modules.Risk.Infrastructure.Entities;

public partial class RiskDbContext : DbContext
{
    public RiskDbContext()
    {
    }

    public RiskDbContext(DbContextOptions<RiskDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BooleanOperator> BooleanOperators { get; set; }

    public virtual DbSet<Constraint> Constraints { get; set; }

    public virtual DbSet<ConstraintBreach> ConstraintBreaches { get; set; }

    public virtual DbSet<ConstraintType> ConstraintTypes { get; set; }

    public virtual DbSet<Filter> Filters { get; set; }

    public virtual DbSet<FilterCriterion> FilterCriteria { get; set; }

    public virtual DbSet<FilterOperator> FilterOperators { get; set; }

    public virtual DbSet<FilterParty> FilterParties { get; set; }

    public virtual DbSet<FilterPartyType> FilterPartyTypes { get; set; }

    public virtual DbSet<Instrument> Instruments { get; set; }

    public virtual DbSet<Portfolio> Portfolios { get; set; }

    public virtual DbSet<PortfolioConstraint> PortfolioConstraints { get; set; }

    public virtual DbSet<RelationalOperator> RelationalOperators { get; set; }

    public virtual DbSet<TargetAllocationCheck> TargetAllocationChecks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=TradingDatabase");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CS_AS");

        modelBuilder.Entity<BooleanOperator>(entity =>
        {
            entity.HasKey(e => e.BooleanOperatorId).HasName("PK_BooleanOperatorId");

            entity
                .ToTable("BooleanOperator", "risk")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("BooleanOperator_H", "risk");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasIndex(e => e.Mnemonic, "UC_BooleanOperatorMnemonic").IsUnique();

            entity.Property(e => e.BooleanOperatorId).ValueGeneratedOnAdd();
            entity.Property(e => e.Mnemonic).HasMaxLength(20);
        });

        modelBuilder.Entity<Constraint>(entity =>
        {
            entity.HasKey(e => e.ConstraintId).HasName("PK_ConstraintId");

            entity
                .ToTable("Constraint", "risk")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("Constraint_H", "risk");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasIndex(e => new { e.ConstraintTypeId, e.RelationalOperatorId, e.LimitValue, e.FilterId }, "UC_Constraint").IsUnique();

            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.LimitValue).HasColumnType("decimal(12, 6)");

            entity.HasOne(d => d.ConstraintType).WithMany(p => p.Constraints)
                .HasForeignKey(d => d.ConstraintTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Constraint_ConstraintType");

            entity.HasOne(d => d.Filter).WithMany(p => p.Constraints)
                .HasForeignKey(d => d.FilterId)
                .HasConstraintName("FK_Constraint_Filter");

            entity.HasOne(d => d.RelationalOperator).WithMany(p => p.Constraints)
                .HasForeignKey(d => d.RelationalOperatorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Constraint_RelationalOperator");
        });

        modelBuilder.Entity<ConstraintBreach>(entity =>
        {
            entity.ToTable("ConstraintBreach", "risk");

            entity.Property(e => e.Message).HasMaxLength(300);

            entity.HasOne(d => d.Constraint).WithMany(p => p.ConstraintBreaches)
                .HasForeignKey(d => d.ConstraintId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConstraintBreach_Constraint");

            entity.HasOne(d => d.TargetAllocationCheck).WithMany(p => p.ConstraintBreaches)
                .HasForeignKey(d => d.TargetAllocationCheckId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConstraintBreach_TargetAllocationCheck");
        });

        modelBuilder.Entity<ConstraintType>(entity =>
        {
            entity.HasKey(e => e.ConstraintTypeId).HasName("PK_ConstraintTypeId");

            entity
                .ToTable("ConstraintType", "risk")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("ConstraintType_H", "risk");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasIndex(e => e.Mnemonic, "UC_ConstraintTypeMnemonic").IsUnique();

            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Mnemonic).HasMaxLength(10);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Filter>(entity =>
        {
            entity.HasKey(e => e.FilterId).HasName("PK_FilterId");

            entity
                .ToTable("Filter", "risk")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("Filter_H", "risk");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasIndex(e => new { e.FilterCriterion1Id, e.BooleanOperatorId, e.FilterCriterion2Id }, "UC_Filter").IsUnique();

            entity.HasOne(d => d.BooleanOperator).WithMany(p => p.Filters)
                .HasForeignKey(d => d.BooleanOperatorId)
                .HasConstraintName("FK_Filter_BooleanOperator");

            entity.HasOne(d => d.FilterCriterion1).WithMany(p => p.FilterFilterCriterion1s)
                .HasForeignKey(d => d.FilterCriterion1Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Filter_FilterCriterion1");

            entity.HasOne(d => d.FilterCriterion2).WithMany(p => p.FilterFilterCriterion2s)
                .HasForeignKey(d => d.FilterCriterion2Id)
                .HasConstraintName("FK_Filter_FilterCriterion2");
        });

        modelBuilder.Entity<FilterCriterion>(entity =>
        {
            entity.HasKey(e => e.FilterCriterionId).HasName("PK_FilterCriterionId");

            entity.ToTable("FilterCriterion", "risk");

            entity.HasIndex(e => new { e.FilterPartyTypeId, e.FilterOperatorId, e.FilterPartyId }, "UC_FilterCriterion").IsUnique();

            entity.HasOne(d => d.FilterOperator).WithMany(p => p.FilterCriteria)
                .HasForeignKey(d => d.FilterOperatorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FilterCriterion_FilterOperator");

            entity.HasOne(d => d.FilterPartyType).WithMany(p => p.FilterCriteria)
                .HasForeignKey(d => d.FilterPartyTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FilterCriterion_FilterPartyType");

            entity.HasOne(d => d.FilterParty).WithMany(p => p.FilterCriteria)
                .HasForeignKey(d => new { d.FilterPartyId, d.FilterPartyTypeId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FilterCriterion_FilterParty");
        });

        modelBuilder.Entity<FilterOperator>(entity =>
        {
            entity.HasKey(e => e.FilterOperatorId).HasName("PK_FilterOperatorId");

            entity
                .ToTable("FilterOperator", "risk")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("FilterOperator_H", "risk");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasIndex(e => e.Mnemonic, "UC_FilterOperatorMnemonic").IsUnique();

            entity.Property(e => e.FilterOperatorId).ValueGeneratedOnAdd();
            entity.Property(e => e.Description).HasMaxLength(20);
            entity.Property(e => e.Mnemonic).HasMaxLength(20);
        });

        modelBuilder.Entity<FilterParty>(entity =>
        {
            entity.HasKey(e => new { e.FilterPartyId, e.FilterPartyTypeId }).HasName("PK_ContractPartyId");

            entity.ToTable("FilterParty", "risk");
        });

        modelBuilder.Entity<FilterPartyType>(entity =>
        {
            entity.HasKey(e => e.FilterPartyTypeId).HasName("PK_FilterPartyTypeId");

            entity
                .ToTable("FilterPartyType", "risk")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("FilterPartyType_H", "risk");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.FilterPartyTypeId).ValueGeneratedOnAdd();
            entity.Property(e => e.Mnemonic).HasMaxLength(5);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Instrument>(entity =>
        {
            entity.HasKey(e => e.InstrumentId).HasName("PK_InstrumentId");

            entity.ToTable("Instrument", "risk");

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

            entity.ToTable("Portfolio", "risk");

            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Mnemonic).HasMaxLength(6);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<PortfolioConstraint>(entity =>
        {
            entity
                .ToTable("PortfolioConstraint", "risk")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("PortfolioConstraint_H", "risk");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasIndex(e => new { e.PortfolioId, e.ConstraintId }, "UC_PortfolioConstraint").IsUnique();

            entity.HasOne(d => d.Constraint).WithMany(p => p.PortfolioConstraints)
                .HasForeignKey(d => d.ConstraintId)
                .HasConstraintName("FK_PortfolioConstraint_Constraint");

            entity.HasOne(d => d.Portfolio).WithMany(p => p.PortfolioConstraints)
                .HasForeignKey(d => d.PortfolioId)
                .HasConstraintName("FK_PortfolioConstraint_Portfolio");
        });

        modelBuilder.Entity<RelationalOperator>(entity =>
        {
            entity.HasKey(e => e.RelationalOperatorId).HasName("PK_RelationalOperatorId");

            entity
                .ToTable("RelationalOperator", "risk")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("RelationalOperator_H", "risk");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasIndex(e => e.Mnemonic, "UC_RelationalOperatorMnemonic").IsUnique();

            entity.Property(e => e.RelationalOperatorId).ValueGeneratedOnAdd();
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.Mnemonic).HasMaxLength(20);
        });

        modelBuilder.Entity<TargetAllocationCheck>(entity =>
        {
            entity.ToTable("TargetAllocationCheck", "risk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
