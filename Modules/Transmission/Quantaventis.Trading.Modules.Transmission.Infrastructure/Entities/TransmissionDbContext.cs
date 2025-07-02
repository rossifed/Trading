using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Entities;

public partial class TransmissionDbContext : DbContext
{
    public TransmissionDbContext()
    {
    }

    public TransmissionDbContext(DbContextOptions<TransmissionDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BookedTradeAllocation> BookedTradeAllocations { get; set; }

    public virtual DbSet<ClearingAccountCodeMapping> ClearingAccountCodeMappings { get; set; }

    public virtual DbSet<ClearingBrokerCodeMapping> ClearingBrokerCodeMappings { get; set; }

    public virtual DbSet<Counterparty> Counterparties { get; set; }

    public virtual DbSet<CounterpartyCodeMapping> CounterpartyCodeMappings { get; set; }

    public virtual DbSet<CustodianCodeMapping> CustodianCodeMappings { get; set; }

    public virtual DbSet<EmailConfiguration> EmailConfigurations { get; set; }

    public virtual DbSet<EncryptionProfile> EncryptionProfiles { get; set; }

    public virtual DbSet<ExecutionAccountCodeMapping> ExecutionAccountCodeMappings { get; set; }

    public virtual DbSet<ExecutionBrokerCodeMapping> ExecutionBrokerCodeMappings { get; set; }

    public virtual DbSet<ExecutionBrokerMapping> ExecutionBrokerMappings { get; set; }

    public virtual DbSet<FileContentType> FileContentTypes { get; set; }

    public virtual DbSet<FileGenerationProfile> FileGenerationProfiles { get; set; }

    public virtual DbSet<FileGenerationType> FileGenerationTypes { get; set; }

    public virtual DbSet<FileTransmission> FileTransmissions { get; set; }

    public virtual DbSet<FtpConfiguration> FtpConfigurations { get; set; }

    public virtual DbSet<FxRate> FxRates { get; set; }

    public virtual DbSet<Instrument> Instruments { get; set; }

    public virtual DbSet<InstrumentPricing> InstrumentPricings { get; set; }

    public virtual DbSet<PostTradeServiceMapping> PostTradeServiceMappings { get; set; }

    public virtual DbSet<PrimeBrokerCodeMapping> PrimeBrokerCodeMappings { get; set; }

    public virtual DbSet<PrimeBrokerMapping> PrimeBrokerMappings { get; set; }

    public virtual DbSet<Trade> Trades { get; set; }

    public virtual DbSet<TradeAllocation> TradeAllocations { get; set; }

    public virtual DbSet<TransmissionChannel> TransmissionChannels { get; set; }

    public virtual DbSet<TransmissionProfile> TransmissionProfiles { get; set; }

    public virtual DbSet<TransmissionScheduleType> TransmissionScheduleTypes { get; set; }

    public virtual DbSet<TransmittedFile> TransmittedFiles { get; set; }

    public virtual DbSet<TransmittedTrade> TransmittedTrades { get; set; }

    public virtual DbSet<VwCmglfndTradesFileGsSynthTest> VwCmglfndTradesFileGsSynthTests { get; set; }

    public virtual DbSet<VwCmglfndTradesFileMsd01Test> VwCmglfndTradesFileMsd01Tests { get; set; }

    public virtual DbSet<VwCmglfndTradesFileMssw002Test> VwCmglfndTradesFileMssw002Tests { get; set; }

    public virtual DbSet<VwCmglfndVwTradesFileMsfssw002GsTest> VwCmglfndVwTradesFileMsfssw002GsTests { get; set; }

    public virtual DbSet<VwCmglfndVwTradesFileMsfssw002MsTest> VwCmglfndVwTradesFileMsfssw002MsTests { get; set; }

    public virtual DbSet<VwCmglfndVwTradesFileMsfstr001GsTest> VwCmglfndVwTradesFileMsfstr001GsTests { get; set; }

    public virtual DbSet<VwCmglfndVwTradesFileMsfstr001MsTest> VwCmglfndVwTradesFileMsfstr001MsTests { get; set; }

    public virtual DbSet<VwLastFileTransmission> VwLastFileTransmissions { get; set; }

    public virtual DbSet<VwPnlInnocapWithRoll> VwPnlInnocapWithRolls { get; set; }

    public virtual DbSet<VwTradesFileCapricorn> VwTradesFileCapricorns { get; set; }

    public virtual DbSet<VwTradesFileInnocapFx> VwTradesFileInnocapFxes { get; set; }

    public virtual DbSet<VwTradesFileInnocapSw> VwTradesFileInnocapSws { get; set; }

    public virtual DbSet<VwTradesFileInnocapTr> VwTradesFileInnocapTrs { get; set; }

    public virtual DbSet<VwTradesFileMsd01> VwTradesFileMsd01s { get; set; }

    public virtual DbSet<VwTradesFileMsfsfx> VwTradesFileMsfsfxes { get; set; }

    public virtual DbSet<VwTradesFileMsfssw002> VwTradesFileMsfssw002s { get; set; }

    public virtual DbSet<VwTradesFileMsfstr001> VwTradesFileMsfstr001s { get; set; }

    public virtual DbSet<VwTradesFileMssw002> VwTradesFileMssw002s { get; set; }

    public virtual DbSet<VwTransmissionProfile> VwTransmissionProfiles { get; set; }

    public virtual DbSet<VwTransmittedFile> VwTransmittedFiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=TradingDatabase");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CS_AS");

        modelBuilder.Entity<BookedTradeAllocation>(entity =>
        {
            entity.HasKey(e => e.TradeAllocationId);

            entity.ToTable("BookedTradeAllocation", "trans");

            entity.Property(e => e.TradeAllocationId).ValueGeneratedNever();
            entity.Property(e => e.BaseCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ClearingAccount).HasMaxLength(20);
            entity.Property(e => e.ClearingBroker).HasMaxLength(6);
            entity.Property(e => e.CommissionAmountBase).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.CommissionAmountLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.CommissionAmountSettle).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.CommissionType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CommissionValue).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.ContractMultiplier).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Cusip).HasMaxLength(10);
            entity.Property(e => e.Custodian).HasMaxLength(6);
            entity.Property(e => e.Exchange).HasMaxLength(5);
            entity.Property(e => e.ExecutionAccount).HasMaxLength(20);
            entity.Property(e => e.ExecutionBroker).HasMaxLength(5);
            entity.Property(e => e.ExecutionDesk).HasMaxLength(6);
            entity.Property(e => e.ExecutionType).HasMaxLength(6);
            entity.Property(e => e.GrossAvgPriceBase).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.GrossAvgPriceLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.GrossAvgPriceSettle).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.GrossPrincipalBase).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.GrossPrincipalLocal).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.GrossPrincipalSettle).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.GrossTradeValueBase).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.GrossTradeValueLocal).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.GrossTradeValueSettle).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.InstrumentType).HasMaxLength(8);
            entity.Property(e => e.Isin).HasMaxLength(12);
            entity.Property(e => e.LocalCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LocalExchangeSymbol).HasMaxLength(20);
            entity.Property(e => e.LocalToBaseFxRate).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.LocalToSettleFxRate).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.MiscFeesBase).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.MiscFeesLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.MiscFeesSettle).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.NetAvgPriceBase).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.NetAvgPriceLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.NetAvgPriceSettle).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.NetPrincipalBase).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.NetPrincipalLocal).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.NetPrincipalSettle).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.NetTradeValueBase).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.NetTradeValueLocal).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.NetTradeValueSettle).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.NominalQuantity).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Notes).HasMaxLength(200);
            entity.Property(e => e.OrderAllocationNominalQuantity).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PositionSide)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PriceCommissionBase).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PriceCommissionLocal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PriceCommissionSettle).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PriceScalingFactor).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.PrimeBroker).HasMaxLength(6);
            entity.Property(e => e.SecurityName).HasMaxLength(100);
            entity.Property(e => e.Sedol).HasMaxLength(20);
            entity.Property(e => e.SettlementCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SettlementDate).HasColumnType("date");
            entity.Property(e => e.Symbol).HasMaxLength(30);
            entity.Property(e => e.TradeDate).HasColumnType("date");
            entity.Property(e => e.TradeInstrumentType).HasMaxLength(8);
            entity.Property(e => e.TradeSide).HasMaxLength(10);
            entity.Property(e => e.TradeStatus)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TraderName).HasMaxLength(30);
            entity.Property(e => e.YellowKey).HasMaxLength(10);
        });

        modelBuilder.Entity<ClearingAccountCodeMapping>(entity =>
        {
            entity.HasKey(e => new { e.CounterpartyId, e.InternalCode });

            entity
                .ToTable("ClearingAccountCodeMapping", "trans")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("H_ClearingAccountCodeMapping", "trans");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.InternalCode).HasMaxLength(20);
            entity.Property(e => e.CounterpartyCode).HasMaxLength(20);

            entity.HasOne(d => d.Counterparty).WithMany(p => p.ClearingAccountCodeMappings)
                .HasForeignKey(d => d.CounterpartyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClearingAccountCodeMapping_Counterparty");
        });

        modelBuilder.Entity<ClearingBrokerCodeMapping>(entity =>
        {
            entity.HasKey(e => new { e.FileGenerationTypeId, e.InternalCode });

            entity
                .ToTable("ClearingBrokerCodeMapping", "trans")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("H_ClearingBrokerCodeMapping", "trans");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.InternalCode).HasMaxLength(20);
            entity.Property(e => e.CounterpartyCode).HasMaxLength(20);

            entity.HasOne(d => d.FileGenerationType).WithMany(p => p.ClearingBrokerCodeMappings)
                .HasForeignKey(d => d.FileGenerationTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClearingBrokerCodeMapping_FileGenerationType");
        });

        modelBuilder.Entity<Counterparty>(entity =>
        {
            entity
                .ToTable("Counterparty", "trans")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("H_Counterparty", "trans");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.CounterpartyId).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<CounterpartyCodeMapping>(entity =>
        {
            entity
                .ToTable("CounterpartyCodeMapping", "trans")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("H_CounterpartyCodeMapping", "trans");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasIndex(e => new { e.PortfolioId, e.FileGenerationType }, "UQ_CounterpartyCodeMapping").IsUnique();

            entity.Property(e => e.ClearingAccount).HasMaxLength(12);
            entity.Property(e => e.ClearingBroker).HasMaxLength(5);
            entity.Property(e => e.Custodian).HasMaxLength(5);
            entity.Property(e => e.ExecutionAccount).HasMaxLength(12);
            entity.Property(e => e.ExecutionBroker).HasMaxLength(5);
            entity.Property(e => e.FileGenerationType).HasMaxLength(20);
        });

        modelBuilder.Entity<CustodianCodeMapping>(entity =>
        {
            entity.HasKey(e => new { e.FileGenerationTypeId, e.PortfolioId, e.InternalCode });

            entity
                .ToTable("CustodianCodeMapping", "trans")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("H_CustodianCodeMapping", "trans");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.InternalCode).HasMaxLength(20);
            entity.Property(e => e.CounterpartyCode).HasMaxLength(20);

            entity.HasOne(d => d.FileGenerationType).WithMany(p => p.CustodianCodeMappings)
                .HasForeignKey(d => d.FileGenerationTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustodianCodeMapping_FileGenerationType");
        });

        modelBuilder.Entity<EmailConfiguration>(entity =>
        {
            entity
                .ToTable("EmailConfiguration", "trans")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("H_EmailConfiguration", "trans");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.EmailSubject)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.MessageBody).IsUnicode(false);
        });

        modelBuilder.Entity<EncryptionProfile>(entity =>
        {
            entity
                .ToTable("EncryptionProfile", "trans")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("H_EncryptionProfile", "trans");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.EncryptionProfileId).ValueGeneratedNever();
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.ExcryptedFileExtension).HasMaxLength(3);
            entity.Property(e => e.Passphrase).HasMaxLength(30);
            entity.Property(e => e.PrivateKeyRecipient).HasMaxLength(50);
            entity.Property(e => e.PublicKeyRecipient).HasMaxLength(50);
        });

        modelBuilder.Entity<ExecutionAccountCodeMapping>(entity =>
        {
            entity.HasKey(e => new { e.CounterpartyId, e.InternalCode });

            entity
                .ToTable("ExecutionAccountCodeMapping", "trans")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("H_ExecutionAccountCodeMapping", "trans");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.InternalCode).HasMaxLength(20);
            entity.Property(e => e.CounterpartyCode).HasMaxLength(20);

            entity.HasOne(d => d.Counterparty).WithMany(p => p.ExecutionAccountCodeMappings)
                .HasForeignKey(d => d.CounterpartyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExecutionAccountCodeMapping_Counterparty");
        });

        modelBuilder.Entity<ExecutionBrokerCodeMapping>(entity =>
        {
            entity.HasKey(e => new { e.FileGenerationTypeId, e.InternalCode });

            entity
                .ToTable("ExecutionBrokerCodeMapping", "trans")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("H_ExecutionBrokerCodeMapping", "trans");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.InternalCode).HasMaxLength(20);
            entity.Property(e => e.CounterpartyCode).HasMaxLength(20);

            entity.HasOne(d => d.FileGenerationType).WithMany(p => p.ExecutionBrokerCodeMappings)
                .HasForeignKey(d => d.FileGenerationTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExecutionBrokerCodeMapping_FileGenerationType");
        });

        modelBuilder.Entity<ExecutionBrokerMapping>(entity =>
        {
            entity.HasKey(e => new { e.TradeDesk, e.ExecutionBroker });

            entity
                .ToTable("ExecutionBrokerMapping", "trans")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("H_ExecutionBrokerMapping", "trans");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.TradeDesk).HasMaxLength(20);
            entity.Property(e => e.ExecutionBroker).HasMaxLength(20);
        });

        modelBuilder.Entity<FileContentType>(entity =>
        {
            entity
                .ToTable("FileContentType", "trans")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("H_FileContentType", "trans");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Mnemonic).HasMaxLength(5);
        });

        modelBuilder.Entity<FileGenerationProfile>(entity =>
        {
            entity
                .ToTable("FileGenerationProfile", "trans")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("H_FileGenerationProfile", "trans");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasIndex(e => new { e.FileGenerationTypeId, e.PortfolioId }, "UQ_FileGenerationProfile").IsUnique();

            entity.Property(e => e.FileGenerationProfileId).ValueGeneratedNever();
            entity.Property(e => e.DateParamFormat).HasMaxLength(20);
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.FileName).HasMaxLength(200);
            entity.Property(e => e.FunctionName).HasMaxLength(150);
            entity.Property(e => e.OutputFolder).HasMaxLength(255);
            entity.Property(e => e.Separator)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.FileGenerationType).WithMany(p => p.FileGenerationProfiles)
                .HasForeignKey(d => d.FileGenerationTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FileGenerationProfile_FileGenerationType");

            entity.HasOne(d => d.TransmissionProfile).WithMany(p => p.FileGenerationProfiles)
                .HasForeignKey(d => d.TransmissionProfileId)
                .HasConstraintName("FK_FileGenerationProfile_TransmissionProfile");
        });

        modelBuilder.Entity<FileGenerationType>(entity =>
        {
            entity
                .ToTable("FileGenerationType", "trans")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("H_FileGenerationType", "trans");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Mnemonic).HasMaxLength(20);
        });

        modelBuilder.Entity<FileTransmission>(entity =>
        {
            entity.ToTable("FileTransmission", "trans");

            entity.Property(e => e.ContentType).HasMaxLength(5);
            entity.Property(e => e.Counterparty).HasMaxLength(50);
            entity.Property(e => e.TransmissionType).HasMaxLength(20);
            entity.Property(e => e.TransmittedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<FtpConfiguration>(entity =>
        {
            entity
                .ToTable("FtpConfiguration", "trans")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("H_FtpConfiguration", "trans");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.FtpConfigurationId).ValueGeneratedNever();
            entity.Property(e => e.Host).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(30);
            entity.Property(e => e.RemoteFolder).HasMaxLength(100);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<FxRate>(entity =>
        {
            entity.HasKey(e => new { e.BaseCurrency, e.QuoteCurrency });

            entity.ToTable("FxRate", "trans");

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

            entity.ToTable("Instrument", "trans");

            entity.Property(e => e.InstrumentId).ValueGeneratedNever();
            entity.Property(e => e.BbgUniqueId).HasMaxLength(30);
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Exchange).HasMaxLength(5);
            entity.Property(e => e.FuturePointValue).HasColumnType("decimal(14, 6)");
            entity.Property(e => e.InstrumentType).HasMaxLength(10);
            entity.Property(e => e.Isin)
                .HasMaxLength(12)
                .HasColumnName("ISIN");
            entity.Property(e => e.MarketSector).HasMaxLength(6);
            entity.Property(e => e.MaturityDate).HasColumnType("date");
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.PriceScalingFactor).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.PrimaryMic).HasMaxLength(10);
            entity.Property(e => e.QuoteCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Symbol).HasMaxLength(30);
        });

        modelBuilder.Entity<InstrumentPricing>(entity =>
        {
            entity.HasKey(e => e.InstrumentId);

            entity.ToTable("InstrumentPricing", "trans");

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

        modelBuilder.Entity<PostTradeServiceMapping>(entity =>
        {
            entity.HasKey(e => new { e.ExecutionBroker, e.PortfolioId, e.InstrumentType, e.IsSwap });

            entity
                .ToTable("PostTradeServiceMapping", "trans")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("H_PostTradeServiceMapping", "trans");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.ExecutionBroker).HasMaxLength(20);
            entity.Property(e => e.InstrumentType).HasMaxLength(10);
            entity.Property(e => e.Clearing).HasMaxLength(10);
            entity.Property(e => e.Custody).HasMaxLength(10);
            entity.Property(e => e.PrimeBrokerage).HasMaxLength(10);
        });

        modelBuilder.Entity<PrimeBrokerCodeMapping>(entity =>
        {
            entity.HasKey(e => new { e.FileGenerationType, e.InternalCode });

            entity
                .ToTable("PrimeBrokerCodeMapping", "trans")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("H_PrimeBrokerCodeMapping", "trans");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.FileGenerationType).HasMaxLength(20);
            entity.Property(e => e.InternalCode).HasMaxLength(20);
            entity.Property(e => e.CounterpartyCode).HasMaxLength(20);
        });

        modelBuilder.Entity<PrimeBrokerMapping>(entity =>
        {
            entity.HasKey(e => new { e.ExecutionBroker, e.PortfolioId, e.InstrumentType, e.IsSwap });

            entity
                .ToTable("PrimeBrokerMapping", "trans")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("H_PrimeBrokerMapping", "trans");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.ExecutionBroker).HasMaxLength(20);
            entity.Property(e => e.InstrumentType).HasMaxLength(10);
            entity.Property(e => e.PrimeBroker).HasMaxLength(10);
        });

        modelBuilder.Entity<Trade>(entity =>
        {
            entity.ToTable("Trade", "trans");

            entity.Property(e => e.TradeId).ValueGeneratedNever();
            entity.Property(e => e.AvgPrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.BookedOn).HasColumnType("datetime");
            entity.Property(e => e.BrokerCode).HasMaxLength(10);
            entity.Property(e => e.BrokerCommission).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.BuySellIndicator)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CommissionRate).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DayAveragePrice).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.EmsxOrderCreatedOn).HasColumnType("date");
            entity.Property(e => e.ExchangeCode).HasMaxLength(20);
            entity.Property(e => e.ExecutionChannel).HasMaxLength(10);
            entity.Property(e => e.FxCurrency1)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FxCurrency2)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Fxcurrency1Amount)
                .HasColumnType("decimal(24, 6)")
                .HasColumnName("FXCurrency1Amount");
            entity.Property(e => e.Fxcurrency2Amount)
                .HasColumnType("decimal(24, 6)")
                .HasColumnName("FXCurrency2Amount");
            entity.Property(e => e.LocalToSettleFxRate).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.MiscFees).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.NetAmount).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Notes).HasMaxLength(300);
            entity.Property(e => e.Principal).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Sedol).HasMaxLength(7);
            entity.Property(e => e.SettlementCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SettlementDate).HasColumnType("date");
            entity.Property(e => e.TotalCharges).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.TradeCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TradeDate).HasColumnType("date");
            entity.Property(e => e.TradeDesk).HasMaxLength(10);
            entity.Property(e => e.TradeStatus).HasMaxLength(5);
            entity.Property(e => e.Trader).HasMaxLength(30);

            entity.HasOne(d => d.Instrument).WithMany(p => p.Trades)
                .HasForeignKey(d => d.InstrumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trade_Instrument");
        });

        modelBuilder.Entity<TradeAllocation>(entity =>
        {
            entity.ToTable("TradeAllocation", "trans");

            entity.Property(e => e.TradeAllocationId).ValueGeneratedNever();
            entity.Property(e => e.Commission).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Fees).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.GrossAmount).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.NetAmount).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PositionSide)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Price).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.TradingAccount).HasMaxLength(30);

            entity.HasOne(d => d.Trade).WithMany(p => p.TradeAllocations)
                .HasForeignKey(d => d.TradeId)
                .HasConstraintName("FK_TradeAllocation_Trade");
        });

        modelBuilder.Entity<TransmissionChannel>(entity =>
        {
            entity
                .ToTable("TransmissionChannel", "trans")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("H_TransmissionChannel", "trans");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.TransmissionChannelId).ValueGeneratedNever();
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Mnemonic).HasMaxLength(10);
        });

        modelBuilder.Entity<TransmissionProfile>(entity =>
        {
            entity
                .ToTable("TransmissionProfile", "trans")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("H_TransmissionProfile", "trans");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasIndex(e => e.Mnemonic, "UC_TransmissionProfile_Mnemonic").IsUnique();

            entity.HasIndex(e => new { e.CounterPartyId, e.FileContentTypeId }, "UQ_CounterPartyId_FileContentTypeId").IsUnique();

            entity.Property(e => e.TransmissionProfileId).ValueGeneratedNever();
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Mnemonic).HasMaxLength(10);

            entity.HasOne(d => d.CounterParty).WithMany(p => p.TransmissionProfiles)
                .HasForeignKey(d => d.CounterPartyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TransmissionProfile_CounterParty");

            entity.HasOne(d => d.EmailConfiguration).WithMany(p => p.TransmissionProfiles)
                .HasForeignKey(d => d.EmailConfigurationId)
                .HasConstraintName("FK_TransmissionProfile_EmailConfiguration");

            entity.HasOne(d => d.EncryptionProfile).WithMany(p => p.TransmissionProfiles)
                .HasForeignKey(d => d.EncryptionProfileId)
                .HasConstraintName("FK_TransmissionProfile_EncryptionProfile");

            entity.HasOne(d => d.FileContentType).WithMany(p => p.TransmissionProfiles)
                .HasForeignKey(d => d.FileContentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TransmissionProfile_FileContentType");

            entity.HasOne(d => d.FtpConfiguration).WithMany(p => p.TransmissionProfiles)
                .HasForeignKey(d => d.FtpConfigurationId)
                .HasConstraintName("FK_TransmissionProfile_FtpConfiguration");

            entity.HasOne(d => d.TransmissionScheduleType).WithMany(p => p.TransmissionProfiles)
                .HasForeignKey(d => d.TransmissionScheduleTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TransmissionProfile_TransmissionScheduleType");
        });

        modelBuilder.Entity<TransmissionScheduleType>(entity =>
        {
            entity
                .ToTable("TransmissionScheduleType", "trans")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("H_TransmissionScheduleType", "trans");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.TransmissionScheduleTypeId).ValueGeneratedNever();
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Mnemonic).HasMaxLength(10);
        });

        modelBuilder.Entity<TransmittedFile>(entity =>
        {
            entity.ToTable("TransmittedFile", "trans");

            entity.Property(e => e.FileName).HasMaxLength(200);
            entity.Property(e => e.FilePath).HasMaxLength(200);

            entity.HasOne(d => d.FileTransmission).WithMany(p => p.TransmittedFiles)
                .HasForeignKey(d => d.FileTransmissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TransmittedFile_FileTransmission");
        });

        modelBuilder.Entity<TransmittedTrade>(entity =>
        {
            entity.HasKey(e => new { e.FileTransmissionId, e.TradeId });

            entity.ToTable("TransmittedTrade", "trans");
        });

        modelBuilder.Entity<VwCmglfndTradesFileGsSynthTest>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwCMGLFND_TradesFile_GS_Synth_TEST", "trans");

            entity.Property(e => e.AccountNumberOrAcronym)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("Account number or acronym");
            entity.Property(e => e.AccruedInterest)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Accrued Interest");
            entity.Property(e => e.Broker)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.CancelCorrectIndicator)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Cancel correct indicator");
            entity.Property(e => e.ClearingAgent)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Clearing Agent");
            entity.Property(e => e.Commission).HasColumnType("decimal(24, 2)");
            entity.Property(e => e.CoutrySettlementCode)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Coutry Settlement Code");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Currency Code");
            entity.Property(e => e.Custodian)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.MiscMoney)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Misc Money");
            entity.Property(e => e.NetAmount)
                .HasColumnType("decimal(24, 2)")
                .HasColumnName("Net Amount");
            entity.Property(e => e.OptionCalPutIndicator)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Option cal put indicator");
            entity.Property(e => e.OptionExpiryDate)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Option expiry date");
            entity.Property(e => e.OptionStrikePrice)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Option strike price");
            entity.Property(e => e.OptionUnderlyer)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Option underlyer");
            entity.Property(e => e.OrderNumber)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("Order Number");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.Principal).HasColumnType("decimal(24, 2)");
            entity.Property(e => e.SecFees)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("SEC Fees");
            entity.Property(e => e.SecurityIdentifier)
                .HasMaxLength(4000)
                .HasColumnName("Security Identifier");
            entity.Property(e => e.SecurityType)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("Security Type");
            entity.Property(e => e.SettlementDate)
                .HasMaxLength(4000)
                .HasColumnName("Settlement Date");
            entity.Property(e => e.TradeDate)
                .HasMaxLength(4000)
                .HasColumnName("Trade Date");
            entity.Property(e => e.TradeTax)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Trade tax");
            entity.Property(e => e.Trailer)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Trailer1)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Trailer 1");
            entity.Property(e => e.Trailer2)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Trailer 2");
            entity.Property(e => e.Trailer3)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Trailer 3");
            entity.Property(e => e.Trailer4)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Trailer 4");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Transaction type");
        });

        modelBuilder.Entity<VwCmglfndTradesFileMsd01Test>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwCMGLFND_TradesFileMSD01_TEST", "trans");

            entity.Property(e => e.Account)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.AveragePriceInd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Average_Price_Ind");
            entity.Property(e => e.BlockTradeInd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Block_Trade_Ind");
            entity.Property(e => e.BuySellIndicator)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Buy Sell Indicator");
            entity.Property(e => e.CallPut)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Call/Put");
            entity.Property(e => e.ClearingBroker)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Clearing_Broker");
            entity.Property(e => e.ClientRefNo).HasColumnName("Client_Ref_No");
            entity.Property(e => e.Commission).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.CommissionCcy)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Commission_CCY");
            entity.Property(e => e.ContractDay)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Contract_Day");
            entity.Property(e => e.ContractMonth)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Contract_Month");
            entity.Property(e => e.ContractSecurityDescription)
                .HasMaxLength(200)
                .HasColumnName("Contract_Security_Description");
            entity.Property(e => e.ContractYear)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Contract_Year");
            entity.Property(e => e.DealId)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ExchangeFee)
                .HasColumnType("decimal(12, 6)")
                .HasColumnName("Exchange_Fee");
            entity.Property(e => e.ExchangeFeeCcy)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Exchange_Fee_CCY");
            entity.Property(e => e.ExchangeForPhysicalInd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Exchange_for_Physical_Ind");
            entity.Property(e => e.ExecutingBroker)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Executing_Broker");
            entity.Property(e => e.ExecutionFee)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Execution_Fee");
            entity.Property(e => e.ExecutionFeeCcy)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Execution_Fee_CCY");
            entity.Property(e => e.ExecutionTime)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ExecutionType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Execution_Type");
            entity.Property(e => e.GiveUpReference)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Give_Up_Reference");
            entity.Property(e => e.HearsayInd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Hearsay_Ind");
            entity.Property(e => e.MarketExchange)
                .HasMaxLength(20)
                .HasColumnName("Market/Exchange");
            entity.Property(e => e.NightTradeInd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Night_Trade_Ind");
            entity.Property(e => e.OffExchangeInd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Off_Exchange_Ind");
            entity.Property(e => e.OrderToCloseInd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("order_To_Close_Ind");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.SecIdentifier)
                .HasMaxLength(30)
                .HasColumnName("Sec_Identifier");
            entity.Property(e => e.SecIdentifierType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Sec_identifier_Type");
            entity.Property(e => e.SpreadTradeInd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Spread_Trade_Ind");
            entity.Property(e => e.StrikePrice)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Strike_Price");
            entity.Property(e => e.TradeDate)
                .HasMaxLength(10)
                .HasColumnName("Trade_Date");
            entity.Property(e => e.TradeType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Trade_Type");
            entity.Property(e => e.TransactionStatus)
                .HasMaxLength(5)
                .HasColumnName("Transaction_Status");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("Transaction_Type");
            entity.Property(e => e.VersionNumber)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Version_Number");
        });

        modelBuilder.Entity<VwCmglfndTradesFileMssw002Test>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwCMGLFND_TradesFileMSSW002_TEST", "trans");

            entity.Property(e => e.AccountId)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("Account Id");
            entity.Property(e => e.AcquisitionDate)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Acquisition Date");
            entity.Property(e => e.AssociatedTradeId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Associated Trade Id");
            entity.Property(e => e.BasketId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Basket Id");
            entity.Property(e => e.BookId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Book Id");
            entity.Property(e => e.BrokerCounterparty)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Broker / Counterparty");
            entity.Property(e => e.BuySellIndicator)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Buy Sell Indicator");
            entity.Property(e => e.ClientStrategy2UsedForPeps)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Client Strategy 2 (Used for PEPS)");
            entity.Property(e => e.ClientTradeRefNo).HasColumnName("Client Trade Ref No.");
            entity.Property(e => e.Comments).HasMaxLength(300);
            entity.Property(e => e.Custodian)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.DealId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Deal Id");
            entity.Property(e => e.DividendEntitlementPercent)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Dividend Entitlement Percent");
            entity.Property(e => e.ExchangeCode)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Exchange Code");
            entity.Property(e => e.ExecutingBrokerCommissionIndicator)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Executing broker Commission Indicator");
            entity.Property(e => e.ExecutionAccount)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Execution Account");
            entity.Property(e => e.ExecutionBrokerCommission)
                .HasColumnType("decimal(24, 2)")
                .HasColumnName("Execution Broker Commission");
            entity.Property(e => e.HearsayInd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Hearsay Ind");
            entity.Property(e => e.Lei)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("LEI");
            entity.Property(e => e.LongShortIndicator)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Long Short Indicator");
            entity.Property(e => e.MoneyManager)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Money Manager");
            entity.Property(e => e.MsFees)
                .HasColumnType("decimal(12, 6)")
                .HasColumnName("MS Fees");
            entity.Property(e => e.MsFeesIndicator)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("MS fees Indicator.");
            entity.Property(e => e.NetAmount)
                .HasColumnType("decimal(24, 2)")
                .HasColumnName("Net Amount");
            entity.Property(e => e.NotRequired)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Not Required");
            entity.Property(e => e.OriginalTaxlotTransactionDate)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Original taxlot transaction date");
            entity.Property(e => e.OriginalTaxlotTransactionPrice)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Original Taxlot transaction price");
            entity.Property(e => e.PositionType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Position Type");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PriceCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Price Currency");
            entity.Property(e => e.PriceFxRate)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Price FX Rate");
            entity.Property(e => e.PriceIndicator)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Price Indicator");
            entity.Property(e => e.Principal).HasColumnType("decimal(24, 2)");
            entity.Property(e => e.ResearchFee)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Research Fee");
            entity.Property(e => e.ResearchFeeIndicator)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Research Fee Indicator");
            entity.Property(e => e.ResetIndicator)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Reset Indicator");
            entity.Property(e => e.SecurityDescription)
                .HasMaxLength(200)
                .HasColumnName("Security Description");
            entity.Property(e => e.SecurityIdentifier).HasMaxLength(30);
            entity.Property(e => e.SecurityIdentifierType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Security Identifier Type");
            entity.Property(e => e.SettlementCcy)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Settlement CCY");
            entity.Property(e => e.SettlementDate)
                .HasMaxLength(4000)
                .HasColumnName("Settlement Date");
            entity.Property(e => e.SnsReference)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("SNS reference");
            entity.Property(e => e.Spread)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.SwapReferenceNo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Swap Reference No.");
            entity.Property(e => e.TaxLotId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("TaxLot Id");
            entity.Property(e => e.TaxlotCloseoutMethod)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Taxlot Closeout Method");
            entity.Property(e => e.TradeDate)
                .HasMaxLength(4000)
                .HasColumnName("Trade Date");
            entity.Property(e => e.TransactionLevel)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Transaction Level");
            entity.Property(e => e.TransactionStatus)
                .HasMaxLength(5)
                .HasColumnName("Transaction Status");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("Transaction Type");
        });

        modelBuilder.Entity<VwCmglfndVwTradesFileMsfssw002GsTest>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwCMGLFND_vwTradesFileMSFSSW002_GS_TEST", "trans");

            entity.Property(e => e.AccountId)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("Account Id");
            entity.Property(e => e.AcquisitionDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.AssociatedTradeId)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.BasketId)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.BookId)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.BrokerCommission).HasColumnType("decimal(24, 2)");
            entity.Property(e => e.BrokerCommissionInd)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.BrokerCouterparty)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Broker/Couterparty");
            entity.Property(e => e.BuySell)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Buy/Sell");
            entity.Property(e => e.CloseOutMethod)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.CollateralPledge)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Comments)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Custodian)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.DaycountConvention)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.DealId)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.DivEntitlPercent)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.DividendAmount)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.DividendPayoutDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.EquitySpread)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ExchangeCode)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ExecutionAccount)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.FixingFrequency)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.FloatingRate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.FuutPartUnwindInd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Fuut/Part Unwind Ind");
            entity.Property(e => e.FxRate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.HearsayInd)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Lei)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("LEI");
            entity.Property(e => e.LongShort)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Long/Short");
            entity.Property(e => e.MaturityDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.MoneyManager)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Msfees)
                .HasColumnType("decimal(12, 6)")
                .HasColumnName("MSFees");
            entity.Property(e => e.MsfeesInd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("MSFeesInd");
            entity.Property(e => e.NetAmount).HasColumnType("decimal(24, 2)");
            entity.Property(e => e.NextResetDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.NotRequired)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.PaymentDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.PaymentFrequency)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.PositionType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PriceCurrency)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.PriceIndicator)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Principal).HasColumnType("decimal(24, 2)");
            entity.Property(e => e.ProductType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ResearchFee)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ResearchFeeInd)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ResetIndicator)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ResetPrice)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.RollConvention)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.SecurityDescription).HasMaxLength(200);
            entity.Property(e => e.SecurityIdentifier).HasMaxLength(30);
            entity.Property(e => e.SecurityIdentifierType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.SettlementCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SettlementDate).HasMaxLength(4000);
            entity.Property(e => e.SnSreference)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("SnSReference");
            entity.Property(e => e.Spread)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.SwapReferenceNo)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TaxDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TaxLotId)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TaxPrice)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TradeDate).HasMaxLength(4000);
            entity.Property(e => e.TransLevel)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TransactionStatus).HasMaxLength(5);
            entity.Property(e => e.TrasationType)
                .HasMaxLength(5)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwCmglfndVwTradesFileMsfssw002MsTest>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwCMGLFND_vwTradesFileMSFSSW002_MS_TEST", "trans");

            entity.Property(e => e.AccountId)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("Account Id");
            entity.Property(e => e.AcquisitionDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.AssociatedTradeId)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.BasketId)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.BookId)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.BrokerCommission).HasColumnType("decimal(24, 2)");
            entity.Property(e => e.BrokerCommissionInd)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.BrokerCouterparty)
                .HasMaxLength(10)
                .HasColumnName("Broker/Couterparty");
            entity.Property(e => e.BuySell)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Buy/Sell");
            entity.Property(e => e.CloseOutMethod)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.CollateralPledge)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Comments)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Custodian)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.DaycountConvention)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.DealId)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.DivEntitlPercent)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.DividendAmount)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.DividendPayoutDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.EquitySpread)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ExchangeCode)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ExecutionAccount)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.FixingFrequency)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.FloatingRate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.FuutPartUnwindInd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Fuut/Part Unwind Ind");
            entity.Property(e => e.FxRate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.HearsayInd)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Lei)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("LEI");
            entity.Property(e => e.LongShort)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Long/Short");
            entity.Property(e => e.MaturityDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.MoneyManager)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Msfees)
                .HasColumnType("decimal(12, 6)")
                .HasColumnName("MSFees");
            entity.Property(e => e.MsfeesInd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("MSFeesInd");
            entity.Property(e => e.NetAmount).HasColumnType("decimal(24, 2)");
            entity.Property(e => e.NextResetDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.NotRequired)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.PaymentDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.PaymentFrequency)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.PositionType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PriceCurrency)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.PriceIndicator)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Principal).HasColumnType("decimal(24, 2)");
            entity.Property(e => e.ProductType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ResearchFee)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ResearchFeeInd)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ResetIndicator)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ResetPrice)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.RollConvention)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.SecurityDescription).HasMaxLength(200);
            entity.Property(e => e.SecurityIdentifier).HasMaxLength(30);
            entity.Property(e => e.SecurityIdentifierType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.SettlementCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SettlementDate).HasMaxLength(4000);
            entity.Property(e => e.SnSreference)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("SnSReference");
            entity.Property(e => e.Spread)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.SwapReferenceNo)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TaxDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TaxLotId)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TaxPrice)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TradeDate).HasMaxLength(4000);
            entity.Property(e => e.TransLevel)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TransactionStatus).HasMaxLength(5);
            entity.Property(e => e.TrasationType)
                .HasMaxLength(5)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwCmglfndVwTradesFileMsfstr001GsTest>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwCMGLFND_vwTradesFileMSFSTR001_GS_TEST", "trans");

            entity.Property(e => e.AccountId)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.AcqDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Associated)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("Associated#");
            entity.Property(e => e.BookId)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.BuySell)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Buy/Sell");
            entity.Property(e => e.ClientRef).HasColumnName("ClientRef#");
            entity.Property(e => e.CloseOutMethod)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Comments)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.CommissionAmount).HasColumnType("decimal(24, 2)");
            entity.Property(e => e.CommissionIndicator)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Custodian)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.DealId)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ExRate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ExchangeCode)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ExecAccount)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.ExecutionBroker)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.FeeInd)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.HearsayInd)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Interest)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.InterestIndicator)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.LongShort)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Long/Short");
            entity.Property(e => e.MoneyManager)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.NetAmount).HasColumnType("decimal(24, 2)");
            entity.Property(e => e.PositionType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.PriceAmount).HasColumnType("decimal(22, 10)");
            entity.Property(e => e.PriceIndicator)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Principal).HasColumnType("decimal(24, 2)");
            entity.Property(e => e.SecId)
                .HasMaxLength(30)
                .HasColumnName("SecID");
            entity.Property(e => e.SecType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.SecurityDescription).HasMaxLength(200);
            entity.Property(e => e.SettlementCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SettlementDate).HasMaxLength(4000);
            entity.Property(e => e.Tax2)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TaxDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TaxFees)
                .HasColumnType("decimal(12, 6)")
                .HasColumnName("Tax/Fees");
            entity.Property(e => e.TaxLotId)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TaxPrice)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TradeDate).HasMaxLength(4000);
            entity.Property(e => e.TransLevel)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TransactionStatus).HasMaxLength(5);
            entity.Property(e => e.TrasationType)
                .HasMaxLength(5)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwCmglfndVwTradesFileMsfstr001MsTest>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwCMGLFND_vwTradesFileMSFSTR001_MS_TEST", "trans");

            entity.Property(e => e.AccountId)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.AcqDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Associated)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("Associated#");
            entity.Property(e => e.BookId)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.BuySell)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Buy/Sell");
            entity.Property(e => e.ClientRef).HasColumnName("ClientRef#");
            entity.Property(e => e.CloseOutMethod)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Comments)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.CommissionAmount).HasColumnType("decimal(24, 2)");
            entity.Property(e => e.CommissionIndicator)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Custodian)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.DealId)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ExRate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ExchangeCode)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ExecAccount)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.ExecutionBroker).HasMaxLength(10);
            entity.Property(e => e.FeeInd)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.HearsayInd)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Interest)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.InterestIndicator)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.LongShort)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Long/Short");
            entity.Property(e => e.MoneyManager)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.NetAmount).HasColumnType("decimal(24, 2)");
            entity.Property(e => e.PositionType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.PriceAmount).HasColumnType("decimal(22, 10)");
            entity.Property(e => e.PriceIndicator)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Principal).HasColumnType("decimal(24, 2)");
            entity.Property(e => e.SecId)
                .HasMaxLength(30)
                .HasColumnName("SecID");
            entity.Property(e => e.SecType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.SecurityDescription).HasMaxLength(200);
            entity.Property(e => e.SettlementCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SettlementDate).HasMaxLength(4000);
            entity.Property(e => e.Tax2)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TaxDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TaxFees)
                .HasColumnType("decimal(12, 6)")
                .HasColumnName("Tax/Fees");
            entity.Property(e => e.TaxLotId)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TaxPrice)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TradeDate).HasMaxLength(4000);
            entity.Property(e => e.TransLevel)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TransactionStatus).HasMaxLength(5);
            entity.Property(e => e.TrasationType)
                .HasMaxLength(5)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwLastFileTransmission>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwLastFileTransmission", "trans");

            entity.Property(e => e.ContentType).HasMaxLength(5);
            entity.Property(e => e.Counterparty).HasMaxLength(50);
            entity.Property(e => e.TransmissionType).HasMaxLength(20);
            entity.Property(e => e.TransmittedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<VwPnlInnocapWithRoll>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwPnlInnocap_withRoll", "trans");

            entity.Property(e => e.AssetType)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Asset Type");
            entity.Property(e => e.BaseCost)
                .HasColumnType("decimal(37, 12)")
                .HasColumnName("Base Cost");
            entity.Property(e => e.BaseMv)
                .HasColumnType("decimal(38, 6)")
                .HasColumnName("Base MV");
            entity.Property(e => e.BasePrice)
                .HasColumnType("decimal(37, 12)")
                .HasColumnName("Base Price");
            entity.Property(e => e.BloombergId)
                .HasMaxLength(30)
                .HasColumnName("Bloomberg ID");
            entity.Property(e => e.Ccy)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CCY");
            entity.Property(e => e.ClearingBroker)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Clearing Broker");
            entity.Property(e => e.Cusip)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Daily)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Daily %");
            entity.Property(e => e.FxRate)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("FX Rate");
            entity.Property(e => e.Isin)
                .HasMaxLength(12)
                .HasColumnName("ISIN");
            entity.Property(e => e.LocalCost)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Local Cost");
            entity.Property(e => e.LocalMv)
                .HasColumnType("decimal(38, 11)")
                .HasColumnName("Local MV");
            entity.Property(e => e.LocalPrice)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("Local Price");
            entity.Property(e => e.Mtd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("MTD %");
            entity.Property(e => e.Sedol)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.SharesNotional).HasColumnName("Shares/Notional");
            entity.Property(e => e.SideLongShort)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("Side (Long/Short)");
            entity.Property(e => e.Ticker).HasMaxLength(30);
            entity.Property(e => e.TotalDailyPnlRealizedUnrealizedBase)
                .HasColumnType("decimal(38, 6)")
                .HasColumnName("Total daily PNL (realized & unrealized) Base");
            entity.Property(e => e.TotalDailyPnlRealizedUnrealizedLocal)
                .HasColumnType("decimal(38, 6)")
                .HasColumnName("Total daily PNL (realized & unrealized) Local");
            entity.Property(e => e.TotalMtdPnlRealizedUnrealizedBase)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Total MTD PNL (realized & unrealized) Base");
            entity.Property(e => e.TotalMtdPnlRealizedUnrealizedLocal)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Total MTD PNL (realized & unrealized) Local");
        });

        modelBuilder.Entity<VwTradesFileCapricorn>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwTradesFileCapricorn", "trans");

            entity.Property(e => e.Account)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.AccruedInterest)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Accrued interest");
            entity.Property(e => e.Activity).HasMaxLength(4000);
            entity.Property(e => e.Broker).HasMaxLength(10);
            entity.Property(e => e.ClearingAgent)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Clearing Agent");
            entity.Property(e => e.Commission).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.Cusip)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CUSIP");
            entity.Property(e => e.Custodian)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ExchangeMic)
                .HasMaxLength(20)
                .HasColumnName("Exchange-MIC");
            entity.Property(e => e.ExpiryDate)
                .HasMaxLength(4000)
                .HasColumnName("Expiry Date");
            entity.Property(e => e.FillledQuantity).HasColumnName("Fillled Quantity");
            entity.Property(e => e.IsCfd).HasColumnName("Is_CFD");
            entity.Property(e => e.Isin)
                .HasMaxLength(12)
                .HasColumnName("ISIN");
            entity.Property(e => e.MiscMoney)
                .HasColumnType("decimal(12, 6)")
                .HasColumnName("Misc money");
            entity.Property(e => e.NetAmount)
                .HasColumnType("decimal(24, 2)")
                .HasColumnName("Net amount");
            entity.Property(e => e.OrderNumber).HasColumnName("Order number");
            entity.Property(e => e.OrderQuantity).HasColumnName("Order Quantity");
            entity.Property(e => e.Price).HasColumnType("decimal(31, 12)");
            entity.Property(e => e.Principal).HasColumnType("decimal(24, 2)");
            entity.Property(e => e.PutCall)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Put/Call");
            entity.Property(e => e.SecFee)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Sec Fee");
            entity.Property(e => e.SecurityDescription)
                .HasMaxLength(200)
                .HasColumnName("Security Description");
            entity.Property(e => e.SecurityType)
                .HasMaxLength(10)
                .HasColumnName("Security Type");
            entity.Property(e => e.Sedol)
                .HasMaxLength(7)
                .HasColumnName("SEDOL");
            entity.Property(e => e.SettleDate)
                .HasMaxLength(4000)
                .HasColumnName("Settle date");
            entity.Property(e => e.SettlementCcy)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Settlement Ccy");
            entity.Property(e => e.Strike)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TickerSymbol)
                .HasMaxLength(30)
                .HasColumnName("Ticker Symbol");
            entity.Property(e => e.TradeDate)
                .HasMaxLength(4000)
                .HasColumnName("Trade date");
            entity.Property(e => e.TradeTax)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Trade tax");
            entity.Property(e => e.Trader).HasMaxLength(30);
            entity.Property(e => e.TransactionType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Transaction type");
        });

        modelBuilder.Entity<VwTradesFileInnocapFx>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwTradesFileInnocapFX", "trans");

            entity.Property(e => e.AccountId)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.AcquisitionDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.AssociatedTradeId)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.BuyCcy)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.BuyQuantity).HasColumnType("decimal(24, 2)");
            entity.Property(e => e.ClientBaseEquivalent)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Comments)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Custodian)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.DealId)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.DealtCcy)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ExecAccount)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.ExecutionBroker).HasMaxLength(10);
            entity.Property(e => e.FarValueDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.FarValueRate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.HeasayInd)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.HedgeOrSpeculative)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.InstrumentType)
                .HasMaxLength(7)
                .IsUnicode(false);
            entity.Property(e => e.MoneyManager)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.NdfFixingDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.NdfFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.NdfLinkedTrade)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Pb)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("PB");
            entity.Property(e => e.Rate).HasColumnType("decimal(38, 14)");
            entity.Property(e => e.Reporter)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.SellCcy)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SellQuantity).HasColumnType("decimal(24, 2)");
            entity.Property(e => e.TaxIndicator)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TradeDate).HasMaxLength(4000);
            entity.Property(e => e.TradeType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TransLevel)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TransactionStatus).HasMaxLength(5);
            entity.Property(e => e.TrasationType)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.ValueDate).HasMaxLength(4000);
        });

        modelBuilder.Entity<VwTradesFileInnocapSw>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwTradesFileInnocapSW", "trans");

            entity.Property(e => e.AccountId)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("Account Id");
            entity.Property(e => e.AcquisitionDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.AssociatedTradeId)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.BasketId)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.BookId)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.BrokerCommission).HasColumnType("decimal(24, 2)");
            entity.Property(e => e.BrokerCommissionInd)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.BrokerCouterparty)
                .HasMaxLength(10)
                .HasColumnName("Broker/Couterparty");
            entity.Property(e => e.BuySell)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Buy/Sell");
            entity.Property(e => e.CloseOutMethod)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.CollateralPledge)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Comments)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Custodian)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.DaycountConvention)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.DealId)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.DivEntitlPercent)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.DividendAmount)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.DividendPayoutDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.EquitySpread)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ExchangeCode)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ExecutionAccount)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.FixingFrequency)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.FloatingRate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.FuutPartUnwindInd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Fuut/Part Unwind Ind");
            entity.Property(e => e.FxRate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.HearsayInd)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Lei)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("LEI");
            entity.Property(e => e.LongShort)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Long/Short");
            entity.Property(e => e.MaturityDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.MoneyManager)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Msfees)
                .HasColumnType("decimal(12, 6)")
                .HasColumnName("MSFees");
            entity.Property(e => e.MsfeesInd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("MSFeesInd");
            entity.Property(e => e.NetAmount).HasColumnType("decimal(24, 2)");
            entity.Property(e => e.NextResetDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.NotRequired)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.PaymentDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.PaymentFrequency)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.PositionType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PriceCurrency)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.PriceIndicator)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Principal).HasColumnType("decimal(24, 2)");
            entity.Property(e => e.ProductType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ResearchFee)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ResearchFeeInd)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ResetIndicator)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ResetPrice)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.RollConvention)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.SecurityDescription).HasMaxLength(200);
            entity.Property(e => e.SecurityIdentifier).HasMaxLength(30);
            entity.Property(e => e.SecurityIdentifierType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.SettlementCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SettlementDate).HasMaxLength(4000);
            entity.Property(e => e.SnSreference)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("SnSReference");
            entity.Property(e => e.Spread)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.SwapReferenceNo)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TaxDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TaxLotId)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TaxPrice)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TradeDate).HasMaxLength(4000);
            entity.Property(e => e.TransLevel)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TransactionStatus).HasMaxLength(5);
            entity.Property(e => e.TrasationType)
                .HasMaxLength(5)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwTradesFileInnocapTr>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwTradesFileInnocapTR", "trans");

            entity.Property(e => e.AccountId)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.AcqDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Associated)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("Associated#");
            entity.Property(e => e.BookId)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.BuySell)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Buy/Sell");
            entity.Property(e => e.ClientRef).HasColumnName("ClientRef#");
            entity.Property(e => e.CloseOutMethod)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Comments)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.CommissionAmount).HasColumnType("decimal(24, 2)");
            entity.Property(e => e.CommissionIndicator)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Custodian)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.DealId)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ExRate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ExchangeCode)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ExecAccount)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.ExecutionBroker).HasMaxLength(10);
            entity.Property(e => e.FeeInd)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.HearsayInd)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Interest)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.InterestIndicator)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.LongShort)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Long/Short");
            entity.Property(e => e.MoneyManager)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.NetAmount).HasColumnType("decimal(24, 2)");
            entity.Property(e => e.PositionType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.PriceAmount).HasColumnType("decimal(22, 10)");
            entity.Property(e => e.PriceIndicator)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Principal).HasColumnType("decimal(24, 2)");
            entity.Property(e => e.SecId)
                .HasMaxLength(30)
                .HasColumnName("SecID");
            entity.Property(e => e.SecType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.SecurityDescription).HasMaxLength(200);
            entity.Property(e => e.SettlementCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SettlementDate).HasMaxLength(4000);
            entity.Property(e => e.Tax2)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TaxDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TaxFees)
                .HasColumnType("decimal(12, 6)")
                .HasColumnName("Tax/Fees");
            entity.Property(e => e.TaxLotId)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TaxPrice)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TradeDate).HasMaxLength(4000);
            entity.Property(e => e.TransLevel)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TransactionStatus).HasMaxLength(5);
            entity.Property(e => e.TrasactionType)
                .HasMaxLength(5)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwTradesFileMsd01>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwTradesFileMSD01", "trans");

            entity.Property(e => e.Account)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.AveragePriceInd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Average_Price_Ind");
            entity.Property(e => e.BlockTradeInd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Block_Trade_Ind");
            entity.Property(e => e.BuySellIndicator)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Buy Sell Indicator");
            entity.Property(e => e.CallPut)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Call/Put");
            entity.Property(e => e.ClearingBroker)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Clearing_Broker");
            entity.Property(e => e.ClientRefNo).HasColumnName("Client_Ref_No");
            entity.Property(e => e.Commission).HasColumnType("decimal(12, 6)");
            entity.Property(e => e.CommissionCcy)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Commission_CCY");
            entity.Property(e => e.ContractDay)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Contract_Day");
            entity.Property(e => e.ContractMonth)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Contract_Month");
            entity.Property(e => e.ContractSecurityDescription)
                .HasMaxLength(200)
                .HasColumnName("Contract_Security_Description");
            entity.Property(e => e.ContractYear)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Contract_Year");
            entity.Property(e => e.DealId)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ExchangeFee)
                .HasColumnType("decimal(12, 6)")
                .HasColumnName("Exchange_Fee");
            entity.Property(e => e.ExchangeFeeCcy)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Exchange_Fee_CCY");
            entity.Property(e => e.ExchangeForPhysicalInd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Exchange_for_Physical_Ind");
            entity.Property(e => e.ExecutingBroker)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Executing_Broker");
            entity.Property(e => e.ExecutionFee)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Execution_Fee");
            entity.Property(e => e.ExecutionFeeCcy)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Execution_Fee_CCY");
            entity.Property(e => e.ExecutionTime)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ExecutionType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Execution_Type");
            entity.Property(e => e.GiveUpReference)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Give_Up_Reference");
            entity.Property(e => e.HearsayInd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Hearsay_Ind");
            entity.Property(e => e.MarketExchange)
                .HasMaxLength(20)
                .HasColumnName("Market/Exchange");
            entity.Property(e => e.NightTradeInd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Night_Trade_Ind");
            entity.Property(e => e.OffExchangeInd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Off_Exchange_Ind");
            entity.Property(e => e.OrderToCloseInd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("order_To_Close_Ind");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.SecIdentifier)
                .HasMaxLength(30)
                .HasColumnName("Sec_Identifier");
            entity.Property(e => e.SecIdentifierType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Sec_identifier_Type");
            entity.Property(e => e.SpreadTradeInd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Spread_Trade_Ind");
            entity.Property(e => e.StrikePrice)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Strike_Price");
            entity.Property(e => e.TradeDate)
                .HasMaxLength(10)
                .HasColumnName("Trade_Date");
            entity.Property(e => e.TradeType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Trade_Type");
            entity.Property(e => e.TransactionStatus)
                .HasMaxLength(5)
                .HasColumnName("Transaction_Status");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("Transaction_Type");
            entity.Property(e => e.VersionNumber)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Version_Number");
        });

        modelBuilder.Entity<VwTradesFileMsfsfx>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwTradesFileMSFSFX", "trans");

            entity.Property(e => e.AccountId)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.AcquisitionDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.AssociatedTradeId)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.BuyCcy)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.BuyQuantity).HasColumnType("decimal(24, 2)");
            entity.Property(e => e.ClientBaseEquivalent)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Comments)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Custodian)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.DealId)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.DealtCcy)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ExecAccount)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.ExecutionBroker).HasMaxLength(10);
            entity.Property(e => e.FarValueDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.FarValueRate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.HeasayInd)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.HedgeOrSpeculative)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.InstrumentType)
                .HasMaxLength(7)
                .IsUnicode(false);
            entity.Property(e => e.MoneyManager)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.NdfFixingDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.NdfFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.NdfLinkedTrade)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Pb)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("PB");
            entity.Property(e => e.Rate).HasColumnType("decimal(38, 14)");
            entity.Property(e => e.Reporter)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.SellCcy)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SellQuantity).HasColumnType("decimal(24, 2)");
            entity.Property(e => e.TaxIndicator)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TradeDate).HasMaxLength(4000);
            entity.Property(e => e.TradeType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TransLevel)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TransactionStatus).HasMaxLength(5);
            entity.Property(e => e.TrasationType)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.ValueDate).HasMaxLength(4000);
        });

        modelBuilder.Entity<VwTradesFileMsfssw002>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwTradesFileMSFSSW002", "trans");

            entity.Property(e => e.AccountId)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("Account Id");
            entity.Property(e => e.AcquisitionDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.AssociatedTradeId)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.BasketId)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.BookId)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.BrokerCommission).HasColumnType("decimal(24, 2)");
            entity.Property(e => e.BrokerCommissionInd)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.BrokerCouterparty)
                .HasMaxLength(10)
                .HasColumnName("Broker/Couterparty");
            entity.Property(e => e.BuySell)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Buy/Sell");
            entity.Property(e => e.CloseOutMethod)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.CollateralPledge)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Comments)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Custodian)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.DaycountConvention)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.DealId)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.DivEntitlPercent)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.DividendAmount)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.DividendPayoutDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.EquitySpread)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ExchangeCode)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ExecutionAccount)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.FixingFrequency)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.FloatingRate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.FuutPartUnwindInd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Fuut/Part Unwind Ind");
            entity.Property(e => e.FxRate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.HearsayInd)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Lei)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("LEI");
            entity.Property(e => e.LongShort)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Long/Short");
            entity.Property(e => e.MaturityDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.MoneyManager)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Msfees)
                .HasColumnType("decimal(12, 6)")
                .HasColumnName("MSFees");
            entity.Property(e => e.MsfeesInd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("MSFeesInd");
            entity.Property(e => e.NetAmount).HasColumnType("decimal(24, 2)");
            entity.Property(e => e.NextResetDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.NotRequired)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.PaymentDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.PaymentFrequency)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.PositionType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PriceCurrency)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.PriceIndicator)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Principal).HasColumnType("decimal(24, 2)");
            entity.Property(e => e.ProductType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ResearchFee)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ResearchFeeInd)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ResetIndicator)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ResetPrice)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.RollConvention)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.SecurityDescription).HasMaxLength(200);
            entity.Property(e => e.SecurityIdentifier).HasMaxLength(30);
            entity.Property(e => e.SecurityIdentifierType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.SettlementCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SettlementDate).HasMaxLength(4000);
            entity.Property(e => e.SnSreference)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("SnSReference");
            entity.Property(e => e.Spread)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.SwapReferenceNo)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TaxDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TaxLotId)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TaxPrice)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TradeDate).HasMaxLength(4000);
            entity.Property(e => e.TransLevel)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TransactionStatus).HasMaxLength(5);
            entity.Property(e => e.TrasationType)
                .HasMaxLength(5)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwTradesFileMsfstr001>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwTradesFileMSFSTR001", "trans");

            entity.Property(e => e.AccountId)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.AcqDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Associated)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("Associated#");
            entity.Property(e => e.BookId)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.BuySell)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Buy/Sell");
            entity.Property(e => e.ClientRef).HasColumnName("ClientRef#");
            entity.Property(e => e.CloseOutMethod)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Comments)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.CommissionAmount).HasColumnType("decimal(24, 2)");
            entity.Property(e => e.CommissionIndicator)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Custodian)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.DealId)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ExRate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ExchangeCode)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ExecAccount)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.ExecutionBroker).HasMaxLength(10);
            entity.Property(e => e.FeeInd)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.HearsayInd)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Interest)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.InterestIndicator)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.LongShort)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Long/Short");
            entity.Property(e => e.MoneyManager)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.NetAmount).HasColumnType("decimal(24, 2)");
            entity.Property(e => e.PositionType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.PriceAmount).HasColumnType("decimal(22, 10)");
            entity.Property(e => e.PriceIndicator)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Principal).HasColumnType("decimal(24, 2)");
            entity.Property(e => e.SecId)
                .HasMaxLength(30)
                .HasColumnName("SecID");
            entity.Property(e => e.SecType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.SecurityDescription).HasMaxLength(200);
            entity.Property(e => e.SettlementCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SettlementDate).HasMaxLength(4000);
            entity.Property(e => e.Tax2)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TaxDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TaxFees)
                .HasColumnType("decimal(12, 6)")
                .HasColumnName("Tax/Fees");
            entity.Property(e => e.TaxLotId)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TaxPrice)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TradeDate).HasMaxLength(4000);
            entity.Property(e => e.TransLevel)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.TransactionStatus).HasMaxLength(5);
            entity.Property(e => e.TrasationType)
                .HasMaxLength(5)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwTradesFileMssw002>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwTradesFileMSSW002", "trans");

            entity.Property(e => e.AccountId)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("Account Id");
            entity.Property(e => e.AcquisitionDate)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Acquisition Date");
            entity.Property(e => e.AssociatedTradeId)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("Associated Trade Id");
            entity.Property(e => e.BasketId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Basket Id");
            entity.Property(e => e.BookId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Book Id");
            entity.Property(e => e.BrokerCounterparty)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Broker / Counterparty");
            entity.Property(e => e.BuySellIndicator)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Buy Sell Indicator");
            entity.Property(e => e.ClientStrategy2UsedForPeps)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Client Strategy 2 (Used for PEPS)");
            entity.Property(e => e.ClientTradeRefNo).HasColumnName("Client Trade Ref No.");
            entity.Property(e => e.Comments).HasMaxLength(300);
            entity.Property(e => e.Custodian)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.DealId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Deal Id");
            entity.Property(e => e.DividendEntitlementPercent)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Dividend Entitlement Percent");
            entity.Property(e => e.ExchangeCode)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Exchange Code");
            entity.Property(e => e.ExecutingBrokerCommissionIndicator)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Executing broker Commission Indicator");
            entity.Property(e => e.ExecutionAccount)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("Execution Account");
            entity.Property(e => e.ExecutionBrokerCommission)
                .HasColumnType("decimal(24, 2)")
                .HasColumnName("Execution Broker Commission");
            entity.Property(e => e.HearsayInd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Hearsay Ind");
            entity.Property(e => e.Lei)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("LEI");
            entity.Property(e => e.LongShortIndicator)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Long Short Indicator");
            entity.Property(e => e.MoneyManager)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Money Manager");
            entity.Property(e => e.MsFees)
                .HasColumnType("decimal(12, 6)")
                .HasColumnName("MS Fees");
            entity.Property(e => e.MsFeesIndicator)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("MS fees Indicator.");
            entity.Property(e => e.NetAmount)
                .HasColumnType("decimal(24, 2)")
                .HasColumnName("Net Amount");
            entity.Property(e => e.NotRequired)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Not Required");
            entity.Property(e => e.OriginalTaxlotTransactionDate)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Original taxlot transaction date");
            entity.Property(e => e.OriginalTaxlotTransactionPrice)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Original Taxlot transaction price");
            entity.Property(e => e.PositionType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Position Type");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 6)");
            entity.Property(e => e.PriceCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Price Currency");
            entity.Property(e => e.PriceFxRate)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Price FX Rate");
            entity.Property(e => e.PriceIndicator)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Price Indicator");
            entity.Property(e => e.Principal).HasColumnType("decimal(24, 2)");
            entity.Property(e => e.ResearchFee)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Research Fee");
            entity.Property(e => e.ResearchFeeIndicator)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Research Fee Indicator");
            entity.Property(e => e.ResetIndicator)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Reset Indicator");
            entity.Property(e => e.SecurityDescription)
                .HasMaxLength(200)
                .HasColumnName("Security Description");
            entity.Property(e => e.SecurityIdentifier).HasMaxLength(30);
            entity.Property(e => e.SecurityIdentifierType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Security Identifier Type");
            entity.Property(e => e.SettlementCcy)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Settlement CCY");
            entity.Property(e => e.SettlementDate)
                .HasMaxLength(4000)
                .HasColumnName("Settlement Date");
            entity.Property(e => e.SnsReference)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("SNS reference");
            entity.Property(e => e.Spread)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.SwapReferenceNo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Swap Reference No.");
            entity.Property(e => e.TaxLotId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("TaxLot Id");
            entity.Property(e => e.TaxlotCloseoutMethod)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Taxlot Closeout Method");
            entity.Property(e => e.TradeDate)
                .HasMaxLength(4000)
                .HasColumnName("Trade Date");
            entity.Property(e => e.TransactionLevel)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Transaction Level");
            entity.Property(e => e.TransactionStatus)
                .HasMaxLength(5)
                .HasColumnName("Transaction Status");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("Transaction Type");
        });

        modelBuilder.Entity<VwTransmissionProfile>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwTransmissionProfile", "trans");

            entity.Property(e => e.CounterPartyName).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.ExcryptedFileExtension).HasMaxLength(3);
            entity.Property(e => e.FileContentType).HasMaxLength(5);
            entity.Property(e => e.FtpHost).HasMaxLength(255);
            entity.Property(e => e.FtpRemoteFolder).HasMaxLength(100);
            entity.Property(e => e.FtpUser).HasMaxLength(50);
            entity.Property(e => e.Mnemonic).HasMaxLength(10);
            entity.Property(e => e.TransmissionScheduleType).HasMaxLength(10);
        });

        modelBuilder.Entity<VwTransmittedFile>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwTransmittedFile", "trans");

            entity.Property(e => e.ContentType).HasMaxLength(5);
            entity.Property(e => e.Counterparty).HasMaxLength(50);
            entity.Property(e => e.FileName).HasMaxLength(200);
            entity.Property(e => e.FilePath).HasMaxLength(200);
            entity.Property(e => e.TransmissionType).HasMaxLength(20);
            entity.Property(e => e.TransmittedOn).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
