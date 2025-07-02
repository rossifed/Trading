using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Entities;

public partial class OrdersDbContext : DbContext
{
    public OrdersDbContext()
    {
    }

    public OrdersDbContext(DbContextOptions<OrdersDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Broker> Brokers { get; set; }

    public virtual DbSet<BrokerSelectionRule> BrokerSelectionRules { get; set; }

    public virtual DbSet<BrokerSelectionRuleOverride> BrokerSelectionRuleOverrides { get; set; }

    public virtual DbSet<Exchange> Exchanges { get; set; }

    public virtual DbSet<ExecutionAlgorithm> ExecutionAlgorithms { get; set; }

    public virtual DbSet<ExecutionAlgorithmParamSet> ExecutionAlgorithmParamSets { get; set; }

    public virtual DbSet<ExecutionChannel> ExecutionChannels { get; set; }

    public virtual DbSet<ExecutionProfile> ExecutionProfiles { get; set; }

    public virtual DbSet<ExecutionProfileSelectionRule> ExecutionProfileSelectionRules { get; set; }

    public virtual DbSet<ExecutionProfileSelectionRuleOverride> ExecutionProfileSelectionRuleOverrides { get; set; }

    public virtual DbSet<HandlingInstruction> HandlingInstructions { get; set; }

    public virtual DbSet<Instrument> Instruments { get; set; }

    public virtual DbSet<InstrumentType> InstrumentTypes { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderAllocation> OrderAllocations { get; set; }

    public virtual DbSet<OrderSide> OrderSides { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<OrderType> OrderTypes { get; set; }

    public virtual DbSet<Portfolio> Portfolios { get; set; }

    public virtual DbSet<PositionSide> PositionSides { get; set; }

    public virtual DbSet<RoutingChannel> RoutingChannels { get; set; }

    public virtual DbSet<TimeInForce> TimeInForces { get; set; }

    public virtual DbSet<TradeMode> TradeModes { get; set; }

    public virtual DbSet<TradeModeSelectionRule> TradeModeSelectionRules { get; set; }

    public virtual DbSet<TradingAccount> TradingAccounts { get; set; }

    public virtual DbSet<TradingAccountSelectionRule> TradingAccountSelectionRules { get; set; }

    public virtual DbSet<TradingDesk> TradingDesks { get; set; }

    public virtual DbSet<VwAllocationOrder> VwAllocationOrders { get; set; }

    public virtual DbSet<VwCompareWithPositionDrift> VwCompareWithPositionDrifts { get; set; }

    public virtual DbSet<VwExecutionProfile> VwExecutionProfiles { get; set; }

    public virtual DbSet<VwFxForwardOrdersToFxgo> VwFxForwardOrdersToFxgos { get; set; }

    public virtual DbSet<VwOrder> VwOrders { get; set; }

    public virtual DbSet<VwOrderAllocation> VwOrderAllocations { get; set; }

    public virtual DbSet<VwOrderHistory> VwOrderHistories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=TradingDatabase");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CS_AS");

        modelBuilder.Entity<Broker>(entity =>
        {
            entity
                .ToTable("Broker", "ord")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("Broker_H", "ord");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<BrokerSelectionRule>(entity =>
        {
            entity
                .ToTable("BrokerSelectionRule", "ord")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("BrokerSelectionRule_H", "ord");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasOne(d => d.Broker).WithMany(p => p.BrokerSelectionRules)
                .HasForeignKey(d => d.BrokerId)
                .HasConstraintName("FK_BrokerSelectionRule_Broker");

            entity.HasOne(d => d.InstrumentType).WithMany(p => p.BrokerSelectionRules)
                .HasForeignKey(d => d.InstrumentTypeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_BrokerSelectionRule_InstrumentType");

            entity.HasOne(d => d.Portfolio).WithMany(p => p.BrokerSelectionRules)
                .HasForeignKey(d => d.PortfolioId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_BrokerSelectionRule_Portfolio");
        });

        modelBuilder.Entity<BrokerSelectionRuleOverride>(entity =>
        {
            entity
                .ToTable("BrokerSelectionRuleOverride", "ord")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("BrokerSelectionRuleOverride_H", "ord");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasOne(d => d.Broker).WithMany(p => p.BrokerSelectionRuleOverrides)
                .HasForeignKey(d => d.BrokerId)
                .HasConstraintName("FK_BrokerSelectionRuleOverride_Broker");

            entity.HasOne(d => d.Instrument).WithMany(p => p.BrokerSelectionRuleOverrides)
                .HasForeignKey(d => d.InstrumentId)
                .HasConstraintName("FK_BrokerSelectionRuleOverride_Instrument");

            entity.HasOne(d => d.Portfolio).WithMany(p => p.BrokerSelectionRuleOverrides)
                .HasForeignKey(d => d.PortfolioId)
                .HasConstraintName("FK_BrokerSelectionRuleOverride_Portfolio");
        });

        modelBuilder.Entity<Exchange>(entity =>
        {
            entity.HasKey(e => e.ExchangeId).HasName("PK_ExchangeId");

            entity.ToTable("Exchange", "ord");

            entity.Property(e => e.ExchangeId).ValueGeneratedNever();
            entity.Property(e => e.Code).HasMaxLength(5);
        });

        modelBuilder.Entity<ExecutionAlgorithm>(entity =>
        {
            entity
                .ToTable("ExecutionAlgorithm", "ord")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("ExecutionAlgorithm_H", "ord");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.Mnmemonic).HasMaxLength(10);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<ExecutionAlgorithmParamSet>(entity =>
        {
            entity
                .ToTable("ExecutionAlgorithmParamSet", "ord")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("ExecutionAlgorithmParamSet_H", "ord");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.Param1).HasMaxLength(30);
            entity.Property(e => e.Param2).HasMaxLength(30);
            entity.Property(e => e.Param3).HasMaxLength(30);
            entity.Property(e => e.Param4).HasMaxLength(30);
            entity.Property(e => e.Param5).HasMaxLength(30);
            entity.Property(e => e.Param6).HasMaxLength(30);
            entity.Property(e => e.Param7).HasMaxLength(30);
            entity.Property(e => e.Param8).HasMaxLength(30);
            entity.Property(e => e.Value1).HasMaxLength(30);
            entity.Property(e => e.Value2).HasMaxLength(30);
            entity.Property(e => e.Value3).HasMaxLength(30);
            entity.Property(e => e.Value4).HasMaxLength(30);
            entity.Property(e => e.Value5).HasMaxLength(30);
            entity.Property(e => e.Value6).HasMaxLength(30);
            entity.Property(e => e.Value7).HasMaxLength(30);
            entity.Property(e => e.Value8).HasMaxLength(30);

            entity.HasOne(d => d.ExecutionAlgorithm).WithMany(p => p.ExecutionAlgorithmParamSets)
                .HasForeignKey(d => d.ExecutionAlgorithmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExecutionAlgorithmParamSet_ExecutionAlgorithm");
        });

        modelBuilder.Entity<ExecutionChannel>(entity =>
        {
            entity
                .ToTable("ExecutionChannel", "ord")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("ExecutionChannel_H", "ord");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.ExecutionChannelId).ValueGeneratedOnAdd();
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Mnemonic).HasMaxLength(10);
        });

        modelBuilder.Entity<ExecutionProfile>(entity =>
        {
            entity.HasKey(e => e.ExecutionProfileId).HasName("PK_ ExecutionProfile");

            entity
                .ToTable("ExecutionProfile", "ord")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("ExecutionProfile_H", "ord");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasOne(d => d.ExecutionAlgorithm).WithMany(p => p.ExecutionProfiles)
                .HasForeignKey(d => d.ExecutionAlgorithmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExecutionProfile_ExecutionAlgorithm");

            entity.HasOne(d => d.ExecutionAlgorithmParamSet).WithMany(p => p.ExecutionProfiles)
                .HasForeignKey(d => d.ExecutionAlgorithmParamSetId)
                .HasConstraintName("FK_ExecutionProfile_ExecutionAlgorithmParamSet");

            entity.HasOne(d => d.ExecutionChannel).WithMany(p => p.ExecutionProfiles)
                .HasForeignKey(d => d.ExecutionChannelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExecutionProfile_ExecutionChannel");

            entity.HasOne(d => d.HandlingInstruction).WithMany(p => p.ExecutionProfiles)
                .HasForeignKey(d => d.HandlingInstructionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExecutionProfile_HandlingInstruction");

            entity.HasOne(d => d.OrderType).WithMany(p => p.ExecutionProfiles)
                .HasForeignKey(d => d.OrderTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExecutionProfile_OrderType");

            entity.HasOne(d => d.TimeInForce).WithMany(p => p.ExecutionProfiles)
                .HasForeignKey(d => d.TimeInForceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExecutionProfile_TimeInForce");

            entity.HasOne(d => d.TradingDesk).WithMany(p => p.ExecutionProfiles)
                .HasForeignKey(d => d.TradingDeskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExecutionProfile_TradingDesk");
        });

        modelBuilder.Entity<ExecutionProfileSelectionRule>(entity =>
        {
            entity
                .ToTable("ExecutionProfileSelectionRule", "ord")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("ExecutionProfileSelectionRule_H", "ord");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasOne(d => d.Broker).WithMany(p => p.ExecutionProfileSelectionRules)
                .HasForeignKey(d => d.BrokerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ExecutionProfileSelectionRule_Broker");

            entity.HasOne(d => d.Exchange).WithMany(p => p.ExecutionProfileSelectionRules)
                .HasForeignKey(d => d.ExchangeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ExecutionProfileSelectionRule_Exchange");

            entity.HasOne(d => d.ExecutionProfile).WithMany(p => p.ExecutionProfileSelectionRules)
                .HasForeignKey(d => d.ExecutionProfileId)
                .HasConstraintName("FK_ExecutionProfileSelectionRule_ExecutionProfile");

            entity.HasOne(d => d.InstrumentType).WithMany(p => p.ExecutionProfileSelectionRules)
                .HasForeignKey(d => d.InstrumentTypeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ExecutionProfileSelectionRule_InstrumentType");

            entity.HasOne(d => d.Portfolio).WithMany(p => p.ExecutionProfileSelectionRules)
                .HasForeignKey(d => d.PortfolioId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ExecutionProfileSelectionRule_Portfolio");

            entity.HasOne(d => d.TradeMode).WithMany(p => p.ExecutionProfileSelectionRules)
                .HasForeignKey(d => d.TradeModeId)
                .HasConstraintName("FK_ExecutionProfileSelectionRule_TradeMode");
        });

        modelBuilder.Entity<ExecutionProfileSelectionRuleOverride>(entity =>
        {
            entity
                .ToTable("ExecutionProfileSelectionRuleOverride", "ord")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("ExecutionProfileSelectionRuleOverride_H", "ord");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasOne(d => d.Broker).WithMany(p => p.ExecutionProfileSelectionRuleOverrides)
                .HasForeignKey(d => d.BrokerId)
                .HasConstraintName("FK_ExecutionProfileSelectionRuleOverride_Broker");

            entity.HasOne(d => d.ExecutionProfile).WithMany(p => p.ExecutionProfileSelectionRuleOverrides)
                .HasForeignKey(d => d.ExecutionProfileId)
                .HasConstraintName("FK_ExecutionProfileSelectionRuleOverride_ExecutionProfile");

            entity.HasOne(d => d.Instrument).WithMany(p => p.ExecutionProfileSelectionRuleOverrides)
                .HasForeignKey(d => d.InstrumentId)
                .HasConstraintName("FK_ExecutionProfileSelectionRuleOverride_Instrument");

            entity.HasOne(d => d.Portfolio).WithMany(p => p.ExecutionProfileSelectionRuleOverrides)
                .HasForeignKey(d => d.PortfolioId)
                .HasConstraintName("FK_ExecutionProfileSelectionRuleOverride_Portfolio");

            entity.HasOne(d => d.TradeMode).WithMany(p => p.ExecutionProfileSelectionRuleOverrides)
                .HasForeignKey(d => d.TradeModeId)
                .HasConstraintName("FK_ExecutionProfileSelectionRuleOverride_TradeMode");
        });

        modelBuilder.Entity<HandlingInstruction>(entity =>
        {
            entity
                .ToTable("HandlingInstruction", "ord")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("HandlingInstruction_H", "ord");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.Description).HasMaxLength(200);
        });

        modelBuilder.Entity<Instrument>(entity =>
        {
            entity.HasKey(e => e.InstrumentId).HasName("PK_InstrumentId");

            entity.ToTable("Instrument", "ord");

            entity.Property(e => e.InstrumentId).ValueGeneratedNever();
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Exchange).HasMaxLength(5);
            entity.Property(e => e.MarketSector).HasMaxLength(6);
            entity.Property(e => e.Maturity).HasColumnType("date");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Symbol).HasMaxLength(30);

            entity.HasOne(d => d.ExchangeNavigation).WithMany(p => p.Instruments)
                .HasForeignKey(d => d.ExchangeId)
                .HasConstraintName("FK_Instrument_Exchange");

            entity.HasOne(d => d.InstrumentType).WithMany(p => p.Instruments)
                .HasForeignKey(d => d.InstrumentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Instrument_InstrumentType");
        });

        modelBuilder.Entity<InstrumentType>(entity =>
        {
            entity.HasKey(e => e.InstrumentTypeId).HasName("PK_InstrumentTypeId");

            entity.ToTable("InstrumentType", "ord");

            entity.HasIndex(e => e.Mnemonic, "UC_InstrumentType_Mnemonic").IsUnique();

            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Mnemonic).HasMaxLength(10);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity
                .ToTable("Order", "ord")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("H_Order", "ord");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.OrderReason).HasMaxLength(10);
            entity.Property(e => e.OrderRef).HasMaxLength(30);
            entity.Property(e => e.Param1).HasMaxLength(30);
            entity.Property(e => e.Param2).HasMaxLength(30);
            entity.Property(e => e.Param3).HasMaxLength(30);
            entity.Property(e => e.Param4).HasMaxLength(30);
            entity.Property(e => e.Param5).HasMaxLength(30);
            entity.Property(e => e.Param6).HasMaxLength(30);
            entity.Property(e => e.Param7).HasMaxLength(30);
            entity.Property(e => e.Param8).HasMaxLength(30);
            entity.Property(e => e.TradeDate).HasColumnType("date");
            entity.Property(e => e.Value1).HasMaxLength(30);
            entity.Property(e => e.Value2).HasMaxLength(30);
            entity.Property(e => e.Value3).HasMaxLength(30);
            entity.Property(e => e.Value4).HasMaxLength(30);
            entity.Property(e => e.Value5).HasMaxLength(30);
            entity.Property(e => e.Value6).HasMaxLength(30);
            entity.Property(e => e.Value7).HasMaxLength(30);
            entity.Property(e => e.Value8).HasMaxLength(30);

            entity.HasOne(d => d.Broker).WithMany(p => p.Orders)
                .HasForeignKey(d => d.BrokerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Broker");

            entity.HasOne(d => d.ExecutionAlgorithm).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ExecutionAlgorithmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_ExecutionAlgorithm");

            entity.HasOne(d => d.ExecutionChannel).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ExecutionChannelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_ExecutionChannel");

            entity.HasOne(d => d.HandlingInstruction).WithMany(p => p.Orders)
                .HasForeignKey(d => d.HandlingInstructionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_HandlingInstruction");

            entity.HasOne(d => d.Instrument).WithMany(p => p.Orders)
                .HasForeignKey(d => d.InstrumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Instrument");

            entity.HasOne(d => d.OrderSide).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderSideId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_OrderSide");

            entity.HasOne(d => d.OrderType).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_OrderType");

            entity.HasOne(d => d.TimeInForce).WithMany(p => p.Orders)
                .HasForeignKey(d => d.TimeInForceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_TimeInForce");

            entity.HasOne(d => d.TradeMode).WithMany(p => p.Orders)
                .HasForeignKey(d => d.TradeModeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_TradeMode");

            entity.HasOne(d => d.TradingDesk).WithMany(p => p.Orders)
                .HasForeignKey(d => d.TradingDeskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_TradingDesk");
        });

        modelBuilder.Entity<OrderAllocation>(entity =>
        {
            entity
                .ToTable("OrderAllocation", "ord")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("H_OrderAllocation", "ord");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasIndex(e => new { e.OrderId, e.PortfolioId }, "UC_OrderAllocation").IsUnique();

            entity.HasOne(d => d.Order).WithMany(p => p.OrderAllocations)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_OrderAllocation_Order");

            entity.HasOne(d => d.Portfolio).WithMany(p => p.OrderAllocations)
                .HasForeignKey(d => d.PortfolioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderAllocation_Portfolio");

            entity.HasOne(d => d.PositionSide).WithMany(p => p.OrderAllocations)
                .HasForeignKey(d => d.PositionSideId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderAllocation_PositionSide");

            entity.HasOne(d => d.TradingAccount).WithMany(p => p.OrderAllocations)
                .HasForeignKey(d => d.TradingAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderAllocation_TradingAccount");
        });

        modelBuilder.Entity<OrderSide>(entity =>
        {
            entity
                .ToTable("OrderSide", "ord")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("OrderSide_H", "ord");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.OrderSideId).ValueGeneratedOnAdd();
            entity.Property(e => e.Mnemonic).HasMaxLength(2);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity
                .ToTable("OrderStatus", "ord")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("OrderStatus_H", "ord");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Mnemonic).HasMaxLength(10);
        });

        modelBuilder.Entity<OrderType>(entity =>
        {
            entity
                .ToTable("OrderType", "ord")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("OrderType_H", "ord");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Mnemonic).HasMaxLength(10);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Portfolio>(entity =>
        {
            entity.HasKey(e => e.PortfolioId).HasName("PK_PortfolioId");

            entity.ToTable("Portfolio", "ord");

            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Mnemonic).HasMaxLength(6);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<PositionSide>(entity =>
        {
            entity
                .ToTable("PositionSide", "ord")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("PositionSide_H", "ord");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.PositionSideId).ValueGeneratedOnAdd();
            entity.Property(e => e.Mnemonic).HasMaxLength(2);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<RoutingChannel>(entity =>
        {
            entity
                .ToTable("RoutingChannel", "ord")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("RoutingChannel_H", "ord");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.RoutingChannelId).ValueGeneratedOnAdd();
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Mnemonic).HasMaxLength(10);
        });

        modelBuilder.Entity<TimeInForce>(entity =>
        {
            entity
                .ToTable("TimeInForce", "ord")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("TimeInForce_H", "ord");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.TimeInForceId).ValueGeneratedOnAdd();
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Mnemonic).HasMaxLength(10);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<TradeMode>(entity =>
        {
            entity.ToTable("TradeMode", "ord");

            entity.Property(e => e.TradeModeId).ValueGeneratedOnAdd();
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Mnemonic).HasMaxLength(10);
        });

        modelBuilder.Entity<TradeModeSelectionRule>(entity =>
        {
            entity
                .ToTable("TradeModeSelectionRule", "ord")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("TradeModeSelectionRule_H", "ord");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasOne(d => d.Broker).WithMany(p => p.TradeModeSelectionRules)
                .HasForeignKey(d => d.BrokerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TradeModeSelectionRule_Broker");

            entity.HasOne(d => d.InstrumentType).WithMany(p => p.TradeModeSelectionRules)
                .HasForeignKey(d => d.InstrumentTypeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TradeModeSelectionRule_InstrumentType");

            entity.HasOne(d => d.Portfolio).WithMany(p => p.TradeModeSelectionRules)
                .HasForeignKey(d => d.PortfolioId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TradeModeSelectionRule_Portfolio");

            entity.HasOne(d => d.TradeMode).WithMany(p => p.TradeModeSelectionRules)
                .HasForeignKey(d => d.TradeModeId)
                .HasConstraintName("FK_TradeModeSelectionRule_TradeMode");
        });

        modelBuilder.Entity<TradingAccount>(entity =>
        {
            entity
                .ToTable("TradingAccount", "ord")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("TradingAccount_H", "ord");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.Code).HasMaxLength(50);
        });

        modelBuilder.Entity<TradingAccountSelectionRule>(entity =>
        {
            entity
                .ToTable("TradingAccountSelectionRule", "ord")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("TradingAccountSelectionRule_H", "ord");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.HasOne(d => d.Broker).WithMany(p => p.TradingAccountSelectionRules)
                .HasForeignKey(d => d.BrokerId)
                .HasConstraintName("FK_TradingAccountSelectionRule_Broker");

            entity.HasOne(d => d.InstrumentType).WithMany(p => p.TradingAccountSelectionRules)
                .HasForeignKey(d => d.InstrumentTypeId)
                .HasConstraintName("FK_TradingAccountSelectionRule_InstrumentType");

            entity.HasOne(d => d.Portfolio).WithMany(p => p.TradingAccountSelectionRules)
                .HasForeignKey(d => d.PortfolioId)
                .HasConstraintName("FK_TradingAccountSelectionRule_Portfolio");

            entity.HasOne(d => d.TradeMode).WithMany(p => p.TradingAccountSelectionRules)
                .HasForeignKey(d => d.TradeModeId)
                .HasConstraintName("FK_TradingAccountSelectionRule_TradeMode");

            entity.HasOne(d => d.TradingAccount).WithMany(p => p.TradingAccountSelectionRules)
                .HasForeignKey(d => d.TradingAccountId)
                .HasConstraintName("FK_TradingAccountSelectionRule_TradingAccount");
        });

        modelBuilder.Entity<TradingDesk>(entity =>
        {
            entity
                .ToTable("TradingDesk", "ord")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("TradingDesk_H", "ord");
                        ttb
                            .HasPeriodStart("ValidFrom")
                            .HasColumnName("ValidFrom");
                        ttb
                            .HasPeriodEnd("ValidTo")
                            .HasColumnName("ValidTo");
                    }));

            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.Description).HasMaxLength(200);

            entity.HasOne(d => d.Broker).WithMany(p => p.TradingDesks)
                .HasForeignKey(d => d.BrokerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TradingDesk_Broker");
        });

        modelBuilder.Entity<VwAllocationOrder>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwAllocationOrder", "ord");

            entity.Property(e => e.BrokerCode).HasMaxLength(10);
            entity.Property(e => e.BrokerName).HasMaxLength(30);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Exchange).HasMaxLength(5);
            entity.Property(e => e.ExecutionAlgo).HasMaxLength(10);
            entity.Property(e => e.ExecutionChannel).HasMaxLength(10);
            entity.Property(e => e.HandlingInstruction).HasMaxLength(10);
            entity.Property(e => e.InstrumentType).HasMaxLength(10);
            entity.Property(e => e.MarketSector).HasMaxLength(6);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.OrderSide).HasMaxLength(2);
            entity.Property(e => e.OrderType).HasMaxLength(10);
            entity.Property(e => e.Param1).HasMaxLength(30);
            entity.Property(e => e.Param2).HasMaxLength(30);
            entity.Property(e => e.Param3).HasMaxLength(30);
            entity.Property(e => e.Param4).HasMaxLength(30);
            entity.Property(e => e.Param5).HasMaxLength(30);
            entity.Property(e => e.Param6).HasMaxLength(30);
            entity.Property(e => e.Param7).HasMaxLength(30);
            entity.Property(e => e.Param8).HasMaxLength(30);
            entity.Property(e => e.PositionSide).HasMaxLength(2);
            entity.Property(e => e.Symbol).HasMaxLength(30);
            entity.Property(e => e.TimeInForce).HasMaxLength(10);
            entity.Property(e => e.TradeDate).HasColumnType("date");
            entity.Property(e => e.TradeMode).HasMaxLength(10);
            entity.Property(e => e.TradingAccount).HasMaxLength(50);
            entity.Property(e => e.TradingDesk).HasMaxLength(10);
            entity.Property(e => e.Value1).HasMaxLength(30);
            entity.Property(e => e.Value2).HasMaxLength(30);
            entity.Property(e => e.Value3).HasMaxLength(30);
            entity.Property(e => e.Value4).HasMaxLength(30);
            entity.Property(e => e.Value5).HasMaxLength(30);
            entity.Property(e => e.Value6).HasMaxLength(30);
            entity.Property(e => e.Value7).HasMaxLength(30);
            entity.Property(e => e.Value8).HasMaxLength(30);
        });

        modelBuilder.Entity<VwCompareWithPositionDrift>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwCompareWithPositionDrift", "ord");

            entity.Property(e => e.Symbol).HasMaxLength(30);
        });

        modelBuilder.Entity<VwExecutionProfile>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwExecutionProfile", "ord");

            entity.Property(e => e.ExecutionAlgorithm).HasMaxLength(10);
            entity.Property(e => e.ExecutionChannel).HasMaxLength(10);
            entity.Property(e => e.HandlingInstruction).HasMaxLength(10);
            entity.Property(e => e.OrderType).HasMaxLength(10);
            entity.Property(e => e.Param1).HasMaxLength(30);
            entity.Property(e => e.Param2).HasMaxLength(30);
            entity.Property(e => e.Param3).HasMaxLength(30);
            entity.Property(e => e.Param4).HasMaxLength(30);
            entity.Property(e => e.Param5).HasMaxLength(30);
            entity.Property(e => e.Param6).HasMaxLength(30);
            entity.Property(e => e.Param7).HasMaxLength(30);
            entity.Property(e => e.Param8).HasMaxLength(30);
            entity.Property(e => e.TimeInForce).HasMaxLength(10);
            entity.Property(e => e.TradingDesk).HasMaxLength(10);
            entity.Property(e => e.Value1).HasMaxLength(30);
            entity.Property(e => e.Value2).HasMaxLength(30);
            entity.Property(e => e.Value3).HasMaxLength(30);
            entity.Property(e => e.Value4).HasMaxLength(30);
            entity.Property(e => e.Value5).HasMaxLength(30);
            entity.Property(e => e.Value6).HasMaxLength(30);
            entity.Property(e => e.Value7).HasMaxLength(30);
            entity.Property(e => e.Value8).HasMaxLength(30);
        });

        modelBuilder.Entity<VwFxForwardOrdersToFxgo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwFxForwardOrdersToFxgo", "ord");

            entity.Property(e => e.Account)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.Currency).HasMaxLength(3);
            entity.Property(e => e.CurrencyPair).HasMaxLength(6);
            entity.Property(e => e.Instrument)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.Side).HasMaxLength(2);
            entity.Property(e => e.Tenor)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ValueDate)
                .HasMaxLength(8000)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwOrder>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwOrder", "ord");

            entity.Property(e => e.BrokerCode).HasMaxLength(10);
            entity.Property(e => e.BrokerName).HasMaxLength(30);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Exchange).HasMaxLength(5);
            entity.Property(e => e.ExecutionAlgo).HasMaxLength(10);
            entity.Property(e => e.ExecutionChannel).HasMaxLength(10);
            entity.Property(e => e.HandlingInstruction).HasMaxLength(10);
            entity.Property(e => e.InstrumentType).HasMaxLength(10);
            entity.Property(e => e.MarketSector).HasMaxLength(6);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.OrderSide).HasMaxLength(2);
            entity.Property(e => e.OrderType).HasMaxLength(10);
            entity.Property(e => e.Param1).HasMaxLength(30);
            entity.Property(e => e.Param2).HasMaxLength(30);
            entity.Property(e => e.Param3).HasMaxLength(30);
            entity.Property(e => e.Param4).HasMaxLength(30);
            entity.Property(e => e.Param5).HasMaxLength(30);
            entity.Property(e => e.Param6).HasMaxLength(30);
            entity.Property(e => e.Param7).HasMaxLength(30);
            entity.Property(e => e.Param8).HasMaxLength(30);
            entity.Property(e => e.Symbol).HasMaxLength(30);
            entity.Property(e => e.TimeInForce).HasMaxLength(10);
            entity.Property(e => e.TradeDate).HasColumnType("date");
            entity.Property(e => e.TradeMode).HasMaxLength(10);
            entity.Property(e => e.TradingDesk).HasMaxLength(10);
            entity.Property(e => e.Value1).HasMaxLength(30);
            entity.Property(e => e.Value2).HasMaxLength(30);
            entity.Property(e => e.Value3).HasMaxLength(30);
            entity.Property(e => e.Value4).HasMaxLength(30);
            entity.Property(e => e.Value5).HasMaxLength(30);
            entity.Property(e => e.Value6).HasMaxLength(30);
            entity.Property(e => e.Value7).HasMaxLength(30);
            entity.Property(e => e.Value8).HasMaxLength(30);
        });

        modelBuilder.Entity<VwOrderAllocation>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwOrderAllocation", "ord");

            entity.Property(e => e.BrokerCode).HasMaxLength(10);
            entity.Property(e => e.BrokerName).HasMaxLength(30);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Exchange).HasMaxLength(5);
            entity.Property(e => e.ExecutionAlgo).HasMaxLength(10);
            entity.Property(e => e.ExecutionChannel).HasMaxLength(10);
            entity.Property(e => e.HandlingInstruction).HasMaxLength(10);
            entity.Property(e => e.InstrumentName).HasMaxLength(100);
            entity.Property(e => e.InstrumentType).HasMaxLength(10);
            entity.Property(e => e.MarketSector).HasMaxLength(6);
            entity.Property(e => e.OrderSide).HasMaxLength(2);
            entity.Property(e => e.OrderType).HasMaxLength(10);
            entity.Property(e => e.PortfolioCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PositionSide).HasMaxLength(2);
            entity.Property(e => e.PotfolioMnemonic).HasMaxLength(6);
            entity.Property(e => e.PotfolioName).HasMaxLength(50);
            entity.Property(e => e.Symbol).HasMaxLength(30);
            entity.Property(e => e.TimeInForce).HasMaxLength(10);
            entity.Property(e => e.TradeDate).HasColumnType("date");
            entity.Property(e => e.TradeMode).HasMaxLength(10);
            entity.Property(e => e.TradingAccountCode).HasMaxLength(50);
            entity.Property(e => e.TradingDesk).HasMaxLength(10);
        });

        modelBuilder.Entity<VwOrderHistory>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwOrderHistory", "ord");

            entity.Property(e => e.BrokerCode).HasMaxLength(10);
            entity.Property(e => e.BrokerName).HasMaxLength(30);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Exchange).HasMaxLength(5);
            entity.Property(e => e.ExecutionAlgo).HasMaxLength(10);
            entity.Property(e => e.ExecutionChannel).HasMaxLength(10);
            entity.Property(e => e.HandlingInstruction).HasMaxLength(10);
            entity.Property(e => e.InstrumentType).HasMaxLength(10);
            entity.Property(e => e.MarketSector).HasMaxLength(6);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.OrderSide).HasMaxLength(2);
            entity.Property(e => e.OrderType).HasMaxLength(10);
            entity.Property(e => e.Param1).HasMaxLength(30);
            entity.Property(e => e.Param2).HasMaxLength(30);
            entity.Property(e => e.Param3).HasMaxLength(30);
            entity.Property(e => e.Param4).HasMaxLength(30);
            entity.Property(e => e.Param5).HasMaxLength(30);
            entity.Property(e => e.Param6).HasMaxLength(30);
            entity.Property(e => e.Param7).HasMaxLength(30);
            entity.Property(e => e.Param8).HasMaxLength(30);
            entity.Property(e => e.Symbol).HasMaxLength(30);
            entity.Property(e => e.TimeInForce).HasMaxLength(10);
            entity.Property(e => e.TradeDate).HasColumnType("date");
            entity.Property(e => e.TradeMode).HasMaxLength(10);
            entity.Property(e => e.TradingDesk).HasMaxLength(10);
            entity.Property(e => e.Value1).HasMaxLength(30);
            entity.Property(e => e.Value2).HasMaxLength(30);
            entity.Property(e => e.Value3).HasMaxLength(30);
            entity.Property(e => e.Value4).HasMaxLength(30);
            entity.Property(e => e.Value5).HasMaxLength(30);
            entity.Property(e => e.Value6).HasMaxLength(30);
            entity.Property(e => e.Value7).HasMaxLength(30);
            entity.Property(e => e.Value8).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
