using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Quantaventis.Trading.Modules.EFRP.Infrastructure.Entities;

public partial class EfrpDbContext : DbContext
{
    public EfrpDbContext()
    {
    }

    public EfrpDbContext(DbContextOptions<EfrpDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Broker> Brokers { get; set; }

    public virtual DbSet<EfrpConversionRule> EfrpConversionRules { get; set; }

    public virtual DbSet<EfrpOrder> EfrpOrders { get; set; }

    public virtual DbSet<FutureContract> FutureContracts { get; set; }

    public virtual DbSet<GenericFuture> GenericFutures { get; set; }

    public virtual DbSet<Immdate> Immdates { get; set; }

    public virtual DbSet<VwEfrpConversionRule> VwEfrpConversionRules { get; set; }

    public virtual DbSet<VwEfrpFutureContract> VwEfrpFutureContracts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=TradingDatabase");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CS_AS");

        modelBuilder.Entity<Broker>(entity =>
        {
            entity.ToTable("Broker", "efrp");

            entity.Property(e => e.Code).HasMaxLength(10);
        });

        modelBuilder.Entity<EfrpConversionRule>(entity =>
        {
            entity
                .ToTable("EfrpConversionRule", "efrp")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("EfrpConversionRule_H", "exec");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.BaseCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CmeClearportTicker).HasMaxLength(5);
            entity.Property(e => e.QuoteCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Broker).WithMany(p => p.EfrpConversionRules)
                .HasForeignKey(d => d.BrokerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EfrpConversionRule_Broker");

            entity.HasOne(d => d.GenericFuture).WithMany(p => p.EfrpConversionRules)
                .HasForeignKey(d => d.GenericFutureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EfrpConversionRule_GenericFuture");
        });

        modelBuilder.Entity<EfrpOrder>(entity =>
        {
            entity.ToTable("EfrpOrder", "efrp");

            entity.Property(e => e.EfrpOrderId).ValueGeneratedNever();
            entity.Property(e => e.BaseCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("date");
            entity.Property(e => e.FxForwardSymbol).HasMaxLength(30);
            entity.Property(e => e.MaturityDate).HasColumnType("date");
            entity.Property(e => e.PositionSide)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.QuoteCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<FutureContract>(entity =>
        {
            entity.HasKey(e => e.FutureContractId).HasName("PK_FutureContractId");

            entity.ToTable("FutureContract", "efrp");

            entity.Property(e => e.FutureContractId).ValueGeneratedNever();
            entity.Property(e => e.LastTradeDate).HasColumnType("date");
            entity.Property(e => e.Symbol).HasMaxLength(30);

            entity.HasOne(d => d.GenericFuture).WithMany(p => p.FutureContracts)
                .HasForeignKey(d => d.GenericFutureId)
                .HasConstraintName("FK_FutureContract_GenericFuture");
        });

        modelBuilder.Entity<GenericFuture>(entity =>
        {
            entity.HasKey(e => e.GenericFutureId).HasName("PK_GenericFutureId");

            entity.ToTable("GenericFuture", "efrp");

            entity.Property(e => e.GenericFutureId).ValueGeneratedNever();
            entity.Property(e => e.ContractSize).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PointValue).HasColumnType("decimal(14, 6)");
            entity.Property(e => e.RootSymbol).HasMaxLength(5);
            entity.Property(e => e.Symbol).HasMaxLength(30);
        });

        modelBuilder.Entity<Immdate>(entity =>
        {
            entity.HasKey(e => e.Date);

            entity.ToTable("IMMDate", "efrp");

            entity.Property(e => e.Date).HasColumnType("date");
        });

        modelBuilder.Entity<VwEfrpConversionRule>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwEfrpConversionRule", "efrp");

            entity.Property(e => e.BaseCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CmeClearportTicker).HasMaxLength(5);
            entity.Property(e => e.ContractSize).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.QuoteCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.RootSymbol).HasMaxLength(5);
            entity.Property(e => e.Symbol).HasMaxLength(30);
            entity.Property(e => e.ValidFrom).HasPrecision(2);
            entity.Property(e => e.ValidTo).HasPrecision(2);
        });

        modelBuilder.Entity<VwEfrpFutureContract>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwEfrpFutureContract", "efrp");

            entity.Property(e => e.BaseCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CmeClearportTicker).HasMaxLength(5);
            entity.Property(e => e.ContractSize).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.LastTradeDate).HasColumnType("date");
            entity.Property(e => e.QuoteCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.RootSymbol).HasMaxLength(5);
            entity.Property(e => e.Symbol).HasMaxLength(30);
            entity.Property(e => e.ValidFrom).HasPrecision(2);
            entity.Property(e => e.ValidTo).HasPrecision(2);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
