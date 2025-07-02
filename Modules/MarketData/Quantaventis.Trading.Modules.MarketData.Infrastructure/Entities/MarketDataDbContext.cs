using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Quantaventis.Trading.Modules.MarketData.Infrastructure.Entities;

public partial class MarketDataDbContext : DbContext
{
    public MarketDataDbContext()
    {
    }

    public MarketDataDbContext(DbContextOptions<MarketDataDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<FxRate> FxRates { get; set; }

    public virtual DbSet<Instrument> Instruments { get; set; }

    public virtual DbSet<MarketDatum> MarketData { get; set; }

    public virtual DbSet<StgMarketDatum> StgMarketData { get; set; }

    public virtual DbSet<StgVolumeDatum> StgVolumeData { get; set; }

    public virtual DbSet<VolumeDatum> VolumeData { get; set; }

    public virtual DbSet<vwLastFxRate> vwLastFxRates { get; set; }

    public virtual DbSet<vwLastFxRateEod> vwLastFxRateEods { get; set; }

    public virtual DbSet<vwLastMarketDatum> vwLastMarketData { get; set; }

    public virtual DbSet<vwLastPrice> vwLastPrices { get; set; }

    public virtual DbSet<vwLastPriceEod> vwLastPriceEods { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=TradingDatabase");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CS_AS");

        modelBuilder.Entity<FxRate>(entity =>
        {
            entity.HasKey(e => new { e.BaseCurrency, e.QuoteCurrency, e.LastUpdateDateEod }).HasName("PK_FXRate");

            entity.ToTable("FxRate", "mktdata");

            entity.Property(e => e.BaseCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.QuoteCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LastUpdateDateEod).HasColumnType("date");
            entity.Property(e => e.LastUpdateDate).HasColumnType("date");
            entity.Property(e => e.LastValue).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.LastValueEod).HasColumnType("decimal(18, 6)");
        });

        modelBuilder.Entity<Instrument>(entity =>
        {
            entity.HasKey(e => e.InstrumentId).HasName("PK_InstrumentId");

            entity.ToTable("Instrument", "mktdata");

            entity.Property(e => e.InstrumentId).ValueGeneratedNever();
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Exchange).HasMaxLength(5);
            entity.Property(e => e.InstrumentType).HasMaxLength(10);
            entity.Property(e => e.PriceScalingFactor).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.QuoteCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.QuoteFactor).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.Symbol).HasMaxLength(30);
        });

        modelBuilder.Entity<MarketDatum>(entity =>
        {
            entity.HasKey(e => new { e.InstrumentId, e.LastUpdateDateEod });

            entity.ToTable("MarketData", "mktdata");

            entity.Property(e => e.LastUpdateDateEod).HasColumnType("date");
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LastPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.LastPriceEod).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.LastUpdateDate).HasColumnType("date");
            entity.Property(e => e.MarketCap).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.VolumeAvg30Day).HasColumnType("decimal(18, 6)");

            entity.HasOne(d => d.Instrument).WithMany(p => p.MarketData)
                .HasForeignKey(d => d.InstrumentId)
                .HasConstraintName("FK_MarketData_Instrument");
        });

        modelBuilder.Entity<StgMarketDatum>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("StgMarketData", "mktdata");

            entity.Property(e => e.CUR_MKT_CAP).HasMaxLength(50);
            entity.Property(e => e.DL_REQUEST_ID).HasMaxLength(50);
            entity.Property(e => e.DL_REQUEST_NAME).HasMaxLength(50);
            entity.Property(e => e.DL_SNAPSHOT_START_TIME).HasMaxLength(50);
            entity.Property(e => e.DL_SNAPSHOT_TZ).HasMaxLength(50);
            entity.Property(e => e.IDENTIFIER).HasMaxLength(50);
            entity.Property(e => e.LAST_TRADE_DATE).HasMaxLength(50);
            entity.Property(e => e.LAST_UPDATE).HasMaxLength(50);
            entity.Property(e => e.LAST_UPDATE_DATE_EOD).HasMaxLength(50);
            entity.Property(e => e.LAST_UPDATE_DT).HasMaxLength(50);
            entity.Property(e => e.PX_CLOSE_DT).HasMaxLength(50);
            entity.Property(e => e.PX_LAST).HasMaxLength(50);
            entity.Property(e => e.PX_LAST_EOD).HasMaxLength(50);
            entity.Property(e => e.PX_YEST_CLOSE).HasMaxLength(50);
            entity.Property(e => e.PX_YEST_DT).HasMaxLength(50);
            entity.Property(e => e.RC).HasMaxLength(50);
            entity.Property(e => e.VOLUME_AVG_30D).HasMaxLength(50);
        });

        modelBuilder.Entity<StgVolumeDatum>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("StgVolumeData", "mktdata");

            entity.Property(e => e.DL_REQUEST_ID).HasMaxLength(50);
            entity.Property(e => e.DL_REQUEST_NAME).HasMaxLength(50);
            entity.Property(e => e.DL_SNAPSHOT_START_TIME).HasMaxLength(50);
            entity.Property(e => e.DL_SNAPSHOT_TZ).HasMaxLength(50);
            entity.Property(e => e.IDENTIFIER).HasMaxLength(50);
            entity.Property(e => e.PX_VOLUME_1D).HasMaxLength(50);
            entity.Property(e => e.RC).HasMaxLength(50);
        });

        modelBuilder.Entity<VolumeDatum>(entity =>
        {
            entity.HasKey(e => new { e.InstrumentId, e.LastUpdateDate });

            entity.ToTable("VolumeData", "mktdata");

            entity.Property(e => e.LastUpdateDate).HasColumnType("date");
            entity.Property(e => e.Volume1Day).HasColumnType("decimal(18, 6)");

            entity.HasOne(d => d.Instrument).WithMany(p => p.VolumeData)
                .HasForeignKey(d => d.InstrumentId)
                .HasConstraintName("FK_VolumeData_Instrument");
        });

        modelBuilder.Entity<vwLastFxRate>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwLastFxRate", "mktdata");

            entity.Property(e => e.BaseCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LastUpdateDate).HasColumnType("date");
            entity.Property(e => e.LastValue).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.QuoteCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<vwLastFxRateEod>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwLastFxRateEod", "mktdata");

            entity.Property(e => e.BaseCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LastUpdateDateEod).HasColumnType("date");
            entity.Property(e => e.LastValueEod).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.QuoteCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<vwLastMarketDatum>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwLastMarketData", "mktdata");

            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.High).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.LastPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.LastPriceEod).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.LastUpdateDate).HasColumnType("date");
            entity.Property(e => e.LastUpdateDateEod).HasColumnType("date");
            entity.Property(e => e.Low).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.MarketCap).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Open).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.OpenInterest).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Volume).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.VolumeAvg30Day).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.VolumeAvg3Month).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.VolumeAvg6Month).HasColumnType("decimal(18, 6)");
        });

        modelBuilder.Entity<vwLastPrice>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwLastPrice", "mktdata");

            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LastPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.LastUpdateDate).HasColumnType("date");
            entity.Property(e => e.PriceScalingFactor).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.QuoteCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.QuoteFactor).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.Symbol).HasMaxLength(30);
        });

        modelBuilder.Entity<vwLastPriceEod>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwLastPriceEod", "mktdata");

            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LastPriceEod).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.LastUpdateDateEod).HasColumnType("date");
            entity.Property(e => e.Symbol).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
