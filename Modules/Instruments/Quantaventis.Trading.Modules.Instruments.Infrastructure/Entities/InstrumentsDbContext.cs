using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;

public partial class InstrumentsDbContext : DbContext
{
    public InstrumentsDbContext()
    {
    }

    public InstrumentsDbContext(DbContextOptions<InstrumentsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Calendar> Calendars { get; set; }

    public virtual DbSet<Cfd> Cfds { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Currency> Currencies { get; set; }

    public virtual DbSet<CurrencyPair> CurrencyPairs { get; set; }

    public virtual DbSet<Date> Dates { get; set; }

    public virtual DbSet<Exchange> Exchanges { get; set; }

    public virtual DbSet<FutureContract> FutureContracts { get; set; }

    public virtual DbSet<FutureContractMonth> FutureContractMonths { get; set; }

    public virtual DbSet<FxForward> FxForwards { get; set; }

    public virtual DbSet<GenericFuture> GenericFutures { get; set; }

    public virtual DbSet<IndustryGroup> IndustryGroups { get; set; }

    public virtual DbSet<IndustrySector> IndustrySectors { get; set; }

    public virtual DbSet<Instrument> Instruments { get; set; }

    public virtual DbSet<InstrumentType> InstrumentTypes { get; set; }

    public virtual DbSet<MIC> MICs { get; set; }

    public virtual DbSet<MarketSector> MarketSectors { get; set; }

    public virtual DbSet<SecurityType> SecurityTypes { get; set; }

    public virtual DbSet<SecurityType2> SecurityType2s { get; set; }

    public virtual DbSet<StgRefDatum> StgRefData { get; set; }

    public virtual DbSet<TimeZone> TimeZones { get; set; }

    public virtual DbSet<vwCurrencyPair> vwCurrencyPairs { get; set; }

    public virtual DbSet<vwFutureContract> vwFutureContracts { get; set; }

    public virtual DbSet<vwFxForward> vwFxForwards { get; set; }

    public virtual DbSet<vwGenericFuture> vwGenericFutures { get; set; }

    public virtual DbSet<vwInstrument> vwInstruments { get; set; }

    public virtual DbSet<vwInverseCurrencyPair> vwInverseCurrencyPairs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=TradingDatabase");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CS_AS");

        modelBuilder.Entity<Calendar>(entity =>
        {
            entity.HasKey(e => e.CalendarDate);

            entity
                .ToTable("Calendar", "instr")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("Calendar_H", "instr");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.CalendarDate).HasColumnType("date");
            entity.Property(e => e.DayOfWeekName).HasMaxLength(9);
            entity.Property(e => e.DaySuffix)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FirstDateOfMonth).HasColumnType("date");
            entity.Property(e => e.FirstDateOfNextMonth).HasColumnType("date");
            entity.Property(e => e.FirstDateOfQuarter).HasColumnType("date");
            entity.Property(e => e.FirstDateOfWeek).HasColumnType("date");
            entity.Property(e => e.FirstDateOfYear).HasColumnType("date");
            entity.Property(e => e.LastDateOfMonth).HasColumnType("date");
            entity.Property(e => e.LastDateOfNextMonth).HasColumnType("date");
            entity.Property(e => e.LastDateOfQuarter).HasColumnType("date");
            entity.Property(e => e.LastDateOfWeek).HasColumnType("date");
            entity.Property(e => e.LastDateOfYear).HasColumnType("date");
            entity.Property(e => e.MonthOfYearName).HasMaxLength(9);
        });

        modelBuilder.Entity<Cfd>(entity =>
        {
            entity
                .ToTable("Cfd", "instr")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("Cfd_H", "instr");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.CfdId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PK_CountryId");

            entity
                .ToTable("Country", "instr")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("Country_H", "instr");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasIndex(e => e.IsoAlpha2Code, "UC_IsoAlpha2Code").IsUnique();

            entity.Property(e => e.IsoAlpha2Code)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Name).HasMaxLength(200);
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity
                .ToTable("Currency", "instr")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("Currency_H", "instr");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasIndex(e => e.Code, "UC_Currency_Code").IsUnique();

            entity.Property(e => e.CurrencyId).ValueGeneratedOnAdd();
            entity.Property(e => e.Code)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Name).HasMaxLength(200);
        });

        modelBuilder.Entity<CurrencyPair>(entity =>
        {
            entity
                .ToTable("CurrencyPair", "instr")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("CurrencyPair_H", "instr");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasIndex(e => new { e.BaseCurrencyId, e.QuoteCurrencyId }, "UC_CurrencyPair").IsUnique();

            entity.Property(e => e.CurrencyPairId).ValueGeneratedNever();
            entity.Property(e => e.QuoteFactor).HasColumnType("decimal(12, 6)");

            entity.HasOne(d => d.BaseCurrency).WithMany(p => p.CurrencyPairBaseCurrencies)
                .HasForeignKey(d => d.BaseCurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CurrencyPair_BaseCurrency");

            entity.HasOne(d => d.CurrencyPairNavigation).WithOne(p => p.CurrencyPair)
                .HasForeignKey<CurrencyPair>(d => d.CurrencyPairId)
                .HasConstraintName("FK_CurrencyPair_Instrument");

            entity.HasOne(d => d.QuoteCurrency).WithMany(p => p.CurrencyPairQuoteCurrencies)
                .HasForeignKey(d => d.QuoteCurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CurrencyPair_QuoteCurrency");
        });

        modelBuilder.Entity<Date>(entity =>
        {
            entity
                .ToTable("Date", "instr")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("Date_H", "instr");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasIndex(e => e.Value, "UC_Date").IsUnique();

            entity.Property(e => e.Value).HasColumnType("date");
        });

        modelBuilder.Entity<Exchange>(entity =>
        {
            entity.HasKey(e => e.ExchangeId).HasName("PK_ExchangeId");

            entity
                .ToTable("Exchange", "instr")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("Exchange_H", "instr");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasIndex(e => e.Code, "UC_ExchangeCode").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(5);
            entity.Property(e => e.Name).HasMaxLength(150);
        });

        modelBuilder.Entity<FutureContract>(entity =>
        {
            entity.HasKey(e => e.FutureContractId).HasName("PK_FutureContractId");

            entity
                .ToTable("FutureContract", "instr")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("FutureContract_H", "instr");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasIndex(e => new { e.GenericFutureId, e.FutureContractMonthId, e.ContractYear }, "UC_FutureContract").IsUnique();

            entity.Property(e => e.FutureContractId).ValueGeneratedNever();
            entity.Property(e => e.FirstDeliveryDate).HasColumnType("date");
            entity.Property(e => e.FirstNoticeDate).HasColumnType("date");
            entity.Property(e => e.LastTradeDate).HasColumnType("date");
            entity.Property(e => e.RollDate).HasColumnType("date");

            entity.HasOne(d => d.FutureContractNavigation).WithOne(p => p.FutureContract)
                .HasForeignKey<FutureContract>(d => d.FutureContractId)
                .HasConstraintName("FK_FutureContract_Instrument");

            entity.HasOne(d => d.FutureContractMonth).WithMany(p => p.FutureContracts)
                .HasForeignKey(d => d.FutureContractMonthId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FutureContract_FutureContractMonth");

            entity.HasOne(d => d.GenericFuture).WithMany(p => p.FutureContracts)
                .HasForeignKey(d => d.GenericFutureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FutureContract_GenericFuture");
        });

        modelBuilder.Entity<FutureContractMonth>(entity =>
        {
            entity.HasKey(e => e.FutureContractMonthId).HasName("PK_FutureContractMonthId");

            entity
                .ToTable("FutureContractMonth", "instr")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("FutureContractMonth_H", "instr");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.FutureContractMonthId).ValueGeneratedOnAdd();
            entity.Property(e => e.Code)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Mnemonic)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(10);
        });

        modelBuilder.Entity<FxForward>(entity =>
        {
            entity
                .ToTable("FxForward", "instr")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("FxForward_H", "instr");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasIndex(e => new { e.CurrencyPairId, e.MaturityDate }, "UC_FxForward").IsUnique();

            entity.Property(e => e.FxForwardId).ValueGeneratedNever();
            entity.Property(e => e.MaturityDate).HasColumnType("date");

            entity.HasOne(d => d.CurrencyPair).WithMany(p => p.FxForwards)
                .HasForeignKey(d => d.CurrencyPairId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FxForward_CurrencyPair");

            entity.HasOne(d => d.FxForwardNavigation).WithOne(p => p.FxForward)
                .HasForeignKey<FxForward>(d => d.FxForwardId)
                .HasConstraintName("FK_FxForward_Instrument");
        });

        modelBuilder.Entity<GenericFuture>(entity =>
        {
            entity.HasKey(e => e.GenericFutureId).HasName("PK_GenericFutureId");

            entity
                .ToTable("GenericFuture", "instr")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("ConstinuousFuture_H", "instr");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.GenericFutureId).ValueGeneratedNever();
            entity.Property(e => e.ContractSize).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PointValue).HasColumnType("decimal(14, 6)");
            entity.Property(e => e.RootSymbol).HasMaxLength(5);
            entity.Property(e => e.TickSize).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.TickValue).HasColumnType("decimal(12, 6)");

            entity.HasOne(d => d.GenericFutureNavigation).WithOne(p => p.GenericFuture)
                .HasForeignKey<GenericFuture>(d => d.GenericFutureId)
                .HasConstraintName("FK_GenericFuture_Instrument");
        });

        modelBuilder.Entity<IndustryGroup>(entity =>
        {
            entity.HasKey(e => e.IndustryGroupId).HasName("PK_IndustryGroupId");

            entity
                .ToTable("IndustryGroup", "instr")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("IndustryGroup_H", "instr");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasIndex(e => e.Number, "UC_IndustryGroupNumber").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<IndustrySector>(entity =>
        {
            entity.HasKey(e => e.IndustrySectorId).HasName("PK_IndustrySectorId");

            entity
                .ToTable("IndustrySector", "instr")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("IndustrySector_H", "instr");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasIndex(e => e.Number, "UC_IndustrySectorNumber").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Instrument>(entity =>
        {
            entity.HasKey(e => e.InstrumentId).HasName("PK_InstrumentId");

            entity
                .ToTable("Instrument", "instr")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("Instrument_H", "instr");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasIndex(e => e.BbgUniqueId, "UQ_BbgUniqueId").IsUnique();

            entity.Property(e => e.BbgGlobalId).HasMaxLength(30);
            entity.Property(e => e.BbgUniqueId).HasMaxLength(30);
            entity.Property(e => e.ISIN).HasMaxLength(12);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PriceScalingFactor)
                .HasDefaultValueSql("((1))")
                .HasColumnType("decimal(12, 6)");
            entity.Property(e => e.QuoteFactor)
                .HasDefaultValueSql("((1))")
                .HasColumnType("decimal(10, 4)");
            entity.Property(e => e.Symbol).HasMaxLength(30);

            entity.HasOne(d => d.Country).WithMany(p => p.Instruments)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_Instrument_Country");

            entity.HasOne(d => d.Currency).WithMany(p => p.InstrumentCurrencies)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Instrument_Currency");

            entity.HasOne(d => d.Exchange).WithMany(p => p.Instruments)
                .HasForeignKey(d => d.ExchangeId)
                .HasConstraintName("FK_Instrument_Exchange");

            entity.HasOne(d => d.IndustryGroup).WithMany(p => p.Instruments)
                .HasForeignKey(d => d.IndustryGroupId)
                .HasConstraintName("FK_Instrument_IndustryGroup");

            entity.HasOne(d => d.IndustrySector).WithMany(p => p.Instruments)
                .HasForeignKey(d => d.IndustrySectorId)
                .HasConstraintName("FK_Instrument_IndustrySector");

            entity.HasOne(d => d.InstrumentType).WithMany(p => p.Instruments)
                .HasForeignKey(d => d.InstrumentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Instrument_InstrumentType");

            entity.HasOne(d => d.MarketSector).WithMany(p => p.Instruments)
                .HasForeignKey(d => d.MarketSectorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Instrument_MarketSector");

            entity.HasOne(d => d.PrimaryMIC).WithMany(p => p.Instruments)
                .HasForeignKey(d => d.PrimaryMICId)
                .HasConstraintName("FK_Instrument_PrimaryMIC");

            entity.HasOne(d => d.QuoteCurrency).WithMany(p => p.InstrumentQuoteCurrencies)
                .HasForeignKey(d => d.QuoteCurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Instrument_QuoteCurrency");

            entity.HasOne(d => d.SecurityType2).WithMany(p => p.Instruments)
                .HasForeignKey(d => d.SecurityType2Id)
                .HasConstraintName("FK_Instrument_SecurityType2");

            entity.HasOne(d => d.SecurityType).WithMany(p => p.Instruments)
                .HasForeignKey(d => d.SecurityTypeId)
                .HasConstraintName("FK_Instrument_SecurityType");
        });

        modelBuilder.Entity<InstrumentType>(entity =>
        {
            entity.HasKey(e => e.InstrumentTypeId).HasName("PK_InstrumentTypeId");

            entity
                .ToTable("InstrumentType", "instr")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("InstrumentType_H", "instr");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasIndex(e => e.Mnemonic, "UC_InstrumentType_Mnemonic").IsUnique();

            entity.Property(e => e.InstrumentTypeId).ValueGeneratedOnAdd();
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Mnemonic).HasMaxLength(10);
        });

        modelBuilder.Entity<MIC>(entity =>
        {
            entity.HasKey(e => e.MICId).HasName("PK_MICId");

            entity
                .ToTable("MIC", "instr")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("MIC_H", "instr");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasIndex(e => e.Code, "UC_MIC").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(5);
        });

        modelBuilder.Entity<MarketSector>(entity =>
        {
            entity
                .ToTable("MarketSector", "instr")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("MarketSector_H", "instr");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.MarketSectorId).ValueGeneratedOnAdd();
            entity.Property(e => e.Mnemonic).HasMaxLength(6);
            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<SecurityType>(entity =>
        {
            entity.HasKey(e => e.SecurityTypeId).HasName("PK_SecurityTypeId");

            entity
                .ToTable("SecurityType", "instr")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("SecurityType_H", "instr");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasIndex(e => e.Name, "UC_SecurityType").IsUnique();

            entity.Property(e => e.SecurityTypeId).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<SecurityType2>(entity =>
        {
            entity.HasKey(e => e.SecurityType2Id).HasName("PK_SecurityType2Id");

            entity
                .ToTable("SecurityType2", "instr")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("SecurityType2_H", "instr");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasIndex(e => e.Name, "UC_SecurityType2").IsUnique();

            entity.Property(e => e.SecurityType2Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<StgRefDatum>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("StgRefData", "instr");

            entity.Property(e => e.BASE_CRNCY).HasMaxLength(200);
            entity.Property(e => e.BB_TO_EXCH_PX_SCALING_FACTOR).HasMaxLength(200);
            entity.Property(e => e.COUNTRY).HasMaxLength(200);
            entity.Property(e => e.COUNTRY_ISO).HasMaxLength(200);
            entity.Property(e => e.CRNCY).HasMaxLength(200);
            entity.Property(e => e.DL_REQUEST_ID).HasMaxLength(200);
            entity.Property(e => e.DL_REQUEST_NAME).HasMaxLength(200);
            entity.Property(e => e.DL_SNAPSHOT_START_TIME).HasMaxLength(200);
            entity.Property(e => e.DL_SNAPSHOT_TZ).HasMaxLength(200);
            entity.Property(e => e.EXCHANGE_TRADING_SESSION_HOURS_BC_SESSION).HasMaxLength(200);
            entity.Property(e => e.EXCHANGE_TRADING_SESSION_HOURS_FUT_TRADING_HRS).HasMaxLength(200);
            entity.Property(e => e.EXCH_CODE).HasMaxLength(200);
            entity.Property(e => e.FUT_CONT_SIZE).HasMaxLength(200);
            entity.Property(e => e.FUT_CUR_GEN_TICKER).HasMaxLength(200);
            entity.Property(e => e.FUT_DLV_DT_FIRST).HasMaxLength(200);
            entity.Property(e => e.FUT_EXCH_NAME_LONG).HasMaxLength(200);
            entity.Property(e => e.FUT_MONTH_YR).HasMaxLength(200);
            entity.Property(e => e.FUT_NOTICE_FIRST).HasMaxLength(200);
            entity.Property(e => e.FUT_ROLL_DT).HasMaxLength(200);
            entity.Property(e => e.FUT_TICK_SIZE).HasMaxLength(200);
            entity.Property(e => e.FUT_TICK_VAL).HasMaxLength(200);
            entity.Property(e => e.FUT_VAL_PT).HasMaxLength(200);
            entity.Property(e => e.IDENTIFIER).HasMaxLength(200);
            entity.Property(e => e.ID_BB_GLOBAL).HasMaxLength(200);
            entity.Property(e => e.ID_BB_UNIQUE).HasMaxLength(200);
            entity.Property(e => e.ID_ISIN).HasMaxLength(200);
            entity.Property(e => e.ID_MIC_LOCAL_EXCH).HasMaxLength(200);
            entity.Property(e => e.ID_MIC_PRIM_EXCH).HasMaxLength(200);
            entity.Property(e => e.LAST_TRADEABLE_DT).HasMaxLength(50);
            entity.Property(e => e.MARKET_SECTOR_DES).HasMaxLength(200);
            entity.Property(e => e.NAME).HasMaxLength(200);
            entity.Property(e => e.PX_SCALING_FACTOR).HasMaxLength(200);
            entity.Property(e => e.QUOTED_CRNCY).HasMaxLength(200);
            entity.Property(e => e.QUOTE_FACTOR).HasMaxLength(200);
            entity.Property(e => e.RC).HasMaxLength(200);
            entity.Property(e => e.SECURITY_TYP).HasMaxLength(200);
            entity.Property(e => e.SECURITY_TYP2).HasMaxLength(200);
            entity.Property(e => e.TIME_ZONE_NUM).HasMaxLength(200);
        });

        modelBuilder.Entity<TimeZone>(entity =>
        {
            entity
                .ToTable("TimeZone", "instr")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("TimeZone_H", "instr");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<vwCurrencyPair>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwCurrencyPair", "instr");

            entity.Property(e => e.BaseCurrencyCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.BbgGlobalId).HasMaxLength(30);
            entity.Property(e => e.BbgUniqueId).HasMaxLength(30);
            entity.Property(e => e.Country)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Exchange).HasMaxLength(5);
            entity.Property(e => e.ISIN).HasMaxLength(12);
            entity.Property(e => e.MarketSectorDes).HasMaxLength(6);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PrimaryMIC).HasMaxLength(5);
            entity.Property(e => e.QuoteCurrencyCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.QuoteFactor).HasColumnType("decimal(10, 4)");
            entity.Property(e => e.Symbol).HasMaxLength(30);
        });

        modelBuilder.Entity<vwFutureContract>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwFutureContract", "instr");

            entity.Property(e => e.BbgGlobalId).HasMaxLength(30);
            entity.Property(e => e.BbgUniqueId).HasMaxLength(30);
            entity.Property(e => e.ContractSize).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Country)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Exchange).HasMaxLength(5);
            entity.Property(e => e.FirstDeliveryDate).HasColumnType("date");
            entity.Property(e => e.FirstNoticeDate).HasColumnType("date");
            entity.Property(e => e.GenericFutureSymbol).HasMaxLength(30);
            entity.Property(e => e.ISIN).HasMaxLength(12);
            entity.Property(e => e.LastTradeDate).HasColumnType("date");
            entity.Property(e => e.MarketSectorDes).HasMaxLength(6);
            entity.Property(e => e.MonthCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.MonthMnemonic)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.MonthName).HasMaxLength(10);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PointValue).HasColumnType("decimal(14, 6)");
            entity.Property(e => e.PriceScalingFactor).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.PrimaryMIC).HasMaxLength(5);
            entity.Property(e => e.QuoteCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.RollDate).HasColumnType("date");
            entity.Property(e => e.RootSymbol).HasMaxLength(5);
            entity.Property(e => e.Symbol).HasMaxLength(30);
            entity.Property(e => e.TickSize).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.TickValue).HasColumnType("decimal(12, 6)");
        });

        modelBuilder.Entity<vwFxForward>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwFxForward", "instr");

            entity.Property(e => e.BaseCurrencyCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.BbgGlobalId).HasMaxLength(30);
            entity.Property(e => e.BbgUniqueId).HasMaxLength(30);
            entity.Property(e => e.Country)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CurrencyPairSymbol).HasMaxLength(30);
            entity.Property(e => e.Exchange).HasMaxLength(5);
            entity.Property(e => e.ISIN).HasMaxLength(12);
            entity.Property(e => e.MarketSectorDes).HasMaxLength(6);
            entity.Property(e => e.MaturityDate).HasColumnType("date");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PrimaryMIC).HasMaxLength(5);
            entity.Property(e => e.QuoteCurrencyCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.QuoteFactor).HasColumnType("decimal(10, 4)");
            entity.Property(e => e.Symbol).HasMaxLength(30);
        });

        modelBuilder.Entity<vwGenericFuture>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwGenericFuture", "instr");

            entity.Property(e => e.BbgGlobalId).HasMaxLength(30);
            entity.Property(e => e.BbgUniqueId).HasMaxLength(30);
            entity.Property(e => e.ContractSize).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Country)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Exchange).HasMaxLength(5);
            entity.Property(e => e.ISIN).HasMaxLength(12);
            entity.Property(e => e.MarketSectorDes).HasMaxLength(6);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PointValue).HasColumnType("decimal(14, 6)");
            entity.Property(e => e.PriceScalingFactor).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.PrimaryMIC).HasMaxLength(5);
            entity.Property(e => e.QuoteCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.RootSymbol).HasMaxLength(5);
            entity.Property(e => e.Symbol).HasMaxLength(30);
            entity.Property(e => e.TickSize).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.TickValue).HasColumnType("decimal(12, 6)");
        });

        modelBuilder.Entity<vwInstrument>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwInstrument", "instr");

            entity.Property(e => e.BbgGlobalId).HasMaxLength(30);
            entity.Property(e => e.BbgUniqueId).HasMaxLength(30);
            entity.Property(e => e.Country)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Exchange).HasMaxLength(5);
            entity.Property(e => e.ISIN).HasMaxLength(12);
            entity.Property(e => e.IndustryGroup).HasMaxLength(100);
            entity.Property(e => e.IndustrySector).HasMaxLength(100);
            entity.Property(e => e.InstrumentType).HasMaxLength(10);
            entity.Property(e => e.MarketSectorDes).HasMaxLength(6);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PriceScalingFactor).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.PrimaryMIC).HasMaxLength(5);
            entity.Property(e => e.QuoteCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.QuoteFactor).HasColumnType("decimal(10, 4)");
            entity.Property(e => e.Symbol).HasMaxLength(30);
            entity.Property(e => e.ValidFrom).HasPrecision(2);
            entity.Property(e => e.ValidTo).HasPrecision(2);
        });

        modelBuilder.Entity<vwInverseCurrencyPair>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwInverseCurrencyPair", "instr");

            entity.Property(e => e.BaseCurrencyCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.InverseBaseCurrencyCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.InverseQuoteCurrencyCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.InverseSymbol).HasMaxLength(30);
            entity.Property(e => e.QuoteCurrencyCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Symbol).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
