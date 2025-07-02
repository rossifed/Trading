/****** Object:  Database [Trading]    Script Date: 6/26/2024 1:49:54 PM ******/
CREATE DATABASE [Trading]  (EDITION = 'GeneralPurpose', SERVICE_OBJECTIVE = 'GP_S_Gen5_2', MAXSIZE = 150 GB) WITH CATALOG_COLLATION = SQL_Latin1_General_CP1_CI_AS, LEDGER = OFF;
GO
ALTER DATABASE [Trading] SET COMPATIBILITY_LEVEL = 150
GO
ALTER DATABASE [Trading] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Trading] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Trading] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Trading] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Trading] SET ARITHABORT OFF 
GO
ALTER DATABASE [Trading] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Trading] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Trading] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Trading] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Trading] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Trading] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Trading] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Trading] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Trading] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO
ALTER DATABASE [Trading] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Trading] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Trading] SET  MULTI_USER 
GO
ALTER DATABASE [Trading] SET ENCRYPTION ON
GO
ALTER DATABASE [Trading] SET QUERY_STORE = ON
GO
ALTER DATABASE [Trading] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 100, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
/*** The scripts of database scoped configurations in Azure should be executed inside the target database connection. ***/

GO
/****** Object:  Schema [blpapi]    Script Date: 6/26/2024 1:49:54 PM ******/
CREATE SCHEMA [blpapi]
GO
/****** Object:  Schema [book]    Script Date: 6/26/2024 1:49:54 PM ******/
CREATE SCHEMA [book]
GO
/****** Object:  Schema [check]    Script Date: 6/26/2024 1:49:54 PM ******/
CREATE SCHEMA [check]
GO
/****** Object:  Schema [constr]    Script Date: 6/26/2024 1:49:54 PM ******/
CREATE SCHEMA [constr]
GO
/****** Object:  Schema [conv]    Script Date: 6/26/2024 1:49:54 PM ******/
CREATE SCHEMA [conv]
GO
/****** Object:  Schema [data]    Script Date: 6/26/2024 1:49:54 PM ******/
CREATE SCHEMA [data]
GO
/****** Object:  Schema [dwh]    Script Date: 6/26/2024 1:49:54 PM ******/
CREATE SCHEMA [dwh]
GO
/****** Object:  Schema [efrp]    Script Date: 6/26/2024 1:49:54 PM ******/
CREATE SCHEMA [efrp]
GO
/****** Object:  Schema [emsx]    Script Date: 6/26/2024 1:49:54 PM ******/
CREATE SCHEMA [emsx]
GO
/****** Object:  Schema [exec]    Script Date: 6/26/2024 1:49:54 PM ******/
CREATE SCHEMA [exec]
GO
/****** Object:  Schema [fxgo]    Script Date: 6/26/2024 1:49:54 PM ******/
CREATE SCHEMA [fxgo]
GO
/****** Object:  Schema [HangFire]    Script Date: 6/26/2024 1:49:54 PM ******/
CREATE SCHEMA [HangFire]
GO
/****** Object:  Schema [instr]    Script Date: 6/26/2024 1:49:54 PM ******/
CREATE SCHEMA [instr]
GO
/****** Object:  Schema [mktdata]    Script Date: 6/26/2024 1:49:54 PM ******/
CREATE SCHEMA [mktdata]
GO
/****** Object:  Schema [ord]    Script Date: 6/26/2024 1:49:54 PM ******/
CREATE SCHEMA [ord]
GO
/****** Object:  Schema [ordgen]    Script Date: 6/26/2024 1:49:54 PM ******/
CREATE SCHEMA [ordgen]
GO
/****** Object:  Schema [port]    Script Date: 6/26/2024 1:49:54 PM ******/
CREATE SCHEMA [port]
GO
/****** Object:  Schema [pos]    Script Date: 6/26/2024 1:49:54 PM ******/
CREATE SCHEMA [pos]
GO
/****** Object:  Schema [prc]    Script Date: 6/26/2024 1:49:54 PM ******/
CREATE SCHEMA [prc]
GO
/****** Object:  Schema [pricing]    Script Date: 6/26/2024 1:49:54 PM ******/
CREATE SCHEMA [pricing]
GO
/****** Object:  Schema [px]    Script Date: 6/26/2024 1:49:54 PM ******/
CREATE SCHEMA [px]
GO
/****** Object:  Schema [rebal]    Script Date: 6/26/2024 1:49:54 PM ******/
CREATE SCHEMA [rebal]
GO
/****** Object:  Schema [ref]    Script Date: 6/26/2024 1:49:54 PM ******/
CREATE SCHEMA [ref]
GO
/****** Object:  Schema [rep]    Script Date: 6/26/2024 1:49:54 PM ******/
CREATE SCHEMA [rep]
GO
/****** Object:  Schema [risk]    Script Date: 6/26/2024 1:49:54 PM ******/
CREATE SCHEMA [risk]
GO
/****** Object:  Schema [roll]    Script Date: 6/26/2024 1:49:54 PM ******/
CREATE SCHEMA [roll]
GO
/****** Object:  Schema [rout]    Script Date: 6/26/2024 1:49:54 PM ******/
CREATE SCHEMA [rout]
GO
/****** Object:  Schema [strats]    Script Date: 6/26/2024 1:49:54 PM ******/
CREATE SCHEMA [strats]
GO
/****** Object:  Schema [trans]    Script Date: 6/26/2024 1:49:54 PM ******/
CREATE SCHEMA [trans]
GO
/****** Object:  Schema [trd]    Script Date: 6/26/2024 1:49:54 PM ******/
CREATE SCHEMA [trd]
GO
/****** Object:  Schema [val]    Script Date: 6/26/2024 1:49:54 PM ******/
CREATE SCHEMA [val]
GO
/****** Object:  Schema [wght]    Script Date: 6/26/2024 1:49:54 PM ******/
CREATE SCHEMA [wght]
GO
/****** Object:  UserDefinedFunction [dbo].[fnNextBusinessDate]    Script Date: 6/26/2024 1:49:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fnNextBusinessDate] (@Date DATE)
RETURNS DATE
AS
BEGIN
    DECLARE @NextDate DATE

    -- Calculate the next day
    SET @NextDate = DATEADD(DAY, 1, @Date)

    -- If Saturday, add two days
    IF DATEPART(WEEKDAY, @NextDate) = 7 
        SET @NextDate = DATEADD(DAY, 2, @NextDate)

    -- If Sunday, add one day
    IF DATEPART(WEEKDAY, @NextDate) = 1 
        SET @NextDate = DATEADD(DAY, 1, @NextDate)

    RETURN @NextDate
END
GO
/****** Object:  UserDefinedFunction [instr].[vfRemoveYellowKey]    Script Date: 6/26/2024 1:49:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE FUNCTION [instr].[vfRemoveYellowKey] (@ticker NVARCHAR(255))
RETURNS NVARCHAR(255)
AS
BEGIN
    -- Starting value is the original ticker
    DECLARE @result NVARCHAR(255) = @ticker;

    -- For each market sector in the MarketSector table, try to find it in the ticker
    -- and then remove it.
    SELECT @result = REPLACE(@result, ' ' + Mnemonic, '')
    FROM instr.MarketSector
    WHERE CHARINDEX(Mnemonic, @ticker) > 0;

    -- Return the modified ticker
    RETURN LTRIM(RTRIM(@result));
END;

GO
/****** Object:  UserDefinedFunction [trd].[fnAddBusinessDays]    Script Date: 6/26/2024 1:49:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [trd].[fnAddBusinessDays] 
(
    @StartDate DATE,
    @NumDays INT
)
RETURNS DATE
AS
BEGIN
    DECLARE @ResultDate DATE = @StartDate
    DECLARE @Direction INT = CASE WHEN @NumDays >= 0 THEN 1 ELSE -1 END

    WHILE @NumDays <> 0
    BEGIN
        -- Move the date in the desired direction
        SET @ResultDate = DATEADD(DAY, @Direction, @ResultDate)

        -- Check if the new date is a weekday
        IF DATEPART(WEEKDAY, @ResultDate) BETWEEN 2 AND 6
            SET @NumDays = @NumDays - @Direction
    END

    RETURN @ResultDate
END
GO
/****** Object:  UserDefinedFunction [trd].[fnNextBusinessDate]    Script Date: 6/26/2024 1:49:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [trd].[fnNextBusinessDate] (@Date DATE)
RETURNS DATE
AS
BEGIN
    DECLARE @NextDate DATE

    -- Calculate the next day
    SET @NextDate = DATEADD(DAY, 1, @Date)

    -- If Saturday, add two days
    IF DATEPART(WEEKDAY, @NextDate) = 7 
        SET @NextDate = DATEADD(DAY, 2, @NextDate)

    -- If Sunday, add one day
    IF DATEPART(WEEKDAY, @NextDate) = 1 
        SET @NextDate = DATEADD(DAY, 1, @NextDate)

    RETURN @NextDate
END
GO
/****** Object:  Table [trans].[H_ExecutionAccountCodeMapping]    Script Date: 6/26/2024 1:49:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[H_ExecutionAccountCodeMapping](
	[CounterpartyId] [int] NOT NULL,
	[InternalCode] [nvarchar](20) NOT NULL,
	[CounterpartyCode] [nvarchar](20) NOT NULL,
	[ValidFrom] [datetime2](7) NOT NULL,
	[ValidTo] [datetime2](7) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_H_ExecutionAccountCodeMapping]    Script Date: 6/26/2024 1:49:54 PM ******/
CREATE CLUSTERED INDEX [ix_H_ExecutionAccountCodeMapping] ON [trans].[H_ExecutionAccountCodeMapping]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [trans].[ExecutionAccountCodeMapping]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[ExecutionAccountCodeMapping](
	[CounterpartyId] [int] NOT NULL,
	[InternalCode] [nvarchar](20) NOT NULL,
	[CounterpartyCode] [nvarchar](20) NOT NULL,
	[ValidFrom] [datetime2](7) GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
	[ValidTo] [datetime2](7) GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
 CONSTRAINT [PK_ExecutionAccountCodeMapping] PRIMARY KEY CLUSTERED 
(
	[CounterpartyId] ASC,
	[InternalCode] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [trans].[H_ExecutionAccountCodeMapping])
)
GO
/****** Object:  Table [risk].[RelationalOperator_H]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [risk].[RelationalOperator_H](
	[RelationalOperatorId] [tinyint] NOT NULL,
	[Mnemonic] [nvarchar](20) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_RelationalOperator_H]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_RelationalOperator_H] ON [risk].[RelationalOperator_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [risk].[RelationalOperator]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [risk].[RelationalOperator](
	[RelationalOperatorId] [tinyint] IDENTITY(1,1) NOT NULL,
	[Mnemonic] [nvarchar](20) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_RelationalOperatorId] PRIMARY KEY CLUSTERED 
(
	[RelationalOperatorId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_RelationalOperatorMnemonic] UNIQUE NONCLUSTERED 
(
	[Mnemonic] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [risk].[RelationalOperator_H])
)
GO
/****** Object:  Table [book].[H_SettlementInfo]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [book].[H_SettlementInfo](
	[CounterpartyId] [int] NOT NULL,
	[InstrumentId] [int] NOT NULL,
	[IsSwap] [bit] NOT NULL,
	[DaysToSettle] [tinyint] NOT NULL,
	[SettleCurrency] [char](3) NOT NULL,
	[ValidFrom] [datetime2](7) NOT NULL,
	[ValidTo] [datetime2](7) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_H_SettlementInfo]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_H_SettlementInfo] ON [book].[H_SettlementInfo]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [book].[SettlementInfo]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [book].[SettlementInfo](
	[CounterpartyId] [int] NOT NULL,
	[InstrumentId] [int] NOT NULL,
	[IsSwap] [bit] NOT NULL,
	[DaysToSettle] [tinyint] NOT NULL,
	[SettleCurrency] [char](3) NOT NULL,
	[ValidFrom] [datetime2](7) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](7) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_SettlementInfo] PRIMARY KEY CLUSTERED 
(
	[CounterpartyId] ASC,
	[InstrumentId] ASC,
	[IsSwap] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [book].[H_SettlementInfo])
)
GO
/****** Object:  Table [ord].[TradingAccountSelectionRule_H]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[TradingAccountSelectionRule_H](
	[TradingAccountSelectionRuleId] [int] NOT NULL,
	[PortfolioId] [tinyint] NOT NULL,
	[BrokerId] [int] NOT NULL,
	[InstrumentTypeId] [tinyint] NOT NULL,
	[TradeModeId] [tinyint] NOT NULL,
	[TradingAccountId] [int] NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_TradingAccountSelectionRule_H]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_TradingAccountSelectionRule_H] ON [ord].[TradingAccountSelectionRule_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [ord].[TradingAccountSelectionRule]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[TradingAccountSelectionRule](
	[TradingAccountSelectionRuleId] [int] IDENTITY(1,1) NOT NULL,
	[PortfolioId] [tinyint] NOT NULL,
	[BrokerId] [int] NOT NULL,
	[InstrumentTypeId] [tinyint] NOT NULL,
	[TradeModeId] [tinyint] NOT NULL,
	[TradingAccountId] [int] NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_TradingAccountSelectionRule] PRIMARY KEY CLUSTERED 
(
	[TradingAccountSelectionRuleId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [ord].[TradingAccountSelectionRule_H])
)
GO
/****** Object:  Table [trd].[H_FutureCommission]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trd].[H_FutureCommission](
	[FutureCommissionId] [int] NOT NULL,
	[BrokerCode] [nvarchar](10) NOT NULL,
	[GenericFutureId] [int] NULL,
	[CommPerLot] [decimal](12, 6) NULL,
	[CommRate] [decimal](8, 6) NULL,
	[ValidFrom] [datetime2](7) NOT NULL,
	[ValidTo] [datetime2](7) NOT NULL,
	[ExecDeskCommPerLot] [decimal](12, 6) NULL,
	[ExecDeskCommRate] [decimal](8, 6) NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_H_FutureCommission]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_H_FutureCommission] ON [trd].[H_FutureCommission]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [trd].[FutureCommission]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trd].[FutureCommission](
	[FutureCommissionId] [int] IDENTITY(1,1) NOT NULL,
	[BrokerCode] [nvarchar](10) NOT NULL,
	[GenericFutureId] [int] NULL,
	[CommPerLot] [decimal](12, 6) NULL,
	[CommRate] [decimal](8, 6) NULL,
	[ValidFrom] [datetime2](7) GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
	[ValidTo] [datetime2](7) GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
	[ExecDeskCommPerLot] [decimal](12, 6) NULL,
	[ExecDeskCommRate] [decimal](8, 6) NULL,
 CONSTRAINT [PK_FutureBrokerCommission] PRIMARY KEY CLUSTERED 
(
	[FutureCommissionId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_FutureCommission] UNIQUE NONCLUSTERED 
(
	[BrokerCode] ASC,
	[GenericFutureId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [trd].[H_FutureCommission])
)
GO
/****** Object:  Table [trd].[Instrument]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trd].[Instrument](
	[InstrumentId] [int] NOT NULL,
	[Symbol] [nvarchar](30) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[ISIN] [nvarchar](12) NULL,
	[BbgUniqueId] [nvarchar](30) NOT NULL,
	[InstrumentType] [nvarchar](10) NOT NULL,
	[MarketSector] [nvarchar](6) NOT NULL,
	[Exchange] [nvarchar](5) NULL,
	[PrimaryMic] [nvarchar](10) NULL,
	[Currency] [char](3) NOT NULL,
	[QuoteCurrency] [char](3) NOT NULL,
	[MaturityDate] [date] NULL,
	[PriceScalingFactor] [decimal](12, 6) NOT NULL,
	[FuturePointValue] [decimal](14, 6) NULL,
	[GenericFutureId] [int] NULL,
 CONSTRAINT [PK_InstrumentId] PRIMARY KEY CLUSTERED 
(
	[InstrumentId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [trd].[H_Trade]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trd].[H_Trade](
	[TradeId] [int] NOT NULL,
	[OrderId] [int] NULL,
	[RebalancingId] [int] NULL,
	[EmsxSequence] [int] NULL,
	[EmsxOrderCreatedOn] [date] NULL,
	[InstrumentId] [int] NOT NULL,
	[ExchangeCode] [nvarchar](20) NULL,
	[Sedol] [nvarchar](7) NULL,
	[BuySellIndicator] [char](1) NOT NULL,
	[OrderQuantity] [int] NOT NULL,
	[FilledQuantity] [int] NOT NULL,
	[AvgPrice] [decimal](18, 6) NOT NULL,
	[DayAveragePrice] [decimal](18, 6) NULL,
	[TradeCurrency] [char](3) NOT NULL,
	[TradeDate] [date] NOT NULL,
	[Principal] [decimal](18, 6) NOT NULL,
	[NetAmount] [decimal](18, 6) NOT NULL,
	[SettlementDate] [date] NULL,
	[SettlementCurrency] [char](3) NULL,
	[BrokerCommission] [decimal](12, 6) NOT NULL,
	[CommissionRate] [decimal](12, 6) NOT NULL,
	[MiscFees] [decimal](12, 6) NOT NULL,
	[Notes] [nvarchar](300) NULL,
	[Trader] [nvarchar](30) NULL,
	[BrokerCode] [nvarchar](10) NOT NULL,
	[TradeDesk] [nvarchar](10) NOT NULL,
	[IsCfd] [bit] NOT NULL,
	[ExecutionChannel] [nvarchar](10) NULL,
	[CreatedOn] [datetime] NULL,
	[TotalCharges] [decimal](18, 6) NOT NULL,
	[FxemTradeId] [int] NULL,
	[FxemOrderId] [int] NULL,
	[TradeStatus] [nvarchar](5) NOT NULL,
	[FxCurrency1] [char](3) NULL,
	[FXCurrency1Amount] [decimal](24, 6) NULL,
	[FxCurrency2] [char](3) NULL,
	[FXCurrency2Amount] [decimal](24, 6) NULL,
	[BookedOn] [datetime] NOT NULL,
	[ValidFrom] [datetime2](7) NOT NULL,
	[ValidTo] [datetime2](7) NOT NULL,
	[IsFutureSwap] [bit] NOT NULL,
	[LocalToSettleFxRate] [decimal](12, 6) NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_H_Trade]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_H_Trade] ON [trd].[H_Trade]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [trd].[Trade]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trd].[Trade](
	[TradeId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NULL,
	[RebalancingId] [int] NULL,
	[EmsxSequence] [int] NULL,
	[EmsxOrderCreatedOn] [date] NULL,
	[InstrumentId] [int] NOT NULL,
	[ExchangeCode] [nvarchar](20) NULL,
	[Sedol] [nvarchar](7) NULL,
	[BuySellIndicator] [char](1) NOT NULL,
	[OrderQuantity] [int] NOT NULL,
	[FilledQuantity] [int] NOT NULL,
	[AvgPrice] [decimal](18, 6) NOT NULL,
	[DayAveragePrice] [decimal](18, 6) NULL,
	[TradeCurrency] [char](3) NOT NULL,
	[TradeDate] [date] NOT NULL,
	[Principal] [decimal](18, 6) NOT NULL,
	[NetAmount] [decimal](18, 6) NOT NULL,
	[SettlementDate] [date] NULL,
	[SettlementCurrency] [char](3) NULL,
	[BrokerCommission] [decimal](12, 6) NOT NULL,
	[CommissionRate] [decimal](12, 6) NOT NULL,
	[MiscFees] [decimal](12, 6) NOT NULL,
	[Notes] [nvarchar](300) NULL,
	[Trader] [nvarchar](30) NULL,
	[BrokerCode] [nvarchar](10) NOT NULL,
	[TradeDesk] [nvarchar](10) NOT NULL,
	[IsCfd] [bit] NOT NULL,
	[ExecutionChannel] [nvarchar](10) NULL,
	[CreatedOn] [datetime] NULL,
	[TotalCharges] [decimal](18, 6) NOT NULL,
	[FxemTradeId] [int] NULL,
	[FxemOrderId] [int] NULL,
	[TradeStatus] [nvarchar](5) NOT NULL,
	[FxCurrency1] [char](3) NULL,
	[FXCurrency1Amount] [decimal](24, 6) NULL,
	[FxCurrency2] [char](3) NULL,
	[FXCurrency2Amount] [decimal](24, 6) NULL,
	[BookedOn] [datetime] NOT NULL,
	[ValidFrom] [datetime2](7) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](7) GENERATED ALWAYS AS ROW END NOT NULL,
	[IsFutureSwap] [bit] NOT NULL,
	[LocalToSettleFxRate] [decimal](12, 6) NULL,
 CONSTRAINT [PK_Trade] PRIMARY KEY CLUSTERED 
(
	[TradeId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [trd].[H_Trade])
)
GO
/****** Object:  View [trd].[vwTrade]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO










/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [trd].[vwTrade] as
SELECT  [TradeId]
      ,[OrderId]
      ,[RebalancingId]
      ,[EmsxSequence]
      ,[EmsxOrderCreatedOn]
	  ,t.InstrumentId
      ,i.Symbol
	  ,i.InstrumentType
      ,[ExchangeCode]
      ,[Sedol]
      ,[BuySellIndicator]
      ,[OrderQuantity]
      ,[FilledQuantity]
      ,[AvgPrice]
      ,[DayAveragePrice]
      ,[TradeCurrency]
      ,[TradeDate]
      ,[Principal]
      ,[NetAmount]
      ,[SettlementDate]
      ,[SettlementCurrency]
      ,[BrokerCommission]
      ,[CommissionRate]
      ,[MiscFees]
      ,[Notes]
      ,[Trader]
      ,[BrokerCode]
      ,[TradeDesk]
      ,[IsCfd]
	  ,[IsFutureSwap]
      ,[ExecutionChannel]
      ,[CreatedOn]
      ,[TotalCharges]
      ,[FxemTradeId]
      ,[FxemOrderId]
      ,[TradeStatus]
      ,[FxCurrency1]
      ,[FXCurrency1Amount]
      ,[FxCurrency2]
      ,[FXCurrency2Amount]
      ,[BookedOn]
  FROM [trd].[Trade] t
  join trd.Instrument i on i.InstrumentId = t.InstrumentId
GO
/****** Object:  Table [dbo].[emsx_export]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[emsx_export](
	[column1] [nvarchar](50) NULL,
	[News] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
	[BsktValue] [nvarchar](50) NULL,
	[Value_Local] [nvarchar](50) NULL,
	[BsktValue2] [nvarchar](50) NULL,
	[Net_Value_Local] [nvarchar](50) NULL,
	[Tkr_YKey] [nvarchar](50) NULL,
	[Side] [nvarchar](50) NULL,
	[Qty] [nvarchar](50) NULL,
	[FillQty] [nvarchar](50) NULL,
	[Order_Type] [nvarchar](50) NULL,
	[Trade_Date] [nvarchar](50) NULL,
	[SEDOL] [nvarchar](50) NULL,
	[Order_Ref_ID] [nvarchar](50) NULL,
	[Exch_Code] [nvarchar](50) NULL,
	[DayAvgPx] [nvarchar](50) NULL,
	[LmtPx] [nvarchar](50) NULL,
	[Total_Fees] [nvarchar](50) NULL,
	[Filled] [nvarchar](50) NULL,
	[TIF] [nvarchar](50) NULL,
	[Urgency] [nvarchar](50) NULL,
	[AvgPx] [nvarchar](50) NULL,
	[Principal] [nvarchar](50) NULL,
	[Brkr_Code] [nvarchar](50) NULL,
	[Account] [nvarchar](50) NULL,
	[Last_Fill_Datetime] [nvarchar](50) NULL,
	[ISIN] [nvarchar](50) NULL,
	[Order_ID] [nvarchar](50) NULL,
	[Yellow_Key_Parseky_able_FIGI_or_Tkr_YKey] [nvarchar](50) NULL,
	[Bskt_Name] [nvarchar](50) NULL,
	[Booking_Type] [nvarchar](50) NULL,
	[Curncy] [nvarchar](50) NULL,
	[Mkt_Sector_Des] [nvarchar](50) NULL,
	[RebalancingId] [nvarchar](50) NULL,
	[Handling_Inst] [nvarchar](50) NULL,
	[Custom_Note_3] [nvarchar](50) NULL,
	[Strategy_Name] [nvarchar](50) NULL,
	[Custom_Note_1] [nvarchar](50) NULL,
	[Custom_Note_2] [nvarchar](50) NULL,
	[LocBrkr] [nvarchar](50) NULL,
	[Trader] [nvarchar](50) NULL,
	[Create_Time_As_of] [nvarchar](50) NULL,
	[Idle] [nvarchar](50) NULL,
	[Working_Qty] [nvarchar](50) NULL,
	[Comm_Rate] [nvarchar](50) NULL,
	[Data_Export_Restricted] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  View [trd].[vwEmsxTradeReconciliation]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [trd].[vwEmsxTradeReconciliation] as
SELECT   cast(LEFT(RIGHT(e.[Order_ID],17),8) as int) as EmsxSequence
,t.EmsxSequence as BookedSequence
, t.TradeId
		,e.[Tkr_YKey] as EmsxSymbol
		,t.Symbol as BookedSymbol
	
		,e.[FillQty]*IIF(LEFT(SIDE,1) = 'S', -1,1) as EmsxQuantity
		,t.FilledQuantity as BookedQuantity
		,e.[FillQty]*IIF(LEFT(SIDE,1) = 'S', -1,1)-t.FilledQuantity as QuantityDiff
		,IIF(LEFT(SIDE,1) = 'S', -1,1) - SIGN(t.FilledQuantity) as SignDiff
		,e.[AvgPx]as EmsxPrice
		,t.AvgPrice as BookedPrice
		,t.AvgPrice-e.[AvgPx] as PriceDiff
		,e.[Trade_Date] as EmsxTradeDate
		,t.TradeDate as BookedTradeDate
		,IIF(CAST(t.TradeDate as date) = CAST(e.[Trade_Date] as date),1,-999)  as TradeDateDiff
		,e.[Curncy] as EmsxCurrency
		,t.TradeCurrency as BookedCurrency
		, IIF(t.TradeCurrency = e.[Curncy],1,-999) as CurrencyDiff
  FROM [dbo].[emsx_export] e
  LEFT JOIN trd.vwTrade t on t.EmsxSequence = cast(LEFT(RIGHT(e.[Order_ID],17),8) as int)
  where cast(e.Filled as float)>0
GO
/****** Object:  Table [instr].[MIC_H]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [instr].[MIC_H](
	[MICId] [smallint] NOT NULL,
	[Code] [nvarchar](5) NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_MIC_H]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_MIC_H] ON [instr].[MIC_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [instr].[MIC]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [instr].[MIC](
	[MICId] [smallint] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](5) NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_MICId] PRIMARY KEY CLUSTERED 
(
	[MICId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_MIC] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [instr].[MIC_H])
)
GO
/****** Object:  Table [book].[H_Counterparty]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [book].[H_Counterparty](
	[CounterpartyId] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Code] [nvarchar](6) NOT NULL,
	[IsExecutionBroker] [bit] NOT NULL,
	[IsClearingBroker] [bit] NOT NULL,
	[IsPrimeBroker] [bit] NOT NULL,
	[IsCustodian] [bit] NOT NULL,
	[ValidFrom] [datetime2](7) NOT NULL,
	[ValidTo] [datetime2](7) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_H_Counterparty]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_H_Counterparty] ON [book].[H_Counterparty]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [book].[Counterparty]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [book].[Counterparty](
	[CounterpartyId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Code] [nvarchar](6) NOT NULL,
	[IsExecutionBroker] [bit] NOT NULL,
	[IsClearingBroker] [bit] NOT NULL,
	[IsPrimeBroker] [bit] NOT NULL,
	[IsCustodian] [bit] NOT NULL,
	[ValidFrom] [datetime2](7) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](7) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_Counterparty] PRIMARY KEY CLUSTERED 
(
	[CounterpartyId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_CounterpartyCode] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [book].[H_Counterparty])
)
GO
/****** Object:  Table [book].[Instrument]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [book].[Instrument](
	[InstrumentId] [int] NOT NULL,
	[Symbol] [nvarchar](30) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[ISIN] [nvarchar](12) NULL,
	[BbgUniqueId] [nvarchar](30) NOT NULL,
	[InstrumentType] [nvarchar](10) NOT NULL,
	[MarketSector] [nvarchar](6) NOT NULL,
	[Exchange] [nvarchar](5) NULL,
	[PrimaryMic] [nvarchar](10) NULL,
	[Currency] [char](3) NOT NULL,
	[QuoteCurrency] [char](3) NOT NULL,
	[MaturityDate] [date] NULL,
	[PriceScalingFactor] [decimal](12, 6) NOT NULL,
	[FuturePointValue] [decimal](14, 6) NULL,
	[GenericFutureId] [int] NULL,
 CONSTRAINT [PK_InstrumentId] PRIMARY KEY CLUSTERED 
(
	[InstrumentId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [book].[vwSettlementInfo]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO












/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [book].[vwSettlementInfo] as
SELECT cp.Code as Counterparty
      ,ins.Symbol
	  , ins.InstrumentType
	  ,ins.Exchange
      ,[IsSwap]
      ,[DaysToSettle]
      ,[SettleCurrency]

  FROM [book].[SettlementInfo] si
  JOIN [book].Counterparty cp on cp.[CounterpartyId] =  si.CounterpartyId
    JOIN [book].Instrument ins on ins.[InstrumentId] =  si.[InstrumentId]

GO
/****** Object:  Table [trans].[FileTransmission]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[FileTransmission](
	[FileTransmissionId] [int] IDENTITY(1,1) NOT NULL,
	[TransmissionType] [nvarchar](20) NOT NULL,
	[TransmittedOn] [datetime] NULL,
	[IsFtpTransmitted] [bit] NOT NULL,
	[IsEmailTransmitted] [bit] NOT NULL,
	[Counterparty] [nvarchar](50) NOT NULL,
	[ContentType] [nvarchar](5) NOT NULL,
 CONSTRAINT [PK_FileTransmission] PRIMARY KEY CLUSTERED 
(
	[FileTransmissionId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [trans].[vwLastFileTransmission]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





















/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [trans].[vwLastFileTransmission] as
with lastransmission as (
SELECT max([FileTransmissionId]) as [FileTransmissionId]
      ,[TransmissionType]
  FROM [trans].[FileTransmission]
  GROUP BY [TransmissionType]
)
SELECT top (1000) ft.[FileTransmissionId]
      ,ft.[TransmissionType]

      ,[IsFtpTransmitted]
      ,[IsEmailTransmitted]
      ,[Counterparty]
      ,[ContentType]    
      ,[TransmittedOn]
  FROM [trans].[FileTransmission] ft
  JOIN lastransmission lt on lt.[FileTransmissionId] = ft.FileTransmissionId
  Order by [TransmittedOn] desc
GO
/****** Object:  Table [trans].[Trade]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[Trade](
	[TradeId] [int] NOT NULL,
	[OrderId] [int] NULL,
	[RebalancingId] [int] NULL,
	[EmsxSequence] [int] NULL,
	[EmsxOrderCreatedOn] [date] NULL,
	[InstrumentId] [int] NOT NULL,
	[ExchangeCode] [nvarchar](20) NULL,
	[Sedol] [nvarchar](7) NULL,
	[BuySellIndicator] [char](1) NOT NULL,
	[OrderQuantity] [int] NOT NULL,
	[FilledQuantity] [int] NOT NULL,
	[AvgPrice] [decimal](18, 6) NOT NULL,
	[DayAveragePrice] [decimal](18, 6) NULL,
	[TradeCurrency] [char](3) NOT NULL,
	[TradeDate] [date] NOT NULL,
	[Principal] [decimal](18, 6) NOT NULL,
	[NetAmount] [decimal](18, 6) NOT NULL,
	[SettlementDate] [date] NULL,
	[SettlementCurrency] [char](3) NULL,
	[BrokerCommission] [decimal](12, 6) NOT NULL,
	[CommissionRate] [decimal](12, 6) NOT NULL,
	[MiscFees] [decimal](12, 6) NOT NULL,
	[Notes] [nvarchar](300) NULL,
	[Trader] [nvarchar](30) NULL,
	[BrokerCode] [nvarchar](10) NOT NULL,
	[TradeDesk] [nvarchar](10) NOT NULL,
	[IsCfd] [bit] NOT NULL,
	[ExecutionChannel] [nvarchar](10) NULL,
	[CreatedOn] [datetime] NULL,
	[TotalCharges] [decimal](18, 6) NOT NULL,
	[FxemTradeId] [int] NULL,
	[FxemOrderId] [int] NULL,
	[TradeStatus] [nvarchar](5) NOT NULL,
	[FxCurrency1] [char](3) NULL,
	[FXCurrency1Amount] [decimal](24, 6) NULL,
	[FxCurrency2] [char](3) NULL,
	[FXCurrency2Amount] [decimal](24, 6) NULL,
	[BookedOn] [datetime] NOT NULL,
	[IsFutureSwap] [bit] NOT NULL,
	[LocalToSettleFxRate] [decimal](12, 6) NULL,
 CONSTRAINT [PK_Trade] PRIMARY KEY CLUSTERED 
(
	[TradeId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [trans].[TradeAllocation]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[TradeAllocation](
	[TradeAllocationId] [int] NOT NULL,
	[TradeId] [int] NOT NULL,
	[PortfolioId] [tinyint] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](18, 6) NOT NULL,
	[GrossAmount] [decimal](18, 6) NOT NULL,
	[NetAmount] [decimal](18, 6) NOT NULL,
	[Commission] [decimal](18, 6) NOT NULL,
	[Fees] [decimal](18, 6) NOT NULL,
	[PositionSide] [char](1) NULL,
	[TradingAccount] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_TradeAllocation] PRIMARY KEY CLUSTERED 
(
	[TradeAllocationId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [trans].[Instrument]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[Instrument](
	[InstrumentId] [int] NOT NULL,
	[Symbol] [nvarchar](30) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[ISIN] [nvarchar](12) NULL,
	[BbgUniqueId] [nvarchar](30) NOT NULL,
	[InstrumentType] [nvarchar](10) NOT NULL,
	[MarketSector] [nvarchar](6) NOT NULL,
	[Exchange] [nvarchar](5) NULL,
	[PrimaryMic] [nvarchar](10) NULL,
	[Currency] [char](3) NOT NULL,
	[QuoteCurrency] [char](3) NOT NULL,
	[MaturityDate] [date] NULL,
	[PriceScalingFactor] [decimal](12, 6) NOT NULL,
	[FuturePointValue] [decimal](14, 6) NULL,
	[GenericFutureId] [int] NULL,
	[FutureContractMonth] [tinyint] NULL,
	[FutureContractYear] [int] NULL,
 CONSTRAINT [PK_InstrumentId] PRIMARY KEY CLUSTERED 
(
	[InstrumentId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [trans].[FxRate]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[FxRate](
	[BaseCurrency] [char](3) NOT NULL,
	[QuoteCurrency] [char](3) NOT NULL,
	[Value] [decimal](12, 6) NOT NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_FxRate] PRIMARY KEY CLUSTERED 
(
	[BaseCurrency] ASC,
	[QuoteCurrency] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [trans].[H_CounterpartyCodeMapping]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[H_CounterpartyCodeMapping](
	[CounterpartyCodeMappingId] [int] NOT NULL,
	[PortfolioId] [tinyint] NOT NULL,
	[FileGenerationType] [nvarchar](20) NOT NULL,
	[ExecutionAccount] [nvarchar](12) NULL,
	[ClearingAccount] [nvarchar](12) NULL,
	[ExecutionBroker] [nvarchar](5) NULL,
	[ClearingBroker] [nvarchar](5) NULL,
	[Custodian] [nvarchar](5) NULL,
	[ValidFrom] [datetime2](7) NOT NULL,
	[ValidTo] [datetime2](7) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_H_CounterpartyCodeMapping]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_H_CounterpartyCodeMapping] ON [trans].[H_CounterpartyCodeMapping]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [trans].[CounterpartyCodeMapping]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[CounterpartyCodeMapping](
	[CounterpartyCodeMappingId] [int] IDENTITY(1,1) NOT NULL,
	[PortfolioId] [tinyint] NOT NULL,
	[FileGenerationType] [nvarchar](20) NOT NULL,
	[ExecutionAccount] [nvarchar](12) NULL,
	[ClearingAccount] [nvarchar](12) NULL,
	[ExecutionBroker] [nvarchar](5) NULL,
	[ClearingBroker] [nvarchar](5) NULL,
	[Custodian] [nvarchar](5) NULL,
	[ValidFrom] [datetime2](7) GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
	[ValidTo] [datetime2](7) GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
 CONSTRAINT [PK_CounterpartyCodeMapping] PRIMARY KEY CLUSTERED 
(
	[CounterpartyCodeMappingId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_CounterpartyCodeMapping] UNIQUE NONCLUSTERED 
(
	[PortfolioId] ASC,
	[FileGenerationType] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [trans].[H_CounterpartyCodeMapping])
)
GO
/****** Object:  UserDefinedFunction [trans].[ZZZ_tvTradesFileCAPRICORN]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE FUNCTION [trans].[ZZZ_tvTradesFileCAPRICORN] (@PortfolioId tinyint)
RETURNS TABLE
AS
RETURN
SELECT 
  ROW_NUMBER() OVER(ORDER BY ins.Symbol)  as [Order number],
  REPLACE(REPLACE(REPLACE(trd.TradeStatus,'NEW','N'),'CAN','C'),'COR','A') as Activity,
  codes.ClearingAccount as Account,
  ins.Name as [Security Description],
  ins.Symbol as [Ticker Symbol],
  trd.ExchangeCode as [Exchange-MIC],
  ISNULL(ins.ISIN,'') as [ISIN],
  IIF(trd.Sedol is null or TRIM(trd.Sedol )= '', '',trd.Sedol ) as [SEDOL],
  '' as[CUSIP],
  trd.BrokerCode as [Broker],
  codes.Custodian as Custodian,
  ins.InstrumentType as [Security Type],
  alloc.PositionSide as [Transaction type],
  trd.TradeCurrency as [Settlement Ccy],
  FORMAT(cast(trd.TradeDate as date),'yyyyMMdd') as [Trade date],
  CASE 
    WHEN InstrumentType = 'EQU' THEN FORMAT(trd.fnAddBusinessDays(trd.TradeDate,1),'yyyyMMdd')
    ELSE FORMAT(cast(trd.TradeDate as date),'yyyyMMdd') 
  END as [Settle date],
  trd.OrderQuantity as [Order Quantity],
  trd.FilledQuantity as[Fillled Quantity],
  trd.BrokerCommission as [Commission],
  trd.AvgPrice * ISNULL(fxr.[Value],1) AS Price,
  '' as [Accrued interest],
  '' as [Sec Fee],
  '' as [Trade tax],
  ISNULL(trd.MiscFees,0) as [Misc money],
  CAST(trd.NetAmount as decimal(24,2)) as [Net amount],
  CAST(trd.Principal as decimal(24,2)) as [Principal],
  '' as [Description],
  IIF(trd.IsCfd= 1, 1, 0) as [Is_CFD],
  '' as [Clearing Agent],
  '' as [Put/Call],
  '' as Strike,
  FORMAT(ISNULL(ins.MaturityDate,''),'yyyy-MM-dd') as [Expiry Date],
  trd.Trader as Trader
FROM 
  [trans].Trade trd
JOIN 
  [trans].TradeAllocation alloc ON alloc.TradeId = trd.TradeId
JOIN 
  [trans].Instrument ins ON ins.InstrumentId = trd.InstrumentId
LEFT JOIN 
  [trans].FxRate fxr ON fxr.BaseCurrency = trd.TradeCurrency AND fxr.QuoteCurrency = 'USD'
LEFT JOIN 
  trans.[vwLastFileTransmission] ft ON ft.TransmissionType = 'CAPRITRD'
 LEFT JOIN 
trans.CounterpartyCodeMapping codes ON codes.PortfolioId = alloc.PortfolioId and  codes.FileGenerationType = 'CAPRICORN'
WHERE 
--  trd.TradeDate = CAST(GETDATE() as date)
 -- AND 
  (ft.TransmittedOn IS NULL OR ft.TransmittedOn < trd.BookedOn)
  AND alloc.PortfolioId = @PortfolioId;
GO
/****** Object:  Table [risk].[ConstraintType_H]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [risk].[ConstraintType_H](
	[ConstraintTypeId] [smallint] NOT NULL,
	[Mnemonic] [nvarchar](10) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_ConstraintType_H]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_ConstraintType_H] ON [risk].[ConstraintType_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [risk].[ConstraintType]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [risk].[ConstraintType](
	[ConstraintTypeId] [smallint] IDENTITY(1,1) NOT NULL,
	[Mnemonic] [nvarchar](10) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_ConstraintTypeId] PRIMARY KEY CLUSTERED 
(
	[ConstraintTypeId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_ConstraintTypeMnemonic] UNIQUE NONCLUSTERED 
(
	[Mnemonic] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [risk].[ConstraintType_H])
)
GO
/****** Object:  UserDefinedFunction [trans].[ZZZ_tvTradesFileGSPBFUT]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [trans].[ZZZ_tvTradesFileGSPBFUT] (@PortfolioId tinyint)
RETURNS TABLE
AS
RETURN
SELECT  

'A' as [TYPE],
CONCAT('A',alloc.TradeAllocationId) AS [CLIENTREF],
ins.Symbol as [CONTRACT],
ins.FutureContractMonth as [MONTH],
ins.FutureContractYear as [YEAR],
'' as PUTCALL,-- blank for futures
'' as STRIKE,-- blank for futures
trd.BuySellIndicator as BUYSELL,-- blank for futures
alloc.Quantity as [QUANTITY],
codes.ClearingAccount as [ACCOUNT],
'' AS [ORDERTYPE],
	ROUND(trd.AvgPrice, 6) AS [Price], 
codes.ExecutionBroker as [EXECBROKER],
codes.ClearingBroker as [CLEARINGBROKER],
'' as [RELATEDID],
'' as [GROUPID],
'' as [SPREADREF],
trd.EmsxSequence as [MEMO],
'FIA-C' as [ELECTRONICEXECUTION],
'BID' as SYMBOLOGYTYPE,
'' as FILLERCOLUMN,
IIF(ins.Exchange = 'LME',FORMAT(ins.MaturityDate, 'yyyyMMdd'),'') as PROMPTDATE,
FORMAT(trd.fnAddBusinessDays(trd.TradeDate,1), 'yyyyMMdd') AS [CLEARINGDATE],
'N' as [CLIENTACTION]
FROM 
    [Trading].[trans].[Trade] trd
JOIN 
    trans.TradeAllocation alloc ON alloc.TradeId = trd.TradeId
JOIN 
    trans.Instrument ins ON ins.InstrumentId = trd.InstrumentId
LEFT JOIN 
    trans.[vwLastFileTransmission] ft ON ft.TransmissionType = 'GSPBTRD'
JOIN 
	trans.CounterpartyCodeMapping codes ON codes.PortfolioId = alloc.PortfolioId and  codes.FileGenerationType = 'GSPBFUT'
WHERE 
     ins.InstrumentType = 'FUT'
  	AND trd.TradeDesk in ('MSET','MSST')--That is not correct, we can exec with one broker and pb another.
    AND trd.IsFutureSwap = 0
    AND (ft.TransmittedOn IS NULL OR ft.TransmittedOn < trd.BookedOn)
	and  trd.TradeDate ='2024-03-11'
	AND alloc.PortfolioId = @PortfolioId;
GO
/****** Object:  Table [exec].[H_EmsxOrder]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [exec].[H_EmsxOrder](
	[EmsxSequence] [int] NOT NULL,
	[Amount] [int] NULL,
	[Broker] [nvarchar](255) NULL,
	[HandInstruction] [nvarchar](255) NULL,
	[OrderType] [nvarchar](255) NULL,
	[Ticker] [nvarchar](255) NULL,
	[TimeInForce] [nvarchar](255) NULL,
	[OrderOrigin] [nvarchar](255) NULL,
	[ApiSeqNum] [bigint] NULL,
	[OrderNumber] [int] NULL,
	[Side] [nvarchar](255) NULL,
	[Account] [nvarchar](255) NULL,
	[BasketName] [nvarchar](255) NULL,
	[Strategy] [nvarchar](255) NULL,
	[ClearingAccount] [nvarchar](255) NULL,
	[ClearingFirm] [nvarchar](255) NULL,
	[CustomNote1] [nvarchar](255) NULL,
	[CustomNote2] [nvarchar](255) NULL,
	[CustomNote3] [nvarchar](255) NULL,
	[CustomNote4] [nvarchar](255) NULL,
	[CustomNote5] [nvarchar](255) NULL,
	[ExchangeDestination] [nvarchar](255) NULL,
	[ExecInstruction] [nvarchar](255) NULL,
	[Warnings] [nvarchar](255) NULL,
	[GtdDate] [date] NULL,
	[InvestorId] [nvarchar](255) NULL,
	[LimitPrice] [decimal](18, 6) NULL,
	[LocateBroker] [nvarchar](255) NULL,
	[LocateId] [nvarchar](255) NULL,
	[LocateRequest] [nvarchar](255) NULL,
	[Notes] [nvarchar](255) NULL,
	[OddLot] [int] NULL,
	[OrderRefId] [nvarchar](255) NULL,
	[ReleaseTime] [time](7) NULL,
	[RequestSequence] [int] NULL,
	[SettlementCurrency] [nvarchar](255) NULL,
	[SettlementDate] [date] NULL,
	[SettlementType] [nvarchar](255) NULL,
	[SettlementPrice] [decimal](18, 6) NULL,
	[StopPrice] [decimal](18, 6) NULL,
	[TraderUuid] [int] NULL,
	[ArrivalPrice] [decimal](18, 6) NULL,
	[AssetClass] [nvarchar](255) NULL,
	[AssignedTrader] [nvarchar](255) NULL,
	[AvgPrice] [decimal](18, 6) NULL,
	[BasketNum] [int] NULL,
	[BrokerComm] [decimal](18, 6) NULL,
	[BseAvgPrice] [decimal](18, 6) NULL,
	[BseFilled] [int] NULL,
	[CfdFlag] [nvarchar](255) NULL,
	[CommDiffFlag] [nvarchar](255) NULL,
	[CommRate] [decimal](18, 6) NULL,
	[CurrencyPair] [nvarchar](255) NULL,
	[Date] [date] NULL,
	[DayAvgPrice] [decimal](18, 6) NULL,
	[DayFill] [int] NULL,
	[DirBrokerFlag] [nvarchar](255) NULL,
	[Exchange] [nvarchar](255) NULL,
	[FillId] [int] NULL,
	[Filled] [int] NULL,
	[IdleAmount] [int] NULL,
	[Isin] [nvarchar](255) NULL,
	[NseAvgPrice] [decimal](18, 6) NULL,
	[NseFilled] [int] NULL,
	[OriginateTrader] [nvarchar](255) NULL,
	[OriginateTraderFirm] [nvarchar](255) NULL,
	[PercentRemain] [decimal](18, 6) NULL,
	[PmUuid] [int] NULL,
	[PortMgr] [nvarchar](255) NULL,
	[PortName] [nvarchar](255) NULL,
	[PortNum] [int] NULL,
	[Position] [nvarchar](255) NULL,
	[Principal] [decimal](18, 6) NULL,
	[Product] [nvarchar](255) NULL,
	[QueuedDate] [int] NULL,
	[QueuedTime] [int] NULL,
	[ReasonCode] [nvarchar](255) NULL,
	[ReasonDescription] [nvarchar](255) NULL,
	[RemainBalance] [decimal](18, 6) NULL,
	[RouteId] [int] NULL,
	[RoutePrice] [decimal](18, 6) NULL,
	[SecName] [nvarchar](255) NULL,
	[Sedol] [nvarchar](255) NULL,
	[SettleAmount] [decimal](18, 6) NULL,
	[SettleDate] [date] NULL,
	[StartAmount] [int] NULL,
	[Status] [nvarchar](255) NULL,
	[StepOutBrooker] [nvarchar](255) NULL,
	[StrategyEndTime] [int] NULL,
	[StrategyPartRate1] [decimal](18, 6) NULL,
	[StrategyPartRate2] [decimal](18, 6) NULL,
	[StrategyStartTime] [int] NULL,
	[StrategyStyle] [nvarchar](255) NULL,
	[StrategyType] [nvarchar](255) NULL,
	[TimeStamp] [time](7) NULL,
	[TradeDesk] [nvarchar](255) NULL,
	[Trader] [nvarchar](255) NULL,
	[TraderNotes] [nvarchar](255) NULL,
	[TsOrdNum] [int] NULL,
	[Type] [nvarchar](255) NULL,
	[UnderlyingTicker] [nvarchar](255) NULL,
	[UserCommAmount] [decimal](18, 6) NULL,
	[UserCommRate] [decimal](18, 6) NULL,
	[UserFees] [decimal](18, 6) NULL,
	[UserNetMoney] [decimal](18, 6) NULL,
	[UserWorkPrice] [decimal](18, 6) NULL,
	[Working] [int] NULL,
	[YellowKey] [nvarchar](255) NULL,
	[BookName] [nvarchar](255) NULL,
	[LocateReq] [nvarchar](255) NULL,
	[Pa] [int] NULL,
	[RouteRefId] [nvarchar](255) NULL,
	[ValidFrom] [datetime2](7) NOT NULL,
	[ValidTo] [datetime2](7) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_H_EmsxOrder]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_H_EmsxOrder] ON [exec].[H_EmsxOrder]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [exec].[EmsxOrder]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [exec].[EmsxOrder](
	[EmsxSequence] [int] NOT NULL,
	[Amount] [int] NULL,
	[Broker] [nvarchar](255) NULL,
	[HandInstruction] [nvarchar](255) NULL,
	[OrderType] [nvarchar](255) NULL,
	[Ticker] [nvarchar](255) NULL,
	[TimeInForce] [nvarchar](255) NULL,
	[OrderOrigin] [nvarchar](255) NULL,
	[ApiSeqNum] [bigint] NULL,
	[OrderNumber] [int] NULL,
	[Side] [nvarchar](255) NULL,
	[Account] [nvarchar](255) NULL,
	[BasketName] [nvarchar](255) NULL,
	[Strategy] [nvarchar](255) NULL,
	[ClearingAccount] [nvarchar](255) NULL,
	[ClearingFirm] [nvarchar](255) NULL,
	[CustomNote1] [nvarchar](255) NULL,
	[CustomNote2] [nvarchar](255) NULL,
	[CustomNote3] [nvarchar](255) NULL,
	[CustomNote4] [nvarchar](255) NULL,
	[CustomNote5] [nvarchar](255) NULL,
	[ExchangeDestination] [nvarchar](255) NULL,
	[ExecInstruction] [nvarchar](255) NULL,
	[Warnings] [nvarchar](255) NULL,
	[GtdDate] [date] NULL,
	[InvestorId] [nvarchar](255) NULL,
	[LimitPrice] [decimal](18, 6) NULL,
	[LocateBroker] [nvarchar](255) NULL,
	[LocateId] [nvarchar](255) NULL,
	[LocateRequest] [nvarchar](255) NULL,
	[Notes] [nvarchar](255) NULL,
	[OddLot] [int] NULL,
	[OrderRefId] [nvarchar](255) NULL,
	[ReleaseTime] [time](7) NULL,
	[RequestSequence] [int] NULL,
	[SettlementCurrency] [nvarchar](255) NULL,
	[SettlementDate] [date] NULL,
	[SettlementType] [nvarchar](255) NULL,
	[SettlementPrice] [decimal](18, 6) NULL,
	[StopPrice] [decimal](18, 6) NULL,
	[TraderUuid] [int] NULL,
	[ArrivalPrice] [decimal](18, 6) NULL,
	[AssetClass] [nvarchar](255) NULL,
	[AssignedTrader] [nvarchar](255) NULL,
	[AvgPrice] [decimal](18, 6) NULL,
	[BasketNum] [int] NULL,
	[BrokerComm] [decimal](18, 6) NULL,
	[BseAvgPrice] [decimal](18, 6) NULL,
	[BseFilled] [int] NULL,
	[CfdFlag] [nvarchar](255) NULL,
	[CommDiffFlag] [nvarchar](255) NULL,
	[CommRate] [decimal](18, 6) NULL,
	[CurrencyPair] [nvarchar](255) NULL,
	[Date] [date] NULL,
	[DayAvgPrice] [decimal](18, 6) NULL,
	[DayFill] [int] NULL,
	[DirBrokerFlag] [nvarchar](255) NULL,
	[Exchange] [nvarchar](255) NULL,
	[FillId] [int] NULL,
	[Filled] [int] NULL,
	[IdleAmount] [int] NULL,
	[Isin] [nvarchar](255) NULL,
	[NseAvgPrice] [decimal](18, 6) NULL,
	[NseFilled] [int] NULL,
	[OriginateTrader] [nvarchar](255) NULL,
	[OriginateTraderFirm] [nvarchar](255) NULL,
	[PercentRemain] [decimal](18, 6) NULL,
	[PmUuid] [int] NULL,
	[PortMgr] [nvarchar](255) NULL,
	[PortName] [nvarchar](255) NULL,
	[PortNum] [int] NULL,
	[Position] [nvarchar](255) NULL,
	[Principal] [decimal](18, 6) NULL,
	[Product] [nvarchar](255) NULL,
	[QueuedDate] [int] NULL,
	[QueuedTime] [int] NULL,
	[ReasonCode] [nvarchar](255) NULL,
	[ReasonDescription] [nvarchar](255) NULL,
	[RemainBalance] [decimal](18, 6) NULL,
	[RouteId] [int] NULL,
	[RoutePrice] [decimal](18, 6) NULL,
	[SecName] [nvarchar](255) NULL,
	[Sedol] [nvarchar](255) NULL,
	[SettleAmount] [decimal](18, 6) NULL,
	[SettleDate] [date] NULL,
	[StartAmount] [int] NULL,
	[Status] [nvarchar](255) NULL,
	[StepOutBrooker] [nvarchar](255) NULL,
	[StrategyEndTime] [int] NULL,
	[StrategyPartRate1] [decimal](18, 6) NULL,
	[StrategyPartRate2] [decimal](18, 6) NULL,
	[StrategyStartTime] [int] NULL,
	[StrategyStyle] [nvarchar](255) NULL,
	[StrategyType] [nvarchar](255) NULL,
	[TimeStamp] [time](7) NULL,
	[TradeDesk] [nvarchar](255) NULL,
	[Trader] [nvarchar](255) NULL,
	[TraderNotes] [nvarchar](255) NULL,
	[TsOrdNum] [int] NULL,
	[Type] [nvarchar](255) NULL,
	[UnderlyingTicker] [nvarchar](255) NULL,
	[UserCommAmount] [decimal](18, 6) NULL,
	[UserCommRate] [decimal](18, 6) NULL,
	[UserFees] [decimal](18, 6) NULL,
	[UserNetMoney] [decimal](18, 6) NULL,
	[UserWorkPrice] [decimal](18, 6) NULL,
	[Working] [int] NULL,
	[YellowKey] [nvarchar](255) NULL,
	[BookName] [nvarchar](255) NULL,
	[LocateReq] [nvarchar](255) NULL,
	[Pa] [int] NULL,
	[RouteRefId] [nvarchar](255) NULL,
	[ValidFrom] [datetime2](7) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](7) GENERATED ALWAYS AS ROW END NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EmsxSequence] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [exec].[H_EmsxOrder])
)
GO
/****** Object:  View [exec].[vwDailyEmsxOrdersStatus]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





























/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [exec].[vwDailyEmsxOrdersStatus] as
SELECT Status, COUNT(*) as #, [Date] as TradeDate
  FROM [exec].[EmsxOrder] where cast ([Date] as date) = cast (GETUTCDATE() as date)
  group by status,Date
 
GO
/****** Object:  View [trd].[vwFutureCommission]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



























/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [trd].[vwFutureCommission] as
SELECT [FutureCommissionId]
      ,[BrokerCode]
      ,ins.[GenericFutureId]
	  , ins.Symbol
	  ,ins.InstrumentType
	  ,ins.Currency
      ,[CommPerLot]
      ,[CommRate]
	  ,[ExecDeskCommPerLot]
      ,[ExecDeskCommRate]
  FROM [trd].[FutureCommission] futcom
  JOIN trd.Instrument ins on ins.InstrumentId = futcom.[GenericFutureId]

GO
/****** Object:  Table [trd].[H_EmsxOrder]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trd].[H_EmsxOrder](
	[EmsxSequence] [int] NOT NULL,
	[OrderNumber] [int] NULL,
	[OrderRefId] [nvarchar](30) NULL,
	[Status] [nvarchar](15) NULL,
	[Ticker] [nvarchar](30) NOT NULL,
	[ISIN] [nvarchar](12) NULL,
	[Sedol] [nvarchar](7) NULL,
	[Exchange] [nvarchar](10) NULL,
	[Side] [nvarchar](10) NOT NULL,
	[Amount] [int] NOT NULL,
	[Filled] [int] NOT NULL,
	[AvgPrice] [decimal](18, 6) NOT NULL,
	[DayAvgPrice] [decimal](18, 6) NULL,
	[LimitPrice] [decimal](18, 6) NULL,
	[Principal] [decimal](24, 6) NOT NULL,
	[BrokerCommm] [decimal](12, 6) NULL,
	[CommmRate] [decimal](12, 6) NULL,
	[MiscFees] [decimal](12, 6) NULL,
	[OrderType] [nvarchar](10) NULL,
	[TimeInForce] [nvarchar](10) NULL,
	[Strategy] [nvarchar](10) NULL,
	[HandInstruction] [nvarchar](10) NOT NULL,
	[Broker] [nvarchar](30) NOT NULL,
	[Account] [nvarchar](20) NOT NULL,
	[CfdFlag] [char](1) NULL,
	[SettleCurrency] [char](3) NULL,
	[SettleAmount] [decimal](18, 6) NULL,
	[ClearingAccount] [nvarchar](30) NULL,
	[ClearingFirm] [nvarchar](30) NULL,
	[BasketName] [nvarchar](20) NULL,
	[CustomNote1] [nvarchar](100) NULL,
	[CustomNote2] [nvarchar](100) NULL,
	[CustomNote3] [nvarchar](100) NULL,
	[CustomNote4] [nvarchar](100) NULL,
	[CustomNote5] [nvarchar](100) NULL,
	[Notes] [nvarchar](300) NULL,
	[TraderUuid] [int] NULL,
	[Trader] [nvarchar](30) NULL,
	[EmsxDate] [date] NULL,
	[PercentRemain] [float] NULL,
	[YellowKey] [nvarchar](10) NOT NULL,
	[SettleDate] [date] NULL,
	[TimeStamp] [time](7) NULL,
	[LastFillDate] [date] NULL,
	[ValidFrom] [datetime2](7) NOT NULL,
	[ValidTo] [datetime2](7) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_H_EmsxOrder]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_H_EmsxOrder] ON [trd].[H_EmsxOrder]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [trd].[EmsxOrder]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trd].[EmsxOrder](
	[EmsxSequence] [int] NOT NULL,
	[OrderNumber] [int] NULL,
	[OrderRefId] [nvarchar](30) NULL,
	[Status] [nvarchar](15) NULL,
	[Ticker] [nvarchar](30) NOT NULL,
	[ISIN] [nvarchar](12) NULL,
	[Sedol] [nvarchar](7) NULL,
	[Exchange] [nvarchar](10) NULL,
	[Side] [nvarchar](10) NOT NULL,
	[Amount] [int] NOT NULL,
	[Filled] [int] NOT NULL,
	[AvgPrice] [decimal](18, 6) NOT NULL,
	[DayAvgPrice] [decimal](18, 6) NULL,
	[LimitPrice] [decimal](18, 6) NULL,
	[Principal] [decimal](24, 6) NOT NULL,
	[BrokerCommm] [decimal](12, 6) NULL,
	[CommmRate] [decimal](12, 6) NULL,
	[MiscFees] [decimal](12, 6) NULL,
	[OrderType] [nvarchar](10) NULL,
	[TimeInForce] [nvarchar](10) NULL,
	[Strategy] [nvarchar](10) NULL,
	[HandInstruction] [nvarchar](10) NOT NULL,
	[Broker] [nvarchar](30) NOT NULL,
	[Account] [nvarchar](20) NOT NULL,
	[CfdFlag] [char](1) NULL,
	[SettleCurrency] [char](3) NULL,
	[SettleAmount] [decimal](18, 6) NULL,
	[ClearingAccount] [nvarchar](30) NULL,
	[ClearingFirm] [nvarchar](30) NULL,
	[BasketName] [nvarchar](20) NULL,
	[CustomNote1] [nvarchar](100) NULL,
	[CustomNote2] [nvarchar](100) NULL,
	[CustomNote3] [nvarchar](100) NULL,
	[CustomNote4] [nvarchar](100) NULL,
	[CustomNote5] [nvarchar](100) NULL,
	[Notes] [nvarchar](300) NULL,
	[TraderUuid] [int] NULL,
	[Trader] [nvarchar](30) NULL,
	[EmsxDate] [date] NULL,
	[PercentRemain] [float] NULL,
	[YellowKey] [nvarchar](10) NOT NULL,
	[SettleDate] [date] NULL,
	[TimeStamp] [time](7) NULL,
	[LastFillDate] [date] NULL,
	[ValidFrom] [datetime2](7) GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
	[ValidTo] [datetime2](7) GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
 CONSTRAINT [PK_EmsxOrder] PRIMARY KEY CLUSTERED 
(
	[EmsxSequence] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [trd].[H_EmsxOrder])
)
GO
/****** Object:  UserDefinedFunction [trans].[ZZZ_tvTradesFileGSPBSYNTH]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE FUNCTION [trans].[ZZZ_tvTradesFileGSPBSYNTH] (@PortfolioId tinyint)
RETURNS TABLE
AS
RETURN
SELECT  
	CONCAT('A',alloc.TradeAllocationId) AS [Order Number],
	'N' as [Cancel correct indicator],
	codes.ClearingAccount as [Account number or acronym],
	TRIM(REPLACE(ins.Symbol,'Equity','')) as [Security Identifier],
	trd.TradeDesk as [Broker], -- explain granularity and provide codes
	codes.Custodian as Custodian, --when GSCO or GSCI?
	 --CASE 
  --      WHEN trd.BuySellIndicator = 'S' AND (alloc.PositionSide IN ('L', 'C')) THEN 'S'
  --      WHEN trd.BuySellIndicator = 'S' AND alloc.PositionSide = 'S' THEN 'SS'
  --      WHEN trd.BuySellIndicator = 'B' AND alloc.PositionSide = 'L' THEN 'B'
  --      WHEN trd.BuySellIndicator = 'B' AND (alloc.PositionSide IN ('S', 'C')) THEN 'BC'
  --  END AS [Transaction type],
   trd.BuySellIndicator AS [Transaction type],
	ISNULL(trd.SettlementCurrency, trd.TradeCurrency) AS [Currency Code],-- how to determine settlement currency?
	FORMAT(trd.[TradeDate], 'MM/dd/yyyy') AS [Trade Date],
	FORMAT(trd.fnAddBusinessDays(trd.TradeDate,IIF(ins.Symbol like '%Equity', 1,1)), 'MM/dd/yyyy') AS [Settlement Date],-- how to determine settlement date?
	trd.FilledQuantity as [Quantity],
    CAST(trd.BrokerCommission AS DECIMAL(24,2)) AS [Commission],
	ROUND(trd.AvgPrice, 6) AS [Price], 
	'' as [Accrued Interest],--Optional
	'' as [Trade tax],
	'' as [Misc Money],
	CAST(ABS(trd.NetAmount) AS DECIMAL(24,2)) AS [Net Amount],
	CAST(ABS(Principal) AS DECIMAL(24,2)) AS [Principal],
	'' as [Description], --not used
	'CFD' as [Security Type], --explain here what about futures that are not swap or CFD? when to use CFD over swap
	'' as [Coutry Settlement Code],
	'' as [Clearing Agent], -- GS can provide list if required
	'' as [SEC Fees], -- leave blacnk GS will calculate
	'' as [Option underlyer],
	'' as [Option expiry date],
	'' as [Option cal put indicator],
	'' as [Option strike price],
	'' as [Trailer],
	'' as [Trailer 1],
	'' as [Trailer 2],
	'' as [Trailer 3],
	'' as [Trailer 4]   
FROM 
    [Trading].[trans].[Trade] trd
JOIN 
    trans.TradeAllocation alloc ON alloc.TradeId = trd.TradeId
JOIN 
    trans.Instrument ins ON ins.InstrumentId = trd.InstrumentId
LEFT JOIN 
    trans.[vwLastFileTransmission] ft ON ft.TransmissionType = 'GSPBTRD'
LEFT JOIN 
	trans.CounterpartyCodeMapping codes ON codes.PortfolioId = alloc.PortfolioId and  codes.FileGenerationType = 'GSPBSYNTH'
WHERE 
     (
       ( ins.InstrumentType = 'EQU' AND trd.IsCfd = 1) 
        OR trd.IsFutureSwap = 1
    )
	AND trd.TradeDesk in ('GS','GSET')--That is not correct, we can exec with one broker and pb another.
    AND (ft.TransmittedOn IS NULL OR ft.TransmittedOn < trd.BookedOn)
	AND alloc.PortfolioId = @PortfolioId;
GO
/****** Object:  Table [instr].[Exchange_H]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [instr].[Exchange_H](
	[ExchangeId] [smallint] NOT NULL,
	[Code] [nvarchar](5) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_Exchange_H]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_Exchange_H] ON [instr].[Exchange_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [instr].[Exchange]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [instr].[Exchange](
	[ExchangeId] [smallint] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](5) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_ExchangeId] PRIMARY KEY CLUSTERED 
(
	[ExchangeId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_ExchangeCode] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [instr].[Exchange_H])
)
GO
/****** Object:  Table [instr].[MarketSector_H]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [instr].[MarketSector_H](
	[MarketSectorId] [tinyint] NOT NULL,
	[Mnemonic] [nvarchar](6) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_MarketSector_H]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_MarketSector_H] ON [instr].[MarketSector_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [instr].[MarketSector]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [instr].[MarketSector](
	[MarketSectorId] [tinyint] IDENTITY(1,1) NOT NULL,
	[Mnemonic] [nvarchar](6) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_MarketSector] PRIMARY KEY CLUSTERED 
(
	[MarketSectorId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [instr].[MarketSector_H])
)
GO
/****** Object:  Table [instr].[IndustryGroup_H]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [instr].[IndustryGroup_H](
	[IndustryGroupId] [int] NOT NULL,
	[Number] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_IndustryGroup_H]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_IndustryGroup_H] ON [instr].[IndustryGroup_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [instr].[IndustryGroup]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [instr].[IndustryGroup](
	[IndustryGroupId] [int] IDENTITY(1,1) NOT NULL,
	[Number] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_IndustryGroupId] PRIMARY KEY CLUSTERED 
(
	[IndustryGroupId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_IndustryGroupNumber] UNIQUE NONCLUSTERED 
(
	[Number] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [instr].[IndustryGroup_H])
)
GO
/****** Object:  Table [instr].[IndustrySector_H]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [instr].[IndustrySector_H](
	[IndustrySectorId] [int] NOT NULL,
	[Number] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_IndustrySector_H]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_IndustrySector_H] ON [instr].[IndustrySector_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [instr].[IndustrySector]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [instr].[IndustrySector](
	[IndustrySectorId] [int] IDENTITY(1,1) NOT NULL,
	[Number] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_IndustrySectorId] PRIMARY KEY CLUSTERED 
(
	[IndustrySectorId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_IndustrySectorNumber] UNIQUE NONCLUSTERED 
(
	[Number] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [instr].[IndustrySector_H])
)
GO
/****** Object:  Table [instr].[Instrument_H]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [instr].[Instrument_H](
	[InstrumentId] [int] NOT NULL,
	[InstrumentTypeId] [tinyint] NOT NULL,
	[Symbol] [nvarchar](30) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[CurrencyId] [tinyint] NOT NULL,
	[ExchangeId] [smallint] NULL,
	[ISIN] [nvarchar](12) NULL,
	[BbgGlobalId] [nvarchar](30) NULL,
	[BbgUniqueId] [nvarchar](30) NOT NULL,
	[CountryId] [smallint] NULL,
	[PrimaryMICId] [smallint] NULL,
	[MarketSectorId] [tinyint] NOT NULL,
	[IndustrySectorId] [int] NULL,
	[IndustryGroupId] [int] NULL,
	[SecurityTypeId] [tinyint] NULL,
	[SecurityType2Id] [tinyint] NULL,
	[PriceScalingFactor] [decimal](12, 6) NOT NULL,
	[QuoteCurrencyId] [tinyint] NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL,
	[QuoteFactor] [decimal](10, 4) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_Instrument_H]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_Instrument_H] ON [instr].[Instrument_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [instr].[Instrument]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [instr].[Instrument](
	[InstrumentId] [int] IDENTITY(1,1) NOT NULL,
	[InstrumentTypeId] [tinyint] NOT NULL,
	[Symbol] [nvarchar](30) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[CurrencyId] [tinyint] NOT NULL,
	[ExchangeId] [smallint] NULL,
	[ISIN] [nvarchar](12) NULL,
	[BbgGlobalId] [nvarchar](30) NULL,
	[BbgUniqueId] [nvarchar](30) NOT NULL,
	[CountryId] [smallint] NULL,
	[PrimaryMICId] [smallint] NULL,
	[MarketSectorId] [tinyint] NOT NULL,
	[IndustrySectorId] [int] NULL,
	[IndustryGroupId] [int] NULL,
	[SecurityTypeId] [tinyint] NULL,
	[SecurityType2Id] [tinyint] NULL,
	[PriceScalingFactor] [decimal](12, 6) NOT NULL,
	[QuoteCurrencyId] [tinyint] NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
	[QuoteFactor] [decimal](10, 4) NOT NULL,
 CONSTRAINT [PK_InstrumentId] PRIMARY KEY CLUSTERED 
(
	[InstrumentId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_BbgUniqueId] UNIQUE NONCLUSTERED 
(
	[BbgUniqueId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [instr].[Instrument_H])
)
GO
/****** Object:  Table [instr].[InstrumentType_H]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [instr].[InstrumentType_H](
	[InstrumentTypeId] [tinyint] NOT NULL,
	[Mnemonic] [nvarchar](10) NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_InstrumentType_H]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_InstrumentType_H] ON [instr].[InstrumentType_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [instr].[InstrumentType]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [instr].[InstrumentType](
	[InstrumentTypeId] [tinyint] IDENTITY(1,1) NOT NULL,
	[Mnemonic] [nvarchar](10) NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_InstrumentTypeId] PRIMARY KEY CLUSTERED 
(
	[InstrumentTypeId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_InstrumentType_Mnemonic] UNIQUE NONCLUSTERED 
(
	[Mnemonic] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [instr].[InstrumentType_H])
)
GO
/****** Object:  Table [instr].[SecurityType_H]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [instr].[SecurityType_H](
	[SecurityTypeId] [tinyint] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_SecurityType_H]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_SecurityType_H] ON [instr].[SecurityType_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [instr].[SecurityType]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [instr].[SecurityType](
	[SecurityTypeId] [tinyint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_SecurityTypeId] PRIMARY KEY CLUSTERED 
(
	[SecurityTypeId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_SecurityType] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [instr].[SecurityType_H])
)
GO
/****** Object:  Table [instr].[SecurityType2_H]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [instr].[SecurityType2_H](
	[SecurityType2Id] [tinyint] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_SecurityType2_H]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_SecurityType2_H] ON [instr].[SecurityType2_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [instr].[SecurityType2]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [instr].[SecurityType2](
	[SecurityType2Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_SecurityType2Id] PRIMARY KEY CLUSTERED 
(
	[SecurityType2Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_SecurityType2] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [instr].[SecurityType2_H])
)
GO
/****** Object:  Table [instr].[Country_H]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [instr].[Country_H](
	[CountryId] [smallint] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[IsoAlpha2Code] [char](2) NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_Country_H]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_Country_H] ON [instr].[Country_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [instr].[Country]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [instr].[Country](
	[CountryId] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[IsoAlpha2Code] [char](2) NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_CountryId] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_IsoAlpha2Code] UNIQUE NONCLUSTERED 
(
	[IsoAlpha2Code] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [instr].[Country_H])
)
GO
/****** Object:  Table [instr].[Currency_H]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [instr].[Currency_H](
	[CurrencyId] [tinyint] NOT NULL,
	[Code] [char](3) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_Currency_H]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_Currency_H] ON [instr].[Currency_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [instr].[Currency]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [instr].[Currency](
	[CurrencyId] [tinyint] IDENTITY(1,1) NOT NULL,
	[Code] [char](3) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_Currency] PRIMARY KEY CLUSTERED 
(
	[CurrencyId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_Currency_Code] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [instr].[Currency_H])
)
GO
/****** Object:  View [instr].[vwInstrument]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [instr].[vwInstrument] as
SELECT TOP (10000000)ins.[InstrumentId]
      ,ins.[InstrumentTypeId]
	  ,instype.Mnemonic as InstrumentType
      ,ins.[Symbol]
      ,ins.[Name]
      ,ins.[CurrencyId]
	  ,ccy.Code as Currency
      ,ins.[ExchangeId]
	  ,ex.Code as Exchange
      ,ins.[ISIN]
	  
      ,ins.[BbgGlobalId]
      ,ins.[BbgUniqueId]
      ,ins.[CountryId]
	  ,ctry.IsoAlpha2Code as Country
      ,ins.[PrimaryMICId]
	  ,mic.Code as PrimaryMIC
      ,ins.[MarketSectorId]
	  ,msec.Mnemonic as MarketSectorDes
      ,ins.[IndustrySectorId]
	  ,indsec.Name as IndustrySector
	  ,indgrp.Name as IndustryGroup
      ,ins.[IndustryGroupId]
      ,ins.[SecurityTypeId]
      ,ins.[SecurityType2Id]
      ,ins.[PriceScalingFactor]
      ,ins.[QuoteCurrencyId]
	  ,quoteccy.Code as QuoteCurrency
	  ,QuoteFactor
      ,ins.[ValidFrom]
      ,ins.[ValidTo]
  FROM [instr].[Instrument] ins
  JOIN instr.InstrumentType instype on instype.InstrumentTypeId = ins.InstrumentTypeId
  JOIN instr.[Currency] ccy on ccy.CurrencyId = ins.CurrencyId
  LEFT JOIN instr.[Exchange] ex on ex.ExchangeId = ins.ExchangeId
  LEFT JOIN instr.[Country] ctry on ctry.CountryId = ins.CountryId
  LEFT JOIN instr.[MIC] mic on mic.MICId = ins.PrimaryMICId
  JOIN instr.[MarketSector] msec on msec.MarketSectorId = ins.MarketSectorId
  LEFT JOIN instr.[IndustrySector] indsec on indsec.IndustrySectorId = ins.IndustrySectorId
  LEFT JOIN instr.[IndustryGroup] indgrp on indgrp.IndustryGroupId = ins.IndustryGroupId
  JOIN instr.[SecurityType] sectype on sectype.SecurityTypeId = ins.SecurityTypeId
  JOIN instr.[SecurityType2] sectype2 on sectype2.SecurityType2Id = ins.SecurityType2Id
  JOIN instr.[Currency] quoteccy on quoteccy.CurrencyId = ins.QuoteCurrencyId
  ORDER BY ins.[InstrumentId]
GO
/****** Object:  Table [trd].[FutureSwap]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trd].[FutureSwap](
	[GenericFutureId] [int] NOT NULL,
	[SettlementCurrency] [char](3) NULL
) ON [PRIMARY]
GO
/****** Object:  View [trd].[vwFutureSwap]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO































/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [trd].[vwFutureSwap] as
SELECT i.[GenericFutureId],
i.InstrumentId,
i.Symbol,
s.SettlementCurrency
  FROM [trd].[FutureSwap] s
  JOIN trd.Instrument i on i.GenericFutureId = s.GenericFutureId
GO
/****** Object:  UserDefinedFunction [trans].[ZZZ_tvTradesFileINNOCAPSW002]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE FUNCTION [trans].[ZZZ_tvTradesFileINNOCAPSW002] (@PortfolioId tinyint)
RETURNS TABLE
AS
RETURN
SELECT 
    'SW002' AS TrasationType,
    trd.TradeStatus AS TransactionStatus,
    trd.BuySellIndicator AS [Buy/Sell],
    CASE
        WHEN trd.BuySellIndicator = 'S' AND (alloc.PositionSide = 'L' OR alloc.PositionSide = 'C') THEN 'L'
        WHEN trd.BuySellIndicator = 'S' AND alloc.PositionSide = 'S' THEN 'S'
        WHEN trd.BuySellIndicator = 'B' AND alloc.PositionSide = 'L' THEN 'L'
        WHEN trd.BuySellIndicator = 'B' AND (alloc.PositionSide = 'S' OR alloc.PositionSide = 'C') THEN 'C'
    END AS [Long/Short],
    '' AS [PositionType],
    'A' AS [TransLevel],
    alloc.TradeAllocationId AS [ClientTradeRefNo],
    CONCAT(trd.TradeId,'A') AS [AssociatedTradeId],
    codes.ExecutionAccount AS [ExecutionAccount],
    codes.ClearingAccount AS [Account Id],
    trd.TradeDesk AS [Broker/Couterparty],
    IIF(trd.Sedol IS NULL OR TRIM(trd.Sedol) = '', 'B','S') AS [SecurityIdentifierType],
    IIF(trd.Sedol IS NULL OR TRIM(trd.Sedol) = '',ins.Symbol, trd.Sedol) AS [SecurityIdentifier],
    ins.Name as SecurityDescription,
    FORMAT(trd.TradeDate, 'MM/dd/yyyy') AS TradeDate,  -- FORMAT(trd.TradeDate, 'MM/dd/yyyy') AS TradeDate,
    FORMAT(trd.fnAddBusinessDays(trd.TradeDate,1), 'MM/dd/yyyy') AS SettlementDate, -- TGU 3 to 2
    ISNULL(fs.SettlementCurrency, ISNULL(trd.SettlementCurrency, trd.TradeCurrency)) AS SettlementCurrency,
    '' AS [ExchangeCode],
    ABS(alloc.Quantity) AS [Quantity],
    alloc.Price AS Price,
    'G' AS PriceIndicator,
    CAST(ABS(trd.Principal) AS DECIMAL(24,2)) AS Principal,
    CAST(trd.BrokerCommission AS DECIMAL(24,2)) AS [BrokerCommission],
    'F' AS [BrokerCommissionInd],
    trd.MiscFees AS [MSFees],
    '' AS [NotRequired],
    'F' AS [MSFeesInd],
    '' AS [DivEntitlPercent],
    '' AS Spread,
    CASE 
        WHEN trd.BuySellIndicator = 'S' THEN  CAST(ABS(trd.Principal)-ABS(trd.BrokerCommission) AS DECIMAL(24,2)) 
        WHEN trd.BuySellIndicator = 'B' THEN CAST(ABS(trd.Principal)+ABS(trd.BrokerCommission)AS DECIMAL(24,2))   
    END AS NetAmount,
    'Y' AS [HearsayInd],
    codes.Custodian AS [Custodian],
    '' AS [MoneyManager],
    '' AS [BookId],
    '' AS [DealId],
    '' AS [TaxLotId],
    '' AS [TaxDate],
    '' AS [TaxPrice],
    '' AS [CloseOutMethod],
    '' AS [FxRate],
    '' AS [AcquisitionDate],
    '' AS [Comments],
    '' AS [SwapReferenceNo],
    '' AS [BasketId],
    '' AS [PriceCurrency],
    '' AS [ResetIndicator],
    '' AS [SnSReference],
    '' AS [ResearchFee],
    '' AS [ResearchFeeInd],
    '' AS [LEI],
    '' AS [MaturityDate],
    'Equity Vanilla Swaps' AS [ProductType],
    '' AS [Fuut/Part Unwind Ind],
    '' AS [PaymentDate],
    '' AS [DividendAmount],
    '' AS [DividendPayoutDate],
    '' AS [NextResetDate],
    '' AS [ResetPrice],
    '' AS [EquitySpread],
    '' AS [DaycountConvention],
    '' AS [FloatingRate],
    '' AS [RollConvention],
    '' AS [CollateralPledge],
    '' AS [FixingFrequency],
    '' AS [PaymentFrequency]
FROM 
    [trans].[Trade] trd
JOIN 
    [trans].[TradeAllocation] alloc ON alloc.TradeId = trd.TradeId
JOIN 
    [trans].Instrument ins ON ins.InstrumentId = trd.InstrumentId
LEFT JOIN 
    trans.[vwLastFileTransmission] ft ON ft.TransmissionType = 'INNOCAPTRD'
LEFT JOIN 
	trans.CounterpartyCodeMapping codes ON codes.PortfolioId = alloc.PortfolioId and  codes.FileGenerationType = 'INNOCAPSW'
LEFT JOIN trd.vwFutureSwap fs on fs.InstrumentId = trd.InstrumentId
WHERE 
    ((ins.InstrumentType = 'EQU' AND trd.IsCfd = 1) 
     OR trd.IsFutureSwap = 1)

	AND (ft.TransmittedOn IS NULL OR ft.TransmittedOn < trd.BookedOn)
	AND alloc.PortfolioId = @PortfolioId;
GO
/****** Object:  Table [trans].[H_FileContentType]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[H_FileContentType](
	[FileContentTypeId] [tinyint] NOT NULL,
	[Mnemonic] [nvarchar](5) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[ValidFrom] [datetime2](7) NOT NULL,
	[ValidTo] [datetime2](7) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_H_FileContentType]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_H_FileContentType] ON [trans].[H_FileContentType]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [trans].[FileContentType]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[FileContentType](
	[FileContentTypeId] [tinyint] NOT NULL,
	[Mnemonic] [nvarchar](5) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[ValidFrom] [datetime2](7) GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
	[ValidTo] [datetime2](7) GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
 CONSTRAINT [PK_FileContentType] PRIMARY KEY CLUSTERED 
(
	[FileContentTypeId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [trans].[H_FileContentType])
)
GO
/****** Object:  Table [book].[H_TradeAllocation]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [book].[H_TradeAllocation](
	[TradeAllocationId] [int] NOT NULL,
	[TradeId] [int] NOT NULL,
	[TradeStatus] [char](3) NOT NULL,
	[PortfolioId] [tinyint] NOT NULL,
	[PositionSide] [char](1) NOT NULL,
	[Quantity] [int] NOT NULL,
	[NominalQuantity] [decimal](18, 6) NOT NULL,
	[OrderAllocationQuantity] [int] NOT NULL,
	[OrderAllocationNominalQuantity] [decimal](18, 6) NOT NULL,
	[ContractMultiplier] [decimal](18, 6) NOT NULL,
	[LocalCurrency] [char](3) NOT NULL,
	[BaseCurrency] [char](3) NOT NULL,
	[SettlementCurrency] [char](3) NOT NULL,
	[CommissionValue] [decimal](12, 6) NOT NULL,
	[CommissionType] [char](1) NOT NULL,
	[GrossAvgPriceLocal] [decimal](18, 6) NOT NULL,
	[PriceCommissionLocal] [decimal](18, 6) NOT NULL,
	[NetAvgPriceLocal] [decimal](18, 6) NOT NULL,
	[GrossAvgPriceBase] [decimal](18, 6) NOT NULL,
	[PriceCommissionBase] [decimal](18, 6) NOT NULL,
	[NetAvgPriceBase] [decimal](18, 8) NOT NULL,
	[GrossAvgPriceSettle] [decimal](18, 6) NULL,
	[PriceCommissionSettle] [decimal](18, 6) NULL,
	[NetAvgPriceSettle] [decimal](18, 6) NULL,
	[CommissionAmountLocal] [decimal](18, 6) NOT NULL,
	[CommissionAmountBase] [decimal](18, 6) NOT NULL,
	[CommissionAmountSettle] [decimal](18, 6) NULL,
	[MiscFeesLocal] [decimal](18, 6) NOT NULL,
	[MiscFeesBase] [decimal](18, 6) NOT NULL,
	[MiscFeesSettle] [decimal](18, 6) NOT NULL,
	[GrossTradeValueLocal] [decimal](20, 2) NOT NULL,
	[NetTradeValueLocal] [decimal](20, 2) NOT NULL,
	[GrossTradeValueBase] [decimal](20, 2) NOT NULL,
	[NetTradeValueBase] [decimal](20, 2) NOT NULL,
	[GrossTradeValueSettle] [decimal](20, 2) NOT NULL,
	[NetTradeValueSettle] [decimal](20, 2) NULL,
	[GrossPrincipalLocal] [decimal](20, 2) NOT NULL,
	[NetPrincipalLocal] [decimal](20, 2) NOT NULL,
	[GrossPrincipalBase] [decimal](20, 2) NOT NULL,
	[NetPrincipalBase] [decimal](20, 2) NOT NULL,
	[GrossPrincipalSettle] [decimal](20, 2) NOT NULL,
	[NetPrincipalSettle] [decimal](20, 2) NOT NULL,
	[SettlementDate] [date] NOT NULL,
	[LocalToBaseFxRate] [decimal](18, 6) NOT NULL,
	[LocalToSettleFxRate] [decimal](18, 6) NOT NULL,
	[PrimeBroker] [nvarchar](6) NULL,
	[ClearingBroker] [nvarchar](6) NOT NULL,
	[ClearingAccount] [nvarchar](20) NOT NULL,
	[Custodian] [nvarchar](6) NULL,
	[LastCorrectedOnUtc] [datetime2](7) NULL,
	[CanceledOnUtc] [datetime2](7) NULL,
	[ValidFrom] [datetime2](7) NOT NULL,
	[ValidTo] [datetime2](7) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_H_TradeAllocation]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_H_TradeAllocation] ON [book].[H_TradeAllocation]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [book].[TradeAllocation]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [book].[TradeAllocation](
	[TradeAllocationId] [int] NOT NULL,
	[TradeId] [int] NOT NULL,
	[TradeStatus] [char](3) NOT NULL,
	[PortfolioId] [tinyint] NOT NULL,
	[PositionSide] [char](1) NOT NULL,
	[Quantity] [int] NOT NULL,
	[NominalQuantity] [decimal](18, 6) NOT NULL,
	[OrderAllocationQuantity] [int] NOT NULL,
	[OrderAllocationNominalQuantity] [decimal](18, 6) NOT NULL,
	[ContractMultiplier] [decimal](18, 6) NOT NULL,
	[LocalCurrency] [char](3) NOT NULL,
	[BaseCurrency] [char](3) NOT NULL,
	[SettlementCurrency] [char](3) NOT NULL,
	[CommissionValue] [decimal](12, 6) NOT NULL,
	[CommissionType] [char](1) NOT NULL,
	[GrossAvgPriceLocal] [decimal](18, 6) NOT NULL,
	[PriceCommissionLocal] [decimal](18, 6) NOT NULL,
	[NetAvgPriceLocal] [decimal](18, 6) NOT NULL,
	[GrossAvgPriceBase] [decimal](18, 6) NOT NULL,
	[PriceCommissionBase] [decimal](18, 6) NOT NULL,
	[NetAvgPriceBase] [decimal](18, 8) NOT NULL,
	[GrossAvgPriceSettle] [decimal](18, 6) NULL,
	[PriceCommissionSettle] [decimal](18, 6) NULL,
	[NetAvgPriceSettle] [decimal](18, 6) NULL,
	[CommissionAmountLocal] [decimal](18, 6) NOT NULL,
	[CommissionAmountBase] [decimal](18, 6) NOT NULL,
	[CommissionAmountSettle] [decimal](18, 6) NULL,
	[MiscFeesLocal] [decimal](18, 6) NOT NULL,
	[MiscFeesBase] [decimal](18, 6) NOT NULL,
	[MiscFeesSettle] [decimal](18, 6) NOT NULL,
	[GrossTradeValueLocal] [decimal](20, 2) NOT NULL,
	[NetTradeValueLocal] [decimal](20, 2) NOT NULL,
	[GrossTradeValueBase] [decimal](20, 2) NOT NULL,
	[NetTradeValueBase] [decimal](20, 2) NOT NULL,
	[GrossTradeValueSettle] [decimal](20, 2) NOT NULL,
	[NetTradeValueSettle] [decimal](20, 2) NULL,
	[GrossPrincipalLocal] [decimal](20, 2) NOT NULL,
	[NetPrincipalLocal] [decimal](20, 2) NOT NULL,
	[GrossPrincipalBase] [decimal](20, 2) NOT NULL,
	[NetPrincipalBase] [decimal](20, 2) NOT NULL,
	[GrossPrincipalSettle] [decimal](20, 2) NOT NULL,
	[NetPrincipalSettle] [decimal](20, 2) NOT NULL,
	[SettlementDate] [date] NOT NULL,
	[LocalToBaseFxRate] [decimal](18, 6) NOT NULL,
	[LocalToSettleFxRate] [decimal](18, 6) NOT NULL,
	[PrimeBroker] [nvarchar](6) NULL,
	[ClearingBroker] [nvarchar](6) NOT NULL,
	[ClearingAccount] [nvarchar](20) NOT NULL,
	[Custodian] [nvarchar](6) NULL,
	[LastCorrectedOnUtc] [datetime2](7) NULL,
	[CanceledOnUtc] [datetime2](7) NULL,
	[ValidFrom] [datetime2](7) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](7) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_TradeAllocation] PRIMARY KEY CLUSTERED 
(
	[TradeAllocationId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_TradeAllocation] UNIQUE NONCLUSTERED 
(
	[TradeId] ASC,
	[PortfolioId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [book].[H_TradeAllocation])
)
GO
/****** Object:  Table [book].[H_Trade]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [book].[H_Trade](
	[TradeId] [int] NOT NULL,
	[TradeStatus] [char](3) NOT NULL,
	[InstrumentId] [int] NOT NULL,
	[Symbol] [nvarchar](30) NOT NULL,
	[TradeSide] [nvarchar](10) NOT NULL,
	[TradeQuantity] [int] NOT NULL,
	[NominalQuantity] [decimal](18, 6) NOT NULL,
	[TradeCurrency] [char](3) NOT NULL,
	[TradeDate] [date] NOT NULL,
	[Exchange] [nvarchar](5) NULL,
	[ExecutionChannel] [nvarchar](10) NOT NULL,
	[ExecutionType] [nvarchar](5) NOT NULL,
	[IsSwap] [bit] NOT NULL,
	[RebalancingId] [int] NULL,
	[ContractMultiplier] [decimal](18, 6) NOT NULL,
	[PriceScalingFactor] [decimal](12, 6) NOT NULL,
	[AvgPrice] [decimal](18, 6) NOT NULL,
	[Principal] [decimal](20, 2) NOT NULL,
	[TradeValue] [decimal](20, 2) NOT NULL,
	[InstrumentType] [nvarchar](8) NOT NULL,
	[TradeInstrumentType] [nvarchar](8) NOT NULL,
	[ExecutionDesk] [nvarchar](6) NOT NULL,
	[ExecutionBroker] [nvarchar](5) NOT NULL,
	[ExecutionAccount] [nvarchar](20) NOT NULL,
	[Isin] [nvarchar](12) NULL,
	[Sedol] [nvarchar](20) NULL,
	[Cusip] [nvarchar](10) NULL,
	[SecurityName] [nvarchar](100) NULL,
	[LocalExchangeSymbol] [nvarchar](20) NULL,
	[SettlementDate] [date] NULL,
	[EmsxOrderId] [int] NULL,
	[OrderReferenceId] [int] NULL,
	[OrderQuantity] [int] NULL,
	[OrderType] [nvarchar](20) NULL,
	[StrategyType] [nvarchar](10) NULL,
	[TimeInForce] [nvarchar](10) NULL,
	[OrderExecutionInstruction] [nvarchar](100) NULL,
	[OrderHandlingInstruction] [nvarchar](100) NULL,
	[OrderInstruction] [nvarchar](100) NULL,
	[LimitPrice] [decimal](18, 6) NULL,
	[StopPrice] [decimal](18, 6) NULL,
	[OriginatingTraderUUId] [int] NULL,
	[TraderName] [nvarchar](20) NULL,
	[TraderUUId] [int] NULL,
	[UserCommissionAmount] [decimal](18, 6) NULL,
	[UserCommissionRate] [decimal](18, 6) NULL,
	[UserFees] [decimal](18, 6) NULL,
	[UserNetMoney] [decimal](18, 6) NULL,
	[YellowKey] [nvarchar](10) NULL,
	[NumberOfFills] [tinyint] NULL,
	[FirstFillTimeUtc] [datetime] NULL,
	[LastFillTimeUtc] [datetime] NULL,
	[MaxFillPrice] [decimal](18, 6) NULL,
	[MinFillPrice] [decimal](18, 6) NULL,
	[BookedOnUtc] [datetime2](7) NOT NULL,
	[LastCorrectedOnUtc] [datetime2](7) NULL,
	[CanceledOnUtc] [datetime2](7) NULL,
	[ValidFrom] [datetime2](7) NOT NULL,
	[ValidTo] [datetime2](7) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_H_Trade]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_H_Trade] ON [book].[H_Trade]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [book].[Trade]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [book].[Trade](
	[TradeId] [int] NOT NULL,
	[TradeStatus] [char](3) NOT NULL,
	[InstrumentId] [int] NOT NULL,
	[Symbol] [nvarchar](30) NOT NULL,
	[TradeSide] [nvarchar](10) NOT NULL,
	[TradeQuantity] [int] NOT NULL,
	[NominalQuantity] [decimal](18, 6) NOT NULL,
	[TradeCurrency] [char](3) NOT NULL,
	[TradeDate] [date] NOT NULL,
	[Exchange] [nvarchar](5) NULL,
	[ExecutionChannel] [nvarchar](10) NOT NULL,
	[ExecutionType] [nvarchar](5) NOT NULL,
	[IsSwap] [bit] NOT NULL,
	[RebalancingId] [int] NULL,
	[ContractMultiplier] [decimal](18, 6) NOT NULL,
	[PriceScalingFactor] [decimal](12, 6) NOT NULL,
	[AvgPrice] [decimal](18, 6) NOT NULL,
	[Principal] [decimal](20, 2) NOT NULL,
	[TradeValue] [decimal](20, 2) NOT NULL,
	[InstrumentType] [nvarchar](8) NOT NULL,
	[TradeInstrumentType] [nvarchar](8) NOT NULL,
	[ExecutionDesk] [nvarchar](6) NOT NULL,
	[ExecutionBroker] [nvarchar](5) NOT NULL,
	[ExecutionAccount] [nvarchar](20) NOT NULL,
	[Isin] [nvarchar](12) NULL,
	[Sedol] [nvarchar](20) NULL,
	[Cusip] [nvarchar](10) NULL,
	[SecurityName] [nvarchar](100) NULL,
	[LocalExchangeSymbol] [nvarchar](20) NULL,
	[SettlementDate] [date] NULL,
	[EmsxOrderId] [int] NULL,
	[OrderReferenceId] [int] NULL,
	[OrderQuantity] [int] NULL,
	[OrderType] [nvarchar](20) NULL,
	[StrategyType] [nvarchar](10) NULL,
	[TimeInForce] [nvarchar](10) NULL,
	[OrderExecutionInstruction] [nvarchar](100) NULL,
	[OrderHandlingInstruction] [nvarchar](100) NULL,
	[OrderInstruction] [nvarchar](100) NULL,
	[LimitPrice] [decimal](18, 6) NULL,
	[StopPrice] [decimal](18, 6) NULL,
	[OriginatingTraderUUId] [int] NULL,
	[TraderName] [nvarchar](20) NULL,
	[TraderUUId] [int] NULL,
	[UserCommissionAmount] [decimal](18, 6) NULL,
	[UserCommissionRate] [decimal](18, 6) NULL,
	[UserFees] [decimal](18, 6) NULL,
	[UserNetMoney] [decimal](18, 6) NULL,
	[YellowKey] [nvarchar](10) NULL,
	[NumberOfFills] [tinyint] NULL,
	[FirstFillTimeUtc] [datetime] NULL,
	[LastFillTimeUtc] [datetime] NULL,
	[MaxFillPrice] [decimal](18, 6) NULL,
	[MinFillPrice] [decimal](18, 6) NULL,
	[BookedOnUtc] [datetime2](7) NOT NULL,
	[LastCorrectedOnUtc] [datetime2](7) NULL,
	[CanceledOnUtc] [datetime2](7) NULL,
	[ValidFrom] [datetime2](7) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](7) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_Trade] PRIMARY KEY CLUSTERED 
(
	[TradeId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [book].[H_Trade])
)
GO
/****** Object:  View [book].[vwTradeAllocation]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


















/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [book].[vwTradeAllocation] as
SELECT  [TradeAllocationId]
      ,alloc.[TradeStatus]
      ,alloc.[TradeId]
	  ,[InstrumentId]
      ,[Symbol]
      ,[TradeSide]
      ,[TradeQuantity]
	  ,InstrumentType
      ,[TradeCurrency]
      ,[TradeDate]
      ,[Exchange]
      ,[ExecutionChannel]
      ,[ExecutionType]
      ,[IsSwap]
      ,[RebalancingId]
	  ,PriceScalingFactor
      ,[AvgPrice] as TradeAvgPrice
      ,[Principal] as TradePrincipal
      ,[TradeValue]
      ,[TradeInstrumentType]
      ,[ExecutionDesk]
      ,[ExecutionBroker]
      ,[ExecutionAccount]
      ,[Isin]
      ,[Sedol]
      ,[Cusip]
      ,[SecurityName]
      ,[LocalExchangeSymbol]

      ,[EmsxOrderId]
      ,[OrderReferenceId]
      ,[OrderQuantity]
      ,[OrderType]
      ,[StrategyType]
      ,[TimeInForce]
      ,[OrderExecutionInstruction]
      ,[OrderHandlingInstruction]
      ,[OrderInstruction]
      ,[LimitPrice]
      ,[StopPrice]
      ,[OriginatingTraderUUId]
      ,[TraderName]
      ,[TraderUUId]
      ,[UserCommissionAmount]
      ,[UserCommissionRate]
      ,[UserFees]
      ,[UserNetMoney]
      ,[YellowKey]
      ,[NumberOfFills]
      ,[FirstFillTimeUtc]
      ,[LastFillTimeUtc]

      ,[MaxFillPrice]
      ,[MinFillPrice]
	  ,BookedOnUtc
      ,alloc.[PortfolioId]
      ,alloc.[PositionSide]
      ,alloc.[Quantity]
	  ,alloc.OrderAllocationQuantity
	  ,alloc.OrderAllocationNominalQuantity
      ,alloc.[ContractMultiplier]
      ,alloc.[NominalQuantity]
      ,alloc.[LocalCurrency]
      ,alloc.[BaseCurrency]
      ,alloc.[SettlementCurrency]
      ,alloc.[CommissionValue]
      ,alloc.[CommissionType]
      ,alloc.[GrossAvgPriceLocal]
      ,alloc.[PriceCommissionLocal]
      ,alloc.[NetAvgPriceLocal]
      ,alloc.[GrossAvgPriceBase]
      ,alloc.[PriceCommissionBase]
      ,alloc.[NetAvgPriceBase]
      ,alloc.[GrossAvgPriceSettle]
      ,alloc.[PriceCommissionSettle]
      ,alloc.[NetAvgPriceSettle]
      ,alloc.[CommissionAmountLocal]
      ,alloc.[CommissionAmountBase]
      ,alloc.[CommissionAmountSettle]
	  ,alloc.MiscFeesLocal
	  ,alloc.MiscFeesBase
	  ,alloc.MiscFeesSettle
      ,alloc.[GrossTradeValueLocal]
      ,alloc.[NetTradeValueLocal]
      ,alloc.[GrossTradeValueBase]
      ,alloc.[NetTradeValueBase]
      ,alloc.[GrossTradeValueSettle]
      ,alloc.[NetTradeValueSettle]
      ,alloc.[GrossPrincipalLocal]
      ,alloc.[NetPrincipalLocal]
      ,alloc.[GrossPrincipalBase]
      ,alloc.[NetPrincipalBase]
      ,alloc.[GrossPrincipalSettle]
      ,alloc.[NetPrincipalSettle]
      ,alloc.[SettlementDate]
      ,alloc.[LocalToBaseFxRate]
      ,alloc.[LocalToSettleFxRate]
      ,alloc.[PrimeBroker]
      ,alloc.[CLearingBroker]
      ,alloc.[ClearingAccount]
      ,alloc.[Custodian]

      ,alloc.[LastCorrectedOnUtc]
      ,alloc.[CanceledOnUtc]
    
  FROM [book].[TradeAllocation] alloc
  LEFT JOIN [book].Trade trd on trd.TradeId = alloc.TradeId
GO
/****** Object:  UserDefinedFunction [trans].[ZZZ_tvTradesFileINNOCAPTR001]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE FUNCTION [trans].[ZZZ_tvTradesFileINNOCAPTR001] (@PortfolioId tinyint)
RETURNS TABLE
AS
RETURN
SELECT 
    'TR001' AS TrasactionType,
    trd.TradeStatus AS TransactionStatus,
    trd.BuySellIndicator AS [Buy/Sell],
    CASE 
        WHEN trd.BuySellIndicator='S' AND (alloc.PositionSide ='L' OR  alloc.PositionSide ='C') THEN 'L'
        WHEN trd.BuySellIndicator='S' AND alloc.PositionSide ='S' THEN 'S'
        WHEN trd.BuySellIndicator='B' AND alloc.PositionSide ='L' THEN 'L'
        WHEN trd.BuySellIndicator='B' AND (alloc.PositionSide ='S' OR  alloc.PositionSide ='C') THEN 'C' 
    END AS [Long/Short],
    '' AS [PositionType],
    'A' AS [TransLevel],
    alloc.TradeAllocationId AS [ClientRef#],
    CONCAT(trd.TradeId,'A') AS [Associated#],
    codes.ExecutionAccount AS [ExecAccount],
    codes.ClearingAccount AS [AccountId],
    trd.TradeDesk AS [ExecutionBroker],
    'B' AS [SecType],
    ins.Symbol AS [SecID],
    ins.[Name] as SecurityDescription,
    FORMAT(trd.TradeDate, 'MM/dd/yyyy') AS TradeDate,
    FORMAT(trd.fnAddBusinessDays(trd.TradeDate,1), 'MM/dd/yyyy') AS SettlementDate,
    ISNULL( trd.SettlementCurrency, trd.TradeCurrency) AS SettlementCurrency,
    '' AS ExchangeCode,
    ABS(alloc.Quantity) AS [Quantity],
	  CASE WHEN LEFT(ins.Symbol, 2)= 'JY' AND RIGHT(ins.Symbol, 6) = 'Curncy' THEN alloc.Price/100
	  WHEN LEFT(ins.Symbol, 2)= 'NO' AND RIGHT(ins.Symbol, 6) = 'Curncy' THEN alloc.Price/100
	  WHEN LEFT(ins.Symbol, 2)= 'SE' AND RIGHT(ins.Symbol, 6) = 'Curncy' THEN alloc.Price/100
	  WHEN LEFT(ins.Symbol, 2)= 'RA' AND RIGHT(ins.Symbol, 6) = 'Curncy' THEN alloc.Price/100
	 ELSE alloc.Price END AS PriceAmount,
    'G' AS PriceIndicator,
    CAST(ABS(trd.Principal) AS DECIMAL(24,2)) AS Principal,
    CAST(ABS(trd.BrokerCommission) AS DECIMAL(24,2)) AS CommissionAmount,
    'F' AS CommissionIndicator,
    ABS(ISNULL(trd.MiscFees,0)) AS [Tax/Fees],
    '' AS [Tax2],
    'F' AS [FeeInd],
    '' AS [Interest],
    '' AS [InterestIndicator],
    CASE 
        WHEN trd.BuySellIndicator = 'S' THEN CAST(ABS(trd.Principal)- ABS(trd.BrokerCommission) AS DECIMAL(24,2))
        WHEN trd.BuySellIndicator = 'B' THEN CAST(ABS(trd.Principal)+ ABS(trd.BrokerCommission) AS DECIMAL(24,2))
    END AS NetAmount,
    'Y' AS [HearsayInd],
    codes.Custodian AS [Custodian],
    '' AS [MoneyManager],
    '' AS [BookId],
    '' AS [DealId],
    '' AS [TaxLotId],
    '' AS [TaxDate],
    '' AS [TaxPrice],
    '' AS [CloseOutMethod],
    '' AS [ExRate],
    '' AS [AcqDate],
    '' AS [Comments]
FROM  
    [trans].[Trade] trd
JOIN 
    [trans].[TradeAllocation] alloc ON alloc.TradeId = trd.TradeId
JOIN 
    [trans].Instrument ins ON ins.InstrumentId = trd.InstrumentId
LEFT JOIN 
	trans.CounterpartyCodeMapping codes ON codes.PortfolioId = alloc.PortfolioId and  codes.FileGenerationType = 'INNOCAPTR'
LEFT JOIN 
    trans.[vwLastFileTransmission] ft ON ft.TransmissionType = 'INNOCAPTRD'
WHERE 
    ins.InstrumentType = 'FUT'
  --  AND trd.TradeDate = CAST(GETDATE() AS DATE) 
    AND trd.IsFutureSwap = 0
    AND (ft.TransmittedOn IS NULL OR ft.TransmittedOn < trd.BookedOn)
	AND alloc.PortfolioId = @PortfolioId;
GO
/****** Object:  Table [ord].[InstrumentType]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[InstrumentType](
	[InstrumentTypeId] [tinyint] NOT NULL,
	[Mnemonic] [nvarchar](10) NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_InstrumentTypeId] PRIMARY KEY CLUSTERED 
(
	[InstrumentTypeId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_InstrumentType_Mnemonic] UNIQUE NONCLUSTERED 
(
	[Mnemonic] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ord].[TradeMode]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[TradeMode](
	[TradeModeId] [tinyint] IDENTITY(1,1) NOT NULL,
	[Mnemonic] [nvarchar](10) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_TradeMode] PRIMARY KEY CLUSTERED 
(
	[TradeModeId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
GO
/****** Object:  Table [ord].[Instrument]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[Instrument](
	[InstrumentId] [int] NOT NULL,
	[InstrumentTypeId] [tinyint] NOT NULL,
	[Symbol] [nvarchar](30) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Currency] [char](3) NOT NULL,
	[Exchange] [nvarchar](5) NULL,
	[MarketSector] [nvarchar](6) NOT NULL,
	[ExchangeId] [smallint] NULL,
	[Maturity] [date] NULL,
	[GenericFutureId] [int] NULL,
 CONSTRAINT [PK_InstrumentId] PRIMARY KEY CLUSTERED 
(
	[InstrumentId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ord].[OrderType_H]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[OrderType_H](
	[OrderTypeId] [int] NOT NULL,
	[Mnemonic] [nvarchar](10) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_OrderType_H]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_OrderType_H] ON [ord].[OrderType_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [ord].[OrderType]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[OrderType](
	[OrderTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Mnemonic] [nvarchar](10) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_OrderType] PRIMARY KEY CLUSTERED 
(
	[OrderTypeId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [ord].[OrderType_H])
)
GO
/****** Object:  Table [ord].[ExecutionAlgorithm_H]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[ExecutionAlgorithm_H](
	[ExecutionAlgorithmId] [int] NOT NULL,
	[Mnmemonic] [nvarchar](10) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_ExecutionAlgorithm_H]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_ExecutionAlgorithm_H] ON [ord].[ExecutionAlgorithm_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [ord].[ExecutionAlgorithm]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[ExecutionAlgorithm](
	[ExecutionAlgorithmId] [int] IDENTITY(1,1) NOT NULL,
	[Mnmemonic] [nvarchar](10) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_ExecutionAlgorithm] PRIMARY KEY CLUSTERED 
(
	[ExecutionAlgorithmId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [ord].[ExecutionAlgorithm_H])
)
GO
/****** Object:  Table [ord].[ExecutionChannel_H]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[ExecutionChannel_H](
	[ExecutionChannelId] [tinyint] NOT NULL,
	[Mnemonic] [nvarchar](10) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_ExecutionChannel_H]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_ExecutionChannel_H] ON [ord].[ExecutionChannel_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [ord].[ExecutionChannel]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[ExecutionChannel](
	[ExecutionChannelId] [tinyint] IDENTITY(1,1) NOT NULL,
	[Mnemonic] [nvarchar](10) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_ExecutionChannel] PRIMARY KEY CLUSTERED 
(
	[ExecutionChannelId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [ord].[ExecutionChannel_H])
)
GO
/****** Object:  Table [ord].[HandlingInstruction_H]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[HandlingInstruction_H](
	[HandlingInstructionId] [int] NOT NULL,
	[Code] [nvarchar](10) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_HandlingInstruction_H]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_HandlingInstruction_H] ON [ord].[HandlingInstruction_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [ord].[HandlingInstruction]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[HandlingInstruction](
	[HandlingInstructionId] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](10) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_HandlingInstruction] PRIMARY KEY CLUSTERED 
(
	[HandlingInstructionId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [ord].[HandlingInstruction_H])
)
GO
/****** Object:  Table [ord].[OrderSide_H]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[OrderSide_H](
	[OrderSideId] [tinyint] NOT NULL,
	[Mnemonic] [nvarchar](2) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_OrderSide_H]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_OrderSide_H] ON [ord].[OrderSide_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [ord].[OrderSide]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[OrderSide](
	[OrderSideId] [tinyint] IDENTITY(1,1) NOT NULL,
	[Mnemonic] [nvarchar](2) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_OrderSide] PRIMARY KEY CLUSTERED 
(
	[OrderSideId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [ord].[OrderSide_H])
)
GO
/****** Object:  Table [ord].[TimeInForce_H]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[TimeInForce_H](
	[TimeInForceId] [tinyint] NOT NULL,
	[Mnemonic] [nvarchar](10) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_TimeInForce_H]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_TimeInForce_H] ON [ord].[TimeInForce_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [ord].[TimeInForce]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[TimeInForce](
	[TimeInForceId] [tinyint] IDENTITY(1,1) NOT NULL,
	[Mnemonic] [nvarchar](10) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_TimeInForce] PRIMARY KEY CLUSTERED 
(
	[TimeInForceId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [ord].[TimeInForce_H])
)
GO
/****** Object:  Table [ord].[TradingDesk_H]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[TradingDesk_H](
	[TradingDeskId] [int] NOT NULL,
	[BrokerId] [int] NOT NULL,
	[Code] [nvarchar](10) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_TradingDesk_H]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_TradingDesk_H] ON [ord].[TradingDesk_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [ord].[TradingDesk]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[TradingDesk](
	[TradingDeskId] [int] IDENTITY(1,1) NOT NULL,
	[BrokerId] [int] NOT NULL,
	[Code] [nvarchar](10) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_TradingDesk] PRIMARY KEY CLUSTERED 
(
	[TradingDeskId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [ord].[TradingDesk_H])
)
GO
/****** Object:  Table [ord].[Broker_H]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[Broker_H](
	[BrokerId] [int] NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Code] [nvarchar](10) NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_Broker_H]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_Broker_H] ON [ord].[Broker_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [ord].[Broker]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[Broker](
	[BrokerId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Code] [nvarchar](10) NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_Broker] PRIMARY KEY CLUSTERED 
(
	[BrokerId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [ord].[Broker_H])
)
GO
/****** Object:  Table [ord].[H_Order]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[H_Order](
	[OrderId] [int] NOT NULL,
	[RebalancingSessionId] [int] NULL,
	[InstrumentId] [int] NOT NULL,
	[OrderSideId] [tinyint] NOT NULL,
	[Quantity] [int] NOT NULL,
	[BrokerId] [int] NOT NULL,
	[OrderTypeId] [int] NOT NULL,
	[TimeInForceId] [tinyint] NOT NULL,
	[ExecutionAlgorithmId] [int] NOT NULL,
	[HandlingInstructionId] [int] NOT NULL,
	[ExecutionChannelId] [tinyint] NOT NULL,
	[TradeModeId] [tinyint] NOT NULL,
	[TradeDate] [date] NOT NULL,
	[TradingDeskId] [int] NOT NULL,
	[CreatedOn] [datetime] NULL,
	[Param1] [nvarchar](30) NULL,
	[Value1] [nvarchar](30) NULL,
	[Param2] [nvarchar](30) NULL,
	[Value2] [nvarchar](30) NULL,
	[Param3] [nvarchar](30) NULL,
	[Value3] [nvarchar](30) NULL,
	[Param4] [nvarchar](30) NULL,
	[Value4] [nvarchar](30) NULL,
	[Param5] [nvarchar](30) NULL,
	[Value5] [nvarchar](30) NULL,
	[Param6] [nvarchar](30) NULL,
	[Value6] [nvarchar](30) NULL,
	[Param7] [nvarchar](30) NULL,
	[Value7] [nvarchar](30) NULL,
	[Param8] [nvarchar](30) NULL,
	[Value8] [nvarchar](30) NULL,
	[OrderRef] [nvarchar](30) NULL,
	[OrderReason] [nvarchar](10) NOT NULL,
	[ValidFrom] [datetime2](7) NOT NULL,
	[ValidTo] [datetime2](7) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_H_Order]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_H_Order] ON [ord].[H_Order]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [ord].[Order]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[Order](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[RebalancingSessionId] [int] NULL,
	[InstrumentId] [int] NOT NULL,
	[OrderSideId] [tinyint] NOT NULL,
	[Quantity] [int] NOT NULL,
	[BrokerId] [int] NOT NULL,
	[OrderTypeId] [int] NOT NULL,
	[TimeInForceId] [tinyint] NOT NULL,
	[ExecutionAlgorithmId] [int] NOT NULL,
	[HandlingInstructionId] [int] NOT NULL,
	[ExecutionChannelId] [tinyint] NOT NULL,
	[TradeModeId] [tinyint] NOT NULL,
	[TradeDate] [date] NOT NULL,
	[TradingDeskId] [int] NOT NULL,
	[CreatedOn] [datetime] NULL,
	[Param1] [nvarchar](30) NULL,
	[Value1] [nvarchar](30) NULL,
	[Param2] [nvarchar](30) NULL,
	[Value2] [nvarchar](30) NULL,
	[Param3] [nvarchar](30) NULL,
	[Value3] [nvarchar](30) NULL,
	[Param4] [nvarchar](30) NULL,
	[Value4] [nvarchar](30) NULL,
	[Param5] [nvarchar](30) NULL,
	[Value5] [nvarchar](30) NULL,
	[Param6] [nvarchar](30) NULL,
	[Value6] [nvarchar](30) NULL,
	[Param7] [nvarchar](30) NULL,
	[Value7] [nvarchar](30) NULL,
	[Param8] [nvarchar](30) NULL,
	[Value8] [nvarchar](30) NULL,
	[OrderRef] [nvarchar](30) NULL,
	[OrderReason] [nvarchar](10) NOT NULL,
	[ValidFrom] [datetime2](7) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](7) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [ord].[H_Order])
)
GO
/****** Object:  View [ord].[vwOrder]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO









/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [ord].[vwOrder] as
SELECT  [OrderId]
      ,[RebalancingSessionId]
      ,ord.[InstrumentId]
	  , ins.Symbol
	  ,ins.Name
	  ,ins.Currency
	  ,ins.Exchange
	  ,ins.MarketSector
	  ,insType.Mnemonic as InstrumentType
      ,ord.[OrderSideId]
	  ,os.Mnemonic as OrderSide
      ,[Quantity]
      ,ord.[BrokerId]
	  ,bro.Code as BrokerCode
	  ,bro.Name as BrokerName
      ,ord.[OrderTypeId]
	  ,ot.Mnemonic as OrderType
      ,ord.[TimeInForceId]
	  ,tif.Mnemonic as TimeInForce
      ,ord.[ExecutionAlgorithmId]
	  ,algo.Mnmemonic as ExecutionAlgo  
      ,ord.[HandlingInstructionId]
	  ,hi.Code as HandlingInstruction
      ,ord.[ExecutionChannelId]
      ,ec.Mnemonic as ExecutionChannel
	  ,ord.[TradeModeId]
	  ,tm.Mnemonic as TradeMode
      ,[TradeDate]
      ,ord.[TradingDeskId]
	  ,td.Code as TradingDesk
      ,[CreatedOn]
      ,[Param1]
      ,[Value1]
      ,[Param2]
      ,[Value2]
      ,[Param3]
      ,[Value3]
      ,[Param4]
      ,[Value4]
      ,[Param5]
      ,[Value5]
      ,[Param6]
      ,[Value6]
      ,[Param7]
      ,[Value7]
      ,[Param8]
      ,[Value8]
  FROM [ord].[Order] ord
  LEFT JOIN ord.Broker bro on bro.BrokerId = ord.BrokerId
  LEFT JOIN ord.OrderSide os on os.OrderSideId = ord.OrderSideId
  LEFT JOIN ord.Instrument ins on ins.InstrumentId = ord.InstrumentId
  LEFT JOIN ord.InstrumentType insType on insType.InstrumentTypeId= ins.InstrumentTypeId
  LEFT JOIN ord.TradeMode tm on tm.TradeModeId = ord.TradeModeId
  LEFT JOIN ord.OrderType ot on ot.OrderTypeId=  ord.OrderTypeId
  LEFT JOIN ord.TimeInForce tif on tif.TimeInForceId = ord.TimeInForceId
  LEFT JOIN ord.HandlingInstruction hi on hi.HandlingInstructionId = ord.HandlingInstructionId
  LEFT JOIN ord.ExecutionChannel ec on ec.ExecutionChannelId = ord. ExecutionChannelId
  LEFT JOIN ord.TradingDesk td on td.TradingDeskId = ord.TradingDeskId
  LEFT JOIN ord.ExecutionAlgorithm algo on algo.ExecutionAlgorithmId = ord.ExecutionAlgorithmId



GO
/****** Object:  Table [ord].[TradingAccount_H]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[TradingAccount_H](
	[TradingAccountId] [int] NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[BrokerId] [int] NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_TradingAccount_H]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_TradingAccount_H] ON [ord].[TradingAccount_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [ord].[TradingAccount]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[TradingAccount](
	[TradingAccountId] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[BrokerId] [int] NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_TradingAccount] PRIMARY KEY CLUSTERED 
(
	[TradingAccountId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [ord].[TradingAccount_H])
)
GO
/****** Object:  Table [risk].[Constraint_H]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [risk].[Constraint_H](
	[ConstraintId] [int] NOT NULL,
	[ConstraintTypeId] [smallint] NOT NULL,
	[RelationalOperatorId] [tinyint] NOT NULL,
	[LimitValue] [decimal](12, 6) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[FilterId] [int] NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_Constraint_H]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_Constraint_H] ON [risk].[Constraint_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [risk].[Constraint]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [risk].[Constraint](
	[ConstraintId] [int] IDENTITY(1,1) NOT NULL,
	[ConstraintTypeId] [smallint] NOT NULL,
	[RelationalOperatorId] [tinyint] NOT NULL,
	[LimitValue] [decimal](12, 6) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[FilterId] [int] NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_ConstraintId] PRIMARY KEY CLUSTERED 
(
	[ConstraintId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_Constraint] UNIQUE NONCLUSTERED 
(
	[ConstraintTypeId] ASC,
	[RelationalOperatorId] ASC,
	[LimitValue] ASC,
	[FilterId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [risk].[Constraint_H])
)
GO
/****** Object:  UserDefinedFunction [trans].[ZZZ_tvTradesFileMSFSSW002]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [trans].[ZZZ_tvTradesFileMSFSSW002] (@PortfolioId tinyint)
RETURNS TABLE
AS
RETURN
SELECT 
    'SW002' AS TrasationType,
    trd.TradeStatus AS TransactionStatus,
    trd.BuySellIndicator AS [Buy/Sell],
    CASE 
        WHEN trd.BuySellIndicator = 'S' AND (alloc.PositionSide = 'L' OR alloc.PositionSide = 'C') THEN 'L'
        WHEN trd.BuySellIndicator = 'S' AND alloc.PositionSide = 'S' THEN 'S'
        WHEN trd.BuySellIndicator = 'B' AND alloc.PositionSide = 'L' THEN 'L'
        WHEN trd.BuySellIndicator = 'B' AND (alloc.PositionSide = 'S' OR alloc.PositionSide = 'C') THEN 'C'
    END AS [Long/Short],
    '' AS [PositionType],
    'A' AS [TransLevel],
    alloc.TradeAllocationId AS [ClientTradeRefNo],
    CONCAT(trd.TradeId,'A') AS [AssociatedTradeId],
    codes.ExecutionAccount AS [ExecutionAccount],
    codes.ClearingAccount AS [Account Id],
    trd.TradeDesk AS [Broker/Couterparty],
    IIF(trd.Sedol IS NULL OR TRIM(trd.Sedol) = '', 'B','S') AS [SecurityIdentifierType],
    IIF(trd.Sedol IS NULL OR TRIM(trd.Sedol) = '',ins.Symbol, trd.Sedol) AS [SecurityIdentifier],
    ins.Name as SecurityDescription,
    FORMAT(trd.TradeDate, 'MM/dd/yyyy') AS TradeDate,
    FORMAT(trd.fnAddBusinessDays(trd.TradeDate,IIF(ins.Symbol like '%Equity', 1,1)), 'MM/dd/yyyy') AS SettlementDate, -- TGU put 3 vs 2
    ISNULL(trd.SettlementCurrency, trd.TradeCurrency) AS SettlementCurrency,
    '' AS [ExchangeCode],
    ABS(alloc.Quantity) AS [Quantity],
    alloc.Price * ISNULL(trd.LocalToSettleFxRate,1) AS Price,
    'G' AS PriceIndicator,
    CAST(ABS(trd.Principal)* ISNULL(trd.LocalToSettleFxRate,1) AS DECIMAL(24,2)) AS Principal,
    CAST(trd.BrokerCommission* ISNULL(trd.LocalToSettleFxRate,1) AS DECIMAL(24,2)) AS [BrokerCommission],
    'F' AS [BrokerCommissionInd],
    trd.MiscFees AS [MSFees],
    '' AS [NotRequired],
    'F' AS [MSFeesInd],
    '' AS [DivEntitlPercent],
    '' AS Spread,
    CASE 
        WHEN trd.BuySellIndicator = 'S' THEN  CAST((ABS(trd.Principal)-ABS(trd.BrokerCommission))* ISNULL(trd.LocalToSettleFxRate,1) AS DECIMAL(24,2)) 
        WHEN trd.BuySellIndicator = 'B' THEN CAST((ABS(trd.Principal)+ABS(trd.BrokerCommission)* ISNULL(trd.LocalToSettleFxRate,1)) AS DECIMAL(24,2))   
    END AS NetAmount,
    'Y' AS [HearsayInd],
    codes.Custodian AS [Custodian],
    '' AS [MoneyManager],
    '' AS [BookId],
    '' AS [DealId],
    '' AS [TaxLotId],
    '' AS [TaxDate],
    '' AS [TaxPrice],
    '' AS [CloseOutMethod],
    '' AS [FxRate],
    '' AS [AcquisitionDate],
    '' AS [Comments],
    '' AS [SwapReferenceNo],
    '' AS [BasketId],
    '' AS [PriceCurrency],
    '' AS [ResetIndicator],
    '' AS [SnSReference],
    '' AS [ResearchFee],
    '' AS [ResearchFeeInd],
    '' AS [LEI],
    '' AS [MaturityDate],
    'Equity Vanilla Swaps' AS [ProductType],
    '' AS [Fuut/Part Unwind Ind],
    '' AS [PaymentDate],
    '' AS [DividendAmount],
    '' AS [DividendPayoutDate],
    '' AS [NextResetDate],
    '' AS [ResetPrice],
    '' AS [EquitySpread],
    '' AS [DaycountConvention],
    '' AS [FloatingRate],
    '' AS [RollConvention],
    '' AS [CollateralPledge],
    '' AS [FixingFrequency],
    '' AS [PaymentFrequency]
FROM 
    [trans].[Trade] trd
JOIN 
    [trans].[TradeAllocation] alloc ON alloc.TradeId = trd.TradeId
JOIN 
    [trans].Instrument ins ON ins.InstrumentId = trd.InstrumentId
LEFT JOIN 
    trans.[vwLastFileTransmission] ft ON ft.TransmissionType = 'MSFSTRD'
LEFT JOIN 
	trans.CounterpartyCodeMapping codes ON codes.PortfolioId = alloc.PortfolioId and  codes.FileGenerationType = 'MSFSSW002'
WHERE 
  
    (
        trd.IsCfd = 1 
        OR trd.IsFutureSwap = 1
    )
  --  AND trd.TradeDate = CAST(GETDATE() AS DATE)
	AND (ft.TransmittedOn IS NULL OR ft.TransmittedOn < trd.BookedOn)
	AND alloc.PortfolioId = @PortfolioId;
GO
/****** Object:  Table [trd].[FxRate]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trd].[FxRate](
	[BaseCurrency] [char](3) NOT NULL,
	[QuoteCurrency] [char](3) NOT NULL,
	[Value] [decimal](12, 6) NOT NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_FxRate] PRIMARY KEY CLUSTERED 
(
	[BaseCurrency] ASC,
	[QuoteCurrency] ASC,
	[Date] DESC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [trd].[vwLastFxRate]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







/****** Script for SelectTopNRows command from SSMS  ******/

Create VIEW [trd].[vwLastFxRate] as
WITH RankedFXRates AS (
    SELECT
        BaseCurrency,
        QuoteCurrency,
        [Date],
        [Value],
        ROW_NUMBER() OVER (PARTITION BY BaseCurrency, QuoteCurrency ORDER BY [Date] DESC) AS rn
    FROM
        trd.FxRate
)

SELECT
    BaseCurrency,
    QuoteCurrency,
    [Date],
        [Value]
FROM
    RankedFXRates
WHERE
    rn = 1;



GO
/****** Object:  UserDefinedFunction [trans].[ZZZ_tvTradesFileMSFSTR001]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE FUNCTION [trans].[ZZZ_tvTradesFileMSFSTR001] (@PortfolioId tinyint)
RETURNS TABLE
AS
RETURN
SELECT 
    'TR001' AS TrasationType,
    trd.TradeStatus AS TransactionStatus,
    trd.BuySellIndicator AS [Buy/Sell],
    CASE 
        WHEN trd.BuySellIndicator='S' AND (alloc.PositionSide ='L' OR  alloc.PositionSide ='C') THEN 'L'
        WHEN trd.BuySellIndicator='S' AND alloc.PositionSide ='S' THEN 'S'
        WHEN trd.BuySellIndicator='B' AND alloc.PositionSide ='L' THEN 'L'
        WHEN trd.BuySellIndicator='B' AND (alloc.PositionSide ='S' OR  alloc.PositionSide ='C') THEN 'C' 
    END AS [Long/Short],
    '' AS [PositionType],
    'A' AS [TransLevel],
    alloc.TradeAllocationId AS [ClientRef#],
    CONCAT(trd.TradeId,'A') AS [Associated#],
    codes.ExecutionAccount AS [ExecAccount],
    codes.ClearingAccount AS [AccountId],
    trd.TradeDesk AS [ExecutionBroker],
    'B' AS [SecType],
    ins.Symbol AS [SecID],
    ins.[Name] as SecurityDescription,
    FORMAT(trd.TradeDate, 'MM/dd/yyyy') AS TradeDate,
    FORMAT(trd.fnAddBusinessDays(trd.TradeDate,1), 'MM/dd/yyyy') AS SettlementDate,
    ISNULL( trd.SettlementCurrency, trd.TradeCurrency) AS SettlementCurrency,
    '' AS ExchangeCode,
    ABS(alloc.Quantity) AS [Quantity],
	  CASE WHEN LEFT(ins.Symbol, 2)= 'JY' AND RIGHT(ins.Symbol, 6) = 'Curncy' THEN alloc.Price/100
	  WHEN LEFT(ins.Symbol, 2)= 'NO' AND RIGHT(ins.Symbol, 6) = 'Curncy' THEN alloc.Price/100
	  WHEN LEFT(ins.Symbol, 2)= 'SE' AND RIGHT(ins.Symbol, 6) = 'Curncy' THEN alloc.Price/100
	  WHEN LEFT(ins.Symbol, 2)= 'RA' AND RIGHT(ins.Symbol, 6) = 'Curncy' THEN alloc.Price/100
	  WHEN LEFT(ins.Symbol, 2)= 'HE' AND RIGHT(ins.Symbol, 6) = 'Curncy' THEN alloc.Price/100
	  WHEN LEFT(ins.Symbol, 2)= 'BR' AND RIGHT(ins.Symbol, 6) = 'Curncy' THEN alloc.Price/100
	 ELSE alloc.Price END AS PriceAmount,
    'G' AS PriceIndicator,
    CAST(ABS(trd.Principal) AS DECIMAL(24,2)) AS Principal,
    CAST(ABS(trd.BrokerCommission) AS DECIMAL(24,2)) AS CommissionAmount,
    'F' AS CommissionIndicator,
    ABS(ISNULL(trd.MiscFees,0)) AS [Tax/Fees],
    '' AS [Tax2],
    'F' AS [FeeInd],
    '' AS [Interest],
    '' AS [InterestIndicator],
    CASE 
        WHEN trd.BuySellIndicator = 'S' THEN CAST(ABS(trd.Principal)- ABS(trd.BrokerCommission) AS DECIMAL(24,2))
        WHEN trd.BuySellIndicator = 'B' THEN CAST(ABS(trd.Principal)+ ABS(trd.BrokerCommission) AS DECIMAL(24,2))
    END AS NetAmount,
    'Y' AS [HearsayInd],
    codes.Custodian AS [Custodian],
    '' AS [MoneyManager],
    '' AS [BookId],
    '' AS [DealId],
    '' AS [TaxLotId],
    '' AS [TaxDate],
    '' AS [TaxPrice],
    '' AS [CloseOutMethod],
    '' AS [ExRate],
    '' AS [AcqDate],
    '' AS [Comments]
FROM  
    [trans].[Trade] trd
JOIN 
    [trans].[TradeAllocation] alloc ON alloc.TradeId = trd.TradeId
JOIN 
    [trans].Instrument ins ON ins.InstrumentId = trd.InstrumentId
LEFT JOIN 
    trans.[vwLastFileTransmission] ft ON ft.TransmissionType = 'MSFSTRD'
LEFT JOIN 
	trans.CounterpartyCodeMapping codes ON codes.PortfolioId = alloc.PortfolioId and  codes.FileGenerationType = 'MSFSTR001'
WHERE 
    ins.InstrumentType = 'FUT'
    --AND trd.TradeDate = CAST(GETDATE() AS DATE) 
    AND trd.IsFutureSwap=0
    AND (ft.TransmittedOn IS NULL OR ft.TransmittedOn < trd.BookedOn)
	AND alloc.PortfolioId = @PortfolioId;
GO
/****** Object:  View [trans].[vwCMGLFND_vwTradesFileMSFSSW002_GS_TEST]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
















--This is just to simulate and provide an example of the trade file for trading with GS. 
--Once the codes and format are validated we need to merge the logic with vwCMGLFND_vwTradesFileMSFSSW002_MS_TEST to return the correct account, broker and custodian according to the trade caracteristics
CREATE VIEW [trans].[vwCMGLFND_vwTradesFileMSFSSW002_GS_TEST] AS
SELECT 
    'SW002' AS TrasationType,
    trd.TradeStatus AS TransactionStatus,
    trd.BuySellIndicator AS [Buy/Sell],
    CASE 
        WHEN trd.BuySellIndicator = 'S' AND (alloc.PositionSide = 'L' OR alloc.PositionSide = 'C') THEN 'L'
        WHEN trd.BuySellIndicator = 'S' AND alloc.PositionSide = 'S' THEN 'S'
        WHEN trd.BuySellIndicator = 'B' AND alloc.PositionSide = 'L' THEN 'L'
        WHEN trd.BuySellIndicator = 'B' AND (alloc.PositionSide = 'S' OR alloc.PositionSide = 'C') THEN 'C'
    END AS [Long/Short],
    '' AS [PositionType],
    'A' AS [TransLevel],
    alloc.TradeAllocationId AS [ClientTradeRefNo],
    CONCAT(trd.TradeId,'A') AS [AssociatedTradeId],
    '038227591' AS [ExecutionAccount],
    '038QLFR53' AS [Account Id],
    'GSET' AS [Broker/Couterparty],
    IIF(trd.Sedol IS NULL OR TRIM(trd.Sedol) = '', 'B','S') AS [SecurityIdentifierType],
    IIF(trd.Sedol IS NULL OR TRIM(trd.Sedol) = '',ins.Symbol, trd.Sedol) AS [SecurityIdentifier],
    ins.Name as SecurityDescription,
    FORMAT(trd.TradeDate, 'MM/dd/yyyy') AS TradeDate,
    FORMAT(trd.fnAddBusinessDays(trd.TradeDate,IIF(ins.Symbol like '%Equity', 2,2)), 'MM/dd/yyyy') AS SettlementDate, -- TGU put 3 vs 2
    ISNULL(fs.SettlementCurrency, ISNULL(trd.SettlementCurrency, trd.TradeCurrency)) AS SettlementCurrency,
    '' AS [ExchangeCode],
    ABS(alloc.Quantity) AS [Quantity],
    alloc.Price AS Price,
    'G' AS PriceIndicator,
    CAST(ABS(trd.Principal) AS DECIMAL(24,2)) AS Principal,
    CAST(trd.BrokerCommission AS DECIMAL(24,2)) AS [BrokerCommission],
    'F' AS [BrokerCommissionInd],
    trd.MiscFees AS [MSFees],
    '' AS [NotRequired],
    'F' AS [MSFeesInd],
    '' AS [DivEntitlPercent],
    '' AS Spread,
    CASE 
        WHEN trd.BuySellIndicator = 'S' THEN  CAST(ABS(trd.Principal)-ABS(trd.BrokerCommission) AS DECIMAL(24,2)) 
        WHEN trd.BuySellIndicator = 'B' THEN CAST(ABS(trd.Principal)+ABS(trd.BrokerCommission)AS DECIMAL(24,2))   
    END AS NetAmount,
    'Y' AS [HearsayInd],
    'GSSW' AS [Custodian],
    '' AS [MoneyManager],
    '' AS [BookId],
    '' AS [DealId],
    '' AS [TaxLotId],
    '' AS [TaxDate],
    '' AS [TaxPrice],
    '' AS [CloseOutMethod],
    '' AS [FxRate],
    '' AS [AcquisitionDate],
    '' AS [Comments],
    '' AS [SwapReferenceNo],
    '' AS [BasketId],
    '' AS [PriceCurrency],
    '' AS [ResetIndicator],
    '' AS [SnSReference],
    '' AS [ResearchFee],
    '' AS [ResearchFeeInd],
    '' AS [LEI],
    '' AS [MaturityDate],
    'Equity Vanilla Swaps' AS [ProductType],
    '' AS [Fuut/Part Unwind Ind],
    '' AS [PaymentDate],
    '' AS [DividendAmount],
    '' AS [DividendPayoutDate],
    '' AS [NextResetDate],
    '' AS [ResetPrice],
    '' AS [EquitySpread],
    '' AS [DaycountConvention],
    '' AS [FloatingRate],
    '' AS [RollConvention],
    '' AS [CollateralPledge],
    '' AS [FixingFrequency],
    '' AS [PaymentFrequency]
FROM 
    [trans].[Trade] trd
JOIN 
    [trans].[TradeAllocation] alloc ON alloc.TradeId = trd.TradeId
JOIN 
    [trans].Instrument ins ON ins.InstrumentId = trd.InstrumentId
LEFT JOIN 
    trans.[vwLastFileTransmission] ft ON ft.TransmissionType = 'MSFSSW002TEST'
LEFT JOIN trd.vwFutureSwap fs on fs.InstrumentId = trd.InstrumentId
WHERE 
    ((ins.InstrumentType = 'EQU' AND trd.IsCfd = 1) 
     OR (trd.InstrumentId IN (SELECT InstrumentId FROM trd.vwFutureSwap)))
       	AND trd.TradeDate = DATEADD(day,-3, CAST(GETDATE() AS DATE)) 
	AND (ft.TransmittedOn IS NULL OR ft.TransmittedOn < trd.BookedOn);
GO
/****** Object:  UserDefinedFunction [trans].[ZZZ_tvTradesFileJPMSWAP]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE FUNCTION [trans].[ZZZ_tvTradesFileJPMSWAP] (@PortfolioId tinyint)
RETURNS TABLE
AS
RETURN
SELECT  
alloc.TradeAllocationId as TradeId,
  trd.TradeStatus AS [ACTION],
  FORMAT(trd.[TradeDate], 'yyyy/MM/dd') AS [TRADE_DATE],
  FORMAT(trd.fnAddBusinessDays(trd.TradeDate,IIF(ins.Symbol like '%Equity', 1,1)), 'yyyy/MM/dd') AS [SETTLEMENT_DATE],
    '317-55516' as [ACCOUNT], --  codes.ClearingAccount AS [Account],

    'SWAP' AS [METHOD],
	 trd.BuySellIndicator  as [SIDE],

	ins.Symbol as [SECURITY],
	'B' as [SEC_ID],
		ABS(FilledQuantity) AS [QUANTITY],
	   ROUND(trd.AvgPrice, 4) AS [PRICE],
	   --'PERQTY' as [COMM_TYPE],
    --CAST(trd.BrokerCommission AS DECIMAL(24,2)) AS [COMM],
	'JPM' as [EXEC_BRK], --codes.ExecutionBroker as [EXEC_BRK],
	ISNULL(fs.SettlementCurrency, trd.TradeCurrency) AS [CURRENCY],
	ISNULL(fxr.Value,'1') as [EXCHG RATE],
	'6ZK_'+ISNULL(fs.SettlementCurrency, trd.TradeCurrency) as [PORTFOLIO_SWAP]
  
FROM 
    [Trading].[trans].[Trade] trd
JOIN 
    trans.TradeAllocation alloc ON alloc.TradeId = trd.TradeId
JOIN 
    trans.Instrument ins ON ins.InstrumentId = trd.InstrumentId
LEFT JOIN trans.CounterpartyCodeMapping codes ON codes.PortfolioId = alloc.PortfolioId and  codes.FileGenerationType = 'MSPBSW002'--TODO:JPPBSWAP
LEFT JOIN 
    trans.[vwLastFileTransmission] ft ON ft.TransmissionType = 'MSPBTRD'--TOD:JPPBTRD
LEFT JOIN trd.vwFutureSwap fs on fs.InstrumentId = trd.InstrumentId
LEFT JOIN trd.vwLastFxRate fxr on fxr.BaseCurrency = trd.TradeCurrency and fxr.QuoteCurrency = ISNULL(fs.SettlementCurrency, trd.TradeCurrency)
WHERE 
    (
        trd.IsCfd = 1 
        OR trd.IsFutureSwap = 1
    )
	AND trd.TradeDesk in ('MSET','MSST')--That is not correct, we can exec with one broker and pb another.
   AND trd.TradeDate = CAST(DATEADD(day, -1,GETDATE()) AS DATE) 
  --AND (ft.TransmittedOn IS NULL OR ft.TransmittedOn < trd.BookedOn)
	AND alloc.PortfolioId =@PortfolioId;
GO
/****** Object:  UserDefinedFunction [trans].[ZZZ_tvTradesFileMSPBD01]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE FUNCTION [trans].[ZZZ_tvTradesFileMSPBD01] (@PortfolioId tinyint)
RETURNS TABLE
AS
RETURN
SELECT  
    'D01' AS [Transaction_Type],    
    codes.ClearingAccount AS [Account],   
    alloc.TradeAllocationId AS [Client_Ref_No],
    '1' AS Version_Number,
    trd.TradeStatus AS Transaction_Status,
    'B' AS Sec_identifier_Type,
    ins.Symbol AS Sec_Identifier,
    '' AS Contract_Year,
    '' AS Contract_Month,
    '' AS Contract_Day,
    ins.[Name] AS Contract_Security_Description,
    ExchangeCode AS [Market/Exchange],   
    CASE 
        WHEN FilledQuantity > 0 THEN 'B' 
        ELSE 'S' 
    END AS [Buy Sell Indicator],   
    '' AS Trade_Type,
    '' AS order_To_Close_Ind,
    '' AS Average_Price_Ind,
    '' AS Spread_Trade_Ind,
    '' AS Night_Trade_Ind,
    '' AS Exchange_for_Physical_Ind,
    '' AS [Block_Trade_Ind],
    '' AS [Off_Exchange_Ind],
    CAST(FORMAT(trd.TradeDate, 'MM/dd/yyyy') AS NVARCHAR(10)) AS [Trade_Date],
    '' AS ExecutionTime,
    ABS(FilledQuantity) AS Quantity,
    ROUND(trd.AvgPrice, 5) AS Price,
    '' AS [Call/Put],
    '' AS Strike_Price,
    codes.ExecutionBroker AS Executing_Broker,
    codes.ClearingBroker AS Clearing_Broker,
    '' AS Give_Up_Reference,
    '' AS Hearsay_Ind,
    '' AS Execution_Fee,
    '' AS Execution_Fee_CCY,
    trd.BrokerCommission AS Commission,
    '' AS Commission_CCY,
    trd.MiscFees AS Exchange_Fee,
    '' AS Exchange_Fee_CCY,
    trd.OrderId AS OrderId,
    '' AS DealId,
    'E' AS Execution_Type
FROM 
    [Trading].[trans].[Trade] trd
JOIN 
    trans.TradeAllocation alloc ON alloc.TradeId = trd.TradeId
JOIN 
    trans.Instrument ins ON ins.InstrumentId = trd.InstrumentId
LEFT JOIN
    trans.CounterpartyCodeMapping codes ON codes.PortfolioId = alloc.PortfolioId and  codes.FileGenerationType = 'MSPBD01'
LEFT JOIN 
    trans.[vwLastFileTransmission] ft ON ft.TransmissionType = 'MSPBTRD'
WHERE 
    ins.InstrumentType = 'FUT'
  	AND trd.TradeDesk in ('MSET','MSST')--That is not correct, we can exec with one broker and pb another.
    AND trd.IsFutureSwap = 0
    AND (ft.TransmittedOn IS NULL OR ft.TransmittedOn < trd.BookedOn)
	AND alloc.PortfolioId = @PortfolioId;
GO
/****** Object:  View [trans].[vwCMGLFND_vwTradesFileMSFSSW002_MS_TEST]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

















CREATE VIEW [trans].[vwCMGLFND_vwTradesFileMSFSSW002_MS_TEST] AS
SELECT 
    'SW002' AS TrasationType,
    trd.TradeStatus AS TransactionStatus,
    trd.BuySellIndicator AS [Buy/Sell],
    CASE 
        WHEN trd.BuySellIndicator = 'S' AND (alloc.PositionSide = 'L' OR alloc.PositionSide = 'C') THEN 'L'
        WHEN trd.BuySellIndicator = 'S' AND alloc.PositionSide = 'S' THEN 'S'
        WHEN trd.BuySellIndicator = 'B' AND alloc.PositionSide = 'L' THEN 'L'
        WHEN trd.BuySellIndicator = 'B' AND (alloc.PositionSide = 'S' OR alloc.PositionSide = 'C') THEN 'C'
    END AS [Long/Short],
    '' AS [PositionType],
    'A' AS [TransLevel],
    alloc.TradeAllocationId AS [ClientTradeRefNo],
    CONCAT(trd.TradeId,'A') AS [AssociatedTradeId],
    '038227591' AS [ExecutionAccount],
    '038QLFR53' AS [Account Id],
    trd.TradeDesk AS [Broker/Couterparty],
    IIF(trd.Sedol IS NULL OR TRIM(trd.Sedol) = '', 'B','S') AS [SecurityIdentifierType],
    IIF(trd.Sedol IS NULL OR TRIM(trd.Sedol) = '',ins.Symbol, trd.Sedol) AS [SecurityIdentifier],
    ins.Name as SecurityDescription,
    FORMAT(trd.TradeDate, 'MM/dd/yyyy') AS TradeDate,
    FORMAT(trd.fnAddBusinessDays(trd.TradeDate,IIF(ins.Symbol like '%Equity', 2,2)), 'MM/dd/yyyy') AS SettlementDate, -- TGU put 3 vs 2
    ISNULL(fs.SettlementCurrency, ISNULL(trd.SettlementCurrency, trd.TradeCurrency)) AS SettlementCurrency,
    '' AS [ExchangeCode],
    ABS(alloc.Quantity) AS [Quantity],
    alloc.Price AS Price,
    'G' AS PriceIndicator,
    CAST(ABS(trd.Principal) AS DECIMAL(24,2)) AS Principal,
    CAST(trd.BrokerCommission AS DECIMAL(24,2)) AS [BrokerCommission],
    'F' AS [BrokerCommissionInd],
    trd.MiscFees AS [MSFees],
    '' AS [NotRequired],
    'F' AS [MSFeesInd],
    '' AS [DivEntitlPercent],
    '' AS Spread,
    CASE 
        WHEN trd.BuySellIndicator = 'S' THEN  CAST(ABS(trd.Principal)-ABS(trd.BrokerCommission) AS DECIMAL(24,2)) 
        WHEN trd.BuySellIndicator = 'B' THEN CAST(ABS(trd.Principal)+ABS(trd.BrokerCommission)AS DECIMAL(24,2))   
    END AS NetAmount,
    'Y' AS [HearsayInd],
    'MSSW' AS [Custodian],
    '' AS [MoneyManager],
    '' AS [BookId],
    '' AS [DealId],
    '' AS [TaxLotId],
    '' AS [TaxDate],
    '' AS [TaxPrice],
    '' AS [CloseOutMethod],
    '' AS [FxRate],
    '' AS [AcquisitionDate],
    '' AS [Comments],
    '' AS [SwapReferenceNo],
    '' AS [BasketId],
    '' AS [PriceCurrency],
    '' AS [ResetIndicator],
    '' AS [SnSReference],
    '' AS [ResearchFee],
    '' AS [ResearchFeeInd],
    '' AS [LEI],
    '' AS [MaturityDate],
    'Equity Vanilla Swaps' AS [ProductType],
    '' AS [Fuut/Part Unwind Ind],
    '' AS [PaymentDate],
    '' AS [DividendAmount],
    '' AS [DividendPayoutDate],
    '' AS [NextResetDate],
    '' AS [ResetPrice],
    '' AS [EquitySpread],
    '' AS [DaycountConvention],
    '' AS [FloatingRate],
    '' AS [RollConvention],
    '' AS [CollateralPledge],
    '' AS [FixingFrequency],
    '' AS [PaymentFrequency]
FROM 
    [trans].[Trade] trd
JOIN 
    [trans].[TradeAllocation] alloc ON alloc.TradeId = trd.TradeId
JOIN 
    [trans].Instrument ins ON ins.InstrumentId = trd.InstrumentId
LEFT JOIN 
    trans.[vwLastFileTransmission] ft ON ft.TransmissionType = 'MSFSSW002TEST'
LEFT JOIN trd.vwFutureSwap fs on fs.InstrumentId = trd.InstrumentId
WHERE 
    ((ins.InstrumentType = 'EQU' AND trd.IsCfd = 1) 
     OR (trd.InstrumentId IN (SELECT InstrumentId FROM trd.vwFutureSwap)))
       	AND trd.TradeDate = DATEADD(day,-3, CAST(GETDATE() AS DATE)) 
	AND (ft.TransmittedOn IS NULL OR ft.TransmittedOn < trd.BookedOn);
GO
/****** Object:  Table [mktdata].[Instrument]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [mktdata].[Instrument](
	[InstrumentId] [int] NOT NULL,
	[Symbol] [nvarchar](30) NOT NULL,
	[InstrumentType] [nvarchar](10) NOT NULL,
	[Exchange] [nvarchar](5) NULL,
	[QuoteCurrency] [char](3) NOT NULL,
	[PriceScalingFactor] [decimal](12, 6) NOT NULL,
	[Currency] [char](3) NOT NULL,
	[QuoteFactor] [decimal](12, 6) NOT NULL,
 CONSTRAINT [PK_InstrumentId] PRIMARY KEY CLUSTERED 
(
	[InstrumentId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [mktdata].[MarketData]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [mktdata].[MarketData](
	[InstrumentId] [int] NOT NULL,
	[LastPrice] [decimal](18, 6) NOT NULL,
	[LastPriceEod] [decimal](18, 6) NOT NULL,
	[VolumeAvg30Day] [decimal](18, 6) NULL,
	[MarketCap] [decimal](18, 6) NULL,
	[LastUpdateDate] [date] NOT NULL,
	[LastUpdateDateEod] [date] NOT NULL,
	[LastUpdateTime] [time](7) NULL,
	[Currency] [char](3) NOT NULL,
 CONSTRAINT [PK_MarketData] PRIMARY KEY CLUSTERED 
(
	[InstrumentId] ASC,
	[LastUpdateDateEod] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [trans].[BookedTradeAllocation]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[BookedTradeAllocation](
	[TradeAllocationId] [int] NOT NULL,
	[TradeId] [int] NOT NULL,
	[TradeStatus] [char](3) NOT NULL,
	[InstrumentId] [int] NOT NULL,
	[Symbol] [nvarchar](30) NOT NULL,
	[TradeSide] [nvarchar](10) NOT NULL,
	[TradeDate] [date] NOT NULL,
	[Exchange] [nvarchar](5) NULL,
	[IsSwap] [bit] NOT NULL,
	[InstrumentType] [nvarchar](8) NOT NULL,
	[TradeInstrumentType] [nvarchar](8) NOT NULL,
	[YellowKey] [nvarchar](10) NOT NULL,
	[ExecutionDesk] [nvarchar](6) NOT NULL,
	[ExecutionBroker] [nvarchar](5) NOT NULL,
	[ExecutionAccount] [nvarchar](20) NOT NULL,
	[Isin] [nvarchar](12) NULL,
	[Sedol] [nvarchar](20) NULL,
	[Cusip] [nvarchar](10) NULL,
	[SecurityName] [nvarchar](100) NULL,
	[LocalExchangeSymbol] [nvarchar](20) NULL,
	[PortfolioId] [tinyint] NOT NULL,
	[PositionSide] [char](1) NOT NULL,
	[Quantity] [int] NOT NULL,
	[ContractMultiplier] [decimal](18, 6) NOT NULL,
	[PriceScalingFactor] [decimal](12, 6) NOT NULL,
	[NominalQuantity] [decimal](18, 6) NOT NULL,
	[LocalCurrency] [char](3) NOT NULL,
	[BaseCurrency] [char](3) NOT NULL,
	[SettlementCurrency] [char](3) NOT NULL,
	[CommissionValue] [decimal](12, 6) NOT NULL,
	[CommissionType] [char](1) NOT NULL,
	[GrossAvgPriceLocal] [decimal](18, 6) NOT NULL,
	[PriceCommissionLocal] [decimal](18, 6) NOT NULL,
	[NetAvgPriceLocal] [decimal](18, 6) NOT NULL,
	[GrossAvgPriceBase] [decimal](18, 6) NOT NULL,
	[PriceCommissionBase] [decimal](18, 6) NOT NULL,
	[NetAvgPriceBase] [decimal](18, 6) NOT NULL,
	[GrossAvgPriceSettle] [decimal](18, 6) NOT NULL,
	[PriceCommissionSettle] [decimal](18, 6) NOT NULL,
	[NetAvgPriceSettle] [decimal](18, 6) NOT NULL,
	[CommissionAmountLocal] [decimal](18, 6) NOT NULL,
	[CommissionAmountBase] [decimal](18, 6) NOT NULL,
	[CommissionAmountSettle] [decimal](18, 6) NOT NULL,
	[MiscFeesLocal] [decimal](18, 6) NOT NULL,
	[MiscFeesBase] [decimal](18, 6) NOT NULL,
	[MiscFeesSettle] [decimal](18, 6) NOT NULL,
	[GrossTradeValueLocal] [decimal](20, 2) NOT NULL,
	[NetTradeValueLocal] [decimal](20, 2) NOT NULL,
	[GrossTradeValueBase] [decimal](20, 2) NOT NULL,
	[NetTradeValueBase] [decimal](20, 2) NOT NULL,
	[GrossTradeValueSettle] [decimal](20, 2) NOT NULL,
	[NetTradeValueSettle] [decimal](20, 2) NOT NULL,
	[GrossPrincipalLocal] [decimal](20, 2) NOT NULL,
	[NetPrincipalLocal] [decimal](20, 2) NOT NULL,
	[GrossPrincipalBase] [decimal](20, 2) NOT NULL,
	[NetPrincipalBase] [decimal](20, 2) NOT NULL,
	[GrossPrincipalSettle] [decimal](20, 2) NOT NULL,
	[NetPrincipalSettle] [decimal](20, 2) NOT NULL,
	[SettlementDate] [date] NOT NULL,
	[LocalToBaseFxRate] [decimal](12, 6) NOT NULL,
	[LocalToSettleFxRate] [decimal](12, 6) NOT NULL,
	[PrimeBroker] [nvarchar](6) NULL,
	[ClearingBroker] [nvarchar](6) NOT NULL,
	[ClearingAccount] [nvarchar](20) NOT NULL,
	[Custodian] [nvarchar](6) NULL,
	[EmsxOrderId] [int] NULL,
	[OrderReferenceId] [int] NULL,
	[BlockOrderQuantity] [int] NULL,
	[OrderAllocationQuantity] [int] NULL,
	[OrderAllocationNominalQuantity] [decimal](18, 6) NULL,
	[ExecutionType] [nvarchar](6) NULL,
	[Notes] [nvarchar](200) NULL,
	[TraderName] [nvarchar](30) NULL,
	[TraderUuid] [int] NULL,
	[LastCorrectedOnUtc] [datetime2](7) NULL,
	[CanceledOnUtc] [datetime2](7) NULL,
	[BookedOnUtc] [datetime2](7) NULL,
 CONSTRAINT [PK_BookedTradeAllocation] PRIMARY KEY CLUSTERED 
(
	[TradeAllocationId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [trans].[tvSwapResetFileMSFSSW003]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [trans].[tvSwapResetFileMSFSSW003] (@EOMDate DATE)
RETURNS TABLE
AS
RETURN
 WITH RankedMarketData AS (
    SELECT[InstrumentId],
        [LastPriceEOD] as [LastPrice],
        LastUpdateDateEOD as [LastUpdateDate],
        [LastUpdateTime],
		Currency,
        ROW_NUMBER() OVER (PARTITION BY [InstrumentId] ORDER BY LastUpdateDateEOD DESC,[LastUpdateTime]DESC,Currency ) AS rn
    FROM
        [mktdata].[MarketData]
		where LastUpdateDateEOD <= @EOMDate
),  eomprices as (

SELECT
   mkt.[InstrumentId],
   ins.Symbol,
        [LastPrice],
        [LastUpdateDate],
        [LastUpdateTime],
		mkt.Currency,
		ins.QuoteCurrency,
		ins.QuoteFactor,
		ins.PriceScalingFactor
FROM
    RankedMarketData mkt
	JOIN mktdata.Instrument ins on ins.InstrumentId = mkt.InstrumentId
WHERE
    rn = 1
	), swappositions as (

SELECT distinct
      i.[InstrumentId]
	   ,MAX(TradeId) as ClientRef
	  ,i.ISIN
      ,IIF([Sedol]='',NULL,[Sedol]) as [Sedol]
	  ,i.[Symbol]
	  ,cast(@EOMDate as DATE) as TradeDate
      ,SUM([NominalQuantity]) as Quantity
      ,[LocalCurrency] as [TradeCurrency]
      ,SettlementCurrency AS Currency
  FROM [trans].[BookedTradeAllocation] t
  JOIN [trans].Instrument i on i.InstrumentId = t.InstrumentId
  WHERE 
    t.IsSwap =1
	 AND t.TradeDate <= @EOMDate
  group by 
   i.[InstrumentId]
      ,IIF([Sedol]='',NULL,[Sedol])   
	  ,i.ISIN
	  ,i.Symbol
      ,[LocalCurrency]   
      ,SettlementCurrency
  )
  SELECT 
    'SW003' AS TrasationType,
    'NEW' AS TransactionStatus,
    CASE 
        WHEN Quantity>0 THEN 'SL'
        ELSE 'BC'
    END AS [PosType],
    cast(CONCAT(FORMAT(@EOMDate, 'yyyyMMdd'),ClientRef)as nvarchar(16)) AS [ClientRef#],
    '038QLFIP9' AS [CustAccount],
    'MSSW' AS [ExecBkr],
	IIF(pos.Sedol IS NULL, 'B','S')  AS SecType,
	IIF(pos.Sedol IS NULL, pos.Symbol, pos.Sedol)  AS [Sec ID],
	'' as [desc],
    FORMAT(pos.TradeDate, 'MM/dd/yyyy') AS TDate,
	FORMAT(trd.fnAddBusinessDays(pos.TradeDate,2), 'MM/dd/yyyy') AS SDate,
	pos.Currency AS CCY,
    ABS(pos.Quantity) AS [qty],
	ABS(px.LastPrice) AS [price],
	'' as comm,
	'' as commtype,
	'' as [Other Charges],
	'' as [Other Charges Type],
	'' as [net amount],
	'MSSW' as [cus bkr],
	'' as [mmgr],
	'' as [deal id],
	'R' as [Swap Reset]

FROM 
    swappositions pos
	JOIN eomprices px on px.InstrumentId = pos.InstrumentId

	where Quantity <> 0
GO
/****** Object:  UserDefinedFunction [trans].[ZZZ_tvTradesFileMSPBSW002]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [trans].[ZZZ_tvTradesFileMSPBSW002] (@PortfolioId tinyint)
RETURNS TABLE
AS
RETURN
SELECT  
    'SW002' AS [Transaction Type],
    trd.TradeStatus AS [Transaction Status],
    trd.BuySellIndicator AS [Buy Sell Indicator],
    CASE 
        WHEN trd.BuySellIndicator = 'S' AND (alloc.PositionSide IN ('L', 'C')) THEN 'L'
        WHEN trd.BuySellIndicator = 'S' AND alloc.PositionSide = 'S' THEN 'S'
        WHEN trd.BuySellIndicator = 'B' AND alloc.PositionSide = 'L' THEN 'L'
        WHEN trd.BuySellIndicator = 'B' AND (alloc.PositionSide IN ('S', 'C')) THEN 'C'
    END AS [Long Short Indicator],
    '' AS [Position Type],
    'A' AS [Transaction Level],
    alloc.TradeAllocationId AS [Client Trade Ref No.],
    CONCAT(alloc.TradeId,'A') AS [Associated Trade Id],
    codes.ExecutionAccount AS [Execution Account],   
    codes.ClearingAccount AS [Account Id],
    codes.ExecutionBroker AS [Broker / Counterparty],
    IIF(trd.Sedol IS NULL OR TRIM(trd.Sedol) = '', 'B', 'S') AS [Security Identifier Type],
    IIF(trd.Sedol IS NULL OR TRIM(trd.Sedol) = '',
        IIF(CHARINDEX(' ', ins.Symbol) > 0, LEFT(ins.Symbol, CHARINDEX(' ', ins.Symbol) - 1), NULL),
        trd.Sedol) AS [SecurityIdentifier],
    ins.[Name] AS [Security Description],
    FORMAT(trd.[TradeDate], 'yyyy-MM-dd') AS [Trade Date],
    FORMAT(trd.fnAddBusinessDays(trd.TradeDate,IIF(ins.Symbol like '%Equity', 1,1)), 'yyyy-MM-dd') AS [Settlement Date], -- TGU 3 to 2
    ISNULL(fs.SettlementCurrency, trd.TradeCurrency) AS [Settlement CCY],
    '' AS [Exchange Code],
    ABS(FilledQuantity) AS [Quantity],
    ROUND(trd.AvgPrice, 5) AS [Price],
    'G' AS [Price Indicator],
    CAST(ABS(Principal) AS DECIMAL(24,2)) AS [Principal],
    CAST(trd.BrokerCommission AS DECIMAL(24,2)) AS [Execution Broker Commission],
    'F' AS [Executing broker Commission Indicator],
    trd.MiscFees AS [MS Fees],
    '' AS [Not Required],
    'F' AS [MS fees Indicator.],
    '' AS [Dividend Entitlement Percent],
    '' AS [Spread],
    CAST(ABS(trd.NetAmount) AS DECIMAL(24,2)) AS [Net Amount],
    '' AS [Hearsay Ind],
    codes.Custodian AS [Custodian],
    '' AS [Money Manager],
    '' AS [Book Id],
    '' AS [Deal Id],
    '' AS [TaxLot Id],
    '' AS [Original taxlot transaction date],
    '' AS [Original Taxlot transaction price],
    '' AS [Taxlot Closeout Method],
    '' AS [Price FX Rate],
    '' AS [Acquisition Date],
    trd.Notes AS [Comments],
    '' AS [Swap Reference No.],
    '' AS [Basket Id],
    TradeCurrency AS [Price Currency],
    '' AS [Reset Indicator],
    '' AS [SNS reference],
    '' AS [Research Fee],
    '' AS [Research Fee Indicator],
    '' AS [LEI],
    '' AS [Client Strategy 2 (Used for PEPS)]
FROM 
    [Trading].[trans].[Trade] trd
JOIN 
    trans.TradeAllocation alloc ON alloc.TradeId = trd.TradeId
JOIN 
    trans.Instrument ins ON ins.InstrumentId = trd.InstrumentId
LEFT JOIN trans.CounterpartyCodeMapping codes ON codes.PortfolioId = alloc.PortfolioId and  codes.FileGenerationType = 'MSPBSW002'
LEFT JOIN 
    trans.[vwLastFileTransmission] ft ON ft.TransmissionType = 'MSPBTRD'
LEFT JOIN trd.vwFutureSwap fs on fs.InstrumentId = trd.InstrumentId
WHERE 
    (
        trd.IsCfd = 1 
        OR trd.IsFutureSwap = 1
    )
	AND trd.TradeDesk in ('MSET','MSST')--That is not correct, we can exec with one broker and pb another.
 --   AND trd.TradeDate = CAST(GETDATE() AS DATE) 
    AND (ft.TransmittedOn IS NULL OR ft.TransmittedOn < trd.BookedOn)
	AND alloc.PortfolioId =@PortfolioId;
GO
/****** Object:  View [trans].[vwCMGLFND_vwTradesFileMSFSTR001_MS_TEST]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
















CREATE VIEW [trans].[vwCMGLFND_vwTradesFileMSFSTR001_MS_TEST] AS
SELECT 
    'TR001' AS TrasationType,
    trd.TradeStatus AS TransactionStatus,
    trd.BuySellIndicator AS [Buy/Sell],
    CASE 
        WHEN trd.BuySellIndicator='S' AND (alloc.PositionSide ='L' OR  alloc.PositionSide ='C') THEN 'L'
        WHEN trd.BuySellIndicator='S' AND alloc.PositionSide ='S' THEN 'S'
        WHEN trd.BuySellIndicator='B' AND alloc.PositionSide ='L' THEN 'L'
        WHEN trd.BuySellIndicator='B' AND (alloc.PositionSide ='S' OR  alloc.PositionSide ='C') THEN 'C' 
    END AS [Long/Short],
    '' AS [PositionType],
    'A' AS [TransLevel],
    alloc.TradeAllocationId AS [ClientRef#],
    CONCAT(trd.TradeId,'A') AS [Associated#],
    '038227591' AS [ExecAccount],
    '038QLFR53' AS [AccountId],
    trd.TradeDesk AS [ExecutionBroker],
    'B' AS [SecType],
    ins.Symbol AS [SecID],
    ins.[Name] as SecurityDescription,
    FORMAT(trd.TradeDate, 'MM/dd/yyyy') AS TradeDate,
    FORMAT(trd.fnAddBusinessDays(trd.TradeDate,1), 'MM/dd/yyyy') AS SettlementDate,
    ISNULL( trd.SettlementCurrency, trd.TradeCurrency) AS SettlementCurrency,
    '' AS ExchangeCode,
    ABS(alloc.Quantity) AS [Quantity],
	  CASE WHEN LEFT(ins.Symbol, 2)= 'JY' AND RIGHT(ins.Symbol, 6) = 'Curncy' THEN alloc.Price/100
	  WHEN LEFT(ins.Symbol, 2)= 'NO' AND RIGHT(ins.Symbol, 6) = 'Curncy' THEN alloc.Price/100
	  WHEN LEFT(ins.Symbol, 2)= 'SE' AND RIGHT(ins.Symbol, 6) = 'Curncy' THEN alloc.Price/100
	  WHEN LEFT(ins.Symbol, 2)= 'RA' AND RIGHT(ins.Symbol, 6) = 'Curncy' THEN alloc.Price/100
	  WHEN LEFT(ins.Symbol, 2)= 'HE' AND RIGHT(ins.Symbol, 6) = 'Curncy' THEN alloc.Price/100
	  WHEN LEFT(ins.Symbol, 2)= 'BR' AND RIGHT(ins.Symbol, 6) = 'Curncy' THEN alloc.Price/100
	 ELSE alloc.Price END AS PriceAmount,
    'G' AS PriceIndicator,
    CAST(ABS(trd.Principal) AS DECIMAL(24,2)) AS Principal,
    CAST(ABS(trd.BrokerCommission) AS DECIMAL(24,2)) AS CommissionAmount,
    'F' AS CommissionIndicator,
    ABS(ISNULL(trd.MiscFees,0)) AS [Tax/Fees],
    '' AS [Tax2],
    'F' AS [FeeInd],
    '' AS [Interest],
    '' AS [InterestIndicator],
    CASE 
        WHEN trd.BuySellIndicator = 'S' THEN CAST(ABS(trd.Principal)- ABS(trd.BrokerCommission) AS DECIMAL(24,2))
        WHEN trd.BuySellIndicator = 'B' THEN CAST(ABS(trd.Principal)+ ABS(trd.BrokerCommission) AS DECIMAL(24,2))
    END AS NetAmount,
    'Y' AS [HearsayInd],
    'MSIL' AS [Custodian],
    '' AS [MoneyManager],
    '' AS [BookId],
    '' AS [DealId],
    '' AS [TaxLotId],
    '' AS [TaxDate],
    '' AS [TaxPrice],
    '' AS [CloseOutMethod],
    '' AS [ExRate],
    '' AS [AcqDate],
    '' AS [Comments]
FROM  
    [trans].[Trade] trd
JOIN 
    [trans].[TradeAllocation] alloc ON alloc.TradeId = trd.TradeId
JOIN 
    [trans].Instrument ins ON ins.InstrumentId = trd.InstrumentId
LEFT JOIN 
    trans.[vwLastFileTransmission] ft ON ft.TransmissionType = 'MSFSTR001TEST'
WHERE 
    ins.InstrumentType = 'FUT'
	AND trd.TradeDate = DATEADD(day,-3, CAST(GETDATE() AS DATE)) 
    AND trd.InstrumentId NOT IN (SELECT InstrumentId FROM trd.vwFutureSwap)
    AND (ft.TransmittedOn IS NULL OR ft.TransmittedOn < trd.BookedOn);
GO
/****** Object:  Table [wght].[Instrument]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [wght].[Instrument](
	[InstrumentId] [int] NOT NULL,
	[Symbol] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_InstrumentId] PRIMARY KEY CLUSTERED 
(
	[InstrumentId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [wght].[TargetWeight]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [wght].[TargetWeight](
	[TargetAllocationId] [int] NOT NULL,
	[InstrumentId] [int] NOT NULL,
	[Weight] [decimal](9, 6) NOT NULL,
 CONSTRAINT [PK_TargetWeightId] PRIMARY KEY CLUSTERED 
(
	[InstrumentId] ASC,
	[TargetAllocationId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [wght].[TargetAllocation]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [wght].[TargetAllocation](
	[TargetAllocationId] [int] IDENTITY(1,1) NOT NULL,
	[PortfolioId] [tinyint] NOT NULL,
	[GeneratedOn] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_TargeAllocationId] PRIMARY KEY CLUSTERED 
(
	[TargetAllocationId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [wght].[vwLastTargetAllocation]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
















/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [wght].[vwLastTargetAllocation] as
WITH RankedAllocations AS (
    SELECT 
        alloc.TargetAllocationId,
        alloc.GeneratedOn,
        alloc.PortfolioId,
        ROW_NUMBER() OVER(PARTITION BY alloc.PortfolioId ORDER BY alloc.TargetAllocationId DESC) AS rn
    FROM 
        [wght].[TargetAllocation] alloc
)
SELECT TOP 10000000
    wght.[TargetAllocationId],
	ins.InstrumentId,
    alloc.GeneratedOn,
    alloc.PortfolioId,
    ins.Symbol,
    [Weight]
FROM 
    [wght].[TargetWeight] wght
JOIN 
    RankedAllocations alloc ON alloc.TargetAllocationId = wght.TargetAllocationId
JOIN 
    wght.[Instrument] ins ON ins.InstrumentId = wght.InstrumentId
WHERE 
    alloc.rn = 1
ORDER BY   alloc.PortfolioId, ins.Symbol


GO
/****** Object:  Table [mktdata].[FxRate]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [mktdata].[FxRate](
	[BaseCurrency] [char](3) NOT NULL,
	[QuoteCurrency] [char](3) NOT NULL,
	[LastValue] [decimal](18, 6) NOT NULL,
	[LastValueEod] [decimal](18, 6) NOT NULL,
	[LastUpdateDate] [date] NOT NULL,
	[LastUpdateDateEod] [date] NOT NULL,
	[LastUpdateTime] [time](7) NULL,
 CONSTRAINT [PK_FXRate] PRIMARY KEY CLUSTERED 
(
	[BaseCurrency] ASC,
	[QuoteCurrency] ASC,
	[LastUpdateDateEod] DESC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [mktdata].[vwLastFxRate]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [mktdata].[vwLastFxRate] as
WITH RankedFXRates AS (
    SELECT
        BaseCurrency,
        QuoteCurrency,
        [LastUpdateDate],
        [LastValue],
        ROW_NUMBER() OVER (PARTITION BY BaseCurrency, QuoteCurrency ORDER BY [LastUpdateDate] DESC) AS rn
    FROM
        mktdata.FxRate
)

SELECT
    BaseCurrency,
    QuoteCurrency,
    [LastUpdateDate],
        [LastValue]
FROM
    RankedFXRates
WHERE
    rn = 1;



GO
/****** Object:  View [trans].[vwCMGLFND_vwTradesFileMSFSTR001_GS_TEST]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
















CREATE VIEW [trans].[vwCMGLFND_vwTradesFileMSFSTR001_GS_TEST] AS
SELECT 
    'TR001' AS TrasationType,
    trd.TradeStatus AS TransactionStatus,
    trd.BuySellIndicator AS [Buy/Sell],
    CASE 
        WHEN trd.BuySellIndicator='S' AND (alloc.PositionSide ='L' OR  alloc.PositionSide ='C') THEN 'L'
        WHEN trd.BuySellIndicator='S' AND alloc.PositionSide ='S' THEN 'S'
        WHEN trd.BuySellIndicator='B' AND alloc.PositionSide ='L' THEN 'L'
        WHEN trd.BuySellIndicator='B' AND (alloc.PositionSide ='S' OR  alloc.PositionSide ='C') THEN 'C' 
    END AS [Long/Short],
    '' AS [PositionType],
    'A' AS [TransLevel],
    alloc.TradeAllocationId AS [ClientRef#],
    CONCAT(trd.TradeId,'A') AS [Associated#],
    '038227591' AS [ExecAccount],
    '038QLFR53' AS [AccountId],
    'GSET' AS [ExecutionBroker],
    'B' AS [SecType],
    ins.Symbol AS [SecID],
    ins.[Name] as SecurityDescription,
    FORMAT(trd.TradeDate, 'MM/dd/yyyy') AS TradeDate,
    FORMAT(trd.fnAddBusinessDays(trd.TradeDate,1), 'MM/dd/yyyy') AS SettlementDate,
    ISNULL( trd.SettlementCurrency, trd.TradeCurrency) AS SettlementCurrency,
    '' AS ExchangeCode,
    ABS(alloc.Quantity) AS [Quantity],
	  CASE WHEN LEFT(ins.Symbol, 2)= 'JY' AND RIGHT(ins.Symbol, 6) = 'Curncy' THEN alloc.Price/100
	  WHEN LEFT(ins.Symbol, 2)= 'NO' AND RIGHT(ins.Symbol, 6) = 'Curncy' THEN alloc.Price/100
	  WHEN LEFT(ins.Symbol, 2)= 'SE' AND RIGHT(ins.Symbol, 6) = 'Curncy' THEN alloc.Price/100
	  WHEN LEFT(ins.Symbol, 2)= 'RA' AND RIGHT(ins.Symbol, 6) = 'Curncy' THEN alloc.Price/100
	  WHEN LEFT(ins.Symbol, 2)= 'HE' AND RIGHT(ins.Symbol, 6) = 'Curncy' THEN alloc.Price/100
	  WHEN LEFT(ins.Symbol, 2)= 'BR' AND RIGHT(ins.Symbol, 6) = 'Curncy' THEN alloc.Price/100
	 ELSE alloc.Price END AS PriceAmount,
    'G' AS PriceIndicator,
    CAST(ABS(trd.Principal) AS DECIMAL(24,2)) AS Principal,
    CAST(ABS(trd.BrokerCommission) AS DECIMAL(24,2)) AS CommissionAmount,
    'F' AS CommissionIndicator,
    ABS(ISNULL(trd.MiscFees,0)) AS [Tax/Fees],
    '' AS [Tax2],
    'F' AS [FeeInd],
    '' AS [Interest],
    '' AS [InterestIndicator],
    CASE 
        WHEN trd.BuySellIndicator = 'S' THEN CAST(ABS(trd.Principal)- ABS(trd.BrokerCommission) AS DECIMAL(24,2))
        WHEN trd.BuySellIndicator = 'B' THEN CAST(ABS(trd.Principal)+ ABS(trd.BrokerCommission) AS DECIMAL(24,2))
    END AS NetAmount,
    'Y' AS [HearsayInd],
    'GSIN' AS [Custodian],
    '' AS [MoneyManager],
    '' AS [BookId],
    '' AS [DealId],
    '' AS [TaxLotId],
    '' AS [TaxDate],
    '' AS [TaxPrice],
    '' AS [CloseOutMethod],
    '' AS [ExRate],
    '' AS [AcqDate],
    '' AS [Comments]
FROM  
    [trans].[Trade] trd
JOIN 
    [trans].[TradeAllocation] alloc ON alloc.TradeId = trd.TradeId
JOIN 
    [trans].Instrument ins ON ins.InstrumentId = trd.InstrumentId
LEFT JOIN 
    trans.[vwLastFileTransmission] ft ON ft.TransmissionType = 'MSFSTR001TEST'
WHERE 
    ins.InstrumentType = 'FUT'
	AND trd.TradeDate = DATEADD(day,-3, CAST(GETDATE() AS DATE)) 
    AND trd.InstrumentId NOT IN (SELECT InstrumentId FROM trd.vwFutureSwap)
    AND (ft.TransmittedOn IS NULL OR ft.TransmittedOn < trd.BookedOn);
GO
/****** Object:  View [mktdata].[vwLastFxRateEod]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [mktdata].[vwLastFxRateEod] as
WITH RankedFXRates AS (
    SELECT
        BaseCurrency,
        QuoteCurrency,
        [LastUpdateDateEod],
        [LastValueEod],
        ROW_NUMBER() OVER (PARTITION BY BaseCurrency, QuoteCurrency ORDER BY [LastUpdateDateEod] DESC) AS rn
    FROM
        mktdata.FxRate
)

SELECT
    BaseCurrency,
    QuoteCurrency,
    [LastUpdateDateEod],
        [LastValueEod]
FROM
    RankedFXRates
WHERE
    rn = 1;



GO
/****** Object:  Table [instr].[Calendar_H]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [instr].[Calendar_H](
	[CalendarDate] [date] NOT NULL,
	[DayOfMonthNum] [tinyint] NOT NULL,
	[DaySuffix] [char](2) NOT NULL,
	[DayOfWeekName] [nvarchar](9) NOT NULL,
	[DayOfWeekNum] [tinyint] NOT NULL,
	[DayOfWeekInMonthNum] [tinyint] NOT NULL,
	[DayOfYearNum] [smallint] NOT NULL,
	[IsWeekend] [bit] NOT NULL,
	[WeekOfYearNum] [tinyint] NOT NULL,
	[ISOWeekOfYearNum] [tinyint] NOT NULL,
	[FirstDateOfWeek] [date] NOT NULL,
	[LastDateOfWeek] [date] NOT NULL,
	[WeekOfMonthNum] [tinyint] NOT NULL,
	[MonthOfTheYearNum] [tinyint] NOT NULL,
	[MonthOfYearName] [nvarchar](9) NOT NULL,
	[FirstDateOfMonth] [date] NOT NULL,
	[LastDateOfMonth] [date] NOT NULL,
	[FirstDateOfNextMonth] [date] NOT NULL,
	[LastDateOfNextMonth] [date] NOT NULL,
	[QuarterNum] [tinyint] NOT NULL,
	[FirstDateOfQuarter] [date] NOT NULL,
	[LastDateOfQuarter] [date] NOT NULL,
	[CalendarYear] [smallint] NULL,
	[ISOCalendarYearValue] [smallint] NULL,
	[FirstDateOfYear] [date] NOT NULL,
	[LastDateOfYear] [date] NOT NULL,
	[IsLeapYear] [bit] NOT NULL,
	[Has53Weeks] [bit] NOT NULL,
	[Has53ISOWeeks] [bit] NOT NULL,
	[IsIMMDate] [bit] NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_Calendar_H]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_Calendar_H] ON [instr].[Calendar_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [instr].[Calendar]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [instr].[Calendar](
	[CalendarDate] [date] NOT NULL,
	[DayOfMonthNum] [tinyint] NOT NULL,
	[DaySuffix] [char](2) NOT NULL,
	[DayOfWeekName] [nvarchar](9) NOT NULL,
	[DayOfWeekNum] [tinyint] NOT NULL,
	[DayOfWeekInMonthNum] [tinyint] NOT NULL,
	[DayOfYearNum] [smallint] NOT NULL,
	[IsWeekend] [bit] NOT NULL,
	[WeekOfYearNum] [tinyint] NOT NULL,
	[ISOWeekOfYearNum] [tinyint] NOT NULL,
	[FirstDateOfWeek] [date] NOT NULL,
	[LastDateOfWeek] [date] NOT NULL,
	[WeekOfMonthNum] [tinyint] NOT NULL,
	[MonthOfTheYearNum] [tinyint] NOT NULL,
	[MonthOfYearName] [nvarchar](9) NOT NULL,
	[FirstDateOfMonth] [date] NOT NULL,
	[LastDateOfMonth] [date] NOT NULL,
	[FirstDateOfNextMonth] [date] NOT NULL,
	[LastDateOfNextMonth] [date] NOT NULL,
	[QuarterNum] [tinyint] NOT NULL,
	[FirstDateOfQuarter] [date] NOT NULL,
	[LastDateOfQuarter] [date] NOT NULL,
	[CalendarYear] [smallint] NULL,
	[ISOCalendarYearValue] [smallint] NULL,
	[FirstDateOfYear] [date] NOT NULL,
	[LastDateOfYear] [date] NOT NULL,
	[IsLeapYear] [bit] NOT NULL,
	[Has53Weeks] [bit] NOT NULL,
	[Has53ISOWeeks] [bit] NOT NULL,
	[IsIMMDate] [bit] NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_Calendar] PRIMARY KEY CLUSTERED 
(
	[CalendarDate] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [instr].[Calendar_H])
)
GO
/****** Object:  View [mktdata].[vwLastPrice]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO











/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [mktdata].[vwLastPrice] as
  WITH RankedMarketData AS (
    SELECT[InstrumentId],
        [LastPrice],
        [LastUpdateDate],
        [LastUpdateTime],
		Currency,
        ROW_NUMBER() OVER (PARTITION BY [InstrumentId] ORDER BY [LastUpdateDate]DESC,[LastUpdateTime]DESC,Currency ) AS rn
    FROM
        [mktdata].[MarketData]
)

SELECT
   mkt.[InstrumentId],
   ins.Symbol,
        [LastPrice],
        [LastUpdateDate],
        [LastUpdateTime],
		mkt.Currency,
		ins.QuoteCurrency,
		ins.QuoteFactor,
		ins.PriceScalingFactor
FROM
    RankedMarketData mkt
	JOIN mktdata.Instrument ins on ins.InstrumentId = mkt.InstrumentId
WHERE
    rn = 1;



GO
/****** Object:  Table [ord].[RoutingChannel_H]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[RoutingChannel_H](
	[RoutingChannelId] [tinyint] NOT NULL,
	[Mnemonic] [nvarchar](10) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_RoutingChannel_H]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_RoutingChannel_H] ON [ord].[RoutingChannel_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [ord].[RoutingChannel]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[RoutingChannel](
	[RoutingChannelId] [tinyint] IDENTITY(1,1) NOT NULL,
	[Mnemonic] [nvarchar](10) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_RoutingChannel] PRIMARY KEY CLUSTERED 
(
	[RoutingChannelId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [ord].[RoutingChannel_H])
)
GO
/****** Object:  View [mktdata].[vwLastPriceEod]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO










/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [mktdata].[vwLastPriceEod] as
  WITH RankedMarketData AS (
    SELECT[InstrumentId],
        [LastPriceEod],
        [LastUpdateDateEod],
    Currency,
        ROW_NUMBER() OVER (PARTITION BY [InstrumentId] ORDER BY [LastUpdateDateEod] DESC) AS rn
    FROM
        [mktdata].[MarketData]
)

SELECT
   mkt.[InstrumentId],
     ins.Symbol,
        [LastPriceEod],
        [LastUpdateDateEod],
		mkt.Currency
FROM
    RankedMarketData mkt
	JOIN mktdata.Instrument ins on ins.InstrumentId = mkt.InstrumentId
WHERE
    rn = 1;



GO
/****** Object:  Table [efrp].[GenericFuture]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [efrp].[GenericFuture](
	[GenericFutureId] [int] NOT NULL,
	[Symbol] [nvarchar](30) NOT NULL,
	[RootSymbol] [nvarchar](5) NOT NULL,
	[ContractSize] [decimal](18, 6) NOT NULL,
	[PointValue] [decimal](14, 6) NOT NULL,
 CONSTRAINT [PK_GenericFutureId] PRIMARY KEY CLUSTERED 
(
	[GenericFutureId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [exec].[EfrpConversionRule_H]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [exec].[EfrpConversionRule_H](
	[EfrpConversionRuleId] [int] NOT NULL,
	[GenericFutureId] [int] NOT NULL,
	[BrokerId] [int] NOT NULL,
	[BaseCurrency] [char](3) NOT NULL,
	[QuoteCurrency] [char](3) NOT NULL,
	[CmeClearportTicker] [nvarchar](5) NULL,
	[IsActive] [bit] NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_EfrpConversionRule_H]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_EfrpConversionRule_H] ON [exec].[EfrpConversionRule_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [efrp].[EfrpConversionRule]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [efrp].[EfrpConversionRule](
	[EfrpConversionRuleId] [int] IDENTITY(1,1) NOT NULL,
	[GenericFutureId] [int] NOT NULL,
	[BrokerId] [int] NOT NULL,
	[BaseCurrency] [char](3) NOT NULL,
	[QuoteCurrency] [char](3) NOT NULL,
	[CmeClearportTicker] [nvarchar](5) NULL,
	[IsActive] [bit] NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_EfrpConversionRule] PRIMARY KEY CLUSTERED 
(
	[EfrpConversionRuleId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [exec].[EfrpConversionRule_H])
)
GO
/****** Object:  View [efrp].[vwEfrpConversionRule]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO









/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [efrp].[vwEfrpConversionRule] as
SELECT  [EfrpConversionRuleId]
      ,gen.[GenericFutureId]
	  ,gen.RootSymbol
	  ,gen.Symbol
	  ,gen.ContractSize
      ,[BrokerId]
      ,[BaseCurrency]
      ,[QuoteCurrency]
      ,[CmeClearportTicker]
      ,[IsActive]
      ,[ValidFrom]
      ,[ValidTo]
  FROM [efrp].[EfrpConversionRule] r
  JOIN efrp.GenericFuture gen on gen.GenericFutureId = r.GenericFutureId



GO
/****** Object:  Table [rebal].[PortfolioDrift]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rebal].[PortfolioDrift](
	[PortfolioDriftId] [int] IDENTITY(1,1) NOT NULL,
	[PortfolioId] [tinyint] NOT NULL,
	[PortfolioValuationId] [int] NOT NULL,
	[TargetAllocationId] [int] NOT NULL,
	[TargetAllocationValuationId] [int] NOT NULL,
	[PortfolioNetExposure] [decimal](18, 6) NOT NULL,
	[TargetNetExposure] [decimal](18, 6) NOT NULL,
	[NetExposureDrift] [decimal](18, 6) NOT NULL,
	[PortfolioGrossExposure] [decimal](18, 6) NOT NULL,
	[TargetGrossExposure] [decimal](18, 6) NOT NULL,
	[GrossExposureDrift] [decimal](18, 6) NOT NULL,
	[ComputedOn] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_PortfolioDrift] PRIMARY KEY CLUSTERED 
(
	[PortfolioDriftId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [rebal].[Instrument]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rebal].[Instrument](
	[InstrumentId] [int] NOT NULL,
	[Symbol] [nvarchar](30) NOT NULL,
	[InstrumentType] [nvarchar](30) NOT NULL,
	[Currency] [char](3) NOT NULL,
 CONSTRAINT [PK_InstrumentId] PRIMARY KEY CLUSTERED 
(
	[InstrumentId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [rebal].[PositionDrift]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rebal].[PositionDrift](
	[PortfolioDriftId] [int] NOT NULL,
	[InstrumentId] [int] NOT NULL,
	[TargetWeight] [decimal](18, 6) NOT NULL,
	[CurrentWeight] [decimal](18, 6) NOT NULL,
	[WeightDrift] [decimal](18, 6) NOT NULL,
	[TargetQuantity] [int] NOT NULL,
	[CurrentQuantity] [int] NOT NULL,
	[QuantityDrift] [int] NOT NULL,
 CONSTRAINT [PK_PositionDrift] PRIMARY KEY CLUSTERED 
(
	[PortfolioDriftId] ASC,
	[InstrumentId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [rebal].[vwPositionDrift]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO












/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [rebal].[vwPositionDrift] as
SELECT p.[PortfolioDriftId]
	,d.PortfolioId
	,d.TargetAllocationId
	,d.PortfolioValuationId
	,d.TargetAllocationValuationId
	,d.PortfolioGrossExposure
	,d.TargetGrossExposure
	,d.GrossExposureDrift
	,d.PortfolioNetExposure
	,d.TargetNetExposure
	,d.NetExposureDrift
      ,p.[InstrumentId]
	  ,i.Symbol
	  ,i.InstrumentType
      ,[TargetWeight]
      ,[CurrentWeight]
      ,[WeightDrift]
      ,[TargetQuantity]
      ,[CurrentQuantity]
      ,[QuantityDrift]
	  ,d.ComputedOn
  FROM [rebal].[PositionDrift] p
  JOIn [rebal].PortfolioDrift d on d.[PortfolioDriftId] = p.[PortfolioDriftId]
  JOIn [rebal].Instrument i on i.InstrumentId = p.InstrumentId



GO
/****** Object:  View [rebal].[vwLastPositionDrift]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO














/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [rebal].[vwLastPositionDrift] as
WITH LastPortfolioDrift as(
SELECT  MAX([PortfolioDriftId]) as [PortfolioDriftId], MAX(ComputedOn) as  ComputedOn , PortfolioId  FROM rebal.PortfolioDrift
group by PortfolioId
)

SELECT  p.[PortfolioDriftId]
      ,p.[PortfolioId]
      ,[TargetAllocationId]
      ,[PortfolioValuationId]
      ,[TargetAllocationValuationId]
      ,[PortfolioGrossExposure]
      ,[TargetGrossExposure]
      ,[GrossExposureDrift]
      ,[PortfolioNetExposure]
      ,[TargetNetExposure]
      ,[NetExposureDrift]
      ,[InstrumentId]
      ,[Symbol]
      ,[InstrumentType]
      ,[TargetWeight]
      ,[CurrentWeight]
      ,[WeightDrift]
      ,[TargetQuantity]
      ,[CurrentQuantity]
      ,[QuantityDrift]
	  ,l.ComputedOn
  FROM [rebal].[vwPositionDrift] p
  JOIN LastPortfolioDrift l on l.[PortfolioDriftId]=p.[PortfolioDriftId]
GO
/****** Object:  Table [ord].[Portfolio]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[Portfolio](
	[PortfolioId] [tinyint] NOT NULL,
	[Mnemonic] [nvarchar](6) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Currency] [char](3) NOT NULL,
 CONSTRAINT [PK_PortfolioId] PRIMARY KEY CLUSTERED 
(
	[PortfolioId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ord].[H_OrderAllocation]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[H_OrderAllocation](
	[OrderAllocationId] [int] NOT NULL,
	[OrderId] [int] NOT NULL,
	[PortfolioId] [tinyint] NOT NULL,
	[Quantity] [int] NOT NULL,
	[TradingAccountId] [int] NOT NULL,
	[PositionSideId] [tinyint] NOT NULL,
	[ValidFrom] [datetime2](7) NOT NULL,
	[ValidTo] [datetime2](7) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_H_OrderAllocation]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_H_OrderAllocation] ON [ord].[H_OrderAllocation]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [ord].[OrderAllocation]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[OrderAllocation](
	[OrderAllocationId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[PortfolioId] [tinyint] NOT NULL,
	[Quantity] [int] NOT NULL,
	[TradingAccountId] [int] NOT NULL,
	[PositionSideId] [tinyint] NOT NULL,
	[ValidFrom] [datetime2](7) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](7) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_OrderAllocation] PRIMARY KEY CLUSTERED 
(
	[OrderAllocationId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_OrderAllocation] UNIQUE NONCLUSTERED 
(
	[OrderId] ASC,
	[PortfolioId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [ord].[H_OrderAllocation])
)
GO
/****** Object:  Table [ord].[PositionSide_H]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[PositionSide_H](
	[PositionSideId] [tinyint] NOT NULL,
	[Mnemonic] [nvarchar](2) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_PositionSide_H]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_PositionSide_H] ON [ord].[PositionSide_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [ord].[PositionSide]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[PositionSide](
	[PositionSideId] [tinyint] IDENTITY(1,1) NOT NULL,
	[Mnemonic] [nvarchar](2) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_PositionSide] PRIMARY KEY CLUSTERED 
(
	[PositionSideId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [ord].[PositionSide_H])
)
GO
/****** Object:  View [ord].[vwOrderAllocation]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO













/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [ord].[vwOrderAllocation] as
SELECT  [OrderAllocationId]
       ,o.[OrderId]
      ,o.[RebalancingSessionId]
      ,o.[InstrumentId]
      ,o.[Symbol]
      ,o.[Name]as [InstrumentName]
      ,o.[Currency]
      ,o.[Exchange]
      ,o.[MarketSector]
      ,o.[InstrumentType]
      ,o.[OrderSide]
      ,o.[Quantity] as [OrderQuantity]
      ,o.[BrokerCode]
      ,o.[BrokerName]
      ,o.[OrderType]
      ,o.[TimeInForce]
      ,[ExecutionAlgorithmId]
      ,[ExecutionAlgo]
      ,[HandlingInstructionId]
      ,[HandlingInstruction]
      ,[ExecutionChannelId]
      ,[ExecutionChannel]
      ,[TradeModeId]
      ,[TradeMode]
      ,[TradeDate]
      ,[TradingDesk]     
      ,alloc.[PortfolioId]
      , ptf.Currency as PortfolioCurrency
	  , ptf.Name as PotfolioName
	  ,ptf.Mnemonic as PotfolioMnemonic
	  ,alloc.[Quantity] as [AllocationQuantity]
      ,alloc.[TradingAccountId]
	  ,ta.Code as TradingAccountCode
      ,alloc.[PositionSideId]
	  ,ps.Mnemonic as PositionSide
	  ,o.CreatedOn
  FROM [ord].[OrderAllocation] alloc
  JOIN [ord].[vwOrder] o on o.OrderId = alloc.OrderId
  JOIN [ord].[PositionSide] ps on ps.PositionSideId =  alloc.PositionSideId
  JOIN [ord].[TradingAccount] ta on ta.TradingAccountId = alloc.TradingAccountId
  JOIN [ord].Portfolio ptf on ptf.PortfolioId = alloc.PortfolioId



GO
/****** Object:  View [ord].[vwCompareWithPositionDrift]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO











/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [ord].[vwCompareWithPositionDrift] as
SELECT lpd.Symbol,
lpd.QuantityDrift,
oa.AllocationQuantity,
IIF(lpd.QuantityDrift <>oa.AllocationQuantity,1,0) as IsMismatch
  FROM [ord].[vwOrderAllocation] oa
  JOin rebal.vwLastPositionDrift lpd on lpd.Symbol = oa.Symbol



GO
/****** Object:  Table [trans].[H_FtpConfiguration]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[H_FtpConfiguration](
	[FtpConfigurationId] [int] NOT NULL,
	[Host] [nvarchar](255) NOT NULL,
	[Port] [int] NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](30) NOT NULL,
	[IsSftp] [bit] NOT NULL,
	[RemoteFolder] [nvarchar](100) NOT NULL,
	[ValidFrom] [datetime2](7) NOT NULL,
	[ValidTo] [datetime2](7) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_H_FtpConfiguration]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_H_FtpConfiguration] ON [trans].[H_FtpConfiguration]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [trans].[FtpConfiguration]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[FtpConfiguration](
	[FtpConfigurationId] [int] NOT NULL,
	[Host] [nvarchar](255) NOT NULL,
	[Port] [int] NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](30) NOT NULL,
	[IsSftp] [bit] NOT NULL,
	[RemoteFolder] [nvarchar](100) NOT NULL,
	[ValidFrom] [datetime2](7) GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
	[ValidTo] [datetime2](7) GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
 CONSTRAINT [PK_FtpConfiguration] PRIMARY KEY CLUSTERED 
(
	[FtpConfigurationId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [trans].[H_FtpConfiguration])
)
GO
/****** Object:  Table [rebal].[RebalancingSessionPortfolioDrift]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rebal].[RebalancingSessionPortfolioDrift](
	[RebalancingSessionId] [int] NOT NULL,
	[PortfolioDriftId] [int] NOT NULL,
 CONSTRAINT [PK_RebalancingSessionPortfolioDrift] PRIMARY KEY CLUSTERED 
(
	[RebalancingSessionId] ASC,
	[PortfolioDriftId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [port].[Instrument]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [port].[Instrument](
	[InstrumentId] [int] NOT NULL,
	[Symbol] [nvarchar](30) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[InstrumentType] [nvarchar](8) NOT NULL,
	[MarketSector] [nvarchar](6) NOT NULL,
	[Currency] [char](3) NOT NULL,
 CONSTRAINT [PK_InstrumentId] PRIMARY KEY CLUSTERED 
(
	[InstrumentId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [port].[Portfolio_H]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [port].[Portfolio_H](
	[PortfolioId] [tinyint] NOT NULL,
	[Mnemonic] [nvarchar](6) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Currency] [char](3) NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_Portfolio_H]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_Portfolio_H] ON [port].[Portfolio_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [port].[Portfolio]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [port].[Portfolio](
	[PortfolioId] [tinyint] IDENTITY(1,1) NOT NULL,
	[Mnemonic] [nvarchar](6) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Currency] [char](3) NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_PortfolioId] PRIMARY KEY CLUSTERED 
(
	[PortfolioId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_Portfolio_Mnemonic] UNIQUE NONCLUSTERED 
(
	[Mnemonic] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [port].[Portfolio_H])
)
GO
/****** Object:  Table [port].[Position]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [port].[Position](
	[PortfolioId] [tinyint] NOT NULL,
	[InstrumentId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[AvgEntryPriceLocal] [decimal](18, 6) NOT NULL,
	[PositionValueLocal] [decimal](24, 6) NOT NULL,
	[GrossTotalCostLocal] [decimal](18, 6) NOT NULL,
	[NetTotalCostLocal] [decimal](18, 6) NOT NULL,
	[LastTradeAllocationId] [int] NOT NULL,
	[PositionDate] [date] NOT NULL,
	[Currency] [char](3) NOT NULL,
	[IsSwap] [bit] NOT NULL,
	[TotalCommissionLocal] [decimal](18, 6) NULL,
 CONSTRAINT [PK_TestPosition] PRIMARY KEY CLUSTERED 
(
	[PortfolioId] DESC,
	[InstrumentId] ASC,
	[Currency] ASC,
	[IsSwap] ASC,
	[PositionDate] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [port].[vwPosition]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO












CREATE VIEW [port].[vwPosition] AS
SELECT  pos.[PortfolioId]
		,ptf.Mnemonic,
	    ptf.Currency as BaseCurrency
      ,pos.[InstrumentId]
	  ,pos.IsSwap
	  ,i.Symbol
	  ,i.InstrumentType
	  ,i.MarketSector
	  ,i.[Name] as  InstrumentName
      ,[Quantity]
      ,[AvgEntryPriceLocal]
      ,[PositionValueLocal]
      ,[GrossTotalCostLocal]
      ,[NetTotalCostLocal]
      ,[LastTradeAllocationId]
      ,[PositionDate]
      ,pos.[Currency]
  FROM [port].[Position] pos
  JOIN port.Instrument i on i.InstrumentId = pos.InstrumentId
  JOIN port.Portfolio ptf on ptf.PortfolioId = pos.PortfolioId

GO
/****** Object:  View [port].[vwLastPosition]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

















CREATE VIEW [port].[vwLastPosition] AS
 with lastPosition as (
select MAX([PositionDate]) as [PositionDate], PortfolioId from [port].[vwPosition]
GROUP BY PortfolioId
)
SELECT  p.[PortfolioId]
      ,[Mnemonic]
      ,[BaseCurrency]
      ,[InstrumentId]
	  ,[IsSwap]
      ,[Symbol]
      ,[InstrumentType]
      ,[MarketSector]
      ,[InstrumentName]
      ,[Quantity]
      ,[AvgEntryPriceLocal]
      ,[PositionValueLocal]
      ,[GrossTotalCostLocal]
      ,[NetTotalCostLocal]
      ,[LastTradeAllocationId]
      ,p.[PositionDate]
      ,[Currency]
 
  FROM [port].[vwPosition] p
  JOIN lastPosition d on d.[PositionDate] = p.[PositionDate] and d.PortfolioId = p.PortfolioId
GO
/****** Object:  UserDefinedFunction [check].[tvCompareLastPositionWithPositionDrift]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE FUNCTION [check].[tvCompareLastPositionWithPositionDrift] (@RebalId int)
RETURNS TABLE
AS
RETURN
(

SELECT pd.[PortfolioDriftId]
, rspd.RebalancingSessionId
      ,pd.[InstrumentId]
	  ,pd.Symbol
      ,[TargetWeight]
      ,[CurrentWeight]
      ,[WeightDrift]
	    ,[CurrentQuantity]
      ,[TargetQuantity]
	
      ,[QuantityDrift]
	  ,lp.Quantity as PositionQuantity
	  ,[TargetQuantity]-lp.Quantity as Mismatch
      
  FROM [rebal].[vwPositionDrift] pd
  JOIn rebal.RebalancingSessionPortfolioDrift rspd on rspd.PortfolioDriftId = pd.PortfolioDriftId
 LEFT JOIN port.vwLastPosition lp on lp.InstrumentId = pd.InstrumentId 
  where rspd.RebalancingSessionId =@RebalId
  )
GO
/****** Object:  Table [instr].[FxForward_H]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [instr].[FxForward_H](
	[FxForwardId] [int] NOT NULL,
	[CurrencyPairId] [int] NOT NULL,
	[MaturityDate] [date] NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_FxForward_H]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_FxForward_H] ON [instr].[FxForward_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [instr].[FxForward]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [instr].[FxForward](
	[FxForwardId] [int] NOT NULL,
	[CurrencyPairId] [int] NOT NULL,
	[MaturityDate] [date] NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_FxForward] PRIMARY KEY CLUSTERED 
(
	[FxForwardId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_FxForward] UNIQUE NONCLUSTERED 
(
	[CurrencyPairId] ASC,
	[MaturityDate] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [instr].[FxForward_H])
)
GO
/****** Object:  Table [roll].[Position]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [roll].[Position](
	[PortfolioId] [tinyint] NOT NULL,
	[GenericId] [int] NOT NULL,
	[ContractId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[PositionDate] [date] NOT NULL,
	[Currency] [char](3) NOT NULL,
	[IsSwap] [bit] NOT NULL,
 CONSTRAINT [PK_Position] PRIMARY KEY CLUSTERED 
(
	[PortfolioId] DESC,
	[ContractId] ASC,
	[Currency] ASC,
	[PositionDate] ASC,
	[IsSwap] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [roll].[FutureContract]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [roll].[FutureContract](
	[FutureContractId] [int] NOT NULL,
	[Symbol] [nvarchar](30) NOT NULL,
	[GenericFutureId] [int] NOT NULL,
	[LastTradeDate] [date] NOT NULL,
	[FirstNoticeDate] [date] NOT NULL,
	[FirstDeliveryDate] [date] NOT NULL,
	[RollDate] [date] NOT NULL,
	[Volume] [decimal](18, 6) NULL,
 CONSTRAINT [PK_FutureContractId] PRIMARY KEY CLUSTERED 
(
	[FutureContractId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [roll].[vwFutureContractRollInfo]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




















/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [roll].[vwFutureContractRollInfo] as
WITH BusinessDays AS (
    SELECT
        FutureContractId,
        Symbol,
        GenericFutureId,
        LEAST([FirstNoticeDate], [LastTradeDate]) AS MaturityDate,
        CASE 
            WHEN DATEPART(WEEKDAY, LEAST([FirstNoticeDate], [LastTradeDate])) = 1 THEN DATEADD(DAY, -9, LEAST([FirstNoticeDate], [LastTradeDate]))
            WHEN DATEPART(WEEKDAY, LEAST([FirstNoticeDate], [LastTradeDate])) = 2 THEN DATEADD(DAY, -10, LEAST([FirstNoticeDate], [LastTradeDate]))
            ELSE DATEADD(DAY, -8, LEAST([FirstNoticeDate], [LastTradeDate]))
        END AS RollingPeriodStartDate,
        Volume
    FROM [roll].[FutureContract]
    WHERE LEAST([FirstNoticeDate], [LastTradeDate]) >= GETDATE()
), currentcontract as(
    SELECT 
        GenericFutureId,
        FutureContractId as CurrentContractId,
        Volume,
		MaturityDate,
		Symbol,
		RollingPeriodStartDate,
	
		DATEDIFF(DAY, GETDATE(), MaturityDate) as DayToLastRollingDate,
        DATEDIFF(DAY, GETDATE(), RollingPeriodStartDate) as DayToFirstRollingDate,
        ROW_NUMBER() OVER(PARTITION BY GenericFutureId ORDER BY Volume DESC, MaturityDate) AS RankNum,
		CASE 
            WHEN GETDATE() BETWEEN RollingPeriodStartDate AND MaturityDate THEN 1
            ELSE 0
        END AS IsBusinessDayRoll,
		CASE 
            WHEN Volume = 0 THEN 1
            ELSE 0
        END AS IsLiquidityLow
    FROM BusinessDays
	where  GETDATE()<RollingPeriodStartDate)

	select top(100000) * from currentcontract
	 where RankNum =1 
	order by Symbol


GO
/****** Object:  View [roll].[vwFuturePositionRollInfo]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



























/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [roll].[vwFuturePositionRollInfo] as
with contractmapping as (SELECT [GenericFutureId]

	  ,[CurrentContractId] 

  FROM [roll].[vwFutureContractRollInfo])
SELECT  [PortfolioId]
,p.ContractId as PositionCurrentContractId
,fc.Symbol as  PositionCurrentSymbol
,fc.Volume as CurrentContractVolume
,fc.LastTradeDate
,fc.FirstNoticeDate
		,cm.[CurrentContractId] as ToContractId
      ,fc2.Symbol as ToSymbol
	  ,fc2.Volume as ToVolume
	  ,[Quantity]
	  
      ,[PositionDate]
      ,[Currency]
	 , iif(p.ContractId <> cm.[CurrentContractId] , 1, 0) as IsRolling
  FROM [roll].[Position] p
  JOIN roll.FutureContract fc on fc.FutureContractId = p.ContractId
  JOIN contractmapping cm on cm.[GenericFutureId] =fc.[GenericFutureId]
    JOIN roll.FutureContract fc2 on fc2.FutureContractId = cm.[CurrentContractId]




GO
/****** Object:  Table [book].[H_RawTrade]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [book].[H_RawTrade](
	[TradeId] [int] NOT NULL,
	[Symbol] [nvarchar](30) NOT NULL,
	[Side] [nvarchar](10) NOT NULL,
	[Quantity] [int] NOT NULL,
	[AvgPrice] [decimal](20, 8) NOT NULL,
	[Currency] [char](3) NOT NULL,
	[TradeDate] [date] NOT NULL,
	[Exchange] [nvarchar](5) NULL,
	[ExecutionBroker] [nvarchar](10) NOT NULL,
	[ExecutionAccount] [nvarchar](10) NOT NULL,
	[ExecutionDesk] [nvarchar](10) NOT NULL,
	[IsCFD] [bit] NOT NULL,
	[Cusip] [nvarchar](10) NULL,
	[Isin] [nvarchar](12) NULL,
	[Sedol] [nvarchar](20) NULL,
	[SecurityName] [nvarchar](100) NULL,
	[LocalExchangeSymbol] [nvarchar](20) NULL,
	[ExecutionChannel] [nvarchar](10) NOT NULL,
	[EmsxOrderId] [int] NULL,
	[OrderReferenceId] [int] NULL,
	[OrderQuantity] [int] NULL,
	[OrderType] [nvarchar](20) NULL,
	[StrategyType] [nvarchar](10) NULL,
	[Tif] [nvarchar](10) NULL,
	[OrderExecutionInstruction] [nvarchar](100) NULL,
	[OrderHandlingInstruction] [nvarchar](100) NULL,
	[OrderInstruction] [nvarchar](100) NULL,
	[LimitPrice] [decimal](18, 6) NULL,
	[StopPrice] [decimal](18, 6) NULL,
	[OriginatingTraderUUId] [int] NULL,
	[TraderName] [nvarchar](20) NULL,
	[TraderUUId] [int] NULL,
	[SettlementDate] [date] NULL,
	[UserCommissionAmount] [decimal](18, 6) NULL,
	[UserCommissionRate] [decimal](18, 6) NULL,
	[UserFees] [decimal](18, 6) NULL,
	[UserNetMoney] [decimal](18, 6) NULL,
	[YellowKey] [nvarchar](10) NULL,
	[NumberOfFills] [tinyint] NULL,
	[FirstFillTimeUtc] [datetime] NULL,
	[LastFillTimeUtc] [datetime] NULL,
	[MaxFillPrice] [decimal](18, 6) NULL,
	[MinFillPrice] [decimal](18, 6) NULL,
	[ValidFrom] [datetime2](7) NOT NULL,
	[ValidTo] [datetime2](7) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_H_RawTrade]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_H_RawTrade] ON [book].[H_RawTrade]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [book].[RawTrade]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [book].[RawTrade](
	[TradeId] [int] IDENTITY(1,1) NOT NULL,
	[Symbol] [nvarchar](30) NOT NULL,
	[Side] [nvarchar](10) NOT NULL,
	[Quantity] [int] NOT NULL,
	[AvgPrice] [decimal](20, 8) NOT NULL,
	[Currency] [char](3) NOT NULL,
	[TradeDate] [date] NOT NULL,
	[Exchange] [nvarchar](5) NULL,
	[ExecutionBroker] [nvarchar](10) NOT NULL,
	[ExecutionAccount] [nvarchar](10) NOT NULL,
	[ExecutionDesk] [nvarchar](10) NOT NULL,
	[IsCFD] [bit] NOT NULL,
	[Cusip] [nvarchar](10) NULL,
	[Isin] [nvarchar](12) NULL,
	[Sedol] [nvarchar](20) NULL,
	[SecurityName] [nvarchar](100) NULL,
	[LocalExchangeSymbol] [nvarchar](20) NULL,
	[ExecutionChannel] [nvarchar](10) NOT NULL,
	[EmsxOrderId] [int] NULL,
	[OrderReferenceId] [int] NULL,
	[OrderQuantity] [int] NULL,
	[OrderType] [nvarchar](20) NULL,
	[StrategyType] [nvarchar](10) NULL,
	[Tif] [nvarchar](10) NULL,
	[OrderExecutionInstruction] [nvarchar](100) NULL,
	[OrderHandlingInstruction] [nvarchar](100) NULL,
	[OrderInstruction] [nvarchar](100) NULL,
	[LimitPrice] [decimal](18, 6) NULL,
	[StopPrice] [decimal](18, 6) NULL,
	[OriginatingTraderUUId] [int] NULL,
	[TraderName] [nvarchar](20) NULL,
	[TraderUUId] [int] NULL,
	[SettlementDate] [date] NULL,
	[UserCommissionAmount] [decimal](18, 6) NULL,
	[UserCommissionRate] [decimal](18, 6) NULL,
	[UserFees] [decimal](18, 6) NULL,
	[UserNetMoney] [decimal](18, 6) NULL,
	[YellowKey] [nvarchar](10) NULL,
	[NumberOfFills] [tinyint] NULL,
	[FirstFillTimeUtc] [datetime] NULL,
	[LastFillTimeUtc] [datetime] NULL,
	[MaxFillPrice] [decimal](18, 6) NULL,
	[MinFillPrice] [decimal](18, 6) NULL,
	[ValidFrom] [datetime2](7) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](7) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_RawTrade] PRIMARY KEY CLUSTERED 
(
	[TradeId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [book].[H_RawTrade])
)
GO
/****** Object:  Table [book].[TradeBookingError]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [book].[TradeBookingError](
	[TradeBookingErrorId] [int] IDENTITY(1,1) NOT NULL,
	[TradeId] [int] NOT NULL,
	[ErrorType] [nvarchar](20) NOT NULL,
	[Message] [nvarchar](500) NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_TradeBookingError] PRIMARY KEY CLUSTERED 
(
	[TradeBookingErrorId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [book].[vwTradeBookingError]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



















/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [book].[vwTradeBookingError] as
SELECT[TradeBookingErrorId]
      ,trd.[TradeId]
	  ,trd.Side
	  ,trd.Symbol
	  ,trd.Quantity
	  ,trd.TradeDate
      ,[ErrorType]
      ,[Message]
      ,[CreatedOn]
  FROM [book].[TradeBookingError] err
  JOIN [book].[RawTrade] trd on trd.TradeId = err.TradeId
GO
/****** Object:  View [check].[vwCheckPositionDriftsVSOrderQuantities]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO













/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [check].[vwCheckPositionDriftsVSOrderQuantities] as
SELECT lpd.Symbol,
lpd.PortfolioDriftId,
oa.RebalancingSessionId,
lpd.QuantityDrift as PositionDrift,
oa.AllocationQuantity as OrderQuantity,
IIF(lpd.QuantityDrift <>oa.AllocationQuantity,1,0) as IsMismatch
  FROM [ord].[vwOrderAllocation] oa
  JOin rebal.vwLastPositionDrift lpd on lpd.Symbol = oa.Symbol



GO
/****** Object:  Table [mktdata].[VolumeData]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [mktdata].[VolumeData](
	[InstrumentId] [int] NOT NULL,
	[Volume1Day] [decimal](18, 6) NULL,
	[LastUpdateDate] [date] NOT NULL,
	[LastUpdateTime] [time](7) NULL,
 CONSTRAINT [PK_VolumeData] PRIMARY KEY CLUSTERED 
(
	[InstrumentId] ASC,
	[LastUpdateDate] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [mktdata].[vwLastVolumeData]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [mktdata].[vwLastVolumeData] as
  WITH RankedVolumeData AS (
      SELECT InstrumentId
      ,[Volume1Day]
	  ,[LastUpdateDate]
      ,ROW_NUMBER() OVER (PARTITION BY [InstrumentId] ORDER BY [LastUpdateDate] DESC) AS rn
      ,[LastUpdateTime]
  FROM [mktdata].[VolumeData]
      
)

SELECT v.[InstrumentId]
		, i.Symbol
      ,[Volume1Day]
      ,[LastUpdateDate]
      ,[LastUpdateTime]
  FROM RankedVolumeData v
  JOIN mktdata.Instrument i  on i.InstrumentId = v.InstrumentId
WHERE
    rn = 1;



GO
/****** Object:  Table [book].[H_ExecutionTypeMapping]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [book].[H_ExecutionTypeMapping](
	[ExecutionDeskId] [int] NOT NULL,
	[Strategy] [nvarchar](15) NOT NULL,
	[ExecutionTypeId] [int] NOT NULL,
	[ValidFrom] [datetime2](7) NOT NULL,
	[ValidTo] [datetime2](7) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_H_ExecutionTypeMapping]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_H_ExecutionTypeMapping] ON [book].[H_ExecutionTypeMapping]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [book].[ExecutionTypeMapping]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [book].[ExecutionTypeMapping](
	[ExecutionDeskId] [int] NOT NULL,
	[Strategy] [nvarchar](15) NOT NULL,
	[ExecutionTypeId] [int] NOT NULL,
	[ValidFrom] [datetime2](7) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](7) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_ExecutionTypeMapping] PRIMARY KEY CLUSTERED 
(
	[ExecutionDeskId] ASC,
	[Strategy] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [book].[H_ExecutionTypeMapping])
)
GO
/****** Object:  Table [risk].[BooleanOperator_H]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [risk].[BooleanOperator_H](
	[BooleanOperatorId] [tinyint] NOT NULL,
	[Mnemonic] [nvarchar](20) NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_BooleanOperator_H]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_BooleanOperator_H] ON [risk].[BooleanOperator_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [risk].[BooleanOperator]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [risk].[BooleanOperator](
	[BooleanOperatorId] [tinyint] IDENTITY(1,1) NOT NULL,
	[Mnemonic] [nvarchar](20) NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_BooleanOperatorId] PRIMARY KEY CLUSTERED 
(
	[BooleanOperatorId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_BooleanOperatorMnemonic] UNIQUE NONCLUSTERED 
(
	[Mnemonic] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [risk].[BooleanOperator_H])
)
GO
/****** Object:  Table [trans].[H_EmailConfiguration]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[H_EmailConfiguration](
	[EmailConfigurationId] [int] NOT NULL,
	[Recipients] [nvarchar](max) NOT NULL,
	[EmailSubject] [varchar](255) NOT NULL,
	[MessageBody] [varchar](max) NULL,
	[AttachFile] [bit] NOT NULL,
	[ValidFrom] [datetime2](7) NOT NULL,
	[ValidTo] [datetime2](7) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_H_EmailConfiguration]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_H_EmailConfiguration] ON [trans].[H_EmailConfiguration]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [trans].[EmailConfiguration]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[EmailConfiguration](
	[EmailConfigurationId] [int] IDENTITY(1,1) NOT NULL,
	[Recipients] [nvarchar](max) NOT NULL,
	[EmailSubject] [varchar](255) NOT NULL,
	[MessageBody] [varchar](max) NULL,
	[AttachFile] [bit] NOT NULL,
	[ValidFrom] [datetime2](7) GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
	[ValidTo] [datetime2](7) GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
 CONSTRAINT [PK_EmailConfiguration] PRIMARY KEY CLUSTERED 
(
	[EmailConfigurationId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [trans].[H_EmailConfiguration])
)
GO
/****** Object:  Table [ordgen].[ExecutionAlgorithm_H]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ordgen].[ExecutionAlgorithm_H](
	[ExecutionAlgorithmId] [int] NOT NULL,
	[Mnmemonic] [nvarchar](10) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_ExecutionAlgorithm_H]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_ExecutionAlgorithm_H] ON [ordgen].[ExecutionAlgorithm_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [ordgen].[ExecutionAlgorithm]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ordgen].[ExecutionAlgorithm](
	[ExecutionAlgorithmId] [int] IDENTITY(1,1) NOT NULL,
	[Mnmemonic] [nvarchar](10) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_ExecutionAlgorithm] PRIMARY KEY CLUSTERED 
(
	[ExecutionAlgorithmId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [ordgen].[ExecutionAlgorithm_H])
)
GO
/****** Object:  View [ord].[vwFxForwardOrdersToFxgo]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO











/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [ord].[vwFxForwardOrdersToFxgo] as
SELECT 'Outright' as Instrument
	  ,LEFT(REPLACE(Symbol, '/',''),6) as CurrencyPair
      ,OrderSide as Side
	  ,'' as Tenor
      ,REPLACE(fwd.MaturityDate,'-','') as ValueDate
      ,ABS(Quantity) as Amount
      ,LEFT(Symbol,3) as Currency
	  --,'' as FarTenor
	  --,'' as FarValueDate
	  --,''as FarAmount
	  --,'' as FarCurrency
	  --,'' as Notes
	  ,'MS1FWD' as Account -- to be provided by ms
     
  FROM [ord].[vwOrder] o
  JOIN instr.FxForward fwd on fwd.FxForwardId = o.InstrumentId
  
  where ExecutionChannel = 'FXGO' and InstrumentType = 'FXFWD'
GO
/****** Object:  Table [trans].[TransmittedFile]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[TransmittedFile](
	[TransmittedFileId] [int] IDENTITY(1,1) NOT NULL,
	[FileTransmissionId] [int] NOT NULL,
	[FileName] [nvarchar](200) NOT NULL,
	[FilePath] [nvarchar](200) NOT NULL,
	[RowsCount] [int] NOT NULL,
 CONSTRAINT [PK_TransmittedFile] PRIMARY KEY CLUSTERED 
(
	[TransmittedFileId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [trans].[vwTransmittedFile]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






















/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [trans].[vwTransmittedFile] as
SELECT  f.[TransmittedFileId]
      ,f.[FileTransmissionId]
	  , t.ContentType
	  , t.Counterparty
	  ,t.IsFtpTransmitted
	  ,t.TransmittedOn
	  ,t.TransmissionType
	  ,t.IsEmailTransmitted
      ,[FileName]
      ,[FilePath]
      ,[RowsCount]
  FROM [trans].[TransmittedFile] f
  JOIN [trans].FileTransmission t on t.FileTransmissionId = f.[FileTransmissionId]
GO
/****** Object:  Table [instr].[FutureContractMonth_H]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [instr].[FutureContractMonth_H](
	[FutureContractMonthId] [tinyint] NOT NULL,
	[Code] [char](1) NOT NULL,
	[Mnemonic] [varchar](3) NOT NULL,
	[Name] [nvarchar](10) NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_FutureContractMonth_H]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_FutureContractMonth_H] ON [instr].[FutureContractMonth_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [instr].[FutureContractMonth]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [instr].[FutureContractMonth](
	[FutureContractMonthId] [tinyint] IDENTITY(1,1) NOT NULL,
	[Code] [char](1) NOT NULL,
	[Mnemonic] [varchar](3) NOT NULL,
	[Name] [nvarchar](10) NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_FutureContractMonthId] PRIMARY KEY CLUSTERED 
(
	[FutureContractMonthId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [instr].[FutureContractMonth_H])
)
GO
/****** Object:  View [trd].[vwDailyBookedTrade]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO











/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [trd].[vwDailyBookedTrade] as
SELECT  [TradeId]
      ,[OrderId]
      ,[RebalancingId]
      ,[EmsxSequence]
      ,[EmsxOrderCreatedOn]
      ,[InstrumentId]
      ,[Symbol]
      ,[InstrumentType]
      ,[ExchangeCode]
      ,[Sedol]
      ,[BuySellIndicator]
      ,[OrderQuantity]
      ,[FilledQuantity]
      ,[AvgPrice]
      ,[DayAveragePrice]
      ,[TradeCurrency]
      ,[TradeDate]
      ,[Principal]
      ,[NetAmount]
      ,[SettlementDate]
      ,[SettlementCurrency]
      ,[BrokerCommission]
      ,[CommissionRate]
      ,[MiscFees]
      ,[Notes]
      ,[Trader]
      ,[BrokerCode]
      ,[TradeDesk]
      ,[IsCfd]
	  ,IsFutureSwap
      ,[ExecutionChannel]
      ,[CreatedOn]
      ,[TotalCharges]
      ,[FxemTradeId]
      ,[FxemOrderId]
      ,[TradeStatus]
      ,[FxCurrency1]
      ,[FXCurrency1Amount]
      ,[FxCurrency2]
      ,[FXCurrency2Amount]
      ,[BookedOn]
  FROM [trd].[vwTrade]
  where cast(BookedOn as date) >=  cast(GETUTCDATE() as date)
GO
/****** Object:  Table [ordgen].[ExecutionChannel_H]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ordgen].[ExecutionChannel_H](
	[ExecutionChannelId] [tinyint] NOT NULL,
	[Mnemonic] [nvarchar](10) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_ExecutionChannel_H]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_ExecutionChannel_H] ON [ordgen].[ExecutionChannel_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [ordgen].[ExecutionChannel]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ordgen].[ExecutionChannel](
	[ExecutionChannelId] [tinyint] IDENTITY(1,1) NOT NULL,
	[Mnemonic] [nvarchar](10) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_ExecutionChannel] PRIMARY KEY CLUSTERED 
(
	[ExecutionChannelId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [ordgen].[ExecutionChannel_H])
)
GO
/****** Object:  Table [conv].[Instrument]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [conv].[Instrument](
	[InstrumentId] [int] NOT NULL,
	[Symbol] [nvarchar](30) NOT NULL,
	[InstrumentType] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_InstrumentId] PRIMARY KEY CLUSTERED 
(
	[InstrumentId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [conv].[InstrumentMappingType_H]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [conv].[InstrumentMappingType_H](
	[InstrumentMappingTypeId] [tinyint] NOT NULL,
	[Mnemonic] [nvarchar](30) NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_InstrumentMappingType_H]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_InstrumentMappingType_H] ON [conv].[InstrumentMappingType_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [conv].[InstrumentMappingType]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [conv].[InstrumentMappingType](
	[InstrumentMappingTypeId] [tinyint] IDENTITY(1,1) NOT NULL,
	[Mnemonic] [nvarchar](30) NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_InstrumentMappingType] PRIMARY KEY CLUSTERED 
(
	[InstrumentMappingTypeId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_InstrumentType_Mnemonic] UNIQUE NONCLUSTERED 
(
	[Mnemonic] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [conv].[InstrumentMappingType_H])
)
GO
/****** Object:  Table [conv].[InstrumentMapping_H]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [conv].[InstrumentMapping_H](
	[FromInstrumentId] [int] NOT NULL,
	[ToInstrumentId] [int] NOT NULL,
	[InstrumentMappingTypeId] [tinyint] NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_InstrumentMapping_H]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_InstrumentMapping_H] ON [conv].[InstrumentMapping_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [conv].[InstrumentMapping]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [conv].[InstrumentMapping](
	[FromInstrumentId] [int] NOT NULL,
	[ToInstrumentId] [int] NOT NULL,
	[InstrumentMappingTypeId] [tinyint] NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_InstrumentMapping] PRIMARY KEY CLUSTERED 
(
	[FromInstrumentId] ASC,
	[InstrumentMappingTypeId] ASC,
	[ToInstrumentId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [conv].[InstrumentMapping_H])
)
GO
/****** Object:  View [conv].[vwInstrumentMapping]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO









/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [conv].[vwInstrumentMapping] as
SELECT  [FromInstrumentId]
,fromIns.Symbol as FromSymbol
      ,[ToInstrumentId]
	  ,ToIns.Symbol as ToSymbol
      ,map.[InstrumentMappingTypeId]
	  ,tp.Mnemonic

  FROM [conv].[InstrumentMapping] map
  JOIN conv.Instrument fromIns on fromIns.InstrumentId = map.FromInstrumentId
  JOIN conv.Instrument ToIns on ToIns.InstrumentId = map.ToInstrumentId
  JOIN conv.InstrumentMappingType tp on tp.InstrumentMappingTypeId = map.InstrumentMappingTypeId



GO
/****** Object:  Table [instr].[FutureContract_H]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [instr].[FutureContract_H](
	[FutureContractId] [int] NOT NULL,
	[GenericFutureId] [int] NOT NULL,
	[FutureContractMonthId] [tinyint] NOT NULL,
	[ContractYear] [int] NOT NULL,
	[LastTradeDate] [date] NOT NULL,
	[FirstNoticeDate] [date] NOT NULL,
	[FirstDeliveryDate] [date] NOT NULL,
	[RollDate] [date] NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_FutureContract_H]    Script Date: 6/26/2024 1:49:55 PM ******/
CREATE CLUSTERED INDEX [ix_FutureContract_H] ON [instr].[FutureContract_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [instr].[FutureContract]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [instr].[FutureContract](
	[FutureContractId] [int] NOT NULL,
	[GenericFutureId] [int] NOT NULL,
	[FutureContractMonthId] [tinyint] NOT NULL,
	[ContractYear] [int] NOT NULL,
	[LastTradeDate] [date] NOT NULL,
	[FirstNoticeDate] [date] NOT NULL,
	[FirstDeliveryDate] [date] NOT NULL,
	[RollDate] [date] NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_FutureContractId] PRIMARY KEY CLUSTERED 
(
	[FutureContractId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_FutureContract] UNIQUE NONCLUSTERED 
(
	[GenericFutureId] ASC,
	[FutureContractMonthId] ASC,
	[ContractYear] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [instr].[FutureContract_H])
)
GO
/****** Object:  Table [ordgen].[HandlingInstruction_H]    Script Date: 6/26/2024 1:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ordgen].[HandlingInstruction_H](
	[HandlingInstructionId] [int] NOT NULL,
	[Code] [nvarchar](10) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_HandlingInstruction_H]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_HandlingInstruction_H] ON [ordgen].[HandlingInstruction_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [ordgen].[HandlingInstruction]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ordgen].[HandlingInstruction](
	[HandlingInstructionId] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](10) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_HandlingInstruction] PRIMARY KEY CLUSTERED 
(
	[HandlingInstructionId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [ordgen].[HandlingInstruction_H])
)
GO
/****** Object:  Table [trans].[H_TransmissionScheduleType]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[H_TransmissionScheduleType](
	[TransmissionScheduleTypeId] [int] NOT NULL,
	[Mnemonic] [nvarchar](10) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[ValidFrom] [datetime2](7) NOT NULL,
	[ValidTo] [datetime2](7) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_H_TransmissionScheduleType]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_H_TransmissionScheduleType] ON [trans].[H_TransmissionScheduleType]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [trans].[TransmissionScheduleType]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[TransmissionScheduleType](
	[TransmissionScheduleTypeId] [int] NOT NULL,
	[Mnemonic] [nvarchar](10) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[ValidFrom] [datetime2](7) GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
	[ValidTo] [datetime2](7) GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
 CONSTRAINT [PK_TransmissionScheduleType] PRIMARY KEY CLUSTERED 
(
	[TransmissionScheduleTypeId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [trans].[H_TransmissionScheduleType])
)
GO
/****** Object:  Table [risk].[FilterPartyType_H]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [risk].[FilterPartyType_H](
	[FilterPartyTypeId] [tinyint] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Mnemonic] [nvarchar](5) NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_FilterPartyType_H]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_FilterPartyType_H] ON [risk].[FilterPartyType_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [risk].[FilterPartyType]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [risk].[FilterPartyType](
	[FilterPartyTypeId] [tinyint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Mnemonic] [nvarchar](5) NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_FilterPartyTypeId] PRIMARY KEY CLUSTERED 
(
	[FilterPartyTypeId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [risk].[FilterPartyType_H])
)
GO
/****** Object:  Table [trd].[FxemTrade]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trd].[FxemTrade](
	[Header] [nvarchar](50) NULL,
	[Trade_ID] [nvarchar](50) NULL,
	[Date_Time] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
	[Product] [nvarchar](50) NULL,
	[Deal_Type] [nvarchar](50) NULL,
	[Ccys] [nvarchar](50) NULL,
	[Side] [nvarchar](50) NULL,
	[Amount_Ccy1] [nvarchar](50) NULL,
	[Ccy] [nvarchar](50) NULL,
	[Amount_Ccy2] [nvarchar](50) NULL,
	[Contra_Ccy] [nvarchar](50) NULL,
	[Trade_Date] [nvarchar](50) NULL,
	[Value_Date] [nvarchar](50) NULL,
	[All_In_Rate] [nvarchar](50) NULL,
	[Spot_Rate] [nvarchar](50) NULL,
	[Fwd_Points] [nvarchar](50) NULL,
	[Deal_Code] [nvarchar](50) NULL,
	[Account] [nvarchar](50) NULL,
	[Counterparty] [nvarchar](50) NULL,
	[RebalancingId] [nvarchar](50) NULL,
	[PortfolioId] [nvarchar](50) NULL,
	[PositionSide] [nvarchar](50) NULL,
	[FXEM_Order_ID] [nvarchar](50) NULL,
	[Trader] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  View [trd].[vwFxemTradeToBook]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [trd].[vwFxemTradeToBook] as
WITH FwdTrades AS (
    SELECT
        [Header],
        [Trade_ID],
        i.InstrumentId,
        i.Symbol,
        i.MaturityDate,
        i.MarketSector,
        CAST([Date_Time] AS DATETIME2) AS [Date_Time],
        [Status],
        [Product],
        [Deal_Type],
        [Ccys] AS CurrencyPair,
        LEFT(TRIM(REPLACE([Side], 'CFQQ', '')), 1) AS Side,
        CAST([Amount_Ccy1] AS DECIMAL(24,6)) AS [Amount_Ccy1],
        [Ccy] AS Ccy1,
        CAST([Amount_Ccy2] AS DECIMAL(24,6)) AS [Amount_Ccy2],
        [Contra_Ccy] AS Ccy2,
        CAST([Trade_Date] AS DATE) AS [Trade_Date],
        CAST([Value_Date] AS DATE) AS [Value_Date],
        CAST([All_In_Rate] AS DECIMAL(18,6)) AS [All_In_Rate],
        CAST([Spot_Rate] AS DECIMAL(18,6)) AS [Spot_Rate],
        CAST([Fwd_Points] AS DECIMAL(18,6)) AS [Fwd_Points],
        [Deal_Code],
        [Account],
        [Counterparty],
        CAST([RebalancingId] AS INT) AS [RebalancingId],
        CAST(PortfolioId AS INT) AS PortfolioId,
        [PositionSide],
        [FXEM_Order_ID],
        [Trader]

    FROM [trd].[FxemTrade] fxem
    LEFT JOIN trd.Instrument i 
        ON LEFT(i.Symbol,7) = fxem.[Ccys] 
        AND i.MaturityDate = fxem.Value_Date
    WHERE NULLIF(fxem.[Trade_ID], '') IS NOT NULL 
        AND ACCOUNT = 'MS1FWD'
)

SELECT 
    f.[FXEM_Order_ID] AS [FxemOrderId],
    f.RebalancingId,
    NULL AS [EmsxSequence],
    CAST(NULL AS DATE) AS [EmsxOrderCreatedOn],
    f.InstrumentId,
    NULL AS [ExchangeCode],
    NULL AS [Sedol],
    f.Side AS [BuySellIndicator],
    f.[Amount_Ccy1] AS [OrderQuantity], -- TODO: need the original quantity
    f.[Amount_Ccy1] AS [FilledQuantity],
    f.[All_In_Rate] AS [AvgPrice],      -- TODO: to be confirmed this is the right field
    NULL AS [DayAveragePrice],         -- TODO: need the original quantity
    f.[Ccy1] AS [TradeCurrency],
    f.[Trade_Date],
    f.[Amount_Ccy1] AS [Principal],
    f.[Amount_Ccy1] AS [NetAmount],
    cast(cast(NULL as nvarchar(12)) as date) AS [SettlementDate],
    NULL AS [SettlementCurrency],
    0 AS [BrokerCommission],
    0 AS [CommissionRate],
    0 AS [MiscFees],
    NULL AS [Notes],
    f.[Trader],
    f.[Deal_Code] AS [BrokerCode],     -- To be confirmed
    f.[Deal_Code] AS [TradeDesk],      -- To be confirmed
    0 AS [IsCfd],
    'FXGO' AS [ExecutionChannel],
    f.[Date_Time] AS [CreatedOn],
    0 AS [TotalCharges],
    f.Account,
    f.[Trade_ID] AS [FxemTradeId],
    f.Ccy1,
    f.[Amount_Ccy1],
    f.Ccy2,
    f.[Amount_Ccy2],
	f.PortfolioId,
	f.[PositionSide]
FROM FwdTrades f
LEFT JOIN trd.Trade trd 
    ON trd.FxemTradeId = f.[Trade_ID]
WHERE trd.TradeId IS NULL
GO
/****** Object:  Table [instr].[ConstinuousFuture_H]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [instr].[ConstinuousFuture_H](
	[GenericFutureId] [int] NOT NULL,
	[RootSymbol] [nvarchar](5) NOT NULL,
	[ContractSize] [decimal](18, 6) NOT NULL,
	[TickSize] [decimal](12, 6) NOT NULL,
	[TickValue] [decimal](12, 6) NOT NULL,
	[PointValue] [decimal](14, 6) NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_ConstinuousFuture_H]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_ConstinuousFuture_H] ON [instr].[ConstinuousFuture_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [instr].[GenericFuture]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [instr].[GenericFuture](
	[GenericFutureId] [int] NOT NULL,
	[RootSymbol] [nvarchar](5) NOT NULL,
	[ContractSize] [decimal](18, 6) NOT NULL,
	[TickSize] [decimal](12, 6) NOT NULL,
	[TickValue] [decimal](12, 6) NOT NULL,
	[PointValue] [decimal](14, 6) NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_GenericFutureId] PRIMARY KEY CLUSTERED 
(
	[GenericFutureId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [instr].[ConstinuousFuture_H])
)
GO
/****** Object:  View [instr].[vwGenericFuture]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [instr].[vwGenericFuture] as
SELECT  [GenericFutureId]
	  ,ins.[Symbol]
      ,ins.[Name]     
      ,ins.[Currency]  
      ,ins.[Exchange]
      ,ins.[ISIN]
      ,ins.[BbgGlobalId]
      ,ins.[BbgUniqueId]     
      ,ins.[Country]
      ,ins.[PrimaryMIC] 
      ,ins.[MarketSectorDes] 
	  ,ins.PriceScalingFactor
	  ,ins.QuoteCurrency
      ,[RootSymbol]
      ,[ContractSize]
      ,[TickSize]
      ,[TickValue]
      ,[PointValue]
  FROM [instr].[GenericFuture] fut
  JOIN [instr].[vwInstrument] ins on ins.InstrumentId = fut.GenericFutureId



GO
/****** Object:  View [instr].[vwFutureContract]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [instr].[vwFutureContract] as
SELECT fut.[FutureContractId]	          
      ,ins.[Symbol]
      ,ins.[Name]     
      ,ins.[Currency]  
      ,ins.[Exchange]
      ,ins.[ISIN]
      ,ins.[BbgGlobalId]
      ,ins.[BbgUniqueId]     
      ,ins.[Country]
      ,ins.[PrimaryMIC] 
      ,ins.[MarketSectorDes]     
      ,ins.PriceScalingFactor
	  ,ins.QuoteCurrency
	  ,fut.[GenericFutureId]
	  
	  ,gf.Symbol as GenericFutureSymbol
	  ,gf.[RootSymbol]
      ,gf.[ContractSize]
      ,gf.[TickSize]
      ,gf.[TickValue]
      ,gf.[PointValue]
      ,fut.[FutureContractMonthId]
	  ,fcm.Mnemonic as MonthCode
	  ,fcm.Code as MonthMnemonic
	  ,fcm.Name as [MonthName]
      ,fut.[ContractYear]
      ,fut.[LastTradeDate]
      ,fut.[FirstNoticeDate]
      ,fut.[FirstDeliveryDate]
      ,fut.[RollDate]
 
  FROM [instr].[FutureContract] fut
  JOIN [instr].[FutureContractMonth] fcm on fcm.FutureContractMonthId =fut.[FutureContractMonthId]
  JOIN [instr].[vwGenericFuture] gf on gf.GenericFutureId = fut.GenericFutureId
  JOIN [instr].[vwInstrument] ins on ins.InstrumentId = fut.FutureContractId


GO
/****** Object:  Table [book].[H_RawTradeAllocation]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [book].[H_RawTradeAllocation](
	[TradeAllocationId] [int] NOT NULL,
	[TradeId] [int] NOT NULL,
	[PortfolioId] [tinyint] NOT NULL,
	[AllocatedQuantity] [int] NOT NULL,
	[OrderAllocationQuantity] [int] NOT NULL,
	[PositionSide] [char](1) NOT NULL,
	[ValidFrom] [datetime2](7) NOT NULL,
	[ValidTo] [datetime2](7) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_H_RawTradeAllocation]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_H_RawTradeAllocation] ON [book].[H_RawTradeAllocation]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [book].[RawTradeAllocation]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [book].[RawTradeAllocation](
	[TradeAllocationId] [int] IDENTITY(1,1) NOT NULL,
	[TradeId] [int] NOT NULL,
	[PortfolioId] [tinyint] NOT NULL,
	[AllocatedQuantity] [int] NOT NULL,
	[OrderAllocationQuantity] [int] NOT NULL,
	[PositionSide] [char](1) NOT NULL,
	[ValidFrom] [datetime2](7) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](7) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_RawTradeAllocation] PRIMARY KEY CLUSTERED 
(
	[TradeAllocationId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_RawTradeAllocation] UNIQUE NONCLUSTERED 
(
	[TradeId] ASC,
	[PortfolioId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [book].[H_RawTradeAllocation])
)
GO
/****** Object:  View [book].[vwNonAllocatedTrade]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO












/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [book].[vwNonAllocatedTrade] as
  SELECT  rawtrd.[TradeId]
      ,rawtrd.[Symbol]
     ,rawtrd.TradeDate
  FROM [book].[RawTrade] rawtrd
  LEFT JOIN book.RawTradeAllocation alloc on alloc.TradeId = rawtrd.TradeId
  where alloc.PortfolioId is null

GO
/****** Object:  View [book].[vwNonBookedTrade]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO












/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [book].[vwNonBookedTrade] as
SELECT  rawtrd.[TradeId]
      ,rawtrd.[Symbol]
     ,rawtrd.TradeDate
  FROM [book].[RawTrade] rawtrd
  LEFT JOIN book.Trade booked on booked.TradeId = rawtrd.TradeId
  where booked.TradeId is null


GO
/****** Object:  Table [instr].[CurrencyPair_H]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [instr].[CurrencyPair_H](
	[CurrencyPairId] [int] NOT NULL,
	[BaseCurrencyId] [tinyint] NOT NULL,
	[QuoteCurrencyId] [tinyint] NOT NULL,
	[QuoteFactor] [decimal](12, 6) NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_CurrencyPair_H]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_CurrencyPair_H] ON [instr].[CurrencyPair_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [instr].[CurrencyPair]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [instr].[CurrencyPair](
	[CurrencyPairId] [int] NOT NULL,
	[BaseCurrencyId] [tinyint] NOT NULL,
	[QuoteCurrencyId] [tinyint] NOT NULL,
	[QuoteFactor] [decimal](12, 6) NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_CurrencyPair] PRIMARY KEY CLUSTERED 
(
	[CurrencyPairId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_CurrencyPair] UNIQUE NONCLUSTERED 
(
	[BaseCurrencyId] ASC,
	[QuoteCurrencyId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [instr].[CurrencyPair_H])
)
GO
/****** Object:  View [instr].[vwCurrencyPair]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [instr].[vwCurrencyPair] as
SELECT  [CurrencyPairId]
	  ,ins.[Symbol]
      ,ins.[Name]     
      ,ins.[Currency]  
      ,ins.[Exchange]
      ,ins.[ISIN]
      ,ins.[BbgGlobalId]
      ,ins.[BbgUniqueId]     
      ,ins.[Country]
      ,ins.[PrimaryMIC] 
      ,ins.[MarketSectorDes] 
      ,cp.[BaseCurrencyId]
	  , ccy1.Code as BaseCurrencyCode
      ,cp.[QuoteCurrencyId]
	  ,ccy2.Code as QuoteCurrencyCode
      ,ins.[QuoteFactor]
  FROM [instr].[CurrencyPair] cp
  JOIN [instr].Currency ccy1 on ccy1.CurrencyId = cp.[BaseCurrencyId]
  JOIN [instr].Currency ccy2 on ccy2.CurrencyId = cp.[QuoteCurrencyId]
  JOIN [instr].[vwInstrument] ins on ins.InstrumentId = cp.CurrencyPairId



GO
/****** Object:  Table [book].[H_CounterpartyRoleSetup]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [book].[H_CounterpartyRoleSetup](
	[CounterpartyRoleSetupId] [int] NOT NULL,
	[ClearingBrokerId] [int] NOT NULL,
	[PrimeBrokerId] [int] NULL,
	[CustodianId] [int] NULL,
	[ValidFrom] [datetime2](7) NOT NULL,
	[ValidTo] [datetime2](7) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_H_CounterpartyRoleSetup]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_H_CounterpartyRoleSetup] ON [book].[H_CounterpartyRoleSetup]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [book].[CounterpartyRoleSetup]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [book].[CounterpartyRoleSetup](
	[CounterpartyRoleSetupId] [int] IDENTITY(1,1) NOT NULL,
	[ClearingBrokerId] [int] NOT NULL,
	[PrimeBrokerId] [int] NULL,
	[CustodianId] [int] NULL,
	[ValidFrom] [datetime2](7) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](7) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_CounterpartyRoleSetup] PRIMARY KEY CLUSTERED 
(
	[CounterpartyRoleSetupId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_CounterpartyRoleSetup] UNIQUE NONCLUSTERED 
(
	[ClearingBrokerId] ASC,
	[PrimeBrokerId] ASC,
	[CustodianId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [book].[H_CounterpartyRoleSetup])
)
GO
/****** Object:  View [instr].[vwFxForward]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [instr].[vwFxForward] as
SELECT [FxForwardId]
      ,fxfwd.[CurrencyPairId]
	  ,ins.[Symbol]
      ,ins.[Name]     
      ,ins.[Currency]  
      ,ins.[Exchange]
      ,ins.[ISIN]
      ,ins.[BbgGlobalId]
      ,ins.[BbgUniqueId]     
      ,ins.[Country]
      ,ins.[PrimaryMIC] 
      ,ins.[MarketSectorDes] 
	  ,cp.Symbol as  CurrencyPairSymbol
	  ,cp.BaseCurrencyCode
	  ,cp.QuoteCurrencyCode
	  ,ins.QuoteFactor
      ,[MaturityDate] 
  FROM [instr].[FxForward] fxfwd
  JOIN [instr].[vwInstrument] ins on ins.InstrumentId = fxfwd.[FxForwardId]
  JOIN [instr].[vwCurrencyPair] cp on cp.CurrencyPairId = fxfwd.[CurrencyPairId]



GO
/****** Object:  Table [trd].[MSEfrpTradeAffirm]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trd].[MSEfrpTradeAffirm](
	[Account] [nvarchar](50) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Ccy1_Side] [nvarchar](50) NOT NULL,
	[Ccy1] [nvarchar](50) NOT NULL,
	[Ccy1_Amt] [nvarchar](50) NOT NULL,
	[Ccy2_Side] [nvarchar](50) NOT NULL,
	[Ccy2] [nvarchar](50) NOT NULL,
	[Ccy2_Amt] [nvarchar](50) NOT NULL,
	[Spot_Rate] [nvarchar](50) NOT NULL,
	[Trade_Date] [nvarchar](50) NOT NULL,
	[Value_Date] [nvarchar](50) NOT NULL,
	[Entry_User] [nvarchar](50) NOT NULL,
	[Deal_ID] [nvarchar](50) NOT NULL,
	[Last_Update_Time] [nvarchar](50) NULL,
	[Deal_Entry_Time] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  View [trd].[vwEfrpTrade]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO









/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [trd].[vwEfrpTrade] as
WITH aggregated AS (
    SELECT 
        [Type] AS Exchange,
        [Ccy1_Side] + ' Curncy' AS Symbol,
        [Ccy1_Amt] AS BuySellIndicator,
        SUM(SIGN([Ccy2_Amt]) * CAST([Ccy2_Side] AS INT)) AS Quantity,
        [Ccy2] AS Currency,
        SUM(CAST([Ccy2_Amt] AS DECIMAL(24,8))) AS [Ccy2_Amt],
        SUM(CAST([Spot_Rate] AS DECIMAL(18,8))* CAST([Ccy2_Side] AS INT))  AS [Spot_Rate],
        [Trade_Date]
    FROM 
        [trd].[MSEfrpTradeAffirm]
    WHERE 
        Account = 'Future'
    GROUP BY 
        [Type], [Ccy1_Side], [Ccy1], [Ccy1_Amt], [Ccy2], [Trade_Date]
),

Priced AS (
    SELECT 
        f.[Exchange],
        i.InstrumentId,
        i.GenericFutureId,
        i.FuturePointValue,
        i.[Symbol],
        BuySellIndicator,
        [Quantity],
        f.[Currency],
        [Ccy2_Amt],
        [Spot_Rate]/[Quantity] as [Spot_Rate],
        [Trade_Date],
        ABS(([Ccy2_Amt] / [Quantity]) / i.FuturePointValue * ([Spot_Rate]/[Quantity]))  AS AvgPrice,
		i.Currency as InstrumentCurrency
    FROM 
        aggregated f
    JOIN 
        trd.Instrument i ON i.Symbol = f.[Symbol]
),

WithPrincipal AS (
    SELECT 
        f.[Exchange],
        f.InstrumentId,
        f.GenericFutureId,
        f.FuturePointValue,
        f.[Symbol],
        f.BuySellIndicator,
        f.[Quantity],
        f.[Currency],
        f.[Ccy2_Amt],
        f.[Spot_Rate],
        f.[Trade_Date],
        f.AvgPrice,
        f.AvgPrice * f.[Quantity] * f.FuturePointValue AS Principal,
		InstrumentCurrency

    FROM 
        Priced f
),

WithCommissions AS (
    SELECT 
        f.[Exchange],
        f.InstrumentId,
        f.GenericFutureId,
        f.FuturePointValue,
        f.[Symbol],
        f.BuySellIndicator,
        f.[Quantity],
        f.[Currency],
        f.[Ccy2_Amt],
        f.[Spot_Rate],
        f.[Trade_Date],
        f.AvgPrice,
        f.Principal,
		f.InstrumentCurrency,
        ABS(ISNULL(c.CommPerLot*Quantity,  c.CommRate * f.Principal)) AS BrokerCommm,
         ABS(ISNULL(c.CommRate, 0)) AS CommmRate,
        0 AS MiscFees
    FROM 
        WithPrincipal f
    LEFT JOIN 
        trd.FutureCommission c ON c.GenericFutureId = f.GenericFutureId AND c.BrokerCode = 'MSET'
)

SELECT 
    f.[Exchange],
    f.InstrumentId,
    f.GenericFutureId,
    f.FuturePointValue,
    f.[Symbol],
    LEFT(f.BuySellIndicator, 1) AS BuySellIndicator,
    f.[Quantity],
    f.[Currency],
    f.[Ccy2_Amt],
    f.[Spot_Rate],
    cast(f.[Trade_Date] AS date) as [Trade_Date],
    f.AvgPrice,
    f.Principal,
    (f.Principal) + ABS(f.BrokerCommm) AS NetAmount,
    f.BrokerCommm,
    f.CommmRate,
    f.MiscFees,
	f.InstrumentCurrency
FROM 
    WithCommissions f;


GO
/****** Object:  Table [ord].[BrokerSelectionRule_H]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[BrokerSelectionRule_H](
	[BrokerSelectionRuleId] [int] NOT NULL,
	[PortfolioId] [tinyint] NULL,
	[InstrumentTypeId] [tinyint] NULL,
	[BrokerId] [int] NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_BrokerSelectionRule_H]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_BrokerSelectionRule_H] ON [ord].[BrokerSelectionRule_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [ord].[BrokerSelectionRule]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[BrokerSelectionRule](
	[BrokerSelectionRuleId] [int] IDENTITY(1,1) NOT NULL,
	[PortfolioId] [tinyint] NULL,
	[InstrumentTypeId] [tinyint] NULL,
	[BrokerId] [int] NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_BrokerSelectionRule] PRIMARY KEY CLUSTERED 
(
	[BrokerSelectionRuleId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [ord].[BrokerSelectionRule_H])
)
GO
/****** Object:  View [trd].[vwEfrpTradeToBook]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO











/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [trd].[vwEfrpTradeToBook] as
    SELECT
		t.TradeId,
        null as EmsxSequence,
        o.OrderId AS OrderId,
        o.RebalancingSessionId AS RebalancingId,
        null as EmsxDate,
        e.InstrumentId,
		e.Symbol,
		e.BuySellIndicator AS Side, -- S or B
        o.PositionSide AS PositionSide,
        e.Quantity AS OrderQuantity,
        e.Quantity AS FilledQuantity,
        e.Exchange as  ExchangeCode,
        null as Sedol,
        o.TradingAccountCode as Account, -- to be reviewed when we implement allocations
		e.[BrokerCommm] AS TotalCharges,
        e.[Trade_Date] AS TradeDate,
        e.Principal,
        e.NetAmount,
        o.PortfolioId AS PortfolioId, -- to be reviewed when we implement allocations
        e.AvgPrice,
        null as DayAvgPrice,
        e.Currency AS TradeCurrency,
        null as OrderType,
        null as TimeInForce,
        null as Strategy,
        null as HandlingInstruction,
       cast( cast(null as nvarchar(12))as date) as SettlementDate,
        e.InstrumentCurrency as SettlementCurrency,
        e.[BrokerCommm] as  [BrokerCommission],
        e.CommmRate as CommissionRate,
        e.MiscFees,
        'EFRP' as Notes,
        null as Trader,
        'MSST' as [BrokerCode],
		  'MSST' as [TradeDesk],
        0 AS IsCfd,
        'FXEM' AS ExecutionChannel,
        null AS CreatedOn, -- Assuming this is the correct calculation
        IIF(e.InstrumentId IS NOT NULL, 1, 0) AS IsInstrumentMapped,
        IIF(t.TradeId IS NOT NULL, 1, 0) AS IsTradeAlreadyBooked
       
    FROM [trd].[vwEfrpTrade] e
    LEFT JOIN trd.Trade t ON t.InstrumentId = e.InstrumentId and t.TradeDate = e.[Trade_Date] and t.FilledQuantity = e.Quantity
	LEFT JOIN ord.vwOrderAllocation o on o.InstrumentId = e.InstrumentId and o.AllocationQuantity = e.Quantity and o.TradingAccountCode = 'MS1EFRP' and cast(o.TradeDate as date)= cast(e.Trade_Date AS date)


GO
/****** Object:  View [trans].[vwTradesFileMSSW002]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







-- select * from [trans].[vwTradesFileMSSW002]



CREATE VIEW [trans].[vwTradesFileMSSW002] AS
SELECT  
    'SW002' AS [Transaction Type],
    trd.TradeStatus AS [Transaction Status],
    trd.BuySellIndicator AS [Buy Sell Indicator],
    CASE 
        WHEN trd.BuySellIndicator = 'S' AND (alloc.PositionSide IN ('L', 'C')) THEN 'L'
        WHEN trd.BuySellIndicator = 'S' AND alloc.PositionSide = 'S' THEN 'S'
        WHEN trd.BuySellIndicator = 'B' AND alloc.PositionSide = 'L' THEN 'L'
        WHEN trd.BuySellIndicator = 'B' AND (alloc.PositionSide IN ('S', 'C')) THEN 'C'
    END AS [Long Short Indicator],
    '' AS [Position Type],
    'A' AS [Transaction Level],
    alloc.TradeAllocationId AS [Client Trade Ref No.],
    CONCAT(alloc.TradeId,'A') AS [Associated Trade Id],
    '038227674' AS [Execution Account],   
    '06178VV43' AS [Account Id],
    'MSSW' AS [Broker / Counterparty],
    IIF(trd.Sedol IS NULL OR TRIM(trd.Sedol) = '', 'B', 'S') AS [Security Identifier Type],
    IIF(trd.Sedol IS NULL OR TRIM(trd.Sedol) = '',
        IIF(CHARINDEX(' ', ins.Symbol) > 0, LEFT(ins.Symbol, CHARINDEX(' ', ins.Symbol) - 1), NULL),
        trd.Sedol) AS [SecurityIdentifier],
    ins.[Name] AS [Security Description],
    FORMAT(trd.[TradeDate], 'yyyy-MM-dd') AS [Trade Date],
    FORMAT(trd.fnAddBusinessDays(trd.TradeDate,IIF(ins.Symbol like '%Equity', 2,2)), 'yyyy-MM-dd') AS [Settlement Date], -- TGU 3 to 2
    ISNULL(fs.SettlementCurrency, trd.TradeCurrency) AS [Settlement CCY],
    '' AS [Exchange Code],
    ABS(FilledQuantity) AS [Quantity],
    ROUND(trd.AvgPrice, 5) AS [Price],
    'G' AS [Price Indicator],
    CAST(ABS(Principal) AS DECIMAL(24,2)) AS [Principal],
    CAST(trd.BrokerCommission AS DECIMAL(24,2)) AS [Execution Broker Commission],
    'F' AS [Executing broker Commission Indicator],
    trd.MiscFees AS [MS Fees],
    '' AS [Not Required],
    'F' AS [MS fees Indicator.],
    '' AS [Dividend Entitlement Percent],
    '' AS [Spread],
    CAST(ABS(trd.NetAmount) AS DECIMAL(24,2)) AS [Net Amount],
    '' AS [Hearsay Ind],
    'MSCO' AS [Custodian],
    '' AS [Money Manager],
    '' AS [Book Id],
    '' AS [Deal Id],
    '' AS [TaxLot Id],
    '' AS [Original taxlot transaction date],
    '' AS [Original Taxlot transaction price],
    '' AS [Taxlot Closeout Method],
    '' AS [Price FX Rate],
    '' AS [Acquisition Date],
    trd.Notes AS [Comments],
    '' AS [Swap Reference No.],
    '' AS [Basket Id],
    TradeCurrency AS [Price Currency],
    '' AS [Reset Indicator],
    '' AS [SNS reference],
    '' AS [Research Fee],
    '' AS [Research Fee Indicator],
    '' AS [LEI],
    '' AS [Client Strategy 2 (Used for PEPS)]
FROM 
    [Trading].[trans].[Trade] trd
JOIN 
    trans.TradeAllocation alloc ON alloc.TradeId = trd.TradeId
JOIN 
    trans.Instrument ins ON ins.InstrumentId = trd.InstrumentId
LEFT JOIN 
    trans.[vwLastFileTransmission] ft ON ft.TransmissionType = 'MSSW002'
LEFT JOIN trd.vwFutureSwap fs on fs.InstrumentId = trd.InstrumentId
WHERE 
    (
        ins.InstrumentType = 'EQU' AND trd.IsCfd = 1 
        OR ins.InstrumentId IN (SELECT InstrumentId FROM trd.vwFutureSwap)
    )
 --   AND trd.TradeDate = CAST(GETDATE() AS DATE) 
    AND (ft.TransmittedOn IS NULL OR ft.TransmittedOn < trd.BookedOn);
GO
/****** Object:  View [trans].[vwTradesFileMSD01]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE VIEW [trans].[vwTradesFileMSD01] AS
SELECT  
    'D01' AS [Transaction_Type],    
    CASE 
        WHEN trd.TradeCurrency = 'USD' THEN '052BATTC2'  
        ELSE '05ABATTC3' 
    END AS [Account],   
    alloc.TradeAllocationId AS [Client_Ref_No],
    '1' AS Version_Number,
    trd.TradeStatus AS Transaction_Status,
    'B' AS Sec_identifier_Type,
    ins.Symbol AS Sec_Identifier,
    '' AS Contract_Year,
    '' AS Contract_Month,
    '' AS Contract_Day,
    ins.[Name] AS Contract_Security_Description,
    ExchangeCode AS [Market/Exchange],   
    CASE 
        WHEN FilledQuantity > 0 THEN 'B' 
        ELSE 'S' 
    END AS [Buy Sell Indicator],   
    '' AS Trade_Type,
    '' AS order_To_Close_Ind,
    '' AS Average_Price_Ind,
    '' AS Spread_Trade_Ind,
    '' AS Night_Trade_Ind,
    '' AS Exchange_for_Physical_Ind,
    '' AS [Block_Trade_Ind],
    '' AS [Off_Exchange_Ind],
    CAST(FORMAT(trd.TradeDate, 'MM/dd/yyyy') AS NVARCHAR(10)) AS [Trade_Date],
    '' AS ExecutionTime,
    ABS(FilledQuantity) AS Quantity,
    ROUND(trd.AvgPrice, 5) AS Price,
    '' AS [Call/Put],
    '' AS Strike_Price,
    'MSPB' AS Executing_Broker,
    'MSPB' AS Clearing_Broker,
    '' AS Give_Up_Reference,
    '' AS Hearsay_Ind,
    '' AS Execution_Fee,
    '' AS Execution_Fee_CCY,
    trd.BrokerCommission AS Commission,
    '' AS Commission_CCY,
    trd.MiscFees AS Exchange_Fee,
    '' AS Exchange_Fee_CCY,
    trd.OrderId AS OrderId,
    '' AS DealId,
    'E' AS Execution_Type
FROM 
    [Trading].[trd].[Trade] trd
JOIN 
    trans.TradeAllocation alloc ON alloc.TradeId = trd.TradeId
JOIN 
    trans.Instrument ins ON ins.InstrumentId = trd.InstrumentId
LEFT JOIN 
    trans.[vwLastFileTransmission] ft ON ft.TransmissionType = 'MSD01'
WHERE 
    ins.InstrumentType = 'FUT'
  --  AND trd.TradeDate = CAST(GETDATE() AS DATE) 
    AND ins.InstrumentId NOT IN (SELECT InstrumentId FROM trd.vwFutureSwap)
    AND (ft.TransmittedOn IS NULL OR ft.TransmittedOn < trd.BookedOn);
GO
/****** Object:  Table [ord].[ExecutionProfile_H]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[ExecutionProfile_H](
	[ExecutionProfileId] [int] NOT NULL,
	[OrderTypeId] [int] NOT NULL,
	[TimeInForceId] [tinyint] NOT NULL,
	[ExecutionAlgorithmId] [int] NOT NULL,
	[ExecutionAlgorithmParamSetId] [int] NULL,
	[HandlingInstructionId] [int] NOT NULL,
	[ExecutionChannelId] [tinyint] NOT NULL,
	[TradingDeskId] [int] NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_ExecutionProfile_H]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_ExecutionProfile_H] ON [ord].[ExecutionProfile_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [ord].[ExecutionProfile]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[ExecutionProfile](
	[ExecutionProfileId] [int] IDENTITY(1,1) NOT NULL,
	[OrderTypeId] [int] NOT NULL,
	[TimeInForceId] [tinyint] NOT NULL,
	[ExecutionAlgorithmId] [int] NOT NULL,
	[ExecutionAlgorithmParamSetId] [int] NULL,
	[HandlingInstructionId] [int] NOT NULL,
	[ExecutionChannelId] [tinyint] NOT NULL,
	[TradingDeskId] [int] NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_ ExecutionProfile] PRIMARY KEY CLUSTERED 
(
	[ExecutionProfileId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [ord].[ExecutionProfile_H])
)
GO
/****** Object:  View [trans].[vwTradesFileMSFSTR001]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE VIEW [trans].[vwTradesFileMSFSTR001] AS
SELECT 
    'TR001' AS TrasationType,
    trd.TradeStatus AS TransactionStatus,
    trd.BuySellIndicator AS [Buy/Sell],
    CASE 
        WHEN trd.BuySellIndicator='S' AND (alloc.PositionSide ='L' OR  alloc.PositionSide ='C') THEN 'L'
        WHEN trd.BuySellIndicator='S' AND alloc.PositionSide ='S' THEN 'S'
        WHEN trd.BuySellIndicator='B' AND alloc.PositionSide ='L' THEN 'L'
        WHEN trd.BuySellIndicator='B' AND (alloc.PositionSide ='S' OR  alloc.PositionSide ='C') THEN 'C' 
    END AS [Long/Short],
    '' AS [PositionType],
    'A' AS [TransLevel],
    alloc.TradeAllocationId AS [ClientRef#],
    CONCAT(trd.TradeId,'A') AS [Associated#],
    '038227591' AS [ExecAccount],
    '038QLFIP9' AS [AccountId],
    trd.TradeDesk AS [ExecutionBroker],
    'B' AS [SecType],
    ins.Symbol AS [SecID],
    ins.[Name] as SecurityDescription,
    FORMAT(trd.TradeDate, 'MM/dd/yyyy') AS TradeDate,
    FORMAT(trd.fnAddBusinessDays(trd.TradeDate,1), 'MM/dd/yyyy') AS SettlementDate,
    ISNULL( trd.SettlementCurrency, trd.TradeCurrency) AS SettlementCurrency,
    '' AS ExchangeCode,
    ABS(alloc.Quantity) AS [Quantity],
	  CASE WHEN LEFT(ins.Symbol, 2)= 'JY' AND RIGHT(ins.Symbol, 6) = 'Curncy' THEN alloc.Price/100
	  WHEN LEFT(ins.Symbol, 2)= 'NO' AND RIGHT(ins.Symbol, 6) = 'Curncy' THEN alloc.Price/100
	  WHEN LEFT(ins.Symbol, 2)= 'SE' AND RIGHT(ins.Symbol, 6) = 'Curncy' THEN alloc.Price/100
	  WHEN LEFT(ins.Symbol, 2)= 'RA' AND RIGHT(ins.Symbol, 6) = 'Curncy' THEN alloc.Price/100
	  WHEN LEFT(ins.Symbol, 2)= 'HE' AND RIGHT(ins.Symbol, 6) = 'Curncy' THEN alloc.Price/100
	  WHEN LEFT(ins.Symbol, 2)= 'BR' AND RIGHT(ins.Symbol, 6) = 'Curncy' THEN alloc.Price/100
	 ELSE alloc.Price END AS PriceAmount,
    'G' AS PriceIndicator,
    CAST(ABS(trd.Principal) AS DECIMAL(24,2)) AS Principal,
    CAST(ABS(trd.BrokerCommission) AS DECIMAL(24,2)) AS CommissionAmount,
    'F' AS CommissionIndicator,
    ABS(ISNULL(trd.MiscFees,0)) AS [Tax/Fees],
    '' AS [Tax2],
    'F' AS [FeeInd],
    '' AS [Interest],
    '' AS [InterestIndicator],
    CASE 
        WHEN trd.BuySellIndicator = 'S' THEN CAST(ABS(trd.Principal)- ABS(trd.BrokerCommission) AS DECIMAL(24,2))
        WHEN trd.BuySellIndicator = 'B' THEN CAST(ABS(trd.Principal)+ ABS(trd.BrokerCommission) AS DECIMAL(24,2))
    END AS NetAmount,
    'Y' AS [HearsayInd],
    'MSCO' AS [Custodian],
    '' AS [MoneyManager],
    '' AS [BookId],
    '' AS [DealId],
    '' AS [TaxLotId],
    '' AS [TaxDate],
    '' AS [TaxPrice],
    '' AS [CloseOutMethod],
    '' AS [ExRate],
    '' AS [AcqDate],
    '' AS [Comments]
FROM  
    [trans].[Trade] trd
JOIN 
    [trans].[TradeAllocation] alloc ON alloc.TradeId = trd.TradeId
JOIN 
    [trans].Instrument ins ON ins.InstrumentId = trd.InstrumentId
LEFT JOIN 
    trans.[vwLastFileTransmission] ft ON ft.TransmissionType = 'MSFSTR001'
WHERE 
    ins.InstrumentType = 'FUT'
    --AND trd.TradeDate = CAST(GETDATE() AS DATE) 
    AND trd.InstrumentId NOT IN (SELECT InstrumentId FROM trd.vwFutureSwap)
    AND (ft.TransmittedOn IS NULL OR ft.TransmittedOn < trd.BookedOn);
GO
/****** Object:  View [trans].[vwTradesFileMSFSSW002]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- select * from [trans].[vwTradesFileMSFSSW002]


CREATE VIEW [trans].[vwTradesFileMSFSSW002] AS
SELECT 
    'SW002' AS TrasationType,
    trd.TradeStatus AS TransactionStatus,
    trd.BuySellIndicator AS [Buy/Sell],
    CASE 
        WHEN trd.BuySellIndicator = 'S' AND (alloc.PositionSide = 'L' OR alloc.PositionSide = 'C') THEN 'L'
        WHEN trd.BuySellIndicator = 'S' AND alloc.PositionSide = 'S' THEN 'S'
        WHEN trd.BuySellIndicator = 'B' AND alloc.PositionSide = 'L' THEN 'L'
        WHEN trd.BuySellIndicator = 'B' AND (alloc.PositionSide = 'S' OR alloc.PositionSide = 'C') THEN 'C'
    END AS [Long/Short],
    '' AS [PositionType],
    'A' AS [TransLevel],
    alloc.TradeAllocationId AS [ClientTradeRefNo],
    CONCAT(trd.TradeId,'A') AS [AssociatedTradeId],
    '038227591' AS [ExecutionAccount],
    '038QLFIP9' AS [Account Id],
    trd.TradeDesk AS [Broker/Couterparty],
    IIF(trd.Sedol IS NULL OR TRIM(trd.Sedol) = '', 'B','S') AS [SecurityIdentifierType],
    IIF(trd.Sedol IS NULL OR TRIM(trd.Sedol) = '',ins.Symbol, trd.Sedol) AS [SecurityIdentifier],
    ins.Name as SecurityDescription,
    FORMAT(trd.TradeDate, 'MM/dd/yyyy') AS TradeDate,
    FORMAT(trd.fnAddBusinessDays(trd.TradeDate,IIF(ins.Symbol like '%Equity', 2,2)), 'MM/dd/yyyy') AS SettlementDate, -- TGU put 3 vs 2
    ISNULL(fs.SettlementCurrency, ISNULL(trd.SettlementCurrency, trd.TradeCurrency)) AS SettlementCurrency,
    '' AS [ExchangeCode],
    ABS(alloc.Quantity) AS [Quantity],
    alloc.Price AS Price,
    'G' AS PriceIndicator,
    CAST(ABS(trd.Principal) AS DECIMAL(24,2)) AS Principal,
    CAST(trd.BrokerCommission AS DECIMAL(24,2)) AS [BrokerCommission],
    'F' AS [BrokerCommissionInd],
    trd.MiscFees AS [MSFees],
    '' AS [NotRequired],
    'F' AS [MSFeesInd],
    '' AS [DivEntitlPercent],
    '' AS Spread,
    CASE 
        WHEN trd.BuySellIndicator = 'S' THEN  CAST(ABS(trd.Principal)-ABS(trd.BrokerCommission) AS DECIMAL(24,2)) 
        WHEN trd.BuySellIndicator = 'B' THEN CAST(ABS(trd.Principal)+ABS(trd.BrokerCommission)AS DECIMAL(24,2))   
    END AS NetAmount,
    'Y' AS [HearsayInd],
    'MSSW' AS [Custodian],
    '' AS [MoneyManager],
    '' AS [BookId],
    '' AS [DealId],
    '' AS [TaxLotId],
    '' AS [TaxDate],
    '' AS [TaxPrice],
    '' AS [CloseOutMethod],
    '' AS [FxRate],
    '' AS [AcquisitionDate],
    '' AS [Comments],
    '' AS [SwapReferenceNo],
    '' AS [BasketId],
    '' AS [PriceCurrency],
    '' AS [ResetIndicator],
    '' AS [SnSReference],
    '' AS [ResearchFee],
    '' AS [ResearchFeeInd],
    '' AS [LEI],
    '' AS [MaturityDate],
    'Equity Vanilla Swaps' AS [ProductType],
    '' AS [Fuut/Part Unwind Ind],
    '' AS [PaymentDate],
    '' AS [DividendAmount],
    '' AS [DividendPayoutDate],
    '' AS [NextResetDate],
    '' AS [ResetPrice],
    '' AS [EquitySpread],
    '' AS [DaycountConvention],
    '' AS [FloatingRate],
    '' AS [RollConvention],
    '' AS [CollateralPledge],
    '' AS [FixingFrequency],
    '' AS [PaymentFrequency]
FROM 
    [trans].[Trade] trd
JOIN 
    [trans].[TradeAllocation] alloc ON alloc.TradeId = trd.TradeId
JOIN 
    [trans].Instrument ins ON ins.InstrumentId = trd.InstrumentId
LEFT JOIN 
    trans.[vwLastFileTransmission] ft ON ft.TransmissionType = 'MSFSSW002'
LEFT JOIN trd.vwFutureSwap fs on fs.InstrumentId = trd.InstrumentId
WHERE 
    ((ins.InstrumentType = 'EQU' AND trd.IsCfd = 1) 
     OR (trd.InstrumentId IN (SELECT InstrumentId FROM trd.vwFutureSwap)))
  --  AND trd.TradeDate = CAST(GETDATE() AS DATE)
	AND (ft.TransmittedOn IS NULL OR ft.TransmittedOn < trd.BookedOn);
GO
/****** Object:  Table [instr].[TimeZone_H]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [instr].[TimeZone_H](
	[TimeZoneId] [smallint] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_TimeZone_H]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_TimeZone_H] ON [instr].[TimeZone_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [instr].[TimeZone]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [instr].[TimeZone](
	[TimeZoneId] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_TimeZone] PRIMARY KEY CLUSTERED 
(
	[TimeZoneId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [instr].[TimeZone_H])
)
GO
/****** Object:  Table [book].[H_FutureSwap]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [book].[H_FutureSwap](
	[ExecutionBrokerId] [int] NOT NULL,
	[GenericFutureId] [int] NOT NULL,
	[ValidFrom] [datetime2](7) NOT NULL,
	[ValidTo] [datetime2](7) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_H_FutureSwap]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_H_FutureSwap] ON [book].[H_FutureSwap]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [book].[FutureSwap]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [book].[FutureSwap](
	[ExecutionBrokerId] [int] NOT NULL,
	[GenericFutureId] [int] NOT NULL,
	[ValidFrom] [datetime2](7) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](7) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_FutureSwap] PRIMARY KEY CLUSTERED 
(
	[ExecutionBrokerId] ASC,
	[GenericFutureId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [book].[H_FutureSwap])
)
GO
/****** Object:  View [book].[vwFutureOnSwap]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO













/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [book].[vwFutureOnSwap] as
SELECT 
execbrok.CounterpartyId as ExecutionBrokerId
,execbrok.Code as ExecutionBrokerCode
,i.InstrumentId
      ,i.Symbol
	  ,si.SettleCurrency
	  ,si.DaysToSettle

  FROM [book].[FutureSwap] fs
  JOIN [book].Counterparty execbrok on execbrok.CounterpartyId = ExecutionBrokerId
  JOIN [book].Instrument i on i.InstrumentId = fs.GenericFutureId
  JOIN [book].SettlementInfo si on si.InstrumentId = i.InstrumentId and si.IsSwap = 1

GO
/****** Object:  View [trans].[vwTradesFileMSFSFX]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [trans].[vwTradesFileMSFSFX] as
SELECT 
    'FX002' AS TrasationType,
    trd.TradeStatus AS TransactionStatus,
    'A' AS [TransLevel],
    'FORWARD' AS [InstrumentType],
    alloc.TradeAllocationId AS [ClientTradeRef],
    CONCAT(trd.TradeId,'A') AS [AssociatedTradeId],    
    '038227591' AS [ExecAccount],
    '038QLFIP9' AS [AccountId],
    trd.TradeDesk AS [ExecutionBroker],
    FORMAT(trd.TradeDate, 'MM/dd/yyyy') AS TradeDate,
    FORMAT(ins.MaturityDate, 'MM/dd/yyyy') AS ValueDate,
    ABS(CAST(IIF(trd.FxCurrency1Amount > 0, trd.FxCurrency1Amount, trd.FxCurrency2Amount) AS DECIMAL(24,2))) AS BuyQuantity,
    ABS(CAST(IIF(trd.FxCurrency1Amount < 0, trd.FxCurrency1Amount, trd.FxCurrency2Amount) AS DECIMAL(24,2))) AS SellQuantity,
    IIF(trd.FxCurrency1Amount > 0, trd.FxCurrency1, trd.FxCurrency2) AS BuyCcy,
    IIF(trd.FxCurrency1Amount < 0, trd.FxCurrency1, trd.FxCurrency2) AS SellCcy,
    '' AS DealtCcy,
    ABS(trd.FxCurrency1Amount) / ABS(trd.FxCurrency2Amount) AS Rate,
    '' AS NdfFlag,
    '' AS NdfFixingDate,
    '' AS NdfLinkedTrade,
    'MSCO' AS PB,
    '' AS FarValueDate,
    '' AS FarValueRate,
    '' AS ClientBaseEquivalent,
    'S' AS HedgeOrSpeculative,
    '' AS TaxIndicator,
    'Y' AS HeasayInd,
    'MSCO' AS Custodian,
    '' AS MoneyManager,
    '' AS DealId,
    '' AS AcquisitionDate,
    '' AS Comments,
    '' AS TradeType,
    '' AS Reporter
FROM 
    [trans].[Trade] trd
JOIN 
    [trans].[TradeAllocation] alloc ON alloc.TradeId = trd.TradeId
JOIN 
    [trans].Instrument ins ON ins.InstrumentId = trd.InstrumentId
LEFT JOIN 
    trans.[vwLastFileTransmission] ft ON ft.TransmissionType = 'MSFSFX'
WHERE 
    ins.InstrumentType ='FXFWD'  
    AND trd.TradeDate = CAST(GETDATE() as date)
    AND (ft.TransmittedOn IS NULL OR ft.TransmittedOn < trd.BookedOn);
GO
/****** Object:  View [trans].[vwTradesFileCapricorn]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [trans].[vwTradesFileCapricorn] as
SELECT 
  ROW_NUMBER() OVER(ORDER BY ins.Symbol)  as [Order number],
  REPLACE(REPLACE(REPLACE(trd.TradeStatus,'NEW','N'),'CAN','C'),'COR','A') as Activity,
  'MS1CFD' as Account,
  ins.Name as [Security Description],
  ins.Symbol as [Ticker Symbol],
  trd.ExchangeCode as [Exchange-MIC],
  ISNULL(ins.ISIN,'') as [ISIN],
  IIF(trd.Sedol is null or TRIM(trd.Sedol )= '', '',trd.Sedol ) as [SEDOL],
  '' as[CUSIP],
  trd.BrokerCode as [Broker],
  'MSCO' as Custodian,
  ins.InstrumentType as [Security Type],
  alloc.PositionSide as [Transaction type],
  trd.TradeCurrency as [Settlement Ccy],
  FORMAT(cast(trd.TradeDate as date),'yyyyMMdd') as [Trade date],
  CASE 
    WHEN InstrumentType = 'EQU' THEN FORMAT(trd.fnAddBusinessDays(trd.TradeDate,2),'yyyyMMdd')
    ELSE FORMAT(cast(trd.TradeDate as date),'yyyyMMdd') 
  END as [Settle date],
  trd.OrderQuantity as [Order Quantity],
  trd.FilledQuantity as[Fillled Quantity],
  trd.BrokerCommission as [Commission],
  trd.AvgPrice * ISNULL(fxr.[Value],1) AS Price,
  '' as [Accrued interest],
  '' as [Sec Fee],
  '' as [Trade tax],
  ISNULL(trd.MiscFees,0) as [Misc money],
  CAST(trd.NetAmount as decimal(24,2)) as [Net amount],
  CAST(trd.Principal as decimal(24,2)) as [Principal],
  '' as [Description],
  IIF(trd.IsCfd= 1, 1, 0) as [Is_CFD],
  '' as [Clearing Agent],
  '' as [Put/Call],
  '' as Strike,
  FORMAT(ISNULL(ins.MaturityDate,''),'yyyy-MM-dd') as [Expiry Date],
  trd.Trader as Trader
FROM 
  [trans].Trade trd
JOIN 
  [trans].TradeAllocation alloc ON alloc.TradeId = trd.TradeId
JOIN 
  [trans].Instrument ins ON ins.InstrumentId = trd.InstrumentId
LEFT JOIN 
  [trans].FxRate fxr ON fxr.BaseCurrency = trd.TradeCurrency AND fxr.QuoteCurrency = 'USD'
LEFT JOIN 
  trans.[vwLastFileTransmission] ft ON ft.TransmissionType = 'CAPRITRD'
WHERE 
--  trd.TradeDate = CAST(GETDATE() as date)
 -- AND 
  (ft.TransmittedOn IS NULL OR ft.TransmittedOn < trd.BookedOn);
GO
/****** Object:  View [port].[vwClosedPosition]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO













CREATE VIEW [port].[vwClosedPosition] AS
SELECT   [PortfolioId]
      ,[Mnemonic]
      ,[BaseCurrency]
      ,[InstrumentId]
      ,[Symbol]
      ,[InstrumentType]
      ,[MarketSector]
      ,[InstrumentName]
	  ,[IsSwap]
      ,[Quantity]
      ,[AvgEntryPriceLocal]
      ,[PositionValueLocal]
      ,[GrossTotalCostLocal]
      ,[NetTotalCostLocal]
      ,[LastTradeAllocationId]
      ,[PositionDate]
      ,[Currency]
   
  FROM [port].[vwPosition]
  where Quantity = 0
GO
/****** Object:  Table [ord].[ExecutionAlgorithmParamSet_H]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[ExecutionAlgorithmParamSet_H](
	[ExecutionAlgorithmParamSetId] [int] NOT NULL,
	[ExecutionAlgorithmId] [int] NOT NULL,
	[Param1] [nvarchar](30) NULL,
	[Value1] [nvarchar](30) NULL,
	[Param2] [nvarchar](30) NULL,
	[Value2] [nvarchar](30) NULL,
	[Param3] [nvarchar](30) NULL,
	[Value3] [nvarchar](30) NULL,
	[Param4] [nvarchar](30) NULL,
	[Value4] [nvarchar](30) NULL,
	[Param5] [nvarchar](30) NULL,
	[Value5] [nvarchar](30) NULL,
	[Param6] [nvarchar](30) NULL,
	[Value6] [nvarchar](30) NULL,
	[Param7] [nvarchar](30) NULL,
	[Value7] [nvarchar](30) NULL,
	[Param8] [nvarchar](30) NULL,
	[Value8] [nvarchar](30) NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_ExecutionAlgorithmParamSet_H]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_ExecutionAlgorithmParamSet_H] ON [ord].[ExecutionAlgorithmParamSet_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [ord].[ExecutionAlgorithmParamSet]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[ExecutionAlgorithmParamSet](
	[ExecutionAlgorithmParamSetId] [int] IDENTITY(1,1) NOT NULL,
	[ExecutionAlgorithmId] [int] NOT NULL,
	[Param1] [nvarchar](30) NULL,
	[Value1] [nvarchar](30) NULL,
	[Param2] [nvarchar](30) NULL,
	[Value2] [nvarchar](30) NULL,
	[Param3] [nvarchar](30) NULL,
	[Value3] [nvarchar](30) NULL,
	[Param4] [nvarchar](30) NULL,
	[Value4] [nvarchar](30) NULL,
	[Param5] [nvarchar](30) NULL,
	[Value5] [nvarchar](30) NULL,
	[Param6] [nvarchar](30) NULL,
	[Value6] [nvarchar](30) NULL,
	[Param7] [nvarchar](30) NULL,
	[Value7] [nvarchar](30) NULL,
	[Param8] [nvarchar](30) NULL,
	[Value8] [nvarchar](30) NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_ExecutionAlgorithmParamSet] PRIMARY KEY CLUSTERED 
(
	[ExecutionAlgorithmParamSetId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [ord].[ExecutionAlgorithmParamSet_H])
)
GO
/****** Object:  View [port].[vwOpenPosition]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO














CREATE VIEW [port].[vwOpenPosition] AS
SELECT  [PortfolioId]
      ,[Mnemonic]
      ,[BaseCurrency]
      ,[InstrumentId]
      ,[Symbol]
      ,[InstrumentType]
	  ,[IsSwap]
      ,[MarketSector]
      ,[InstrumentName]
      ,[Quantity]
      ,[AvgEntryPriceLocal]
      ,[PositionValueLocal]
      ,[GrossTotalCostLocal]
      ,[NetTotalCostLocal]
      ,[LastTradeAllocationId]
      ,[PositionDate]
      ,[Currency]
  
  FROM [port].[vwPosition]
  where Quantity <> 0
GO
/****** Object:  View [port].[vwLastOpenPosition]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
















CREATE VIEW [port].[vwLastOpenPosition] AS
SELECT   [PortfolioId]
      ,[Mnemonic]
      ,[BaseCurrency]
      ,[InstrumentId]
	  ,[IsSwap]
      ,[Symbol]
      ,[InstrumentType]
      ,[MarketSector]
      ,[InstrumentName]
      ,[Quantity]
      ,[AvgEntryPriceLocal]
      ,[PositionValueLocal]
      ,[GrossTotalCostLocal]
      ,[NetTotalCostLocal]
      ,[LastTradeAllocationId]
      ,[PositionDate]
      ,[Currency]
  
  FROM [port].[vwLastPosition]
  where Quantity <> 0
GO
/****** Object:  Table [book].[H_CounterpartyRoleAssignment]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [book].[H_CounterpartyRoleAssignment](
	[CounterpartyRoleAssignmentId] [int] NOT NULL,
	[PortfolioId] [int] NOT NULL,
	[InstrumentId] [int] NOT NULL,
	[ExecutionBrokerId] [int] NOT NULL,
	[CounterpartyRoleSetupId] [int] NOT NULL,
	[ValidFrom] [datetime2](7) NOT NULL,
	[ValidTo] [datetime2](7) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_H_CounterpartyRoleAssignment]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_H_CounterpartyRoleAssignment] ON [book].[H_CounterpartyRoleAssignment]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [book].[CounterpartyRoleAssignment]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [book].[CounterpartyRoleAssignment](
	[CounterpartyRoleAssignmentId] [int] IDENTITY(1,1) NOT NULL,
	[PortfolioId] [int] NOT NULL,
	[InstrumentId] [int] NOT NULL,
	[ExecutionBrokerId] [int] NOT NULL,
	[CounterpartyRoleSetupId] [int] NOT NULL,
	[ValidFrom] [datetime2](7) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](7) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_CounterpartyRoleAssignment] PRIMARY KEY CLUSTERED 
(
	[CounterpartyRoleAssignmentId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_CounterpartyRoleAssignment] UNIQUE NONCLUSTERED 
(
	[PortfolioId] ASC,
	[InstrumentId] ASC,
	[ExecutionBrokerId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [book].[H_CounterpartyRoleAssignment])
)
GO
/****** Object:  Table [risk].[FilterOperator_H]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [risk].[FilterOperator_H](
	[FilterOperatorId] [tinyint] NOT NULL,
	[Mnemonic] [nvarchar](20) NOT NULL,
	[Description] [nvarchar](20) NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_FilterOperator_H]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_FilterOperator_H] ON [risk].[FilterOperator_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [risk].[FilterOperator]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [risk].[FilterOperator](
	[FilterOperatorId] [tinyint] IDENTITY(1,1) NOT NULL,
	[Mnemonic] [nvarchar](20) NOT NULL,
	[Description] [nvarchar](20) NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_FilterOperatorId] PRIMARY KEY CLUSTERED 
(
	[FilterOperatorId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_FilterOperatorMnemonic] UNIQUE NONCLUSTERED 
(
	[Mnemonic] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [risk].[FilterOperator_H])
)
GO
/****** Object:  Table [ord].[BrokerSelectionRuleOverride_H]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[BrokerSelectionRuleOverride_H](
	[BrokerSelectionRuleOverrideId] [int] NOT NULL,
	[PortfolioId] [tinyint] NOT NULL,
	[InstrumentId] [int] NOT NULL,
	[BrokerId] [int] NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_BrokerSelectionRuleOverride_H]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_BrokerSelectionRuleOverride_H] ON [ord].[BrokerSelectionRuleOverride_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [ord].[BrokerSelectionRuleOverride]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[BrokerSelectionRuleOverride](
	[BrokerSelectionRuleOverrideId] [int] IDENTITY(1,1) NOT NULL,
	[PortfolioId] [tinyint] NOT NULL,
	[InstrumentId] [int] NOT NULL,
	[BrokerId] [int] NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_BrokerSelectionRuleOverride] PRIMARY KEY CLUSTERED 
(
	[BrokerSelectionRuleOverrideId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [ord].[BrokerSelectionRuleOverride_H])
)
GO
/****** Object:  View [trd].[vwEmsxTradeToBook_Backup]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [trd].[vwEmsxTradeToBook_Backup] as
WITH OrderSign AS (
    SELECT 
        e.EmsxSequence,
        IIF(e.Side LIKE 'S%', -1, 1) as SignMultiplier
    FROM [trd].[EmsxOrder] e
),

PrincipalDetails AS (
    SELECT
        e.EmsxSequence,
        os.SignMultiplier,
        os.SignMultiplier * e.Filled * e.AvgPrice * ISNULL(i.FuturePointValue, 1) AS Principal
    FROM [trd].[EmsxOrder] e
    LEFT JOIN trd.Instrument i ON i.Symbol = e.Ticker
    INNER JOIN OrderSign os ON os.EmsxSequence = e.EmsxSequence
),

BrokerCommDetails AS (
    SELECT
        pd.EmsxSequence,
        ABS(COALESCE(
            fc.CommPerLot * e.Filled,
            fc.CommRate * pd.Principal,
            e.[BrokerCommm],
            0
        )) AS BrokerCommm,
        COALESCE(fc.CommRate, e.[CommmRate], 0) AS CommmRate,
        ABS(ISNULL(e.[MiscFees] , 0)) AS MiscFees
    FROM [trd].[EmsxOrder] e
    LEFT JOIN trd.Instrument i ON i.Symbol = e.Ticker
    LEFT JOIN trd.FutureCommission fc ON fc.GenericFutureId = i.GenericFutureId AND fc.BrokerCode = e.Broker
    INNER JOIN PrincipalDetails pd ON pd.EmsxSequence = e.EmsxSequence
)
    SELECT
		t.TradeId,
        e.EmsxSequence,
        CAST(e.OrderRefId AS INT) AS OrderId,
         IIF(e.CustomNote1 = '', null,CAST(e.CustomNote1 AS INT)) AS RebalancingId,
        e.OrderRefId AS EmsxOrderRefId,
        e.EmsxDate,
        i.InstrumentId,
		i.Symbol,
		 LEFT(e.Side, 1) AS Side, -- S or B
        IIF(e.CustomNote3 = '', null, CAST(e.CustomNote3 AS CHAR(1))) AS PositionSide,
        pd.SignMultiplier * e.Amount AS OrderQuantity,
        pd.SignMultiplier * e.Filled AS FilledQuantity,
        i.Exchange as  ExchangeCode,
        e.Sedol,
        e.Account, -- to be reviewed when we implement allocations
		 bcd.BrokerCommm + bcd.MiscFees AS TotalCharges,
        e.EmsxDate AS TradeDate,
        pd.Principal,
        pd.Principal + ABS(bcd.BrokerCommm) + ABS(bcd.MiscFees) AS NetAmount,
        IIF(e.CustomNote2 = '', null, CAST(e.CustomNote2 AS TINYINT)) AS PortfolioId, -- to be reviewed when we implement allocations
        e.AvgPrice,
        e.DayAvgPrice,
        i.Currency AS TradeCurrency,
        e.OrderType,
        e.TimeInForce,
        e.Strategy,
        e.HandInstruction,
        e.SettleDate,
        e.SettleCurrency,
        bcd.BrokerCommm,
        bcd.CommmRate,
        bcd.MiscFees,
        e.Notes,
        e.Trader,
        e.Broker,
        IIF(e.CfdFlag = '1' OR e.CfdFlag = 'Y', 1, 0) AS IsCfd,
        'EMSX' AS ExecutionChannel,
       CAST( e.EmsxDate  AS DATETIME)+ CAST(e.TimeStamp AS DATETIME)AS CreatedOn, -- Assuming this is the correct calculation
        IIF(i.InstrumentId IS NOT NULL, 1, 0) AS IsInstrumentMapped,
        IIF(t.TradeId IS NOT NULL, 1, 0) AS IsTradeAlreadyBooked,
        fc.CommPerLot,
        fc.CommRate
       
    FROM [trd].[EmsxOrder] e
    LEFT JOIN trd.Instrument i ON i.Symbol = e.Ticker
    LEFT JOIN trd.FutureCommission fc ON fc.GenericFutureId = i.GenericFutureId AND fc.BrokerCode = e.Broker
    LEFT JOIN trd.Trade t ON t.EmsxSequence = e.EmsxSequence
    INNER JOIN PrincipalDetails pd ON pd.EmsxSequence = e.EmsxSequence
    INNER JOIN BrokerCommDetails bcd ON bcd.EmsxSequence = e.EmsxSequence



GO
/****** Object:  View [port].[vwLastClosedPosition]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








CREATE VIEW [port].[vwLastClosedPosition] AS
WITH RankedClosedPositions AS (
    SELECT 
        [PortfolioId]
      ,[Mnemonic]
      ,[BaseCurrency]
      ,[InstrumentId]
	  ,[IsSwap]
      ,[Symbol]
      ,[InstrumentType]
      ,[MarketSector]
      ,[InstrumentName]
      ,[Quantity]
      ,[AvgEntryPriceLocal]
      ,[PositionValueLocal]
      ,[GrossTotalCostLocal]
      ,[NetTotalCostLocal]
      ,[LastTradeAllocationId]
      ,[PositionDate]
      ,[Currency]
  
       , ROW_NUMBER() OVER (PARTITION BY [PortfolioId], [InstrumentId] ORDER BY [PositionDate] DESC) AS RowNum
    FROM 
        [port].[vwClosedPosition]
    WHERE 
        Quantity = 0
)
SELECT 
  [PortfolioId]
      ,[Mnemonic]
      ,[BaseCurrency]
      ,[InstrumentId]
	  
      ,[Symbol]
	  ,[IsSwap]
      ,[InstrumentType]
      ,[MarketSector]
      ,[InstrumentName]
      ,[Quantity]
      ,[AvgEntryPriceLocal]
      ,[PositionValueLocal]
      ,[GrossTotalCostLocal]
      ,[NetTotalCostLocal]
      ,[LastTradeAllocationId]
      ,[PositionDate] as LastClosingPositionDate
      ,[Currency]

FROM 
    RankedClosedPositions
WHERE 
    RowNum = 1;

GO
/****** Object:  Table [ord].[ExecutionProfileSelectionRuleOverride_H]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[ExecutionProfileSelectionRuleOverride_H](
	[ExecutionProfileSelectionRuleOverrideId] [int] NOT NULL,
	[PortfolioId] [tinyint] NOT NULL,
	[BrokerId] [int] NOT NULL,
	[InstrumentId] [int] NOT NULL,
	[TradeModeId] [tinyint] NOT NULL,
	[ExecutionProfileId] [int] NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_ExecutionProfileSelectionRuleOverride_H]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_ExecutionProfileSelectionRuleOverride_H] ON [ord].[ExecutionProfileSelectionRuleOverride_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [ord].[ExecutionProfileSelectionRuleOverride]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[ExecutionProfileSelectionRuleOverride](
	[ExecutionProfileSelectionRuleOverrideId] [int] IDENTITY(1,1) NOT NULL,
	[PortfolioId] [tinyint] NOT NULL,
	[BrokerId] [int] NOT NULL,
	[InstrumentId] [int] NOT NULL,
	[TradeModeId] [tinyint] NOT NULL,
	[ExecutionProfileId] [int] NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_ExecutionProfileSelectionRuleOverride] PRIMARY KEY CLUSTERED 
(
	[ExecutionProfileSelectionRuleOverrideId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [ord].[ExecutionProfileSelectionRuleOverride_H])
)
GO
/****** Object:  Table [book].[H_CommissionType]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [book].[H_CommissionType](
	[CommissionTypeId] [int] NOT NULL,
	[Code] [char](1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Description] [nvarchar](100) NULL,
	[ValidFrom] [datetime2](7) NOT NULL,
	[ValidTo] [datetime2](7) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_H_CommissionType]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_H_CommissionType] ON [book].[H_CommissionType]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [book].[CommissionType]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [book].[CommissionType](
	[CommissionTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Code] [char](1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Description] [nvarchar](100) NULL,
	[ValidFrom] [datetime2](7) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](7) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_CommissionType] PRIMARY KEY CLUSTERED 
(
	[CommissionTypeId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_CommissionTypeCode] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [book].[H_CommissionType])
)
GO
/****** Object:  Table [instr].[Date_H]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [instr].[Date_H](
	[DateId] [int] NOT NULL,
	[Value] [date] NOT NULL,
	[IsIMM] [bit] NOT NULL,
	[IsForwardMaturity] [bit] NOT NULL,
	[IsWeekend] [bit] NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_Date_H]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_Date_H] ON [instr].[Date_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [instr].[Date]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [instr].[Date](
	[DateId] [int] IDENTITY(1,1) NOT NULL,
	[Value] [date] NOT NULL,
	[IsIMM] [bit] NOT NULL,
	[IsForwardMaturity] [bit] NOT NULL,
	[IsWeekend] [bit] NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_Date] PRIMARY KEY CLUSTERED 
(
	[DateId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_Date] UNIQUE NONCLUSTERED 
(
	[Value] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [instr].[Date_H])
)
GO
/****** Object:  View [roll].[vwFutureContractRollInfo_Old]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


















/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [roll].[vwFutureContractRollInfo_Old] as
WITH BusinessDays AS (
    SELECT
        FutureContractId,
        Symbol,
        GenericFutureId,
        LEAST([FirstNoticeDate], [LastTradeDate]) AS MaturityDate,
        CASE 
            WHEN DATEPART(WEEKDAY, LEAST([FirstNoticeDate], [LastTradeDate])) = 1 THEN DATEADD(DAY, -9, LEAST([FirstNoticeDate], [LastTradeDate]))
            WHEN DATEPART(WEEKDAY, LEAST([FirstNoticeDate], [LastTradeDate])) = 2 THEN DATEADD(DAY, -10, LEAST([FirstNoticeDate], [LastTradeDate]))
            ELSE DATEADD(DAY, -8, LEAST([FirstNoticeDate], [LastTradeDate]))
        END AS RollingPeriodStartDate,
        OpenInterest
    FROM [roll].[FutureContract]
    WHERE LEAST([FirstNoticeDate], [LastTradeDate]) >= GETDATE()
),

NextContractRanking AS (
    SELECT
        GenericFutureId,
        FutureContractId,
        OpenInterest,
		MaturityDate,
		Symbol,
		RollingPeriodStartDate,
		DATEDIFF(DAY, GETDATE(), MaturityDate) as DayToLastRollingDate,
        DATEDIFF(DAY, GETDATE(), RollingPeriodStartDate) as DayToFirstRollingDate,
        ROW_NUMBER() OVER(PARTITION BY GenericFutureId ORDER BY OpenInterest DESC, MaturityDate) AS RankNum,
		CASE 
            WHEN GETDATE() BETWEEN RollingPeriodStartDate AND MaturityDate THEN 1
            ELSE 0
        END AS IsBusinessDayRoll,
		CASE 
            WHEN OpenInterest = 0 THEN 1
            ELSE 0
        END AS IsLiquidityLow
    FROM BusinessDays
),CurrentAndNextContracts AS (
    SELECT
        c.FutureContractId AS CurrentContractId,
        c.GenericFutureId,
		c.Symbol as CurrentSymbol,
		c.MaturityDate as ExpiryDate,
        c.OpenInterest AS CurrentOpenInterest,
        c.MaturityDate AS CurrentMaturityDate,
		 c.RollingPeriodStartDate AS RollingPeriodStartDate,
    c.DayToFirstRollingDate AS DayToRollingPeriodStart,
    c.DayToLastRollingDate AS DayToExpiry,
    c.IsBusinessDayRoll,
	c.IsLiquidityLow,
	IIF(c.OpenInterest < n.OpenInterest AND n.MaturityDate >= c.MaturityDate, 1, 0) AS IsLiquidityRoll,
CASE 
    WHEN c.IsBusinessDayRoll = 1 OR IIF(c.OpenInterest < n.OpenInterest AND n.MaturityDate >= c.MaturityDate, 1, 0) = 1 THEN 1
    ELSE 0
END AS IsRollingPeriod,  
        n.FutureContractId AS NextContractId,
        n.OpenInterest AS NextOpenInterest,
		n.Symbol as NextSymbol,
        n.MaturityDate AS NextMaturityDate,
        ROW_NUMBER() OVER(PARTITION BY c.FutureContractId ORDER BY n.OpenInterest DESC, n.MaturityDate) AS Rank
    FROM NextContractRanking c
    INNER JOIN NextContractRanking n ON c.GenericFutureId = n.GenericFutureId
    WHERE n.MaturityDate > c.MaturityDate and c.RankNum = 1
)

SELECT [GenericFutureId]
      ,[CurrentContractId]
      ,[CurrentSymbol]
      ,[ExpiryDate]
      ,[CurrentOpenInterest]
      ,[RollingPeriodStartDate]
      ,[DayToRollingPeriodStart]
      ,[DayToExpiry]
      ,[IsBusinessDayRoll]
      ,[IsLiquidityLow]
      ,[IsLiquidityRoll]
      ,[IsRollingPeriod]
      ,[NextContractId]
      ,[NextMaturityDate]
      ,[NextSymbol]
      ,[NextOpenInterest]
FROM CurrentAndNextContracts
WHERE Rank = 1;

GO
/****** Object:  Table [book].[H_ExecutionType]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [book].[H_ExecutionType](
	[ExecutionTypeId] [int] NOT NULL,
	[Code] [nvarchar](5) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Description] [nvarchar](100) NULL,
	[ValidFrom] [datetime2](7) NOT NULL,
	[ValidTo] [datetime2](7) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_H_ExecutionType]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_H_ExecutionType] ON [book].[H_ExecutionType]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [book].[ExecutionType]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [book].[ExecutionType](
	[ExecutionTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](5) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Description] [nvarchar](100) NULL,
	[ValidFrom] [datetime2](7) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](7) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_ExecutionType] PRIMARY KEY CLUSTERED 
(
	[ExecutionTypeId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_ExecutionTypeCode] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [book].[H_ExecutionType])
)
GO
/****** Object:  Table [val].[InstrumentValuation]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [val].[InstrumentValuation](
	[InstrumentId] [int] NOT NULL,
	[Price] [decimal](18, 6) NOT NULL,
	[PriceDate] [date] NOT NULL,
	[PreviousPrice] [decimal](18, 6) NOT NULL,
	[PreviousPriceDate] [date] NOT NULL,
	[ValuationFactor] [decimal](18, 6) NOT NULL,
	[InstrumentValue] [decimal](18, 6) NOT NULL,
	[PreviousInstrumentValue] [decimal](18, 6) NOT NULL,
	[PriceReturn] [decimal](18, 6) NOT NULL,
	[Currency] [char](3) NOT NULL,
 CONSTRAINT [PK_InstrumentValuation] PRIMARY KEY CLUSTERED 
(
	[InstrumentId] ASC,
	[PriceDate] ASC,
	[Currency] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [val].[Instrument]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [val].[Instrument](
	[InstrumentId] [int] NOT NULL,
	[Symbol] [nvarchar](30) NOT NULL,
	[InstrumentType] [nvarchar](10) NOT NULL,
	[Currency] [char](3) NOT NULL,
 CONSTRAINT [PK_InstrumentId] PRIMARY KEY CLUSTERED 
(
	[InstrumentId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [val].[vwLastInstrumentValuation]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [val].[vwLastInstrumentValuation] AS
WITH RankedValuations AS (
    SELECT
        [InstrumentId],
        [Price],
        [PriceDate],
        [PreviousPrice],
        [PreviousPriceDate],
        [ValuationFactor],
        [InstrumentValue],
        [PreviousInstrumentValue],
        [PriceReturn],
        [Currency],
        ROW_NUMBER() OVER (PARTITION BY [InstrumentId], [Currency] ORDER BY [PriceDate] DESC) AS rn
    FROM 
        [val].[InstrumentValuation]
)

SELECT
    v.[InstrumentId],
	i.Symbol,
	i.InstrumentType,
    [Price],
    [PriceDate],
    [PreviousPrice],
    [PreviousPriceDate],
    [ValuationFactor],
    [InstrumentValue],
    [PreviousInstrumentValue],
    [PriceReturn],
    v.[Currency]
FROM 
    RankedValuations v
	JOIN val.Instrument i on i.InstrumentId = v.InstrumentId
WHERE 
    rn = 1;

GO
/****** Object:  Table [val].[PortfolioValuation]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [val].[PortfolioValuation](
	[PortfolioValuationId] [int] IDENTITY(1,1) NOT NULL,
	[PortfolioId] [tinyint] NOT NULL,
	[TotalValue] [decimal](18, 6) NOT NULL,
	[GrossExposure] [decimal](18, 6) NOT NULL,
	[NetExposure] [decimal](18, 6) NOT NULL,
	[PnL] [decimal](18, 6) NOT NULL,
	[ROI] [decimal](18, 6) NOT NULL,
	[Currency] [char](3) NOT NULL,
	[ValuationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_PortfolioValuationId] PRIMARY KEY CLUSTERED 
(
	[PortfolioValuationId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [val].[PositionValuation]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [val].[PositionValuation](
	[PositionValuationId] [int] IDENTITY(1,1) NOT NULL,
	[PortfolioValuationId] [int] NOT NULL,
	[InstrumentId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[InstrumentValue] [decimal](18, 6) NOT NULL,
	[InstrumentPrice] [decimal](18, 6) NOT NULL,
	[InstrumentPriceDate] [datetime2](7) NOT NULL,
	[InstrumentPriceCurrency] [char](3) NOT NULL,
	[ValuationCurrency] [char](3) NOT NULL,
	[FxRate] [decimal](12, 6) NOT NULL,
	[NetExposure] [decimal](18, 6) NOT NULL,
	[GrossExposure] [decimal](18, 6) NOT NULL,
	[PnL] [decimal](18, 6) NOT NULL,
	[ROI] [decimal](18, 6) NOT NULL,
	[Weight] [decimal](18, 6) NOT NULL,
 CONSTRAINT [PK_PositionValuation] PRIMARY KEY CLUSTERED 
(
	[PositionValuationId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_PositionValuation] UNIQUE NONCLUSTERED 
(
	[PortfolioValuationId] ASC,
	[InstrumentId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [val].[vwLastPositionValuation]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [val].[vwLastPositionValuation] AS
WITH lastPortfolioValuation AS (
Select MAX(PortfolioValuationId) AS PortfolioValuationId, PortfolioId FROM val.PortfolioValuation
GROUP BY PortfolioId
) SELECT p.[PositionValuationId]
      ,p.[PortfolioValuationId]
	  ,f.ValuationDate
	  ,f.TotalValue AS PortfolioTotalValue
	  ,f.Currency AS BaseCurrency
	  ,f.GrossExposure AS PortfolioGrossExposure
	  ,f.NetExposure AS PortfolioNetExposure
	  ,f.PnL AS PortfolioPnl
	  ,f.ROI AS PortfolioRoi	
	  ,i.InstrumentId
      ,i.Symbol
	  ,i.InstrumentType
	  ,i.Currency AS InstrumentCurrency
      ,[Quantity]
      ,[InstrumentValue]
      ,[InstrumentPrice]
      ,[InstrumentPriceDate]
      ,[InstrumentPriceCurrency]
      ,[ValuationCurrency]
      ,[FxRate]
      ,p.[NetExposure] AS PositionNetExposure
      ,p.[GrossExposure] AS PositionGrossExposure
      ,p.[PnL] AS PositionPnl
      ,p.[ROI] AS PositionRoi
      ,[Weight] AS PositionWeight
  FROM [val].[PositionValuation] p
  JOIN val.Instrument i ON i.InstrumentId = p.InstrumentId
  JOIN val.PortfolioValuation f ON f.PortfolioValuationId = p.PortfolioValuationId
  JOIN lastPortfolioValuation l ON l.PortfolioValuationId = f.PortfolioValuationId
GO
/****** Object:  Table [instr].[Cfd_H]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [instr].[Cfd_H](
	[CfdId] [int] NOT NULL,
	[UnderlyingInstrumentId] [int] NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_Cfd_H]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_Cfd_H] ON [instr].[Cfd_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [instr].[Cfd]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [instr].[Cfd](
	[CfdId] [int] NOT NULL,
	[UnderlyingInstrumentId] [int] NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_Cfd] PRIMARY KEY CLUSTERED 
(
	[CfdId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [instr].[Cfd_H])
)
GO
/****** Object:  Table [val].[FxRate]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [val].[FxRate](
	[BaseCurrency] [char](3) NOT NULL,
	[QuoteCurrency] [char](3) NOT NULL,
	[Value] [decimal](12, 6) NOT NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_FxRate] PRIMARY KEY CLUSTERED 
(
	[BaseCurrency] ASC,
	[QuoteCurrency] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [val].[Position]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [val].[Position](
	[PortfolioId] [tinyint] NOT NULL,
	[InstrumentId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[AvgEntryPriceLocal] [decimal](18, 6) NOT NULL,
	[GrossTotalCostLocal] [decimal](18, 6) NOT NULL,
	[NetTotalCostLocal] [decimal](18, 6) NOT NULL,
	[LastTradeAllocationId] [int] NOT NULL,
	[PositionDate] [date] NOT NULL,
	[Currency] [char](3) NOT NULL,
	[IsSwap] [bit] NOT NULL,
 CONSTRAINT [PK_Position] PRIMARY KEY CLUSTERED 
(
	[PortfolioId] DESC,
	[InstrumentId] ASC,
	[Currency] ASC,
	[PositionDate] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [val].[vwLastPositionValuation2]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [val].[vwLastPositionValuation2] AS
SELECT  [PortfolioId]
      ,p.[InstrumentId]
      ,[Quantity]
      ,[AvgEntryPriceLocal]
      ,[GrossTotalCostLocal]
      ,[NetTotalCostLocal]
      ,[PositionDate]
      ,p.[Currency] as PositionCurrency	   
      ,[Symbol]
      ,[InstrumentType]
      ,[Price]
      ,[PriceDate]
      ,[PreviousPrice]
      ,[PreviousPriceDate]
      ,[ValuationFactor]
      ,[InstrumentValue]
      ,[PreviousInstrumentValue]
      ,[PriceReturn]
	  ,[Quantity]*[InstrumentValue] as MarketValue
	  ,[Quantity]*PriceReturn*[PreviousInstrumentValue] as Pnl
  FROM [val].[Position] p
  JOIN [val].vwLastInstrumentValuation v on v.InstrumentId = p.InstrumentId  and v.Currency = p.Currency
  JOIN [val].FxRate r on r.BaseCurrency = 'USD'and r.QuoteCurrency = v.Currency



GO
/****** Object:  View [val].[vwPositionValuationPnL]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





















/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [val].[vwPositionValuationPnL] AS
WITH Instruments AS (
    SELECT
        i.InstrumentId,
        i.Symbol,
        i.InstrumentType,
        i.Currency,
        gen.PointValue
    FROM [port].Instrument i
    LEFT JOIN instr.FutureContract fc ON fc.FutureContractId = i.InstrumentId
    LEFT JOIN instr.GenericFuture gen ON gen.GenericFutureId = fc.GenericFutureId
), PositionValuation AS (
    SELECT
        P.PortfolioId,
        ptf.Currency AS PortfolioCurrency,
        P.InstrumentId,
		P.IsSwap,
        i.Symbol,
        i.InstrumentType,
        i.Currency AS InstrumentCurrency,
        P.Quantity,
        P.AvgEntryPriceLocal,
        P.PositionValueLocal,
        P.GrossTotalCostLocal,
        P.NetTotalCostLocal,
        P.LastTradeAllocationId,
        P.PositionDate,
        P.Currency AS PositionCurrency,
    
        MD.LastPriceEod,
        MD.Currency AS PriceCurrency,
        i.PointValue,
        (
            SELECT TOP 1 MD.LastPriceEod
            FROM [mktdata].[MarketData] MD
            --WHERE MD.InstrumentId = P.InstrumentId AND MD.LastUpdateDateEod <= '20231229'
            WHERE MD.InstrumentId = P.InstrumentId AND MD.LastUpdateDateEod <= P.PositionDate
            ORDER BY MD.LastUpdateDateEod DESC
        ) AS Price,
        COALESCE(
            (
                SELECT TOP 1 FXR.LastValueEod
                FROM [mktdata].[FxRate] FXR
                --WHERE FXR.BaseCurrency = MD.Currency AND FXR.QuoteCurrency = ptf.Currency AND FXR.LastUpdateDateEod <= '20231229'
                WHERE FXR.BaseCurrency = MD.Currency AND FXR.QuoteCurrency = ptf.Currency AND FXR.LastUpdateDateEod <= P.PositionDate
                ORDER BY FXR.LastUpdateDateEod DESC
            ), 
            1
        ) AS FxRate -- Use COALESCE to default to 1
    FROM [port].[Position] P
    JOIN [port].Portfolio ptf ON ptf.PortfolioId = P.PortfolioId
    JOIN Instruments i ON i.InstrumentId = P.InstrumentId
    OUTER APPLY (
        SELECT TOP 1
            MD.LastPriceEod,
            MD.Currency
        FROM [mktdata].[MarketData] MD
        --WHERE MD.InstrumentId = P.InstrumentId AND MD.LastUpdateDateEod <= '20231229'
        WHERE MD.InstrumentId = P.InstrumentId AND MD.LastUpdateDateEod <= P.PositionDate
        ORDER BY MD.LastUpdateDateEod DESC
    ) MD
), PositionValuationWithPnL as(
SELECT
    PV.PortfolioId,
    PV.PortfolioCurrency,
    PV.InstrumentId,
	PV.IsSwap,
    PV.Symbol,
 ( ((IIF(PV.PointValue IS NULL, PV.Price, PV.Price * PV.PointValue) * PV.FxRate) * PV.Quantity) - (IIF(PV.PointValue IS NULL, PV.PositionValueLocal, PV.PositionValueLocal * PV.PointValue) * PV.FxRate)) AS PnL,
    PV.InstrumentType,
    PV.InstrumentCurrency,
    PV.Quantity,
    PV.AvgEntryPriceLocal,
    PV.AvgEntryPriceLocal * PV.FxRate AS AvgEntryPriceBase,
    IIF(PV.PointValue IS NULL, PV.PositionValueLocal, PV.PositionValueLocal * PV.PointValue) AS PositionValueLocal,
    IIF(PV.PointValue IS NULL, PV.PositionValueLocal, PV.PositionValueLocal * PV.PointValue) * PV.FxRate AS PositionValueBase,
    PV.GrossTotalCostLocal,
    PV.GrossTotalCostLocal * PV.FxRate AS GrossTotalCostBase,
    PV.NetTotalCostLocal,
    PV.NetTotalCostLocal * PV.FxRate AS NetTotalCostBase,
    PV.LastTradeAllocationId,
    PV.PositionDate,
    PV.PositionCurrency,
    PV.Price,
    PV.PriceCurrency,
    PV.PointValue,
    PV.FxRate,
    IIF(PV.PointValue IS NULL, PV.Price, PV.Price * PV.PointValue) AS InstrumentValueLocal,
    IIF(PV.PointValue IS NULL, PV.Price, PV.Price * PV.PointValue) * PV.FxRate AS InstrumentValueBase

FROM PositionValuation PV
)  SELECT  [PortfolioId]
      ,[PortfolioCurrency]
      ,[InstrumentId]
	  ,IsSwap
      ,[Symbol]
      ,[PnL]
	  , PnL - LAG(PnL, 1, 0) OVER (PARTITION BY PortfolioId, InstrumentId ORDER BY PositionDate) AS DailyPnLChange
      ,[InstrumentType]
      ,[InstrumentCurrency]
      ,[Quantity]
      ,[AvgEntryPriceLocal]
      ,[AvgEntryPriceBase]
      ,[PositionValueLocal]
      ,[PositionValueBase]
      ,[GrossTotalCostLocal]
      ,[GrossTotalCostBase]
      ,[NetTotalCostLocal]
      ,[NetTotalCostBase]
      ,[LastTradeAllocationId]
      ,[PositionDate]
      ,[PositionCurrency]
 
      ,[Price]
      ,[PriceCurrency]
      ,[PointValue]
      ,[FxRate]
      ,[InstrumentValueLocal]
      ,[InstrumentValueBase]
  FROM [PositionValuationWithPnL]




GO
/****** Object:  Table [trd].[H_TradeAllocation]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trd].[H_TradeAllocation](
	[TradeAllocationId] [int] NOT NULL,
	[TradeId] [int] NOT NULL,
	[PortfolioId] [tinyint] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](18, 6) NOT NULL,
	[GrossAmount] [decimal](18, 6) NOT NULL,
	[NetAmount] [decimal](18, 6) NOT NULL,
	[Commission] [decimal](18, 6) NOT NULL,
	[Fees] [decimal](18, 6) NOT NULL,
	[PositionSide] [char](1) NULL,
	[TradingAccount] [nvarchar](30) NOT NULL,
	[ValidFrom] [datetime2](7) NOT NULL,
	[ValidTo] [datetime2](7) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_H_TradeAllocation]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_H_TradeAllocation] ON [trd].[H_TradeAllocation]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [trd].[TradeAllocation]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trd].[TradeAllocation](
	[TradeAllocationId] [int] IDENTITY(1,1) NOT NULL,
	[TradeId] [int] NOT NULL,
	[PortfolioId] [tinyint] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](18, 6) NOT NULL,
	[GrossAmount] [decimal](18, 6) NOT NULL,
	[NetAmount] [decimal](18, 6) NOT NULL,
	[Commission] [decimal](18, 6) NOT NULL,
	[Fees] [decimal](18, 6) NOT NULL,
	[PositionSide] [char](1) NULL,
	[TradingAccount] [nvarchar](30) NOT NULL,
	[ValidFrom] [datetime2](7) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](7) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_TradeAllocation] PRIMARY KEY CLUSTERED 
(
	[TradeAllocationId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [trd].[H_TradeAllocation])
)
GO
/****** Object:  View [trd].[vwTradeAllocation]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO










/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [trd].[vwTradeAllocation] as
SELECT  [TradeAllocationId]
      ,t.[TradeId]
      ,[OrderId]
      ,[RebalancingId]
      ,[EmsxSequence]
      ,[EmsxOrderCreatedOn]
      ,[InstrumentId]
      ,t.[Symbol]
      ,t.[InstrumentType]
      ,[ExchangeCode]
      ,[Sedol]
      ,[BuySellIndicator]
      ,[OrderQuantity]
      ,[FilledQuantity]
      ,[AvgPrice]
      ,[DayAveragePrice]
      ,[TradeCurrency]
      ,[TradeDate]
      ,[Principal]
      ,t.[NetAmount]
      ,[SettlementDate]
      ,[SettlementCurrency]
      ,[BrokerCommission]
      ,[CommissionRate]
      ,[MiscFees]
      ,[Notes]
      ,[Trader]
      ,[BrokerCode]
      ,[TradeDesk]
      ,[IsCfd]
      ,[ExecutionChannel]
      ,[CreatedOn]
      ,[TotalCharges]
      ,[FxemTradeId]
      ,[FxemOrderId]
      ,[TradeStatus]
      ,[FxCurrency1]
      ,[FXCurrency1Amount]
      ,[FxCurrency2]
      ,[FXCurrency2Amount]
      ,[BookedOn]
      ,[PortfolioId]
      ,a.[Quantity] as AllocationQuantity
      ,[Price]
      ,a.[GrossAmount] as AllocationGrossAmount
      ,a.[NetAmount] as AllocationNetAmount
      ,a.[Commission] as AllocationCommission
      ,a.[Fees] as AllocationFees
      ,[PositionSide]
      ,[TradingAccount]
  FROM [trd].[TradeAllocation] a
  JOIN trd.vwTrade t on t.TradeId = a.TradeId

GO
/****** Object:  View [book].[vwDailyBookedTrades]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


















/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [book].[vwDailyBookedTrades] as
SELECT [TradeId]
      ,[TradeStatus]
      ,[InstrumentId]
      ,[Symbol]
      ,[TradeSide]
      ,[TradeQuantity]
      ,[NominalQuantity]
      ,[TradeCurrency]
      ,[TradeDate]
      ,[Exchange]
      ,[ExecutionChannel]
      ,[ExecutionType]
      ,[IsSwap]
      ,[RebalancingId]
      ,[ContractMultiplier]
      ,[PriceScalingFactor]
      ,[AvgPrice]
      ,[Principal]
      ,[TradeValue]
      ,[InstrumentType]
      ,[TradeInstrumentType]
      ,[ExecutionDesk]
      ,[ExecutionBroker]
      ,[ExecutionAccount]
      ,[Isin]
      ,[Sedol]
      ,[Cusip]
      ,[SecurityName]
      ,[LocalExchangeSymbol]
      ,[SettlementDate]
      ,[EmsxOrderId]
      ,[OrderReferenceId]
      ,[OrderQuantity]
      ,[OrderType]
      ,[StrategyType]
      ,[TimeInForce]
      ,[OrderExecutionInstruction]
      ,[OrderHandlingInstruction]
      ,[OrderInstruction]
      ,[LimitPrice]
      ,[StopPrice]
      ,[OriginatingTraderUUId]
      ,[TraderName]
      ,[TraderUUId]
      ,[UserCommissionAmount]
      ,[UserCommissionRate]
      ,[UserFees]
      ,[UserNetMoney]
      ,[YellowKey]
      ,[NumberOfFills]
      ,[FirstFillTimeUtc]
      ,[LastFillTimeUtc]
      ,[MaxFillPrice]
      ,[MinFillPrice]
      ,[BookedOnUtc]
      ,[LastCorrectedOnUtc]
      ,[CanceledOnUtc]
    
  FROM [book].[Trade]
  where cast(BookedOnUtc as date) = cast(GETUTCDATE()as date)
GO
/****** Object:  Table [ord].[ExecutionProfileSelectionRule_H]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[ExecutionProfileSelectionRule_H](
	[ExecutionProfileSelectionRuleId] [int] NOT NULL,
	[PortfolioId] [tinyint] NULL,
	[BrokerId] [int] NULL,
	[InstrumentTypeId] [tinyint] NULL,
	[TradeModeId] [tinyint] NOT NULL,
	[ExchangeId] [smallint] NULL,
	[ExecutionProfileId] [int] NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_ExecutionProfileSelectionRule_H]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_ExecutionProfileSelectionRule_H] ON [ord].[ExecutionProfileSelectionRule_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [ord].[ExecutionProfileSelectionRule]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[ExecutionProfileSelectionRule](
	[ExecutionProfileSelectionRuleId] [int] IDENTITY(1,1) NOT NULL,
	[PortfolioId] [tinyint] NULL,
	[BrokerId] [int] NULL,
	[InstrumentTypeId] [tinyint] NULL,
	[TradeModeId] [tinyint] NOT NULL,
	[ExchangeId] [smallint] NULL,
	[ExecutionProfileId] [int] NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_ExecutionProfileSelectionRule] PRIMARY KEY CLUSTERED 
(
	[ExecutionProfileSelectionRuleId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [ord].[ExecutionProfileSelectionRule_H])
)
GO
/****** Object:  View [trans].[vwPnlInnocap_withRoll]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [trans].[vwPnlInnocap_withRoll] as
		  select 
		  case when I.InstrumentType = 'EQU' THEN 'EquityCFD'
					 when I.InstrumentType = 'FUT' THEN 'Future'
					 WHEN I.InstrumentType = 'FXFWD' THEN 'FXForwards'
					 end  as 'Asset Type'
			   ,I.Symbol 'Ticker'
			   ,isnull(I.BbgGlobalId,'') 'Bloomberg ID'
			   ,'' as Cusip
			   ,isnull(I.ISIN,'') 'ISIN'
			   ,'' as Sedol
			   ,case when [Quantity] > 0 THEN 'Long'
					when [Quantity] < 0 THEN 'Short' 
					ELSE ''
					end as 'Side (Long/Short)'
			  ,[Quantity] 'Shares/Notional'
			   ,[PriceCurrency] as 'CCY'
			   ,[AvgEntryPriceLocal] 'Local Cost'
			  ,[AvgEntryPriceBase] 'Base Cost'
	  			  ,[Price] 'Local Price'
			  ,price*isnull(FxRate,1) 'Base Price'
			  ,PositionValueLocal 'Local MV'
			  ,PositionValueBase 'Base MV'
			  ,'MSET' AS 'Clearing Broker'
			  ,[DailyPnLChange]/FxRate 'Total daily PNL (realized & unrealized) Local' -- 
			  ,[DailyPnLChange] 'Total daily PNL (realized & unrealized) Base' -- 
			  ,'' AS 'Total MTD PNL (realized & unrealized) Local'
			  ,'' AS 'Total MTD PNL (realized & unrealized) Base'
			  ,FxRate as  'FX Rate'
			  ,'' as 'Daily %'
			  ,'' as 'MTD %'

		  from [val].[vwPositionValuationPnL] V (nolock)
		  LEFT JOIN [instr].[vwInstrument] I on I.InstrumentId = V.[InstrumentId]

		  --where PositionDate = DATEADD(day, - (CASE WHEN DATEPART(dw, cast(GETDATE() as date)) = 2 THEN 3 ELSE 1 END), cast(GETDATE() as date))
		  where PositionDate = '2024-06-24'

		  and [DailyPnLChange] <> 0.000000
		  --and [Quantity] <> 0
		 
GO
/****** Object:  View [ord].[vwOrderHistory]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO










/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [ord].[vwOrderHistory] as
SELECT  [OrderId]
      ,[RebalancingSessionId]
      ,ord.[InstrumentId]
	  , ins.Symbol
	  ,ins.Name
	  ,ins.Currency
	  ,ins.Exchange
	  ,ins.MarketSector
	  ,insType.Mnemonic as InstrumentType
      ,ord.[OrderSideId]
	  ,os.Mnemonic as OrderSide
      ,[Quantity]
      ,ord.[BrokerId]
	  ,bro.Code as BrokerCode
	  ,bro.Name as BrokerName
      ,ord.[OrderTypeId]
	  ,ot.Mnemonic as OrderType
      ,ord.[TimeInForceId]
	  ,tif.Mnemonic as TimeInForce
      ,ord.[ExecutionAlgorithmId]
	  ,algo.Mnmemonic as ExecutionAlgo  
      ,ord.[HandlingInstructionId]
	  ,hi.Code as HandlingInstruction
      ,ord.[ExecutionChannelId]
      ,ec.Mnemonic as ExecutionChannel
	  ,ord.[TradeModeId]
	  ,tm.Mnemonic as TradeMode
      ,[TradeDate]
      ,ord.[TradingDeskId]
	  ,td.Code as TradingDesk
      ,[CreatedOn]
      ,[Param1]
      ,[Value1]
      ,[Param2]
      ,[Value2]
      ,[Param3]
      ,[Value3]
      ,[Param4]
      ,[Value4]
      ,[Param5]
      ,[Value5]
      ,[Param6]
      ,[Value6]
      ,[Param7]
      ,[Value7]
      ,[Param8]
      ,[Value8]
  FROM [ord].[H_Order] ord
  LEFT JOIN ord.Broker bro on bro.BrokerId = ord.BrokerId
  LEFT JOIN ord.OrderSide os on os.OrderSideId = ord.OrderSideId
  LEFT JOIN ord.Instrument ins on ins.InstrumentId = ord.InstrumentId
  LEFT JOIN ord.InstrumentType insType on insType.InstrumentTypeId= ins.InstrumentTypeId
  LEFT JOIN ord.TradeMode tm on tm.TradeModeId = ord.TradeModeId
  LEFT JOIN ord.OrderType ot on ot.OrderTypeId=  ord.OrderTypeId
  LEFT JOIN ord.TimeInForce tif on tif.TimeInForceId = ord.TimeInForceId
  LEFT JOIN ord.HandlingInstruction hi on hi.HandlingInstructionId = ord.HandlingInstructionId
  LEFT JOIN ord.ExecutionChannel ec on ec.ExecutionChannelId = ord. ExecutionChannelId
  LEFT JOIN ord.TradingDesk td on td.TradingDeskId = ord.TradingDeskId
  LEFT JOIN ord.ExecutionAlgorithm algo on algo.ExecutionAlgorithmId = ord.ExecutionAlgorithmId



GO
/****** Object:  Table [risk].[Filter_H]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [risk].[Filter_H](
	[FilterId] [int] NOT NULL,
	[FilterCriterion1Id] [int] NOT NULL,
	[BooleanOperatorId] [tinyint] NULL,
	[FilterCriterion2Id] [int] NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_Filter_H]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_Filter_H] ON [risk].[Filter_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [risk].[Filter]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [risk].[Filter](
	[FilterId] [int] IDENTITY(1,1) NOT NULL,
	[FilterCriterion1Id] [int] NOT NULL,
	[BooleanOperatorId] [tinyint] NULL,
	[FilterCriterion2Id] [int] NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_FilterId] PRIMARY KEY CLUSTERED 
(
	[FilterId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_Filter] UNIQUE NONCLUSTERED 
(
	[FilterCriterion1Id] ASC,
	[BooleanOperatorId] ASC,
	[FilterCriterion2Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [risk].[Filter_H])
)
GO
/****** Object:  UserDefinedFunction [val].[tvGetPortfolioValuation]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [val].[tvGetPortfolioValuation] (@ValuationDate DATE)
RETURNS TABLE
AS
RETURN
(
    WITH lasteval AS (
        SELECT MAX(PortfolioValuationId) AS PortfolioValuationid 
        FROM val.PortfolioValuation 
        WHERE cast(ValuationDate  as DATE)= @ValuationDate AND PortfolioId = 1
    )
    SELECT  
        pftv.PortfolioId,
        pftv.Currency AS PortfolioCurrency,
        pftv.ValuationDate,
        pftv.GrossExposure AS TotalGrossExposure,
        pftv.NetExposure AS TotalNetExposure,
        pftv.PnL AS TotalPnl,
        pftv.ROI AS TotalRoi,
        pftv.TotalValue AS PortfolioTotalValue,
        ins.Symbol,
        ins.InstrumentType,
        ins.Currency AS InstrumentCurrency,
        [Quantity],
        [InstrumentValue],
        [InstrumentPrice],
        [InstrumentPriceDate],
        [InstrumentPriceCurrency],
        [ValuationCurrency],
        [FxRate],
        val.[NetExposure] AS PositionNetExposure,
        val.[GrossExposure] AS PositionGrossExposure,
        val.[PnL] AS PositionPnL,
        val.[ROI] AS PositionROI,
        val.[Weight] AS PositionWeight
    FROM 
        val.PositionValuation val
    JOIN 
        val.Instrument ins ON ins.InstrumentId = val.InstrumentId
    JOIN 
        val.PortfolioValuation pftv ON pftv.PortfolioValuationId = val.PortfolioValuationId
    JOIN 
        lasteval lastval ON lastval.PortfolioValuationid = pftv.PortfolioValuationId
)
GO
/****** Object:  Table [conv].[FutureConversionRule_H]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [conv].[FutureConversionRule_H](
	[FutureConversionRuleId] [int] NOT NULL,
	[PortfolioId] [tinyint] NULL,
	[ConvertToCross] [bit] NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_FutureConversionRule_H]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_FutureConversionRule_H] ON [conv].[FutureConversionRule_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [conv].[FutureConversionRule]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [conv].[FutureConversionRule](
	[FutureConversionRuleId] [int] IDENTITY(1,1) NOT NULL,
	[PortfolioId] [tinyint] NULL,
	[ConvertToCross] [bit] NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_FutureConversionRule] PRIMARY KEY CLUSTERED 
(
	[FutureConversionRuleId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [conv].[FutureConversionRule_H])
)
GO
/****** Object:  View [mktdata].[vwLastMarketData]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO













/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [mktdata].[vwLastMarketData] as
  WITH RankedMarketData AS (
    SELECT[InstrumentId]
      ,[LastPrice]
      ,[LastPriceEod]
      ,[VolumeAvg30Day]
      ,[MarketCap]
      ,[LastUpdateDate]
      ,[LastUpdateDateEod]
      ,[LastUpdateTime]
      ,[Currency]
       , ROW_NUMBER() OVER (PARTITION BY [InstrumentId] ORDER BY [LastUpdateDate]DESC,[LastUpdateTime]DESC,Currency ) AS rn
    FROM
        [mktdata].[MarketData]
)

 SELECT mkt.[InstrumentId]
      ,[LastPrice]
      ,[LastPriceEod]
      ,[VolumeAvg30Day]
      ,[MarketCap]
      ,[LastUpdateDate]
      ,[LastUpdateDateEod]
      ,[LastUpdateTime]
      ,mkt.[Currency]
FROM
    RankedMarketData mkt
	JOIN mktdata.Instrument ins on ins.InstrumentId = mkt.InstrumentId
WHERE
    rn = 1;



GO
/****** Object:  UserDefinedFunction [check].[tvCompareTradesWithPositions]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE FUNCTION [check].[tvCompareTradesWithPositions] (@TradeDate date)
RETURNS TABLE
AS
RETURN
(
with trades as(SELECT SUM(Quantity) as Quantity, Symbol
  FROM [book].[vwTradeAllocation]
  where TradeDate<=@TradeDate
  group by Symbol
), positions as(
select pos.Symbol, pos.Quantity, pos.PositionDate from [port].vwPosition pos where pos.PositionDate = @TradeDate
) , compare as (select pos.Symbol as PosSymbol,trd.Symbol  as TradeSymbol, trd.Quantity , pos.Quantity as PosQuantity, IIF(trd.Quantity <>pos.Quantity, 1, 0) as mismatch 
from positions pos
FULL JOIn trades trd on trd.Symbol = pos.Symbol

)select top(100000) * from compare
--where 
-- mismatch = 1 or (Quantity <> 0 and PosQuantity is null) or (Quantity is null and PosQuantity <>0)
order by PosSymbol, TradeSymbol
  )
GO
/****** Object:  View [instr].[vwInverseCurrencyPair]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO










/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [instr].[vwInverseCurrencyPair] as
SELECT cp.[CurrencyPairId]
	  ,cp.Symbol
      ,cp.[BaseCurrencyId]
	  ,cp.BaseCurrencyCode
      ,cp.[QuoteCurrencyId]
	  ,cp.QuoteCurrencyCode
	  ,inverse.[CurrencyPairId]as InverseCurrencyPairId
	  ,inverse.Symbol as InverseSymbol
      ,inverse.[BaseCurrencyId] as InverseBaseCurrencyId
	  ,inverse.BaseCurrencyCode as InverseBaseCurrencyCode
      ,inverse.[QuoteCurrencyId] as InverseQuoteCurrencyId
	  ,inverse.QuoteCurrencyCode as InverseQuoteCurrencyCode
  FROM [instr].[vwCurrencyPair] cp
  INNER JOIN [instr].[vwCurrencyPair] inverse on inverse.BaseCurrencyId =cp.QuoteCurrencyId  AND inverse.QuoteCurrencyId = cp.BaseCurrencyId





GO
/****** Object:  UserDefinedFunction [trans].[ZZZ_tvSwapResetFileMSFSSW003]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [trans].[ZZZ_tvSwapResetFileMSFSSW003] (@EOMDate DATE)
RETURNS TABLE
AS
RETURN
  WITH RankedMarketData AS (
    SELECT[InstrumentId],
        [LastPriceEOD] as [LastPrice],
        LastUpdateDateEOD as [LastUpdateDate],
        [LastUpdateTime],
		Currency,
        ROW_NUMBER() OVER (PARTITION BY [InstrumentId] ORDER BY LastUpdateDateEOD DESC,[LastUpdateTime]DESC,Currency ) AS rn
    FROM
        [mktdata].[MarketData]
		where LastUpdateDateEOD <= @EOMDate
),  eomprices as (

SELECT
   mkt.[InstrumentId],
   ins.Symbol,
        [LastPrice],
        [LastUpdateDate],
        [LastUpdateTime],
		mkt.Currency,
		ins.QuoteCurrency,
		ins.QuoteFactor,
		ins.PriceScalingFactor
FROM
    RankedMarketData mkt
	JOIN mktdata.Instrument ins on ins.InstrumentId = mkt.InstrumentId
WHERE
    rn = 1
	), swappositions as (

SELECT distinct
      t.[InstrumentId]
	   ,MAX(t.TradeId) as ClientRef
	  ,i.ISIN
      ,IIF([Sedol]='',NULL,[Sedol]) as [Sedol]
	  ,i.[Symbol]
	  ,cast(@EOMDate as DATE) as TradeDate
      ,ISNULL(SUM([FilledQuantity]*i.FuturePointValue), SUM([FilledQuantity])) as Quantity
      ,[TradeCurrency]
      ,ISNULL(fs.SettlementCurrency, ISNULL(t.SettlementCurrency, t.TradeCurrency)) AS Currency
  FROM [trans].[Trade] t
  JOIN [trans].Instrument i on i.InstrumentId = t.InstrumentId
  LEFT JOIN trd.vwFutureSwap fs on fs.InstrumentId = t.InstrumentId
  WHERE 
    ((i.InstrumentType = 'EQU' AND t.IsCfd = 1) 
     OR (i.InstrumentId IN (SELECT InstrumentId FROM trd.vwFutureSwap)))
	 AND t.TradeDate <= @EOMDate
  group by 
   t.[InstrumentId]
      ,IIF([Sedol]='',NULL,[Sedol])   
	  ,i.ISIN
	  ,i.Symbol
      ,[TradeCurrency]   
      ,ISNULL(fs.SettlementCurrency, ISNULL(t.SettlementCurrency, t.TradeCurrency)) 
  )
  SELECT 
    'SW003' AS TrasationType,
    'NEW' AS TransactionStatus,
    CASE 
        WHEN Quantity>0 THEN 'SL'
        ELSE 'BC'
    END AS [PosType],
    cast(CONCAT(FORMAT(@EOMDate, 'yyyyMMdd'),ClientRef)as nvarchar(16)) AS [ClientRef#],
    '038QLFIP9' AS [CustAccount],
    'MSSW' AS [ExecBkr],
	IIF(pos.Sedol IS NULL, 'B','S')  AS SecType,
	IIF(pos.Sedol IS NULL, pos.Symbol, pos.Sedol)  AS [Sec ID],
	'' as [desc],
    FORMAT(pos.TradeDate, 'MM/dd/yyyy') AS TDate,
	FORMAT(trd.fnAddBusinessDays(pos.TradeDate,2), 'MM/dd/yyyy') AS SDate,
	pos.Currency AS CCY,
    ABS(pos.Quantity) AS [qty],
	ABS(px.LastPrice) AS [price],
	'' as comm,
	'' as commtype,
	'' as [Other Charges],
	'' as [Other Charges Type],
	'' as [net amount],
	'MSSW' as [cus bkr],
	'' as [mmgr],
	'' as [deal id],
	'R' as [Swap Reset]

FROM 
    swappositions pos
	JOIN eomprices px on px.InstrumentId = pos.InstrumentId

	where Quantity <> 0

GO
/****** Object:  Table [conv].[EquityConversionRule_H]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [conv].[EquityConversionRule_H](
	[EquityConversionRuleId] [int] NOT NULL,
	[PortfolioId] [tinyint] NULL,
	[ConvertToCfd] [bit] NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_EquityConversionRule_H]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_EquityConversionRule_H] ON [conv].[EquityConversionRule_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [conv].[EquityConversionRule]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [conv].[EquityConversionRule](
	[EquityConversionRuleId] [int] IDENTITY(1,1) NOT NULL,
	[PortfolioId] [tinyint] NULL,
	[ConvertToCfd] [bit] NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_EquityConversionRule] PRIMARY KEY CLUSTERED 
(
	[EquityConversionRuleId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [conv].[EquityConversionRule_H])
)
GO
/****** Object:  UserDefinedFunction [port].[tvGetPositionsAtDate]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [port].[tvGetPositionsAtDate] (@PositionDate DATE)
RETURNS TABLE
AS
RETURN
(
SELECT  [PortfolioId]
      ,p.[InstrumentId]
	  ,i.Symbol
	  ,i.InstrumentType
	  ,p.IsSwap
	  ,i.[Name]as InstrumentName
      ,[Quantity]
      ,[AvgEntryPriceLocal]
      ,[GrossTotalCostLocal]
      ,[NetTotalCostLocal]
      ,[LastTradeAllocationId]
      ,[PositionDate]
      ,p.[Currency]
  FROM [port].[Position] p
  JOIN [port].Instrument i on i.InstrumentId = p.InstrumentId
  where PositionDate = @PositionDate
  )
GO
/****** Object:  Table [trans].[H_PrimeBrokerCodeMapping]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[H_PrimeBrokerCodeMapping](
	[FileGenerationType] [nvarchar](20) NOT NULL,
	[InternalCode] [nvarchar](20) NOT NULL,
	[CounterpartyCode] [nvarchar](20) NOT NULL,
	[ValidFrom] [datetime2](7) NOT NULL,
	[ValidTo] [datetime2](7) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_H_PrimeBrokerCodeMapping]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_H_PrimeBrokerCodeMapping] ON [trans].[H_PrimeBrokerCodeMapping]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [trans].[PrimeBrokerCodeMapping]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[PrimeBrokerCodeMapping](
	[FileGenerationType] [nvarchar](20) NOT NULL,
	[InternalCode] [nvarchar](20) NOT NULL,
	[CounterpartyCode] [nvarchar](20) NOT NULL,
	[ValidFrom] [datetime2](7) GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
	[ValidTo] [datetime2](7) GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
 CONSTRAINT [PK_PrimeBrokerCodeMapping] PRIMARY KEY CLUSTERED 
(
	[FileGenerationType] ASC,
	[InternalCode] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [trans].[H_PrimeBrokerCodeMapping])
)
GO
/****** Object:  Table [conv].[CurrencyPairConversionRule_H]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [conv].[CurrencyPairConversionRule_H](
	[CurrencyPairConversionRuleId] [int] NOT NULL,
	[PortfolioId] [tinyint] NULL,
	[InvertPair] [bit] NOT NULL,
	[ConvertToForward] [bit] NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_CurrencyPairConversionRule_H]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_CurrencyPairConversionRule_H] ON [conv].[CurrencyPairConversionRule_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [conv].[CurrencyPairConversionRule]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [conv].[CurrencyPairConversionRule](
	[CurrencyPairConversionRuleId] [int] IDENTITY(1,1) NOT NULL,
	[PortfolioId] [tinyint] NULL,
	[InvertPair] [bit] NOT NULL,
	[ConvertToForward] [bit] NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_CurrencyPairConversionRule] PRIMARY KEY CLUSTERED 
(
	[CurrencyPairConversionRuleId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [conv].[CurrencyPairConversionRule_H])
)
GO
/****** Object:  Table [exec].[H_EmsxFill]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [exec].[H_EmsxFill](
	[Account] [nvarchar](50) NULL,
	[Amount] [int] NOT NULL,
	[AssetClass] [nvarchar](50) NULL,
	[BasketId] [int] NULL,
	[Bbgid] [nvarchar](15) NULL,
	[BlockId] [nvarchar](50) NULL,
	[Broker] [nvarchar](10) NOT NULL,
	[ClearingAccount] [nvarchar](20) NULL,
	[ClearingFirm] [nvarchar](50) NULL,
	[ContractExpDate] [date] NULL,
	[CorrectedFillId] [int] NULL,
	[Currency] [char](3) NOT NULL,
	[Cusip] [nvarchar](10) NULL,
	[DateTimeOfFill] [datetime2](7) NOT NULL,
	[Exchange] [nvarchar](5) NOT NULL,
	[ExecPrevSeqNo] [int] NULL,
	[ExecType] [nvarchar](20) NULL,
	[ExecutingBroker] [nvarchar](10) NULL,
	[FillId] [int] NOT NULL,
	[FillPrice] [decimal](18, 6) NOT NULL,
	[FillShares] [int] NOT NULL,
	[InvestorId] [nvarchar](50) NULL,
	[IsCFD] [bit] NOT NULL,
	[Isin] [nvarchar](12) NULL,
	[IsLeg] [bit] NULL,
	[LastCapacity] [nvarchar](20) NULL,
	[LastMarket] [nvarchar](20) NULL,
	[LimitPrice] [decimal](18, 6) NULL,
	[Liquidity] [nvarchar](50) NULL,
	[LocalExchangeSymbol] [nvarchar](8) NULL,
	[LocateBroker] [nvarchar](10) NULL,
	[LocateId] [nvarchar](50) NULL,
	[LocateRequired] [bit] NULL,
	[MultiLegId] [nvarchar](50) NULL,
	[OccSymbol] [nvarchar](50) NULL,
	[OrderExecutionInstruction] [nvarchar](50) NULL,
	[OrderHandlingInstruction] [nvarchar](20) NULL,
	[OrderId] [int] NOT NULL,
	[OrderInstruction] [nvarchar](50) NULL,
	[OrderOrigin] [nvarchar](10) NULL,
	[OrderReferenceId] [nvarchar](50) NULL,
	[OriginatingTraderUUId] [int] NULL,
	[ReroutedBroker] [nvarchar](20) NULL,
	[RouteCommissionAmount] [decimal](18, 6) NULL,
	[RouteCommissionRate] [decimal](10, 6) NULL,
	[RouteExecutionInstruction] [nvarchar](50) NULL,
	[RouteHandlingInstruction] [nvarchar](50) NULL,
	[RouteId] [int] NULL,
	[RouteNetMoney] [decimal](24, 6) NULL,
	[RouteNotes] [nvarchar](200) NULL,
	[RouteShares] [int] NULL,
	[SecurityName] [nvarchar](200) NULL,
	[Sedol] [nvarchar](10) NULL,
	[SettlementDate] [date] NULL,
	[Side] [nvarchar](2) NOT NULL,
	[StopPrice] [decimal](18, 6) NULL,
	[StrategyType] [nvarchar](20) NULL,
	[Ticker] [nvarchar](30) NOT NULL,
	[Tif] [nvarchar](10) NULL,
	[TraderName] [nvarchar](20) NULL,
	[TraderUUId] [int] NULL,
	[Type] [nvarchar](50) NULL,
	[UserCommissionAmount] [decimal](18, 6) NULL,
	[UserCommissionRate] [decimal](8, 6) NULL,
	[UserFees] [decimal](18, 6) NULL,
	[UserNetMoney] [decimal](24, 6) NULL,
	[YellowKey] [nvarchar](10) NOT NULL,
	[ValidFrom] [datetime2](7) NOT NULL,
	[ValidTo] [datetime2](7) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_H_EmsxFill]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_H_EmsxFill] ON [exec].[H_EmsxFill]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [exec].[EmsxFill]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [exec].[EmsxFill](
	[Account] [nvarchar](50) NULL,
	[Amount] [int] NOT NULL,
	[AssetClass] [nvarchar](50) NULL,
	[BasketId] [int] NULL,
	[Bbgid] [nvarchar](15) NULL,
	[BlockId] [nvarchar](50) NULL,
	[Broker] [nvarchar](10) NOT NULL,
	[ClearingAccount] [nvarchar](20) NULL,
	[ClearingFirm] [nvarchar](50) NULL,
	[ContractExpDate] [date] NULL,
	[CorrectedFillId] [int] NULL,
	[Currency] [char](3) NOT NULL,
	[Cusip] [nvarchar](10) NULL,
	[DateTimeOfFill] [datetime2](7) NOT NULL,
	[Exchange] [nvarchar](5) NOT NULL,
	[ExecPrevSeqNo] [int] NULL,
	[ExecType] [nvarchar](20) NULL,
	[ExecutingBroker] [nvarchar](10) NULL,
	[FillId] [int] NOT NULL,
	[FillPrice] [decimal](18, 6) NOT NULL,
	[FillShares] [int] NOT NULL,
	[InvestorId] [nvarchar](50) NULL,
	[IsCFD] [bit] NOT NULL,
	[Isin] [nvarchar](12) NULL,
	[IsLeg] [bit] NULL,
	[LastCapacity] [nvarchar](20) NULL,
	[LastMarket] [nvarchar](20) NULL,
	[LimitPrice] [decimal](18, 6) NULL,
	[Liquidity] [nvarchar](50) NULL,
	[LocalExchangeSymbol] [nvarchar](8) NULL,
	[LocateBroker] [nvarchar](10) NULL,
	[LocateId] [nvarchar](50) NULL,
	[LocateRequired] [bit] NULL,
	[MultiLegId] [nvarchar](50) NULL,
	[OccSymbol] [nvarchar](50) NULL,
	[OrderExecutionInstruction] [nvarchar](50) NULL,
	[OrderHandlingInstruction] [nvarchar](20) NULL,
	[OrderId] [int] NOT NULL,
	[OrderInstruction] [nvarchar](50) NULL,
	[OrderOrigin] [nvarchar](10) NULL,
	[OrderReferenceId] [nvarchar](50) NULL,
	[OriginatingTraderUUId] [int] NULL,
	[ReroutedBroker] [nvarchar](20) NULL,
	[RouteCommissionAmount] [decimal](18, 6) NULL,
	[RouteCommissionRate] [decimal](10, 6) NULL,
	[RouteExecutionInstruction] [nvarchar](50) NULL,
	[RouteHandlingInstruction] [nvarchar](50) NULL,
	[RouteId] [int] NULL,
	[RouteNetMoney] [decimal](24, 6) NULL,
	[RouteNotes] [nvarchar](200) NULL,
	[RouteShares] [int] NULL,
	[SecurityName] [nvarchar](200) NULL,
	[Sedol] [nvarchar](10) NULL,
	[SettlementDate] [date] NULL,
	[Side] [nvarchar](2) NOT NULL,
	[StopPrice] [decimal](18, 6) NULL,
	[StrategyType] [nvarchar](20) NULL,
	[Ticker] [nvarchar](30) NOT NULL,
	[Tif] [nvarchar](10) NULL,
	[TraderName] [nvarchar](20) NULL,
	[TraderUUId] [int] NULL,
	[Type] [nvarchar](50) NULL,
	[UserCommissionAmount] [decimal](18, 6) NULL,
	[UserCommissionRate] [decimal](8, 6) NULL,
	[UserFees] [decimal](18, 6) NULL,
	[UserNetMoney] [decimal](24, 6) NULL,
	[YellowKey] [nvarchar](10) NOT NULL,
	[ValidFrom] [datetime2](7) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](7) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_EmsxFill] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC,
	[FillId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [exec].[H_EmsxFill])
)
GO
/****** Object:  View [trans].[vwCMGLFND_TradesFileMSD01_TEST]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE VIEW [trans].[vwCMGLFND_TradesFileMSD01_TEST] AS
SELECT  
    'D01' AS [Transaction_Type],    
    CASE 
        WHEN trd.TradeCurrency = 'USD' THEN '052BATTC2'  
        ELSE '05ABATTC3' 
    END AS [Account],   
    alloc.TradeAllocationId AS [Client_Ref_No],
    '1' AS Version_Number,
    trd.TradeStatus AS Transaction_Status,
    'B' AS Sec_identifier_Type,
    ins.Symbol AS Sec_Identifier,
    '' AS Contract_Year,
    '' AS Contract_Month,
    '' AS Contract_Day,
    ins.[Name] AS Contract_Security_Description,
    ExchangeCode AS [Market/Exchange],   
    CASE 
        WHEN FilledQuantity > 0 THEN 'B' 
        ELSE 'S' 
    END AS [Buy Sell Indicator],   
    '' AS Trade_Type,
    '' AS order_To_Close_Ind,
    '' AS Average_Price_Ind,
    '' AS Spread_Trade_Ind,
    '' AS Night_Trade_Ind,
    '' AS Exchange_for_Physical_Ind,
    '' AS [Block_Trade_Ind],
    '' AS [Off_Exchange_Ind],
    CAST(FORMAT(trd.TradeDate, 'MM/dd/yyyy') AS NVARCHAR(10)) AS [Trade_Date],
    '' AS ExecutionTime,
    ABS(FilledQuantity) AS Quantity,
    ROUND(trd.AvgPrice, 5) AS Price,
    '' AS [Call/Put],
    '' AS Strike_Price,
    'MSPB' AS Executing_Broker,
    'MSPB' AS Clearing_Broker,
    '' AS Give_Up_Reference,
    '' AS Hearsay_Ind,
    '' AS Execution_Fee,
    '' AS Execution_Fee_CCY,
    trd.BrokerCommission AS Commission,
    '' AS Commission_CCY,
    trd.MiscFees AS Exchange_Fee,
    '' AS Exchange_Fee_CCY,
    trd.OrderId AS OrderId,
    '' AS DealId,
    'E' AS Execution_Type
FROM 
    [Trading].[trd].[Trade] trd
JOIN 
    trans.TradeAllocation alloc ON alloc.TradeId = trd.TradeId
JOIN 
    trans.Instrument ins ON ins.InstrumentId = trd.InstrumentId
LEFT JOIN 
    trans.[vwLastFileTransmission] ft ON ft.TransmissionType = 'MSD01TEST'
WHERE 
    ins.InstrumentType = 'FUT'
    AND trd.TradeDate = DATEADD(day,-1, CAST(GETDATE() AS DATE)) 
    AND ins.InstrumentId NOT IN (SELECT InstrumentId FROM trd.vwFutureSwap)
    AND (ft.TransmittedOn IS NULL OR ft.TransmittedOn < trd.BookedOn);
GO
/****** Object:  View [trans].[vwCMGLFND_TradesFileMSSW002_TEST]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO











CREATE VIEW [trans].[vwCMGLFND_TradesFileMSSW002_TEST] AS
SELECT  
    'SW002' AS [Transaction Type],
    trd.TradeStatus AS [Transaction Status],
    trd.BuySellIndicator AS [Buy Sell Indicator],
    CASE 
        WHEN trd.BuySellIndicator = 'S' AND (alloc.PositionSide IN ('L', 'C')) THEN 'L'
        WHEN trd.BuySellIndicator = 'S' AND alloc.PositionSide = 'S' THEN 'S'
        WHEN trd.BuySellIndicator = 'B' AND alloc.PositionSide = 'L' THEN 'L'
        WHEN trd.BuySellIndicator = 'B' AND (alloc.PositionSide IN ('S', 'C')) THEN 'S'
    END AS [Long Short Indicator],
    '' AS [Position Type],
    'S' AS [Transaction Level],
    alloc.TradeAllocationId AS [Client Trade Ref No.],
    '' AS [Associated Trade Id],
    '' AS [Execution Account],   
    '06178VV43' AS [Account Id],
    'MSSW' AS [Broker / Counterparty],
    IIF(trd.Sedol IS NULL OR TRIM(trd.Sedol) = '', 'B', 'S') AS [Security Identifier Type],
    IIF(trd.Sedol IS NULL OR TRIM(trd.Sedol) = '', ins.Symbol,trd.Sedol) AS [SecurityIdentifier],
    ins.[Name] AS [Security Description],
    FORMAT(trd.[TradeDate], 'yyyy-MM-dd') AS [Trade Date],
    FORMAT(trd.fnAddBusinessDays(trd.TradeDate,IIF(ins.Symbol like '%Equity', 2,2)), 'yyyy-MM-dd') AS [Settlement Date],
    ISNULL(fs.SettlementCurrency, trd.TradeCurrency) AS [Settlement CCY],
    '' AS [Exchange Code],
    ABS(FilledQuantity) AS [Quantity],
    ROUND(trd.AvgPrice, 5) AS [Price],
    'G' AS [Price Indicator],
    CAST(ABS(Principal) AS DECIMAL(24,2)) AS [Principal],
    CAST(trd.BrokerCommission AS DECIMAL(24,2)) AS [Execution Broker Commission],
    'F' AS [Executing broker Commission Indicator],
    trd.MiscFees AS [MS Fees],
    '' AS [Not Required],
    'F' AS [MS fees Indicator.],
    '' AS [Dividend Entitlement Percent],
    '' AS [Spread],
    CAST(ABS(trd.NetAmount) AS DECIMAL(24,2)) AS [Net Amount],
    'N' AS [Hearsay Ind],
    'MSIL' AS [Custodian],
    '' AS [Money Manager],
    '' AS [Book Id],
    '' AS [Deal Id],
    '' AS [TaxLot Id],
    '' AS [Original taxlot transaction date],
    '' AS [Original Taxlot transaction price],
    '' AS [Taxlot Closeout Method],
    '1' AS [Price FX Rate],
    '' AS [Acquisition Date],
    trd.Notes AS [Comments],
    '' AS [Swap Reference No.],
    '' AS [Basket Id],
    TradeCurrency AS [Price Currency],
    '' AS [Reset Indicator],
    '' AS [SNS reference],
    '' AS [Research Fee],
    '' AS [Research Fee Indicator],
    '' AS [LEI],
    '' AS [Client Strategy 2 (Used for PEPS)]
FROM 
    [Trading].[trd].[Trade] trd
JOIN 
    trans.TradeAllocation alloc ON alloc.TradeId = trd.TradeId
JOIN 
    trans.Instrument ins ON ins.InstrumentId = trd.InstrumentId
LEFT JOIN 
    trans.[vwLastFileTransmission] ft ON ft.TransmissionType = 'MSSW002TEST'
LEFT JOIN trd.vwFutureSwap fs on fs.InstrumentId = trd.InstrumentId
WHERE 
    (
        ins.InstrumentType = 'EQU' AND trd.IsCfd = 1 
        OR ins.InstrumentId IN (SELECT InstrumentId FROM trd.vwFutureSwap)
    )
    AND trd.TradeDate = DATEADD(day, - 1,CAST(GETDATE() AS DATE)) 
    AND (ft.TransmittedOn IS NULL OR ft.TransmittedOn < trd.BookedOn);
GO
/****** Object:  View [book].[vwDailyBookedTradeAllocation]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


















/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [book].[vwDailyBookedTradeAllocation] as
SELECT  [TradeAllocationId]
      ,alloc.[TradeStatus]
      ,alloc.[TradeId]
	  ,[InstrumentId]
      ,[Symbol]
      ,[TradeSide]
      ,[TradeQuantity]
	  ,InstrumentType
      ,[TradeCurrency]
      ,[TradeDate]
      ,[Exchange]
      ,[ExecutionChannel]
      ,[ExecutionType]
      ,[IsSwap]
      ,[RebalancingId]
   
      ,[AvgPrice] as TradeAvgPrice
      ,[Principal] as TradePrincipal
      ,[TradeValue]
      ,[TradeInstrumentType]
      ,[ExecutionDesk]
      ,[ExecutionBroker]
      ,[ExecutionAccount]
      ,[Isin]
      ,[Sedol]
      ,[Cusip]
      ,[SecurityName]
      ,[LocalExchangeSymbol]

      ,[EmsxOrderId]
      ,[OrderReferenceId]
      ,[OrderQuantity]
      ,[OrderType]
      ,[StrategyType]
      ,[TimeInForce]
      ,[OrderExecutionInstruction]
      ,[OrderHandlingInstruction]
      ,[OrderInstruction]
      ,[LimitPrice]
      ,[StopPrice]
      ,[OriginatingTraderUUId]
      ,[TraderName]
      ,[TraderUUId]
      ,[UserCommissionAmount]
      ,[UserCommissionRate]
      ,[UserFees]
      ,[UserNetMoney]
      ,[YellowKey]
      ,[NumberOfFills]
      ,[FirstFillTimeUtc]
      ,[LastFillTimeUtc]

      ,[MaxFillPrice]
      ,[MinFillPrice]
	  ,BookedOnUtc
      ,alloc.[PortfolioId]
      ,alloc.[PositionSide]
      ,alloc.[Quantity]
	  ,alloc.OrderAllocationQuantity
	  ,alloc.OrderAllocationNominalQuantity
      ,alloc.[ContractMultiplier]
      ,alloc.[NominalQuantity]
      ,alloc.[LocalCurrency]
      ,alloc.[BaseCurrency]
      ,alloc.[SettlementCurrency]
      ,alloc.[CommissionValue]
      ,alloc.[CommissionType]
      ,alloc.[GrossAvgPriceLocal]
      ,alloc.[PriceCommissionLocal]
      ,alloc.[NetAvgPriceLocal]
      ,alloc.[GrossAvgPriceBase]
      ,alloc.[PriceCommissionBase]
      ,alloc.[NetAvgPriceBase]
      ,alloc.[GrossAvgPriceSettle]
      ,alloc.[PriceCommissionSettle]
      ,alloc.[NetAvgPriceSettle]
      ,alloc.[CommissionAmountLocal]
      ,alloc.[CommissionAmountBase]
      ,alloc.[CommissionAmountSettle]
	  ,alloc.MiscFeesLocal
	  ,alloc.MiscFeesBase
	  ,alloc.MiscFeesSettle
      ,alloc.[GrossTradeValueLocal]
      ,alloc.[NetTradeValueLocal]
      ,alloc.[GrossTradeValueBase]
      ,alloc.[NetTradeValueBase]
      ,alloc.[GrossTradeValueSettle]
      ,alloc.[NetTradeValueSettle]
      ,alloc.[GrossPrincipalLocal]
      ,alloc.[NetPrincipalLocal]
      ,alloc.[GrossPrincipalBase]
      ,alloc.[NetPrincipalBase]
      ,alloc.[GrossPrincipalSettle]
      ,alloc.[NetPrincipalSettle]
      ,alloc.[SettlementDate]
      ,alloc.[LocalToBaseFxRate]
      ,alloc.[LocalToSettleFxRate]
      ,alloc.[PrimeBroker]
      ,alloc.[CLearingBroker]
      ,alloc.[ClearingAccount]
      ,alloc.[Custodian]

      ,alloc.[LastCorrectedOnUtc]
      ,alloc.[CanceledOnUtc]
    
  FROM [book].[TradeAllocation] alloc
  LEFT JOIN [book].Trade trd on trd.TradeId = alloc.TradeId
    where cast(BookedOnUtc as date) = cast(GETUTCDATE()as date)
GO
/****** Object:  Table [efrp].[FutureContract]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [efrp].[FutureContract](
	[FutureContractId] [int] NOT NULL,
	[Symbol] [nvarchar](30) NOT NULL,
	[GenericFutureId] [int] NOT NULL,
	[LastTradeDate] [date] NOT NULL,
 CONSTRAINT [PK_FutureContractId] PRIMARY KEY CLUSTERED 
(
	[FutureContractId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [efrp].[vwEfrpFutureContract]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [efrp].[vwEfrpFutureContract] as
SELECT  [EfrpConversionRuleId]
      ,rl.[GenericFutureId]
	  ,fut.FutureContractId
	  ,gen.RootSymbol
	  ,fut.Symbol
	  ,fut.LastTradeDate
	  ,gen.ContractSize
      ,[BrokerId]
      ,[BaseCurrency]
      ,[QuoteCurrency]
      ,[CmeClearportTicker]
      ,[IsActive]
      ,[ValidFrom]
      ,[ValidTo]
  FROM [efrp].[EfrpConversionRule] rl
 JOIN efrp.FutureContract fut on fut.GenericFutureId = rl.GenericFutureId
 JOIN efrp.GenericFuture gen on gen.GenericFutureId = rl.GenericFutureId



GO
/****** Object:  Table [exec].[Instrument]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [exec].[Instrument](
	[InstrumentId] [int] NOT NULL,
	[Symbol] [nvarchar](30) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[ISIN] [nvarchar](12) NULL,
	[BbgUniqueId] [nvarchar](30) NOT NULL,
	[InstrumentType] [nvarchar](10) NOT NULL,
	[MarketSector] [nvarchar](6) NOT NULL,
	[Exchange] [nvarchar](5) NULL,
	[PrimaryMic] [nvarchar](10) NULL,
	[Currency] [char](3) NOT NULL,
	[QuoteCurrency] [char](3) NOT NULL,
	[MaturityDate] [date] NULL,
	[PriceScalingFactor] [decimal](12, 6) NOT NULL,
	[FuturePointValue] [decimal](14, 6) NULL,
	[GenericFutureId] [int] NULL,
 CONSTRAINT [PK_InstrumentId] PRIMARY KEY CLUSTERED 
(
	[InstrumentId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [exec].[vwEmsxOrderExecution]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


























/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [exec].[vwEmsxOrderExecution] as
with fills as (
SELECT 
IIF(YellowKey = 'Equity',[Ticker]+' '+Exchange+' '+[YellowKey]	,[Ticker]+' '+[YellowKey]) AS Symbol,
  [Account],
  IIF(Side LIKE 'S%', -1, 1) as SignMultiplier,
  [Amount]  AS OrderQuantity,

  [AssetClass],
  [BasketId],
  [Bbgid],
  [BlockId],
  IIF(TRIM([Broker]) ='',null, TRIM([Broker])) as [Broker],
  IIF(TRIM([ClearingAccount]) ='',null, TRIM([ClearingAccount])) as [ClearingAccount],
  IIF(TRIM([ClearingFirm]) ='',null, TRIM([ClearingFirm])) as [ClearingFirm],
  [ContractExpDate],
  [Currency],
  IIF(TRIM([Cusip]) ='',null, TRIM([Cusip])) as [Cusip],
    MIN([DateTimeOfFill]) AS FirstFillTime,
  MAX([DateTimeOfFill]) AS LastFillTime,
  [Exchange],
  IIF(TRIM([ExecutingBroker]) ='',null, TRIM([ExecutingBroker])) as [ExecutingBroker],
  SUM([FillPrice] * [FillShares]) / SUM([FillShares]) AS AvgPrice,
  MAX([FillPrice]) as MaxFillPrice,
  MIN([FillPrice]) as MinFillPrice,

  SUM(FillShares) AS FilledQuantity,
  [IsCFD],
  IIF(TRIM([Isin]) ='',null, TRIM([Isin])) as [Isin],
  [LimitPrice],
  [LocalExchangeSymbol],
  [OrderExecutionInstruction],
  [OrderHandlingInstruction],
  [OrderId],
  [OrderInstruction],
  [OrderOrigin],
  [OrderReferenceId],
  [OriginatingTraderUUId],
  [SecurityName],
  IIF(TRIM([Sedol]) ='',null, TRIM([Sedol])) as [Sedol],
  [SettlementDate],
  [Side],
  [StopPrice],
  [StrategyType],
  [Ticker],
  [Tif],
  [TraderName],
  [TraderUUId],
  [Type],
  SUM([UserCommissionAmount]) AS UserCommissionAmount,
  AVG([UserCommissionRate]) AS UserCommissionRate,
  SUM([UserFees]) AS UserFees,
  SUM([UserNetMoney]) AS UserNetMoney,
  [YellowKey]
FROM
  [exec].[EmsxFill]
WHERE
  ExecType <> 'DFD'
GROUP BY
  [Account],
  [Amount],
  [AssetClass],
  [BasketId],
  [Bbgid],
  [BlockId],
  [Broker],
  [ClearingAccount],
  [ClearingFirm],
  [ContractExpDate],
  [Currency],
  [Cusip],
  [Exchange],
  [ExecutingBroker],
  [IsCFD],
  [Isin],
  [LimitPrice],
  [LocalExchangeSymbol],
  [OrderExecutionInstruction],
  [OrderHandlingInstruction],
  [OrderId],
  [OrderInstruction],
  [OrderOrigin],
  [OrderReferenceId],
  [OriginatingTraderUUId],
  [SecurityName],
  [Sedol],
  [SettlementDate],
  [Side],
  [StopPrice],
  [StrategyType],
  [Ticker],
  [Tif],
  [TraderName],
  [TraderUUId],
  [Type],
  [YellowKey]
  )
  select 
      trd.Symbol
      , [Account]
      ,OrderQuantity*SignMultiplier as OrderQuantity
	  ,ISNULL(i.FuturePointValue, 1) as ContractMultiplier
	  ,AvgPrice*FilledQuantity*SignMultiplier*ISNULL(i.FuturePointValue, 1) as GrossMarketValue
	  ,AvgPrice*FilledQuantity*SignMultiplier as GrossNotionalAmount
	  
      ,[AssetClass]
      ,[BasketId]
      ,[Bbgid]
      ,[BlockId]
      ,[Broker]
      ,[ClearingAccount]
      ,[ClearingFirm]
      ,[ContractExpDate]
      ,trd.[Currency]
	  ,i.InstrumentId
	  ,i.InstrumentType
      ,[Cusip]
	  , CAST(LastFillTime as date) as TradeDate
	  ,FirstFillTime
      ,[LastFillTime]
      ,trd.[Exchange]
      ,[ExecutingBroker]
      ,[AvgPrice]
	  ,[MaxFillPrice]
	  ,[MinFillPrice]
      ,FilledQuantity*SignMultiplier as FilledQuantity
      ,[IsCFD]
      ,trd.[Isin]
      ,[LimitPrice]
      ,[LocalExchangeSymbol]
      ,[OrderExecutionInstruction]
      ,[OrderHandlingInstruction]
      ,[OrderId]
      ,[OrderInstruction]
      ,[OrderOrigin]
      ,[OrderReferenceId]
      ,[OriginatingTraderUUId]
      ,i.[Name] as[SecurityName]
      ,[Sedol]
      ,[SettlementDate]
      ,[Side]
      ,[StopPrice]
      ,[StrategyType]
      ,[Ticker]
      ,[Tif]
      ,[TraderName]
      ,[TraderUUId]
      ,[Type]
      ,[UserCommissionAmount]
      ,[UserCommissionRate]
      ,[UserFees]
      ,[UserNetMoney]
      ,[YellowKey] 
	  from fills trd
	      LEFT JOIN [exec].Instrument i ON i.Symbol = trd.Symbol

GO
/****** Object:  Table [book].[H_ExecutionDesk]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [book].[H_ExecutionDesk](
	[ExecutionDeskId] [int] NOT NULL,
	[Code] [nvarchar](6) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[ExecutionBrokerId] [int] NOT NULL,
	[ValidFrom] [datetime2](7) NOT NULL,
	[ValidTo] [datetime2](7) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_H_ExecutionDesk]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_H_ExecutionDesk] ON [book].[H_ExecutionDesk]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [book].[ExecutionDesk]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [book].[ExecutionDesk](
	[ExecutionDeskId] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](6) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[ExecutionBrokerId] [int] NOT NULL,
	[ValidFrom] [datetime2](7) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](7) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_ExecutionDesk] PRIMARY KEY CLUSTERED 
(
	[ExecutionDeskId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_ExecutionDeskCode] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [book].[H_ExecutionDesk])
)
GO
/****** Object:  View [exec].[vwTestCompareBookedTrades]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


























/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [exec].[vwTestCompareBookedTrades] as
SELECT
    t.Symbol,
    t.OrderReferenceId,
    t.FilledQuantity AS FilledQuantity,
    d.FilledQuantity AS BookedQuantity,
	t.FilledQuantity -d.FilledQuantity as QuantityDiff,
    t.AvgPrice AS TradeAvgPrice,
    d.AvgPrice AS BookedAvgPrice,
	t.AvgPrice- d.AvgPrice as AvgPriceDiff,
    t.[GrossMarketValue]AS Principal,
	d.Principal AS BookedPrincipal,
	t.[GrossMarketValue]-d.Principal as PrincipalDiff,
    t.InstrumentType AS TradeInstrumentType,
    d.InstrumentType AS BookedInstrumentType,
    t.Sedol AS TradeSedol,
    d.Sedol AS BookedSedol,
	t.TradeDate AS TradeDate,
    d.TradeDate AS BookedTradeDate,
    t.Currency AS TradeCurrency,
    d.TradeCurrency AS BookedTradeCurrency,
    t.IsCFD AS TradeIsCFD,
    d.IsCfd AS BookedIsCfd
FROM
    [exec].[vwEmsxOrderExecution] t
RIGHT JOIN
    [trd].[vwTrade] d ON t.OrderId = d.EmsxSequence
WHERE
    t.OrderQuantity <> d.OrderQuantity
    OR t.FilledQuantity <> d.FilledQuantity
    OR t.AvgPrice <> d.AvgPrice
    OR t.InstrumentType <> d.InstrumentType
    OR t.Sedol <> d.Sedol
    OR t.Currency <> d.TradeCurrency
	OR t.[GrossMarketValue] <>d.Principal
    OR t.IsCFD <> d.IsCfd
    OR t.TradeDate <> d.TradeDate
	or t.OrderId is null;

GO
/****** Object:  View [exec].[vwEmsxFillAggregate]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



























/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [exec].[vwEmsxFillAggregate] as
with fills as (
SELECT 
IIF(YellowKey = 'Equity',[Ticker]+' '+Exchange+' '+[YellowKey]	,[Ticker]+' '+[YellowKey]) AS Symbol,
  [Account],
  IIF(Side LIKE 'S%', -1, 1) as SignMultiplier,
  [Amount]  AS OrderQuantity,

  [AssetClass],
  [BasketId],
  [Bbgid],
  [BlockId],
  IIF(TRIM([Broker]) ='',null, TRIM([Broker])) as [Broker],
  IIF(TRIM([ClearingAccount]) ='',null, TRIM([ClearingAccount])) as [ClearingAccount],
  IIF(TRIM([ClearingFirm]) ='',null, TRIM([ClearingFirm])) as [ClearingFirm],
  [ContractExpDate],
  [Currency],
  IIF(TRIM([Cusip]) ='',null, TRIM([Cusip])) as [Cusip],
    MIN([DateTimeOfFill]) AS FirstFillTime,
  MAX([DateTimeOfFill]) AS LastFillTime,
  [Exchange],
  IIF(TRIM([ExecutingBroker]) ='',null, TRIM([ExecutingBroker])) as [ExecutingBroker],
  SUM([FillPrice] * [FillShares]) / SUM([FillShares]) AS AvgPrice,
  MAX([FillPrice]) as MaxFillPrice,
  MIN([FillPrice]) as MinFillPrice,

  SUM(FillShares) AS FilledQuantity,
  [IsCFD],
  IIF(TRIM([Isin]) ='',null, TRIM([Isin])) as [Isin],
  [LimitPrice],
  [LocalExchangeSymbol],
  [OrderExecutionInstruction],
  [OrderHandlingInstruction],
  [OrderId],
  [OrderInstruction],
  [OrderOrigin],
  [OrderReferenceId],
  [OriginatingTraderUUId],
  [SecurityName],
  IIF(TRIM([Sedol]) ='',null, TRIM([Sedol])) as [Sedol],
  [SettlementDate],
  [Side],
  [StopPrice],
  [StrategyType],
  [Ticker],
  [Tif],
  [TraderName],
  [TraderUUId],
  [Type],
  SUM([UserCommissionAmount]) AS UserCommissionAmount,
  AVG([UserCommissionRate]) AS UserCommissionRate,
  SUM([UserFees]) AS UserFees,
  SUM([UserNetMoney]) AS UserNetMoney,
  [YellowKey]
FROM
  [exec].[EmsxFill]
WHERE
  ExecType <> 'DFD'
GROUP BY
  [Account],
  [Amount],
  [AssetClass],
  [BasketId],
  [Bbgid],
  [BlockId],
  [Broker],
  [ClearingAccount],
  [ClearingFirm],
  [ContractExpDate],
  [Currency],
  [Cusip],
  [Exchange],
  [ExecutingBroker],
  [IsCFD],
  [Isin],
  [LimitPrice],
  [LocalExchangeSymbol],
  [OrderExecutionInstruction],
  [OrderHandlingInstruction],
  [OrderId],
  [OrderInstruction],
  [OrderOrigin],
  [OrderReferenceId],
  [OriginatingTraderUUId],
  [SecurityName],
  [Sedol],
  [SettlementDate],
  [Side],
  [StopPrice],
  [StrategyType],
  [Ticker],
  [Tif],
  [TraderName],
  [TraderUUId],
  [Type],
  [YellowKey]
  )
  select 
      trd.Symbol
      , [Account]
      ,OrderQuantity*SignMultiplier as OrderQuantity
	  ,ISNULL(i.FuturePointValue, 1) as ContractMultiplier
	  ,AvgPrice*FilledQuantity*SignMultiplier*ISNULL(i.FuturePointValue, 1) as GrossMarketValue
	  ,AvgPrice*FilledQuantity*SignMultiplier as GrossNotionalAmount
	  
      ,[AssetClass]
      ,[BasketId]
      ,[Bbgid]
      ,[BlockId]
      ,[Broker]
      ,[ClearingAccount]
      ,[ClearingFirm]
      ,[ContractExpDate]
      ,trd.[Currency]
	  ,i.InstrumentId
	  ,i.InstrumentType
      ,[Cusip]
	  , CAST(LastFillTime as date) as TradeDate
	  ,FirstFillTime
      ,[LastFillTime]
      ,trd.[Exchange]
      ,[ExecutingBroker]
      ,[AvgPrice]
	  ,[MaxFillPrice]
	  ,[MinFillPrice]
      ,FilledQuantity*SignMultiplier as FilledQuantity
      ,[IsCFD]
      ,trd.[Isin]
      ,[LimitPrice]
      ,[LocalExchangeSymbol]
      ,[OrderExecutionInstruction]
      ,[OrderHandlingInstruction]
      ,[OrderId]
      ,[OrderInstruction]
      ,[OrderOrigin]
      ,[OrderReferenceId]
      ,[OriginatingTraderUUId]
      ,i.[Name] as[SecurityName]
      ,[Sedol]
      ,[SettlementDate]
      ,[Side]
      ,[StopPrice]
      ,[StrategyType]
      ,[Ticker]
      ,[Tif]
      ,[TraderName]
      ,[TraderUUId]
      ,[Type]
      ,[UserCommissionAmount]
      ,[UserCommissionRate]
      ,[UserFees]
      ,[UserNetMoney]
      ,[YellowKey] 
	  from fills trd
	      LEFT JOIN [exec].Instrument i ON i.Symbol = trd.Symbol

GO
/****** Object:  Table [roll].[FxForward]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [roll].[FxForward](
	[FxForwardId] [int] NOT NULL,
	[Symbol] [nvarchar](30) NOT NULL,
	[CurrencyPairId] [int] NOT NULL,
	[MaturityDate] [date] NOT NULL,
 CONSTRAINT [PK_FxForward] PRIMARY KEY CLUSTERED 
(
	[FxForwardId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [roll].[vwFxForwardRollInfo]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO














/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [roll].[vwFxForwardRollInfo] as
WITH BusinessDays AS (

    SELECT
        FxForwardId,
		Symbol,
        CurrencyPairId,
        MaturityDate,
              CASE 
        WHEN DATEPART(WEEKDAY, MaturityDate) = 1 THEN DATEADD(DAY, -9, MaturityDate)
        WHEN DATEPART(WEEKDAY, MaturityDate) = 2 THEN DATEADD(DAY, -10, MaturityDate)
        ELSE DATEADD(DAY, -8, MaturityDate)
    END AS RollingPeriodStartDate
    FROM [roll].[FxForward]
	
)

, RankedBusinessDays AS (
    SELECT
        FxForwardId,
        CurrencyPairId,
		Symbol,
        MaturityDate,
        RollingPeriodStartDate,
		DATEDIFF(DAY, GETDATE(), MaturityDate) as DayToLastRollingDate,
		DATEDIFF(DAY, GETDATE(), RollingPeriodStartDate) as DayToFirstRollingDate,
        DENSE_RANK() OVER(PARTITION BY CurrencyPairId ORDER BY MaturityDate) AS RankNum,
        CASE 
            WHEN GETDATE() BETWEEN RollingPeriodStartDate AND MaturityDate THEN 1
            ELSE 0
        END AS IsRollingPeriod
    FROM BusinessDays
    WHERE MaturityDate >= GETDATE()
)

SELECT TOP (100000)
    curr.CurrencyPairId, 
    curr.FxForwardId AS CurrentContractId, 
	curr.Symbol AS CurrentSymbol,
    curr.MaturityDate AS ExpiryDate, 
    curr.RollingPeriodStartDate AS RollingPeriodStartDate,
	curr.DayToFirstRollingDate as DayToRollingPeriodStart,
	curr.DayToLastRollingDate as DayToExpiry,
    curr.IsRollingPeriod AS IsRollingPeriod,
    nextC.FxForwardId AS NextContractId,
    nextC.MaturityDate AS NextMaturityDate,
	nextC.Symbol AS NextSymbol
FROM RankedBusinessDays AS curr
LEFT JOIN RankedBusinessDays AS nextC ON curr.CurrencyPairId = nextC.CurrencyPairId AND curr.RankNum = nextC.RankNum - 1
WHERE curr.RankNum = 1
ORDER BY curr.CurrencyPairId, curr.MaturityDate;





GO
/****** Object:  Table [trans].[H_ClearingAccountCodeMapping]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[H_ClearingAccountCodeMapping](
	[CounterpartyId] [int] NOT NULL,
	[InternalCode] [nvarchar](20) NOT NULL,
	[CounterpartyCode] [nvarchar](20) NOT NULL,
	[ValidFrom] [datetime2](7) NOT NULL,
	[ValidTo] [datetime2](7) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_H_ClearingAccountCodeMapping]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_H_ClearingAccountCodeMapping] ON [trans].[H_ClearingAccountCodeMapping]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [trans].[ClearingAccountCodeMapping]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[ClearingAccountCodeMapping](
	[CounterpartyId] [int] NOT NULL,
	[InternalCode] [nvarchar](20) NOT NULL,
	[CounterpartyCode] [nvarchar](20) NOT NULL,
	[ValidFrom] [datetime2](7) GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
	[ValidTo] [datetime2](7) GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
 CONSTRAINT [PK_ClearingAccountCodeMapping] PRIMARY KEY CLUSTERED 
(
	[CounterpartyId] ASC,
	[InternalCode] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [trans].[H_ClearingAccountCodeMapping])
)
GO
/****** Object:  Table [trans].[H_PostTradeServiceMapping]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[H_PostTradeServiceMapping](
	[ExecutionBroker] [nvarchar](20) NOT NULL,
	[PortfolioId] [tinyint] NOT NULL,
	[InstrumentType] [nvarchar](10) NOT NULL,
	[IsSwap] [bit] NOT NULL,
	[PrimeBrokerage] [nvarchar](10) NOT NULL,
	[Clearing] [nvarchar](10) NOT NULL,
	[Custody] [nvarchar](10) NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_H_PostTradeServiceMapping]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_H_PostTradeServiceMapping] ON [trans].[H_PostTradeServiceMapping]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [trans].[PostTradeServiceMapping]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[PostTradeServiceMapping](
	[ExecutionBroker] [nvarchar](20) NOT NULL,
	[PortfolioId] [tinyint] NOT NULL,
	[InstrumentType] [nvarchar](10) NOT NULL,
	[IsSwap] [bit] NOT NULL,
	[PrimeBrokerage] [nvarchar](10) NOT NULL,
	[Clearing] [nvarchar](10) NOT NULL,
	[Custody] [nvarchar](10) NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_PostTradeServiceMapping] PRIMARY KEY CLUSTERED 
(
	[ExecutionBroker] ASC,
	[PortfolioId] ASC,
	[InstrumentType] ASC,
	[IsSwap] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [trans].[H_PostTradeServiceMapping])
)
GO
/****** Object:  Table [trans].[H_PrimeBrokerMapping]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[H_PrimeBrokerMapping](
	[ExecutionBroker] [nvarchar](20) NOT NULL,
	[PortfolioId] [tinyint] NOT NULL,
	[InstrumentType] [nvarchar](10) NOT NULL,
	[IsSwap] [bit] NOT NULL,
	[PrimeBroker] [nvarchar](10) NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_H_PrimeBrokerMapping]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_H_PrimeBrokerMapping] ON [trans].[H_PrimeBrokerMapping]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [trans].[PrimeBrokerMapping]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[PrimeBrokerMapping](
	[ExecutionBroker] [nvarchar](20) NOT NULL,
	[PortfolioId] [tinyint] NOT NULL,
	[InstrumentType] [nvarchar](10) NOT NULL,
	[IsSwap] [bit] NOT NULL,
	[PrimeBroker] [nvarchar](10) NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_PrimeBrokerMapping] PRIMARY KEY CLUSTERED 
(
	[ExecutionBroker] ASC,
	[PortfolioId] ASC,
	[InstrumentType] ASC,
	[IsSwap] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [trans].[H_PrimeBrokerMapping])
)
GO
/****** Object:  Table [trans].[H_EncryptionProfile]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[H_EncryptionProfile](
	[EncryptionProfileId] [int] NOT NULL,
	[PublicKeyRecipient] [nvarchar](50) NOT NULL,
	[PrivateKeyRecipient] [nvarchar](50) NOT NULL,
	[Passphrase] [nvarchar](30) NULL,
	[Sign] [bit] NOT NULL,
	[ExcryptedFileExtension] [nvarchar](3) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[ValidFrom] [datetime2](7) NOT NULL,
	[ValidTo] [datetime2](7) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_H_EncryptionProfile]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_H_EncryptionProfile] ON [trans].[H_EncryptionProfile]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [trans].[EncryptionProfile]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[EncryptionProfile](
	[EncryptionProfileId] [int] NOT NULL,
	[PublicKeyRecipient] [nvarchar](50) NOT NULL,
	[PrivateKeyRecipient] [nvarchar](50) NOT NULL,
	[Passphrase] [nvarchar](30) NULL,
	[Sign] [bit] NOT NULL,
	[ExcryptedFileExtension] [nvarchar](3) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[ValidFrom] [datetime2](7) GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
	[ValidTo] [datetime2](7) GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
 CONSTRAINT [PK_EncryptionProfile] PRIMARY KEY CLUSTERED 
(
	[EncryptionProfileId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [trans].[H_EncryptionProfile])
)
GO
/****** Object:  Table [trans].[H_TransmissionProfile]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[H_TransmissionProfile](
	[TransmissionProfileId] [int] NOT NULL,
	[Mnemonic] [nvarchar](10) NOT NULL,
	[CounterPartyId] [int] NOT NULL,
	[FtpConfigurationId] [int] NULL,
	[EmailConfigurationId] [int] NULL,
	[EncryptionProfileId] [int] NULL,
	[Description] [nvarchar](255) NOT NULL,
	[TransmissionScheduleTypeId] [int] NOT NULL,
	[IsEnabled] [bit] NOT NULL,
	[ValidFrom] [datetime2](7) NOT NULL,
	[ValidTo] [datetime2](7) NOT NULL,
	[FileContentTypeId] [tinyint] NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_H_TransmissionProfile]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_H_TransmissionProfile] ON [trans].[H_TransmissionProfile]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [trans].[TransmissionProfile]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[TransmissionProfile](
	[TransmissionProfileId] [int] NOT NULL,
	[Mnemonic] [nvarchar](10) NOT NULL,
	[CounterPartyId] [int] NOT NULL,
	[FtpConfigurationId] [int] NULL,
	[EmailConfigurationId] [int] NULL,
	[EncryptionProfileId] [int] NULL,
	[Description] [nvarchar](255) NOT NULL,
	[TransmissionScheduleTypeId] [int] NOT NULL,
	[IsEnabled] [bit] NOT NULL,
	[ValidFrom] [datetime2](7) GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
	[ValidTo] [datetime2](7) GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
	[FileContentTypeId] [tinyint] NOT NULL,
 CONSTRAINT [PK_TransmissionProfile] PRIMARY KEY CLUSTERED 
(
	[TransmissionProfileId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_TransmissionProfile_Mnemonic] UNIQUE NONCLUSTERED 
(
	[Mnemonic] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_CounterPartyId_FileContentTypeId] UNIQUE NONCLUSTERED 
(
	[CounterPartyId] ASC,
	[FileContentTypeId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [trans].[H_TransmissionProfile])
)
GO
/****** Object:  Table [trans].[H_FileGenerationType]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[H_FileGenerationType](
	[FileGenerationTypeId] [int] NOT NULL,
	[Mnemonic] [nvarchar](20) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[ValidFrom] [datetime2](7) NOT NULL,
	[ValidTo] [datetime2](7) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_H_FileGenerationType]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_H_FileGenerationType] ON [trans].[H_FileGenerationType]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [trans].[FileGenerationType]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[FileGenerationType](
	[FileGenerationTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Mnemonic] [nvarchar](20) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[ValidFrom] [datetime2](7) GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
	[ValidTo] [datetime2](7) GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
 CONSTRAINT [PK_FileGenerationType] PRIMARY KEY CLUSTERED 
(
	[FileGenerationTypeId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [trans].[H_FileGenerationType])
)
GO
/****** Object:  Table [trans].[H_FileGenerationProfile]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[H_FileGenerationProfile](
	[FileGenerationProfileId] [int] NOT NULL,
	[FileName] [nvarchar](200) NOT NULL,
	[IncludeHeader] [bit] NOT NULL,
	[DateParamFormat] [nvarchar](20) NULL,
	[Separator] [char](1) NOT NULL,
	[OutputFolder] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[ValidFrom] [datetime2](7) NOT NULL,
	[ValidTo] [datetime2](7) NOT NULL,
	[PortfolioId] [tinyint] NOT NULL,
	[FunctionName] [nvarchar](150) NOT NULL,
	[TransmissionProfileId] [int] NOT NULL,
	[FileGenerationTypeId] [int] NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_H_FileGenerationProfile]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_H_FileGenerationProfile] ON [trans].[H_FileGenerationProfile]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [trans].[FileGenerationProfile]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[FileGenerationProfile](
	[FileGenerationProfileId] [int] NOT NULL,
	[FileName] [nvarchar](200) NOT NULL,
	[IncludeHeader] [bit] NOT NULL,
	[DateParamFormat] [nvarchar](20) NULL,
	[Separator] [char](1) NOT NULL,
	[OutputFolder] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[ValidFrom] [datetime2](7) GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
	[ValidTo] [datetime2](7) GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
	[PortfolioId] [tinyint] NOT NULL,
	[FunctionName] [nvarchar](150) NOT NULL,
	[TransmissionProfileId] [int] NOT NULL,
	[FileGenerationTypeId] [int] NOT NULL,
 CONSTRAINT [PK_FileGenerationProfile] PRIMARY KEY CLUSTERED 
(
	[FileGenerationProfileId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_FileGenerationProfile] UNIQUE NONCLUSTERED 
(
	[FileGenerationTypeId] ASC,
	[PortfolioId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [trans].[H_FileGenerationProfile])
)
GO
/****** Object:  Table [trans].[H_CustodianCodeMapping]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[H_CustodianCodeMapping](
	[FileGenerationTypeId] [int] NOT NULL,
	[PortfolioId] [tinyint] NOT NULL,
	[InternalCode] [nvarchar](20) NOT NULL,
	[CounterpartyCode] [nvarchar](20) NOT NULL,
	[ValidFrom] [datetime2](7) NOT NULL,
	[ValidTo] [datetime2](7) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_H_CustodianCodeMapping]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_H_CustodianCodeMapping] ON [trans].[H_CustodianCodeMapping]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [trans].[CustodianCodeMapping]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[CustodianCodeMapping](
	[FileGenerationTypeId] [int] NOT NULL,
	[PortfolioId] [tinyint] NOT NULL,
	[InternalCode] [nvarchar](20) NOT NULL,
	[CounterpartyCode] [nvarchar](20) NOT NULL,
	[ValidFrom] [datetime2](7) GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
	[ValidTo] [datetime2](7) GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
 CONSTRAINT [PK_CustodianCodeMapping] PRIMARY KEY CLUSTERED 
(
	[FileGenerationTypeId] ASC,
	[PortfolioId] ASC,
	[InternalCode] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [trans].[H_CustodianCodeMapping])
)
GO
/****** Object:  Table [trans].[H_ClearingBrokerCodeMapping]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[H_ClearingBrokerCodeMapping](
	[FileGenerationTypeId] [int] NOT NULL,
	[InternalCode] [nvarchar](20) NOT NULL,
	[CounterpartyCode] [nvarchar](20) NOT NULL,
	[ValidFrom] [datetime2](7) NOT NULL,
	[ValidTo] [datetime2](7) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_H_ClearingBrokerCodeMapping]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_H_ClearingBrokerCodeMapping] ON [trans].[H_ClearingBrokerCodeMapping]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [trans].[ClearingBrokerCodeMapping]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[ClearingBrokerCodeMapping](
	[FileGenerationTypeId] [int] NOT NULL,
	[InternalCode] [nvarchar](20) NOT NULL,
	[CounterpartyCode] [nvarchar](20) NOT NULL,
	[ValidFrom] [datetime2](7) GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
	[ValidTo] [datetime2](7) GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
 CONSTRAINT [PK_ClearingBrokerCodeMapping] PRIMARY KEY CLUSTERED 
(
	[FileGenerationTypeId] ASC,
	[InternalCode] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [trans].[H_ClearingBrokerCodeMapping])
)
GO
/****** Object:  Table [trans].[H_ExecutionBrokerCodeMapping]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[H_ExecutionBrokerCodeMapping](
	[FileGenerationTypeId] [int] NOT NULL,
	[InternalCode] [nvarchar](20) NOT NULL,
	[CounterpartyCode] [nvarchar](20) NOT NULL,
	[ValidFrom] [datetime2](7) NOT NULL,
	[ValidTo] [datetime2](7) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_H_ExecutionBrokerCodeMapping]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_H_ExecutionBrokerCodeMapping] ON [trans].[H_ExecutionBrokerCodeMapping]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [trans].[ExecutionBrokerCodeMapping]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[ExecutionBrokerCodeMapping](
	[FileGenerationTypeId] [int] NOT NULL,
	[InternalCode] [nvarchar](20) NOT NULL,
	[CounterpartyCode] [nvarchar](20) NOT NULL,
	[ValidFrom] [datetime2](7) GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
	[ValidTo] [datetime2](7) GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
 CONSTRAINT [PK_ExecutionBrokerCodeMapping] PRIMARY KEY CLUSTERED 
(
	[FileGenerationTypeId] ASC,
	[InternalCode] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [trans].[H_ExecutionBrokerCodeMapping])
)
GO
/****** Object:  UserDefinedFunction [trans].[tvTradesFileMSFSTR001]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE FUNCTION [trans].[tvTradesFileMSFSTR001] (@PortfolioId tinyint)
RETURNS TABLE
AS
RETURN
with trades as (
SELECT  [TradeAllocationId]
      ,[TradeId]
      ,[TradeStatus]
      ,[InstrumentId]
      ,[Symbol]
      ,[TradeSide]
      ,[TradeDate]
      ,[Exchange]
      ,[IsSwap]
      ,[InstrumentType]
      ,[TradeInstrumentType]
      ,[YellowKey]
      ,[ExecutionDesk]
      ,execbroker.CounterpartyCode as [ExecutionBroker]
      ,execaccount.CounterpartyCode as[ExecutionAccount]
      ,[Isin]
      ,[Sedol]
      ,[Cusip]
      ,[SecurityName]
      ,[LocalExchangeSymbol]
      ,trd.[PortfolioId]
      ,[PositionSide]
      ,[Quantity]
      ,[ContractMultiplier]
      ,[NominalQuantity]
      ,[LocalCurrency]
      ,[BaseCurrency]
      ,[SettlementCurrency]
      ,[CommissionValue]
      ,[CommissionType]
      ,[GrossAvgPriceLocal]
      ,[PriceCommissionLocal]
      ,[NetAvgPriceLocal]
      ,[GrossAvgPriceBase]
      ,[PriceCommissionBase]
      ,[NetAvgPriceBase]
      ,[GrossAvgPriceSettle]
      ,[PriceCommissionSettle]
      ,[NetAvgPriceSettle]
      ,[CommissionAmountLocal]
      ,[CommissionAmountBase]
      ,[CommissionAmountSettle]
      ,[MiscFeesLocal]
      ,[MiscFeesBase]
      ,[MiscFeesSettle]
      ,[GrossTradeValueLocal]
      ,[NetTradeValueLocal]
      ,[GrossTradeValueBase]
      ,[NetTradeValueBase]
      ,[GrossTradeValueSettle]
      ,[NetTradeValueSettle]
      ,[GrossPrincipalLocal]
      ,[NetPrincipalLocal]
      ,[GrossPrincipalBase]
      ,[NetPrincipalBase]
      ,[GrossPrincipalSettle]
      ,[NetPrincipalSettle]
      ,[SettlementDate]
      ,[LocalToBaseFxRate]
      ,[LocalToSettleFxRate]
      ,[PrimeBroker]
      ,clearingbroker.CounterpartyCode as [ClearingBroker]
      ,clearingaccount.CounterpartyCode as [ClearingAccount]
      ,custodian.CounterpartyCode as [Custodian]
      ,[EmsxOrderId]
      ,[OrderReferenceId]
      ,[BlockOrderQuantity]
      ,[OrderAllocationQuantity]
      ,[OrderAllocationNominalQuantity]
      ,[ExecutionType]
      ,[Notes]
      ,[TraderName]
      ,[TraderUuid]
      ,[LastCorrectedOnUtc]
      ,[CanceledOnUtc]
      ,[BookedOnUtc]

  FROM [trans].[BookedTradeAllocation] trd
  JOIN
    trans.FileGenerationType fgt ON fgt.mnemonic = 'MSFSTR001'
JOIN
    trans.FileGenerationProfile fgp ON fgp.FileGenerationTypeId = fgt.FileGenerationTypeId
    AND fgp.PortfolioId = trd.PortfolioId
JOIN
    trans.TransmissionProfile tp ON tp.TransmissionProfileId = fgp.TransmissionProfileId
LEFT JOIN
    trans.[ClearingBrokerCodeMapping] clearingbroker ON clearingbroker.FileGenerationTypeId = fgt.FileGenerationTypeId
    AND clearingbroker.InternalCode = trd.ClearingBroker
LEFT JOIN
    trans.[ClearingAccountCodeMapping] clearingaccount ON clearingaccount.CounterpartyId = tp.CounterpartyId
    AND clearingaccount.InternalCode = trd.ClearingAccount
LEFT JOIN
    trans.[ExecutionBrokerCodeMapping] execbroker ON execbroker.FileGenerationTypeId = fgt.FileGenerationTypeId
    AND execbroker.InternalCode = trd.ExecutionBroker
LEFT JOIN
    trans.[ExecutionAccountCodeMapping] execaccount ON execaccount.CounterpartyId = tp.CounterpartyId
    AND execaccount.InternalCode = trd.ExecutionAccount
LEFT JOIN
    trans.[CustodianCodeMapping] custodian ON custodian.FileGenerationTypeId = fgt.FileGenerationTypeId
    AND custodian.PortfolioId = trd.PortfolioId
    AND custodian.InternalCode = trd.Custodian

LEFT JOIN trans.[vwLastFileTransmission] ft ON ft.[TransmissionType] = tp.Mnemonic

WHERE 
    trd.TradeInstrumentType = 'FUT'
    --AND trd.TradeDate = CAST(GETDATE() AS DATE) 
	 	AND trd.PrimeBroker ='MS'
    AND (ft.TransmittedOn IS NULL OR ft.TransmittedOn < trd.BookedOnUtc OR ft.TransmittedOn < trd.CanceledOnUtc OR  ft.TransmittedOn < trd.LastCorrectedOnUtc)

	AND trd.PortfolioId = @PortfolioId
)
SELECT 
    'TR001' AS TrasationType,
    trd.TradeStatus AS TransactionStatus,
    trd.TradeSide AS [Buy/Sell],
    CASE 
        WHEN trd.TradeSide='S' AND (trd.PositionSide ='L' OR  trd.PositionSide ='C') THEN 'L'
        WHEN trd.TradeSide='S' AND trd.PositionSide ='S' THEN 'S'
        WHEN trd.TradeSide='B' AND trd.PositionSide ='L' THEN 'L'
        WHEN trd.TradeSide='B' AND (trd.PositionSide ='S' OR  trd.PositionSide ='C') THEN 'C' 
    END AS [Long/Short],
    '' AS [PositionType],
    'A' AS [TransLevel],
    trd.TradeAllocationId AS [ClientRef#],
    CONCAT(trd.TradeId,'A') AS [Associated#],
    trd.ExecutionAccount AS [ExecAccount],
    trd.ClearingAccount AS [AccountId],
    trd.ExecutionDesk AS [ExecutionBroker],
    'B' AS [SecType],
    trd.Symbol AS [SecID],
    trd.[SecurityName] as SecurityDescription,
    FORMAT(trd.TradeDate, 'MM/dd/yyyy') AS TradeDate,
    FORMAT(trd.SettlementDate, 'MM/dd/yyyy') AS SettlementDate,
    trd.SettlementCurrency AS SettlementCurrency,
    '' AS ExchangeCode,
    ABS(trd.Quantity) AS [Quantity],
	  CASE WHEN LEFT(trd.Symbol, 2)= 'JY' AND RIGHT(trd.Symbol, 6) = 'Curncy' THEN trd.GrossAvgPriceLocal/100
	  WHEN LEFT(trd.Symbol, 2)= 'NO' AND RIGHT(trd.Symbol, 6) = 'Curncy' THEN trd.GrossAvgPriceLocal/100
	  WHEN LEFT(trd.Symbol, 2)= 'SE' AND RIGHT(trd.Symbol, 6) = 'Curncy' THEN trd.GrossAvgPriceLocal/100
	  WHEN LEFT(trd.Symbol, 2)= 'RA' AND RIGHT(trd.Symbol, 6) = 'Curncy' THEN trd.GrossAvgPriceLocal/100
	  WHEN LEFT(trd.Symbol, 2)= 'HE' AND RIGHT(trd.Symbol, 6) = 'Curncy' THEN trd.GrossAvgPriceLocal/100
	  WHEN LEFT(trd.Symbol, 2)= 'BR' AND RIGHT(trd.Symbol, 6) = 'Curncy' THEN trd.GrossAvgPriceLocal/100
	 ELSE trd.GrossAvgPriceLocal END AS PriceAmount,
    'G' AS PriceIndicator,
    CAST(ABS(trd.GrossPrincipalLocal) AS DECIMAL(24,2)) AS Principal,
    CAST(ABS(trd.CommissionAmountLocal) AS DECIMAL(24,2)) AS CommissionAmount,
    'F' AS CommissionIndicator,
    0 AS [Tax/Fees],
    '' AS [Tax2],
    'F' AS [FeeInd],
    '' AS [Interest],
    '' AS [InterestIndicator],
    CAST(ABS(trd.NetPrincipalLocal)AS DECIMAL(24,2))  AS NetAmount,
    'Y' AS [HearsayInd],
    trd.Custodian AS [Custodian],
    '' AS [MoneyManager],
    '' AS [BookId],
    '' AS [DealId],
    '' AS [TaxLotId],
    '' AS [TaxDate],
    '' AS [TaxPrice],
    '' AS [CloseOutMethod],
    '' AS [ExRate],
    '' AS [AcqDate],
    '' AS [Comments]
FROM  
   trades trd
GO
/****** Object:  Table [val].[Portfolio]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [val].[Portfolio](
	[PortfolioId] [tinyint] NOT NULL,
	[Mnemonic] [nvarchar](6) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[TotalValue] [decimal](18, 6) NOT NULL,
	[Currency] [char](3) NOT NULL,
 CONSTRAINT [PK_PortfolioId] PRIMARY KEY CLUSTERED 
(
	[PortfolioId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [val].[vwLastPositionValuationV2]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [val].[vwLastPositionValuationV2] AS
with positions as (SELECT p.[PortfolioId]
,f.Mnemonic
,f.TotalValue as  PortfolioTotalValue 
,f.Currency as PortfolioCurrency
      ,p.[InstrumentId]
      ,[Quantity]
      ,[AvgEntryPriceLocal]
      ,[GrossTotalCostLocal]
      ,[NetTotalCostLocal]
      ,[LastTradeAllocationId]
      ,[PositionDate]
      ,p.[Currency]
      ,[PreviousQuantity]
      ,[PreviousAvgEntryPriceLocal]
      ,[PreviousGrossTotalCostLocal]
      ,[PreviousNetTotalCostLocal]
      ,[PreviousPositionDate]

	  ,v.[Price]
      ,v.[PriceDate]
      ,v.[PreviousPrice]
      ,v.[PreviousPriceDate]
      ,v.[ValuationFactor]
      ,v.[InstrumentValue]
      ,v.[PreviousInstrumentValue]
      ,v.[PriceReturn]
      ,v.[Currency] as PriceCurrency
	    ,(v.[InstrumentValue]*[Quantity])  as LocalMarketValue
  FROM [val].[Position] p
  JOIN val.Portfolio f on f.PortfolioId = p.PortfolioId
  JOIN val.vwLastInstrumentValuation v on v.InstrumentId = p.InstrumentId)

  SELECT [PortfolioId]
,Mnemonic
,PortfolioTotalValue
,PortfolioCurrency
      ,[InstrumentId]
      ,[Quantity]
      ,[AvgEntryPriceLocal]
      ,[GrossTotalCostLocal]
      ,[NetTotalCostLocal]
      ,[LastTradeAllocationId]
      ,[PositionDate]
      ,[Currency]
      ,[PreviousQuantity]
      ,[PreviousAvgEntryPriceLocal]
      ,[PreviousGrossTotalCostLocal]
      ,[PreviousNetTotalCostLocal]
      ,[PreviousPositionDate]

	  ,[Price]
      ,[PriceDate]
      ,[PreviousPrice]
      ,[PreviousPriceDate]
      ,[ValuationFactor]
      ,[InstrumentValue]
      ,[PreviousInstrumentValue]
      ,[PriceReturn]
      , PriceCurrency
  	  ,([InstrumentValue]-[PreviousInstrumentValue])*PreviousQuantity as LocalDailyPnl
	   --,([InstrumentValue]*FXRAte-[PreviousInstrumentValue]*PrevFxRate)*PrevQuantity as BaseDailyPnl	   
	 --,LocalMarketValue*FxRate as BaseMarketValue
	  ,LocalMarketValue/PortfolioTotalValue as NetExposure
	  ,ABS(LocalMarketValue/PortfolioTotalValue) as GrossExposure 
	  from positions



GO
/****** Object:  UserDefinedFunction [trans].[tvTradesFileMSPBD01]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE FUNCTION [trans].[tvTradesFileMSPBD01] (@PortfolioId tinyint)
RETURNS TABLE
AS
RETURN
with trades as (
SELECT  [TradeAllocationId]
      ,[TradeId]
      ,[TradeStatus]
      ,[InstrumentId]
      ,[Symbol]
      ,[TradeSide]
      ,[TradeDate]
      ,[Exchange]
      ,[IsSwap]
      ,[InstrumentType]
      ,[TradeInstrumentType]
      ,[YellowKey]
      ,[ExecutionDesk]
      ,execbroker.CounterpartyCode as [ExecutionBroker]
      ,execaccount.CounterpartyCode as[ExecutionAccount]
      ,[Isin]
      ,[Sedol]
      ,[Cusip]
      ,[SecurityName]
      ,[LocalExchangeSymbol]
      ,trd.[PortfolioId]
      ,[PositionSide]
      ,[Quantity]
      ,[ContractMultiplier]
      ,[NominalQuantity]
      ,[LocalCurrency]
      ,[BaseCurrency]
      ,[SettlementCurrency]
      ,[CommissionValue]
      ,[CommissionType]
      ,[GrossAvgPriceLocal]
      ,[PriceCommissionLocal]
      ,[NetAvgPriceLocal]
      ,[GrossAvgPriceBase]
      ,[PriceCommissionBase]
      ,[NetAvgPriceBase]
      ,[GrossAvgPriceSettle]
      ,[PriceCommissionSettle]
      ,[NetAvgPriceSettle]
      ,[CommissionAmountLocal]
      ,[CommissionAmountBase]
      ,[CommissionAmountSettle]
      ,[MiscFeesLocal]
      ,[MiscFeesBase]
      ,[MiscFeesSettle]
      ,[GrossTradeValueLocal]
      ,[NetTradeValueLocal]
      ,[GrossTradeValueBase]
      ,[NetTradeValueBase]
      ,[GrossTradeValueSettle]
      ,[NetTradeValueSettle]
      ,[GrossPrincipalLocal]
      ,[NetPrincipalLocal]
      ,[GrossPrincipalBase]
      ,[NetPrincipalBase]
      ,[GrossPrincipalSettle]
      ,[NetPrincipalSettle]
      ,[SettlementDate]
      ,[LocalToBaseFxRate]
      ,[LocalToSettleFxRate]
      ,[PrimeBroker]
      ,clearingbroker.CounterpartyCode as [ClearingBroker]
      ,clearingaccount.CounterpartyCode as [ClearingAccount]
      ,custodian.CounterpartyCode as [Custodian]
      ,[EmsxOrderId]
      ,[OrderReferenceId]
      ,[BlockOrderQuantity]
      ,[OrderAllocationQuantity]
      ,[OrderAllocationNominalQuantity]
      ,[ExecutionType]
      ,[Notes]
      ,[TraderName]
      ,[TraderUuid]
      ,[LastCorrectedOnUtc]
      ,[CanceledOnUtc]
      ,[BookedOnUtc]

  FROM [trans].[BookedTradeAllocation] trd
  JOIN
    trans.FileGenerationType fgt ON fgt.mnemonic = 'MSPBD01'
JOIN
    trans.FileGenerationProfile fgp ON fgp.FileGenerationTypeId = fgt.FileGenerationTypeId
    AND fgp.PortfolioId = trd.PortfolioId
JOIN
    trans.TransmissionProfile tp ON tp.TransmissionProfileId = fgp.TransmissionProfileId
LEFT JOIN
    trans.[ClearingBrokerCodeMapping] clearingbroker ON clearingbroker.FileGenerationTypeId = fgt.FileGenerationTypeId
    AND clearingbroker.InternalCode = trd.ClearingBroker
LEFT JOIN
    trans.[ClearingAccountCodeMapping] clearingaccount ON clearingaccount.CounterpartyId = tp.CounterpartyId
    AND clearingaccount.InternalCode = trd.ClearingAccount
LEFT JOIN
    trans.[ExecutionBrokerCodeMapping] execbroker ON execbroker.FileGenerationTypeId = fgt.FileGenerationTypeId
    AND execbroker.InternalCode = trd.ExecutionBroker
LEFT JOIN
    trans.[ExecutionAccountCodeMapping] execaccount ON execaccount.CounterpartyId = tp.CounterpartyId
    AND execaccount.InternalCode = trd.ExecutionAccount
LEFT JOIN
    trans.[CustodianCodeMapping] custodian ON custodian.FileGenerationTypeId = fgt.FileGenerationTypeId
    AND custodian.PortfolioId = trd.PortfolioId
    AND custodian.InternalCode = trd.Custodian

LEFT JOIN trans.[vwLastFileTransmission] ft ON ft.[TransmissionType] = tp.Mnemonic

WHERE 
   trd.TradeInstrumentType = 'FUT'
  	AND trd.PrimeBroker ='MS'
   AND (ft.TransmittedOn IS NULL OR ft.TransmittedOn < trd.BookedOnUtc OR ft.TransmittedOn < trd.CanceledOnUtc OR  ft.TransmittedOn < trd.LastCorrectedOnUtc)
	AND trd.PortfolioId = @PortfolioId

)
SELECT  
    'D01' AS [Transaction_Type],    
    trd.ClearingAccount AS [Account],   
    trd.TradeAllocationId AS [Client_Ref_No],
    '1' AS Version_Number,
    trd.TradeStatus AS Transaction_Status,
    'B' AS Sec_identifier_Type,
    trd.Symbol AS Sec_Identifier,
    '' AS Contract_Year,
    '' AS Contract_Month,
    '' AS Contract_Day,
    trd.[SecurityName] AS Contract_Security_Description,
    trd.Exchange AS [Market/Exchange],   
    trd.TradeSide AS [Buy Sell Indicator],   
    '' AS Trade_Type,
    '' AS order_To_Close_Ind,
    '' AS Average_Price_Ind,
    '' AS Spread_Trade_Ind,
    '' AS Night_Trade_Ind,
    '' AS Exchange_for_Physical_Ind,
    '' AS [Block_Trade_Ind],
    '' AS [Off_Exchange_Ind],
    CAST(FORMAT(trd.TradeDate, 'MM/dd/yyyy') AS NVARCHAR(10)) AS [Trade_Date],
    '' AS ExecutionTime,
    ABS(trd.Quantity) AS Quantity,
    ROUND(trd.GrossAvgPriceLocal, 5) AS Price,
    '' AS [Call/Put],
    '' AS Strike_Price,
    trd.ExecutionBroker AS Executing_Broker,
    trd.ClearingBroker AS Clearing_Broker,
    '' AS Give_Up_Reference,
    '' AS Hearsay_Ind,
    '' AS Execution_Fee,
    '' AS Execution_Fee_CCY,
    trd.CommissionAmountLocal AS Commission,
    '' AS Commission_CCY,
    cast(0 as decimal(7,6)) AS Exchange_Fee,
    '' AS Exchange_Fee_CCY,
    trd.OrderReferenceId AS OrderId,
    '' AS DealId,
    'E' AS Execution_Type
FROM 
   trades trd
GO
/****** Object:  UserDefinedFunction [trans].[tvTradesFileMSPBSW002]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE FUNCTION [trans].[tvTradesFileMSPBSW002] (@PortfolioId tinyint)
RETURNS TABLE
AS
RETURN
with trades as (
SELECT  [TradeAllocationId]
      ,[TradeId]
      ,[TradeStatus]
      ,[InstrumentId]
      ,[Symbol]
      ,[TradeSide]
      ,[TradeDate]
      ,[Exchange]
      ,[IsSwap]
      ,[InstrumentType]
      ,[TradeInstrumentType]
      ,[YellowKey]
      ,[ExecutionDesk]
      ,execbroker.CounterpartyCode as [ExecutionBroker]
      ,execaccount.CounterpartyCode as[ExecutionAccount]
      ,[Isin]
      ,[Sedol]
      ,[Cusip]
      ,[SecurityName]
      ,[LocalExchangeSymbol]
      ,trd.[PortfolioId]
      ,[PositionSide]
      ,[Quantity]
      ,[ContractMultiplier]
      ,[NominalQuantity]
      ,[LocalCurrency]
      ,[BaseCurrency]
      ,[SettlementCurrency]
      ,[CommissionValue]
      ,[CommissionType]
      ,[GrossAvgPriceLocal]
      ,[PriceCommissionLocal]
      ,[NetAvgPriceLocal]
      ,[GrossAvgPriceBase]
      ,[PriceCommissionBase]
      ,[NetAvgPriceBase]
      ,[GrossAvgPriceSettle]
      ,[PriceCommissionSettle]
      ,[NetAvgPriceSettle]
      ,[CommissionAmountLocal]
      ,[CommissionAmountBase]
      ,[CommissionAmountSettle]
      ,[MiscFeesLocal]
      ,[MiscFeesBase]
      ,[MiscFeesSettle]
      ,[GrossTradeValueLocal]
      ,[NetTradeValueLocal]
      ,[GrossTradeValueBase]
      ,[NetTradeValueBase]
      ,[GrossTradeValueSettle]
      ,[NetTradeValueSettle]
      ,[GrossPrincipalLocal]
      ,[NetPrincipalLocal]
      ,[GrossPrincipalBase]
      ,[NetPrincipalBase]
      ,[GrossPrincipalSettle]
      ,[NetPrincipalSettle]
      ,[SettlementDate]
      ,[LocalToBaseFxRate]
      ,[LocalToSettleFxRate]
      ,[PrimeBroker]
      ,clearingbroker.CounterpartyCode as [ClearingBroker]
      ,clearingaccount.CounterpartyCode as [ClearingAccount]
      ,custodian.CounterpartyCode as [Custodian]
      ,[EmsxOrderId]
      ,[OrderReferenceId]
      ,[BlockOrderQuantity]
      ,[OrderAllocationQuantity]
      ,[OrderAllocationNominalQuantity]
      ,[ExecutionType]
      ,[Notes]
      ,[TraderName]
      ,[TraderUuid]
      ,[LastCorrectedOnUtc]
      ,[CanceledOnUtc]
      ,[BookedOnUtc]

  FROM [trans].[BookedTradeAllocation] trd
  JOIN
    trans.FileGenerationType fgt ON fgt.mnemonic = 'MSPBSW002'
JOIN
    trans.FileGenerationProfile fgp ON fgp.FileGenerationTypeId = fgt.FileGenerationTypeId
    AND fgp.PortfolioId = trd.PortfolioId
JOIN
    trans.TransmissionProfile tp ON tp.TransmissionProfileId = fgp.TransmissionProfileId
LEFT JOIN
    trans.[ClearingBrokerCodeMapping] clearingbroker ON clearingbroker.FileGenerationTypeId = fgt.FileGenerationTypeId
    AND clearingbroker.InternalCode = trd.ClearingBroker
LEFT JOIN
    trans.[ClearingAccountCodeMapping] clearingaccount ON clearingaccount.CounterpartyId = tp.CounterpartyId
    AND clearingaccount.InternalCode = trd.ClearingAccount
LEFT JOIN
    trans.[ExecutionBrokerCodeMapping] execbroker ON execbroker.FileGenerationTypeId = fgt.FileGenerationTypeId
    AND execbroker.InternalCode = trd.ExecutionBroker
LEFT JOIN
    trans.[ExecutionAccountCodeMapping] execaccount ON execaccount.CounterpartyId = tp.CounterpartyId
    AND execaccount.InternalCode = trd.ExecutionAccount
LEFT JOIN
    trans.[CustodianCodeMapping] custodian ON custodian.FileGenerationTypeId = fgt.FileGenerationTypeId
    AND custodian.PortfolioId = trd.PortfolioId
    AND custodian.InternalCode = trd.Custodian

LEFT JOIN trans.[vwLastFileTransmission] ft ON ft.[TransmissionType] = tp.Mnemonic

WHERE 
 trd.IsSwap = 1
	AND trd.PrimeBroker = 'MS'--That is not correct, we can exec with one broker and pb another.
 --   AND trd.TradeDate = CAST(GETDATE() AS DATE) 
    AND (ft.TransmittedOn IS NULL OR ft.TransmittedOn < trd.BookedOnUtc OR ft.TransmittedOn < trd.CanceledOnUtc OR  ft.TransmittedOn < trd.LastCorrectedOnUtc)
	AND trd.PortfolioId = @PortfolioId
)
SELECT  
    'SW002' AS [Transaction Type],
    trd.TradeStatus AS [Transaction Status],
    trd.TradeSide AS [Buy Sell Indicator],
    CASE 
        WHEN trd.TradeSide = 'S' AND (trd.PositionSide IN ('L', 'C')) THEN 'L'
        WHEN trd.TradeSide = 'S' AND trd.PositionSide = 'S' THEN 'S'
        WHEN trd.TradeSide = 'B' AND trd.PositionSide = 'L' THEN 'L'
        WHEN trd.TradeSide = 'B' AND (trd.PositionSide IN ('S', 'C')) THEN 'C'
    END AS [Long Short Indicator],
    '' AS [Position Type],
    'A' AS [Transaction Level],
    trd.TradeAllocationId AS [Client Trade Ref No.],
    CONCAT(trd.TradeId,'A') AS [Associated Trade Id],
    trd.ExecutionAccount AS [Execution Account],   
    trd.ClearingAccount AS [Account Id],
    trd.ExecutionBroker  AS [Broker / Counterparty],
    IIF(trd.Sedol IS NULL OR TRIM(trd.Sedol) = '', 'B', 'S') AS [Security Identifier Type],
    IIF(trd.Sedol IS NULL OR TRIM(trd.Sedol) = '',
        IIF(CHARINDEX(' ', trd.Symbol) > 0, LEFT(trd.Symbol, CHARINDEX(' ', trd.Symbol) - 1), NULL),
        trd.Sedol) AS [SecurityIdentifier],
    trd.[SecurityName] AS [Security Description],
    FORMAT(trd.[TradeDate], 'yyyy-MM-dd') AS [Trade Date],
    FORMAT(trd.SettlementDate, 'yyyy-MM-dd') AS [Settlement Date], -- TGU 3 to 2
    trd.SettlementCurrency AS [Settlement CCY],
    '' AS [Exchange Code],
    ABS(Quantity) AS [Quantity],
    ROUND(trd.GrossAvgPriceLocal, 5) AS [Price],
    'G' AS [Price Indicator],
    CAST(ABS(GrossPrincipalLocal) AS DECIMAL(24,2)) AS [Principal],
    CAST(ABS(trd.CommissionAmountLocal) AS DECIMAL(24,2)) AS [Execution Broker Commission],
    'F' AS [Executing broker Commission Indicator],
    CAST(trd.[MiscFeesLocal] AS DECIMAL(6,4)) AS [MS Fees],
    '' AS [Not Required],
    'F' AS [MS fees Indicator.],
    '' AS [Dividend Entitlement Percent],
    '' AS [Spread],
    CAST(ABS(trd.NetPrincipalLocal) AS DECIMAL(24,2)) AS [Net Amount],
    '' AS [Hearsay Ind],
    trd.[Custodian] AS [Custodian],
    '' AS [Money Manager],
    '' AS [Book Id],
    '' AS [Deal Id],
    '' AS [TaxLot Id],
    '' AS [Original taxlot transaction date],
    '' AS [Original Taxlot transaction price],
    '' AS [Taxlot Closeout Method],
    '' AS [Price FX Rate],
    '' AS [Acquisition Date],
    '' AS [Comments],
    '' AS [Swap Reference No.],
    '' AS [Basket Id],
    trd.LocalCurrency AS [Price Currency],
    '' AS [Reset Indicator],
    '' AS [SNS reference],
    '' AS [Research Fee],
    '' AS [Research Fee Indicator],
    '' AS [LEI],
    '' AS [Client Strategy 2 (Used for PEPS)]
FROM 
    trades trd
GO
/****** Object:  Table [risk].[PortfolioConstraint_H]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [risk].[PortfolioConstraint_H](
	[PortfolioConstraintId] [int] NOT NULL,
	[PortfolioId] [tinyint] NOT NULL,
	[ConstraintId] [int] NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_PortfolioConstraint_H]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_PortfolioConstraint_H] ON [risk].[PortfolioConstraint_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [risk].[PortfolioConstraint]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [risk].[PortfolioConstraint](
	[PortfolioConstraintId] [int] IDENTITY(1,1) NOT NULL,
	[PortfolioId] [tinyint] NOT NULL,
	[ConstraintId] [int] NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_PortfolioConstraint] PRIMARY KEY CLUSTERED 
(
	[PortfolioConstraintId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_PortfolioConstraint] UNIQUE NONCLUSTERED 
(
	[PortfolioId] ASC,
	[ConstraintId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [risk].[PortfolioConstraint_H])
)
GO
/****** Object:  UserDefinedFunction [trans].[tvTradesFileMSFSSW002]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE FUNCTION [trans].[tvTradesFileMSFSSW002] (@PortfolioId tinyint)
RETURNS TABLE
AS
RETURN
with trades as (
SELECT  [TradeAllocationId]
      ,[TradeId]
      ,[TradeStatus]
      ,[InstrumentId]
      ,[Symbol]
      ,[TradeSide]
      ,[TradeDate]
      ,[Exchange]
      ,[IsSwap]
      ,[InstrumentType]
      ,[TradeInstrumentType]
      ,[YellowKey]
      ,[ExecutionDesk]
      ,execbroker.CounterpartyCode as [ExecutionBroker]
      ,execaccount.CounterpartyCode as[ExecutionAccount]
      ,[Isin]
      ,[Sedol]
      ,[Cusip]
      ,[SecurityName]
      ,[LocalExchangeSymbol]
      ,trd.[PortfolioId]
      ,[PositionSide]
      ,[Quantity]
      ,[ContractMultiplier]
      ,[NominalQuantity]
      ,[LocalCurrency]
      ,[BaseCurrency]
      ,[SettlementCurrency]
      ,[CommissionValue]
      ,[CommissionType]
      ,[GrossAvgPriceLocal]
      ,[PriceCommissionLocal]
      ,[NetAvgPriceLocal]
      ,[GrossAvgPriceBase]
      ,[PriceCommissionBase]
      ,[NetAvgPriceBase]
      ,[GrossAvgPriceSettle]
      ,[PriceCommissionSettle]
      ,[NetAvgPriceSettle]
      ,[CommissionAmountLocal]
      ,[CommissionAmountBase]
      ,[CommissionAmountSettle]
      ,[MiscFeesLocal]
      ,[MiscFeesBase]
      ,[MiscFeesSettle]
      ,[GrossTradeValueLocal]
      ,[NetTradeValueLocal]
      ,[GrossTradeValueBase]
      ,[NetTradeValueBase]
      ,[GrossTradeValueSettle]
      ,[NetTradeValueSettle]
      ,[GrossPrincipalLocal]
      ,[NetPrincipalLocal]
      ,[GrossPrincipalBase]
      ,[NetPrincipalBase]
      ,[GrossPrincipalSettle]
      ,[NetPrincipalSettle]
      ,[SettlementDate]
      ,[LocalToBaseFxRate]
      ,[LocalToSettleFxRate]
      ,[PrimeBroker]
      ,clearingbroker.CounterpartyCode as [ClearingBroker]
      ,clearingaccount.CounterpartyCode as [ClearingAccount]
      ,custodian.CounterpartyCode as [Custodian]
      ,[EmsxOrderId]
      ,[OrderReferenceId]
      ,[BlockOrderQuantity]
      ,[OrderAllocationQuantity]
      ,[OrderAllocationNominalQuantity]
      ,[ExecutionType]
      ,[Notes]
      ,[TraderName]
      ,[TraderUuid]
      ,[LastCorrectedOnUtc]
      ,[CanceledOnUtc]
      ,[BookedOnUtc]

  FROM [trans].[BookedTradeAllocation] trd
  JOIN
    trans.FileGenerationType fgt ON fgt.mnemonic = 'MSFSSW002'
JOIN
    trans.FileGenerationProfile fgp ON fgp.FileGenerationTypeId = fgt.FileGenerationTypeId
    AND fgp.PortfolioId = trd.PortfolioId
JOIN
    trans.TransmissionProfile tp ON tp.TransmissionProfileId = fgp.TransmissionProfileId
LEFT JOIN
    trans.[ClearingBrokerCodeMapping] clearingbroker ON clearingbroker.FileGenerationTypeId = fgt.FileGenerationTypeId
    AND clearingbroker.InternalCode = trd.ClearingBroker
LEFT JOIN
    trans.[ClearingAccountCodeMapping] clearingaccount ON clearingaccount.CounterpartyId = tp.CounterpartyId
    AND clearingaccount.InternalCode = trd.ClearingAccount
LEFT JOIN
    trans.[ExecutionBrokerCodeMapping] execbroker ON execbroker.FileGenerationTypeId = fgt.FileGenerationTypeId
    AND execbroker.InternalCode = trd.ExecutionBroker
LEFT JOIN
    trans.[ExecutionAccountCodeMapping] execaccount ON execaccount.CounterpartyId = tp.CounterpartyId
    AND execaccount.InternalCode = trd.ExecutionAccount
LEFT JOIN
    trans.[CustodianCodeMapping] custodian ON custodian.FileGenerationTypeId = fgt.FileGenerationTypeId
    AND custodian.PortfolioId = trd.PortfolioId
    AND custodian.InternalCode = trd.Custodian

LEFT JOIN trans.[vwLastFileTransmission] ft ON ft.[TransmissionType] = tp.Mnemonic

WHERE 
 trd.IsSwap = 1
	 	AND trd.PrimeBroker ='MS'
    AND (ft.TransmittedOn IS NULL OR ft.TransmittedOn < trd.BookedOnUtc OR ft.TransmittedOn < trd.CanceledOnUtc OR  ft.TransmittedOn < trd.LastCorrectedOnUtc)
	AND trd.PortfolioId = @PortfolioId
	)
SELECT 
    'SW002' AS TrasationType,
    trd.TradeStatus AS TransactionStatus,
    trd.TradeSide AS [Buy/Sell],
    CASE 
        WHEN trd.TradeSide = 'S' AND (trd.PositionSide = 'L' OR trd.PositionSide = 'C') THEN 'L'
        WHEN trd.TradeSide = 'S' AND trd.PositionSide = 'S' THEN 'S'
        WHEN trd.TradeSide = 'B' AND trd.PositionSide = 'L' THEN 'L'
        WHEN trd.TradeSide = 'B' AND (trd.PositionSide = 'S' OR trd.PositionSide = 'C') THEN 'C'
    END AS [Long/Short],
    '' AS [PositionType],
    'A' AS [TransLevel],
    trd.TradeAllocationId AS [ClientTradeRefNo],
    CONCAT(trd.TradeId,'A') AS [AssociatedTradeId],
    trd.ExecutionAccount AS [ExecutionAccount],
    trd.ClearingAccount AS [Account Id],
    trd.ExecutionDesk AS [Broker/Couterparty],
    IIF(trd.Sedol IS NULL OR TRIM(trd.Sedol) = '', 'B','S') AS [SecurityIdentifierType],
    IIF(trd.Sedol IS NULL OR TRIM(trd.Sedol) = '',trd.Symbol, trd.Sedol) AS [SecurityIdentifier],
    trd.SecurityName as SecurityDescription,
    FORMAT(trd.TradeDate, 'MM/dd/yyyy') AS TradeDate,
    FORMAT(trd.SettlementDate, 'MM/dd/yyyy') AS SettlementDate, -- TGU put 3 vs 2
    trd.SettlementCurrency AS SettlementCurrency,
    '' AS [ExchangeCode],
    ABS(trd.Quantity) AS [Quantity],
    trd.GrossAvgPriceSettle AS Price,
    'G' AS PriceIndicator,
    CAST(ABS(trd.GrossPrincipalSettle) AS DECIMAL(24,2)) AS Principal,
    CAST(ABS(trd.CommissionAmountSettle) AS DECIMAL(24,2)) AS [BrokerCommission],
    'F' AS [BrokerCommissionInd],
    ABS(trd.[MiscFeesLocal]) AS [MSFees],
    '' AS [NotRequired],
    'F' AS [MSFeesInd],
    '' AS [DivEntitlPercent],
    '' AS Spread,
    ABS(trd.NetPrincipalSettle) AS NetAmount,
    'Y' AS [HearsayInd],
    trd.Custodian AS [Custodian],
    '' AS [MoneyManager],
    '' AS [BookId],
    '' AS [DealId],
    '' AS [TaxLotId],
    '' AS [TaxDate],
    '' AS [TaxPrice],
    '' AS [CloseOutMethod],
    '' AS [FxRate],
    '' AS [AcquisitionDate],
    '' AS [Comments],
    '' AS [SwapReferenceNo],
    '' AS [BasketId],
    '' AS [PriceCurrency],
    '' AS [ResetIndicator],
    '' AS [SnSReference],
    '' AS [ResearchFee],
    '' AS [ResearchFeeInd],
    '' AS [LEI],
    '' AS [MaturityDate],
    'Equity Vanilla Swaps' AS [ProductType],
    '' AS [Fuut/Part Unwind Ind],
    '' AS [PaymentDate],
    '' AS [DividendAmount],
    '' AS [DividendPayoutDate],
    '' AS [NextResetDate],
    '' AS [ResetPrice],
    '' AS [EquitySpread],
    '' AS [DaycountConvention],
    '' AS [FloatingRate],
    '' AS [RollConvention],
    '' AS [CollateralPledge],
    '' AS [FixingFrequency],
    '' AS [PaymentFrequency]
FROM 
    trades trd
GO
/****** Object:  Table [trans].[H_Counterparty]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[H_Counterparty](
	[CounterpartyId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ValidFrom] [datetime2](7) NOT NULL,
	[ValidTo] [datetime2](7) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_H_Counterparty]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_H_Counterparty] ON [trans].[H_Counterparty]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [trans].[Counterparty]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[Counterparty](
	[CounterpartyId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ValidFrom] [datetime2](7) GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
	[ValidTo] [datetime2](7) GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
 CONSTRAINT [PK_Counterparty] PRIMARY KEY CLUSTERED 
(
	[CounterpartyId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [trans].[H_Counterparty])
)
GO
/****** Object:  View [trans].[vwTransmissionProfile]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
























/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [trans].[vwTransmissionProfile] as
SELECT  [TransmissionProfileId]
      ,tp.[Mnemonic]
	  ,tp.[Description]
	  ,tp.[IsEnabled]
      ,tp.[CounterPartyId]
	  ,c.[Name] as CounterPartyName
	  ,tp.[FileContentTypeId]
	  ,fct.Mnemonic as [FileContentType]
	  ,tp.[FtpConfigurationId]
	  ,ftp.Host as FtpHost
	  ,ftp.Username as FtpUser
	  ,ftp.[Port] as FtpPort
	  ,ftp.RemoteFolder as FtpRemoteFolder
      ,tp.[EmailConfigurationId]
      ,tp.[EncryptionProfileId]
	  ,ep.ExcryptedFileExtension
	  ,ep.[Sign] as EncryptAndSign    
      ,tp.[TransmissionScheduleTypeId]
	  ,tst.Mnemonic  as TransmissionScheduleType
  FROM [trans].[TransmissionProfile] tp
  LEFT JOIN  [trans].Counterparty  c on c.CounterpartyId  = tp.CounterPartyId
  LEFT JOIN [trans].[FtpConfiguration] ftp on ftp.[FtpConfigurationId] = tp.FtpConfigurationId
  LEFT  JOIN [trans].EncryptionProfile ep on ep.EncryptionProfileId = tp.EncryptionProfileId
  LEFT JOIN [trans].TransmissionScheduleType tst on tst.TransmissionScheduleTypeId = tp. TransmissionScheduleTypeId
  LEFT JOIN [trans].FileContentType fct on fct.FileContentTypeId = tp.[FileContentTypeId]


GO
/****** Object:  UserDefinedFunction [trans].[tvTradesFileCAPRICORN]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE FUNCTION [trans].[tvTradesFileCAPRICORN] (@PortfolioId tinyint)
RETURNS TABLE
AS
RETURN
with trades as (
SELECT  [TradeAllocationId]
      ,[TradeId]
      ,[TradeStatus]
      ,[InstrumentId]
      ,[Symbol]
      ,[TradeSide]
      ,[TradeDate]
      ,[Exchange]
      ,[IsSwap]
      ,[InstrumentType]
      ,[TradeInstrumentType]
      ,[YellowKey]
      ,[ExecutionDesk]
      ,execbroker.CounterpartyCode as [ExecutionBroker]
      ,execaccount.CounterpartyCode as[ExecutionAccount]
      ,[Isin]
      ,[Sedol]
      ,[Cusip]
      ,[SecurityName]
      ,[LocalExchangeSymbol]
      ,trd.[PortfolioId]
      ,[PositionSide]
      ,[Quantity]
      ,[ContractMultiplier]
      ,[NominalQuantity]
      ,[LocalCurrency]
      ,[BaseCurrency]
      ,[SettlementCurrency]
      ,[CommissionValue]
      ,[CommissionType]
      ,[GrossAvgPriceLocal]
      ,[PriceCommissionLocal]
      ,[NetAvgPriceLocal]
      ,[GrossAvgPriceBase]
      ,[PriceCommissionBase]
      ,[NetAvgPriceBase]
      ,[GrossAvgPriceSettle]
      ,[PriceCommissionSettle]
      ,[NetAvgPriceSettle]
      ,[CommissionAmountLocal]
      ,[CommissionAmountBase]
      ,[CommissionAmountSettle]
      ,[MiscFeesLocal]
      ,[MiscFeesBase]
      ,[MiscFeesSettle]
      ,[GrossTradeValueLocal]
      ,[NetTradeValueLocal]
      ,[GrossTradeValueBase]
      ,[NetTradeValueBase]
      ,[GrossTradeValueSettle]
      ,[NetTradeValueSettle]
      ,[GrossPrincipalLocal]
      ,[NetPrincipalLocal]
      ,[GrossPrincipalBase]
      ,[NetPrincipalBase]
      ,[GrossPrincipalSettle]
      ,[NetPrincipalSettle]
      ,[SettlementDate]
      ,[LocalToBaseFxRate]
      ,[LocalToSettleFxRate]
      ,[PrimeBroker]
      ,clearingbroker.CounterpartyCode as [ClearingBroker]
      ,clearingaccount.CounterpartyCode as [ClearingAccount]
      ,custodian.CounterpartyCode as [Custodian]
      ,[EmsxOrderId]
      ,[OrderReferenceId]
      ,[BlockOrderQuantity]
      ,[OrderAllocationQuantity]
      ,[OrderAllocationNominalQuantity]
      ,[ExecutionType]
      ,[Notes]
      ,[TraderName]
      ,[TraderUuid]
      ,[LastCorrectedOnUtc]
      ,[CanceledOnUtc]
      ,[BookedOnUtc]

  FROM [trans].[BookedTradeAllocation] trd
  JOIN
    trans.FileGenerationType fgt ON fgt.mnemonic = 'CAPRICORN'
JOIN
    trans.FileGenerationProfile fgp ON fgp.FileGenerationTypeId = fgt.FileGenerationTypeId
    AND fgp.PortfolioId = trd.PortfolioId
JOIN
    trans.TransmissionProfile tp ON tp.TransmissionProfileId = fgp.TransmissionProfileId
LEFT JOIN
    trans.[ClearingBrokerCodeMapping] clearingbroker ON clearingbroker.FileGenerationTypeId = fgt.FileGenerationTypeId
    AND clearingbroker.InternalCode = trd.ClearingBroker
LEFT JOIN
    trans.[ClearingAccountCodeMapping] clearingaccount ON clearingaccount.CounterpartyId = tp.CounterpartyId
    AND clearingaccount.InternalCode = trd.ClearingAccount
LEFT JOIN
    trans.[ExecutionBrokerCodeMapping] execbroker ON execbroker.FileGenerationTypeId = fgt.FileGenerationTypeId
    AND execbroker.InternalCode = trd.ExecutionBroker
LEFT JOIN
    trans.[ExecutionAccountCodeMapping] execaccount ON execaccount.CounterpartyId = tp.CounterpartyId
    AND execaccount.InternalCode = trd.ExecutionAccount
LEFT JOIN
    trans.[CustodianCodeMapping] custodian ON custodian.FileGenerationTypeId = fgt.FileGenerationTypeId
    AND custodian.PortfolioId = trd.PortfolioId
    AND custodian.InternalCode = trd.Custodian

LEFT JOIN trans.[vwLastFileTransmission] ft ON ft.[TransmissionType] = tp.Mnemonic

WHERE 
     (ft.TransmittedOn IS NULL OR ft.TransmittedOn < trd.BookedOnUtc OR ft.TransmittedOn < trd.CanceledOnUtc OR  ft.TransmittedOn < trd.LastCorrectedOnUtc)
	AND trd.PortfolioId = @PortfolioId
)
SELECT 
  ROW_NUMBER() OVER(ORDER BY trd.Symbol)  as [Order number],
  REPLACE(REPLACE(REPLACE(trd.TradeStatus,'NEW','N'),'CAN','C'),'COR','A') as Activity,
  trd.ClearingAccount as Account,
  trd.SecurityName as [Security Description],
  trd.Symbol as [Ticker Symbol],
  trd.Exchange as [Exchange-MIC],
  ISNULL(trd.ISIN,'') as [ISIN],
  IIF(trd.Sedol is null or TRIM(trd.Sedol )= '', '',trd.Sedol ) as [SEDOL],
  '' as[CUSIP],
  trd.ExecutionDesk as [Broker],
  trd.Custodian as Custodian,
  trd.InstrumentType as [Security Type],
  trd.PositionSide as [Transaction type],
  trd.SettlementCurrency as [Settlement Ccy],
  FORMAT(cast(trd.TradeDate as date),'yyyyMMdd') as [Trade date],
  FORMAT(trd.SettlementDate,'yyyyMMdd') as [Settle date],
  trd.Quantity as [Order Quantity],-- trd.OrderQuantity as [Order Quantity],
   trd.Quantity as[Filled Quantity],--  trd.FilledQuantity as[Filled Quantity],
  trd.CommissionAmountLocal as [Commission],
  trd.GrossAvgPriceBase AS Price,
  '' as [Accrued interest],
  '' as [Sec Fee],
  '' as [Trade tax],
  trd.[MiscFeesLocal] as [Misc money],
  CAST(trd.NetPrincipalLocal as decimal(24,2)) as [Net amount],
  CAST(trd.GrossPrincipalLocal as decimal(24,2)) as [Principal],
  '' as [Description],
  trd.IsSwap as [Is_CFD],
  '' as [Clearing Agent],
  '' as [Put/Call],
  '' as Strike,
  '' as [Expiry Date],
  trd.[TraderName] as Trader --trd.Trader as Trader
FROM 
 trades trd
GO
/****** Object:  UserDefinedFunction [trans].[tvTradesFileINNOCAPTR001]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE FUNCTION [trans].[tvTradesFileINNOCAPTR001] (@PortfolioId tinyint)
RETURNS TABLE
AS
RETURN
with trades as (
SELECT  [TradeAllocationId]
      ,[TradeId]
      ,[TradeStatus]
      ,[InstrumentId]
      ,[Symbol]
      ,[TradeSide]
      ,[TradeDate]
      ,[Exchange]
      ,[IsSwap]
      ,[InstrumentType]
      ,[TradeInstrumentType]
      ,[YellowKey]
      ,[ExecutionDesk]
      ,execbroker.CounterpartyCode as [ExecutionBroker]
      ,execaccount.CounterpartyCode as[ExecutionAccount]
      ,[Isin]
      ,[Sedol]
      ,[Cusip]
      ,[SecurityName]
      ,[LocalExchangeSymbol]
      ,trd.[PortfolioId]
      ,[PositionSide]
      ,[Quantity]
      ,[ContractMultiplier]
      ,[NominalQuantity]
      ,[LocalCurrency]
      ,[BaseCurrency]
      ,[SettlementCurrency]
      ,[CommissionValue]
      ,[CommissionType]
      ,[GrossAvgPriceLocal]
      ,[PriceCommissionLocal]
      ,[NetAvgPriceLocal]
      ,[GrossAvgPriceBase]
      ,[PriceCommissionBase]
      ,[NetAvgPriceBase]
      ,[GrossAvgPriceSettle]
      ,[PriceCommissionSettle]
      ,[NetAvgPriceSettle]
      ,[CommissionAmountLocal]
      ,[CommissionAmountBase]
      ,[CommissionAmountSettle]
      ,[MiscFeesLocal]
      ,[MiscFeesBase]
      ,[MiscFeesSettle]
      ,[GrossTradeValueLocal]
      ,[NetTradeValueLocal]
      ,[GrossTradeValueBase]
      ,[NetTradeValueBase]
      ,[GrossTradeValueSettle]
      ,[NetTradeValueSettle]
      ,[GrossPrincipalLocal]
      ,[NetPrincipalLocal]
      ,[GrossPrincipalBase]
      ,[NetPrincipalBase]
      ,[GrossPrincipalSettle]
      ,[NetPrincipalSettle]
      ,[SettlementDate]
      ,[LocalToBaseFxRate]
      ,[LocalToSettleFxRate]
      ,[PrimeBroker]
      ,clearingbroker.CounterpartyCode as [ClearingBroker]
      ,clearingaccount.CounterpartyCode as [ClearingAccount]
      ,custodian.CounterpartyCode as [Custodian]
      ,[EmsxOrderId]
      ,[OrderReferenceId]
      ,[BlockOrderQuantity]
      ,[OrderAllocationQuantity]
      ,[OrderAllocationNominalQuantity]
      ,[ExecutionType]
      ,[Notes]
      ,[TraderName]
      ,[TraderUuid]
      ,[LastCorrectedOnUtc]
      ,[CanceledOnUtc]
      ,[BookedOnUtc]

  FROM [trans].[BookedTradeAllocation] trd
  JOIN
    trans.FileGenerationType fgt ON fgt.mnemonic = 'INNOCAPTR001'
JOIN
    trans.FileGenerationProfile fgp ON fgp.FileGenerationTypeId = fgt.FileGenerationTypeId
    AND fgp.PortfolioId = trd.PortfolioId
JOIN
    trans.TransmissionProfile tp ON tp.TransmissionProfileId = fgp.TransmissionProfileId
LEFT JOIN
    trans.[ClearingBrokerCodeMapping] clearingbroker ON clearingbroker.FileGenerationTypeId = fgt.FileGenerationTypeId
    AND clearingbroker.InternalCode = trd.ClearingBroker
LEFT JOIN
    trans.[ClearingAccountCodeMapping] clearingaccount ON clearingaccount.CounterpartyId = tp.CounterpartyId
    AND clearingaccount.InternalCode = trd.ClearingAccount
LEFT JOIN
    trans.[ExecutionBrokerCodeMapping] execbroker ON execbroker.FileGenerationTypeId = fgt.FileGenerationTypeId
    AND execbroker.InternalCode = trd.ExecutionBroker
LEFT JOIN
    trans.[ExecutionAccountCodeMapping] execaccount ON execaccount.CounterpartyId = tp.CounterpartyId
    AND execaccount.InternalCode = trd.ExecutionAccount
LEFT JOIN
    trans.[CustodianCodeMapping] custodian ON custodian.FileGenerationTypeId = fgt.FileGenerationTypeId
    AND custodian.PortfolioId = trd.PortfolioId
    AND custodian.InternalCode = trd.Custodian

LEFT JOIN trans.[vwLastFileTransmission] ft ON ft.[TransmissionType] = tp.Mnemonic

WHERE 
    trd.TradeInstrumentType = 'FUT'
    --AND trd.TradeDate = CAST(GETDATE() AS DATE) 
    AND (ft.TransmittedOn IS NULL OR ft.TransmittedOn < trd.BookedOnUtc OR ft.TransmittedOn < trd.CanceledOnUtc OR  ft.TransmittedOn < trd.LastCorrectedOnUtc)

	AND trd.PortfolioId = @PortfolioId
)
SELECT 
    'TR001' AS TrasactionType,
    trd.TradeStatus AS TransactionStatus,
    trd.TradeSide AS [Buy/Sell],
    CASE 
        WHEN trd.TradeSide='S' AND (trd.PositionSide ='L' OR  trd.PositionSide ='C') THEN 'L'
        WHEN trd.TradeSide='S' AND trd.PositionSide ='S' THEN 'S'
        WHEN trd.TradeSide='B' AND trd.PositionSide ='L' THEN 'L'
        WHEN trd.TradeSide='B' AND (trd.PositionSide ='S' OR  trd.PositionSide ='C') THEN 'C' 
    END AS [Long/Short],
    '' AS [PositionType],
    'A' AS [TransLevel],
    trd.TradeAllocationId AS [ClientRef#],
    CONCAT(trd.TradeId,'A') AS [Associated#],
    trd.ExecutionAccount AS [ExecAccount],
    trd.ClearingAccount AS [AccountId],
    trd.ExecutionDesk AS [ExecutionBroker],
    'B' AS [SecType],
    trd.Symbol AS [SecID],
    trd.[SecurityName] as SecurityDescription,
    FORMAT(trd.TradeDate, 'MM/dd/yyyy') AS TradeDate,
    FORMAT(trd.SettlementDate, 'MM/dd/yyyy') AS SettlementDate,
     trd.SettlementCurrency AS SettlementCurrency,
    '' AS ExchangeCode,
    ABS(trd.Quantity) AS [Quantity],
	  CASE WHEN LEFT(trd.Symbol, 2)= 'JY' AND RIGHT(trd.Symbol, 6) = 'Curncy' THEN trd.GrossAvgPriceLocal/100
	  WHEN LEFT(trd.Symbol, 2)= 'NO' AND RIGHT(trd.Symbol, 6) = 'Curncy' THEN trd.GrossAvgPriceLocal/100
	  WHEN LEFT(trd.Symbol, 2)= 'SE' AND RIGHT(trd.Symbol, 6) = 'Curncy' THEN trd.GrossAvgPriceLocal/100
	  WHEN LEFT(trd.Symbol, 2)= 'RA' AND RIGHT(trd.Symbol, 6) = 'Curncy' THEN trd.GrossAvgPriceLocal/100
	 ELSE trd.GrossAvgPriceLocal END AS PriceAmount,

    'G' AS PriceIndicator,
    CAST(ABS(trd.GrossPrincipalLocal) AS DECIMAL(24,2)) AS Principal,
    CAST(ABS(trd.CommissionAmountLocal) AS DECIMAL(24,2)) AS CommissionAmount,
    'F' AS CommissionIndicator,
    [MiscFeesLocal] AS [Tax/Fees],
    '' AS [Tax2],
    'F' AS [FeeInd],
    '' AS [Interest],
    '' AS [InterestIndicator],
    CAST(ABS(trd.NetPrincipalLocal)AS DECIMAL(24,2))  AS NetAmount,
    'Y' AS [HearsayInd],
    trd.Custodian AS [Custodian],
    '' AS [MoneyManager],
    '' AS [BookId],
    '' AS [DealId],
    '' AS [TaxLotId],
    '' AS [TaxDate],
    '' AS [TaxPrice],
    '' AS [CloseOutMethod],
    '' AS [ExRate],
    '' AS [AcqDate],
    '' AS [Comments]
FROM  
    trades trd
GO
/****** Object:  View [trans].[vwTradesFileInnocapSW]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- select * from [trans].[vwTradesFileInnocapSW]


CREATE VIEW [trans].[vwTradesFileInnocapSW] AS
SELECT 
    'SW002' AS TrasationType,
    trd.TradeStatus AS TransactionStatus,
    trd.BuySellIndicator AS [Buy/Sell],
    CASE
        WHEN trd.BuySellIndicator = 'S' AND (alloc.PositionSide = 'L' OR alloc.PositionSide = 'C') THEN 'L'
        WHEN trd.BuySellIndicator = 'S' AND alloc.PositionSide = 'S' THEN 'S'
        WHEN trd.BuySellIndicator = 'B' AND alloc.PositionSide = 'L' THEN 'L'
        WHEN trd.BuySellIndicator = 'B' AND (alloc.PositionSide = 'S' OR alloc.PositionSide = 'C') THEN 'C'
    END AS [Long/Short],
    '' AS [PositionType],
    'A' AS [TransLevel],
    alloc.TradeAllocationId AS [ClientTradeRefNo],
    CONCAT(trd.TradeId,'A') AS [AssociatedTradeId],
    '038227591' AS [ExecutionAccount],
    '038QLFIP9' AS [Account Id],
    trd.TradeDesk AS [Broker/Couterparty],
    IIF(trd.Sedol IS NULL OR TRIM(trd.Sedol) = '', 'B','S') AS [SecurityIdentifierType],
    IIF(trd.Sedol IS NULL OR TRIM(trd.Sedol) = '',ins.Symbol, trd.Sedol) AS [SecurityIdentifier],
    ins.Name as SecurityDescription,
    FORMAT(trd.TradeDate, 'MM/dd/yyyy') AS TradeDate,  -- FORMAT(trd.TradeDate, 'MM/dd/yyyy') AS TradeDate,
    FORMAT(trd.fnAddBusinessDays(trd.TradeDate,2), 'MM/dd/yyyy') AS SettlementDate, -- TGU 3 to 2
    ISNULL(fs.SettlementCurrency, ISNULL(trd.SettlementCurrency, trd.TradeCurrency)) AS SettlementCurrency,
    '' AS [ExchangeCode],
    ABS(alloc.Quantity) AS [Quantity],
    alloc.Price AS Price,
    'G' AS PriceIndicator,
    CAST(ABS(trd.Principal) AS DECIMAL(24,2)) AS Principal,
    CAST(trd.BrokerCommission AS DECIMAL(24,2)) AS [BrokerCommission],
    'F' AS [BrokerCommissionInd],
    trd.MiscFees AS [MSFees],
    '' AS [NotRequired],
    'F' AS [MSFeesInd],
    '' AS [DivEntitlPercent],
    '' AS Spread,
    CASE 
        WHEN trd.BuySellIndicator = 'S' THEN  CAST(ABS(trd.Principal)-ABS(trd.BrokerCommission) AS DECIMAL(24,2)) 
        WHEN trd.BuySellIndicator = 'B' THEN CAST(ABS(trd.Principal)+ABS(trd.BrokerCommission)AS DECIMAL(24,2))   
    END AS NetAmount,
    'Y' AS [HearsayInd],
    'MSSW' AS [Custodian],
    '' AS [MoneyManager],
    '' AS [BookId],
    '' AS [DealId],
    '' AS [TaxLotId],
    '' AS [TaxDate],
    '' AS [TaxPrice],
    '' AS [CloseOutMethod],
    '' AS [FxRate],
    '' AS [AcquisitionDate],
    '' AS [Comments],
    '' AS [SwapReferenceNo],
    '' AS [BasketId],
    '' AS [PriceCurrency],
    '' AS [ResetIndicator],
    '' AS [SnSReference],
    '' AS [ResearchFee],
    '' AS [ResearchFeeInd],
    '' AS [LEI],
    '' AS [MaturityDate],
    'Equity Vanilla Swaps' AS [ProductType],
    '' AS [Fuut/Part Unwind Ind],
    '' AS [PaymentDate],
    '' AS [DividendAmount],
    '' AS [DividendPayoutDate],
    '' AS [NextResetDate],
    '' AS [ResetPrice],
    '' AS [EquitySpread],
    '' AS [DaycountConvention],
    '' AS [FloatingRate],
    '' AS [RollConvention],
    '' AS [CollateralPledge],
    '' AS [FixingFrequency],
    '' AS [PaymentFrequency]
FROM 
    [trans].[Trade] trd
JOIN 
    [trans].[TradeAllocation] alloc ON alloc.TradeId = trd.TradeId
JOIN 
    [trans].Instrument ins ON ins.InstrumentId = trd.InstrumentId
LEFT JOIN 
    trans.[vwLastFileTransmission] ft ON ft.TransmissionType = 'INNOCAPSW'
LEFT JOIN trd.vwFutureSwap fs on fs.InstrumentId = trd.InstrumentId
WHERE 
    ((ins.InstrumentType = 'EQU' AND trd.IsCfd = 1) 
     OR (trd.InstrumentId IN (SELECT InstrumentId FROM trd.vwFutureSwap)))

	AND (ft.TransmittedOn IS NULL OR ft.TransmittedOn < trd.BookedOn);
GO
/****** Object:  Table [book].[H_CommissionSchedule]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [book].[H_CommissionSchedule](
	[CommissionScheduleId] [int] NOT NULL,
	[InstrumentId] [int] NOT NULL,
	[ExecutionBrokerId] [int] NOT NULL,
	[CounterpartyRoleSetupId] [int] NOT NULL,
	[ExecutionTypeId] [int] NOT NULL,
	[CommissionTypeId] [int] NOT NULL,
	[CommissionValue] [decimal](18, 6) NOT NULL,
	[ValidFrom] [datetime2](7) NOT NULL,
	[ValidTo] [datetime2](7) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_H_CommissionSchedule]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_H_CommissionSchedule] ON [book].[H_CommissionSchedule]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [book].[CommissionSchedule]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [book].[CommissionSchedule](
	[CommissionScheduleId] [int] IDENTITY(1,1) NOT NULL,
	[InstrumentId] [int] NOT NULL,
	[ExecutionBrokerId] [int] NOT NULL,
	[CounterpartyRoleSetupId] [int] NOT NULL,
	[ExecutionTypeId] [int] NOT NULL,
	[CommissionTypeId] [int] NOT NULL,
	[CommissionValue] [decimal](18, 6) NOT NULL,
	[ValidFrom] [datetime2](7) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](7) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_CommissionSchedule] PRIMARY KEY CLUSTERED 
(
	[CommissionScheduleId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_CommissionSchedule] UNIQUE NONCLUSTERED 
(
	[InstrumentId] ASC,
	[ExecutionBrokerId] ASC,
	[CounterpartyRoleSetupId] ASC,
	[ExecutionTypeId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [book].[H_CommissionSchedule])
)
GO
/****** Object:  View [book].[vwCommissionSchedule]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [book].[vwCommissionSchedule] as
SELECT distinct top (10000000)   [CommissionScheduleId]
      ,iif(ins.InstrumentId is null, genfut.Symbol, ins.Symbol)as Symbol
   
      ,execbrk.Code as ExecutionBroker
	  ,clearbrk.Code as ClearingBroker
	  ,pb.Code as PrimeBroker
	  ,custo.Code as Custodian
      ,exectype.Name as ExecutionType
      ,ct.Name as CommissionType
      ,[CommissionValue]

  FROM [book].[CommissionSchedule] cs
  LEFT JOIN [book].Instrument ins on ins.InstrumentId = cs.InstrumentId
  LEFT JOIN [book].Instrument genfut on genfut.GenericFutureId = cs.InstrumentId
  LEFT JOIN  [book].CounterpartyRoleSetup crs on crs.CounterpartyRoleSetupId = cs.CounterpartyRoleSetupId
  LEFT JOIN [book].Counterparty execbrk on execbrk.CounterpartyId = ExecutionBrokerId
  LEFT JOIN [book].Counterparty clearbrk on clearbrk.CounterpartyId = crs.ClearingBrokerId
  LEFT JOIN [book].Counterparty pb on pb.CounterpartyId = crs.PrimeBrokerId
  LEFT JOIN [book].Counterparty custo on custo.CounterpartyId = crs.CustodianId
  LEFT JOIN [book].ExecutionType exectype on exectype.ExecutionTypeId = cs.ExecutionTypeId
  LEFT JOIN [book].CommissionType ct on ct.CommissionTypeId = cs.CommissionTypeId
  order by Symbol

GO
/****** Object:  View [roll].[vwFutureContractRollingPeriod]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





















/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [roll].[vwFutureContractRollingPeriod] as

    SELECT
        FutureContractId,
        Symbol,
        GenericFutureId,

        CASE 
            WHEN DATEPART(WEEKDAY, LEAST([FirstNoticeDate], [LastTradeDate])) = 1 THEN DATEADD(DAY, -9, LEAST([FirstNoticeDate], [LastTradeDate]))
            WHEN DATEPART(WEEKDAY, LEAST([FirstNoticeDate], [LastTradeDate])) = 2 THEN DATEADD(DAY, -10, LEAST([FirstNoticeDate], [LastTradeDate]))
            ELSE DATEADD(DAY, -8, LEAST([FirstNoticeDate], [LastTradeDate]))
        END AS RollingPeriodStart,
		LEAST([FirstNoticeDate], [LastTradeDate]) AS RollingPeriodEnd
    FROM [roll].[FutureContract]
    WHERE LEAST([FirstNoticeDate], [LastTradeDate]) >= GETDATE()



GO
/****** Object:  UserDefinedFunction [trans].[tvTradesFileINNOCAPSW002]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE FUNCTION [trans].[tvTradesFileINNOCAPSW002] (@PortfolioId tinyint)
RETURNS TABLE
AS
RETURN
with trades as (
SELECT  [TradeAllocationId]
      ,[TradeId]
      ,[TradeStatus]
      ,[InstrumentId]
      ,[Symbol]
      ,[TradeSide]
      ,[TradeDate]
      ,[Exchange]
      ,[IsSwap]
      ,[InstrumentType]
      ,[TradeInstrumentType]
      ,[YellowKey]
      ,[ExecutionDesk]
      ,execbroker.CounterpartyCode as [ExecutionBroker]
      ,execaccount.CounterpartyCode as[ExecutionAccount]
      ,[Isin]
      ,[Sedol]
      ,[Cusip]
      ,[SecurityName]
      ,[LocalExchangeSymbol]
      ,trd.[PortfolioId]
      ,[PositionSide]
      ,[Quantity]
      ,[ContractMultiplier]
      ,[NominalQuantity]
      ,[LocalCurrency]
      ,[BaseCurrency]
      ,[SettlementCurrency]
      ,[CommissionValue]
      ,[CommissionType]
      ,[GrossAvgPriceLocal]
      ,[PriceCommissionLocal]
      ,[NetAvgPriceLocal]
      ,[GrossAvgPriceBase]
      ,[PriceCommissionBase]
      ,[NetAvgPriceBase]
      ,[GrossAvgPriceSettle]
      ,[PriceCommissionSettle]
      ,[NetAvgPriceSettle]
      ,[CommissionAmountLocal]
      ,[CommissionAmountBase]
      ,[CommissionAmountSettle]
      ,[MiscFeesLocal]
      ,[MiscFeesBase]
      ,[MiscFeesSettle]
      ,[GrossTradeValueLocal]
      ,[NetTradeValueLocal]
      ,[GrossTradeValueBase]
      ,[NetTradeValueBase]
      ,[GrossTradeValueSettle]
      ,[NetTradeValueSettle]
      ,[GrossPrincipalLocal]
      ,[NetPrincipalLocal]
      ,[GrossPrincipalBase]
      ,[NetPrincipalBase]
      ,[GrossPrincipalSettle]
      ,[NetPrincipalSettle]
      ,[SettlementDate]
      ,[LocalToBaseFxRate]
      ,[LocalToSettleFxRate]
      ,[PrimeBroker]
      ,clearingbroker.CounterpartyCode as [ClearingBroker]
      ,clearingaccount.CounterpartyCode as [ClearingAccount]
      ,custodian.CounterpartyCode as [Custodian]
      ,[EmsxOrderId]
      ,[OrderReferenceId]
      ,[BlockOrderQuantity]
      ,[OrderAllocationQuantity]
      ,[OrderAllocationNominalQuantity]
      ,[ExecutionType]
      ,[Notes]
      ,[TraderName]
      ,[TraderUuid]
      ,[LastCorrectedOnUtc]
      ,[CanceledOnUtc]
      ,[BookedOnUtc]

  FROM [trans].[BookedTradeAllocation] trd
  JOIN
    trans.FileGenerationType fgt ON fgt.mnemonic = 'INNOCAPSW002'
JOIN
    trans.FileGenerationProfile fgp ON fgp.FileGenerationTypeId = fgt.FileGenerationTypeId
    AND fgp.PortfolioId = trd.PortfolioId
JOIN
    trans.TransmissionProfile tp ON tp.TransmissionProfileId = fgp.TransmissionProfileId
LEFT JOIN
    trans.[ClearingBrokerCodeMapping] clearingbroker ON clearingbroker.FileGenerationTypeId = fgt.FileGenerationTypeId
    AND clearingbroker.InternalCode = trd.ClearingBroker
LEFT JOIN
    trans.[ClearingAccountCodeMapping] clearingaccount ON clearingaccount.CounterpartyId = tp.CounterpartyId
    AND clearingaccount.InternalCode = trd.ClearingAccount
LEFT JOIN
    trans.[ExecutionBrokerCodeMapping] execbroker ON execbroker.FileGenerationTypeId = fgt.FileGenerationTypeId
    AND execbroker.InternalCode = trd.ExecutionBroker
LEFT JOIN
    trans.[ExecutionAccountCodeMapping] execaccount ON execaccount.CounterpartyId = tp.CounterpartyId
    AND execaccount.InternalCode = trd.ExecutionAccount
LEFT JOIN
    trans.[CustodianCodeMapping] custodian ON custodian.FileGenerationTypeId = fgt.FileGenerationTypeId
    AND custodian.PortfolioId = trd.PortfolioId
    AND custodian.InternalCode = trd.Custodian

LEFT JOIN trans.[vwLastFileTransmission] ft ON ft.[TransmissionType] = tp.Mnemonic

WHERE 
 trd.IsSwap = 1

    AND (ft.TransmittedOn IS NULL OR ft.TransmittedOn < trd.BookedOnUtc OR ft.TransmittedOn < trd.CanceledOnUtc OR  ft.TransmittedOn < trd.LastCorrectedOnUtc)
	AND trd.PortfolioId = @PortfolioId
)
SELECT 
    'SW002' AS TrasationType,
    trd.TradeStatus AS TransactionStatus,
    trd.TradeSide AS [Buy/Sell],
    CASE
        WHEN trd.TradeSide = 'S' AND (trd.PositionSide = 'L' OR trd.PositionSide = 'C') THEN 'L'
        WHEN trd.TradeSide = 'S' AND trd.PositionSide = 'S' THEN 'S'
        WHEN trd.TradeSide = 'B' AND trd.PositionSide = 'L' THEN 'L'
        WHEN trd.TradeSide = 'B' AND (trd.PositionSide = 'S' OR trd.PositionSide = 'C') THEN 'C'
    END AS [Long/Short],
    '' AS [PositionType],
    'A' AS [TransLevel],
    trd.TradeAllocationId AS [ClientTradeRefNo],
    CONCAT(trd.TradeId,'A') AS [AssociatedTradeId],
    trd.ExecutionAccount AS [ExecutionAccount],
    trd.ClearingAccount AS [Account Id],
    trd.ExecutionDesk AS [Broker/Couterparty],
    IIF(trd.Sedol IS NULL OR TRIM(trd.Sedol) = '', 'B','S') AS [SecurityIdentifierType],
    IIF(trd.Sedol IS NULL OR TRIM(trd.Sedol) = '',trd.Symbol, trd.Sedol) AS [SecurityIdentifier],
    trd.SecurityName as SecurityDescription,
    FORMAT(trd.TradeDate, 'MM/dd/yyyy') AS TradeDate,  -- FORMAT(trd.TradeDate, 'MM/dd/yyyy') AS TradeDate,
    FORMAT(trd.SettlementDate, 'MM/dd/yyyy') AS SettlementDate, -- TGU 3 to 2
    trd.SettlementCurrency AS SettlementCurrency,
    '' AS [ExchangeCode],
    ABS(trd.Quantity) AS [Quantity],
    trd.GrossAvgPriceLocal AS Price,
    'G' AS PriceIndicator,
    CAST(ABS(trd.GrossPrincipalLocal) AS DECIMAL(24,2)) AS Principal,
    CAST(trd.CommissionAmountLocal AS DECIMAL(24,2)) AS [BrokerCommission],
    'F' AS [BrokerCommissionInd],
    ABS(trd.[MiscFeesLocal]) AS [MSFees],
    '' AS [NotRequired],
    'F' AS [MSFeesInd],
    '' AS [DivEntitlPercent],
    '' AS Spread,
    CAST(ABS(trd.NetPrincipalLocal)AS DECIMAL(24,2)) as NetAmount,
    'Y' AS [HearsayInd],
    trd.Custodian AS [Custodian],
    '' AS [MoneyManager],
    '' AS [BookId],
    '' AS [DealId],
    '' AS [TaxLotId],
    '' AS [TaxDate],
    '' AS [TaxPrice],
    '' AS [CloseOutMethod],
    '' AS [FxRate],
    '' AS [AcquisitionDate],
    '' AS [Comments],
    '' AS [SwapReferenceNo],
    '' AS [BasketId],
    '' AS [PriceCurrency],
    '' AS [ResetIndicator],
    '' AS [SnSReference],
    '' AS [ResearchFee],
    '' AS [ResearchFeeInd],
    '' AS [LEI],
    '' AS [MaturityDate],
    'Equity Vanilla Swaps' AS [ProductType],
    '' AS [Fuut/Part Unwind Ind],
    '' AS [PaymentDate],
    '' AS [DividendAmount],
    '' AS [DividendPayoutDate],
    '' AS [NextResetDate],
    '' AS [ResetPrice],
    '' AS [EquitySpread],
    '' AS [DaycountConvention],
    '' AS [FloatingRate],
    '' AS [RollConvention],
    '' AS [CollateralPledge],
    '' AS [FixingFrequency],
    '' AS [PaymentFrequency]
FROM 
    trades trd

GO
/****** Object:  Table [trans].[H_ExecutionBrokerMapping]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[H_ExecutionBrokerMapping](
	[TradeDesk] [nvarchar](20) NOT NULL,
	[ExecutionBroker] [nvarchar](20) NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_H_ExecutionBrokerMapping]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_H_ExecutionBrokerMapping] ON [trans].[H_ExecutionBrokerMapping]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [trans].[ExecutionBrokerMapping]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[ExecutionBrokerMapping](
	[TradeDesk] [nvarchar](20) NOT NULL,
	[ExecutionBroker] [nvarchar](20) NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_ExecutionBrokerMapping] PRIMARY KEY CLUSTERED 
(
	[TradeDesk] ASC,
	[ExecutionBroker] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [trans].[H_ExecutionBrokerMapping])
)
GO
/****** Object:  View [roll].[vwFutureContractVolumeRank]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





















/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [roll].[vwFutureContractVolumeRank] as
with volumerank as(    SELECT 
        GenericFutureId,
        FutureContractId, 
        Volume,
		Symbol,	
        ROW_NUMBER() OVER(PARTITION BY GenericFutureId ORDER BY Volume DESC) AS VolumeRank
    FROM [roll].[FutureContract]

	)
		select top(100000)  GenericFutureId,
        FutureContractId,       
		Symbol,
		Volume,
		VolumeRank from volumerank
	order by GenericFutureId,VolumeRank asc


GO
/****** Object:  Table [ord].[OrderStatus_H]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[OrderStatus_H](
	[OrderStatusId] [int] NOT NULL,
	[Mnemonic] [nvarchar](10) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_OrderStatus_H]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_OrderStatus_H] ON [ord].[OrderStatus_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [ord].[OrderStatus]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[OrderStatus](
	[OrderStatusId] [int] IDENTITY(1,1) NOT NULL,
	[Mnemonic] [nvarchar](10) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_OrderStatus] PRIMARY KEY CLUSTERED 
(
	[OrderStatusId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [ord].[OrderStatus_H])
)
GO
/****** Object:  View [trans].[vwTradesFileInnocapTR]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







CREATE VIEW [trans].[vwTradesFileInnocapTR] AS
SELECT 
    'TR001' AS TrasactionType,
    trd.TradeStatus AS TransactionStatus,
    trd.BuySellIndicator AS [Buy/Sell],
    CASE 
        WHEN trd.BuySellIndicator='S' AND (alloc.PositionSide ='L' OR  alloc.PositionSide ='C') THEN 'L'
        WHEN trd.BuySellIndicator='S' AND alloc.PositionSide ='S' THEN 'S'
        WHEN trd.BuySellIndicator='B' AND alloc.PositionSide ='L' THEN 'L'
        WHEN trd.BuySellIndicator='B' AND (alloc.PositionSide ='S' OR  alloc.PositionSide ='C') THEN 'C' 
    END AS [Long/Short],
    '' AS [PositionType],
    'A' AS [TransLevel],
    alloc.TradeAllocationId AS [ClientRef#],
    CONCAT(trd.TradeId,'A') AS [Associated#],
    '038227591' AS [ExecAccount],
    '038QLFIP9' AS [AccountId],
    trd.TradeDesk AS [ExecutionBroker],
    'B' AS [SecType],
    ins.Symbol AS [SecID],
    ins.[Name] as SecurityDescription,
    FORMAT(trd.TradeDate, 'MM/dd/yyyy') AS TradeDate,
    FORMAT(trd.fnAddBusinessDays(trd.TradeDate,1), 'MM/dd/yyyy') AS SettlementDate,
    ISNULL( trd.SettlementCurrency, trd.TradeCurrency) AS SettlementCurrency,
    '' AS ExchangeCode,
    ABS(alloc.Quantity) AS [Quantity],
	  CASE WHEN LEFT(ins.Symbol, 2)= 'JY' AND RIGHT(ins.Symbol, 6) = 'Curncy' THEN alloc.Price/100
	  WHEN LEFT(ins.Symbol, 2)= 'NO' AND RIGHT(ins.Symbol, 6) = 'Curncy' THEN alloc.Price/100
	  WHEN LEFT(ins.Symbol, 2)= 'SE' AND RIGHT(ins.Symbol, 6) = 'Curncy' THEN alloc.Price/100
	  WHEN LEFT(ins.Symbol, 2)= 'RA' AND RIGHT(ins.Symbol, 6) = 'Curncy' THEN alloc.Price/100
	 ELSE alloc.Price END AS PriceAmount,
    'G' AS PriceIndicator,
    CAST(ABS(trd.Principal) AS DECIMAL(24,2)) AS Principal,
    CAST(ABS(trd.BrokerCommission) AS DECIMAL(24,2)) AS CommissionAmount,
    'F' AS CommissionIndicator,
    ABS(ISNULL(trd.MiscFees,0)) AS [Tax/Fees],
    '' AS [Tax2],
    'F' AS [FeeInd],
    '' AS [Interest],
    '' AS [InterestIndicator],
    CASE 
        WHEN trd.BuySellIndicator = 'S' THEN CAST(ABS(trd.Principal)- ABS(trd.BrokerCommission) AS DECIMAL(24,2))
        WHEN trd.BuySellIndicator = 'B' THEN CAST(ABS(trd.Principal)+ ABS(trd.BrokerCommission) AS DECIMAL(24,2))
    END AS NetAmount,
    'Y' AS [HearsayInd],
    'MSCO' AS [Custodian],
    '' AS [MoneyManager],
    '' AS [BookId],
    '' AS [DealId],
    '' AS [TaxLotId],
    '' AS [TaxDate],
    '' AS [TaxPrice],
    '' AS [CloseOutMethod],
    '' AS [ExRate],
    '' AS [AcqDate],
    '' AS [Comments]
FROM  
    [trans].[Trade] trd
JOIN 
    [trans].[TradeAllocation] alloc ON alloc.TradeId = trd.TradeId
JOIN 
    [trans].Instrument ins ON ins.InstrumentId = trd.InstrumentId
LEFT JOIN 
    trans.[vwLastFileTransmission] ft ON ft.TransmissionType = 'INNOCAPTR'
WHERE 
    ins.InstrumentType = 'FUT'
  --  AND trd.TradeDate = CAST(GETDATE() AS DATE) 
    AND trd.InstrumentId NOT IN (SELECT InstrumentId FROM trd.vwFutureSwap)
    AND (ft.TransmittedOn IS NULL OR ft.TransmittedOn < trd.BookedOn);
GO
/****** Object:  Table [book].[H_TradeInstrumentType]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [book].[H_TradeInstrumentType](
	[TradeInstrumentTypeId] [int] NOT NULL,
	[Mnemonic] [nvarchar](8) NOT NULL,
	[IsSwap] [bit] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[InstrumentType] [nvarchar](10) NOT NULL,
	[ValidFrom] [datetime2](7) NOT NULL,
	[ValidTo] [datetime2](7) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_H_TradeInstrumentType]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_H_TradeInstrumentType] ON [book].[H_TradeInstrumentType]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [book].[TradeInstrumentType]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [book].[TradeInstrumentType](
	[TradeInstrumentTypeId] [int] NOT NULL,
	[Mnemonic] [nvarchar](8) NOT NULL,
	[IsSwap] [bit] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[InstrumentType] [nvarchar](10) NOT NULL,
	[ValidFrom] [datetime2](7) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](7) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_TradeInstrumentType] PRIMARY KEY CLUSTERED 
(
	[TradeInstrumentTypeId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_InstrumentTypeIsSwap] UNIQUE NONCLUSTERED 
(
	[IsSwap] ASC,
	[InstrumentType] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_TradeInstrumentTypeMnemonic] UNIQUE NONCLUSTERED 
(
	[Mnemonic] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [book].[H_TradeInstrumentType])
)
GO
/****** Object:  Table [roll].[FutureCurrentContract_H]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [roll].[FutureCurrentContract_H](
	[GenericFutureId] [int] NOT NULL,
	[FutureContractId] [int] NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_FutureCurrentContract_H]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_FutureCurrentContract_H] ON [roll].[FutureCurrentContract_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [roll].[FutureCurrentContract]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [roll].[FutureCurrentContract](
	[GenericFutureId] [int] NOT NULL,
	[FutureContractId] [int] NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_GenericFutureId] PRIMARY KEY CLUSTERED 
(
	[GenericFutureId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [roll].[FutureCurrentContract_H])
)
GO
/****** Object:  UserDefinedFunction [trans].[tvTradesFileJPMSWAP]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE FUNCTION [trans].[tvTradesFileJPMSWAP] (@PortfolioId tinyint)
RETURNS TABLE
AS
RETURN
with trades as (
SELECT  [TradeAllocationId]
      ,[TradeId]
      ,[TradeStatus]
      ,[InstrumentId]
      ,[Symbol]
      ,[TradeSide]
      ,[TradeDate]
      ,[Exchange]
      ,[IsSwap]
      ,[InstrumentType]
      ,[TradeInstrumentType]
      ,[YellowKey]
      ,[ExecutionDesk]
      ,execbroker.CounterpartyCode as [ExecutionBroker]
      ,execaccount.CounterpartyCode as[ExecutionAccount]
      ,[Isin]
      ,[Sedol]
      ,[Cusip]
      ,[SecurityName]
      ,[LocalExchangeSymbol]
      ,trd.[PortfolioId]
      ,[PositionSide]
      ,[Quantity]
      ,[ContractMultiplier]
      ,[NominalQuantity]
      ,[LocalCurrency]
      ,[BaseCurrency]
      ,[SettlementCurrency]
      ,[CommissionValue]
      ,[CommissionType]
      ,[GrossAvgPriceLocal]
      ,[PriceCommissionLocal]
      ,[NetAvgPriceLocal]
      ,[GrossAvgPriceBase]
      ,[PriceCommissionBase]
      ,[NetAvgPriceBase]
      ,[GrossAvgPriceSettle]
      ,[PriceCommissionSettle]
      ,[NetAvgPriceSettle]
      ,[CommissionAmountLocal]
      ,[CommissionAmountBase]
      ,[CommissionAmountSettle]
      ,[MiscFeesLocal]
      ,[MiscFeesBase]
      ,[MiscFeesSettle]
      ,[GrossTradeValueLocal]
      ,[NetTradeValueLocal]
      ,[GrossTradeValueBase]
      ,[NetTradeValueBase]
      ,[GrossTradeValueSettle]
      ,[NetTradeValueSettle]
      ,[GrossPrincipalLocal]
      ,[NetPrincipalLocal]
      ,[GrossPrincipalBase]
      ,[NetPrincipalBase]
      ,[GrossPrincipalSettle]
      ,[NetPrincipalSettle]
      ,[SettlementDate]
      ,[LocalToBaseFxRate]
      ,[LocalToSettleFxRate]
      ,[PrimeBroker]
      ,clearingbroker.CounterpartyCode as [ClearingBroker]
      ,clearingaccount.CounterpartyCode as [ClearingAccount]
      ,custodian.CounterpartyCode as [Custodian]
      ,[EmsxOrderId]
      ,[OrderReferenceId]
      ,[BlockOrderQuantity]
      ,[OrderAllocationQuantity]
      ,[OrderAllocationNominalQuantity]
      ,[ExecutionType]
      ,[Notes]
      ,[TraderName]
      ,[TraderUuid]
      ,[LastCorrectedOnUtc]
      ,[CanceledOnUtc]
      ,[BookedOnUtc]

  FROM [trans].[BookedTradeAllocation] trd
  JOIN
    trans.FileGenerationType fgt ON fgt.mnemonic = 'JPMSWAP'
JOIN
    trans.FileGenerationProfile fgp ON fgp.FileGenerationTypeId = fgt.FileGenerationTypeId
    AND fgp.PortfolioId = trd.PortfolioId
JOIN
    trans.TransmissionProfile tp ON tp.TransmissionProfileId = fgp.TransmissionProfileId
LEFT JOIN
    trans.[ClearingBrokerCodeMapping] clearingbroker ON clearingbroker.FileGenerationTypeId = fgt.FileGenerationTypeId
    AND clearingbroker.InternalCode = trd.ClearingBroker
LEFT JOIN
    trans.[ClearingAccountCodeMapping] clearingaccount ON clearingaccount.CounterpartyId = tp.CounterpartyId
    AND clearingaccount.InternalCode = trd.ClearingAccount
LEFT JOIN
    trans.[ExecutionBrokerCodeMapping] execbroker ON execbroker.FileGenerationTypeId = fgt.FileGenerationTypeId
    AND execbroker.InternalCode = trd.ExecutionBroker
LEFT JOIN
    trans.[ExecutionAccountCodeMapping] execaccount ON execaccount.CounterpartyId = tp.CounterpartyId
    AND execaccount.InternalCode = trd.ExecutionAccount
LEFT JOIN
    trans.[CustodianCodeMapping] custodian ON custodian.FileGenerationTypeId = fgt.FileGenerationTypeId
    AND custodian.PortfolioId = trd.PortfolioId
    AND custodian.InternalCode = trd.Custodian

LEFT JOIN trans.[vwLastFileTransmission] ft ON ft.[TransmissionType] = tp.Mnemonic

WHERE 
 trd.IsSwap = 1
	AND trd.PrimeBroker = 'JP'--That is not correct, we can exec with one broker and pb another.
 --   AND trd.TradeDate = CAST(GETDATE() AS DATE) 
    AND (ft.TransmittedOn IS NULL OR ft.TransmittedOn < trd.BookedOnUtc OR ft.TransmittedOn < trd.CanceledOnUtc OR  ft.TransmittedOn < trd.LastCorrectedOnUtc)
	AND trd.PortfolioId = @PortfolioId
)
SELECT  
trd.TradeAllocationId as TradeId,
  trd.TradeStatus AS [ACTION],
  FORMAT(trd.[TradeDate], 'yyyy/MM/dd') AS [TRADE_DATE],
  FORMAT(trd.SettlementDate, 'yyyy/MM/dd') AS [SETTLEMENT_DATE],
    '317-55516' as [ACCOUNT], --  trd.ClearingAccount AS [Account],

    'SWAP' AS [METHOD],
	 trd.TradeSide  as [SIDE],

	trd.Symbol as [SECURITY],
	'B' as [SEC_ID],
		ABS(Quantity) AS [QUANTITY],
	   ROUND(trd.GrossAvgPriceSettle, 4) AS [PRICE],
	   --'PERQTY' as [COMM_TYPE],
    --CAST(trd.BrokerCommission AS DECIMAL(24,2)) AS [COMM],
	'JPM' as [EXEC_BRK], --trd.ExecutionBroker as [EXEC_BRK],
	trd.SettlementCurrency AS [CURRENCY],
	trd.LocalToSettleFxRate as [EXCHG RATE],
	'6ZK_'+trd.SettlementCurrency as [PORTFOLIO_SWAP]
  
FROM trades trd
GO
/****** Object:  View [trans].[vwTradesFileInnocapFX]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [trans].[vwTradesFileInnocapFX] as
SELECT 
    'FX002' AS TrasationType,
    trd.TradeStatus AS TransactionStatus,
    'A' AS [TransLevel],
    'FORWARD' AS [InstrumentType],
    alloc.TradeAllocationId AS [ClientTradeRef],
    CONCAT(trd.TradeId,'A') AS [AssociatedTradeId],    
    '038227591' AS [ExecAccount],
    '038QLFIP9' AS [AccountId],
    trd.TradeDesk AS [ExecutionBroker],
    FORMAT(trd.TradeDate, 'MM/dd/yyyy') AS TradeDate,
    FORMAT(ins.MaturityDate, 'MM/dd/yyyy') AS ValueDate,
    ABS(CAST(IIF(trd.FxCurrency1Amount > 0, trd.FxCurrency1Amount, trd.FxCurrency2Amount) AS DECIMAL(24,2))) AS BuyQuantity,
    ABS(CAST(IIF(trd.FxCurrency1Amount < 0, trd.FxCurrency1Amount, trd.FxCurrency2Amount) AS DECIMAL(24,2))) AS SellQuantity,
    IIF(trd.FxCurrency1Amount > 0, trd.FxCurrency1, trd.FxCurrency2) AS BuyCcy,
    IIF(trd.FxCurrency1Amount < 0, trd.FxCurrency1, trd.FxCurrency2) AS SellCcy,
    '' AS DealtCcy,
    ABS(trd.FxCurrency1Amount) / ABS(trd.FxCurrency2Amount) AS Rate,
    '' AS NdfFlag,
    '' AS NdfFixingDate,
    '' AS NdfLinkedTrade,
    'MSCO' AS PB,
    '' AS FarValueDate,
    '' AS FarValueRate,
    '' AS ClientBaseEquivalent,
    'S' AS HedgeOrSpeculative,
    '' AS TaxIndicator,
    'Y' AS HeasayInd,
    'MSCO' AS Custodian,
    '' AS MoneyManager,
    '' AS DealId,
    '' AS AcquisitionDate,
    '' AS Comments,
    '' AS TradeType,
    '' AS Reporter
FROM 
    [trans].[Trade] trd
JOIN 
    [trans].[TradeAllocation] alloc ON alloc.TradeId = trd.TradeId
JOIN 
    [trans].Instrument ins ON ins.InstrumentId = trd.InstrumentId
LEFT JOIN 
    trans.[vwLastFileTransmission] ft ON ft.TransmissionType = 'INNOCAPFX'
WHERE 
    ins.InstrumentType ='FXFWD'  
    AND trd.TradeDate = CAST(GETDATE() as date)
    AND (ft.TransmittedOn IS NULL OR ft.TransmittedOn < trd.BookedOn);
GO
/****** Object:  UserDefinedFunction [trans].[tvTradesFileGSPBFUT]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [trans].[tvTradesFileGSPBFUT] (@PortfolioId tinyint)
RETURNS TABLE
AS
RETURN
with trades as (
SELECT  [TradeAllocationId]
      ,[TradeId]
      ,[TradeStatus]
      ,[InstrumentId]
      ,[Symbol]
      ,[TradeSide]
      ,[TradeDate]
      ,[Exchange]
      ,[IsSwap]
      ,[InstrumentType]
      ,[TradeInstrumentType]
      ,[YellowKey]
      ,[ExecutionDesk]
      ,execbroker.CounterpartyCode as [ExecutionBroker]
      ,execaccount.CounterpartyCode as[ExecutionAccount]
      ,[Isin]
      ,[Sedol]
      ,[Cusip]
      ,[SecurityName]
      ,[LocalExchangeSymbol]
      ,trd.[PortfolioId]
      ,[PositionSide]
      ,[Quantity]
      ,[ContractMultiplier]
      ,[NominalQuantity]
      ,[LocalCurrency]
      ,[BaseCurrency]
      ,[SettlementCurrency]
      ,[CommissionValue]
      ,[CommissionType]
      ,[GrossAvgPriceLocal]
      ,[PriceCommissionLocal]
      ,[NetAvgPriceLocal]
      ,[GrossAvgPriceBase]
      ,[PriceCommissionBase]
      ,[NetAvgPriceBase]
      ,[GrossAvgPriceSettle]
      ,[PriceCommissionSettle]
      ,[NetAvgPriceSettle]
      ,[CommissionAmountLocal]
      ,[CommissionAmountBase]
      ,[CommissionAmountSettle]
      ,[MiscFeesLocal]
      ,[MiscFeesBase]
      ,[MiscFeesSettle]
      ,[GrossTradeValueLocal]
      ,[NetTradeValueLocal]
      ,[GrossTradeValueBase]
      ,[NetTradeValueBase]
      ,[GrossTradeValueSettle]
      ,[NetTradeValueSettle]
      ,[GrossPrincipalLocal]
      ,[NetPrincipalLocal]
      ,[GrossPrincipalBase]
      ,[NetPrincipalBase]
      ,[GrossPrincipalSettle]
      ,[NetPrincipalSettle]
      ,[SettlementDate]
      ,[LocalToBaseFxRate]
      ,[LocalToSettleFxRate]
      ,[PrimeBroker]
      ,clearingbroker.CounterpartyCode as [ClearingBroker]
      ,clearingaccount.CounterpartyCode as [ClearingAccount]
      ,custodian.CounterpartyCode as [Custodian]
      ,[EmsxOrderId]
      ,[OrderReferenceId]
      ,[BlockOrderQuantity]
      ,[OrderAllocationQuantity]
      ,[OrderAllocationNominalQuantity]
      ,[ExecutionType]
      ,[Notes]
      ,[TraderName]
      ,[TraderUuid]
      ,[LastCorrectedOnUtc]
      ,[CanceledOnUtc]
      ,[BookedOnUtc]

  FROM [trans].[BookedTradeAllocation] trd
  JOIN
    trans.FileGenerationType fgt ON fgt.mnemonic = 'GSPBFUT'
JOIN
    trans.FileGenerationProfile fgp ON fgp.FileGenerationTypeId = fgt.FileGenerationTypeId
    AND fgp.PortfolioId = trd.PortfolioId
JOIN
    trans.TransmissionProfile tp ON tp.TransmissionProfileId = fgp.TransmissionProfileId
LEFT JOIN
    trans.[ClearingBrokerCodeMapping] clearingbroker ON clearingbroker.FileGenerationTypeId = fgt.FileGenerationTypeId
    AND clearingbroker.InternalCode = trd.ClearingBroker
LEFT JOIN
    trans.[ClearingAccountCodeMapping] clearingaccount ON clearingaccount.CounterpartyId = tp.CounterpartyId
    AND clearingaccount.InternalCode = trd.ClearingAccount
LEFT JOIN
    trans.[ExecutionBrokerCodeMapping] execbroker ON execbroker.FileGenerationTypeId = fgt.FileGenerationTypeId
    AND execbroker.InternalCode = trd.ExecutionBroker
LEFT JOIN
    trans.[ExecutionAccountCodeMapping] execaccount ON execaccount.CounterpartyId = tp.CounterpartyId
    AND execaccount.InternalCode = trd.ExecutionAccount
LEFT JOIN
    trans.[CustodianCodeMapping] custodian ON custodian.FileGenerationTypeId = fgt.FileGenerationTypeId
    AND custodian.PortfolioId = trd.PortfolioId
    AND custodian.InternalCode = trd.Custodian

LEFT JOIN trans.[vwLastFileTransmission] ft ON ft.[TransmissionType] = tp.Mnemonic

WHERE 
   trd.TradeInstrumentType = 'FUT'
  	AND trd.PrimeBroker ='GS'
   AND (ft.TransmittedOn IS NULL OR ft.TransmittedOn < trd.BookedOnUtc OR ft.TransmittedOn < trd.CanceledOnUtc OR  ft.TransmittedOn < trd.LastCorrectedOnUtc)
	AND trd.PortfolioId = @PortfolioId

)
SELECT  

'A' as [TYPE],
CONCAT('A',trd.TradeAllocationId) AS [CLIENTREF],
trd.Symbol as [CONTRACT],
ins.FutureContractMonth as [MONTH],
ins.FutureContractYear as [YEAR],
'' as PUTCALL,-- blank for futures
'' as STRIKE,-- blank for futures
trd.TradeSide as BUYSELL,-- blank for futures
trd.Quantity as [QUANTITY],
trd.ClearingAccount as [ACCOUNT],
'' AS [ORDERTYPE],
	ROUND(trd.GrossAvgPriceLocal, 6) AS [Price], 
trd.ExecutionBroker as [EXECBROKER],
trd.ClearingBroker as [CLEARINGBROKER],
'' as [RELATEDID],
'' as [GROUPID],
'' as [SPREADREF],
'' as MEMO, --trd.EmsxSequence as [MEMO],
'FIA-C' as [ELECTRONICEXECUTION],
'BID' as SYMBOLOGYTYPE,
'' as FILLERCOLUMN,
IIF(ins.Exchange = 'LME',FORMAT(ins.MaturityDate, 'yyyyMMdd'),'') as PROMPTDATE,
FORMAT(trd.SettlementDate, 'yyyyMMdd') AS [CLEARINGDATE],
'N' as [CLIENTACTION]
FROM 
    trades trd
	JOIN 
    trans.Instrument ins ON ins.InstrumentId = trd.InstrumentId
GO
/****** Object:  UserDefinedFunction [trans].[tvTradesFileGSPBSYNTH]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE FUNCTION [trans].[tvTradesFileGSPBSYNTH] (@PortfolioId tinyint)
RETURNS TABLE
AS
RETURN
with trades as (
SELECT  [TradeAllocationId]
      ,[TradeId]
      ,[TradeStatus]
      ,[InstrumentId]
      ,[Symbol]
      ,[TradeSide]
      ,[TradeDate]
      ,[Exchange]
      ,[IsSwap]
      ,[InstrumentType]
      ,[TradeInstrumentType]
      ,[YellowKey]
      ,[ExecutionDesk]
      ,execbroker.CounterpartyCode as [ExecutionBroker]
      ,execaccount.CounterpartyCode as[ExecutionAccount]
      ,[Isin]
      ,[Sedol]
      ,[Cusip]
      ,[SecurityName]
      ,[LocalExchangeSymbol]
      ,trd.[PortfolioId]
      ,[PositionSide]
      ,[Quantity]
      ,[ContractMultiplier]
      ,[NominalQuantity]
      ,[LocalCurrency]
      ,[BaseCurrency]
      ,[SettlementCurrency]
      ,[CommissionValue]
      ,[CommissionType]
      ,[GrossAvgPriceLocal]
      ,[PriceCommissionLocal]
      ,[NetAvgPriceLocal]
      ,[GrossAvgPriceBase]
      ,[PriceCommissionBase]
      ,[NetAvgPriceBase]
      ,[GrossAvgPriceSettle]
      ,[PriceCommissionSettle]
      ,[NetAvgPriceSettle]
      ,[CommissionAmountLocal]
      ,[CommissionAmountBase]
      ,[CommissionAmountSettle]
      ,[MiscFeesLocal]
      ,[MiscFeesBase]
      ,[MiscFeesSettle]
      ,[GrossTradeValueLocal]
      ,[NetTradeValueLocal]
      ,[GrossTradeValueBase]
      ,[NetTradeValueBase]
      ,[GrossTradeValueSettle]
      ,[NetTradeValueSettle]
      ,[GrossPrincipalLocal]
      ,[NetPrincipalLocal]
      ,[GrossPrincipalBase]
      ,[NetPrincipalBase]
      ,[GrossPrincipalSettle]
      ,[NetPrincipalSettle]
      ,[SettlementDate]
      ,[LocalToBaseFxRate]
      ,[LocalToSettleFxRate]
      ,[PrimeBroker]
      ,clearingbroker.CounterpartyCode as [ClearingBroker]
      ,clearingaccount.CounterpartyCode as [ClearingAccount]
      ,custodian.CounterpartyCode as [Custodian]
      ,[EmsxOrderId]
      ,[OrderReferenceId]
      ,[BlockOrderQuantity]
      ,[OrderAllocationQuantity]
      ,[OrderAllocationNominalQuantity]
      ,[ExecutionType]
      ,[Notes]
      ,[TraderName]
      ,[TraderUuid]
      ,[LastCorrectedOnUtc]
      ,[CanceledOnUtc]
      ,[BookedOnUtc]

  FROM [trans].[BookedTradeAllocation] trd
  JOIN
    trans.FileGenerationType fgt ON fgt.mnemonic = 'GSPBSYNTH'
JOIN
    trans.FileGenerationProfile fgp ON fgp.FileGenerationTypeId = fgt.FileGenerationTypeId
    AND fgp.PortfolioId = trd.PortfolioId
JOIN
    trans.TransmissionProfile tp ON tp.TransmissionProfileId = fgp.TransmissionProfileId
LEFT JOIN
    trans.[ClearingBrokerCodeMapping] clearingbroker ON clearingbroker.FileGenerationTypeId = fgt.FileGenerationTypeId
    AND clearingbroker.InternalCode = trd.ClearingBroker
LEFT JOIN
    trans.[ClearingAccountCodeMapping] clearingaccount ON clearingaccount.CounterpartyId = tp.CounterpartyId
    AND clearingaccount.InternalCode = trd.ClearingAccount
LEFT JOIN
    trans.[ExecutionBrokerCodeMapping] execbroker ON execbroker.FileGenerationTypeId = fgt.FileGenerationTypeId
    AND execbroker.InternalCode = trd.ExecutionBroker
LEFT JOIN
    trans.[ExecutionAccountCodeMapping] execaccount ON execaccount.CounterpartyId = tp.CounterpartyId
    AND execaccount.InternalCode = trd.ExecutionAccount
LEFT JOIN
    trans.[CustodianCodeMapping] custodian ON custodian.FileGenerationTypeId = fgt.FileGenerationTypeId
    AND custodian.PortfolioId = trd.PortfolioId
    AND custodian.InternalCode = trd.Custodian

LEFT JOIN trans.[vwLastFileTransmission] ft ON ft.[TransmissionType] = tp.Mnemonic

WHERE 
   trd.TradeInstrumentType = 'FUT'
  	AND trd.PrimeBroker ='GS'
   AND (ft.TransmittedOn IS NULL OR ft.TransmittedOn < trd.BookedOnUtc OR ft.TransmittedOn < trd.CanceledOnUtc OR  ft.TransmittedOn < trd.LastCorrectedOnUtc)
	AND trd.PortfolioId = @PortfolioId

)
SELECT  
	CONCAT('A',trd.TradeAllocationId) AS [Order Number],
	trd.TradeStatus as [Cancel correct indicator],
	trd.ClearingAccount as [Account number or acronym],
	TRIM(REPLACE(trd.Symbol,'Equity','')) as [Security Identifier],
	trd.ExecutionBroker as [Broker], -- explain granularity and provide codes
	trd.Custodian as Custodian, --when GSCO or GSCI?
	 --CASE 
  --      WHEN trd.BuySellIndicator = 'S' AND (alloc.PositionSide IN ('L', 'C')) THEN 'S'
  --      WHEN trd.BuySellIndicator = 'S' AND alloc.PositionSide = 'S' THEN 'SS'
  --      WHEN trd.BuySellIndicator = 'B' AND alloc.PositionSide = 'L' THEN 'B'
  --      WHEN trd.BuySellIndicator = 'B' AND (alloc.PositionSide IN ('S', 'C')) THEN 'BC'
  --  END AS [Transaction type],
   trd.TradeSide AS [Transaction type],
	trd.SettlementCurrency AS [Currency Code],-- how to determine settlement currency?
	FORMAT(trd.[TradeDate], 'MM/dd/yyyy') AS [Trade Date],
	FORMAT(trd.SettlementDate, 'MM/dd/yyyy') AS [Settlement Date],-- how to determine settlement date?
	trd.Quantity as [Quantity],
    CAST(trd.CommissionAmountLocal AS DECIMAL(24,2)) AS [Commission],
	ROUND(trd.GrossAvgPriceLocal, 6) AS [Price], 
	'' as [Accrued Interest],--Optional
	'' as [Trade tax],
	'' as [Misc Money],
	CAST(ABS(trd.NetPrincipalLocal) AS DECIMAL(24,2)) AS [Net Amount],
	CAST(ABS(GrossPrincipalLocal) AS DECIMAL(24,2)) AS [Principal],
	'' as [Description], --not used
	'CFD' as [Security Type], --explain here what about futures that are not swap or CFD? when to use CFD over swap
	'' as [Coutry Settlement Code],
	'' as [Clearing Agent], -- GS can provide list if required
	'' as [SEC Fees], -- leave blacnk GS will calculate
	'' as [Option underlyer],
	'' as [Option expiry date],
	'' as [Option cal put indicator],
	'' as [Option strike price],
	'' as [Trailer],
	'' as [Trailer 1],
	'' as [Trailer 2],
	'' as [Trailer 3],
	'' as [Trailer 4]   
FROM 
    trades trd
GO
/****** Object:  View [roll].[vwFutureContractRollInfo2]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO























/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [roll].[vwFutureContractRollInfo2] as
WITH RollingPeriod AS (
    SELECT
        FutureContractId,
        Symbol,
        GenericFutureId,
        Volume,
        -- Calculate RollingPeriodStart based on the day of the week
        CASE 
            WHEN DATEPART(WEEKDAY, LEAST([FirstNoticeDate], [LastTradeDate])) = 1 THEN DATEADD(DAY, -9, LEAST([FirstNoticeDate], [LastTradeDate]))
            WHEN DATEPART(WEEKDAY, LEAST([FirstNoticeDate], [LastTradeDate])) = 2 THEN DATEADD(DAY, -10, LEAST([FirstNoticeDate], [LastTradeDate]))
            ELSE DATEADD(DAY, -8, LEAST([FirstNoticeDate], [LastTradeDate]))
        END AS RollingPeriodStart,
        LEAST([FirstNoticeDate], [LastTradeDate]) AS RollingPeriodEnd
    FROM [roll].[FutureContract]
    WHERE LEAST([FirstNoticeDate], [LastTradeDate]) >= GETDATE()
),
-- CTE for ranking volume within each GenericFutureId
VolumeRank AS (
    SELECT 
        GenericFutureId,
        FutureContractId, 
        Volume,
        Symbol,
        -- Rank futures within the same GenericFutureId by Volume and RollingPeriodEnd
        ROW_NUMBER() OVER(PARTITION BY GenericFutureId ORDER BY Volume DESC, RollingPeriodEnd) AS VolumeRank,
        RollingPeriodStart,
        RollingPeriodEnd,
		DATEDIFF(DAY, GETDATE(), RollingPeriodStart) as DayToFirstRollingDate,
		DATEDIFF(DAY, GETDATE(), RollingPeriodEnd) as DayToLastRollingDate,
        CASE 
            WHEN GETDATE() BETWEEN RollingPeriodStart AND RollingPeriodEnd THEN 1
            ELSE 0
        END AS IsRollingPeriod
    FROM RollingPeriod
    WHERE GETDATE() < RollingPeriodStart
)
-- Select from the VolumeRank CTE
SELECT TOP (100000) *
FROM VolumeRank
ORDER BY Symbol



GO
/****** Object:  View [trans].[vwCMGLFND_TradesFile_GS_Synth_TEST]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO












CREATE VIEW [trans].[vwCMGLFND_TradesFile_GS_Synth_TEST] AS
SELECT  
	CONCAT('A',alloc.TradeAllocationId) AS [Order Number],
	'N' as [Cancel correct indicator],
	'069937001' as [Account number or acronym],
	TRIM(REPLACE(ins.Symbol,'Equity','')) as [Security Identifier],
	'GS' as [Broker], -- explain granularity and provide codes
	'GSI' as Custodian, --when GSCO or GSCI?
	 --CASE 
  --      WHEN trd.BuySellIndicator = 'S' AND (alloc.PositionSide IN ('L', 'C')) THEN 'S'
  --      WHEN trd.BuySellIndicator = 'S' AND alloc.PositionSide = 'S' THEN 'SS'
  --      WHEN trd.BuySellIndicator = 'B' AND alloc.PositionSide = 'L' THEN 'B'
  --      WHEN trd.BuySellIndicator = 'B' AND (alloc.PositionSide IN ('S', 'C')) THEN 'BC'
  --  END AS [Transaction type],
   trd.BuySellIndicator AS [Transaction type],
	ISNULL(trd.SettlementCurrency, trd.TradeCurrency) AS [Currency Code],-- how to determine settlement currency?
	FORMAT(trd.[TradeDate], 'MM/dd/yyyy') AS [Trade Date],
	FORMAT(trd.fnAddBusinessDays(trd.TradeDate,IIF(ins.Symbol like '%Equity', 2,2)), 'MM/dd/yyyy') AS [Settlement Date],-- how to determine settlement date?
	trd.FilledQuantity as [Quantity],
    CAST(trd.BrokerCommission AS DECIMAL(24,2)) AS [Commission],
	ROUND(trd.AvgPrice, 6) AS [Price], 
	'' as [Accrued Interest],--Optional
	'' as [Trade tax],
	'' as [Misc Money],
	CAST(ABS(trd.NetAmount) AS DECIMAL(24,2)) AS [Net Amount],
	CAST(ABS(Principal) AS DECIMAL(24,2)) AS [Principal],
	'' as [Description], --not used
	'CFD' as [Security Type], --explain here what about futures that are not swap or CFD? when to use CFD over swap
	'' as [Coutry Settlement Code],
	'' as [Clearing Agent], -- GS can provide list if required
	'' as [SEC Fees], -- leave blacnk GS will calculate
	'' as [Option underlyer],
	'' as [Option expiry date],
	'' as [Option cal put indicator],
	'' as [Option strike price],
	'' as [Trailer],
	'' as [Trailer 1],
	'' as [Trailer 2],
	'' as [Trailer 3],
	'' as [Trailer 4]   
FROM 
    [Trading].[trd].[Trade] trd
JOIN 
    trans.TradeAllocation alloc ON alloc.TradeId = trd.TradeId
JOIN 
    trans.Instrument ins ON ins.InstrumentId = trd.InstrumentId
LEFT JOIN 
    trans.[vwLastFileTransmission] ft ON ft.TransmissionType = 'GSSYNTEST'
WHERE 
     (
       ( ins.InstrumentType = 'EQU' AND trd.IsCfd = 1) 
        OR ins.InstrumentId IN (SELECT InstrumentId FROM trd.vwFutureSwap)
    )
    AND trd.TradeDate = DATEADD(day,-4, CAST(GETDATE() AS DATE)) 

    AND (ft.TransmittedOn IS NULL OR ft.TransmittedOn < trd.BookedOn);
GO
/****** Object:  Table [pos].[Position_H]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [pos].[Position_H](
	[PortfolioId] [tinyint] NOT NULL,
	[PositionDate] [date] NOT NULL,
	[Quantity] [int] NOT NULL,
	[NominalQuantity] [decimal](18, 6) NOT NULL,
	[InstrumentId] [int] NOT NULL,
	[LocalCurrency] [char](3) NOT NULL,
	[BaseCurrency] [char](3) NOT NULL,
	[GrossEntryPriceLocal] [decimal](18, 6) NOT NULL,
	[GrossEntryPriceBase] [decimal](18, 6) NOT NULL,
	[NetEntryPriceLocal] [decimal](18, 6) NOT NULL,
	[NetEntryPriceBase] [decimal](18, 6) NOT NULL,
	[GrossTradeValueLocal] [decimal](18, 6) NOT NULL,
	[GrossTradeValueBase] [decimal](18, 6) NOT NULL,
	[NetTradeValueLocal] [decimal](18, 6) NOT NULL,
	[NetTradeValueBase] [decimal](18, 6) NOT NULL,
	[GrossNotionalValueLocal] [decimal](18, 6) NOT NULL,
	[GrossNotionalValueBase] [decimal](18, 6) NOT NULL,
	[NetNotionalValueLocal] [decimal](18, 6) NOT NULL,
	[NetNotionalValueBase] [decimal](18, 6) NOT NULL,
	[TotalCommissionLocal] [decimal](18, 6) NOT NULL,
	[TotalCommissionBase] [decimal](18, 6) NOT NULL,
	[IsSwap] [bit] NOT NULL,
	[FirstTradeDate] [date] NOT NULL,
	[LastTradeDate] [date] NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_Position_H]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_Position_H] ON [pos].[Position_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [pos].[Position]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [pos].[Position](
	[PortfolioId] [tinyint] NOT NULL,
	[PositionDate] [date] NOT NULL,
	[Quantity] [int] NOT NULL,
	[NominalQuantity] [decimal](18, 6) NOT NULL,
	[InstrumentId] [int] NOT NULL,
	[LocalCurrency] [char](3) NOT NULL,
	[BaseCurrency] [char](3) NOT NULL,
	[GrossEntryPriceLocal] [decimal](18, 6) NOT NULL,
	[GrossEntryPriceBase] [decimal](18, 6) NOT NULL,
	[NetEntryPriceLocal] [decimal](18, 6) NOT NULL,
	[NetEntryPriceBase] [decimal](18, 6) NOT NULL,
	[GrossTradeValueLocal] [decimal](18, 6) NOT NULL,
	[GrossTradeValueBase] [decimal](18, 6) NOT NULL,
	[NetTradeValueLocal] [decimal](18, 6) NOT NULL,
	[NetTradeValueBase] [decimal](18, 6) NOT NULL,
	[GrossNotionalValueLocal] [decimal](18, 6) NOT NULL,
	[GrossNotionalValueBase] [decimal](18, 6) NOT NULL,
	[NetNotionalValueLocal] [decimal](18, 6) NOT NULL,
	[NetNotionalValueBase] [decimal](18, 6) NOT NULL,
	[TotalCommissionLocal] [decimal](18, 6) NOT NULL,
	[TotalCommissionBase] [decimal](18, 6) NOT NULL,
	[IsSwap] [bit] NOT NULL,
	[FirstTradeDate] [date] NOT NULL,
	[LastTradeDate] [date] NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_Position] PRIMARY KEY CLUSTERED 
(
	[InstrumentId] ASC,
	[IsSwap] ASC,
	[PortfolioId] ASC,
	[LocalCurrency] ASC,
	[PositionDate] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [pos].[Position_H])
)
GO
/****** Object:  View [trd].[vwEmsxTradeToBook]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO










/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [trd].[vwEmsxTradeToBook] as
WITH OrderSign AS (
    SELECT 
        e.EmsxSequence,
        IIF(e.Side LIKE 'S%', -1, 1) as SignMultiplier
    FROM [trd].[EmsxOrder] e
), RankedFXRates AS (
    SELECT
        BaseCurrency,
        QuoteCurrency,
        [Date],
        [Value],
        ROW_NUMBER() OVER (PARTITION BY BaseCurrency, QuoteCurrency ORDER BY [Date] DESC) AS rn
    FROM
        trd.FxRate
), lastFxRate as(

	
SELECT
    BaseCurrency,
    QuoteCurrency,
    [Date],
        [Value]
FROM
    RankedFXRates
WHERE
    rn = 1
),

PrincipalDetails AS (
    SELECT
        e.EmsxSequence,
        os.SignMultiplier,
        os.SignMultiplier * e.Filled * e.AvgPrice * ISNULL(i.FuturePointValue, 1) AS Principal
    FROM [trd].[EmsxOrder] e
    LEFT JOIN trd.Instrument i ON i.Symbol = e.Ticker
    INNER JOIN OrderSign os ON os.EmsxSequence = e.EmsxSequence
),

BrokerCommDetails AS (
    SELECT
        pd.EmsxSequence,
        ABS(COALESCE(
           IIF(e.Strategy = 'EXECDESK' and fc.ExecDeskCommPerLot is not null, fc.ExecDeskCommPerLot, fc.CommPerLot) * e.Filled,
           IIF(e.Strategy = 'EXECDESK' and fc.ExecDeskCommRate is not null, fc.ExecDeskCommRate, fc.CommRate) * pd.Principal,
            e.[BrokerCommm],
            0
        )) AS BrokerCommm,
        COALESCE(IIF(e.Strategy = 'EXECDESK' and fc.ExecDeskCommRate is not null, fc.ExecDeskCommRate, fc.CommRate), e.[CommmRate], 0) AS CommmRate,
        ABS(ISNULL(e.[MiscFees] , 0)) AS MiscFees,
		IIF(e.Strategy = 'EXECDESK' and fc.ExecDeskCommPerLot is not null, fc.ExecDeskCommPerLot, fc.CommPerLot) as CommPerLot,
        IIF(e.Strategy = 'EXECDESK' and fc.ExecDeskCommRate is not null, fc.ExecDeskCommRate, fc.CommRate) as CommRate
    FROM [trd].[EmsxOrder] e
    LEFT JOIN trd.Instrument i ON i.Symbol = e.Ticker
    LEFT JOIN trd.FutureCommission fc ON fc.GenericFutureId = i.GenericFutureId AND fc.BrokerCode = e.Broker
    INNER JOIN PrincipalDetails pd ON pd.EmsxSequence = e.EmsxSequence
)
    SELECT
		t.TradeId,
        e.EmsxSequence,
        CAST(e.OrderRefId AS INT) AS OrderId,
         IIF(e.CustomNote1 = '', null,CAST(e.CustomNote1 AS INT)) AS RebalancingId,
        e.OrderRefId AS EmsxOrderRefId,
        e.EmsxDate,
        i.InstrumentId,
		i.Symbol,
		 LEFT(e.Side, 1) AS Side, -- S or B
        IIF(e.CustomNote3 = '', null, CAST(e.CustomNote3 AS CHAR(1))) AS PositionSide,
        pd.SignMultiplier * e.Amount AS OrderQuantity,
        pd.SignMultiplier * e.Filled AS FilledQuantity,
        i.Exchange as  ExchangeCode,
        e.Sedol,
        e.Account, -- to be reviewed when we implement allocations
		 bcd.BrokerCommm + bcd.MiscFees AS TotalCharges,
        e.EmsxDate AS TradeDate,
        pd.Principal,
        pd.Principal + ABS(bcd.BrokerCommm) + ABS(bcd.MiscFees) AS NetAmount,
        IIF(e.CustomNote2 = '', null, CAST(e.CustomNote2 AS TINYINT)) AS PortfolioId, -- to be reviewed when we implement allocations
        e.AvgPrice,
        e.DayAvgPrice,
        i.Currency AS TradeCurrency,
        e.OrderType,
        e.TimeInForce,
        e.Strategy,
        e.HandInstruction,
        e.SettleDate,
        ISNULL(fs.SettlementCurrency, ISNULL(e.SettleCurrency, i.Currency)) as SettleCurrency,
        bcd.BrokerCommm,
        bcd.CommmRate,
        bcd.MiscFees,
        e.Notes,
        e.Trader,
        e.Broker,
        IIF(e.CfdFlag = '1' OR e.CfdFlag = 'Y', 1, 0) AS IsCfd,
		IIF(fs.instrumentId is null, 0, 1) AS IsFutureSwap,
        'EMSX' AS ExecutionChannel,
       CAST( e.EmsxDate  AS DATETIME)+ CAST(e.TimeStamp AS DATETIME)AS CreatedOn, -- Assuming this is the correct calculation
        IIF(i.InstrumentId IS NOT NULL, 1, 0) AS IsInstrumentMapped,
        IIF(t.TradeId IS NOT NULL, 1, 0) AS IsTradeAlreadyBooked,
        bcd.CommPerLot,
        bcd.CommRate,
		IIF(fx.Value is null,1,fx.Value ) as LocalToSettleFxRate
       
    FROM [trd].[EmsxOrder] e
    LEFT JOIN trd.Instrument i ON i.Symbol = e.Ticker
    LEFT JOIN trd.Trade t ON t.EmsxSequence = e.EmsxSequence
	LEFT JOIN trd.vwFutureSwap fs ON fs.InstrumentId = i.InstrumentId
	left join lastFxRate fx ON fx.BaseCurrency = t.TradeCurrency and fx.QuoteCurrency = ISNULL(fs.SettlementCurrency, ISNULL(e.SettleCurrency, i.Currency))
    INNER JOIN PrincipalDetails pd ON pd.EmsxSequence = e.EmsxSequence
    INNER JOIN BrokerCommDetails bcd ON bcd.EmsxSequence = e.EmsxSequence
GO
/****** Object:  Table [trans].[H_TransmissionChannel]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[H_TransmissionChannel](
	[TransmissionChannelId] [int] NOT NULL,
	[Mnemonic] [nvarchar](10) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[ValidFrom] [datetime2](7) NOT NULL,
	[ValidTo] [datetime2](7) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_H_TransmissionChannel]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_H_TransmissionChannel] ON [trans].[H_TransmissionChannel]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [trans].[TransmissionChannel]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[TransmissionChannel](
	[TransmissionChannelId] [int] NOT NULL,
	[Mnemonic] [nvarchar](10) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[ValidFrom] [datetime2](7) GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
	[ValidTo] [datetime2](7) GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
 CONSTRAINT [PK_TransmissionChannel] PRIMARY KEY CLUSTERED 
(
	[TransmissionChannelId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [trans].[H_TransmissionChannel])
)
GO
/****** Object:  Table [book].[H_ClearingAccount]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [book].[H_ClearingAccount](
	[ClearingAccountId] [int] NOT NULL,
	[Code] [nvarchar](12) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[PortfolioId] [tinyint] NOT NULL,
	[TradeInstrumentTypeId] [int] NOT NULL,
	[ClearingBrokerId] [int] NOT NULL,
	[ValidFrom] [datetime2](7) NOT NULL,
	[ValidTo] [datetime2](7) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_H_ClearingAccount]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_H_ClearingAccount] ON [book].[H_ClearingAccount]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [book].[ClearingAccount]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [book].[ClearingAccount](
	[ClearingAccountId] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](12) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[PortfolioId] [tinyint] NOT NULL,
	[TradeInstrumentTypeId] [int] NOT NULL,
	[ClearingBrokerId] [int] NOT NULL,
	[ValidFrom] [datetime2](7) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](7) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_ClearingAccount] PRIMARY KEY CLUSTERED 
(
	[ClearingAccountId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_ClearingAccount] UNIQUE NONCLUSTERED 
(
	[PortfolioId] ASC,
	[TradeInstrumentTypeId] ASC,
	[ClearingBrokerId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [book].[H_ClearingAccount])
)
GO
/****** Object:  View [roll].[vwFutureCurrentContract]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





















/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [roll].[vwFutureCurrentContract] as
   SELECT 
        fcri.GenericFutureId,
        fcri.FutureContractId,
        fcri.Volume,
        fcri.Symbol,
        fcri.VolumeRank,
        fcri.RollingPeriodStart,
        fcri.RollingPeriodEnd,
        fcri.DayToFirstRollingDate,
        fcri.DayToLastRollingDate,
        fcri.IsRollingPeriod
    FROM [roll].[vwFutureContractRollInfo2] fcri
    INNER JOIN [roll].FutureCurrentContract fcc ON fcc.FutureContractId = fcri.FutureContractId


GO
/****** Object:  View [roll].[vwCompareCurrentContracts]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





















/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [roll].[vwCompareCurrentContracts] as
SELECT  fcc.[GenericFutureId]
      ,fcc.[FutureContractId]as TableContractId
	  ,fcri.[CurrentContractId]as ViewContractId 

      ,fcc.[Symbol] as TableSymbol
	   ,fcri.[Symbol] as ViewSymbol
		, IIF(fcc.[FutureContractId]<>fcri.[CurrentContractId], 1, 0) as ContractDiverge
	  ,fcc.[Volume] as TableVolume
      ,fcc.[RollingPeriodStart] as TableRollingPeriodStart
      ,fcc.[RollingPeriodEnd]as TableRollingPeriodEnd
      ,fcri.[Volume]as ViewVolume
	    ,fcri.[RollingPeriodStartDate]as ViewRollingPeriodStart
      ,fcri.[MaturityDate]as ViewRollingPeriodEnd

  FROM [roll].[vwFutureCurrentContract] fcc
  JOIN [roll].vwFutureContractRollInfo fcri on fcri.GenericFutureId = fcc.[GenericFutureId]



GO
/****** Object:  Table [ord].[TradeModeSelectionRule_H]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[TradeModeSelectionRule_H](
	[TradeModeSelectionRuleId] [int] NOT NULL,
	[PortfolioId] [tinyint] NULL,
	[BrokerId] [int] NULL,
	[InstrumentTypeId] [tinyint] NULL,
	[IsEfrp] [bit] NULL,
	[TradeModeId] [tinyint] NOT NULL,
	[ValidFrom] [datetime2](2) NOT NULL,
	[ValidTo] [datetime2](2) NOT NULL
) ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_TradeModeSelectionRule_H]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE CLUSTERED INDEX [ix_TradeModeSelectionRule_H] ON [ord].[TradeModeSelectionRule_H]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [ord].[TradeModeSelectionRule]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[TradeModeSelectionRule](
	[TradeModeSelectionRuleId] [int] IDENTITY(1,1) NOT NULL,
	[PortfolioId] [tinyint] NULL,
	[BrokerId] [int] NULL,
	[InstrumentTypeId] [tinyint] NULL,
	[IsEfrp] [bit] NULL,
	[TradeModeId] [tinyint] NOT NULL,
	[ValidFrom] [datetime2](2) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](2) GENERATED ALWAYS AS ROW END NOT NULL,
 CONSTRAINT [PK_TradeModeSelectionRule] PRIMARY KEY CLUSTERED 
(
	[TradeModeSelectionRuleId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [ord].[TradeModeSelectionRule_H])
)
GO
/****** Object:  View [ord].[vwExecutionProfile]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [ord].[vwExecutionProfile] as
SELECT  [ExecutionProfileId]
      ,ep.[OrderTypeId]
	  , ot.Mnemonic as OrderType
      ,ep.[TimeInForceId]
	  ,tif.Mnemonic as TimeInForce
      ,ep.[ExecutionAlgorithmId]
	  ,algo.Mnmemonic as ExecutionAlgorithm
      ,ep.[HandlingInstructionId]
	  , hi.Code as HandlingInstruction
      ,ep.[ExecutionChannelId]
	  ,ec.Mnemonic as ExecutionChannel
      ,ep.[TradingDeskId]
	  ,td.Code as TradingDesk
      ,[Param1]
      ,[Value1]
      ,[Param2]
      ,[Value2]
      ,[Param3]
      ,[Value3]
      ,[Param4]
      ,[Value4]
      ,[Param5]
      ,[Value5]
      ,[Param6]
      ,[Value6]
      ,[Param7]
      ,[Value7]
      ,[Param8]
      ,[Value8]
  FROM [ord].[ExecutionProfile] ep
  LEFT JOIN ord.OrderType ot on ot.OrderTypeId=  ep.OrderTypeId
  LEFT JOIN ord.TimeInForce tif on tif.TimeInForceId = ep.TimeInForceId
  LEFT JOIN ord.HandlingInstruction hi on hi.HandlingInstructionId = ep.HandlingInstructionId
  LEFT JOIN ord.ExecutionChannel ec on ec.ExecutionChannelId = ep. ExecutionChannelId
  LEFT JOIN ord.TradingDesk td on td.TradingDeskId = ep.TradingDeskId
  LEFT JOIN ord.ExecutionAlgorithm algo on algo.ExecutionAlgorithmId = ep.ExecutionAlgorithmId
  LEFT JOIN ord.ExecutionAlgorithmParamSet algoparam on algoparam.ExecutionAlgorithmParamSetId = ep.ExecutionAlgorithmParamSetId



GO
/****** Object:  Table [book].[Portfolio]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [book].[Portfolio](
	[PortfolioId] [tinyint] NOT NULL,
	[Mnemonic] [nvarchar](6) NOT NULL,
	[Currency] [char](3) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PortfolioId] PRIMARY KEY CLUSTERED 
(
	[PortfolioId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [book].[vwClearingAccount]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO










/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [book].[vwClearingAccount] as
SELECT top 100000 [ClearingAccountId]     
      ,ptf.PortfolioId
	  ,ptf.Mnemonic as PortfolioMnemonic
      ,tit.Name as TradeInstrumentType
	  ,tit.IsSwap
      ,clbrk.Code as ClearingBroker
    ,ca.[Code] as ClearingAccount
      ,[Description]
  FROM [book].[ClearingAccount] ca
  join book.TradeInstrumentType tit on tit.TradeInstrumentTypeId =  ca.TradeInstrumentTypeId
  JOIN book.Portfolio ptf on ptf.PortfolioId = ca.PortfolioId
  JOIN book.Counterparty clbrk on clbrk.CounterpartyId = ca.ClearingBrokerId
  order by ca.PortfolioId, ca.ClearingBrokerId, ca.TradeInstrumentTypeId

GO
/****** Object:  View [ord].[vwAllocationOrder]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO









/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [ord].[vwAllocationOrder] as
SELECT 
		alloc.[OrderAllocationId]
		,alloc.[OrderId]
      ,alloc.[PortfolioId]
      ,alloc.[Quantity] as AllocationQuantity
      , alloc.[TradingAccountId]
	  ,ta.Code as TradingAccount
      ,alloc.[PositionSideId]
	  ,ps.Mnemonic as PositionSide
      ,ord.[RebalancingSessionId]
      ,ord.[InstrumentId]
      ,ord.[Symbol]
      ,ord.[Name]
      ,ord.[Currency]
      ,ord.[Exchange]
      ,ord.[MarketSector]
      ,ord.[InstrumentType]
      ,ord.[OrderSideId]
      ,ord.[OrderSide]
      ,ord.[Quantity]
      ,ord.[BrokerId]
      ,ord.[BrokerCode]
      ,ord.[BrokerName]
      ,ord.[OrderTypeId]
      ,ord.[OrderType]
      ,ord.[TimeInForceId]
      ,ord.[TimeInForce]
      ,ord.[ExecutionAlgorithmId]
      ,ord.[ExecutionAlgo]
      ,ord.[HandlingInstructionId]
      ,ord.[HandlingInstruction]
      ,ord.[ExecutionChannelId]
      ,ord.[ExecutionChannel]
      ,ord.[TradeModeId]
      ,ord.[TradeMode]
      ,ord.[TradeDate]
      ,ord.[TradingDeskId]
      ,ord.[TradingDesk]
      ,ord.[CreatedOn]
      ,ord.[Param1]
      ,ord.[Value1]
      ,ord.[Param2]
      ,ord.[Value2]
      ,ord.[Param3]
      ,ord.[Value3]
      ,ord.[Param4]
      ,ord.[Value4]
      ,ord.[Param5]
      ,ord.[Value5]
      ,ord.[Param6]
      ,ord.[Value6]
      ,ord.[Param7]
      ,ord.[Value7]
      ,ord.[Param8]
      ,ord.[Value8]
  FROM [ord].[OrderAllocation] alloc
 LEFT JOIn ord.[vwOrder] ord on ord.OrderId = alloc.OrderId
 LEFT JOIN ord.TradingAccount ta on ta.TradingAccountId = alloc.TradingAccountId
 LEFT JOIN ord.PositionSide ps on ps.PositionSideId = alloc.PositionSideId




GO
/****** Object:  View [trd].[vwMSEfrpFutureTradeAffirm]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


















/****** Script for SelectTopNRows command from SSMS  ******/

CREATE VIEW [trd].[vwMSEfrpFutureTradeAffirm] as

SELECT  [Account]
      ,[Type]
      ,[Ccy1_Side]
      ,[Ccy1]
      ,[Ccy1_Amt]
      ,sum(cast([Ccy2_Side] as int)) as [Quantity]
      ,[Ccy2]
      ,Sum(cast([Ccy2_Amt] as decimal(24,6))) as [Ccy2_Amt]
      ,Avg(cast([Spot_Rate]as decimal(12,6))) as [Spot_Rate]
      ,[Trade_Date]
      ,[Value_Date]
      ,[Entry_User]
      ,[Deal_ID]
      ,MAX([Last_Update_Time]) as [Last_Update_Time]
      ,MAX([Deal_Entry_Time]) as [Deal_Entry_Time]
  FROM [dbo].[MSTradeAffirm]
  where Account = 'Future'
  group by[Account]
      ,[Type]
      ,[Ccy1_Side]
      ,[Ccy1]
      ,[Ccy1_Amt]   
      ,[Ccy2]          
      ,[Trade_Date]
      ,[Value_Date]
      ,[Entry_User]
      ,[Deal_ID]
    




GO
/****** Object:  Table [book].[FxRate]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [book].[FxRate](
	[BaseCurrency] [char](3) NOT NULL,
	[QuoteCurrency] [char](3) NOT NULL,
	[Value] [decimal](12, 6) NOT NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_FxRate] PRIMARY KEY CLUSTERED 
(
	[BaseCurrency] ASC,
	[QuoteCurrency] ASC,
	[Date] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [book].[Order]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [book].[Order](
	[OrderId] [int] NOT NULL,
	[InstrumentId] [int] NOT NULL,
	[Symbol] [nvarchar](100) NOT NULL,
	[RebalancingId] [int] NULL,
	[Quantity] [int] NOT NULL,
	[TradeDate] [date] NOT NULL,
	[ExecutionDesk] [nvarchar](10) NOT NULL,
	[TradeMode] [nvarchar](10) NOT NULL,
	[ExecutionAccount] [nvarchar](10) NOT NULL,
	[OrderType] [nvarchar](10) NOT NULL,
	[ExecutionAlgo] [nvarchar](10) NOT NULL,
	[TimeInForce] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [book].[OrderAllocation]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [book].[OrderAllocation](
	[OrderId] [int] NOT NULL,
	[PortfolioId] [tinyint] NOT NULL,
	[Quantity] [int] NOT NULL,
	[PositionSide] [nvarchar](2) NOT NULL,
 CONSTRAINT [PK_OrderAllocation] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC,
	[PortfolioId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [book].[Position]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [book].[Position](
	[PortfolioId] [tinyint] NOT NULL,
	[InstrumentId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[IsSwap] [bit] NOT NULL,
	[PositionDate] [date] NOT NULL,
 CONSTRAINT [PK_Position] PRIMARY KEY CLUSTERED 
(
	[PortfolioId] ASC,
	[InstrumentId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [conv].[Portfolio]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [conv].[Portfolio](
	[PortfolioId] [tinyint] NOT NULL,
	[Mnemonic] [nvarchar](6) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PortfolioId] PRIMARY KEY CLUSTERED 
(
	[PortfolioId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [conv].[TargetAllocationConversion]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [conv].[TargetAllocationConversion](
	[TargetAllocationConversionId] [int] IDENTITY(1,1) NOT NULL,
	[TargetAllocationId] [int] NOT NULL,
	[ConvertedOn] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_TargetAllocationConversion] PRIMARY KEY CLUSTERED 
(
	[TargetAllocationConversionId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [conv].[TargetWeightConversion]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [conv].[TargetWeightConversion](
	[TargetWeightConversionId] [int] IDENTITY(1,1) NOT NULL,
	[TargetAllocationConversionId] [int] NOT NULL,
	[FromInstrumentId] [int] NOT NULL,
	[FromSymbol] [int] NOT NULL,
	[FromWeight] [decimal](18, 6) NOT NULL,
	[ToInstrumentId] [int] NOT NULL,
	[ToSymbol] [int] NOT NULL,
	[ToWeight] [decimal](18, 6) NOT NULL,
 CONSTRAINT [PK_TargetWeightConversionId] PRIMARY KEY CLUSTERED 
(
	[TargetWeightConversionId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aph]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aph](
	[Trade_Date] [date] NOT NULL,
	[MdSymbol] [nvarchar](50) NOT NULL,
	[Qty] [int] NOT NULL,
	[Gross_Price] [float] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PositionBackup]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PositionBackup](
	[PortfolioId] [tinyint] NOT NULL,
	[InstrumentId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[AvgEntryPriceLocal] [decimal](18, 6) NOT NULL,
	[PositionValueLocal] [decimal](24, 6) NOT NULL,
	[GrossTotalCostLocal] [decimal](18, 6) NOT NULL,
	[NetTotalCostLocal] [decimal](18, 6) NOT NULL,
	[LastTradeAllocationId] [int] NOT NULL,
	[PositionDate] [date] NOT NULL,
	[Currency] [char](3) NOT NULL,
	[IsSwap] [bit] NOT NULL,
	[TotalCommissionLocal] [decimal](18, 6) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [efrp].[Broker]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [efrp].[Broker](
	[BrokerId] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Broker] PRIMARY KEY CLUSTERED 
(
	[BrokerId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [efrp].[EfrpOrder]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [efrp].[EfrpOrder](
	[EfrpOrderId] [int] NOT NULL,
	[OriginalOrderId] [int] NOT NULL,
	[FutureContractId] [int] NOT NULL,
	[OriginalQuantity] [int] NOT NULL,
	[FxForwardSymbol] [nvarchar](30) NOT NULL,
	[BaseCurrency] [char](3) NOT NULL,
	[QuoteCurrency] [char](3) NOT NULL,
	[MaturityDate] [date] NOT NULL,
	[FxForwardQuantity] [int] NOT NULL,
	[PortfolioId] [tinyint] NOT NULL,
	[RebalancingId] [int] NOT NULL,
	[PositionSide] [char](1) NOT NULL,
	[CreatedOn] [date] NOT NULL,
 CONSTRAINT [PK_EfrpOrder] PRIMARY KEY CLUSTERED 
(
	[EfrpOrderId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [efrp].[IMMDate]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [efrp].[IMMDate](
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_IMMDate] PRIMARY KEY CLUSTERED 
(
	[Date] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [exec].[EmsxRoute]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [exec].[EmsxRoute](
	[RouteId] [int] NOT NULL,
	[ApiSeqNum] [bigint] NULL,
	[Account] [nvarchar](255) NULL,
	[Amount] [int] NULL,
	[AvgPrice] [decimal](18, 6) NULL,
	[Broker] [nvarchar](255) NULL,
	[BrokerComm] [decimal](18, 6) NULL,
	[BseAvgPrice] [decimal](18, 6) NULL,
	[BseFilled] [int] NULL,
	[ClearingAccount] [nvarchar](255) NULL,
	[ClearingFirm] [nvarchar](255) NULL,
	[CommDiffFlag] [nvarchar](255) NULL,
	[CommRate] [decimal](18, 6) NULL,
	[CurrencyPair] [nvarchar](255) NULL,
	[CustomAccount] [nvarchar](255) NULL,
	[DayAvgPrice] [decimal](18, 6) NULL,
	[DayFill] [int] NULL,
	[ExchangeDestination] [nvarchar](255) NULL,
	[ExecInstruction] [nvarchar](255) NULL,
	[ExecuteBroker] [nvarchar](255) NULL,
	[FillId] [int] NULL,
	[Filled] [int] NULL,
	[GtdDate] [int] NULL,
	[HandInstruction] [nvarchar](255) NULL,
	[IsManualRoute] [int] NULL,
	[LastFillDate] [int] NULL,
	[LastFillTime] [int] NULL,
	[LastMarket] [nvarchar](255) NULL,
	[LastPrice] [decimal](18, 6) NULL,
	[LastShares] [int] NULL,
	[LimitPrice] [decimal](18, 6) NULL,
	[Misc_fees] [decimal](18, 6) NULL,
	[MlLegQuantity] [int] NULL,
	[MlNumLegs] [int] NULL,
	[MlPercentFilled] [decimal](18, 6) NULL,
	[MlRation] [decimal](18, 6) NULL,
	[MlRemainBalance] [decimal](18, 6) NULL,
	[MlStrategy] [nvarchar](255) NULL,
	[MlTotalQuantity] [int] NULL,
	[Notes] [nvarchar](max) NULL,
	[NseAvgPrice] [decimal](18, 6) NULL,
	[NseFilled] [int] NULL,
	[OrderType] [nvarchar](255) NULL,
	[Pa] [nvarchar](255) NULL,
	[PercentRemain] [decimal](18, 6) NULL,
	[Principal] [decimal](18, 6) NULL,
	[QueuedDate] [int] NULL,
	[QueuedTime] [int] NULL,
	[ReasonCode] [nvarchar](255) NULL,
	[ReasonDescription] [nvarchar](255) NULL,
	[RemainBalance] [decimal](18, 6) NULL,
	[RouteCreateDate] [int] NULL,
	[RouteCreateTime] [int] NULL,
	[RouteRefId] [nvarchar](255) NULL,
	[RouteLastUpdateTime] [int] NULL,
	[RoutePrice] [decimal](18, 6) NULL,
	[Sequence] [int] NOT NULL,
	[SettleAmount] [decimal](18, 6) NULL,
	[SettleDate] [int] NULL,
	[Status] [nvarchar](255) NULL,
	[StopPrice] [decimal](18, 6) NULL,
	[StrategyEndTime] [int] NULL,
	[StrategyPartRate1] [decimal](18, 6) NULL,
	[StrategyPartRate2] [decimal](18, 6) NULL,
	[StrategyStartTime] [int] NULL,
	[StrategyStyle] [nvarchar](255) NULL,
	[StrategyType] [nvarchar](255) NULL,
	[Tif] [nvarchar](255) NULL,
	[TimeStamp] [int] NULL,
	[Type] [nvarchar](255) NULL,
	[UrgencyLevel] [int] NULL,
	[UserCommAmount] [decimal](18, 6) NULL,
	[UserCommRate] [decimal](18, 6) NULL,
	[UserFees] [decimal](18, 6) NULL,
	[UserNetMoney] [decimal](18, 6) NULL,
	[Working] [int] NULL,
 CONSTRAINT [PK_EmsxRoute] PRIMARY KEY CLUSTERED 
(
	[Sequence] ASC,
	[RouteId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [instr].[StgRefData]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [instr].[StgRefData](
	[DL_REQUEST_ID] [nvarchar](200) NULL,
	[DL_REQUEST_NAME] [nvarchar](200) NULL,
	[DL_SNAPSHOT_START_TIME] [nvarchar](200) NULL,
	[DL_SNAPSHOT_TZ] [nvarchar](200) NULL,
	[IDENTIFIER] [nvarchar](200) NULL,
	[RC] [nvarchar](200) NULL,
	[BASE_CRNCY] [nvarchar](200) NULL,
	[BB_TO_EXCH_PX_SCALING_FACTOR] [nvarchar](200) NULL,
	[COUNTRY] [nvarchar](200) NULL,
	[COUNTRY_ISO] [nvarchar](200) NULL,
	[CRNCY] [nvarchar](200) NULL,
	[EXCH_CODE] [nvarchar](200) NULL,
	[FUT_CONT_SIZE] [nvarchar](200) NULL,
	[FUT_CUR_GEN_TICKER] [nvarchar](200) NULL,
	[FUT_DLV_DT_FIRST] [nvarchar](200) NULL,
	[FUT_EXCH_NAME_LONG] [nvarchar](200) NULL,
	[FUT_MONTH_YR] [nvarchar](200) NULL,
	[FUT_NOTICE_FIRST] [nvarchar](200) NULL,
	[FUT_ROLL_DT] [nvarchar](200) NULL,
	[FUT_TICK_SIZE] [nvarchar](200) NULL,
	[FUT_TICK_VAL] [nvarchar](200) NULL,
	[FUT_VAL_PT] [nvarchar](200) NULL,
	[ID_BB_GLOBAL] [nvarchar](200) NULL,
	[ID_BB_UNIQUE] [nvarchar](200) NULL,
	[ID_ISIN] [nvarchar](200) NULL,
	[ID_MIC_LOCAL_EXCH] [nvarchar](200) NULL,
	[ID_MIC_PRIM_EXCH] [nvarchar](200) NULL,
	[MARKET_SECTOR_DES] [nvarchar](200) NULL,
	[NAME] [nvarchar](200) NULL,
	[PX_SCALING_FACTOR] [nvarchar](200) NULL,
	[QUOTE_FACTOR] [nvarchar](200) NULL,
	[QUOTED_CRNCY] [nvarchar](200) NULL,
	[SECURITY_TYP] [nvarchar](200) NULL,
	[SECURITY_TYP2] [nvarchar](200) NULL,
	[TIME_ZONE_NUM] [nvarchar](200) NULL,
	[EXCHANGE_TRADING_SESSION_HOURS_BC_SESSION] [nvarchar](200) NULL,
	[EXCHANGE_TRADING_SESSION_HOURS_FUT_TRADING_HRS] [nvarchar](200) NULL,
	[LAST_TRADEABLE_DT] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [mktdata].[StgMarketData]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [mktdata].[StgMarketData](
	[DL_REQUEST_ID] [nvarchar](50) NULL,
	[DL_REQUEST_NAME] [nvarchar](50) NULL,
	[DL_SNAPSHOT_START_TIME] [nvarchar](50) NULL,
	[DL_SNAPSHOT_TZ] [nvarchar](50) NULL,
	[IDENTIFIER] [nvarchar](50) NULL,
	[RC] [nvarchar](50) NULL,
	[CUR_MKT_CAP] [nvarchar](50) NULL,
	[LAST_TRADE_DATE] [nvarchar](50) NULL,
	[LAST_UPDATE] [nvarchar](50) NULL,
	[LAST_UPDATE_DATE_EOD] [nvarchar](50) NULL,
	[LAST_UPDATE_DT] [nvarchar](50) NULL,
	[PX_CLOSE_DT] [nvarchar](50) NULL,
	[PX_LAST] [nvarchar](50) NULL,
	[PX_LAST_EOD] [nvarchar](50) NULL,
	[PX_YEST_CLOSE] [nvarchar](50) NULL,
	[VOLUME_AVG_30D] [nvarchar](50) NULL,
	[PX_YEST_DT] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [mktdata].[StgVolumeData]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [mktdata].[StgVolumeData](
	[DL_REQUEST_ID] [nvarchar](50) NULL,
	[DL_REQUEST_NAME] [nvarchar](50) NULL,
	[DL_SNAPSHOT_START_TIME] [nvarchar](50) NULL,
	[DL_SNAPSHOT_TZ] [nvarchar](50) NULL,
	[IDENTIFIER] [nvarchar](50) NULL,
	[RC] [nvarchar](50) NULL,
	[PX_VOLUME_1D] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [ord].[Exchange]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ord].[Exchange](
	[ExchangeId] [smallint] NOT NULL,
	[Code] [nvarchar](5) NOT NULL,
 CONSTRAINT [PK_ExchangeId] PRIMARY KEY CLUSTERED 
(
	[ExchangeId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ordgen].[Exchange]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ordgen].[Exchange](
	[ExchangeId] [smallint] NOT NULL,
	[Code] [nvarchar](5) NOT NULL,
 CONSTRAINT [PK_ExchangeId] PRIMARY KEY CLUSTERED 
(
	[ExchangeId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [port].[BookedTradeAllocation]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [port].[BookedTradeAllocation](
	[TradeId] [int] NOT NULL,
	[TradeAllocationId] [int] NOT NULL,
	[PortfolioId] [tinyint] NOT NULL,
	[InstrumentId] [int] NOT NULL,
	[IsSwap] [bit] NOT NULL,
	[Quantity] [int] NOT NULL,
	[TradePrice] [decimal](12, 6) NOT NULL,
	[GrossAmount] [decimal](18, 6) NOT NULL,
	[NetAmount] [decimal](18, 6) NOT NULL,
	[Commission] [decimal](16, 6) NOT NULL,
	[Fees] [decimal](16, 6) NOT NULL,
	[TradeCurrency] [char](3) NOT NULL,
	[LastTradeDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_BookedTradeAllocationId] PRIMARY KEY CLUSTERED 
(
	[TradeAllocationId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [port].[FxRate]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [port].[FxRate](
	[BaseCurrency] [char](3) NOT NULL,
	[QuoteCurrency] [char](3) NOT NULL,
	[Value] [decimal](12, 6) NOT NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_FxRate] PRIMARY KEY CLUSTERED 
(
	[BaseCurrency] ASC,
	[QuoteCurrency] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [port].[Trade]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [port].[Trade](
	[TradeId] [int] IDENTITY(1,1) NOT NULL,
	[PortfolioId] [tinyint] NOT NULL,
	[SecurityId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[ExecutionPrice] [decimal](12, 4) NOT NULL,
	[Currency] [nchar](3) NOT NULL,
	[ExecutedOn] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_TradeId] PRIMARY KEY CLUSTERED 
(
	[TradeId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_Trade] UNIQUE NONCLUSTERED 
(
	[SecurityId] ASC,
	[PortfolioId] ASC,
	[ExecutedOn] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [port].[TradeAllocation]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [port].[TradeAllocation](
	[TradeAllocationId] [int] NOT NULL,
	[PortfolioId] [tinyint] NOT NULL,
	[InstrumentId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[TradePrice] [decimal](12, 6) NOT NULL,
	[GrossAmount] [decimal](18, 6) NOT NULL,
	[NetAmount] [decimal](18, 6) NOT NULL,
	[Commission] [decimal](16, 6) NOT NULL,
	[Fees] [decimal](16, 6) NOT NULL,
	[TradeCurrency] [char](3) NOT NULL,
	[LastTradeDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_TradeAllocationId] PRIMARY KEY CLUSTERED 
(
	[TradeAllocationId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [port].[ZZZ_Position]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [port].[ZZZ_Position](
	[PortfolioId] [tinyint] NOT NULL,
	[InstrumentId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[AvgEntryPriceLocal] [decimal](18, 6) NOT NULL,
	[PositionValueLocal] [decimal](24, 6) NOT NULL,
	[GrossTotalCostLocal] [decimal](18, 6) NOT NULL,
	[NetTotalCostLocal] [decimal](18, 6) NOT NULL,
	[LastTradeAllocationId] [int] NOT NULL,
	[PositionDate] [date] NOT NULL,
	[Currency] [char](3) NOT NULL,
	[PreviousQuantity] [int] NOT NULL,
	[PreviousAvgEntryPriceLocal] [decimal](18, 6) NOT NULL,
	[PreviousPositionValueLocal] [decimal](18, 6) NOT NULL,
	[PreviousGrossTotalCostLocal] [decimal](18, 6) NOT NULL,
	[PreviousNetTotalCostLocal] [decimal](18, 6) NOT NULL,
	[PreviousPositionDate] [date] NULL,
	[TotalCommissionLocal] [decimal](18, 6) NULL,
 CONSTRAINT [PK_Position] PRIMARY KEY CLUSTERED 
(
	[PortfolioId] DESC,
	[InstrumentId] ASC,
	[Currency] ASC,
	[PositionDate] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [pos].[Instrument]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [pos].[Instrument](
	[InstrumentId] [int] NOT NULL,
	[Symbol] [nvarchar](30) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[InstrumentType] [nvarchar](8) NOT NULL,
	[MarketSector] [nvarchar](6) NOT NULL,
	[Currency] [char](3) NOT NULL,
 CONSTRAINT [PK_InstrumentId] PRIMARY KEY CLUSTERED 
(
	[InstrumentId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [pos].[TradeAllocation]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [pos].[TradeAllocation](
	[TradeAllocationId] [int] NOT NULL,
	[TradeId] [int] NOT NULL,
	[PortfolioId] [tinyint] NOT NULL,
	[InstrumentId] [int] NOT NULL,
	[TradeDate] [date] NOT NULL,
	[IsSwap] [bit] NOT NULL,
	[Isin] [nvarchar](12) NULL,
	[Sedol] [nvarchar](20) NULL,
	[Cusip] [nvarchar](10) NULL,
	[SecurityName] [nvarchar](100) NULL,
	[Quantity] [int] NOT NULL,
	[NominalQuantity] [decimal](18, 6) NOT NULL,
	[LocalCurrency] [char](3) NOT NULL,
	[BaseCurrency] [char](3) NOT NULL,
	[GrossAvgPriceLocal] [decimal](18, 6) NOT NULL,
	[GrossAvgPriceBase] [decimal](18, 6) NOT NULL,
	[NetAvgPriceLocal] [decimal](18, 6) NOT NULL,
	[NetAvgPriceBase] [decimal](18, 6) NOT NULL,
	[CommissionAmountLocal] [decimal](18, 6) NOT NULL,
	[CommissionAmountBase] [decimal](18, 6) NOT NULL,
	[GrossTradeValueLocal] [decimal](24, 6) NOT NULL,
	[NetTradeValueLocal] [decimal](24, 6) NOT NULL,
	[GrossTradeValueBase] [decimal](24, 6) NOT NULL,
	[NetTradeValueBase] [decimal](24, 6) NOT NULL,
	[GrossPrincipalLocal] [decimal](24, 6) NOT NULL,
	[NetPrincipalLocal] [decimal](24, 6) NOT NULL,
	[GrossPrincipalBase] [decimal](24, 6) NOT NULL,
	[NetPrincipalBase] [decimal](24, 6) NOT NULL,
	[LocalToBaseFxRate] [decimal](12, 6) NOT NULL,
	[LocalToSettleFxRate] [decimal](12, 6) NOT NULL,
 CONSTRAINT [PK_TradeAllocation] PRIMARY KEY CLUSTERED 
(
	[TradeAllocationId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [rebal].[Portfolio]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rebal].[Portfolio](
	[PortfolioId] [tinyint] NOT NULL,
	[Mnemonic] [nvarchar](6) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Currency] [char](3) NOT NULL,
 CONSTRAINT [PK_PortfolioId] PRIMARY KEY CLUSTERED 
(
	[PortfolioId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [rebal].[PortfolioValuation]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rebal].[PortfolioValuation](
	[PortfolioValuationId] [int] NOT NULL,
	[PortfolioId] [tinyint] NOT NULL,
	[TotalValue] [decimal](18, 6) NOT NULL,
	[GrossExposure] [decimal](18, 6) NOT NULL,
	[NetExposure] [decimal](18, 6) NOT NULL,
	[Currency] [char](3) NOT NULL,
	[ValuationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_PortfolioValuationId] PRIMARY KEY CLUSTERED 
(
	[PortfolioValuationId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [rebal].[PositionValuation]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rebal].[PositionValuation](
	[PortfolioValuationId] [int] NOT NULL,
	[InstrumentId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Weight] [decimal](18, 6) NOT NULL,
 CONSTRAINT [PK_PositionValuation] PRIMARY KEY CLUSTERED 
(
	[PortfolioValuationId] ASC,
	[InstrumentId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [rebal].[RebalancingSession]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rebal].[RebalancingSession](
	[RebalancingSessionId] [int] IDENTITY(1,1) NOT NULL,
	[Status] [nvarchar](20) NOT NULL,
	[StatusReason] [nvarchar](40) NOT NULL,
	[TradeDate] [date] NOT NULL,
	[StartedOn] [datetime2](7) NOT NULL,
	[EndedOn] [datetime2](7) NULL,
	[StartedBy] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_RebalancingSession] PRIMARY KEY CLUSTERED 
(
	[RebalancingSessionId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [rebal].[TargetAllocationValuation]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rebal].[TargetAllocationValuation](
	[TargetAllocationValuationId] [int] NOT NULL,
	[TargetAllocationId] [int] NOT NULL,
	[PortfolioId] [tinyint] NOT NULL,
	[ValuationCurrency] [char](3) NOT NULL,
	[PortfolioValue] [decimal](18, 6) NOT NULL,
	[TargetNetExposure] [decimal](18, 6) NOT NULL,
	[TargetGrossExposure] [decimal](18, 6) NOT NULL,
	[TotalWeight] [decimal](18, 6) NOT NULL,
	[ValuatedOn] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_TargetAllocationValuationId] PRIMARY KEY CLUSTERED 
(
	[TargetAllocationValuationId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_TargetAllocationValuation] UNIQUE NONCLUSTERED 
(
	[TargetAllocationId] ASC,
	[ValuatedOn] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [rebal].[TargetWeightValuation]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rebal].[TargetWeightValuation](
	[TargetAllocationValuationId] [int] NOT NULL,
	[InstrumentId] [int] NOT NULL,
	[Weight] [decimal](12, 6) NOT NULL,
	[TargetQuantity] [int] NOT NULL,
 CONSTRAINT [PK_TargetWeightValuation] PRIMARY KEY CLUSTERED 
(
	[TargetAllocationValuationId] ASC,
	[InstrumentId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [risk].[ConstraintBreach]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [risk].[ConstraintBreach](
	[ConstraintBreachId] [int] IDENTITY(1,1) NOT NULL,
	[TargetAllocationCheckId] [int] NOT NULL,
	[ConstraintId] [int] NOT NULL,
	[LimitValue] [float] NOT NULL,
	[CheckedValue] [float] NOT NULL,
	[Message] [nvarchar](300) NOT NULL,
 CONSTRAINT [PK_ConstraintBreach] PRIMARY KEY CLUSTERED 
(
	[ConstraintBreachId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [risk].[FilterCriterion]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [risk].[FilterCriterion](
	[FilterCriterionId] [int] IDENTITY(1,1) NOT NULL,
	[FilterPartyTypeId] [tinyint] NOT NULL,
	[FilterOperatorId] [tinyint] NOT NULL,
	[FilterPartyId] [int] NOT NULL,
 CONSTRAINT [PK_FilterCriterionId] PRIMARY KEY CLUSTERED 
(
	[FilterCriterionId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_FilterCriterion] UNIQUE NONCLUSTERED 
(
	[FilterPartyTypeId] ASC,
	[FilterOperatorId] ASC,
	[FilterPartyId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [risk].[FilterParty]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [risk].[FilterParty](
	[FilterPartyId] [int] NOT NULL,
	[FilterPartyTypeId] [tinyint] NOT NULL,
 CONSTRAINT [PK_ContractPartyId] PRIMARY KEY CLUSTERED 
(
	[FilterPartyId] ASC,
	[FilterPartyTypeId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [risk].[Instrument]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [risk].[Instrument](
	[InstrumentId] [int] NOT NULL,
	[Symbol] [nvarchar](30) NOT NULL,
	[InstrumentType] [nvarchar](30) NOT NULL,
	[Currency] [char](3) NOT NULL,
 CONSTRAINT [PK_InstrumentId] PRIMARY KEY CLUSTERED 
(
	[InstrumentId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [risk].[Portfolio]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [risk].[Portfolio](
	[PortfolioId] [tinyint] NOT NULL,
	[Mnemonic] [nvarchar](6) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Currency] [char](3) NOT NULL,
 CONSTRAINT [PK_PortfolioId] PRIMARY KEY CLUSTERED 
(
	[PortfolioId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [risk].[TargetAllocationCheck]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [risk].[TargetAllocationCheck](
	[TargetAllocationCheckId] [int] IDENTITY(1,1) NOT NULL,
	[TargetAllocationId] [int] NOT NULL,
	[IsBreach] [bit] NOT NULL,
	[CheckedOn] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_TargetAllocationCheck] PRIMARY KEY CLUSTERED 
(
	[TargetAllocationCheckId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [roll].[FutureRollOrder]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [roll].[FutureRollOrder](
	[FutureRollOrderId] [tinyint] NOT NULL,
	[PortfolioId] [tinyint] NOT NULL,
	[RolledQuantity] [int] NOT NULL,
	[GenericFutureId] [int] NOT NULL,
	[GenericFutureSymbol] [nvarchar](30) NOT NULL,
	[ExpiringContractId] [int] NOT NULL,
	[ExpiringContractSymbol] [nvarchar](30) NOT NULL,
	[ExpiringContractMaturity] [date] NOT NULL,
	[NextContractId] [int] NOT NULL,
	[NextContractSymbol] [nvarchar](30) NOT NULL,
	[NextContractMaturity] [date] NOT NULL,
	[RollDate] [date] NOT NULL,
 CONSTRAINT [PK_FutureRollOrder] PRIMARY KEY CLUSTERED 
(
	[PortfolioId] DESC,
	[ExpiringContractId] ASC,
	[NextContractId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [roll].[FxForwardRollOrder]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [roll].[FxForwardRollOrder](
	[FutureRollOrderId] [tinyint] NOT NULL,
	[PortfolioId] [tinyint] NOT NULL,
	[RolledQuantity] [int] NOT NULL,
	[CurrencyPairId] [int] NOT NULL,
	[CurrencyPairSymbol] [nvarchar](30) NOT NULL,
	[ExpiringContractId] [int] NOT NULL,
	[ExpiringContractSymbol] [nvarchar](30) NOT NULL,
	[ExpiringContractMaturity] [date] NOT NULL,
	[NextContractId] [int] NOT NULL,
	[NextContractSymbol] [nvarchar](30) NOT NULL,
	[NextContractMaturity] [date] NOT NULL,
	[RollDate] [date] NOT NULL,
 CONSTRAINT [PK_FxForwardRollOrder] PRIMARY KEY CLUSTERED 
(
	[PortfolioId] DESC,
	[ExpiringContractId] ASC,
	[NextContractId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [trans].[InstrumentPricing]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[InstrumentPricing](
	[InstrumentId] [int] NOT NULL,
	[Price] [decimal](18, 6) NOT NULL,
	[Currency] [char](3) NOT NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_InstrumentPricing] PRIMARY KEY CLUSTERED 
(
	[InstrumentId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [trans].[TransmittedTrade]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trans].[TransmittedTrade](
	[FileTransmissionId] [int] NOT NULL,
	[TradeId] [int] NOT NULL,
 CONSTRAINT [PK_TransmittedTrade] PRIMARY KEY CLUSTERED 
(
	[FileTransmissionId] ASC,
	[TradeId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [trd].[StgTradeAllocToBook]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trd].[StgTradeAllocToBook](
	[StgTradeAllocToBookId] [int] IDENTITY(1,1) NOT NULL,
	[StgTradeToBookId] [int] NULL,
	[PortfolioId] [tinyint] NULL,
	[Quantity] [int] NULL,
	[Price] [decimal](18, 6) NULL,
	[GrossAmount] [decimal](18, 6) NULL,
	[NetAmount] [decimal](18, 6) NULL,
	[Commission] [decimal](18, 6) NULL,
	[Fees] [decimal](18, 6) NULL,
	[PositionSide] [char](1) NULL,
	[TradingAccount] [nvarchar](30) NULL,
 CONSTRAINT [PK_StgTradeAllocToBook] PRIMARY KEY CLUSTERED 
(
	[StgTradeAllocToBookId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [trd].[StgTradeToBook]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trd].[StgTradeToBook](
	[StgTradeToBookId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NULL,
	[RebalancingId] [int] NULL,
	[EmsxSequence] [int] NULL,
	[EmsxOrderCreatedOn] [date] NULL,
	[InstrumentId] [int] NOT NULL,
	[ExchangeCode] [nvarchar](20) NULL,
	[Sedol] [nvarchar](7) NULL,
	[BuySellIndicator] [char](1) NOT NULL,
	[OrderQuantity] [int] NOT NULL,
	[FilledQuantity] [int] NOT NULL,
	[AvgPrice] [decimal](18, 6) NOT NULL,
	[DayAveragePrice] [decimal](18, 6) NULL,
	[TradeCurrency] [char](3) NOT NULL,
	[TradeDate] [date] NOT NULL,
	[Principal] [decimal](18, 6) NOT NULL,
	[NetAmount] [decimal](18, 6) NOT NULL,
	[SettlementDate] [date] NULL,
	[SettlementCurrency] [char](3) NULL,
	[BrokerCommission] [decimal](12, 6) NOT NULL,
	[CommissionRate] [decimal](12, 6) NOT NULL,
	[MiscFees] [decimal](12, 6) NOT NULL,
	[Notes] [nvarchar](300) NULL,
	[Trader] [nvarchar](30) NULL,
	[BrokerCode] [nvarchar](10) NOT NULL,
	[TradeDesk] [nvarchar](10) NOT NULL,
	[IsCfd] [bit] NOT NULL,
	[ExecutionChannel] [nvarchar](10) NULL,
	[CreatedOn] [datetime] NULL,
	[TotalCharges] [decimal](18, 6) NOT NULL,
	[FxemTradeId] [int] NULL,
	[FxemOrderId] [int] NULL,
	[TradeStatus] [nvarchar](5) NOT NULL,
	[FxCurrency1] [char](3) NULL,
	[FXCurrency1Amount] [decimal](24, 6) NULL,
	[FxCurrency2] [char](3) NULL,
	[FXCurrency2Amount] [decimal](24, 6) NULL,
	[IsFutureSwap] [bit] NOT NULL,
	[LocalToSettleFxRate] [decimal](12, 6) NULL,
 CONSTRAINT [PK_StgTradeToBookId] PRIMARY KEY CLUSTERED 
(
	[StgTradeToBookId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [trd].[TradeAllocation_Backup]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trd].[TradeAllocation_Backup](
	[TradeAllocationId] [int] IDENTITY(1,1) NOT NULL,
	[TradeId] [int] NOT NULL,
	[PortfolioId] [tinyint] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](18, 6) NOT NULL,
	[GrossAmount] [decimal](18, 6) NOT NULL,
	[NetAmount] [decimal](18, 6) NOT NULL,
	[Commission] [decimal](18, 6) NOT NULL,
	[Fees] [decimal](18, 6) NOT NULL,
	[PositionSide] [char](1) NULL,
	[TradingAccount] [nvarchar](30) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [trd].[TradeFill]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [trd].[TradeFill](
	[TradeFillId] [int] IDENTITY(1,1) NOT NULL,
	[TradeId] [int] NOT NULL,
	[EmsxTradeFillId] [int] NULL,
	[FilledQuantity] [int] NULL,
	[FilledPrice] [decimal](18, 6) NULL,
	[FilledOn] [date] NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_TradeFill] PRIMARY KEY CLUSTERED 
(
	[TradeFillId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [val].[FutureContract]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [val].[FutureContract](
	[FutureContractId] [int] NOT NULL,
	[PointValue] [decimal](14, 6) NOT NULL,
	[PointValueCurrency] [char](3) NOT NULL,
 CONSTRAINT [PK_FutureContractId] PRIMARY KEY CLUSTERED 
(
	[FutureContractId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [val].[InstrumentPricing]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [val].[InstrumentPricing](
	[InstrumentId] [int] NOT NULL,
	[Price] [decimal](18, 6) NOT NULL,
	[Currency] [char](3) NOT NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_InstrumentPricing] PRIMARY KEY CLUSTERED 
(
	[InstrumentId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [val].[TargetAllocation]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [val].[TargetAllocation](
	[TargetAllocationId] [int] NOT NULL,
	[PortfolioId] [tinyint] NOT NULL,
	[GeneratedOn] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_TargetAllocationId] PRIMARY KEY CLUSTERED 
(
	[TargetAllocationId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [val].[TargetAllocationValuation]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [val].[TargetAllocationValuation](
	[TargetAllocationValuationId] [int] IDENTITY(1,1) NOT NULL,
	[TargetAllocationId] [int] NOT NULL,
	[ValuationCurrency] [char](3) NOT NULL,
	[PortfolioValue] [decimal](18, 6) NOT NULL,
	[TargetNetExposure] [decimal](18, 6) NOT NULL,
	[TargetGrossExposure] [decimal](18, 6) NOT NULL,
	[TotalWeight] [decimal](18, 6) NOT NULL,
	[ValuatedOn] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_TargetAllocationValuationId] PRIMARY KEY CLUSTERED 
(
	[TargetAllocationValuationId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_TargetAllocationValuation] UNIQUE NONCLUSTERED 
(
	[TargetAllocationId] ASC,
	[ValuatedOn] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [val].[TargetWeight]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [val].[TargetWeight](
	[TargetWeightId] [int] IDENTITY(1,1) NOT NULL,
	[TargetAllocationId] [int] NOT NULL,
	[InstrumentId] [int] NOT NULL,
	[Weight] [decimal](9, 6) NOT NULL,
 CONSTRAINT [PK_TargetWeightId] PRIMARY KEY CLUSTERED 
(
	[TargetWeightId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_TargetWeight] UNIQUE NONCLUSTERED 
(
	[TargetWeightId] ASC,
	[InstrumentId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [val].[TargetWeightValuation]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [val].[TargetWeightValuation](
	[TargetWeightValuationId] [int] IDENTITY(1,1) NOT NULL,
	[TargetAllocationValuationId] [int] NOT NULL,
	[InstrumentId] [int] NOT NULL,
	[Weight] [decimal](12, 6) NOT NULL,
	[Price] [decimal](18, 6) NOT NULL,
	[PricedOn] [datetime2](7) NOT NULL,
	[PriceCurrency] [char](3) NOT NULL,
	[InstrumentValue] [decimal](18, 6) NOT NULL,
	[TargetQuantity] [int] NOT NULL,
	[TargetNetExposure] [decimal](18, 6) NOT NULL,
	[TargetGrossExposure] [decimal](18, 6) NOT NULL,
 CONSTRAINT [PK_TargetWeightValuation] PRIMARY KEY CLUSTERED 
(
	[TargetWeightValuationId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_TargetWeightValuation] UNIQUE NONCLUSTERED 
(
	[TargetAllocationValuationId] ASC,
	[InstrumentId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [wght].[StgTargetWeight]    Script Date: 6/26/2024 1:49:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [wght].[StgTargetWeight](
	[PortfolioId] [tinyint] NOT NULL,
	[Symbol] [nvarchar](30) NOT NULL,
	[Weight] [decimal](9, 6) NOT NULL,
 CONSTRAINT [PK_StgTargetWeight] PRIMARY KEY CLUSTERED 
(
	[Weight] ASC,
	[PortfolioId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [Idx_InstrumentId]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE NONCLUSTERED INDEX [Idx_InstrumentId] ON [port].[TradeAllocation]
(
	[InstrumentId] ASC
)
INCLUDE([PortfolioId],[Quantity],[TradePrice],[GrossAmount],[NetAmount],[TradeCurrency],[LastTradeDate]) WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [Idx_LastTradeDate]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE NONCLUSTERED INDEX [Idx_LastTradeDate] ON [port].[TradeAllocation]
(
	[LastTradeDate] ASC
)
INCLUDE([PortfolioId],[InstrumentId],[Quantity],[TradePrice],[GrossAmount],[NetAmount],[Commission],[TradeCurrency]) WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [Idx_PortfolioId_PositionDate]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE NONCLUSTERED INDEX [Idx_PortfolioId_PositionDate] ON [port].[ZZZ_Position]
(
	[PortfolioId] ASC,
	[PositionDate] ASC
)
INCLUDE([Quantity],[AvgEntryPriceLocal],[PositionValueLocal],[GrossTotalCostLocal],[NetTotalCostLocal],[LastTradeAllocationId],[PreviousQuantity],[PreviousAvgEntryPriceLocal],[PreviousPositionValueLocal],[PreviousGrossTotalCostLocal],[PreviousNetTotalCostLocal],[PreviousPositionDate]) WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [Idx_Position_Quantity]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE NONCLUSTERED INDEX [Idx_Position_Quantity] ON [port].[ZZZ_Position]
(
	[Quantity] ASC
)
INCLUDE([AvgEntryPriceLocal],[PositionValueLocal],[GrossTotalCostLocal],[NetTotalCostLocal],[LastTradeAllocationId],[PreviousQuantity],[PreviousAvgEntryPriceLocal],[PreviousPositionValueLocal],[PreviousGrossTotalCostLocal],[PreviousNetTotalCostLocal],[PreviousPositionDate]) WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [Idx_TradeAllocation_TradeId]    Script Date: 6/26/2024 1:49:56 PM ******/
CREATE NONCLUSTERED INDEX [Idx_TradeAllocation_TradeId] ON [trd].[TradeAllocation]
(
	[TradeId] ASC
)
INCLUDE([PortfolioId],[Quantity],[Price],[GrossAmount],[NetAmount],[Commission],[Fees]) WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [book].[TradeBookingError] ADD  DEFAULT (getutcdate()) FOR [CreatedOn]
GO
ALTER TABLE [efrp].[EfrpOrder] ADD  DEFAULT (getutcdate()) FOR [CreatedOn]
GO
ALTER TABLE [instr].[Instrument] ADD  DEFAULT ((1)) FOR [PriceScalingFactor]
GO
ALTER TABLE [instr].[Instrument] ADD  DEFAULT ((1)) FOR [QuoteFactor]
GO
ALTER TABLE [ord].[Order] ADD  DEFAULT (getutcdate()) FOR [CreatedOn]
GO
ALTER TABLE [ord].[Order] ADD  DEFAULT (sysutcdatetime()) FOR [ValidFrom]
GO
ALTER TABLE [ord].[Order] ADD  DEFAULT (CONVERT([datetime2],'9999-12-31 23:59:59.9999999')) FOR [ValidTo]
GO
ALTER TABLE [ord].[OrderAllocation] ADD  DEFAULT (sysutcdatetime()) FOR [ValidFrom]
GO
ALTER TABLE [ord].[OrderAllocation] ADD  DEFAULT (CONVERT([datetime2],'9999-12-31 23:59:59.9999999')) FOR [ValidTo]
GO
ALTER TABLE [rebal].[PortfolioDrift] ADD  DEFAULT (getutcdate()) FOR [ComputedOn]
GO
ALTER TABLE [rebal].[RebalancingSession] ADD  DEFAULT ('Unknown') FOR [StartedBy]
GO
ALTER TABLE [trans].[Counterparty] ADD  CONSTRAINT [DF_Counterparty_ValidFrom]  DEFAULT (sysutcdatetime()) FOR [ValidFrom]
GO
ALTER TABLE [trans].[Counterparty] ADD  CONSTRAINT [DF_Counterparty_ValidTo]  DEFAULT (CONVERT([datetime2],'9999-12-31 23:59:59.9999999')) FOR [ValidTo]
GO
ALTER TABLE [trans].[EmailConfiguration] ADD  CONSTRAINT [DF_EmailConfiguration_ValidFrom]  DEFAULT (sysutcdatetime()) FOR [ValidFrom]
GO
ALTER TABLE [trans].[EmailConfiguration] ADD  CONSTRAINT [DF_EmailConfiguration_ValidTo]  DEFAULT (CONVERT([datetime2],'9999-12-31 23:59:59.9999999')) FOR [ValidTo]
GO
ALTER TABLE [trans].[EncryptionProfile] ADD  CONSTRAINT [DF_EncryptionProfile_ValidFrom]  DEFAULT (sysutcdatetime()) FOR [ValidFrom]
GO
ALTER TABLE [trans].[EncryptionProfile] ADD  CONSTRAINT [DF_EncryptionProfile_ValidTo]  DEFAULT (CONVERT([datetime2],'9999-12-31 23:59:59.9999999')) FOR [ValidTo]
GO
ALTER TABLE [trans].[FileContentType] ADD  CONSTRAINT [DF_FileContentType_ValidFrom]  DEFAULT (sysutcdatetime()) FOR [ValidFrom]
GO
ALTER TABLE [trans].[FileContentType] ADD  CONSTRAINT [DF_FileContentType_ValidTo]  DEFAULT (CONVERT([datetime2],'9999-12-31 23:59:59.9999999')) FOR [ValidTo]
GO
ALTER TABLE [trans].[FileGenerationProfile] ADD  CONSTRAINT [DF_FileGenerationProfile_ValidFrom]  DEFAULT (sysutcdatetime()) FOR [ValidFrom]
GO
ALTER TABLE [trans].[FileGenerationProfile] ADD  CONSTRAINT [DF_FileGenerationProfile_ValidTo]  DEFAULT (CONVERT([datetime2],'9999-12-31 23:59:59.9999999')) FOR [ValidTo]
GO
ALTER TABLE [trans].[FtpConfiguration] ADD  CONSTRAINT [DF_FtpConfiguration_ValidFrom]  DEFAULT (sysutcdatetime()) FOR [ValidFrom]
GO
ALTER TABLE [trans].[FtpConfiguration] ADD  CONSTRAINT [DF_FtpConfiguration_ValidTo]  DEFAULT (CONVERT([datetime2],'9999-12-31 23:59:59.9999999')) FOR [ValidTo]
GO
ALTER TABLE [trans].[TransmissionChannel] ADD  CONSTRAINT [DF_TransmissionChannel_ValidFrom]  DEFAULT (sysutcdatetime()) FOR [ValidFrom]
GO
ALTER TABLE [trans].[TransmissionChannel] ADD  CONSTRAINT [DF_TransmissionChannel_ValidTo]  DEFAULT (CONVERT([datetime2],'9999-12-31 23:59:59.9999999')) FOR [ValidTo]
GO
ALTER TABLE [trans].[TransmissionProfile] ADD  CONSTRAINT [DF_TransmissionProfile_ValidFrom]  DEFAULT (sysutcdatetime()) FOR [ValidFrom]
GO
ALTER TABLE [trans].[TransmissionProfile] ADD  CONSTRAINT [DF_TransmissionProfile_ValidTo]  DEFAULT (CONVERT([datetime2],'9999-12-31 23:59:59.9999999')) FOR [ValidTo]
GO
ALTER TABLE [trans].[TransmissionScheduleType] ADD  CONSTRAINT [DF_TransmissionScheduleType_ValidFrom]  DEFAULT (sysutcdatetime()) FOR [ValidFrom]
GO
ALTER TABLE [trans].[TransmissionScheduleType] ADD  CONSTRAINT [DF_TransmissionScheduleType_ValidTo]  DEFAULT (CONVERT([datetime2],'9999-12-31 23:59:59.9999999')) FOR [ValidTo]
GO
ALTER TABLE [trd].[EmsxOrder] ADD  CONSTRAINT [DF_EmsxOrder_ValidFrom]  DEFAULT (sysutcdatetime()) FOR [ValidFrom]
GO
ALTER TABLE [trd].[EmsxOrder] ADD  CONSTRAINT [DF_EmsxOrder_ValidTo]  DEFAULT (CONVERT([datetime2],'9999-12-31 23:59:59.9999999')) FOR [ValidTo]
GO
ALTER TABLE [trd].[StgTradeToBook] ADD  DEFAULT ('NEW') FOR [TradeStatus]
GO
ALTER TABLE [trd].[Trade] ADD  DEFAULT (getutcdate()) FOR [CreatedOn]
GO
ALTER TABLE [trd].[Trade] ADD  DEFAULT ('NEW') FOR [TradeStatus]
GO
ALTER TABLE [trd].[Trade] ADD  DEFAULT (getutcdate()) FOR [BookedOn]
GO
ALTER TABLE [trd].[TradeFill] ADD  DEFAULT (getutcdate()) FOR [CreatedOn]
GO
ALTER TABLE [book].[ClearingAccount]  WITH NOCHECK ADD  CONSTRAINT [FK_ClearingAccount_Counterparty] FOREIGN KEY([ClearingBrokerId])
REFERENCES [book].[Counterparty] ([CounterpartyId])
GO
ALTER TABLE [book].[ClearingAccount] CHECK CONSTRAINT [FK_ClearingAccount_Counterparty]
GO
ALTER TABLE [book].[ClearingAccount]  WITH NOCHECK ADD  CONSTRAINT [FK_ClearingAccount_TradeInstrumentType] FOREIGN KEY([TradeInstrumentTypeId])
REFERENCES [book].[TradeInstrumentType] ([TradeInstrumentTypeId])
GO
ALTER TABLE [book].[ClearingAccount] CHECK CONSTRAINT [FK_ClearingAccount_TradeInstrumentType]
GO
ALTER TABLE [book].[CommissionSchedule]  WITH NOCHECK ADD  CONSTRAINT [FK_CommissionSchedule_CommissionType] FOREIGN KEY([CommissionTypeId])
REFERENCES [book].[CommissionType] ([CommissionTypeId])
GO
ALTER TABLE [book].[CommissionSchedule] CHECK CONSTRAINT [FK_CommissionSchedule_CommissionType]
GO
ALTER TABLE [book].[CommissionSchedule]  WITH NOCHECK ADD  CONSTRAINT [FK_CommissionSchedule_CounterpartyRoleSetup] FOREIGN KEY([CounterpartyRoleSetupId])
REFERENCES [book].[CounterpartyRoleSetup] ([CounterpartyRoleSetupId])
GO
ALTER TABLE [book].[CommissionSchedule] CHECK CONSTRAINT [FK_CommissionSchedule_CounterpartyRoleSetup]
GO
ALTER TABLE [book].[CommissionSchedule]  WITH NOCHECK ADD  CONSTRAINT [FK_CommissionSchedule_ExecutionBroker] FOREIGN KEY([ExecutionBrokerId])
REFERENCES [book].[Counterparty] ([CounterpartyId])
GO
ALTER TABLE [book].[CommissionSchedule] CHECK CONSTRAINT [FK_CommissionSchedule_ExecutionBroker]
GO
ALTER TABLE [book].[CommissionSchedule]  WITH NOCHECK ADD  CONSTRAINT [FK_CommissionSchedule_ExecutionType] FOREIGN KEY([ExecutionTypeId])
REFERENCES [book].[ExecutionType] ([ExecutionTypeId])
GO
ALTER TABLE [book].[CommissionSchedule] CHECK CONSTRAINT [FK_CommissionSchedule_ExecutionType]
GO
ALTER TABLE [book].[CommissionSchedule]  WITH NOCHECK ADD  CONSTRAINT [FK_CommissionSchedule_Instrument] FOREIGN KEY([InstrumentId])
REFERENCES [book].[Instrument] ([InstrumentId])
GO
ALTER TABLE [book].[CommissionSchedule] CHECK CONSTRAINT [FK_CommissionSchedule_Instrument]
GO
ALTER TABLE [book].[CounterpartyRoleAssignment]  WITH NOCHECK ADD  CONSTRAINT [FK_CounterpartyRoleAssignment_CounterpartyRoleSetup] FOREIGN KEY([CounterpartyRoleSetupId])
REFERENCES [book].[CounterpartyRoleSetup] ([CounterpartyRoleSetupId])
GO
ALTER TABLE [book].[CounterpartyRoleAssignment] CHECK CONSTRAINT [FK_CounterpartyRoleAssignment_CounterpartyRoleSetup]
GO
ALTER TABLE [book].[CounterpartyRoleAssignment]  WITH NOCHECK ADD  CONSTRAINT [FK_CounterpartyRoleAssignment_ExecutionBroker] FOREIGN KEY([ExecutionBrokerId])
REFERENCES [book].[Counterparty] ([CounterpartyId])
GO
ALTER TABLE [book].[CounterpartyRoleAssignment] CHECK CONSTRAINT [FK_CounterpartyRoleAssignment_ExecutionBroker]
GO
ALTER TABLE [book].[CounterpartyRoleAssignment]  WITH NOCHECK ADD  CONSTRAINT [FK_CounterpartyRoleAssignment_Instrument] FOREIGN KEY([InstrumentId])
REFERENCES [book].[Instrument] ([InstrumentId])
GO
ALTER TABLE [book].[CounterpartyRoleAssignment] CHECK CONSTRAINT [FK_CounterpartyRoleAssignment_Instrument]
GO
ALTER TABLE [book].[CounterpartyRoleSetup]  WITH NOCHECK ADD  CONSTRAINT [FK_CounterpartyRoleSetup_ClearingBroker] FOREIGN KEY([ClearingBrokerId])
REFERENCES [book].[Counterparty] ([CounterpartyId])
GO
ALTER TABLE [book].[CounterpartyRoleSetup] CHECK CONSTRAINT [FK_CounterpartyRoleSetup_ClearingBroker]
GO
ALTER TABLE [book].[CounterpartyRoleSetup]  WITH NOCHECK ADD  CONSTRAINT [FK_CounterpartyRoleSetup_Custodian] FOREIGN KEY([CustodianId])
REFERENCES [book].[Counterparty] ([CounterpartyId])
GO
ALTER TABLE [book].[CounterpartyRoleSetup] CHECK CONSTRAINT [FK_CounterpartyRoleSetup_Custodian]
GO
ALTER TABLE [book].[CounterpartyRoleSetup]  WITH NOCHECK ADD  CONSTRAINT [FK_CounterpartyRoleSetup_PrimeBroker] FOREIGN KEY([PrimeBrokerId])
REFERENCES [book].[Counterparty] ([CounterpartyId])
GO
ALTER TABLE [book].[CounterpartyRoleSetup] CHECK CONSTRAINT [FK_CounterpartyRoleSetup_PrimeBroker]
GO
ALTER TABLE [book].[ExecutionDesk]  WITH NOCHECK ADD  CONSTRAINT [FK_ExecutionDesk_ExecutionBroker] FOREIGN KEY([ExecutionBrokerId])
REFERENCES [book].[Counterparty] ([CounterpartyId])
GO
ALTER TABLE [book].[ExecutionDesk] CHECK CONSTRAINT [FK_ExecutionDesk_ExecutionBroker]
GO
ALTER TABLE [book].[ExecutionTypeMapping]  WITH NOCHECK ADD  CONSTRAINT [FK_ExecutionTypeMapping_ExecutionDesk] FOREIGN KEY([ExecutionDeskId])
REFERENCES [book].[ExecutionDesk] ([ExecutionDeskId])
GO
ALTER TABLE [book].[ExecutionTypeMapping] CHECK CONSTRAINT [FK_ExecutionTypeMapping_ExecutionDesk]
GO
ALTER TABLE [book].[ExecutionTypeMapping]  WITH NOCHECK ADD  CONSTRAINT [FK_ExecutionTypeMapping_ExecutionType] FOREIGN KEY([ExecutionTypeId])
REFERENCES [book].[ExecutionType] ([ExecutionTypeId])
GO
ALTER TABLE [book].[ExecutionTypeMapping] CHECK CONSTRAINT [FK_ExecutionTypeMapping_ExecutionType]
GO
ALTER TABLE [book].[FutureSwap]  WITH NOCHECK ADD  CONSTRAINT [FK_FutureSwap_ExecutionBroker] FOREIGN KEY([ExecutionBrokerId])
REFERENCES [book].[Counterparty] ([CounterpartyId])
GO
ALTER TABLE [book].[FutureSwap] CHECK CONSTRAINT [FK_FutureSwap_ExecutionBroker]
GO
ALTER TABLE [book].[Instrument]  WITH NOCHECK ADD  CONSTRAINT [FK_Instrument_GenericFuture] FOREIGN KEY([GenericFutureId])
REFERENCES [book].[Instrument] ([InstrumentId])
GO
ALTER TABLE [book].[Instrument] CHECK CONSTRAINT [FK_Instrument_GenericFuture]
GO
ALTER TABLE [book].[OrderAllocation]  WITH NOCHECK ADD  CONSTRAINT [FK_OrderAllocation_Order] FOREIGN KEY([OrderId])
REFERENCES [book].[Order] ([OrderId])
ON DELETE CASCADE
GO
ALTER TABLE [book].[OrderAllocation] CHECK CONSTRAINT [FK_OrderAllocation_Order]
GO
ALTER TABLE [book].[Position]  WITH NOCHECK ADD  CONSTRAINT [FK_Position_Instrument] FOREIGN KEY([InstrumentId])
REFERENCES [book].[Instrument] ([InstrumentId])
GO
ALTER TABLE [book].[Position] CHECK CONSTRAINT [FK_Position_Instrument]
GO
ALTER TABLE [book].[Position]  WITH NOCHECK ADD  CONSTRAINT [FK_Position_Portfolio] FOREIGN KEY([PortfolioId])
REFERENCES [book].[Portfolio] ([PortfolioId])
GO
ALTER TABLE [book].[Position] CHECK CONSTRAINT [FK_Position_Portfolio]
GO
ALTER TABLE [book].[RawTradeAllocation]  WITH NOCHECK ADD  CONSTRAINT [FK_RawTradeAllocation_RawTrade] FOREIGN KEY([TradeId])
REFERENCES [book].[RawTrade] ([TradeId])
ON DELETE CASCADE
GO
ALTER TABLE [book].[RawTradeAllocation] CHECK CONSTRAINT [FK_RawTradeAllocation_RawTrade]
GO
ALTER TABLE [book].[SettlementInfo]  WITH NOCHECK ADD  CONSTRAINT [FK_SettlementInfo_Counterparty] FOREIGN KEY([CounterpartyId])
REFERENCES [book].[Counterparty] ([CounterpartyId])
GO
ALTER TABLE [book].[SettlementInfo] CHECK CONSTRAINT [FK_SettlementInfo_Counterparty]
GO
ALTER TABLE [book].[SettlementInfo]  WITH NOCHECK ADD  CONSTRAINT [FK_SettlementInfo_Instrument] FOREIGN KEY([InstrumentId])
REFERENCES [book].[Instrument] ([InstrumentId])
GO
ALTER TABLE [book].[SettlementInfo] CHECK CONSTRAINT [FK_SettlementInfo_Instrument]
GO
ALTER TABLE [book].[TradeAllocation]  WITH NOCHECK ADD  CONSTRAINT [FK_TradeAllocation_Trade] FOREIGN KEY([TradeId])
REFERENCES [book].[Trade] ([TradeId])
ON DELETE CASCADE
GO
ALTER TABLE [book].[TradeAllocation] CHECK CONSTRAINT [FK_TradeAllocation_Trade]
GO
ALTER TABLE [book].[TradeBookingError]  WITH NOCHECK ADD  CONSTRAINT [FK_TradeBookingError_RawTrade] FOREIGN KEY([TradeId])
REFERENCES [book].[RawTrade] ([TradeId])
ON DELETE CASCADE
GO
ALTER TABLE [book].[TradeBookingError] CHECK CONSTRAINT [FK_TradeBookingError_RawTrade]
GO
ALTER TABLE [conv].[InstrumentMapping]  WITH NOCHECK ADD  CONSTRAINT [FK_InstrumentMapping_FromInstrument] FOREIGN KEY([FromInstrumentId])
REFERENCES [conv].[Instrument] ([InstrumentId])
GO
ALTER TABLE [conv].[InstrumentMapping] CHECK CONSTRAINT [FK_InstrumentMapping_FromInstrument]
GO
ALTER TABLE [conv].[InstrumentMapping]  WITH NOCHECK ADD  CONSTRAINT [FK_InstrumentMapping_InstrumentMappingType] FOREIGN KEY([InstrumentMappingTypeId])
REFERENCES [conv].[InstrumentMappingType] ([InstrumentMappingTypeId])
ON DELETE CASCADE
GO
ALTER TABLE [conv].[InstrumentMapping] CHECK CONSTRAINT [FK_InstrumentMapping_InstrumentMappingType]
GO
ALTER TABLE [conv].[InstrumentMapping]  WITH NOCHECK ADD  CONSTRAINT [FK_InstrumentMapping_ToInstrument] FOREIGN KEY([ToInstrumentId])
REFERENCES [conv].[Instrument] ([InstrumentId])
GO
ALTER TABLE [conv].[InstrumentMapping] CHECK CONSTRAINT [FK_InstrumentMapping_ToInstrument]
GO
ALTER TABLE [conv].[TargetWeightConversion]  WITH NOCHECK ADD  CONSTRAINT [FK_TargetWeightConversion_FromInstrument] FOREIGN KEY([FromInstrumentId])
REFERENCES [conv].[Instrument] ([InstrumentId])
GO
ALTER TABLE [conv].[TargetWeightConversion] CHECK CONSTRAINT [FK_TargetWeightConversion_FromInstrument]
GO
ALTER TABLE [conv].[TargetWeightConversion]  WITH NOCHECK ADD  CONSTRAINT [FK_TargetWeightConversion_TargetAllocationConversion] FOREIGN KEY([TargetAllocationConversionId])
REFERENCES [conv].[TargetAllocationConversion] ([TargetAllocationConversionId])
GO
ALTER TABLE [conv].[TargetWeightConversion] CHECK CONSTRAINT [FK_TargetWeightConversion_TargetAllocationConversion]
GO
ALTER TABLE [conv].[TargetWeightConversion]  WITH NOCHECK ADD  CONSTRAINT [FK_TargetWeightConversion_ToInstrument] FOREIGN KEY([ToInstrumentId])
REFERENCES [conv].[Instrument] ([InstrumentId])
GO
ALTER TABLE [conv].[TargetWeightConversion] CHECK CONSTRAINT [FK_TargetWeightConversion_ToInstrument]
GO
ALTER TABLE [efrp].[EfrpConversionRule]  WITH NOCHECK ADD  CONSTRAINT [FK_EfrpConversionRule_Broker] FOREIGN KEY([BrokerId])
REFERENCES [efrp].[Broker] ([BrokerId])
GO
ALTER TABLE [efrp].[EfrpConversionRule] CHECK CONSTRAINT [FK_EfrpConversionRule_Broker]
GO
ALTER TABLE [efrp].[EfrpConversionRule]  WITH NOCHECK ADD  CONSTRAINT [FK_EfrpConversionRule_GenericFuture] FOREIGN KEY([GenericFutureId])
REFERENCES [efrp].[GenericFuture] ([GenericFutureId])
GO
ALTER TABLE [efrp].[EfrpConversionRule] CHECK CONSTRAINT [FK_EfrpConversionRule_GenericFuture]
GO
ALTER TABLE [efrp].[FutureContract]  WITH NOCHECK ADD  CONSTRAINT [FK_FutureContract_GenericFuture] FOREIGN KEY([GenericFutureId])
REFERENCES [efrp].[GenericFuture] ([GenericFutureId])
ON DELETE CASCADE
GO
ALTER TABLE [efrp].[FutureContract] CHECK CONSTRAINT [FK_FutureContract_GenericFuture]
GO
ALTER TABLE [instr].[CurrencyPair]  WITH NOCHECK ADD  CONSTRAINT [FK_CurrencyPair_BaseCurrency] FOREIGN KEY([BaseCurrencyId])
REFERENCES [instr].[Currency] ([CurrencyId])
GO
ALTER TABLE [instr].[CurrencyPair] CHECK CONSTRAINT [FK_CurrencyPair_BaseCurrency]
GO
ALTER TABLE [instr].[CurrencyPair]  WITH NOCHECK ADD  CONSTRAINT [FK_CurrencyPair_Instrument] FOREIGN KEY([CurrencyPairId])
REFERENCES [instr].[Instrument] ([InstrumentId])
ON DELETE CASCADE
GO
ALTER TABLE [instr].[CurrencyPair] CHECK CONSTRAINT [FK_CurrencyPair_Instrument]
GO
ALTER TABLE [instr].[CurrencyPair]  WITH NOCHECK ADD  CONSTRAINT [FK_CurrencyPair_QuoteCurrency] FOREIGN KEY([QuoteCurrencyId])
REFERENCES [instr].[Currency] ([CurrencyId])
GO
ALTER TABLE [instr].[CurrencyPair] CHECK CONSTRAINT [FK_CurrencyPair_QuoteCurrency]
GO
ALTER TABLE [instr].[FutureContract]  WITH NOCHECK ADD  CONSTRAINT [FK_FutureContract_FutureContractMonth] FOREIGN KEY([FutureContractMonthId])
REFERENCES [instr].[FutureContractMonth] ([FutureContractMonthId])
GO
ALTER TABLE [instr].[FutureContract] CHECK CONSTRAINT [FK_FutureContract_FutureContractMonth]
GO
ALTER TABLE [instr].[FutureContract]  WITH NOCHECK ADD  CONSTRAINT [FK_FutureContract_GenericFuture] FOREIGN KEY([GenericFutureId])
REFERENCES [instr].[GenericFuture] ([GenericFutureId])
GO
ALTER TABLE [instr].[FutureContract] CHECK CONSTRAINT [FK_FutureContract_GenericFuture]
GO
ALTER TABLE [instr].[FutureContract]  WITH NOCHECK ADD  CONSTRAINT [FK_FutureContract_Instrument] FOREIGN KEY([FutureContractId])
REFERENCES [instr].[Instrument] ([InstrumentId])
ON DELETE CASCADE
GO
ALTER TABLE [instr].[FutureContract] CHECK CONSTRAINT [FK_FutureContract_Instrument]
GO
ALTER TABLE [instr].[FxForward]  WITH NOCHECK ADD  CONSTRAINT [FK_FxForward_CurrencyPair] FOREIGN KEY([CurrencyPairId])
REFERENCES [instr].[CurrencyPair] ([CurrencyPairId])
GO
ALTER TABLE [instr].[FxForward] CHECK CONSTRAINT [FK_FxForward_CurrencyPair]
GO
ALTER TABLE [instr].[FxForward]  WITH NOCHECK ADD  CONSTRAINT [FK_FxForward_Instrument] FOREIGN KEY([FxForwardId])
REFERENCES [instr].[Instrument] ([InstrumentId])
ON DELETE CASCADE
GO
ALTER TABLE [instr].[FxForward] CHECK CONSTRAINT [FK_FxForward_Instrument]
GO
ALTER TABLE [instr].[GenericFuture]  WITH NOCHECK ADD  CONSTRAINT [FK_GenericFuture_Instrument] FOREIGN KEY([GenericFutureId])
REFERENCES [instr].[Instrument] ([InstrumentId])
ON DELETE CASCADE
GO
ALTER TABLE [instr].[GenericFuture] CHECK CONSTRAINT [FK_GenericFuture_Instrument]
GO
ALTER TABLE [instr].[Instrument]  WITH NOCHECK ADD  CONSTRAINT [FK_Instrument_Country] FOREIGN KEY([CountryId])
REFERENCES [instr].[Country] ([CountryId])
GO
ALTER TABLE [instr].[Instrument] CHECK CONSTRAINT [FK_Instrument_Country]
GO
ALTER TABLE [instr].[Instrument]  WITH NOCHECK ADD  CONSTRAINT [FK_Instrument_Currency] FOREIGN KEY([CurrencyId])
REFERENCES [instr].[Currency] ([CurrencyId])
GO
ALTER TABLE [instr].[Instrument] CHECK CONSTRAINT [FK_Instrument_Currency]
GO
ALTER TABLE [instr].[Instrument]  WITH NOCHECK ADD  CONSTRAINT [FK_Instrument_Exchange] FOREIGN KEY([ExchangeId])
REFERENCES [instr].[Exchange] ([ExchangeId])
GO
ALTER TABLE [instr].[Instrument] CHECK CONSTRAINT [FK_Instrument_Exchange]
GO
ALTER TABLE [instr].[Instrument]  WITH NOCHECK ADD  CONSTRAINT [FK_Instrument_IndustryGroup] FOREIGN KEY([IndustryGroupId])
REFERENCES [instr].[IndustryGroup] ([IndustryGroupId])
GO
ALTER TABLE [instr].[Instrument] CHECK CONSTRAINT [FK_Instrument_IndustryGroup]
GO
ALTER TABLE [instr].[Instrument]  WITH NOCHECK ADD  CONSTRAINT [FK_Instrument_IndustrySector] FOREIGN KEY([IndustrySectorId])
REFERENCES [instr].[IndustrySector] ([IndustrySectorId])
GO
ALTER TABLE [instr].[Instrument] CHECK CONSTRAINT [FK_Instrument_IndustrySector]
GO
ALTER TABLE [instr].[Instrument]  WITH NOCHECK ADD  CONSTRAINT [FK_Instrument_InstrumentType] FOREIGN KEY([InstrumentTypeId])
REFERENCES [instr].[InstrumentType] ([InstrumentTypeId])
GO
ALTER TABLE [instr].[Instrument] CHECK CONSTRAINT [FK_Instrument_InstrumentType]
GO
ALTER TABLE [instr].[Instrument]  WITH NOCHECK ADD  CONSTRAINT [FK_Instrument_MarketSector] FOREIGN KEY([MarketSectorId])
REFERENCES [instr].[MarketSector] ([MarketSectorId])
GO
ALTER TABLE [instr].[Instrument] CHECK CONSTRAINT [FK_Instrument_MarketSector]
GO
ALTER TABLE [instr].[Instrument]  WITH NOCHECK ADD  CONSTRAINT [FK_Instrument_PrimaryMIC] FOREIGN KEY([PrimaryMICId])
REFERENCES [instr].[MIC] ([MICId])
GO
ALTER TABLE [instr].[Instrument] CHECK CONSTRAINT [FK_Instrument_PrimaryMIC]
GO
ALTER TABLE [instr].[Instrument]  WITH NOCHECK ADD  CONSTRAINT [FK_Instrument_QuoteCurrency] FOREIGN KEY([QuoteCurrencyId])
REFERENCES [instr].[Currency] ([CurrencyId])
GO
ALTER TABLE [instr].[Instrument] CHECK CONSTRAINT [FK_Instrument_QuoteCurrency]
GO
ALTER TABLE [instr].[Instrument]  WITH NOCHECK ADD  CONSTRAINT [FK_Instrument_SecurityType] FOREIGN KEY([SecurityTypeId])
REFERENCES [instr].[SecurityType] ([SecurityTypeId])
GO
ALTER TABLE [instr].[Instrument] CHECK CONSTRAINT [FK_Instrument_SecurityType]
GO
ALTER TABLE [instr].[Instrument]  WITH NOCHECK ADD  CONSTRAINT [FK_Instrument_SecurityType2] FOREIGN KEY([SecurityType2Id])
REFERENCES [instr].[SecurityType2] ([SecurityType2Id])
GO
ALTER TABLE [instr].[Instrument] CHECK CONSTRAINT [FK_Instrument_SecurityType2]
GO
ALTER TABLE [mktdata].[MarketData]  WITH NOCHECK ADD  CONSTRAINT [FK_MarketData_Instrument] FOREIGN KEY([InstrumentId])
REFERENCES [mktdata].[Instrument] ([InstrumentId])
ON DELETE CASCADE
GO
ALTER TABLE [mktdata].[MarketData] CHECK CONSTRAINT [FK_MarketData_Instrument]
GO
ALTER TABLE [mktdata].[VolumeData]  WITH NOCHECK ADD  CONSTRAINT [FK_VolumeData_Instrument] FOREIGN KEY([InstrumentId])
REFERENCES [mktdata].[Instrument] ([InstrumentId])
ON DELETE CASCADE
GO
ALTER TABLE [mktdata].[VolumeData] CHECK CONSTRAINT [FK_VolumeData_Instrument]
GO
ALTER TABLE [ord].[BrokerSelectionRule]  WITH NOCHECK ADD  CONSTRAINT [FK_BrokerSelectionRule_Broker] FOREIGN KEY([BrokerId])
REFERENCES [ord].[Broker] ([BrokerId])
ON DELETE CASCADE
GO
ALTER TABLE [ord].[BrokerSelectionRule] CHECK CONSTRAINT [FK_BrokerSelectionRule_Broker]
GO
ALTER TABLE [ord].[BrokerSelectionRule]  WITH NOCHECK ADD  CONSTRAINT [FK_BrokerSelectionRule_InstrumentType] FOREIGN KEY([InstrumentTypeId])
REFERENCES [ord].[InstrumentType] ([InstrumentTypeId])
ON DELETE CASCADE
GO
ALTER TABLE [ord].[BrokerSelectionRule] CHECK CONSTRAINT [FK_BrokerSelectionRule_InstrumentType]
GO
ALTER TABLE [ord].[BrokerSelectionRule]  WITH NOCHECK ADD  CONSTRAINT [FK_BrokerSelectionRule_Portfolio] FOREIGN KEY([PortfolioId])
REFERENCES [ord].[Portfolio] ([PortfolioId])
ON DELETE CASCADE
GO
ALTER TABLE [ord].[BrokerSelectionRule] CHECK CONSTRAINT [FK_BrokerSelectionRule_Portfolio]
GO
ALTER TABLE [ord].[BrokerSelectionRuleOverride]  WITH NOCHECK ADD  CONSTRAINT [FK_BrokerSelectionRuleOverride_Broker] FOREIGN KEY([BrokerId])
REFERENCES [ord].[Broker] ([BrokerId])
ON DELETE CASCADE
GO
ALTER TABLE [ord].[BrokerSelectionRuleOverride] CHECK CONSTRAINT [FK_BrokerSelectionRuleOverride_Broker]
GO
ALTER TABLE [ord].[BrokerSelectionRuleOverride]  WITH NOCHECK ADD  CONSTRAINT [FK_BrokerSelectionRuleOverride_Instrument] FOREIGN KEY([InstrumentId])
REFERENCES [ord].[Instrument] ([InstrumentId])
ON DELETE CASCADE
GO
ALTER TABLE [ord].[BrokerSelectionRuleOverride] CHECK CONSTRAINT [FK_BrokerSelectionRuleOverride_Instrument]
GO
ALTER TABLE [ord].[BrokerSelectionRuleOverride]  WITH NOCHECK ADD  CONSTRAINT [FK_BrokerSelectionRuleOverride_Portfolio] FOREIGN KEY([PortfolioId])
REFERENCES [ord].[Portfolio] ([PortfolioId])
ON DELETE CASCADE
GO
ALTER TABLE [ord].[BrokerSelectionRuleOverride] CHECK CONSTRAINT [FK_BrokerSelectionRuleOverride_Portfolio]
GO
ALTER TABLE [ord].[ExecutionAlgorithmParamSet]  WITH NOCHECK ADD  CONSTRAINT [FK_ExecutionAlgorithmParamSet_ExecutionAlgorithm] FOREIGN KEY([ExecutionAlgorithmId])
REFERENCES [ord].[ExecutionAlgorithm] ([ExecutionAlgorithmId])
GO
ALTER TABLE [ord].[ExecutionAlgorithmParamSet] CHECK CONSTRAINT [FK_ExecutionAlgorithmParamSet_ExecutionAlgorithm]
GO
ALTER TABLE [ord].[ExecutionProfile]  WITH NOCHECK ADD  CONSTRAINT [FK_ExecutionProfile_ExecutionAlgorithm] FOREIGN KEY([ExecutionAlgorithmId])
REFERENCES [ord].[ExecutionAlgorithm] ([ExecutionAlgorithmId])
GO
ALTER TABLE [ord].[ExecutionProfile] CHECK CONSTRAINT [FK_ExecutionProfile_ExecutionAlgorithm]
GO
ALTER TABLE [ord].[ExecutionProfile]  WITH NOCHECK ADD  CONSTRAINT [FK_ExecutionProfile_ExecutionAlgorithmParamSet] FOREIGN KEY([ExecutionAlgorithmParamSetId])
REFERENCES [ord].[ExecutionAlgorithmParamSet] ([ExecutionAlgorithmParamSetId])
GO
ALTER TABLE [ord].[ExecutionProfile] CHECK CONSTRAINT [FK_ExecutionProfile_ExecutionAlgorithmParamSet]
GO
ALTER TABLE [ord].[ExecutionProfile]  WITH NOCHECK ADD  CONSTRAINT [FK_ExecutionProfile_ExecutionChannel] FOREIGN KEY([ExecutionChannelId])
REFERENCES [ord].[ExecutionChannel] ([ExecutionChannelId])
GO
ALTER TABLE [ord].[ExecutionProfile] CHECK CONSTRAINT [FK_ExecutionProfile_ExecutionChannel]
GO
ALTER TABLE [ord].[ExecutionProfile]  WITH NOCHECK ADD  CONSTRAINT [FK_ExecutionProfile_HandlingInstruction] FOREIGN KEY([HandlingInstructionId])
REFERENCES [ord].[HandlingInstruction] ([HandlingInstructionId])
GO
ALTER TABLE [ord].[ExecutionProfile] CHECK CONSTRAINT [FK_ExecutionProfile_HandlingInstruction]
GO
ALTER TABLE [ord].[ExecutionProfile]  WITH NOCHECK ADD  CONSTRAINT [FK_ExecutionProfile_OrderType] FOREIGN KEY([OrderTypeId])
REFERENCES [ord].[OrderType] ([OrderTypeId])
GO
ALTER TABLE [ord].[ExecutionProfile] CHECK CONSTRAINT [FK_ExecutionProfile_OrderType]
GO
ALTER TABLE [ord].[ExecutionProfile]  WITH NOCHECK ADD  CONSTRAINT [FK_ExecutionProfile_TimeInForce] FOREIGN KEY([TimeInForceId])
REFERENCES [ord].[TimeInForce] ([TimeInForceId])
GO
ALTER TABLE [ord].[ExecutionProfile] CHECK CONSTRAINT [FK_ExecutionProfile_TimeInForce]
GO
ALTER TABLE [ord].[ExecutionProfile]  WITH NOCHECK ADD  CONSTRAINT [FK_ExecutionProfile_TradingDesk] FOREIGN KEY([TradingDeskId])
REFERENCES [ord].[TradingDesk] ([TradingDeskId])
GO
ALTER TABLE [ord].[ExecutionProfile] CHECK CONSTRAINT [FK_ExecutionProfile_TradingDesk]
GO
ALTER TABLE [ord].[ExecutionProfileSelectionRule]  WITH NOCHECK ADD  CONSTRAINT [FK_ExecutionProfileSelectionRule_Broker] FOREIGN KEY([BrokerId])
REFERENCES [ord].[Broker] ([BrokerId])
ON DELETE CASCADE
GO
ALTER TABLE [ord].[ExecutionProfileSelectionRule] NOCHECK CONSTRAINT [FK_ExecutionProfileSelectionRule_Broker]
GO
ALTER TABLE [ord].[ExecutionProfileSelectionRule]  WITH NOCHECK ADD  CONSTRAINT [FK_ExecutionProfileSelectionRule_Exchange] FOREIGN KEY([ExchangeId])
REFERENCES [ord].[Exchange] ([ExchangeId])
ON DELETE CASCADE
GO
ALTER TABLE [ord].[ExecutionProfileSelectionRule] CHECK CONSTRAINT [FK_ExecutionProfileSelectionRule_Exchange]
GO
ALTER TABLE [ord].[ExecutionProfileSelectionRule]  WITH NOCHECK ADD  CONSTRAINT [FK_ExecutionProfileSelectionRule_ExecutionProfile] FOREIGN KEY([ExecutionProfileId])
REFERENCES [ord].[ExecutionProfile] ([ExecutionProfileId])
ON DELETE CASCADE
GO
ALTER TABLE [ord].[ExecutionProfileSelectionRule] CHECK CONSTRAINT [FK_ExecutionProfileSelectionRule_ExecutionProfile]
GO
ALTER TABLE [ord].[ExecutionProfileSelectionRule]  WITH NOCHECK ADD  CONSTRAINT [FK_ExecutionProfileSelectionRule_InstrumentType] FOREIGN KEY([InstrumentTypeId])
REFERENCES [ord].[InstrumentType] ([InstrumentTypeId])
ON DELETE CASCADE
GO
ALTER TABLE [ord].[ExecutionProfileSelectionRule] CHECK CONSTRAINT [FK_ExecutionProfileSelectionRule_InstrumentType]
GO
ALTER TABLE [ord].[ExecutionProfileSelectionRule]  WITH NOCHECK ADD  CONSTRAINT [FK_ExecutionProfileSelectionRule_Portfolio] FOREIGN KEY([PortfolioId])
REFERENCES [ord].[Portfolio] ([PortfolioId])
ON DELETE CASCADE
GO
ALTER TABLE [ord].[ExecutionProfileSelectionRule] CHECK CONSTRAINT [FK_ExecutionProfileSelectionRule_Portfolio]
GO
ALTER TABLE [ord].[ExecutionProfileSelectionRule]  WITH NOCHECK ADD  CONSTRAINT [FK_ExecutionProfileSelectionRule_TradeMode] FOREIGN KEY([TradeModeId])
REFERENCES [ord].[TradeMode] ([TradeModeId])
ON DELETE CASCADE
GO
ALTER TABLE [ord].[ExecutionProfileSelectionRule] CHECK CONSTRAINT [FK_ExecutionProfileSelectionRule_TradeMode]
GO
ALTER TABLE [ord].[ExecutionProfileSelectionRuleOverride]  WITH NOCHECK ADD  CONSTRAINT [FK_ExecutionProfileSelectionRuleOverride_Broker] FOREIGN KEY([BrokerId])
REFERENCES [ord].[Broker] ([BrokerId])
ON DELETE CASCADE
GO
ALTER TABLE [ord].[ExecutionProfileSelectionRuleOverride] NOCHECK CONSTRAINT [FK_ExecutionProfileSelectionRuleOverride_Broker]
GO
ALTER TABLE [ord].[ExecutionProfileSelectionRuleOverride]  WITH NOCHECK ADD  CONSTRAINT [FK_ExecutionProfileSelectionRuleOverride_ExecutionProfile] FOREIGN KEY([ExecutionProfileId])
REFERENCES [ord].[ExecutionProfile] ([ExecutionProfileId])
ON DELETE CASCADE
GO
ALTER TABLE [ord].[ExecutionProfileSelectionRuleOverride] CHECK CONSTRAINT [FK_ExecutionProfileSelectionRuleOverride_ExecutionProfile]
GO
ALTER TABLE [ord].[ExecutionProfileSelectionRuleOverride]  WITH NOCHECK ADD  CONSTRAINT [FK_ExecutionProfileSelectionRuleOverride_Instrument] FOREIGN KEY([InstrumentId])
REFERENCES [ord].[Instrument] ([InstrumentId])
ON DELETE CASCADE
GO
ALTER TABLE [ord].[ExecutionProfileSelectionRuleOverride] CHECK CONSTRAINT [FK_ExecutionProfileSelectionRuleOverride_Instrument]
GO
ALTER TABLE [ord].[ExecutionProfileSelectionRuleOverride]  WITH NOCHECK ADD  CONSTRAINT [FK_ExecutionProfileSelectionRuleOverride_Portfolio] FOREIGN KEY([PortfolioId])
REFERENCES [ord].[Portfolio] ([PortfolioId])
ON DELETE CASCADE
GO
ALTER TABLE [ord].[ExecutionProfileSelectionRuleOverride] CHECK CONSTRAINT [FK_ExecutionProfileSelectionRuleOverride_Portfolio]
GO
ALTER TABLE [ord].[ExecutionProfileSelectionRuleOverride]  WITH NOCHECK ADD  CONSTRAINT [FK_ExecutionProfileSelectionRuleOverride_TradeMode] FOREIGN KEY([TradeModeId])
REFERENCES [ord].[TradeMode] ([TradeModeId])
ON DELETE CASCADE
GO
ALTER TABLE [ord].[ExecutionProfileSelectionRuleOverride] CHECK CONSTRAINT [FK_ExecutionProfileSelectionRuleOverride_TradeMode]
GO
ALTER TABLE [ord].[Instrument]  WITH NOCHECK ADD  CONSTRAINT [FK_Instrument_Exchange] FOREIGN KEY([ExchangeId])
REFERENCES [ord].[Exchange] ([ExchangeId])
GO
ALTER TABLE [ord].[Instrument] CHECK CONSTRAINT [FK_Instrument_Exchange]
GO
ALTER TABLE [ord].[Instrument]  WITH NOCHECK ADD  CONSTRAINT [FK_Instrument_InstrumentType] FOREIGN KEY([InstrumentTypeId])
REFERENCES [ord].[InstrumentType] ([InstrumentTypeId])
GO
ALTER TABLE [ord].[Instrument] CHECK CONSTRAINT [FK_Instrument_InstrumentType]
GO
ALTER TABLE [ord].[Order]  WITH NOCHECK ADD  CONSTRAINT [FK_Order_Broker] FOREIGN KEY([BrokerId])
REFERENCES [ord].[Broker] ([BrokerId])
GO
ALTER TABLE [ord].[Order] NOCHECK CONSTRAINT [FK_Order_Broker]
GO
ALTER TABLE [ord].[Order]  WITH NOCHECK ADD  CONSTRAINT [FK_Order_ExecutionAlgorithm] FOREIGN KEY([ExecutionAlgorithmId])
REFERENCES [ord].[ExecutionAlgorithm] ([ExecutionAlgorithmId])
GO
ALTER TABLE [ord].[Order] CHECK CONSTRAINT [FK_Order_ExecutionAlgorithm]
GO
ALTER TABLE [ord].[Order]  WITH NOCHECK ADD  CONSTRAINT [FK_Order_ExecutionChannel] FOREIGN KEY([ExecutionChannelId])
REFERENCES [ord].[ExecutionChannel] ([ExecutionChannelId])
GO
ALTER TABLE [ord].[Order] CHECK CONSTRAINT [FK_Order_ExecutionChannel]
GO
ALTER TABLE [ord].[Order]  WITH NOCHECK ADD  CONSTRAINT [FK_Order_HandlingInstruction] FOREIGN KEY([HandlingInstructionId])
REFERENCES [ord].[HandlingInstruction] ([HandlingInstructionId])
GO
ALTER TABLE [ord].[Order] CHECK CONSTRAINT [FK_Order_HandlingInstruction]
GO
ALTER TABLE [ord].[Order]  WITH NOCHECK ADD  CONSTRAINT [FK_Order_Instrument] FOREIGN KEY([InstrumentId])
REFERENCES [ord].[Instrument] ([InstrumentId])
GO
ALTER TABLE [ord].[Order] CHECK CONSTRAINT [FK_Order_Instrument]
GO
ALTER TABLE [ord].[Order]  WITH NOCHECK ADD  CONSTRAINT [FK_Order_OrderSide] FOREIGN KEY([OrderSideId])
REFERENCES [ord].[OrderSide] ([OrderSideId])
GO
ALTER TABLE [ord].[Order] CHECK CONSTRAINT [FK_Order_OrderSide]
GO
ALTER TABLE [ord].[Order]  WITH NOCHECK ADD  CONSTRAINT [FK_Order_OrderType] FOREIGN KEY([OrderTypeId])
REFERENCES [ord].[OrderType] ([OrderTypeId])
GO
ALTER TABLE [ord].[Order] CHECK CONSTRAINT [FK_Order_OrderType]
GO
ALTER TABLE [ord].[Order]  WITH NOCHECK ADD  CONSTRAINT [FK_Order_TimeInForce] FOREIGN KEY([TimeInForceId])
REFERENCES [ord].[TimeInForce] ([TimeInForceId])
GO
ALTER TABLE [ord].[Order] CHECK CONSTRAINT [FK_Order_TimeInForce]
GO
ALTER TABLE [ord].[Order]  WITH NOCHECK ADD  CONSTRAINT [FK_Order_TradeMode] FOREIGN KEY([TradeModeId])
REFERENCES [ord].[TradeMode] ([TradeModeId])
GO
ALTER TABLE [ord].[Order] CHECK CONSTRAINT [FK_Order_TradeMode]
GO
ALTER TABLE [ord].[Order]  WITH NOCHECK ADD  CONSTRAINT [FK_Order_TradingDesk] FOREIGN KEY([TradingDeskId])
REFERENCES [ord].[TradingDesk] ([TradingDeskId])
GO
ALTER TABLE [ord].[Order] CHECK CONSTRAINT [FK_Order_TradingDesk]
GO
ALTER TABLE [ord].[OrderAllocation]  WITH NOCHECK ADD  CONSTRAINT [FK_OrderAllocation_Order] FOREIGN KEY([OrderId])
REFERENCES [ord].[Order] ([OrderId])
ON DELETE CASCADE
GO
ALTER TABLE [ord].[OrderAllocation] CHECK CONSTRAINT [FK_OrderAllocation_Order]
GO
ALTER TABLE [ord].[OrderAllocation]  WITH NOCHECK ADD  CONSTRAINT [FK_OrderAllocation_Portfolio] FOREIGN KEY([PortfolioId])
REFERENCES [ord].[Portfolio] ([PortfolioId])
GO
ALTER TABLE [ord].[OrderAllocation] CHECK CONSTRAINT [FK_OrderAllocation_Portfolio]
GO
ALTER TABLE [ord].[OrderAllocation]  WITH NOCHECK ADD  CONSTRAINT [FK_OrderAllocation_PositionSide] FOREIGN KEY([PositionSideId])
REFERENCES [ord].[PositionSide] ([PositionSideId])
GO
ALTER TABLE [ord].[OrderAllocation] CHECK CONSTRAINT [FK_OrderAllocation_PositionSide]
GO
ALTER TABLE [ord].[OrderAllocation]  WITH NOCHECK ADD  CONSTRAINT [FK_OrderAllocation_TradingAccount] FOREIGN KEY([TradingAccountId])
REFERENCES [ord].[TradingAccount] ([TradingAccountId])
GO
ALTER TABLE [ord].[OrderAllocation] CHECK CONSTRAINT [FK_OrderAllocation_TradingAccount]
GO
ALTER TABLE [ord].[TradeModeSelectionRule]  WITH NOCHECK ADD  CONSTRAINT [FK_TradeModeSelectionRule_Broker] FOREIGN KEY([BrokerId])
REFERENCES [ord].[Broker] ([BrokerId])
ON DELETE CASCADE
GO
ALTER TABLE [ord].[TradeModeSelectionRule] NOCHECK CONSTRAINT [FK_TradeModeSelectionRule_Broker]
GO
ALTER TABLE [ord].[TradeModeSelectionRule]  WITH NOCHECK ADD  CONSTRAINT [FK_TradeModeSelectionRule_InstrumentType] FOREIGN KEY([InstrumentTypeId])
REFERENCES [ord].[InstrumentType] ([InstrumentTypeId])
ON DELETE CASCADE
GO
ALTER TABLE [ord].[TradeModeSelectionRule] CHECK CONSTRAINT [FK_TradeModeSelectionRule_InstrumentType]
GO
ALTER TABLE [ord].[TradeModeSelectionRule]  WITH NOCHECK ADD  CONSTRAINT [FK_TradeModeSelectionRule_Portfolio] FOREIGN KEY([PortfolioId])
REFERENCES [ord].[Portfolio] ([PortfolioId])
ON DELETE CASCADE
GO
ALTER TABLE [ord].[TradeModeSelectionRule] CHECK CONSTRAINT [FK_TradeModeSelectionRule_Portfolio]
GO
ALTER TABLE [ord].[TradeModeSelectionRule]  WITH NOCHECK ADD  CONSTRAINT [FK_TradeModeSelectionRule_TradeMode] FOREIGN KEY([TradeModeId])
REFERENCES [ord].[TradeMode] ([TradeModeId])
ON DELETE CASCADE
GO
ALTER TABLE [ord].[TradeModeSelectionRule] CHECK CONSTRAINT [FK_TradeModeSelectionRule_TradeMode]
GO
ALTER TABLE [ord].[TradingAccountSelectionRule]  WITH NOCHECK ADD  CONSTRAINT [FK_TradingAccountSelectionRule_Broker] FOREIGN KEY([BrokerId])
REFERENCES [ord].[Broker] ([BrokerId])
ON DELETE CASCADE
GO
ALTER TABLE [ord].[TradingAccountSelectionRule] NOCHECK CONSTRAINT [FK_TradingAccountSelectionRule_Broker]
GO
ALTER TABLE [ord].[TradingAccountSelectionRule]  WITH NOCHECK ADD  CONSTRAINT [FK_TradingAccountSelectionRule_InstrumentType] FOREIGN KEY([InstrumentTypeId])
REFERENCES [ord].[InstrumentType] ([InstrumentTypeId])
ON DELETE CASCADE
GO
ALTER TABLE [ord].[TradingAccountSelectionRule] CHECK CONSTRAINT [FK_TradingAccountSelectionRule_InstrumentType]
GO
ALTER TABLE [ord].[TradingAccountSelectionRule]  WITH NOCHECK ADD  CONSTRAINT [FK_TradingAccountSelectionRule_Portfolio] FOREIGN KEY([PortfolioId])
REFERENCES [ord].[Portfolio] ([PortfolioId])
ON DELETE CASCADE
GO
ALTER TABLE [ord].[TradingAccountSelectionRule] CHECK CONSTRAINT [FK_TradingAccountSelectionRule_Portfolio]
GO
ALTER TABLE [ord].[TradingAccountSelectionRule]  WITH NOCHECK ADD  CONSTRAINT [FK_TradingAccountSelectionRule_TradeMode] FOREIGN KEY([TradeModeId])
REFERENCES [ord].[TradeMode] ([TradeModeId])
ON DELETE CASCADE
GO
ALTER TABLE [ord].[TradingAccountSelectionRule] CHECK CONSTRAINT [FK_TradingAccountSelectionRule_TradeMode]
GO
ALTER TABLE [ord].[TradingAccountSelectionRule]  WITH NOCHECK ADD  CONSTRAINT [FK_TradingAccountSelectionRule_TradingAccount] FOREIGN KEY([TradingAccountId])
REFERENCES [ord].[TradingAccount] ([TradingAccountId])
ON DELETE CASCADE
GO
ALTER TABLE [ord].[TradingAccountSelectionRule] CHECK CONSTRAINT [FK_TradingAccountSelectionRule_TradingAccount]
GO
ALTER TABLE [ord].[TradingDesk]  WITH NOCHECK ADD  CONSTRAINT [FK_TradingDesk_Broker] FOREIGN KEY([BrokerId])
REFERENCES [ord].[Broker] ([BrokerId])
GO
ALTER TABLE [ord].[TradingDesk] CHECK CONSTRAINT [FK_TradingDesk_Broker]
GO
ALTER TABLE [port].[BookedTradeAllocation]  WITH NOCHECK ADD  CONSTRAINT [FK_BookedTradeAllocation_Instrument] FOREIGN KEY([InstrumentId])
REFERENCES [port].[Instrument] ([InstrumentId])
GO
ALTER TABLE [port].[BookedTradeAllocation] CHECK CONSTRAINT [FK_BookedTradeAllocation_Instrument]
GO
ALTER TABLE [port].[BookedTradeAllocation]  WITH NOCHECK ADD  CONSTRAINT [FK_BookedTradeAllocation_Portfolio] FOREIGN KEY([PortfolioId])
REFERENCES [port].[Portfolio] ([PortfolioId])
ON DELETE CASCADE
GO
ALTER TABLE [port].[BookedTradeAllocation] CHECK CONSTRAINT [FK_BookedTradeAllocation_Portfolio]
GO
ALTER TABLE [port].[Position]  WITH NOCHECK ADD  CONSTRAINT [FK_TestPosition_Portfolio] FOREIGN KEY([PortfolioId])
REFERENCES [port].[Portfolio] ([PortfolioId])
ON DELETE CASCADE
GO
ALTER TABLE [port].[Position] CHECK CONSTRAINT [FK_TestPosition_Portfolio]
GO
ALTER TABLE [port].[TradeAllocation]  WITH NOCHECK ADD  CONSTRAINT [FK_TradeAllocation_Instrument] FOREIGN KEY([InstrumentId])
REFERENCES [port].[Instrument] ([InstrumentId])
GO
ALTER TABLE [port].[TradeAllocation] CHECK CONSTRAINT [FK_TradeAllocation_Instrument]
GO
ALTER TABLE [port].[TradeAllocation]  WITH NOCHECK ADD  CONSTRAINT [FK_TradeAllocation_Portfolio] FOREIGN KEY([PortfolioId])
REFERENCES [port].[Portfolio] ([PortfolioId])
ON DELETE CASCADE
GO
ALTER TABLE [port].[TradeAllocation] CHECK CONSTRAINT [FK_TradeAllocation_Portfolio]
GO
ALTER TABLE [port].[ZZZ_Position]  WITH NOCHECK ADD  CONSTRAINT [FK_Position_Portfolio] FOREIGN KEY([PortfolioId])
REFERENCES [port].[Portfolio] ([PortfolioId])
ON DELETE CASCADE
GO
ALTER TABLE [port].[ZZZ_Position] CHECK CONSTRAINT [FK_Position_Portfolio]
GO
ALTER TABLE [pos].[Position]  WITH NOCHECK ADD  CONSTRAINT [FK_Position_Instrument] FOREIGN KEY([InstrumentId])
REFERENCES [pos].[Instrument] ([InstrumentId])
GO
ALTER TABLE [pos].[Position] CHECK CONSTRAINT [FK_Position_Instrument]
GO
ALTER TABLE [rebal].[PositionDrift]  WITH NOCHECK ADD  CONSTRAINT [FK_PositionDrift_PortfolioDrift] FOREIGN KEY([PortfolioDriftId])
REFERENCES [rebal].[PortfolioDrift] ([PortfolioDriftId])
ON DELETE CASCADE
GO
ALTER TABLE [rebal].[PositionDrift] CHECK CONSTRAINT [FK_PositionDrift_PortfolioDrift]
GO
ALTER TABLE [rebal].[PositionValuation]  WITH NOCHECK ADD  CONSTRAINT [FK_PositionValuation_PortfolioValuation] FOREIGN KEY([PortfolioValuationId])
REFERENCES [rebal].[PortfolioValuation] ([PortfolioValuationId])
ON DELETE CASCADE
GO
ALTER TABLE [rebal].[PositionValuation] CHECK CONSTRAINT [FK_PositionValuation_PortfolioValuation]
GO
ALTER TABLE [rebal].[RebalancingSessionPortfolioDrift]  WITH NOCHECK ADD  CONSTRAINT [FK_RebalancingSessionPortfolioDrift_PortfolioDrift] FOREIGN KEY([PortfolioDriftId])
REFERENCES [rebal].[PortfolioDrift] ([PortfolioDriftId])
ON DELETE CASCADE
GO
ALTER TABLE [rebal].[RebalancingSessionPortfolioDrift] CHECK CONSTRAINT [FK_RebalancingSessionPortfolioDrift_PortfolioDrift]
GO
ALTER TABLE [rebal].[RebalancingSessionPortfolioDrift]  WITH NOCHECK ADD  CONSTRAINT [FK_RebalancingSessionPortfolioDrift_RebalancingSession] FOREIGN KEY([RebalancingSessionId])
REFERENCES [rebal].[RebalancingSession] ([RebalancingSessionId])
ON DELETE CASCADE
GO
ALTER TABLE [rebal].[RebalancingSessionPortfolioDrift] CHECK CONSTRAINT [FK_RebalancingSessionPortfolioDrift_RebalancingSession]
GO
ALTER TABLE [rebal].[TargetWeightValuation]  WITH NOCHECK ADD  CONSTRAINT [FK_TargetWeightValuation_TargetAllocationValuation] FOREIGN KEY([TargetAllocationValuationId])
REFERENCES [rebal].[TargetAllocationValuation] ([TargetAllocationValuationId])
ON DELETE CASCADE
GO
ALTER TABLE [rebal].[TargetWeightValuation] CHECK CONSTRAINT [FK_TargetWeightValuation_TargetAllocationValuation]
GO
ALTER TABLE [risk].[Constraint]  WITH NOCHECK ADD  CONSTRAINT [FK_Constraint_ConstraintType] FOREIGN KEY([ConstraintTypeId])
REFERENCES [risk].[ConstraintType] ([ConstraintTypeId])
GO
ALTER TABLE [risk].[Constraint] CHECK CONSTRAINT [FK_Constraint_ConstraintType]
GO
ALTER TABLE [risk].[Constraint]  WITH NOCHECK ADD  CONSTRAINT [FK_Constraint_Filter] FOREIGN KEY([FilterId])
REFERENCES [risk].[Filter] ([FilterId])
GO
ALTER TABLE [risk].[Constraint] CHECK CONSTRAINT [FK_Constraint_Filter]
GO
ALTER TABLE [risk].[Constraint]  WITH NOCHECK ADD  CONSTRAINT [FK_Constraint_RelationalOperator] FOREIGN KEY([RelationalOperatorId])
REFERENCES [risk].[RelationalOperator] ([RelationalOperatorId])
GO
ALTER TABLE [risk].[Constraint] CHECK CONSTRAINT [FK_Constraint_RelationalOperator]
GO
ALTER TABLE [risk].[ConstraintBreach]  WITH NOCHECK ADD  CONSTRAINT [FK_ConstraintBreach_Constraint] FOREIGN KEY([ConstraintId])
REFERENCES [risk].[Constraint] ([ConstraintId])
GO
ALTER TABLE [risk].[ConstraintBreach] CHECK CONSTRAINT [FK_ConstraintBreach_Constraint]
GO
ALTER TABLE [risk].[ConstraintBreach]  WITH NOCHECK ADD  CONSTRAINT [FK_ConstraintBreach_TargetAllocationCheck] FOREIGN KEY([TargetAllocationCheckId])
REFERENCES [risk].[TargetAllocationCheck] ([TargetAllocationCheckId])
GO
ALTER TABLE [risk].[ConstraintBreach] CHECK CONSTRAINT [FK_ConstraintBreach_TargetAllocationCheck]
GO
ALTER TABLE [risk].[Filter]  WITH NOCHECK ADD  CONSTRAINT [FK_Filter_BooleanOperator] FOREIGN KEY([BooleanOperatorId])
REFERENCES [risk].[BooleanOperator] ([BooleanOperatorId])
GO
ALTER TABLE [risk].[Filter] CHECK CONSTRAINT [FK_Filter_BooleanOperator]
GO
ALTER TABLE [risk].[Filter]  WITH NOCHECK ADD  CONSTRAINT [FK_Filter_FilterCriterion1] FOREIGN KEY([FilterCriterion1Id])
REFERENCES [risk].[FilterCriterion] ([FilterCriterionId])
GO
ALTER TABLE [risk].[Filter] CHECK CONSTRAINT [FK_Filter_FilterCriterion1]
GO
ALTER TABLE [risk].[Filter]  WITH NOCHECK ADD  CONSTRAINT [FK_Filter_FilterCriterion2] FOREIGN KEY([FilterCriterion2Id])
REFERENCES [risk].[FilterCriterion] ([FilterCriterionId])
GO
ALTER TABLE [risk].[Filter] CHECK CONSTRAINT [FK_Filter_FilterCriterion2]
GO
ALTER TABLE [risk].[FilterCriterion]  WITH NOCHECK ADD  CONSTRAINT [FK_FilterCriterion_FilterOperator] FOREIGN KEY([FilterOperatorId])
REFERENCES [risk].[FilterOperator] ([FilterOperatorId])
GO
ALTER TABLE [risk].[FilterCriterion] CHECK CONSTRAINT [FK_FilterCriterion_FilterOperator]
GO
ALTER TABLE [risk].[FilterCriterion]  WITH NOCHECK ADD  CONSTRAINT [FK_FilterCriterion_FilterParty] FOREIGN KEY([FilterPartyId], [FilterPartyTypeId])
REFERENCES [risk].[FilterParty] ([FilterPartyId], [FilterPartyTypeId])
GO
ALTER TABLE [risk].[FilterCriterion] CHECK CONSTRAINT [FK_FilterCriterion_FilterParty]
GO
ALTER TABLE [risk].[FilterCriterion]  WITH NOCHECK ADD  CONSTRAINT [FK_FilterCriterion_FilterPartyType] FOREIGN KEY([FilterPartyTypeId])
REFERENCES [risk].[FilterPartyType] ([FilterPartyTypeId])
GO
ALTER TABLE [risk].[FilterCriterion] CHECK CONSTRAINT [FK_FilterCriterion_FilterPartyType]
GO
ALTER TABLE [risk].[PortfolioConstraint]  WITH NOCHECK ADD  CONSTRAINT [FK_PortfolioConstraint_Constraint] FOREIGN KEY([ConstraintId])
REFERENCES [risk].[Constraint] ([ConstraintId])
ON DELETE CASCADE
GO
ALTER TABLE [risk].[PortfolioConstraint] CHECK CONSTRAINT [FK_PortfolioConstraint_Constraint]
GO
ALTER TABLE [risk].[PortfolioConstraint]  WITH NOCHECK ADD  CONSTRAINT [FK_PortfolioConstraint_Portfolio] FOREIGN KEY([PortfolioId])
REFERENCES [risk].[Portfolio] ([PortfolioId])
ON DELETE CASCADE
GO
ALTER TABLE [risk].[PortfolioConstraint] CHECK CONSTRAINT [FK_PortfolioConstraint_Portfolio]
GO
ALTER TABLE [trans].[ClearingAccountCodeMapping]  WITH NOCHECK ADD  CONSTRAINT [FK_ClearingAccountCodeMapping_Counterparty] FOREIGN KEY([CounterpartyId])
REFERENCES [trans].[Counterparty] ([CounterpartyId])
GO
ALTER TABLE [trans].[ClearingAccountCodeMapping] CHECK CONSTRAINT [FK_ClearingAccountCodeMapping_Counterparty]
GO
ALTER TABLE [trans].[ClearingBrokerCodeMapping]  WITH NOCHECK ADD  CONSTRAINT [FK_ClearingBrokerCodeMapping_FileGenerationType] FOREIGN KEY([FileGenerationTypeId])
REFERENCES [trans].[FileGenerationType] ([FileGenerationTypeId])
GO
ALTER TABLE [trans].[ClearingBrokerCodeMapping] CHECK CONSTRAINT [FK_ClearingBrokerCodeMapping_FileGenerationType]
GO
ALTER TABLE [trans].[CustodianCodeMapping]  WITH NOCHECK ADD  CONSTRAINT [FK_CustodianCodeMapping_FileGenerationType] FOREIGN KEY([FileGenerationTypeId])
REFERENCES [trans].[FileGenerationType] ([FileGenerationTypeId])
GO
ALTER TABLE [trans].[CustodianCodeMapping] CHECK CONSTRAINT [FK_CustodianCodeMapping_FileGenerationType]
GO
ALTER TABLE [trans].[ExecutionAccountCodeMapping]  WITH NOCHECK ADD  CONSTRAINT [FK_ExecutionAccountCodeMapping_Counterparty] FOREIGN KEY([CounterpartyId])
REFERENCES [trans].[Counterparty] ([CounterpartyId])
GO
ALTER TABLE [trans].[ExecutionAccountCodeMapping] CHECK CONSTRAINT [FK_ExecutionAccountCodeMapping_Counterparty]
GO
ALTER TABLE [trans].[ExecutionBrokerCodeMapping]  WITH NOCHECK ADD  CONSTRAINT [FK_ExecutionBrokerCodeMapping_FileGenerationType] FOREIGN KEY([FileGenerationTypeId])
REFERENCES [trans].[FileGenerationType] ([FileGenerationTypeId])
GO
ALTER TABLE [trans].[ExecutionBrokerCodeMapping] CHECK CONSTRAINT [FK_ExecutionBrokerCodeMapping_FileGenerationType]
GO
ALTER TABLE [trans].[FileGenerationProfile]  WITH NOCHECK ADD  CONSTRAINT [FK_FileGenerationProfile_FileGenerationType] FOREIGN KEY([FileGenerationTypeId])
REFERENCES [trans].[FileGenerationType] ([FileGenerationTypeId])
GO
ALTER TABLE [trans].[FileGenerationProfile] CHECK CONSTRAINT [FK_FileGenerationProfile_FileGenerationType]
GO
ALTER TABLE [trans].[FileGenerationProfile]  WITH NOCHECK ADD  CONSTRAINT [FK_FileGenerationProfile_TransmissionProfile] FOREIGN KEY([TransmissionProfileId])
REFERENCES [trans].[TransmissionProfile] ([TransmissionProfileId])
ON DELETE CASCADE
GO
ALTER TABLE [trans].[FileGenerationProfile] CHECK CONSTRAINT [FK_FileGenerationProfile_TransmissionProfile]
GO
ALTER TABLE [trans].[InstrumentPricing]  WITH NOCHECK ADD  CONSTRAINT [FK_InstrumentPricing_Instrument] FOREIGN KEY([InstrumentId])
REFERENCES [trans].[Instrument] ([InstrumentId])
ON DELETE CASCADE
GO
ALTER TABLE [trans].[InstrumentPricing] CHECK CONSTRAINT [FK_InstrumentPricing_Instrument]
GO
ALTER TABLE [trans].[Trade]  WITH NOCHECK ADD  CONSTRAINT [FK_Trade_Instrument] FOREIGN KEY([InstrumentId])
REFERENCES [trans].[Instrument] ([InstrumentId])
GO
ALTER TABLE [trans].[Trade] CHECK CONSTRAINT [FK_Trade_Instrument]
GO
ALTER TABLE [trans].[TradeAllocation]  WITH NOCHECK ADD  CONSTRAINT [FK_TradeAllocation_Trade] FOREIGN KEY([TradeId])
REFERENCES [trans].[Trade] ([TradeId])
ON DELETE CASCADE
GO
ALTER TABLE [trans].[TradeAllocation] CHECK CONSTRAINT [FK_TradeAllocation_Trade]
GO
ALTER TABLE [trans].[TransmissionProfile]  WITH NOCHECK ADD  CONSTRAINT [FK_TransmissionProfile_CounterParty] FOREIGN KEY([CounterPartyId])
REFERENCES [trans].[Counterparty] ([CounterpartyId])
GO
ALTER TABLE [trans].[TransmissionProfile] CHECK CONSTRAINT [FK_TransmissionProfile_CounterParty]
GO
ALTER TABLE [trans].[TransmissionProfile]  WITH NOCHECK ADD  CONSTRAINT [FK_TransmissionProfile_EmailConfiguration] FOREIGN KEY([EmailConfigurationId])
REFERENCES [trans].[EmailConfiguration] ([EmailConfigurationId])
GO
ALTER TABLE [trans].[TransmissionProfile] CHECK CONSTRAINT [FK_TransmissionProfile_EmailConfiguration]
GO
ALTER TABLE [trans].[TransmissionProfile]  WITH NOCHECK ADD  CONSTRAINT [FK_TransmissionProfile_EncryptionProfile] FOREIGN KEY([EncryptionProfileId])
REFERENCES [trans].[EncryptionProfile] ([EncryptionProfileId])
GO
ALTER TABLE [trans].[TransmissionProfile] CHECK CONSTRAINT [FK_TransmissionProfile_EncryptionProfile]
GO
ALTER TABLE [trans].[TransmissionProfile]  WITH NOCHECK ADD  CONSTRAINT [FK_TransmissionProfile_FileContentType] FOREIGN KEY([FileContentTypeId])
REFERENCES [trans].[FileContentType] ([FileContentTypeId])
GO
ALTER TABLE [trans].[TransmissionProfile] CHECK CONSTRAINT [FK_TransmissionProfile_FileContentType]
GO
ALTER TABLE [trans].[TransmissionProfile]  WITH NOCHECK ADD  CONSTRAINT [FK_TransmissionProfile_FtpConfiguration] FOREIGN KEY([FtpConfigurationId])
REFERENCES [trans].[FtpConfiguration] ([FtpConfigurationId])
GO
ALTER TABLE [trans].[TransmissionProfile] CHECK CONSTRAINT [FK_TransmissionProfile_FtpConfiguration]
GO
ALTER TABLE [trans].[TransmissionProfile]  WITH NOCHECK ADD  CONSTRAINT [FK_TransmissionProfile_TransmissionScheduleType] FOREIGN KEY([TransmissionScheduleTypeId])
REFERENCES [trans].[TransmissionScheduleType] ([TransmissionScheduleTypeId])
GO
ALTER TABLE [trans].[TransmissionProfile] CHECK CONSTRAINT [FK_TransmissionProfile_TransmissionScheduleType]
GO
ALTER TABLE [trans].[TransmittedFile]  WITH NOCHECK ADD  CONSTRAINT [FK_TransmittedFile_FileTransmission] FOREIGN KEY([FileTransmissionId])
REFERENCES [trans].[FileTransmission] ([FileTransmissionId])
GO
ALTER TABLE [trans].[TransmittedFile] CHECK CONSTRAINT [FK_TransmittedFile_FileTransmission]
GO
ALTER TABLE [trd].[StgTradeAllocToBook]  WITH NOCHECK ADD  CONSTRAINT [FK_StgTradeAllocToBook_StgTradeToBook] FOREIGN KEY([StgTradeToBookId])
REFERENCES [trd].[StgTradeToBook] ([StgTradeToBookId])
ON DELETE CASCADE
GO
ALTER TABLE [trd].[StgTradeAllocToBook] CHECK CONSTRAINT [FK_StgTradeAllocToBook_StgTradeToBook]
GO
ALTER TABLE [trd].[StgTradeToBook]  WITH NOCHECK ADD  CONSTRAINT [FK_StgTradeToBook_Instrument] FOREIGN KEY([InstrumentId])
REFERENCES [trd].[Instrument] ([InstrumentId])
GO
ALTER TABLE [trd].[StgTradeToBook] CHECK CONSTRAINT [FK_StgTradeToBook_Instrument]
GO
ALTER TABLE [trd].[Trade]  WITH NOCHECK ADD  CONSTRAINT [FK_Trade_Instrument] FOREIGN KEY([InstrumentId])
REFERENCES [trd].[Instrument] ([InstrumentId])
ON DELETE CASCADE
GO
ALTER TABLE [trd].[Trade] CHECK CONSTRAINT [FK_Trade_Instrument]
GO
ALTER TABLE [trd].[TradeAllocation]  WITH NOCHECK ADD  CONSTRAINT [FK_TradeAllocation_Trade] FOREIGN KEY([TradeId])
REFERENCES [trd].[Trade] ([TradeId])
ON DELETE CASCADE
GO
ALTER TABLE [trd].[TradeAllocation] CHECK CONSTRAINT [FK_TradeAllocation_Trade]
GO
ALTER TABLE [trd].[TradeFill]  WITH NOCHECK ADD  CONSTRAINT [FK_TradeFill_Trade] FOREIGN KEY([TradeId])
REFERENCES [trd].[Trade] ([TradeId])
ON DELETE CASCADE
GO
ALTER TABLE [trd].[TradeFill] CHECK CONSTRAINT [FK_TradeFill_Trade]
GO
ALTER TABLE [val].[FutureContract]  WITH NOCHECK ADD  CONSTRAINT [FK_FutureContract_Instrument] FOREIGN KEY([FutureContractId])
REFERENCES [val].[Instrument] ([InstrumentId])
ON DELETE CASCADE
GO
ALTER TABLE [val].[FutureContract] CHECK CONSTRAINT [FK_FutureContract_Instrument]
GO
ALTER TABLE [val].[InstrumentPricing]  WITH NOCHECK ADD  CONSTRAINT [FK_InstrumentPricing_Instrument] FOREIGN KEY([InstrumentId])
REFERENCES [val].[Instrument] ([InstrumentId])
ON DELETE CASCADE
GO
ALTER TABLE [val].[InstrumentPricing] CHECK CONSTRAINT [FK_InstrumentPricing_Instrument]
GO
ALTER TABLE [val].[Position]  WITH NOCHECK ADD  CONSTRAINT [FK_Position_Instrument] FOREIGN KEY([InstrumentId])
REFERENCES [val].[Instrument] ([InstrumentId])
GO
ALTER TABLE [val].[Position] CHECK CONSTRAINT [FK_Position_Instrument]
GO
ALTER TABLE [val].[Position]  WITH NOCHECK ADD  CONSTRAINT [FK_Position_Portfolio] FOREIGN KEY([PortfolioId])
REFERENCES [val].[Portfolio] ([PortfolioId])
ON DELETE CASCADE
GO
ALTER TABLE [val].[Position] CHECK CONSTRAINT [FK_Position_Portfolio]
GO
ALTER TABLE [val].[PositionValuation]  WITH NOCHECK ADD  CONSTRAINT [FK_PositionValuation_PortfolioValuation] FOREIGN KEY([PortfolioValuationId])
REFERENCES [val].[PortfolioValuation] ([PortfolioValuationId])
ON DELETE CASCADE
GO
ALTER TABLE [val].[PositionValuation] CHECK CONSTRAINT [FK_PositionValuation_PortfolioValuation]
GO
ALTER TABLE [val].[TargetAllocation]  WITH NOCHECK ADD  CONSTRAINT [FK_TargetAllocation_Portfolio] FOREIGN KEY([PortfolioId])
REFERENCES [val].[Portfolio] ([PortfolioId])
ON DELETE CASCADE
GO
ALTER TABLE [val].[TargetAllocation] CHECK CONSTRAINT [FK_TargetAllocation_Portfolio]
GO
ALTER TABLE [val].[TargetWeight]  WITH NOCHECK ADD  CONSTRAINT [FK_TargetWeight_Instrument] FOREIGN KEY([InstrumentId])
REFERENCES [val].[Instrument] ([InstrumentId])
ON DELETE CASCADE
GO
ALTER TABLE [val].[TargetWeight] CHECK CONSTRAINT [FK_TargetWeight_Instrument]
GO
ALTER TABLE [val].[TargetWeight]  WITH NOCHECK ADD  CONSTRAINT [FK_TargetWeight_TargetAllocation] FOREIGN KEY([TargetAllocationId])
REFERENCES [val].[TargetAllocation] ([TargetAllocationId])
ON DELETE CASCADE
GO
ALTER TABLE [val].[TargetWeight] CHECK CONSTRAINT [FK_TargetWeight_TargetAllocation]
GO
ALTER TABLE [val].[TargetWeightValuation]  WITH NOCHECK ADD  CONSTRAINT [FK_TargetWeightValuation_TargetAllocationValuation] FOREIGN KEY([TargetAllocationValuationId])
REFERENCES [val].[TargetAllocationValuation] ([TargetAllocationValuationId])
ON DELETE CASCADE
GO
ALTER TABLE [val].[TargetWeightValuation] CHECK CONSTRAINT [FK_TargetWeightValuation_TargetAllocationValuation]
GO
ALTER TABLE [wght].[TargetWeight]  WITH NOCHECK ADD  CONSTRAINT [FK_TargetWeight_Instrument] FOREIGN KEY([InstrumentId])
REFERENCES [wght].[Instrument] ([InstrumentId])
GO
ALTER TABLE [wght].[TargetWeight] CHECK CONSTRAINT [FK_TargetWeight_Instrument]
GO
ALTER TABLE [wght].[TargetWeight]  WITH NOCHECK ADD  CONSTRAINT [FK_TargetWeight_TargetAllocation] FOREIGN KEY([TargetAllocationId])
REFERENCES [wght].[TargetAllocation] ([TargetAllocationId])
ON DELETE CASCADE
GO
ALTER TABLE [wght].[TargetWeight] CHECK CONSTRAINT [FK_TargetWeight_TargetAllocation]
GO
/****** Object:  StoredProcedure [book].[sp1MigrateRawTrades]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [book].[sp1MigrateRawTrades]
AS
BEGIN
delete from book.RawTrade;

SET IDENTITY_INSERT book.RawTrade ON;
INSERT into book.RawTrade(
[TradeId]
      ,[Symbol]
      ,[Side]
      ,[Quantity]
      ,[AvgPrice]
      ,[Currency]
      ,[TradeDate]
      ,[Exchange]
      ,[ExecutionBroker]
      ,[ExecutionAccount]
      ,[ExecutionDesk]
      ,[IsCFD]
      ,[Cusip]
      ,[Isin]
      ,[Sedol]
      ,[SecurityName]
      ,[LocalExchangeSymbol]
      ,[ExecutionChannel]
      ,[EmsxOrderId]
      ,[OrderReferenceId]
      ,[OrderQuantity]
      ,[OrderType]
      ,[StrategyType]
      ,[Tif]
      ,[OrderExecutionInstruction]
      ,[OrderHandlingInstruction]
      ,[OrderInstruction]
      ,[LimitPrice]
      ,[StopPrice]
      ,[OriginatingTraderUUId]
      ,[TraderName]
      ,[TraderUUId]
      ,[SettlementDate]
      ,[UserCommissionAmount]
      ,[UserCommissionRate]
      ,[UserFees]
      ,[UserNetMoney]
      ,[YellowKey]
      ,[NumberOfFills]
      ,[FirstFillTimeUtc]
      ,[LastFillTimeUtc]
      ,[MaxFillPrice]
      ,[MinFillPrice]
)

SELECT 
		trd.TradeId
		,trd.[Symbol]
	   ,[BuySellIndicator] as [Side]
	   ,[FilledQuantity] as Quantity
	   ,[AvgPrice]
	   ,[TradeCurrency] as [Currency]
	   ,[TradeDate]
	   ,[ExchangeCode] as Exchange
	   ,[BrokerCode] as [ExecutionBroker]
	   ,[TradingAccount] as [ExecutionAccount]
	   ,[TradeDesk] as [ExecutionDesk]
	   , IsCfd as [IsCFD]
	   , null as [Cusip]
	   ,i.ISIN as Isin
	   ,trd.Sedol
	   ,i.Name as [SecurityName]
	   ,null as [LocalExchangeSymbol]
	   ,trd.ExecutionChannel
	   ,trd.EmsxSequence as [EmsxOrderId]
	   ,trd.OrderId as [OrderReferenceId]
	   ,trd.OrderQuantity 
	   ,'MKT' as OrderType
	   ,null as [StrategyType]
      ,'DAY' as [Tif]
      ,null as [OrderExecutionInstruction]
      ,null as[OrderHandlingInstruction]
      ,null as[OrderInstruction]
      ,null as[LimitPrice]
      ,null as[StopPrice]
	  ,null as [OriginatingTraderUUId]
      ,Trader as [TraderName]
      , CASE WHEN Trader = 'AFRASER77' THEN 31853626
				WHEN Trader like 'PH%'THEN 31934002
				ELSE null end  as [TraderUUId]
	,trd.SettlementDate
	,null as[UserCommissionAmount]
      ,null as[UserCommissionRate]
      ,null as[UserFees]
      ,null as[UserNetMoney]
	   ,i.MarketSectorDes AS [YellowKey]
      ,null as [NumberOfFills]
      ,null as [FirstFillTimeUtc]
      ,null as [LastFillTimeUtc]
      ,null as [MaxFillPrice]
      ,null as [MinFillPrice]
  FROM [trd].[vwTradeAllocation] trd
  JOIn instr.vwInstrument i on i.InstrumentId = trd.InstrumentId
  order by TradeId

  SET IDENTITY_INSERT book.RawTrade OFF;

   update  [book].[RawTrade]
  set ExecutionChannel = 'FXEM'
  where ExecutionChannel = 'FXGO'
END
GO
/****** Object:  StoredProcedure [book].[sp2MigrateRawTradeAllocations]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [book].[sp2MigrateRawTradeAllocations]
AS
BEGIN
delete from book.[RawTradeAllocation];

SET IDENTITY_INSERT book.[RawTradeAllocation] ON;
INSERT INTO book.RawTradeAllocation(
	TradeAllocationId
      ,[TradeId]
      ,[PortfolioId]
      ,[AllocatedQuantity]
      ,[OrderAllocationQuantity]
      ,[PositionSide])

SELECT 
TradeAllocationId
,[TradeId]  
	  ,[PortfolioId]

	  ,[FilledQuantity] as AllocatedQuantity
	  ,[OrderQuantity] as OrderAllocationQuantity
	   ,ISNULL([PositionSide], 'L')   
  FROM [trd].[vwTradeAllocation]
  order by [TradeAllocationId]
    SET IDENTITY_INSERT book.[RawTradeAllocation] OFF;
END
GO
/****** Object:  StoredProcedure [book].[sp3MigrateBookedTrades]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [book].[sp3MigrateBookedTrades]
AS
BEGIN
delete from book.Trade;


with bookedtrades as (
SELECT 
		trd.TradeId
		,'NEW' as TradeStatus
		,trd.InstrumentId
		,trd.Symbol
	   ,[BuySellIndicator] as [TradeSide]
	   ,[FilledQuantity] as TradeQuantity
	   ,ISNULL(fc.PointValue*[FilledQuantity], [FilledQuantity]) as [NominalQuantity]
	   ,[TradeCurrency]
	   ,[TradeDate]
	   ,[ExchangeCode] as Exchange
	    ,trd.ExecutionChannel
		,IIF([ExchangeCode] like 'LME','VOICE', 'ELEC') as ExecutionType
		,IIF(fs.GenericFutureId IS NOT null or trd.IsCfd=1 ,1,0) as IsSwap
		,trd.RebalancingId
		,ISNULL(fc.PointValue, 1) as ContractMultiplier
		,i.PriceScalingFactor
		,trd.[AvgPrice]
		,trd.Principal
		,trd.AvgPrice*trd.FilledQuantity as [TradeValue]
		,i.InstrumentType
		,CASE WHEN i.InstrumentType = 'EQU' THEN 'EQUSWAP'
				WHEN fs.GenericFutureId IS NOT null THEN 'FUTSWAP'
					WHEN fc.FutureContractId IS NOT null or i.InstrumentType  like 'FUT' THEN 'FUT'
				ELSE  'FXFWD' end as [TradeInstrumentType]
	   ,[TradeDesk] as [ExecutionDesk]	  
	   ,'MS' as [ExecutionBroker]
	   ,[TradingAccount] as [ExecutionAccount]
	     ,i.ISIN as Isin
	   ,trd.Sedol
	   , null as [Cusip]
	   ,i.Name as [SecurityName]
	   	 ,null as [LocalExchangeSymbol]
		 	,trd.SettlementDate
	 ,trd.EmsxSequence as [EmsxOrderId]
	  ,trd.OrderId as [OrderReferenceId]
	   ,trd.OrderQuantity 		  	  	  
	   ,'MKT' as OrderType
	   ,null as [StrategyType]
      ,'DAY' as [TimeInForce]
      ,null as [OrderExecutionInstruction]
      ,null as[OrderHandlingInstruction]
      ,null as[OrderInstruction]
      ,null as[LimitPrice]
      ,null as[StopPrice]
	  ,null as [OriginatingTraderUUId]
      ,Trader as [TraderName]
      , CASE WHEN Trader = 'AFRASER77' THEN 31853626
				WHEN Trader like 'PH%'THEN 31934002
				ELSE null end  as [TraderUUId]

	,null as[UserCommissionAmount]
      ,null as[UserCommissionRate]
      ,null as[UserFees]
      ,null as[UserNetMoney]
	   ,i.MarketSectorDes AS [YellowKey]
      ,null as [NumberOfFills]
      ,null as [FirstFillTimeUtc]
      ,null as [LastFillTimeUtc]
      ,null as [MaxFillPrice]
      ,null as [MinFillPrice]
	  ,trd.BookedOn AT TIME ZONE 'Central European Standard Time' AT TIME ZONE 'UTC' as [BookedOnUtc]
	  ,null as [LastCorrectedOnUtc]
	  , null as [CanceledOnUtc]
  FROM [trd].[vwTradeAllocation] trd
  LEFT JOIn instr.vwInstrument i on i.InstrumentId = trd.InstrumentId
  LEFT JOIN instr.vwFutureContract fc on  fc.FutureContractId = trd.InstrumentId
  LEFT JOIN trd.FutureSwap fs on  fs.GenericFutureId = fc.GenericFutureId
)
insert into book.Trade (
[TradeId]
      ,[TradeStatus]
      ,[InstrumentId]
      ,[Symbol]
      ,[TradeSide]
      ,[TradeQuantity]
      ,[NominalQuantity]
      ,[TradeCurrency]
      ,[TradeDate]
      ,[Exchange]
      ,[ExecutionChannel]
      ,[ExecutionType]
      ,[IsSwap]
      ,[RebalancingId]
      ,[ContractMultiplier]
      ,[PriceScalingFactor]
      ,[AvgPrice]
      ,[Principal]
      ,[TradeValue]
      ,[InstrumentType]
      ,[TradeInstrumentType]
      ,[ExecutionDesk]
      ,[ExecutionBroker]
      ,[ExecutionAccount]
      ,[Isin]
      ,[Sedol]
      ,[Cusip]
      ,[SecurityName]
      ,[LocalExchangeSymbol]
      ,[SettlementDate]
      ,[EmsxOrderId]
      ,[OrderReferenceId]
      ,[OrderQuantity]
      ,[OrderType]
      ,[StrategyType]
      ,[TimeInForce]
      ,[OrderExecutionInstruction]
      ,[OrderHandlingInstruction]
      ,[OrderInstruction]
      ,[LimitPrice]
      ,[StopPrice]
      ,[OriginatingTraderUUId]
      ,[TraderName]
      ,[TraderUUId]
      ,[UserCommissionAmount]
      ,[UserCommissionRate]
      ,[UserFees]
      ,[UserNetMoney]
      ,[YellowKey]
      ,[NumberOfFills]
      ,[FirstFillTimeUtc]
      ,[LastFillTimeUtc]
      ,[MaxFillPrice]
      ,[MinFillPrice]
      ,[BookedOnUtc]
      ,[LastCorrectedOnUtc]
      ,[CanceledOnUtc]

)

select [TradeId]
      ,[TradeStatus]
      ,[InstrumentId]
      ,[Symbol]
      ,[TradeSide]
      ,[TradeQuantity]
      ,[NominalQuantity]
      ,[TradeCurrency]
      ,[TradeDate]
      ,[Exchange]
      ,[ExecutionChannel]
      ,[ExecutionType]
      ,[IsSwap]
      ,[RebalancingId]
      ,[ContractMultiplier]
      ,[PriceScalingFactor]
      ,[AvgPrice]
      ,[Principal]
      ,[TradeValue]
      ,[InstrumentType]
      ,[TradeInstrumentType]
      ,[ExecutionDesk]
      ,[ExecutionBroker]
      ,[ExecutionAccount]
      ,[Isin]
      ,[Sedol]
      ,[Cusip]
      ,[SecurityName]
      ,[LocalExchangeSymbol]
      ,[SettlementDate]
      ,[EmsxOrderId]
      ,[OrderReferenceId]
      ,[OrderQuantity]
      ,[OrderType]
      ,[StrategyType]
      ,[TimeInForce]
      ,[OrderExecutionInstruction]
      ,[OrderHandlingInstruction]
      ,[OrderInstruction]
      ,[LimitPrice]
      ,[StopPrice]
      ,[OriginatingTraderUUId]
      ,[TraderName]
      ,[TraderUUId]
      ,[UserCommissionAmount]
      ,[UserCommissionRate]
      ,[UserFees]
      ,[UserNetMoney]
      ,[YellowKey]
      ,[NumberOfFills]
      ,[FirstFillTimeUtc]
      ,[LastFillTimeUtc]
      ,[MaxFillPrice]
      ,[MinFillPrice]
      ,[BookedOnUtc]
      ,[LastCorrectedOnUtc]
      ,[CanceledOnUtc] from bookedtrades 
	  order by TradeId

  
END
GO
/****** Object:  StoredProcedure [book].[sp4MigrateBookedTradeAllocsWorkInProgress]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [book].[sp4MigrateBookedTradeAllocsWorkInProgress]
AS
BEGIN
delete from book.TradeAllocation;

with commissions as(
 select [TradeAllocationId]
 ,IIF([CommissionRate] IS not null and [CommissionRate] <> 0, [CommissionRate], BrokerCommission/FilledQuantity) as [CommissionValue]
   ,IIF([CommissionRate] IS not null and [CommissionRate] <> 0, 'R', 'L') as [CommissionType]

	 FROM [trd].[vwTradeAllocation] trd	

), eodfxrates as (

SELECT 
    [BaseCurrency],
    [QuoteCurrency],
    [Date],
	[Value],
    LAG([Value]) OVER (PARTITION BY [BaseCurrency], [QuoteCurrency] ORDER BY [Date]) AS [PrevValue]


    
FROM 
    [book].[FxRate]

), settlementCcy as (
SELECT [InstrumentId]
    
      ,[SettleCurrency]
  
  FROM [book].[SettlementInfo]
)

, withcommissions as (


SELECT  trd.[TradeAllocationId]
      ,trd.[TradeId]
	  ,'NEW' as [TradeStatus]
	  ,[PortfolioId]
      ,[PositionSide]
	  ,[FilledQuantity] as [Quantity]
	  ,ISNULL(trd.[FilledQuantity] * fc.PointValue,trd.[FilledQuantity]) as [NominalQuantity]
	  ,trd.[OrderQuantity] as [OrderAllocationQuantity]
	   ,ISNULL(trd.[OrderQuantity] * fc.PointValue,trd.[OrderQuantity]) as [OrderAllocationNominalQuantity]
	   	,ISNULL(fc.PointValue, 1) as ContractMultiplier
		,IIF(trd2.ExecutionAccount = 'MS1EFRP','USD', trd.TradeCurrency) as LocalCurrency
		,'USD' as BaseCurrency
		,IIF(fs.GenericFutureId IS NOT null or trd.IsCfd=1 ,1,0) as IsSwap
		,
		IIF(i.InstrumentType ='FXFWD','USD',  ISNULL(trd.SettlementCurrency,ISNULL(sc.[SettleCurrency], trd.TradeCurrency))) as SettlementCurrency
		,com.CommissionValue as [CommissionValue]
		,com.CommissionType [CommissionType]
		, trd.AvgPrice as [GrossAvgPriceLocal]
		,IIF(com.CommissionType ='R', trd.AvgPrice*[CommissionRate], ABS(com.CommissionValue))as [PriceCommissionLocal]
		,IIF(com.CommissionType ='R', trd.AvgPrice+(trd.AvgPrice*[CommissionRate]), trd.AvgPrice+ABS(com.CommissionValue)) as [NetAvgPriceLocal]
		,ABS(IIF(com.CommissionType ='R', trd.principal*[CommissionRate], com.CommissionValue*trd.filledQuantity)) as [CommissionAmountLocal]
     , 0 as [MiscFeesLocal]
	 , trd.AvgPrice*trd.filledQuantity as [GrossTradeValueLocal]
	 ,trd.Principal as [GrossPrincipalLocal]
	 , trd.fnAddBusinessDays(trd.TradeDate,IIF((i.Symbol like '%Equity' or fs.GenericFutureId IS NOT null) and trd.TradeDate < '2024-05-28'  , 2,1)) as SettlementDate
	 ,'MS' as PrimeBroker
	 ,'MS' as ClearingBroker
	 ,CASE WHEN (i.InstrumentType = 'EQU' or fs.GenericFutureId IS NOT null) THEN 'MS1SWAP'
		
					WHEN fc.FutureContractId IS NOT null or i.InstrumentType  like 'FUT' THEN 'MS1FUT'
				ELSE  'MS1FWD' end as ClearingAccount
	 ,'MS' as Custodian
	 , null as [LastCorrectedOnUtc]
      , null as [CanceledOnUtc]
	,    (SELECT TOP 1 efx.PrevValue 
         FROM eodfxrates efx 
         WHERE efx.BaseCurrency = trd.TradeCurrency 
         AND efx.QuoteCurrency = 'USD' 
         AND efx.Date <= trd.TradeDate 
         ORDER BY efx.Date DESC) AS [LocalToBaseFxRate],
        (SELECT TOP 1 efx.PrevValue 
         FROM eodfxrates efx 
         WHERE efx.BaseCurrency = trd.TradeCurrency 
         AND efx.QuoteCurrency = trd.SettlementCurrency 
         AND efx.Date <= trd.TradeDate 
         ORDER BY efx.Date DESC) AS [LocalToSettleFxRate]
  FROM [trd].[vwTradeAllocation] trd
  LEFT JOIN book.Trade trd2 on trd2.TradeId = trd.TradeId
    LEFT JOIn instr.vwInstrument i on i.InstrumentId = trd.InstrumentId
	LEFT join settlementCcy sc on sc.InstrumentId = trd.InstrumentId
	LEFT JOIN commissions com on com.TradeAllocationId = trd.TradeAllocationId
  LEFT JOIN instr.vwFutureContract fc on  fc.FutureContractId = trd.InstrumentId
  LEFT JOIN trd.FutureSwap fs on  fs.GenericFutureId = fc.GenericFutureId
  LEFT JOIN eodfxrates local2BaseFx on local2BaseFx.BaseCurrency = trd.TradeCurrency and local2BaseFx.QuoteCurrency = 'USD' and local2BaseFx.Date = trd.TradeDate
  LEFT JOIN eodfxrates local2SettleFx on local2SettleFx.BaseCurrency = trd.TradeCurrency and local2SettleFx.QuoteCurrency =trd.SettlementCurrency and local2SettleFx.Date = trd.TradeDate
  ), withNetAmountlocal as (SELECT  [TradeAllocationId]
      ,[TradeId]
      ,[TradeStatus]
      ,[PortfolioId]
      ,[PositionSide]
      ,[Quantity]
      ,[NominalQuantity]
      ,[OrderAllocationQuantity]
      ,[OrderAllocationNominalQuantity]
      ,[ContractMultiplier]
      ,[LocalCurrency]
      ,[BaseCurrency]
      ,[SettlementCurrency]
      ,[CommissionValue]
      ,[CommissionType]
      ,[GrossAvgPriceLocal]
      ,[PriceCommissionLocal]
      ,[NetAvgPriceLocal]
	  ,[CommissionAmountLocal]
	  ,[MiscFeesLocal]
 ,[GrossTradeValueLocal]
 ,GrossPrincipalLocal
      ,[GrossTradeValueLocal]+[CommissionAmountLocal] as  [NetTradeValueLocal]
      ,[GrossPrincipalLocal]+[CommissionAmountLocal]as NetPrincipalLocal
      --,[NetTradeValueBase]
      --,[GrossTradeValueSettle]
      --,[NetTradeValueSettle]
      --,[GrossPrincipalLocal]
      --,[NetPrincipalLocal]
      --,[GrossPrincipalBase]
      --,[NetPrincipalBase]
      --,[GrossPrincipalSettle]
      --,[NetPrincipalSettle]
     ,[SettlementDate]
      ,IIF(LocalCurrency = BaseCurrency, 1 , [LocalToBaseFxRate]) as [LocalToBaseFxRate]
	  ,IIF(LocalCurrency = SettlementCurrency, 1 , [LocalToBaseFxRate]) as [LocalToSettleFxRate]
  
      ,[PrimeBroker]
      ,[ClearingBroker]
      ,[ClearingAccount]
      ,[Custodian]
      ,[LastCorrectedOnUtc]
      ,[CanceledOnUtc]
     
  FROM withcommissions),  complete as(SELECT  [TradeAllocationId]
      ,[TradeId]
      ,[TradeStatus]
      ,[PortfolioId]
      ,ISNULL([PositionSide],'Z') as [PositionSide]
      ,[Quantity]
      ,[NominalQuantity]
      ,[OrderAllocationQuantity]
      ,[OrderAllocationNominalQuantity]
      ,[ContractMultiplier]
      ,[LocalCurrency]
      ,[BaseCurrency]
      ,[SettlementCurrency]
      ,[CommissionValue]
      ,[CommissionType]
      ,[GrossAvgPriceLocal]
      ,[PriceCommissionLocal]
	  ,[GrossTradeValueLocal]
	  ,[GrossPrincipalLocal]
	  ,[CommissionAmountLocal]
	  ,[MiscFeesLocal]
	  	  ,[CommissionAmountLocal]*[LocalToBaseFxRate] as [CommissionAmountBase]
	  	  ,[CommissionAmountLocal]*[LocalToSettleFxRate] as [CommissionAmountSettle]
      ,[NetAvgPriceLocal]
		,[NetTradeValueLocal]
		,NetPrincipalLocal
		,GrossAvgPriceLocal*LocalToBaseFxRate as GrossAvgPriceBase
		,GrossAvgPriceLocal*LocalToSettleFxRate as GrossAvgPriceSettle
		,[PriceCommissionLocal]*LocalToBaseFxRate as [PriceCommissionBase]
				,[PriceCommissionLocal]*LocalToSettleFxRate as [PriceCommissionSettle]
      , [NetTradeValueLocal]*LocalToBaseFxRate as [NetTradeValueBase]
      ,  [GrossTradeValueLocal] * LocalToSettleFxRate as [GrossTradeValueSettle]
	    ,  [GrossTradeValueLocal] * LocalToBaseFxRate as [GrossTradeValueBase]
	  ,[NetAvgPriceLocal]* LocalToBaseFxRate as [NetAvgPriceBase]
	  	  ,[NetAvgPriceLocal]* LocalToSettleFxRate as [NetAvgPriceSettle]
      ,[NetTradeValueLocal] *LocalToSettleFxRate as [NetTradeValueSettle]         
      ,[GrossPrincipalLocal]*LocalToBaseFxRate as[GrossPrincipalBase]
      ,NetPrincipalLocal*LocalToBaseFxRate as[NetPrincipalBase]
      ,[GrossPrincipalLocal] *LocalToSettleFxRate as [GrossPrincipalSettle]
      ,NetPrincipalLocal*LocalToSettleFxRate as  [NetPrincipalSettle]
	  ,[MiscFeesLocal]*LocalToSettleFxRate as MiscFeesSettle
	    ,[MiscFeesLocal]*LocalToBaseFxRate as MiscFeesBase
      ,[SettlementDate]
      ,[LocalToBaseFxRate]
      ,[LocalToSettleFxRate]
      ,[PrimeBroker]
      ,[ClearingBroker]
      ,[ClearingAccount]
      ,[Custodian]
      ,[LastCorrectedOnUtc]
      ,[CanceledOnUtc] from withNetAmountlocal
  )
  insert into book.TradeAllocation( [TradeAllocationId]
      ,[TradeId]
      ,[TradeStatus]
      ,[PortfolioId]
      ,[PositionSide] 
      ,[Quantity]
      ,[NominalQuantity]
      ,[OrderAllocationQuantity]
      ,[OrderAllocationNominalQuantity]
      ,[ContractMultiplier]
      ,[LocalCurrency]
      ,[BaseCurrency]
      ,[SettlementCurrency]
      ,[CommissionValue]
      ,[CommissionType]
      ,[GrossAvgPriceLocal]
      ,[PriceCommissionLocal]
      ,[NetAvgPriceLocal]
      ,[GrossAvgPriceBase]
      ,[PriceCommissionBase]
      ,[NetAvgPriceBase]
      ,[GrossAvgPriceSettle]
      ,[PriceCommissionSettle]
      ,[NetAvgPriceSettle]
      ,[CommissionAmountLocal]
      ,[CommissionAmountBase]
      ,[CommissionAmountSettle]
      ,[MiscFeesLocal]
      ,[MiscFeesBase]
      ,[MiscFeesSettle]
      ,[GrossTradeValueLocal]
      ,[NetTradeValueLocal]
      ,[GrossTradeValueBase]
      ,[NetTradeValueBase]
      ,[GrossTradeValueSettle]
      ,[NetTradeValueSettle]
      ,[GrossPrincipalLocal]
      ,[NetPrincipalLocal]
      ,[GrossPrincipalBase]
      ,[NetPrincipalBase]
      ,[GrossPrincipalSettle]
      ,[NetPrincipalSettle]
      ,[SettlementDate]
      ,[LocalToBaseFxRate]
      ,[LocalToSettleFxRate]
      ,[PrimeBroker]
      ,[ClearingBroker]
      ,[ClearingAccount]
      ,[Custodian]
      ,[LastCorrectedOnUtc]
	  ,[CanceledOnUtc]) 
  select [TradeAllocationId]
      ,[TradeId]
      ,[TradeStatus]
      ,[PortfolioId]
      ,[PositionSide]
      ,[Quantity]
      ,[NominalQuantity]
      ,[OrderAllocationQuantity]
      ,[OrderAllocationNominalQuantity]
      ,[ContractMultiplier]
      ,[LocalCurrency]
      ,[BaseCurrency]
      ,[SettlementCurrency]
      ,[CommissionValue]
      ,[CommissionType]
      ,[GrossAvgPriceLocal]
      ,[PriceCommissionLocal]
      ,[NetAvgPriceLocal]
      ,[GrossAvgPriceBase]
      ,[PriceCommissionBase]
      ,[NetAvgPriceBase]
      ,[GrossAvgPriceSettle]
      ,[PriceCommissionSettle]
      ,[NetAvgPriceSettle]
      ,[CommissionAmountLocal]
      ,[CommissionAmountBase]
      ,[CommissionAmountSettle]
      ,[MiscFeesLocal]
      ,[MiscFeesBase]
      ,[MiscFeesSettle]
      ,[GrossTradeValueLocal]
      ,[NetTradeValueLocal]
      ,[GrossTradeValueBase]
      ,[NetTradeValueBase]
      ,[GrossTradeValueSettle]
      ,[NetTradeValueSettle]
      ,[GrossPrincipalLocal]
      ,[NetPrincipalLocal]
      ,[GrossPrincipalBase]
      ,[NetPrincipalBase]
      ,[GrossPrincipalSettle]
      ,[NetPrincipalSettle]
      ,[SettlementDate]
      ,[LocalToBaseFxRate]
      ,[LocalToSettleFxRate]
      ,[PrimeBroker]
      ,[ClearingBroker]
      ,[ClearingAccount]
      ,[Custodian]
      ,[LastCorrectedOnUtc]
      ,[CanceledOnUtc] from complete

	  order by TradeAllocationId;

END
GO
/****** Object:  StoredProcedure [book].[spAssignCounterpartyRole]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
Create PROCEDURE [book].[spAssignCounterpartyRole]
@PortfolioId tinyint,
@ExecBrokerCode nvarchar(10),
@CounterpartyRoleSetupId int
AS
BEGIN
    WITH roleAssignment AS (
     SELECT @PortfolioId as PortfolioId

,[InstrumentId]
 ,counterparty.CounterpartyId as [ExecutionBrokerId]
 ,@CounterpartyRoleSetupId as [CounterpartyRoleSetupId]
 FROM [book].[Instrument] ins
  JOIN [book].Counterparty counterparty on counterparty.Code = @ExecBrokerCode
	
    )
    
    MERGE INTO [book].[CounterpartyRoleAssignment] AS target
    USING roleAssignment AS source ON (target.PortfolioId = source.PortfolioId 
	AND target.InstrumentId = source.InstrumentId 
	AND target.[ExecutionBrokerId] = source.[ExecutionBrokerId])
	 WHEN MATCHED THEN
        UPDATE SET          
			target.[CounterpartyRoleSetupId] = source.[CounterpartyRoleSetupId]
			
    WHEN NOT MATCHED BY TARGET THEN
        INSERT ([PortfolioId]
      ,[InstrumentId]
      ,[ExecutionBrokerId]
      ,[CounterpartyRoleSetupId])
        VALUES (source.[PortfolioId]
      ,source.[InstrumentId]
      ,source.[ExecutionBrokerId]
      ,source.[CounterpartyRoleSetupId]);
END
GO
/****** Object:  StoredProcedure [book].[spAssignCounterpartyRoleByExchange]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
Create PROCEDURE [book].[spAssignCounterpartyRoleByExchange]
@PortfolioId tinyint,
@ExecBrokerCode nvarchar(10),
@Exchange nvarchar(10),
@CounterpartyRoleSetupId int
AS
BEGIN
    WITH roleAssignment AS (
     SELECT @PortfolioId as PortfolioId

,[InstrumentId]
 ,counterparty.CounterpartyId as [ExecutionBrokerId]
 ,@CounterpartyRoleSetupId as [CounterpartyRoleSetupId]
 FROM [book].[Instrument] ins
  JOIN [book].Counterparty counterparty on counterparty.Code = @ExecBrokerCode
  where ins.Exchange = @Exchange  
	
    )
    
    MERGE INTO [book].[CounterpartyRoleAssignment] AS target
    USING roleAssignment AS source ON (target.PortfolioId = source.PortfolioId 
	AND target.InstrumentId = source.InstrumentId 
	AND target.[ExecutionBrokerId] = source.[ExecutionBrokerId])
	 WHEN MATCHED THEN
        UPDATE SET          
			target.[CounterpartyRoleSetupId] = source.[CounterpartyRoleSetupId]
			
    WHEN NOT MATCHED BY TARGET THEN
        INSERT ([PortfolioId]
      ,[InstrumentId]
      ,[ExecutionBrokerId]
      ,[CounterpartyRoleSetupId])
        VALUES (source.[PortfolioId]
      ,source.[InstrumentId]
      ,source.[ExecutionBrokerId]
      ,source.[CounterpartyRoleSetupId]);
END
GO
/****** Object:  StoredProcedure [book].[spAssignCounterpartyRoleByInstrument]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
Create PROCEDURE [book].[spAssignCounterpartyRoleByInstrument]
@PortfolioId tinyint,
@ExecBrokerCode nvarchar(10),
@InstrumentId int,
@CounterpartyRoleSetupId int
AS
BEGIN
    WITH roleAssignment AS (
     SELECT @PortfolioId as PortfolioId

,[InstrumentId]
 ,counterparty.CounterpartyId as [ExecutionBrokerId]
 ,@CounterpartyRoleSetupId as [CounterpartyRoleSetupId]
 FROM [book].[Instrument] ins
  JOIN [book].Counterparty counterparty on counterparty.Code = @ExecBrokerCode
  where ins.InstrumentId = @InstrumentId  
	
    )
    
    MERGE INTO [book].[CounterpartyRoleAssignment] AS target
    USING roleAssignment AS source ON (target.PortfolioId = source.PortfolioId 
	AND target.InstrumentId = source.InstrumentId 
	AND target.[ExecutionBrokerId] = source.[ExecutionBrokerId])
	 WHEN MATCHED THEN
        UPDATE SET          
			target.[CounterpartyRoleSetupId] = source.[CounterpartyRoleSetupId]
			
    WHEN NOT MATCHED BY TARGET THEN
        INSERT ([PortfolioId]
      ,[InstrumentId]
      ,[ExecutionBrokerId]
      ,[CounterpartyRoleSetupId])
        VALUES (source.[PortfolioId]
      ,source.[InstrumentId]
      ,source.[ExecutionBrokerId]
      ,source.[CounterpartyRoleSetupId]);
END
GO
/****** Object:  StoredProcedure [book].[spAssignCounterpartyRoleByInstrumentType]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
Create PROCEDURE [book].[spAssignCounterpartyRoleByInstrumentType]
@PortfolioId tinyint,
@ExecBrokerCode nvarchar(10),
@InstrumentType nvarchar(10),
@CounterpartyRoleSetupId int
AS
BEGIN
    WITH roleAssignment AS (
     SELECT @PortfolioId as PortfolioId

,[InstrumentId]
 ,counterparty.CounterpartyId as [ExecutionBrokerId]
 ,@CounterpartyRoleSetupId as [CounterpartyRoleSetupId]
 FROM [book].[Instrument]
  JOIN [book].Counterparty counterparty on counterparty.Code = @ExecBrokerCode
  where InstrumentType = @InstrumentType  
	
    )
    
    MERGE INTO [book].[CounterpartyRoleAssignment] AS target
    USING roleAssignment AS source ON (target.PortfolioId = source.PortfolioId 
	AND target.InstrumentId = source.InstrumentId 
	AND target.[ExecutionBrokerId] = source.[ExecutionBrokerId])
	 WHEN MATCHED THEN
        UPDATE SET          
			target.[CounterpartyRoleSetupId] = source.[CounterpartyRoleSetupId]
			
    WHEN NOT MATCHED BY TARGET THEN
        INSERT ([PortfolioId]
      ,[InstrumentId]
      ,[ExecutionBrokerId]
      ,[CounterpartyRoleSetupId])
        VALUES (source.[PortfolioId]
      ,source.[InstrumentId]
      ,source.[ExecutionBrokerId]
      ,source.[CounterpartyRoleSetupId]);
END
GO
/****** Object:  StoredProcedure [book].[spPropagateUpdateBookedTrades]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO









-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [book].[spPropagateUpdateBookedTrades]

AS
BEGIN

-- Execute the procedures
EXEC dbo.spExecuteProcAcrossSchemas 'spUpdateBookedTrades'

END


GO
/****** Object:  StoredProcedure [book].[spUpdateFxRates]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [book].[spUpdateFxRates]
AS
BEGIN
    MERGE INTO [book].FxRate AS target
    USING (
       SELECT [BaseCurrency]
      ,[QuoteCurrency]
      ,[LastValueEod]     
      ,[LastUpdateDateEod]
  FROM [mktdata].[FxRate]
    ) AS source ON (target.[BaseCurrency] = source.[BaseCurrency] AND target.[QuoteCurrency] = source.[QuoteCurrency] and target.Date = source.[LastUpdateDateEod])

    WHEN MATCHED THEN
        UPDATE SET
            target.[Value] = source.[LastValueEod],
			target.Date = source.[LastUpdateDateEod]

    WHEN NOT MATCHED BY TARGET THEN
        INSERT (
          [BaseCurrency]
      ,[QuoteCurrency]
      ,[Value]
      ,[Date]
        )
        VALUES (
            source.[BaseCurrency],
            source.[QuoteCurrency],
            source.[LastValueEod],
            source.[LastUpdateDateEod]
        );

END
GO
/****** Object:  StoredProcedure [book].[spUpdateInstruments]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [book].[spUpdateInstruments]
AS
BEGIN


    MERGE INTO [book].Instrument AS target
    USING (
        SELECT 
       [InstrumentId]
      ,[Symbol]
      ,[Name]
	  ,[ISIN]
      ,[BbgUniqueId]
      ,[InstrumentType]
      ,[MarketSectorDes]
      ,[Exchange]
      ,[PrimaryMIC]
      ,[Currency]
      ,[QuoteCurrency]
	  ,gen.GenericFutureId
      ,CASE WHEN fut.LastTradeDate is not null THEN fut.LastTradeDate 
	        WHEN fwd.MaturityDate is not null THEN fwd.MaturityDate 
			ELSE NULL END as MaturityDate
      ,[PriceScalingFactor]
	  ,gen.PointValue as FuturePointValue
  FROM [instr].[vwInstrument] ins
  LEFT JOIN instr.FutureContract fut on fut.FutureContractId = ins.[InstrumentId]
  LEFT JOIN instr.GenericFuture gen on gen.GenericFutureId =fut.GenericFutureId
  LEFT JOIN instr.FxForward fwd on fwd.FxForwardId = ins.[InstrumentId]
		
    ) AS source ON (target.[InstrumentId] = source.[InstrumentId])

   WHEN MATCHED THEN
        UPDATE SET
            target.[InstrumentType] = source.[InstrumentType],
            target.[Symbol] = source.[Symbol],
            target.[Name] = source.[Name],
            target.[Currency] = source.[Currency],
            target.[BbgUniqueId] = source.[BbgUniqueId],
			target.[ISIN] = source.[ISIN],
		    target.[MarketSector] = source.[MarketSectorDes],
		 	target.[Exchange] = source.[Exchange],
			target.[PrimaryMIC] = source.[PrimaryMIC],
			target.[QuoteCurrency] = source.[QuoteCurrency],
			target.[PriceScalingFactor] = source.[PriceScalingFactor],
			target.MaturityDate = source.MaturityDate,
		    target.FuturePointValue = source.FuturePointValue,
			target.GenericFutureId = source.GenericFutureId
    WHEN NOT MATCHED BY TARGET THEN
        INSERT (
               [InstrumentId]
			  ,[Symbol]
			  ,[Name]
			  ,[ISIN]
			  ,[BbgUniqueId]
			  ,[InstrumentType]
			  ,[MarketSector]
			  ,[Exchange]
			  ,[PrimaryMIC]
			  ,[Currency]
			  ,[QuoteCurrency]
			  ,[PriceScalingFactor]
			  ,[MaturityDate]
			  ,FuturePointValue
			  ,GenericFutureId
        )
        VALUES (
                 source.[InstrumentId]
				  ,source.[Symbol]
				  ,source.[Name]
				  ,source.[ISIN]
				  ,source.[BbgUniqueId]
				  ,source.[InstrumentType]
				  ,source.[MarketSectorDes]
				  ,source.[Exchange]
				  ,source.[PrimaryMIC]
				  ,source.[Currency]
				  ,source.[QuoteCurrency]
				   ,source.[PriceScalingFactor]
			  ,source.[MaturityDate]
			  ,source.[FuturePointValue]
			  ,source.GenericFutureId
        )
		    WHEN NOT MATCHED BY SOURCE THEN
        DELETE;


END
GO
/****** Object:  StoredProcedure [book].[spUpdateOrder]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [book].[spUpdateOrder]

AS
BEGIN
MERGE INTO [book].[Order] AS Target
USING (
   SELECT [OrderId]
      ,[InstrumentId]
      ,[Symbol]
      ,[RebalancingSessionId] as RebalancingId
      ,[Quantity]
      ,[TradeDate]
      ,[TradingDesk] as [ExecutionDesk]
      ,[TradeMode]
      ,'' as [ExecutionAccount]
      ,[OrderType]
      ,[ExecutionAlgo]
      ,[TimeInForce]
    FROM 
        [ord].[vwOrder] o

) AS Source
ON Target.[OrderId] = Source.[OrderId]
WHEN MATCHED THEN 
    UPDATE SET
        Target.OrderId = Source.OrderId,
        Target.[RebalancingId] = Source.[RebalancingId],
        Target.[InstrumentId] = Source.[InstrumentId],
		Target.[Quantity] = Source.[Quantity],
		Target.[Symbol] = Source.[Symbol],   
		Target.[TradeDate] = Source.[TradeDate],
		Target.[ExecutionDesk] = Source.[ExecutionDesk],
		Target.[TradeMode] = Source.[TradeMode],
		Target.[ExecutionAccount] = Source.[ExecutionAccount],
		Target.[OrderType] = Source.[OrderType],
		Target.[ExecutionAlgo] = Source.[ExecutionAlgo],
		Target.[TimeInForce] = Source.[TimeInForce]
WHEN NOT MATCHED BY TARGET THEN
    INSERT (
        [OrderId]
      ,[InstrumentId]
      ,[Symbol]
      ,[RebalancingId]
      ,[Quantity]
      ,[TradeDate]
      ,[ExecutionDesk]
      ,[TradeMode]
      ,[ExecutionAccount]
      ,[OrderType]
      ,[ExecutionAlgo]
      ,[TimeInForce]
    )
    VALUES (
        Source.[OrderId]
      ,Source.[InstrumentId]
      ,Source.[Symbol]
      ,Source.[RebalancingId]
      ,Source.[Quantity]
      ,Source.[TradeDate]
      ,Source.[ExecutionDesk]
      ,Source.[TradeMode]
      ,Source.[ExecutionAccount]
      ,Source.[OrderType]
      ,Source.[ExecutionAlgo]
      ,Source.[TimeInForce]
    );

	EXEC book.spUpdateOrderAllocation
END;
GO
/****** Object:  StoredProcedure [book].[spUpdateOrderAllocation]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [book].[spUpdateOrderAllocation]

AS
BEGIN
MERGE INTO [book].[OrderAllocation] AS Target
USING (
    SELECT 
        OrderId, 
        [PortfolioId],
        [Quantity],
		ps.Mnemonic as PositionSide
    FROM 
        [ord].[OrderAllocation] alloc
		JOIN [ord].PositionSide ps on ps.PositionSideId = alloc.PositionSideId
) AS Source
ON Target.[OrderId] = Source.[OrderId] and Target.PortfolioId = Source.PortfolioId
WHEN MATCHED THEN 
    UPDATE SET
        Target.[Quantity] = Source.[Quantity],
		Target.PositionSide = Source.[PositionSide]
WHEN NOT MATCHED BY TARGET THEN
    INSERT (
        OrderId, 
        [PortfolioId],
        [Quantity],
		[PositionSide]
    )
    VALUES (
        Source.OrderId, 
        Source.[PortfolioId],
        Source.[Quantity],
		Source.[PositionSide]
    );
END;
GO
/****** Object:  StoredProcedure [book].[spUpdatePositions]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [book].[spUpdatePositions]

AS
BEGIN
DECLARE @StartDate DATE = DATEADD(MONTH, -1, CAST(GETDATE() AS DATE));
--MERGE INTO [book].[Position] AS Target
--USING (SELECT [PortfolioId]
--      ,pos.[InstrumentId]
--      ,[Quantity]
--	  ,IIF((ins.InstrumentType = 'EQU' or fs.GenericFutureId is not null), 1,0) AS IsSwap--TODO:!!!! really bad need to propagate isswap on position or modelize swaps as well
--		,PositionDate
-- FROM [port].[Position] pos
--  LEFT JOIN book.Instrument ins on ins.InstrumentId = pos.InstrumentId
-- LEFT JOIN book.FutureSwap fs on fs.GenericFutureId = ins.GenericFutureId
-- where PositionDate >= @StartDate
--       ) AS Source
--ON (Target.[PortfolioId] = Source.[PortfolioId] 
--    AND Target.[InstrumentId] = Source.[InstrumentId]
--	AND Target.[PositionDate] =Source.[PositionDate])
--WHEN MATCHED THEN 
--    UPDATE SET
--        Target.[Quantity] = Source.[Quantity]
       

--WHEN NOT MATCHED BY TARGET THEN
--    INSERT ([PortfolioId], 
--            [InstrumentId], 
--            [Quantity], 
--            [IsSwap],
--			[PositionDate])
--    VALUES (Source.[PortfolioId], 
--            Source.[InstrumentId], 
--            Source.[Quantity], 
--            Source.[IsSwap],
--			Source.[PositionDate]
--           )
--WHEN NOT MATCHED BY SOURCE THEN
--DELETE;
END
GO
/****** Object:  StoredProcedure [conv].[spUpdateCross2ForwardMappings]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [conv].[spUpdateCross2ForwardMappings]
AS
BEGIN
    Declare @MappingTypeId tinyint = 2;
    MERGE INTO conv.InstrumentMapping AS target
    USING (
       SELECT [CurrencyPairId]
      ,[CurrentContractId]      
  FROM [roll].[vwFxForwardRollInfo]
    ) AS source ON (target.[FromInstrumentId] = source.[CurrencyPairId] AND target.InstrumentMappingTypeId = @MappingTypeId)

    WHEN MATCHED THEN
        UPDATE SET
            target.[ToInstrumentId] = source.[CurrentContractId]

    WHEN NOT MATCHED BY TARGET THEN
        INSERT (
            [FromInstrumentId],
            [ToInstrumentId],
			InstrumentMappingTypeId
        )
        VALUES (
            source.[CurrencyPairId],
            source.[CurrentContractId],
			@MappingTypeId
        );
END
GO
/****** Object:  StoredProcedure [conv].[spUpdateCross2InverseMappings]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [conv].[spUpdateCross2InverseMappings]
AS
BEGIN
   Declare @MappingTypeId tinyint = 3;
    MERGE INTO conv.InstrumentMapping AS target
    USING (
     SELECT  [CurrencyPairId]      
      ,[InverseCurrencyPairId]     
  FROM [instr].[vwInverseCurrencyPair]
    ) AS source ON (target.[FromInstrumentId] = source.[CurrencyPairId] AND target.InstrumentMappingTypeId = @MappingTypeId)

    WHEN MATCHED THEN
        UPDATE SET
            target.[ToInstrumentId] = source.[InverseCurrencyPairId]

    WHEN NOT MATCHED BY TARGET THEN
        INSERT (
            [FromInstrumentId],
            [ToInstrumentId],
			InstrumentMappingTypeId
        )
        VALUES (
            source.[CurrencyPairId],
            source.[InverseCurrencyPairId],
			@MappingTypeId
        );
END
GO
/****** Object:  StoredProcedure [conv].[spUpdateFutureContractRollInfo]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [conv].[spUpdateFutureContractRollInfo]
AS
BEGIN
    EXEC [conv].[spUpdateGeneric2FutureMappings]

   
END
GO
/****** Object:  StoredProcedure [conv].[spUpdateGeneric2FutureMappings]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [conv].[spUpdateGeneric2FutureMappings]
AS
BEGIN
    Declare @MappingTypeId tinyint = 1;
    MERGE INTO conv.InstrumentMapping AS target
    USING (
       SELECT [GenericFutureId]

	  , [CurrentContractId] as ToContractId

  FROM [roll].[vwFutureContractRollInfo]
    ) AS source ON (target.[FromInstrumentId] = source.[GenericFutureId] AND target.InstrumentMappingTypeId = @MappingTypeId)

    WHEN MATCHED THEN
        UPDATE SET
            target.[ToInstrumentId] = source.ToContractId

    WHEN NOT MATCHED BY TARGET THEN
        INSERT (
            [FromInstrumentId],
            ToInstrumentId,
			InstrumentMappingTypeId
        )
        VALUES (
            source.[GenericFutureId],
            source.ToContractId,
			@MappingTypeId
        );

   
END
GO
/****** Object:  StoredProcedure [conv].[spUpdateInstrumentMappings]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [conv].[spUpdateInstrumentMappings]
AS
BEGIN
EXEC [conv].[spUpdateGeneric2FutureMappings]
EXEC [conv].[spUpdateCross2InverseMappings]
EXEC [conv].[spUpdateCross2ForwardMappings]

END
GO
/****** Object:  StoredProcedure [conv].[spUpdateInstruments]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [conv].[spUpdateInstruments]
AS
BEGIN
    MERGE INTO conv.Instrument AS target
    USING (
        SELECT
            [InstrumentId],
            [Symbol],
            [InstrumentType]
        FROM [instr].[vwInstrument]
    ) AS source ON (target.[InstrumentId] = source.[InstrumentId])

    WHEN MATCHED THEN
        UPDATE SET
            target.[Symbol] = source.[Symbol],
            target.[InstrumentType] = source.[InstrumentType]

    WHEN NOT MATCHED BY TARGET THEN
        INSERT (
            [InstrumentId],
            [Symbol],
            [InstrumentType]
        )
        VALUES (
            source.[InstrumentId],
            source.[Symbol],
            source.[InstrumentType]
        )

    WHEN NOT MATCHED BY SOURCE THEN
        DELETE;

EXEC	[conv].[spUpdateInstrumentMappings]
END
GO
/****** Object:  StoredProcedure [dbo].[spDeleteTableAcrossSchemas]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteTableAcrossSchemas]
@TableName NVARCHAR(256)
AS
BEGIN
    DECLARE @SqlCmd NVARCHAR(MAX) = ''

   SELECT @SqlCmd += 'DELETE FROM ['+ s.name + '].[' + o.name + '];'
    FROM sys.objects o
    JOIN sys.schemas s ON o.schema_id = s.schema_id
	WHERE type = 'U' and o.name =@TableName and s.name <> 'instr'

	--  DECLARE @SqlCmd2 NVARCHAR(MAX) = ''
	--   SELECT @SqlCmd2 += 'DBCC CHECKIDENT (''['+ s.name + '].[' + o.name + ']'', RESEED, 0);'
 --   FROM sys.objects o
 --   JOIN sys.schemas s ON o.schema_id = s.schema_id
	--WHERE type = 'U' and o.name =@TableName

    -- Execute the procedures
    EXEC sp_executesql @SqlCmd

	 --EXEC sp_executesql @SqlCmd2
END


GO
/****** Object:  StoredProcedure [dbo].[spExecuteProcAcrossSchemas]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[spExecuteProcAcrossSchemas]
@ProcName NVARCHAR(256)
AS
BEGIN
    DECLARE @SqlCmd NVARCHAR(MAX) = ''

    -- Construct the dynamic SQL command
    SELECT @SqlCmd += 'EXEC [' + s.name + '].[' + o.name + ']; '
    FROM sys.objects o
    JOIN sys.schemas s ON o.schema_id = s.schema_id
    WHERE o.type = 'P' AND o.name = @ProcName

    -- Execute the procedures
    EXEC sp_executesql @SqlCmd
END


GO
/****** Object:  StoredProcedure [dbo].[spInsertTradeFileDataForTests]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[spInsertTradeFileDataForTests]
AS
BEGIN

drop table dbo.tvTradesFileCAPRICORN 
drop table dbo.tvTradesFileGSPBFUT 
drop table  dbo.tvTradesFileGSPBSYNTH 
drop table dbo.tvTradesFileINNOCAPSW002 
drop table dbo.tvTradesFileINNOCAPTR001 
drop table  dbo.tvTradesFileJPMSWAP 
drop table  dbo.tvTradesFileMSFSSW002 
drop table  dbo.tvTradesFileMSFSTR001 
drop table  dbo.tvTradesFileMSPBD01 
drop table  dbo.tvTradesFileMSPBSW002 

SELECT * into  dbo.tvTradesFileCAPRICORN FROM [trans].tvTradesFileCAPRICORN (1)
SELECT * into  dbo.tvTradesFileGSPBFUT FROM [trans].tvTradesFileGSPBFUT (1)
SELECT * into  dbo.tvTradesFileGSPBSYNTH FROM [trans].tvTradesFileGSPBSYNTH (1)
SELECT * into  dbo.tvTradesFileINNOCAPSW002 FROM [trans].tvTradesFileINNOCAPSW002 (1)
SELECT * into  dbo.tvTradesFileINNOCAPTR001 FROM [trans].tvTradesFileINNOCAPTR001 (1)
SELECT * into  dbo.tvTradesFileJPMSWAP FROM [trans].[tvTradesFileJPMSWAP] (1)
SELECT * into  dbo.tvTradesFileMSFSSW002 FROM [trans].tvTradesFileMSFSSW002 (1)
SELECT * into  dbo.tvTradesFileMSFSTR001 FROM [trans].tvTradesFileMSFSTR001 (1)
SELECT * into  dbo.tvTradesFileMSPBD01 FROM [trans].tvTradesFileMSPBD01 (1)
SELECT * into  dbo.tvTradesFileMSPBSW002 FROM [trans].tvTradesFileMSPBSW002 (1)




drop table dbo.tv_TEST_TradesFileCAPRICORN 
drop table dbo.tv_TEST_TradesFileGSPBFUT 
drop table  dbo.tv_TEST_TradesFileGSPBSYNTH 
drop table dbo.tv_TEST_TradesFileINNOCAPSW002 
drop table dbo.tv_TEST_TradesFileINNOCAPTR001 
drop table  dbo.tv_TEST_TradesFileJPMSWAP 
drop table  dbo.tv_TEST_TradesFileMSFSSW002 
drop table  dbo.tv_TEST_TradesFileMSFSTR001 
drop table  dbo.tv_TEST_TradesFileMSPBD01 
drop table  dbo.tv_TEST_TradesFileMSPBSW002 

SELECT * into  dbo.tv_TEST_TradesFileCAPRICORN FROM [trans].tv_TEST_TradesFileCAPRICORN (1)
SELECT * into  dbo.tv_TEST_TradesFileGSPBFUT FROM [trans].tv_TEST_TradesFileGSPBFUT (1)
SELECT * into  dbo.tv_TEST_TradesFileGSPBSYNTH FROM [trans].tv_TEST_TradesFileGSPBSYNTH (1)
SELECT * into  dbo.tv_TEST_TradesFileINNOCAPSW002 FROM [trans].tv_TEST_TradesFileINNOCAPSW002 (1)
SELECT * into  dbo.tv_TEST_TradesFileINNOCAPTR001 FROM [trans].tv_TEST_TradesFileINNOCAPTR001 (1)
SELECT * into  dbo.tv_TEST_TradesFileJPMSWAP FROM [trans].[tv_TEST_TradesFileJPMSWAP] (1)
SELECT * into  dbo.tv_TEST_TradesFileMSFSSW002 FROM [trans].tv_TEST_TradesFileMSFSSW002 (1)
SELECT * into  dbo.tv_TEST_TradesFileMSFSTR001 FROM [trans].tv_TEST_TradesFileMSFSTR001 (1)
SELECT * into  dbo.tv_TEST_TradesFileMSPBD01 FROM [trans].tv_TEST_TradesFileMSPBD01 (1)
SELECT * into  dbo.tv_TEST_TradesFileMSPBSW002 FROM [trans].tv_TEST_TradesFileMSPBSW002 (1)
END


GO
/****** Object:  StoredProcedure [dbo].[spPnlAtDate]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
-- EXEC [dbo].[spPnlAtDate] '20231204',55455000
CREATE PROCEDURE [dbo].[spPnlAtDate]
@date_run date,
@equity_aum float

AS
BEGIN
	  
		  select * from (
		  select 
		  case when I.InstrumentType = 'EQU' THEN 'EquityCFD'
					 when I.InstrumentType = 'FUT' THEN 'Future'
					 WHEN I.InstrumentType = 'FXFWD' THEN 'FXForwards'
					 end  as 'AssetType'
,case when I.Symbol ='USD/BRL 12/31/2023 Curncy' THEN 'BRLUSD Curncy'
		when I.Symbol ='USD/KRW 12/31/2023 Curncy' THEN 'IDRUSD Curncy'
		when I.Symbol ='USD/THB 12/31/2023 Curncy' THEN 'KRWUSD Curncy'
		when I.Symbol ='USD/SGD 12/31/2023 Curncy' THEN 'SGDUSD Curncy'
		when I.Symbol ='USD/IDR 12/31/2023 Curncy' THEN 'THBUSD Curncy'
		else I.Symbol end ticker
			   ,case when [Quantity] = 0 THEN 0 ELSE PositionValueBase/@equity_aum  end as weight_real
			   ,case when [Quantity] > 0 THEN 'Long'
					when [Quantity] < 0 THEN 'Short' 
					when [Quantity] = 0 AND I.InstrumentType = 'FUT' THEN 'XRoll' end as 'side'
			  ,[Quantity] 'quantity'
			   ,[PriceCurrency] as 'CCY'
			   ,case when [Quantity] = 0 AND abs([DailyPnLChange]) < 100 THEN 1
					else 0 end as 'check_old_pnl'
			  -- ,[AvgEntryPriceLocal] 'Local Cost'
			  --,[AvgEntryPriceBase] 'Base Cost'
	  		--	  ,[Price] 'Local Price'
			  --,price*isnull(FxRate,1) 'Base Price'
			  --,PositionValueLocal 'Local MV'
			  ,PositionValueBase 'Base_MV'
			  --,[DailyPnLChange]/FxRate as pnl_local
			  ,[DailyPnLChange] as pnl_base -- 
			  --,FxRate as  'FX Rate'

		  from [val].[vwPositionValuationPnL] V (nolock)
		  LEFT JOIN [instr].[vwInstrument] I on I.InstrumentId = V.[InstrumentId]

		  where PositionDate = @date_run ) M
		  --and [Quantity] <> 0
		  where  check_old_pnl = 0 -- M.AssetType <> 'FXForwards' and

		  order by side desc
END


GO
/****** Object:  StoredProcedure [dbo].[spTruncateTableAcrossSchemas]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[spTruncateTableAcrossSchemas]
@TableName NVARCHAR(256)
AS
BEGIN
    DECLARE @SqlCmd NVARCHAR(MAX) = ''

   SELECT @SqlCmd += 'TRUNCATE TABLE ['+ s.name + '].[' + o.name + '];'
    FROM sys.objects o
    JOIN sys.schemas s ON o.schema_id = s.schema_id
	WHERE type = 'U' and o.name =@TableName and s.name <> 'instr'

    -- Execute the procedures
    EXEC sp_executesql @SqlCmd
END


GO
/****** Object:  StoredProcedure [dbo].[spValidateEmsxTrade]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spValidateEmsxTrade]
AS
BEGIN
    -- Declare the necessary variables
    DECLARE @ErrorFlag INT;
    DECLARE @ErrorMessage NVARCHAR(MAX);
    
    -- Temp tables for accumulating errors
    DECLARE @TempErrorMessages TABLE (ErrorType NVARCHAR(255), EmsxSequenceValues NVARCHAR(MAX));
    DECLARE @CurrentError NVARCHAR(MAX);
    
    SET @ErrorFlag = 0;
    SET @ErrorMessage = '';

    -- Check InstrumentId
    SET @CurrentError = 'InstrumentId is missing for EmsxSequences:';
    INSERT INTO @TempErrorMessages (ErrorType, EmsxSequenceValues)
    SELECT @CurrentError, STRING_AGG(CAST([EmsxSequence] AS NVARCHAR(50)), ', ')
    FROM [trd].[vwEmsxTradeToBook] 
    WHERE InstrumentId IS NULL;
  

    -- Check Side
    SET @CurrentError = 'Side is missing for EmsxSequences:';
    INSERT INTO @TempErrorMessages (ErrorType, EmsxSequenceValues)
    SELECT @CurrentError, STRING_AGG(CAST([EmsxSequence] AS NVARCHAR(50)), ', ')
    FROM [trd].[vwEmsxTradeToBook] 
    WHERE Side IS NULL or Side NOT in ('S', 'B');


    -- ... Continue similarly for all other columns ...

    -- Check OrderQuantity
    SET @CurrentError = 'OrderQuantity is missing for EmsxSequences:';
    INSERT INTO @TempErrorMessages (ErrorType, EmsxSequenceValues)
    SELECT @CurrentError, STRING_AGG(CAST([EmsxSequence] AS NVARCHAR(50)), ', ')
    FROM [trd].[vwEmsxTradeToBook] 
    WHERE OrderQuantity IS NULL or OrderQuantity = 0;

    -- Check FilledQuantity
    SET @CurrentError = 'FilledQuantity is missing for EmsxSequences:';
    INSERT INTO @TempErrorMessages (ErrorType, EmsxSequenceValues)
    SELECT @CurrentError, STRING_AGG(CAST([EmsxSequence] AS NVARCHAR(50)), ', ')
    FROM [trd].[vwEmsxTradeToBook] 
    WHERE FilledQuantity IS NULL or FilledQuantity = 0;

    -- Check AvgPrice
    SET @CurrentError = 'AvgPrice is missing for EmsxSequences:';
    INSERT INTO @TempErrorMessages (ErrorType, EmsxSequenceValues)
    SELECT @CurrentError, STRING_AGG(CAST([EmsxSequence] AS NVARCHAR(50)), ', ')
    FROM [trd].[vwEmsxTradeToBook] 
    WHERE AvgPrice IS NULL or AvgPrice = 0;

	   -- Check AvgPrice
    SET @CurrentError = 'TradeCurrency is missing for EmsxSequences:';
    INSERT INTO @TempErrorMessages (ErrorType, EmsxSequenceValues)
    SELECT @CurrentError, STRING_AGG(CAST([EmsxSequence] AS NVARCHAR(50)), ', ')
    FROM [trd].[vwEmsxTradeToBook] 
    WHERE [TradeCurrency] IS NULL ;

	    SET @CurrentError = 'TotalCharges is missing for EmsxSequences:';
    INSERT INTO @TempErrorMessages (ErrorType, EmsxSequenceValues)
    SELECT @CurrentError, STRING_AGG(CAST([EmsxSequence] AS NVARCHAR(50)), ', ')
    FROM [trd].[vwEmsxTradeToBook] 
    WHERE [TotalCharges] IS NULL ;
  
      SET @CurrentError = 'Principal is missing for EmsxSequences:';
    INSERT INTO @TempErrorMessages (ErrorType, EmsxSequenceValues)
    SELECT @CurrentError, STRING_AGG(CAST([EmsxSequence] AS NVARCHAR(50)), ', ')
    FROM [trd].[vwEmsxTradeToBook] 
    WHERE Principal IS NULL or Principal = 0;

	  
      SET @CurrentError = 'NetAmount is missing for EmsxSequences:';
    INSERT INTO @TempErrorMessages (ErrorType, EmsxSequenceValues)
    SELECT @CurrentError, STRING_AGG(CAST([EmsxSequence] AS NVARCHAR(50)), ', ')
    FROM [trd].[vwEmsxTradeToBook] 
    WHERE NetAmount IS NULL or NetAmount = 0;
	    SET @CurrentError = 'Broker is missing for EmsxSequences:';
    INSERT INTO @TempErrorMessages (ErrorType, EmsxSequenceValues)
    SELECT @CurrentError, STRING_AGG(CAST([EmsxSequence] AS NVARCHAR(50)), ', ')
    FROM [trd].[vwEmsxTradeToBook] 
    WHERE [Broker] IS NULL;

    -- Aggregate error messages
    SELECT @ErrorFlag = CASE WHEN COUNT(*) > 0 THEN 1 ELSE @ErrorFlag END
    FROM @TempErrorMessages;

    SELECT @ErrorMessage = STRING_AGG(CONCAT(ErrorType, ' ', EmsxSequenceValues), CHAR(13) + CHAR(10))
    FROM @TempErrorMessages;

    -- Return the error messages if any
    IF @ErrorFlag = 1
    BEGIN
        RAISERROR(@ErrorMessage, 16, 1); 
    END
END
GO
/****** Object:  StoredProcedure [efrp].[spUpdateFutureContracts]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [efrp].[spUpdateFutureContracts]
AS
BEGIN


    MERGE INTO efrp.FutureContract AS target
    USING (
        SELECT 
       fut.[FutureContractId]
      ,fut.[Symbol]
      ,fut.[GenericFutureId]
      ,fut.[LastTradeDate]

  FROM [instr].[vwFutureContract] fut
  JOIN efrp.GenericFuture gen on gen.[GenericFutureId] = fut.[GenericFutureId]
		
    ) AS source ON (target.[FutureContractId] = source.[FutureContractId])

   WHEN MATCHED THEN
        UPDATE SET
            target.[Symbol] = source.[Symbol],
            target.[GenericFutureId] = source.[GenericFutureId],
            target.[LastTradeDate] = source.[LastTradeDate]
		
    WHEN NOT MATCHED BY TARGET THEN
        INSERT (
           [FutureContractId]
		  ,[Symbol]
		  ,[GenericFutureId]
		  ,[LastTradeDate]
		  
        )
        VALUES (
           source.[FutureContractId]
		  , source.[Symbol]
		  , source.[GenericFutureId]
		  , source.[LastTradeDate]
		
        )
		    WHEN NOT MATCHED BY SOURCE THEN
        DELETE;


END
GO
/****** Object:  StoredProcedure [efrp].[spUpdateGenericFutures]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [efrp].[spUpdateGenericFutures]
AS
BEGIN


    MERGE INTO efrp.GenericFuture AS target
    USING (
        SELECT 
       [GenericFutureId]
      ,[Symbol]
      ,[RootSymbol]
      ,[ContractSize]
	  ,[PointValue]
  FROM [instr].[vwGenericFuture]
  WHERE MarketSectorDes = 'Curncy'
		
    ) AS source ON (target.[GenericFutureId] = source.[GenericFutureId])

   WHEN MATCHED THEN
        UPDATE SET
            target.[Symbol] = source.[Symbol],
            target.[RootSymbol] = source.[RootSymbol],
            target.[ContractSize] = source.[ContractSize],
			   target.[PointValue] = source.[PointValue]
    WHEN NOT MATCHED BY TARGET THEN
        INSERT (
             [GenericFutureId]
			  ,[Symbol]
			  ,[RootSymbol]
			  ,[ContractSize]
			  ,[PointValue]
        )
        VALUES (
            source.[GenericFutureId]
			  ,source.[Symbol]
			  ,source.[RootSymbol]
			  ,source.[ContractSize]
			  ,source.[PointValue]
        )
		    WHEN NOT MATCHED BY SOURCE THEN
        DELETE;


END
GO
/****** Object:  StoredProcedure [efrp].[spUpdateInstruments]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [efrp].[spUpdateInstruments]
AS
BEGIN
EXEC [efrp].[spUpdateGenericFutures]
EXEC [efrp].[spUpdateFutureContracts] 

END
GO
/****** Object:  StoredProcedure [exec].[spUpdateInstruments]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [exec].[spUpdateInstruments]
AS
BEGIN


    MERGE INTO [exec].Instrument AS target
    USING (
        SELECT 
       [InstrumentId]
      ,[Symbol]
      ,[Name]
	  ,[ISIN]
      ,[BbgUniqueId]
      ,[InstrumentType]
      ,[MarketSectorDes]
      ,[Exchange]
      ,[PrimaryMIC]
      ,[Currency]
      ,[QuoteCurrency]
	  ,gen.GenericFutureId
      ,CASE WHEN fut.LastTradeDate is not null THEN fut.LastTradeDate 
	        WHEN fwd.MaturityDate is not null THEN fwd.MaturityDate 
			ELSE NULL END as MaturityDate
      ,[PriceScalingFactor]
	  ,gen.PointValue as FuturePointValue
  FROM [instr].[vwInstrument] ins
  LEFT JOIN instr.FutureContract fut on fut.FutureContractId = ins.[InstrumentId]
  LEFT JOIN instr.GenericFuture gen on gen.GenericFutureId =fut.GenericFutureId
  LEFT JOIN instr.FxForward fwd on fwd.FxForwardId = ins.[InstrumentId]
		
    ) AS source ON (target.[InstrumentId] = source.[InstrumentId])

   WHEN MATCHED THEN
        UPDATE SET
            target.[InstrumentType] = source.[InstrumentType],
            target.[Symbol] = source.[Symbol],
            target.[Name] = source.[Name],
            target.[Currency] = source.[Currency],
            target.[BbgUniqueId] = source.[BbgUniqueId],
			target.[ISIN] = source.[ISIN],
		    target.[MarketSector] = source.[MarketSectorDes],
		 	target.[Exchange] = source.[Exchange],
			target.[PrimaryMIC] = source.[PrimaryMIC],
			target.[QuoteCurrency] = source.[QuoteCurrency],
			target.[PriceScalingFactor] = source.[PriceScalingFactor],
			target.MaturityDate = source.MaturityDate,
		    target.FuturePointValue = source.FuturePointValue,
			target.GenericFutureId = source.GenericFutureId
    WHEN NOT MATCHED BY TARGET THEN
        INSERT (
               [InstrumentId]
			  ,[Symbol]
			  ,[Name]
			  ,[ISIN]
			  ,[BbgUniqueId]
			  ,[InstrumentType]
			  ,[MarketSector]
			  ,[Exchange]
			  ,[PrimaryMIC]
			  ,[Currency]
			  ,[QuoteCurrency]
			  ,[PriceScalingFactor]
			  ,[MaturityDate]
			  ,FuturePointValue
			  ,GenericFutureId
        )
        VALUES (
                 source.[InstrumentId]
				  ,source.[Symbol]
				  ,source.[Name]
				  ,source.[ISIN]
				  ,source.[BbgUniqueId]
				  ,source.[InstrumentType]
				  ,source.[MarketSectorDes]
				  ,source.[Exchange]
				  ,source.[PrimaryMIC]
				  ,source.[Currency]
				  ,source.[QuoteCurrency]
				   ,source.[PriceScalingFactor]
			  ,source.[MaturityDate]
			  ,source.[FuturePointValue]
			  ,source.GenericFutureId
        )
		    WHEN NOT MATCHED BY SOURCE THEN
        DELETE;


END
GO
/****** Object:  StoredProcedure [instr].[spDeleteAllInstruments]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [instr].[spDeleteAllInstruments]

AS
BEGIN

DELETE FROM [instr].[FutureContract];
DELETE FROM [instr].[FxForward];
DELETE FROM [instr].[GenericFuture];
DELETE FROM [instr].[CurrencyPair];
DELETE FROM [instr].[Instrument];
DBCC CHECKIDENT ('[instr].[Instrument]', RESEED, 0);
END
GO
/****** Object:  StoredProcedure [instr].[spDeleteAllRefData]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [instr].[spDeleteAllRefData]

AS
BEGIN
EXEC  [instr].[spDeleteAllInstruments]

DELETE FROM [instr].[MIC];
DBCC CHECKIDENT ('[instr].[MIC]', RESEED, 0);

DELETE FROM [instr].[Exchange];
DBCC CHECKIDENT ('[instr].[Exchange]', RESEED, 0);

DELETE FROM [instr].[SecurityType];
DBCC CHECKIDENT ('[instr].[SecurityType]', RESEED, 0);

DELETE FROM [instr].[SecurityType2];
DBCC CHECKIDENT ('[instr].[SecurityType2]', RESEED, 0);

DELETE FROM [instr].[IndustryGroup];
DBCC CHECKIDENT ('[instr].[IndustryGroup]', RESEED, 0);

DELETE FROM [instr].[IndustrySector];
DBCC CHECKIDENT ('[instr].[IndustrySector]', RESEED, 0);

DELETE FROM [instr].[MarketSector];
DBCC CHECKIDENT ('[instr].[MarketSector]', RESEED, 0);

DELETE FROM [instr].[Currency];
DBCC CHECKIDENT ('[instr].[Currency]', RESEED, 0);

DELETE FROM [instr].[Country];
DBCC CHECKIDENT ('[instr].[Country]', RESEED, 0);
END
GO
/****** Object:  StoredProcedure [instr].[spMergeAllRefData]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [instr].[spMergeAllRefData]

AS
BEGIN
EXEC [instr].[spMergeRefDataIntoCountry]
EXEC [instr].[spMergeRefDataIntoCurrency]
EXEC [instr].[spMergeRefDataIntoExchange]
--EXEC [instr].[spMergeRefDataIntoIndustryGroup] --Removed from RefData
--EXEC [instr].[spMergeRefDataIntoIndustrySector]--Removed from RefData
EXEC [instr].[spMergeRefDataIntoMarketSector]
EXEC [instr].[spMergeRefDataIntoMIC]
EXEC [instr].[spMergeRefDataIntoSecurityType]
EXEC [instr].[spMergeRefDataIntoSecurityType2]
EXEC [instr].[spMergeRefDataIntoInstrument]
EXEC [instr].[spMergeRefDataIntoGenericFuture]
EXEC [instr].[spMergeRefDataIntoFutureContract]
EXEC [instr].[spMergeRefDataIntoCurrencyPair]
--EXEC [instr].[spMergeRefDataIntoFxForward] --FXFWD not traded anymore, the maturity is not retrieved anymore from refdata

END


GO
/****** Object:  StoredProcedure [instr].[spMergeDuplicates]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [instr].[spMergeDuplicates]
    @FromInstrumentId INT,
    @ToInstrumentId INT
AS
BEGIN
    -- Begin transaction
    BEGIN TRANSACTION;

    BEGIN TRY
        -- Merge the from entity into the to entity
        MERGE INTO instr.Instrument AS target
        USING (SELECT * FROM instr.Instrument WHERE InstrumentId = @FromInstrumentId) AS source
        ON target.InstrumentId = @ToInstrumentId
        WHEN MATCHED THEN
            UPDATE SET 
                target.InstrumentTypeId = source.InstrumentTypeId,
                target.Name = source.Name,
                target.CurrencyId = source.CurrencyId,
                target.ExchangeId = source.ExchangeId,
                target.ISIN = source.ISIN,
                target.BbgGlobalId = source.BbgGlobalId,
                -- target.BbgUniqueId = source.BbgUniqueId, -- Exclude this to maintain uniqueness
                target.CountryId = source.CountryId,
                target.PrimaryMICId = source.PrimaryMICId,
                target.MarketSectorId = source.MarketSectorId,
                target.IndustrySectorId = source.IndustrySectorId,
                target.IndustryGroupId = source.IndustryGroupId,
                target.SecurityTypeId = source.SecurityTypeId,
                target.SecurityType2Id = source.SecurityType2Id,
                target.PriceScalingFactor = source.PriceScalingFactor,
                target.QuoteCurrencyId = source.QuoteCurrencyId,
            
                target.QuoteFactor = source.QuoteFactor;

        -- Delete the from entity
        DELETE FROM instr.Instrument WHERE InstrumentId = @FromInstrumentId;

        -- Commit transaction
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Rollback transaction in case of error
        ROLLBACK TRANSACTION;

        -- Raise the error again
        THROW;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [instr].[spMergeRefDataIntoCountry]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [instr].[spMergeRefDataIntoCountry]

AS
BEGIN

MERGE INTO instr.Country AS target
USING (
  SELECT 
  DISTINCT TOP 1000 [COUNTRY_ISO] as IsoCode
  FROM [instr].[StgRefData]
  WHERE NULLIF(TRIM([COUNTRY_ISO]),'') IS NOT NULL
  ORDER  BY [COUNTRY_ISO]

) AS source
ON (target.IsoAlpha2Code = source.IsoCode)

WHEN NOT MATCHED BY TARGET THEN
    INSERT (IsoAlpha2Code, Name)
    VALUES (source.IsoCode, source.IsoCode);
END
GO
/****** Object:  StoredProcedure [instr].[spMergeRefDataIntoCurrency]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [instr].[spMergeRefDataIntoCurrency]

AS
BEGIN
WITH ConsolidatedCurrencies AS (
    SELECT DISTINCT 
           CRNCY AS CurrencyCode
    FROM [instr].[StgRefData]
    
    UNION
    
    SELECT DISTINCT 
           QUOTED_CRNCY AS CurrencyCode
    FROM [instr].[StgRefData]
	
	UNION
    
    SELECT DISTINCT 
           BASE_CRNCY AS CurrencyCode
    FROM [instr].[StgRefData]
)

MERGE INTO instr.Currency AS target
USING (
    SELECT  DISTINCT TOP 1000 CurrencyCode 
    FROM ConsolidatedCurrencies
    WHERE NULLIF(TRIM(CurrencyCode),'') IS NOT NULL
	ORDER BY CurrencyCode

) AS source
ON (target.Code = source.CurrencyCode)

WHEN NOT MATCHED BY TARGET THEN
    INSERT (Code, Name)
    VALUES (source.CurrencyCode, source.CurrencyCode);
END
GO
/****** Object:  StoredProcedure [instr].[spMergeRefDataIntoCurrencyPair]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [instr].[spMergeRefDataIntoCurrencyPair]
AS
BEGIN
    WITH currencyPairs AS (
        SELECT InstrumentId, BbgUniqueId
        FROM instr.Instrument ins
        JOIN instr.InstrumentType it ON it.InstrumentTypeId = ins.InstrumentTypeId
        WHERE it.Mnemonic = 'CROSS'
    )

    MERGE INTO instr.CurrencyPair AS target
    USING (
        SELECT DISTINCT TOP 100000
            InstrumentId,
            ccy1.CurrencyId AS BaseCurrencyId,
            ccy2.CurrencyId AS QuoteCurrencyId,
            ref.[QUOTE_FACTOR] AS QuoteFactor
        FROM instr.stgRefData ref
        JOIN currencyPairs cp ON cp.BbgUniqueId = ref.[ID_BB_UNIQUE]
        JOIN instr.Currency ccy1 ON ccy1.Code = ref.[BASE_CRNCY]
        JOIN instr.Currency ccy2 ON ccy2.Code = ref.[CRNCY]
        ORDER BY InstrumentId
    ) AS source
    ON (target.[CurrencyPairId] = source.InstrumentId)

    WHEN MATCHED THEN
        UPDATE SET
            target.[BaseCurrencyId] = source.BaseCurrencyId,
            target.[QuoteCurrencyId] = source.QuoteCurrencyId,
            target.[QuoteFactor] = source.QuoteFactor

    WHEN NOT MATCHED BY TARGET THEN
        INSERT (
            [CurrencyPairId],
            [BaseCurrencyId],
            [QuoteCurrencyId],
            [QuoteFactor]
        )
        VALUES (
            source.InstrumentId,
            source.BaseCurrencyId,
            source.QuoteCurrencyId,
            source.QuoteFactor
        )

    WHEN NOT MATCHED BY SOURCE THEN
        DELETE;
END
GO
/****** Object:  StoredProcedure [instr].[spMergeRefDataIntoExchange]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [instr].[spMergeRefDataIntoExchange]

AS
BEGIN

MERGE INTO instr.Exchange AS target
USING (
SELECT DISTINCT TOP 10000
      [EXCH_CODE]
      ,CASE WHEN [EXCH_CODE] = 'US' and [FUT_EXCH_NAME_LONG] is null 
		    THEN 'BBG US Composite Exchange' 
			ELSE	[FUT_EXCH_NAME_LONG] END [FUT_EXCH_NAME_LONG]
  FROM [instr].[StgRefData]
  WHERE NULLIF([EXCH_CODE],'') IS NOT NULL 
  ORDER BY [EXCH_CODE]

) AS source
ON (target.Code = source.[EXCH_CODE])

WHEN NOT MATCHED BY TARGET THEN
    INSERT (Code, Name)
    VALUES (source.[EXCH_CODE], source.[FUT_EXCH_NAME_LONG]);
END
GO
/****** Object:  StoredProcedure [instr].[spMergeRefDataIntoFutureContract]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [instr].[spMergeRefDataIntoFutureContract]
AS
BEGIN
    WITH futures AS (
        SELECT InstrumentId, BbgUniqueId, Symbol, MarketSectorId
        FROM instr.Instrument ins
        JOIN instr.InstrumentType it ON it.InstrumentTypeId = ins.InstrumentTypeId
        WHERE it.Mnemonic = 'FUT'
    ),
    genericfuture AS (
        SELECT gen.GenericFutureId, ins.Symbol, gen.RootSymbol, ins.MarketSectorId
        FROM [instr].[Instrument] ins
        JOIN instr.GenericFuture gen ON gen.GenericFutureId = ins.InstrumentId
    )

    MERGE INTO instr.FutureContract AS target
    USING (
        SELECT DISTINCT TOP 1000000
            fut.InstrumentId,
            genfut.GenericFutureId,
            mth.FutureContractMonthId,
            2000 + CAST(RIGHT(FUT_MONTH_YR, 2) AS INT) AS ContractYear,
            CAST(ref.[LAST_TRADEABLE_DT] AS DATE) AS LastTradeDate,
            CAST(ref.[FUT_NOTICE_FIRST] AS DATE) AS FirstNoticeDate,
            CAST(ref.[FUT_DLV_DT_FIRST] AS DATE) AS FirstDeliveryDate,
            CAST(ref.[FUT_ROLL_DT] AS DATE) AS RollDate
        FROM instr.stgRefData ref
        JOIN futures fut ON fut.BbgUniqueId = ref.[ID_BB_UNIQUE]
        JOIN instr.FutureContractMonth mth ON mth.Mnemonic = LEFT(ref.FUT_MONTH_YR, 3)
        JOIN genericfuture genfut ON ref.IDENTIFIER LIKE genfut.RootSymbol + '%' AND genfut.MarketSectorId = fut.MarketSectorId
        ORDER BY InstrumentId
    ) AS source
    ON (target.[FutureContractId] = source.InstrumentId)

    WHEN MATCHED THEN
        UPDATE SET
            target.[GenericFutureId] = source.GenericFutureId,
            target.[FutureContractMonthId] = source.FutureContractMonthId,
            target.[ContractYear] = source.ContractYear,
            target.[LastTradeDate] = source.LastTradeDate,
            target.[FirstNoticeDate] = source.FirstNoticeDate,
            target.[FirstDeliveryDate] = source.FirstDeliveryDate,
            target.[RollDate] = source.RollDate

    WHEN NOT MATCHED BY TARGET THEN
        INSERT (
            [FutureContractId],
            [GenericFutureId],
            [FutureContractMonthId],
            [ContractYear],
            [LastTradeDate],
            [FirstNoticeDate],
            [FirstDeliveryDate],
            [RollDate]
        )
        VALUES (
            source.InstrumentId,
            source.GenericFutureId,
            source.FutureContractMonthId,
            source.ContractYear,
            source.LastTradeDate,
            source.FirstNoticeDate,
            source.FirstDeliveryDate,
            source.RollDate
        );

END
GO
/****** Object:  StoredProcedure [instr].[spMergeRefDataIntoFxForward]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [instr].[spMergeRefDataIntoFxForward]
AS
BEGIN
    WITH fxforwards AS (
        SELECT InstrumentId, BbgUniqueId
        FROM instr.Instrument ins
        JOIN instr.InstrumentType it ON it.InstrumentTypeId = ins.InstrumentTypeId
        WHERE it.Mnemonic = 'FXFWD'
    )

    MERGE INTO instr.FxForward AS target
    USING (
        SELECT DISTINCT TOP 1000000
            InstrumentId,
            cp.CurrencyPairId,
            CAST(ref.MATURITY AS DATE) AS Maturity
        FROM instr.stgRefData ref
        JOIN fxforwards fwd ON fwd.BbgUniqueId = ref.[ID_BB_UNIQUE]
        JOIN instr.Currency ccy1 ON ccy1.Code = ref.[BASE_CRNCY]
        JOIN instr.Currency ccy2 ON ccy2.Code = ref.[CRNCY]
        JOIN instr.CurrencyPair cp ON cp.BaseCurrencyId = ccy1.CurrencyId AND cp.QuoteCurrencyId = ccy2.CurrencyId
        ORDER BY InstrumentId
    ) AS source
    ON (target.[FxForwardId] = source.InstrumentId)

    WHEN MATCHED THEN
        UPDATE SET
            target.[CurrencyPairId] = source.CurrencyPairId,
            target.[MaturityDate] = source.Maturity

    WHEN NOT MATCHED BY TARGET THEN
        INSERT (
            [FxForwardId],
            [CurrencyPairId],
            [MaturityDate]
        )
        VALUES (
            source.InstrumentId,
            source.CurrencyPairId,
            source.Maturity
        );
END
GO
/****** Object:  StoredProcedure [instr].[spMergeRefDataIntoGenericFuture]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [instr].[spMergeRefDataIntoGenericFuture]
AS
BEGIN
    WITH genericfutures AS (
        SELECT InstrumentId, BbgUniqueId
        FROM instr.Instrument ins
        JOIN instr.InstrumentType it ON it.InstrumentTypeId = ins.InstrumentTypeId
        WHERE it.Mnemonic = 'GENFUT'
    )

    MERGE INTO instr.GenericFuture AS target
    USING (
        SELECT DISTINCT TOP 1000000 genfut.InstrumentId
            , REPLACE(instr.vfRemoveYellowKey([IDENTIFIER]), '1', '') AS RootSymbol
            , CAST([FUT_CONT_SIZE] AS DECIMAL(18, 6)) AS ContractSize
            , CAST([FUT_TICK_SIZE] AS DECIMAL(12, 6)) AS TickSize
            , CAST([FUT_TICK_VAL] AS DECIMAL(12, 6)) AS TickValue
            , CAST([FUT_VAL_PT] AS DECIMAL(14, 6)) AS PointValue
        FROM [instr].[StgRefData] ref
        JOIN genericfutures genfut ON genfut.BbgUniqueId = ref.[ID_BB_UNIQUE]
        ORDER BY genfut.InstrumentId
    ) AS source
    ON (target.[GenericFutureId] = source.InstrumentId)

    WHEN MATCHED THEN
        UPDATE SET
            target.[RootSymbol] = source.RootSymbol,
            target.[ContractSize] = source.ContractSize,
            target.[TickSize] = source.TickSize,
            target.[TickValue] = source.TickValue,
            target.[PointValue] = source.PointValue

    WHEN NOT MATCHED BY TARGET THEN
        INSERT (
            [GenericFutureId],
            [RootSymbol],
            [ContractSize],
            [TickSize],
            [TickValue],
            [PointValue]
        )
        VALUES (
            source.InstrumentId,
            source.RootSymbol,
            source.ContractSize,
            source.TickSize,
            source.TickValue,
            source.PointValue
        );
END
GO
/****** Object:  StoredProcedure [instr].[spMergeRefDataIntoIndustryGroup]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [instr].[spMergeRefDataIntoIndustryGroup]

AS
BEGIN

MERGE INTO instr.IndustryGroup AS target
USING (
SELECT DISTINCT TOP 10000
      [INDUSTRY_GROUP_NUM]    
      ,[INDUSTRY_GROUP]
  
  FROM [instr].[StgRefData]
  WHERE NULLIF(TRIM([INDUSTRY_GROUP_NUM]),'') IS NOT NULL AND NULLIF(TRIM([INDUSTRY_GROUP]),'') IS NOT NULL
  ORDER BY [INDUSTRY_GROUP_NUM]


) AS source
ON (target.Number = source.[INDUSTRY_GROUP_NUM])

WHEN NOT MATCHED BY TARGET THEN
    INSERT (Number, name)
    VALUES (source.[INDUSTRY_GROUP_NUM], source.[INDUSTRY_GROUP]);
END
GO
/****** Object:  StoredProcedure [instr].[spMergeRefDataIntoIndustrySector]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [instr].[spMergeRefDataIntoIndustrySector]

AS
BEGIN

MERGE INTO instr.IndustrySector AS target
USING (
SELECT DISTINCT TOP 10000
      [INDUSTRY_Sector_NUM]    
      ,[INDUSTRY_Sector]
  
  FROM [instr].[StgRefData]
  WHERE NULLIF(TRIM([INDUSTRY_Sector_NUM]),'') IS NOT NULL AND NULLIF(TRIM([INDUSTRY_Sector]),'') IS NOT NULL
  ORDER BY [INDUSTRY_Sector_NUM]


) AS source
ON (target.Number = source.[INDUSTRY_Sector_NUM])

WHEN NOT MATCHED BY TARGET THEN
    INSERT (Number, name)
    VALUES (source.[INDUSTRY_Sector_NUM], source.[INDUSTRY_Sector]);
END
GO
/****** Object:  StoredProcedure [instr].[spMergeRefDataIntoInstrument]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [instr].[spMergeRefDataIntoInstrument]

AS
BEGIN

MERGE INTO instr.Instrument AS target
USING (

SELECT DISTINCT TOP 1000000
      [IDENTIFIER] as Symbol
	        ,refdata.[NAME]  
	,ityp.InstrumentTypeId
	  ,ctry.CountryId
	  ,ccy.CurrencyId
	  ,ex.ExchangeId    
      ,NULLIF([ID_BB_GLOBAL],'') as BbgGlobalId
      ,NULLIF([ID_BB_UNIQUE],'') as BbgUniqueId
      ,NULLIF([ID_ISIN],'')    as ISIN
	  ,NULLIF(primmic.MICId,'') as PrimaryMICId
	  ,ms.MarketSectorId  
	  --,sect.IndustrySectorId
	  --,grp.IndustryGroupId
	  ,sectyp.SecurityTypeId
	  ,sectyp2.SecurityType2Id
	  ,COALESCE( NULLIF(quoteccy.CurrencyId,''), ccy.CurrencyId) as QuoteCurrencyId
	  ,CASE WHEN TRIM(UPPER([SECURITY_TYP2])) = 'FUTURE' AND NULLIF([BB_TO_EXCH_PX_SCALING_FACTOR],'') is not null AND  TRIM([BB_TO_EXCH_PX_SCALING_FACTOR])<>'' AND [BB_TO_EXCH_PX_SCALING_FACTOR]<>[PX_SCALING_FACTOR] THEN cast([BB_TO_EXCH_PX_SCALING_FACTOR] as decimal(12,6)) ELSE cast([PX_SCALING_FACTOR] as decimal(12,6)) END as PriceScalingFactor
		,CAST(ISNULL(NULLIF(LTRIM(RTRIM(QUOTE_FACTOR)), ''), '1') AS DECIMAL(10, 4))  as QuoteFactor
  FROM [instr].[StgRefData] refdata
LEFT JOIN instr.Currency ccy on ccy.Code = CRNCY
LEFT JOIN instr.Currency quoteccy on quoteccy.Code = COALESCE([QUOTED_CRNCY],CRNCY)
LEFT JOIN instr.Exchange ex on ex.Code = NULLIF([EXCH_CODE],'')
LEFT JOIN instr.MarketSector ms on ms.Mnemonic = [MARKET_SECTOR_DES]
LEFT JOIN instr.Country ctry on ctry.IsoAlpha2Code = [COUNTRY_ISO]
LEFT JOIN instr.MIC primmic on primmic.Code = NULLIF([ID_MIC_PRIM_EXCH],'')
LEFT JOIN instr.SecurityType sectyp on sectyp.Name = [SECURITY_TYP]
LEFT JOIN instr.SecurityType2 sectyp2 on sectyp2.Name = [SECURITY_TYP2]
--LEFT JOIN instr.IndustryGroup grp on grp.Number =  NULLIF([INDUSTRY_GROUP_NUM],'')
--LEFT JOIN instr.IndustrySector sect on sect.Number =  NULLIF([INDUSTRY_SECTOR_NUM],'')
LEFT JOIN instr.InstrumentType ityp on ityp.Mnemonic = CASE WHEN UPPER(TRIM([MARKET_SECTOR_DES])) = 'EQUITY' THEN 'EQU'
															WHEN UPPER(TRIM(SECURITY_TYP2)) = 'FUTURE' AND UPPER(TRIM(refdata.[NAME])) like'%GENERIC%' THEN 'GENFUT'
														   
														   WHEN UPPER(TRIM(SECURITY_TYP2)) = 'FUTURE' AND UPPER(TRIM(refdata.[NAME])) NOT like'%GENERIC%' THEN 'FUT'
														   WHEN UPPER(TRIM([MARKET_SECTOR_DES])) = 'CURNCY' AND UPPER(TRIM(SECURITY_TYP))= 'FORWARD' THEN 'FXFWD'
														   WHEN UPPER(TRIM([MARKET_SECTOR_DES])) = 'CURNCY' AND UPPER(TRIM(SECURITY_TYP))= 'CROSS' THEN 'CROSS' END 
ORDER BY [IDENTIFIER]
) AS source
ON (target.[BbgUniqueId] = source.[BbgUniqueId])
 WHEN MATCHED THEN
        UPDATE SET
            target.[Symbol] = source.[Symbol],
            target.[Name] = source.[Name],
			target.[CurrencyId] = source.[CurrencyId],

			target.[ExchangeId] = source.[ExchangeId],
            target.[ISIN] = source.[ISIN],
			target.[BbgGlobalId] = source.[BbgGlobalId],
            target.[CountryId] = source.[CountryId],
		    target.[PrimaryMICId] = source.[PrimaryMICId],
			target.[MarketSectorId] = source.[MarketSectorId],
			--target.[IndustrySectorId] = source.[IndustrySectorId],
			--target.[IndustryGroupId] = source.[IndustryGroupId],
		    target.[SecurityTypeId] = source.[SecurityTypeId],
			target.[SecurityType2Id] = source.[SecurityType2Id],
		    target.QuoteCurrencyId = source.QuoteCurrencyId,
			target.QuoteFactor = source.QuoteFactor,
	        target.PriceScalingFactor = source.PriceScalingFactor
WHEN NOT MATCHED BY TARGET THEN
    INSERT ([InstrumentTypeId]
      ,[Symbol]
      ,[Name]
      ,[CurrencyId]
      ,[ExchangeId]
      ,[ISIN]
      ,[BbgGlobalId]
      ,[BbgUniqueId]
      ,[CountryId]
      ,[PrimaryMICId]
      ,[MarketSectorId]
      --,[IndustrySectorId]
      --,[IndustryGroupId]
      ,[SecurityTypeId]
      ,[SecurityType2Id]
	  ,QuoteCurrencyId
	  ,PriceScalingFactor
	  ,QuoteFactor)
    VALUES (source.[InstrumentTypeId]
      ,source.[Symbol]
      ,source.[Name]
      ,source.[CurrencyId]
      ,source.[ExchangeId]
      ,source.[ISIN]
      ,source.[BbgGlobalId]
      ,source.[BbgUniqueId]
      ,source.[CountryId]
      ,source.[PrimaryMICId]
      ,source.[MarketSectorId]
      --,source.[IndustrySectorId]
      --,source.[IndustryGroupId]
      ,source.[SecurityTypeId]
      ,source.[SecurityType2Id]
	  ,source.QuoteCurrencyId
	  ,source.PriceScalingFactor
	  ,source.QuoteFactor);
END
GO
/****** Object:  StoredProcedure [instr].[spMergeRefDataIntoMarketSector]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [instr].[spMergeRefDataIntoMarketSector]

AS
BEGIN

MERGE INTO instr.MarketSector AS target
USING (
SELECT DISTINCT TOP 100
      [MARKET_SECTOR_DES]      
  FROM [instr].[StgRefData]
  WHERE NULLIF(TRIM([MARKET_SECTOR_DES]),'') IS NOT NULL
  ORDER BY [MARKET_SECTOR_DES]

) AS source
ON (target.Mnemonic = source.[MARKET_SECTOR_DES])

WHEN NOT MATCHED BY TARGET THEN
    INSERT (Mnemonic, name)
    VALUES (source.[MARKET_SECTOR_DES], source.[MARKET_SECTOR_DES]);
END
GO
/****** Object:  StoredProcedure [instr].[spMergeRefDataIntoMIC]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [instr].[spMergeRefDataIntoMIC]

AS
BEGIN

MERGE INTO instr.MIC AS target
USING (
SELECT distinct TOP 10000
      [ID_MIC_PRIM_EXCH] 
  FROM [instr].[StgRefData]
  WHERE NULLIF(TRIM([ID_MIC_PRIM_EXCH]),'') IS NOT NULL
  ORDER BY [ID_MIC_PRIM_EXCH]


) AS source
ON (target.Code = source.[ID_MIC_PRIM_EXCH])

WHEN NOT MATCHED BY TARGET THEN
    INSERT (Code)
    VALUES (source.[ID_MIC_PRIM_EXCH]);
END
GO
/****** Object:  StoredProcedure [instr].[spMergeRefDataIntoSecurityType]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [instr].[spMergeRefDataIntoSecurityType]

AS
BEGIN

MERGE INTO instr.SecurityType AS target
USING (
SELECT DISTINCT TOP 10000
      [SECURITY_TYP] 
  
  FROM [instr].[StgRefData]
  WHERE NULLIF(TRIM([SECURITY_TYP]),'') IS NOT NULL
  ORDER BY [SECURITY_TYP]


) AS source
ON (target.Name = source.[SECURITY_TYP])

WHEN NOT MATCHED BY TARGET THEN
    INSERT (NAme)
    VALUES (source.[SECURITY_TYP]);
END
GO
/****** Object:  StoredProcedure [instr].[spMergeRefDataIntoSecurityType2]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [instr].[spMergeRefDataIntoSecurityType2]

AS
BEGIN

MERGE INTO instr.SecurityType2 AS target
USING (
SELECT DISTINCT TOP 10000
      [SECURITY_TYP2] 
  
  FROM [instr].[StgRefData]
  WHERE NULLIF(TRIM([SECURITY_TYP2]),'') IS NOT NULL
  ORDER BY [SECURITY_TYP2]


) AS source
ON (target.Name = source.[SECURITY_TYP2])

WHEN NOT MATCHED BY TARGET THEN
    INSERT (NAme)
    VALUES (source.[SECURITY_TYP2]);
END
GO
/****** Object:  StoredProcedure [instr].[spPropagateUpdateInstruments]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [instr].[spPropagateUpdateInstruments]

AS
BEGIN

-- Execute the procedures
EXEC dbo.spExecuteProcAcrossSchemas 'spUpdateInstruments'

END


GO
/****** Object:  StoredProcedure [mktdata].[Backup_spMergeMarketData]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [mktdata].[Backup_spMergeMarketData]
AS
BEGIN
    WITH stgmarketdata AS (
       SELECT ins.InstrumentId,
               ins.Symbol,
               ins.QuoteCurrency,
			   ins.Currency,
			   ins.PriceScalingFactor,
	
               IIF( CHARINDEX(':', [LAST_UPDATE]) > 0, CAST([LAST_UPDATE] AS TIME), NULL ) AS [LAST_UPDATE],
               CAST(stg.[PX_YEST_DT]  AS DATE) AS [LAST_UPDATE_DATE_EOD],
               CAST(IIF([LAST_UPDATE_DT]is null, GETDATE(),[LAST_UPDATE_DT]) AS DATE) AS [LAST_UPDATE_DT],
               CAST(NULLIF([PX_HIGH],'') AS DECIMAL(18,6))/ins.QuoteFactor AS [PX_HIGH],
               CAST(NULLIF([PX_LAST],'') AS DECIMAL(18,6))/ins.QuoteFactor AS [PX_LAST],
               CAST(NULLIF([PX_LAST_EOD],'') AS DECIMAL(18,6))/ins.QuoteFactor AS [PX_LAST_EOD],
               CAST(NULLIF([PX_LOW],'') AS DECIMAL(18,6))/ins.QuoteFactor AS [PX_LOW],
               CAST(NULLIF([PX_OPEN],'') AS DECIMAL(18,6))/ins.QuoteFactor AS [PX_OPEN],
               CAST(NULLIF([PX_VOLUME],'') AS DECIMAL(18,6)) AS [PX_VOLUME],
               CAST(NULLIF([OPEN_INT],'') AS DECIMAL(18,6)) AS [OPEN_INT],
               CAST(NULLIF([CUR_MKT_CAP],'') AS DECIMAL(18,6)) AS [CUR_MKT_CAP],
			   CAST(NULLIF([PX_YEST_CLOSE],'') AS DECIMAL(18,6)) AS [PX_YEST_CLOSE],
               CAST(NULLIF([VOLUME_AVG_30D],'') AS DECIMAL(18,6)) AS [VOLUME_AVG_30D],
               CAST(NULLIF([VOLUME_AVG_3M],'') AS DECIMAL(18,6)) AS [VOLUME_AVG_3M],
               CAST(NULLIF([VOLUME_AVG_6M],'') AS DECIMAL(18,6)) AS [VOLUME_AVG_6M]
        FROM [mktdata].[StgMarketData] stg
        JOIN mktdata.Instrument ins ON ins.Symbol = stg.IDENTIFIER
	
    )
    
    MERGE INTO mktdata.MarketData AS target
    USING (
      SELECT DISTINCT 
               stg.InstrumentId,
               QuoteCurrency,
			   stg.Currency,
                [LAST_UPDATE] AS LastUpdateTime,
                [LAST_UPDATE_DATE_EOD]AS LastUpdateDateEod,
              [LAST_UPDATE_DT] AS LastUpdateDate,
               COALESCE(stg.[PX_OPEN], mktdt.[Open]) AS [Open],
               COALESCE(stg.[PX_HIGH], mktdt.[High]) AS [High],
               COALESCE(stg.[PX_LOW], mktdt.[Low]) AS [Low],
               COALESCE(stg.[PX_LAST], mktdt.[LastPrice]) AS [LastPrice],
               COALESCE(stg.[PX_YEST_CLOSE], stg.[PX_LAST],mktdt.[LastPriceEod], mktdt.[LastPrice])  AS [LastPriceEod],--need to fill with the previous day
               COALESCE(stg.[PX_VOLUME], mktdt.[Volume]) AS [Volume],
               COALESCE(stg.[VOLUME_AVG_30D], mktdt.[VolumeAvg30Day]) AS [VolumeAvg30Day],
               COALESCE(stg.[VOLUME_AVG_3M], mktdt.[VolumeAvg3Month]) AS [VolumeAvg3Month],
               COALESCE(stg.[VOLUME_AVG_6M], mktdt.[VolumeAvg6Month]) AS [VolumeAvg6Month],		
               COALESCE(stg.[OPEN_INT], mktdt.[OpenInterest]) AS [OpenInterest],
               COALESCE(stg.[CUR_MKT_CAP], mktdt.[MarketCap]) AS [MarketCap]
        FROM stgmarketdata stg
        LEFT JOIN mktdata.MarketData mktdt ON mktdt.InstrumentId = stg.InstrumentId 
                                           AND mktdt.LastUpdateDateEod = stg.[LAST_UPDATE_DATE_EOD]
        WHERE  stg.[PX_LAST] IS NOT NULL and stg.[PX_YEST_CLOSE] IS NOT NULL


    ) AS source ON (target.InstrumentId = source.InstrumentId AND target.LastUpdateDateEod = source.LastUpdateDateEod)
	 WHEN MATCHED THEN
        UPDATE SET
            target.[Open] = source.[Open],
            target.[High] = source.[High],
			target.[Low] = source.[Low],

			target.[LastPrice] = source.[LastPrice],
            target.[LastPriceEod] = source.[LastPriceEod],
			target.[Volume] = source.[Volume],
            target.[VolumeAvg30Day] = source.[VolumeAvg30Day],
			target.[VolumeAvg3Month] = source.[VolumeAvg3Month],
            target.[VolumeAvg6Month] = source.[VolumeAvg6Month],
			target.[OpenInterest] = source.[OpenInterest],
            target.[MarketCap] = source.[MarketCap],
			target.[LastUpdateDate] = source.[LastUpdateDate],
            target.[LastUpdateDateEod] = source.[LastUpdateDateEod],
			target.[LastUpdateTime] = source.[LastUpdateTime],
            target.[Currency] = source.[Currency]
			
    WHEN NOT MATCHED BY TARGET THEN
        INSERT ([InstrumentId],
                [Open],
                [High],
                [Low],
                [LastPrice],
                [LastPriceEod],
                [Volume],
                [VolumeAvg30Day],
                [VolumeAvg3Month],
                [VolumeAvg6Month],
                [OpenInterest],
                [MarketCap],
                [LastUpdateDate],
                [LastUpdateDateEod],
                [LastUpdateTime],
                [Currency])
        VALUES (source.[InstrumentId], 
                source.[Open],
                source.[High],
                source.[Low],
				source.[LastPrice],
				source.[LastPriceEod],
				source.[Volume],
				source.[VolumeAvg30Day],
				source.[VolumeAvg3Month],
				source.[VolumeAvg6Month],
				source.[OpenInterest],
				source.[MarketCap],
				source.LastUpdateDate,
				source.LastUpdateDateEod,
				source.LastUpdateTime,
				source.[Currency]);
END
GO
/****** Object:  StoredProcedure [mktdata].[spDeleteAllMarketData]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [mktdata].[spDeleteAllMarketData]

AS
BEGIN
 delete FROM [mktdata].[FxRate]
 delete FROM [mktdata].[Instrument]
 delete FROM [mktdata].[MarketData]
 delete FROM [mktdata].[StgMarketData]
END
GO
/****** Object:  StoredProcedure [mktdata].[spMergeMarketData]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [mktdata].[spMergeMarketData]
AS
BEGIN
    WITH stgmarketdata AS (
       SELECT ins.InstrumentId,
               ins.Symbol,
               ins.QuoteCurrency,
			   ins.Currency,
			   ins.PriceScalingFactor,
	
               IIF( CHARINDEX(':', [LAST_UPDATE]) > 0, CAST([LAST_UPDATE] AS TIME), NULL ) AS [LAST_UPDATE],
               CAST(stg.[PX_YEST_DT]  AS DATE) AS [LAST_UPDATE_DATE_EOD],
               CAST(IIF([LAST_UPDATE_DT]is null, GETDATE(),[LAST_UPDATE_DT]) AS DATE) AS [LAST_UPDATE_DT],
             
               CAST(NULLIF([PX_LAST],'') AS DECIMAL(18,6))/ins.QuoteFactor AS [PX_LAST],
               CAST(NULLIF([PX_LAST_EOD],'') AS DECIMAL(18,6))/ins.QuoteFactor AS [PX_LAST_EOD],
            
               CAST(NULLIF([CUR_MKT_CAP],'') AS DECIMAL(18,6)) AS [CUR_MKT_CAP],
			   CAST(NULLIF([PX_YEST_CLOSE],'') AS DECIMAL(18,6)) AS [PX_YEST_CLOSE],
               CAST(NULLIF([VOLUME_AVG_30D],'') AS DECIMAL(18,6)) AS [VOLUME_AVG_30D]
             
        FROM [mktdata].[StgMarketData] stg
        JOIN mktdata.Instrument ins ON ins.Symbol = stg.IDENTIFIER
	
    )
    
    MERGE INTO mktdata.MarketData AS target
    USING (
      SELECT DISTINCT 
               stg.InstrumentId,
               QuoteCurrency,
			   stg.Currency,
                [LAST_UPDATE] AS LastUpdateTime,
                [LAST_UPDATE_DATE_EOD]AS LastUpdateDateEod,
              [LAST_UPDATE_DT] AS LastUpdateDate,              
               COALESCE(stg.[PX_LAST], mktdt.[LastPrice]) AS [LastPrice],
               COALESCE(stg.[PX_YEST_CLOSE], stg.[PX_LAST],mktdt.[LastPriceEod], mktdt.[LastPrice])  AS [LastPriceEod],--need to fill with the previous day            
               COALESCE(stg.[VOLUME_AVG_30D], mktdt.[VolumeAvg30Day]) AS [VolumeAvg30Day],            
               COALESCE(stg.[CUR_MKT_CAP], mktdt.[MarketCap]) AS [MarketCap]
        FROM stgmarketdata stg
        LEFT JOIN mktdata.MarketData mktdt ON mktdt.InstrumentId = stg.InstrumentId 
                                           AND mktdt.LastUpdateDateEod = stg.[LAST_UPDATE_DATE_EOD]
        WHERE  stg.[PX_LAST] IS NOT NULL and stg.[PX_YEST_CLOSE] IS NOT NULL


    ) AS source ON (target.InstrumentId = source.InstrumentId AND target.LastUpdateDateEod = source.LastUpdateDateEod)
	 WHEN MATCHED THEN
        UPDATE SET          
			target.[LastPrice] = source.[LastPrice],
            target.[LastPriceEod] = source.[LastPriceEod],			
            target.[VolumeAvg30Day] = source.[VolumeAvg30Day],			
            target.[MarketCap] = source.[MarketCap],
			target.[LastUpdateDate] = source.[LastUpdateDate],
            target.[LastUpdateDateEod] = source.[LastUpdateDateEod],
			target.[LastUpdateTime] = source.[LastUpdateTime],
            target.[Currency] = source.[Currency]
			
    WHEN NOT MATCHED BY TARGET THEN
        INSERT ([InstrumentId],
                [LastPrice],
                [LastPriceEod],
                [VolumeAvg30Day],              
                [MarketCap],
                [LastUpdateDate],
                [LastUpdateDateEod],
                [LastUpdateTime],
                [Currency])
        VALUES (source.[InstrumentId], 
				source.[LastPrice],
				source.[LastPriceEod],
				source.[VolumeAvg30Day],
				source.[MarketCap],
				source.LastUpdateDate,
				source.LastUpdateDateEod,
				source.LastUpdateTime,
				source.[Currency]);
END
GO
/****** Object:  StoredProcedure [mktdata].[spMergeMarketDataIntoFxRate]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [mktdata].[spMergeMarketDataIntoFxRate]
AS
BEGIN

    MERGE INTO mktdata.FxRate AS target
    USING (
        SELECT DISTINCT TOP 1000000 
		   ins.InstrumentId,
		   ccy1.Code as BaseCurrency,
		   ccy2.Code as QuoteCurrency,
		   CAST([PX_LAST] as decimal(18,6))/ins.QuoteFactor as LastValue,
		   CAST([PX_YEST_CLOSE] as decimal(18,6))/ins.QuoteFactor  as LastValueEod,	   
		   CAST([LAST_UPDATE_DT] as DATE) as LastUpdateDate,
		   CAST([PX_YEST_DT] as DATE) as LastUpdateDateEod,
			CASE  WHEN CHARINDEX(':', [LAST_UPDATE]) > 0 THEN CAST([LAST_UPDATE] AS TIME)
					   ELSE NULL 
				   END AS LastUpdateTime	  
		  FROM [mktdata].[StgMarketData] stg
		  JOIN instr.Instrument ins on ins.Symbol = stg.IDENTIFIER
		  JOIN instr.CurrencyPair cp on cp.CurrencyPairId =  ins.InstrumentId
		  JOIN instr.Currency ccy1 on ccy1.CurrencyId =  cp.BaseCurrencyId
		  JOIN instr.Currency ccy2 on ccy2.CurrencyId =  cp.QuoteCurrencyId
		ORDER BY ccy1.Code,ccy2.Code
    ) AS source ON (target.BaseCurrency = source.BaseCurrency AND target.QuoteCurrency = source.QuoteCurrency AND target.[LastUpdateDateEod] = source.[LastUpdateDateEod])
		 WHEN MATCHED THEN
        UPDATE SET
            target.[BaseCurrency] = source.[BaseCurrency],
            target.[QuoteCurrency] = source.[QuoteCurrency],
			target.[LastValue] = source.[LastValue],

			target.[LastValueEod] = source.[LastValueEod],
            target.[LastUpdateDate] = source.[LastUpdateDate],
			target.[LastUpdateDateEod] = source.[LastUpdateDateEod],
            target.[LastUpdateTime] = source.[LastUpdateTime]
			
    WHEN NOT MATCHED BY TARGET THEN
        INSERT ([BaseCurrency]
      ,[QuoteCurrency]
      ,[LastValue]
      ,[LastValueEod]
      ,[LastUpdateDate]
      ,[LastUpdateDateEod]
      ,[LastUpdateTime])
        VALUES (source.[BaseCurrency]
      ,source.[QuoteCurrency]
      ,source.[LastValue]
      ,source.[LastValueEod]
      ,source.[LastUpdateDate]
      ,source.[LastUpdateDateEod]
      ,source.[LastUpdateTime]);
END
GO
/****** Object:  StoredProcedure [mktdata].[spMergeVolumeData]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [mktdata].[spMergeVolumeData]
AS
BEGIN
WITH stgmarketdata AS (
    SELECT 
        ins.InstrumentId,
        CAST(NULLIF([PX_VOLUME_1D], '') AS DECIMAL(18, 6)) AS [Volume1Day],
        CAST([DL_SNAPSHOT_START_TIME] AS Date) AS [LastUpdateDate],
        CAST([DL_SNAPSHOT_START_TIME] AS Time) AS [LastUpdateTime]
    FROM 
        [mktdata].[StgVolumeData] stg
    JOIN 
        mktdata.Instrument ins ON ins.Symbol = Replace(stg.IDENTIFIER,' COMB ', ' ')
		 WHERE
        NULLIF([PX_VOLUME_1D], '') IS NOT NULL --added to avoid updating null volumes when market close.
	
)

MERGE INTO mktdata.VolumeData AS target
USING stgmarketdata AS source 
ON (
    target.InstrumentId = source.InstrumentId 
    AND target.LastUpdateDate = source.LastUpdateDate
)
WHEN MATCHED THEN
    UPDATE SET
        target.[Volume1Day] = source.[Volume1Day],
        target.[LastUpdateTime] = source.LastUpdateTime
WHEN NOT MATCHED BY TARGET THEN
    INSERT (
        [InstrumentId],
        [LastUpdateDate],
        [LastUpdateTime],
        [Volume1Day]
    )
    VALUES (
        source.[InstrumentId], 
        source.[LastUpdateDate],
        source.[LastUpdateTime],
        source.[Volume1Day]
    );
END

GO
/****** Object:  StoredProcedure [mktdata].[spPropagateUpdateFxRates]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO









-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [mktdata].[spPropagateUpdateFxRates]

AS
BEGIN

-- Execute the procedures
EXEC dbo.spExecuteProcAcrossSchemas 'spUpdateFxRates'

END


GO
/****** Object:  StoredProcedure [mktdata].[spPropagateUpdateMarketData]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [mktdata].[spPropagateUpdateMarketData]

AS
BEGIN

-- Execute the procedures
EXEC dbo.spExecuteProcAcrossSchemas 'spUpdateMarketData'

END


GO
/****** Object:  StoredProcedure [mktdata].[spPropagateUpdatVolumeData]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO









-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [mktdata].[spPropagateUpdatVolumeData]

AS
BEGIN

-- Execute the procedures
EXEC dbo.spExecuteProcAcrossSchemas 'spUpdateVolumeData'

END


GO
/****** Object:  StoredProcedure [mktdata].[spUpdateInstruments]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [mktdata].[spUpdateInstruments]
AS
BEGIN

    MERGE INTO mktdata.Instrument AS target
    USING (
        SELECT 
       [InstrumentId]
      ,[Symbol]
      ,[InstrumentType]
	  ,[Exchange]
      ,[QuoteCurrency]
      ,[PriceScalingFactor]
	  ,Currency
	  , QuoteFactor
  FROM [instr].[vwInstrument] ins

		
    ) AS source ON (target.[InstrumentId] = source.[InstrumentId])
	
WHEN MATCHED THEN 
    UPDATE SET
      target.[Symbol] = source.[Symbol],
      target.[InstrumentType] = source.[InstrumentType],
      target.[Exchange] = source.[Exchange],
      target.[QuoteCurrency] = source.[QuoteCurrency],
      target.[PriceScalingFactor] = source.[PriceScalingFactor],
      target.Currency = source.Currency,
      target.QuoteFactor = source.QuoteFactor
    WHEN NOT MATCHED BY TARGET THEN
        INSERT ( [InstrumentId]
      ,[Symbol]
      ,[InstrumentType]
	  ,[Exchange]
      ,[QuoteCurrency]
      ,[PriceScalingFactor]
	  ,Currency
	  ,QuoteFactor)
        VALUES ( source.[InstrumentId]
      ,source.[Symbol]
      ,source.[InstrumentType]
	  ,source.[Exchange]
      ,source.[QuoteCurrency]
      ,source.[PriceScalingFactor]
	  ,source.Currency
	  ,source.QuoteFactor)
WHEN NOT MATCHED BY SOURCE THEN
      DELETE;
END
GO
/****** Object:  StoredProcedure [ord].[spUpdateExchanges]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [ord].[spUpdateExchanges]
AS
BEGIN
    MERGE INTO [ord].Exchange AS target
    USING (
        SELECT 
            [ExchangeId],
            [Code]
        FROM [instr].[Exchange]
    ) AS source ON (target.[ExchangeId] = source.[ExchangeId])

    WHEN MATCHED THEN
        UPDATE SET
            target.[Code] = source.[Code] -- Update all fields except ExchangeId

    WHEN NOT MATCHED BY TARGET THEN
        INSERT ([ExchangeId], [Code])
        VALUES (source.[ExchangeId], source.[Code])
	WHEN NOT MATCHED BY SOURCE THEN
        DELETE;
END
GO
/****** Object:  StoredProcedure [ord].[spUpdateInstruments]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [ord].[spUpdateInstruments]
AS
BEGIN
EXEC [ord].[spUpdateExchanges]
EXEC [ord].[spUpdateInstrumentTypes]

    MERGE INTO ord.Instrument AS target
    USING (
     SELECT 
       [InstrumentId]
      ,[InstrumentTypeId]
      ,[Symbol]
      ,[Name]
      ,[Currency]
      ,[Exchange]
      ,[MarketSectorDes]
      ,[ExchangeId]
	  ,fut.GenericFutureId
	  ,COALESCE(fwd.MaturityDate,fut.LastTradeDate) as Maturity
  FROM [instr].[vwInstrument] ins
  LEFT JOIN instr.FxForward fwd on fwd.FxForwardId = ins.InstrumentId
  LEFT JOIN instr.FutureContract fut on fut.FutureContractId = ins.InstrumentId
		
    ) AS source ON (target.[InstrumentId] = source.[InstrumentId])

   WHEN MATCHED THEN
        UPDATE SET
            target.[InstrumentTypeId] = source.[InstrumentTypeId],
            target.[Symbol] = source.[Symbol],
            target.[Name] = source.[Name],
            target.[Currency] = source.[Currency],
            target.[MarketSector] = source.[MarketSectorDes],
			target.GenericFutureId = source.GenericFutureId,
			target.Maturity = source.Maturity
    WHEN NOT MATCHED BY TARGET THEN
        INSERT (
            [InstrumentId],
            [InstrumentTypeId],
            [Symbol],
            [Name],
            [Currency],
            [Exchange],
            [MarketSector],
            [ExchangeId],
			GenericFutureId,
			Maturity 
        )
        VALUES (
            source.[InstrumentId],
            source.[InstrumentTypeId],
            source.[Symbol],
            source.[Name],
            source.[Currency],
            source.[Exchange],
            source.[MarketSectorDes],
            source.[ExchangeId],
			source.GenericFutureId,
			source.Maturity
        )
		    WHEN NOT MATCHED BY SOURCE THEN
        DELETE;


END
GO
/****** Object:  StoredProcedure [ord].[spUpdateInstrumentTypes]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [ord].[spUpdateInstrumentTypes]
AS
BEGIN

    MERGE INTO [ord].InstrumentType AS target
    USING (
        SELECT 
       [InstrumentTypeId]
      ,[Mnemonic]
	  ,[Description]
  FROM [instr].[InstrumentType]
		
    ) AS source ON (target.[InstrumentTypeId] = source.[InstrumentTypeId])
	 WHEN MATCHED THEN
        UPDATE SET
            target.[Mnemonic] = source.[Mnemonic],
            target.[Description] = source.[Description]
    WHEN NOT MATCHED BY TARGET THEN
        INSERT (  [InstrumentTypeId]
      ,[Mnemonic]
	  ,[Description])
        VALUES ( source.[InstrumentTypeId]
      ,source.[Mnemonic]
	  ,source.[Description])
    WHEN NOT MATCHED BY SOURCE THEN
        DELETE;

END
GO
/****** Object:  StoredProcedure [port].[spComputeMissingPositions]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [port].[spComputeMissingPositions]

AS
BEGIN
   declare @DaysToCompute int;

SELECT @DaysToCompute = DATEDIFF(day, MAX(PositionDate), GETUTCDATE()) 
FROM port.Position;
EXEC [port].[spComputePositions] @DaysToCompute

END
GO
/****** Object:  StoredProcedure [port].[spComputePositions]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [port].[spComputePositions]
@DaysBack int =5
AS
BEGIN
DECLARE @CutoffDate DATE = DATEADD(DAY, -ABS(@DaysBack), CAST(GETDATE() AS DATE));
WITH DateRange AS (
    -- Generates a list of dates from the first trade until today
    SELECT cast (MIN(LastTradeDate) as date ) AS DateValue
    FROM [port].BookedTradeAllocation 
	where  LastTradeDate >= @CutoffDate
    UNION ALL
    SELECT DATEADD(DAY, 1, DateValue)
    FROM DateRange 
    WHERE DateValue <cast ( GETDATE()as date )
), allPositions as(
SELECT 
    dr.DateValue AS PositionDate,
    PortfolioId,
    alloc.InstrumentId,
    ins.InstrumentType,
    ins.[Name] AS InstrumentName,
	alloc.IsSwap,
    ins.Symbol,
    SUM(Quantity) AS Quantity,
	SUM(Quantity*TradePrice) as PositionValueLocal,
   CASE WHEN SUM(Quantity) =0 THEN 0 
   ELSE SUM(Quantity*TradePrice)/SUM(Quantity) END as AvgTradePriceLocal,
    Sum(GrossAmount) as GrossTotalCostLocal,
    Sum(Commission) as TotalCommissionLocal,
    Sum(NetAmount) as NetTotalCostLocal,
    MAX(TradeAllocationId) as LastTradeAllocationId,
    CAST(MAX(LastTradeDate) as date) as LastTradeDate,
    MAX(LastTradeDate) AS LastTradeDateTime,
    GETUTCDATE() as PositionDateTimeUtc,
    TradeCurrency AS TradeCurrency
FROM 
    DateRange dr
CROSS JOIN [port].BookedTradeAllocation alloc 
JOIN [port].Instrument ins on ins.InstrumentId = alloc.InstrumentId
WHERE 
    alloc.LastTradeDate <= dr.DateValue  -- to get the state of the position as of that date
GROUP BY 
    dr.DateValue,
    PortfolioId,
	alloc.IsSwap,
    alloc.InstrumentId,
	ins.InstrumentType,
    ins.[Name], 
    ins.Symbol,
    TradeCurrency
), CTE_Positions as(
SELECT PositionDate,
    PortfolioId,
    InstrumentId,
	IsSwap,
    Symbol,
	 InstrumentType,
   InstrumentName,
     Quantity,
	 PositionValueLocal,
   AvgTradePriceLocal as AvgEntryPriceLocal,
   TotalCommissionLocal,
    GrossTotalCostLocal,
     NetTotalCostLocal,
    LastTradeAllocationId,
     LastTradeDate,
    LastTradeDateTime,
     PositionDateTimeUtc,
    TradeCurrency
	from allPositions )

MERGE INTO [port].[Position] AS Target
USING (
SELECT 
    cur.[PortfolioId]
  , cur.[InstrumentId]
  , cur.Symbol
  ,cur.IsSwap
  , cur.InstrumentType
  , cur.InstrumentName
  , cur.[Quantity] AS Quantity
  , cur.AvgEntryPriceLocal AS AvgEntryPriceLocal
  ,cur.PositionValueLocal as PositionValueLocal
  ,cur.TotalCommissionLocal as TotalCommissionLocal
  , cur.[GrossTotalCostLocal] AS GrossTotalCostLocal
  , cur.[NetTotalCostLocal] AS NetTotalCostLocal
  , cur.[LastTradeAllocationId] AS LastTradeAllocationId
  , cur.[PositionDate] AS PositionDate
  , cur.[TradeCurrency]
FROM 
    CTE_Positions cur
       ) AS Source
ON (Target.[PortfolioId] = Source.[PortfolioId] 
    AND Target.[InstrumentId] = Source.[InstrumentId]
    AND Target.[PositionDate] = Source.[PositionDate]
    AND Target.[Currency] = Source.[TradeCurrency])
WHEN MATCHED THEN 
    UPDATE SET
        Target.[Quantity] = Source.[Quantity],
		Target.[IsSwap] = Source.[IsSwap],
        Target.[AvgEntryPriceLocal] = Source.[AvgEntryPriceLocal],
		Target.[PositionValueLocal] = Source.[PositionValueLocal],
        Target.[GrossTotalCostLocal] = Source.[GrossTotalCostLocal],
        Target.[NetTotalCostLocal] = Source.[NetTotalCostLocal],
        Target.[LastTradeAllocationId] = Source.[LastTradeAllocationId],
		Target.[TotalCommissionLocal]= Source.[TotalCommissionLocal]
WHEN NOT MATCHED BY TARGET THEN
    INSERT ([PortfolioId], 
            [InstrumentId], 
			[IsSwap],
            [Quantity], 
            [AvgEntryPriceLocal], 
			[PositionValueLocal],
            [GrossTotalCostLocal], 
            [NetTotalCostLocal], 
            [LastTradeAllocationId], 
            [PositionDate], 
            [Currency],	
			TotalCommissionLocal)
    VALUES (Source.[PortfolioId], 
            Source.[InstrumentId], 
			Source.[IsSwap],
            Source.[Quantity], 
            Source.[AvgEntryPriceLocal], 
			Source.[PositionValueLocal],
            Source.[GrossTotalCostLocal], 
            Source.[NetTotalCostLocal], 
            Source.[LastTradeAllocationId], 
            Source.[PositionDate], 
            Source.[TradeCurrency],
			TotalCommissionLocal)

	 OPTION (MAXRECURSION 1000);
	 EXEC [port].spPropagateUpdatePositions
END
GO
/****** Object:  StoredProcedure [port].[spComputePositionsAll]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [port].[spComputePositionsAll]

AS
BEGIN
WITH DateRange AS (
    -- Generates a list of dates from the first trade until today
    SELECT cast (MIN(LastTradeDate) as date ) AS DateValue
    FROM [port].BookedTradeAllocation 
    UNION ALL
    SELECT DATEADD(DAY, 1, DateValue)
    FROM DateRange 
    WHERE DateValue <cast ( GETDATE()as date )
), allPositions as(
SELECT 
    dr.DateValue AS PositionDate,
    PortfolioId,
    alloc.InstrumentId,
    ins.InstrumentType,
    ins.[Name] AS InstrumentName,
    ins.Symbol,
	alloc.IsSwap,
    SUM(Quantity) AS Quantity,
	SUM(Quantity*TradePrice) as PositionValueLocal,
   CASE WHEN SUM(Quantity) =0 THEN 0 
   ELSE SUM(Quantity*TradePrice)/SUM(Quantity) END as AvgTradePriceLocal,
    Sum(GrossAmount) as GrossTotalCostLocal,
    Sum(Commission) as TotalCommissionLocal,
    Sum(NetAmount) as NetTotalCostLocal,
    MAX(TradeAllocationId) as LastTradeAllocationId,
    CAST(MAX(LastTradeDate) as date) as LastTradeDate,
    MAX(LastTradeDate) AS LastTradeDateTime,
    GETUTCDATE() as PositionDateTimeUtc,
    TradeCurrency AS TradeCurrency
FROM 
    DateRange dr
CROSS JOIN [port].BookedTradeAllocation alloc 
JOIN [port].Instrument ins on ins.InstrumentId = alloc.InstrumentId
WHERE 
    alloc.LastTradeDate <= dr.DateValue  -- to get the state of the position as of that date
GROUP BY 
    dr.DateValue,
    PortfolioId,
    alloc.InstrumentId,
	ins.InstrumentType,
	alloc.IsSwap,
    ins.[Name], 
    ins.Symbol,
    TradeCurrency
), CTE_Positions as(
SELECT PositionDate,
    PortfolioId,
    InstrumentId,
    Symbol,
	 InstrumentType,
	 IsSwap,
   InstrumentName,
     Quantity,
	 PositionValueLocal,
   AvgTradePriceLocal as AvgEntryPriceLocal,
   TotalCommissionLocal,
    GrossTotalCostLocal,
     NetTotalCostLocal,
    LastTradeAllocationId,
     LastTradeDate,
    LastTradeDateTime,
     PositionDateTimeUtc,
    TradeCurrency
	
	from allPositions )

MERGE INTO [port].[Position] AS Target
USING (
SELECT 
    cur.[PortfolioId]
  , cur.[InstrumentId]
  , cur.Symbol
  , cur.InstrumentType
  , cur.InstrumentName
  ,cur.IsSwap
  , cur.[Quantity] AS Quantity
  , cur.AvgEntryPriceLocal AS AvgEntryPriceLocal
  ,cur.PositionValueLocal as PositionValueLocal
  ,cur.TotalCommissionLocal as TotalCommissionLocal
  , cur.[GrossTotalCostLocal] AS GrossTotalCostLocal
  , cur.[NetTotalCostLocal] AS NetTotalCostLocal
  , cur.[LastTradeAllocationId] AS LastTradeAllocationId
  , cur.[PositionDate] AS PositionDate
  , cur.[TradeCurrency] AS [TradeCurrency]
FROM 
    CTE_Positions cur


       ) AS Source
ON (Target.[PortfolioId] = Source.[PortfolioId] 
    AND Target.[InstrumentId] = Source.[InstrumentId]
    AND Target.[PositionDate] = Source.[PositionDate]
	AND Target.IsSwap = Source.IsSwap
    AND Target.[Currency] = Source.[TradeCurrency])
WHEN MATCHED THEN 
    UPDATE SET
        Target.[Quantity] = Source.[Quantity],
        Target.[AvgEntryPriceLocal] = Source.[AvgEntryPriceLocal],
		Target.[PositionValueLocal] = Source.[PositionValueLocal],
        Target.[GrossTotalCostLocal] = Source.[GrossTotalCostLocal],
        Target.[NetTotalCostLocal] = Source.[NetTotalCostLocal],
        Target.[LastTradeAllocationId] = Source.[LastTradeAllocationId],
		Target.IsSwap = Source.IsSwap,
		
		Target.[TotalCommissionLocal]= Source.[TotalCommissionLocal]
WHEN NOT MATCHED BY TARGET THEN
    INSERT ([PortfolioId], 
            [InstrumentId], 
			IsSwap,
            [Quantity], 
            [AvgEntryPriceLocal], 
			[PositionValueLocal],
            [GrossTotalCostLocal], 
            [NetTotalCostLocal], 
            [LastTradeAllocationId], 
            [PositionDate], 
            [Currency],
			
			TotalCommissionLocal)
    VALUES (Source.[PortfolioId], 
            Source.[InstrumentId], 
			Source.IsSwap,
            Source.[Quantity], 
            Source.[AvgEntryPriceLocal], 
			Source.[PositionValueLocal],
            Source.[GrossTotalCostLocal], 
            Source.[NetTotalCostLocal], 
            Source.[LastTradeAllocationId], 
            Source.[PositionDate], 
            Source.[TradeCurrency],
		
			Source.TotalCommissionLocal)
 WHEN NOT MATCHED BY SOURCE THEN DELETE
	 OPTION (MAXRECURSION 1000);
	 EXEC [port].spPropagateUpdatePositions
END
GO
/****** Object:  StoredProcedure [port].[spComputePositionsByInstrument]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [port].[spComputePositionsByInstrument]
@DaysBack tinyint =5,
@InstrumentId int
AS
BEGIN
DECLARE @CutoffDate DATE = DATEADD(DAY, -ABS(@DaysBack), CAST(GETDATE() AS DATE));
WITH DateRange AS (
    -- Generates a list of dates from the first trade until today
    SELECT cast (MIN(LastTradeDate) as date ) AS DateValue
    FROM [port].BookedTradeAllocation 
	where  LastTradeDate >= @CutoffDate
    UNION ALL
    SELECT DATEADD(DAY, 1, DateValue)
    FROM DateRange 
    WHERE DateValue <cast ( GETDATE()as date )
), allPositions as(
SELECT 
    dr.DateValue AS PositionDate,
    PortfolioId,
    alloc.InstrumentId,
    ins.InstrumentType,
    ins.[Name] AS InstrumentName,
	alloc.IsSwap,
    ins.Symbol,
    SUM(Quantity) AS Quantity,
	SUM(Quantity*TradePrice) as PositionValueLocal,
   CASE WHEN SUM(Quantity) =0 THEN 0 
   ELSE SUM(Quantity*TradePrice)/SUM(Quantity) END as AvgTradePriceLocal,
    Sum(GrossAmount) as GrossTotalCostLocal,
    Sum(Commission) as TotalCommissionLocal,
    Sum(NetAmount) as NetTotalCostLocal,
    MAX(TradeAllocationId) as LastTradeAllocationId,
    CAST(MAX(LastTradeDate) as date) as LastTradeDate,
    MAX(LastTradeDate) AS LastTradeDateTime,
    GETUTCDATE() as PositionDateTimeUtc,
    TradeCurrency AS TradeCurrency
FROM 
    DateRange dr
CROSS JOIN [port].BookedTradeAllocation alloc 
JOIN [port].Instrument ins on ins.InstrumentId = alloc.InstrumentId
WHERE 
    alloc.LastTradeDate <= dr.DateValue and alloc.InstrumentId = @InstrumentId -- to get the state of the position as of that date
GROUP BY 
    dr.DateValue,
    PortfolioId,
	alloc.IsSwap,
    alloc.InstrumentId,
	ins.InstrumentType,
    ins.[Name], 
    ins.Symbol,
    TradeCurrency
), CTE_Positions as(
SELECT PositionDate,
    PortfolioId,
    InstrumentId,
	IsSwap,
    Symbol,
	 InstrumentType,
   InstrumentName,
     Quantity,
	 PositionValueLocal,
   AvgTradePriceLocal as AvgEntryPriceLocal,
   TotalCommissionLocal,
    GrossTotalCostLocal,
     NetTotalCostLocal,
    LastTradeAllocationId,
     LastTradeDate,
    LastTradeDateTime,
     PositionDateTimeUtc,
    TradeCurrency
	from allPositions )

MERGE INTO [port].[Position] AS Target
USING (
SELECT 
    cur.[PortfolioId]
  , cur.[InstrumentId]
  , cur.Symbol
  ,cur.IsSwap
  , cur.InstrumentType
  , cur.InstrumentName
  , cur.[Quantity] AS Quantity
  , cur.AvgEntryPriceLocal AS AvgEntryPriceLocal
  ,cur.PositionValueLocal as PositionValueLocal
  ,cur.TotalCommissionLocal as TotalCommissionLocal
  , cur.[GrossTotalCostLocal] AS GrossTotalCostLocal
  , cur.[NetTotalCostLocal] AS NetTotalCostLocal
  , cur.[LastTradeAllocationId] AS LastTradeAllocationId
  , cur.[PositionDate] AS PositionDate
  , cur.[TradeCurrency]
FROM 
    CTE_Positions cur
       ) AS Source
ON (Target.[PortfolioId] = Source.[PortfolioId] 
    AND Target.[InstrumentId] = Source.[InstrumentId]
    AND Target.[PositionDate] = Source.[PositionDate]
    AND Target.[Currency] = Source.[TradeCurrency])
WHEN MATCHED THEN 
    UPDATE SET
        Target.[Quantity] = Source.[Quantity],
		Target.[IsSwap] = Source.[IsSwap],
        Target.[AvgEntryPriceLocal] = Source.[AvgEntryPriceLocal],
		Target.[PositionValueLocal] = Source.[PositionValueLocal],
        Target.[GrossTotalCostLocal] = Source.[GrossTotalCostLocal],
        Target.[NetTotalCostLocal] = Source.[NetTotalCostLocal],
        Target.[LastTradeAllocationId] = Source.[LastTradeAllocationId],
		Target.[TotalCommissionLocal]= Source.[TotalCommissionLocal]
WHEN NOT MATCHED BY TARGET THEN
    INSERT ([PortfolioId], 
            [InstrumentId], 
			[IsSwap],
            [Quantity], 
            [AvgEntryPriceLocal], 
			[PositionValueLocal],
            [GrossTotalCostLocal], 
            [NetTotalCostLocal], 
            [LastTradeAllocationId], 
            [PositionDate], 
            [Currency],	
			TotalCommissionLocal)
    VALUES (Source.[PortfolioId], 
            Source.[InstrumentId], 
			Source.[IsSwap],
            Source.[Quantity], 
            Source.[AvgEntryPriceLocal], 
			Source.[PositionValueLocal],
            Source.[GrossTotalCostLocal], 
            Source.[NetTotalCostLocal], 
            Source.[LastTradeAllocationId], 
            Source.[PositionDate], 
            Source.[TradeCurrency],
			TotalCommissionLocal)

	 OPTION (MAXRECURSION 1000);
	 EXEC [port].spPropagateUpdatePositions
END
GO
/****** Object:  StoredProcedure [port].[spPropagateUpdatePositions]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [port].[spPropagateUpdatePositions]

AS
BEGIN

-- Execute the procedures
EXEC dbo.spExecuteProcAcrossSchemas 'spUpdatePositions'

END


GO
/****** Object:  StoredProcedure [port].[spUpdateBookedTrades]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [port].[spUpdateBookedTrades]

AS
BEGIN

MERGE INTO [port].[BookedTradeAllocation] AS target
USING (
    SELECT  
		[TradeId],
        [TradeAllocationId],
		[IsSwap],	
        [PortfolioId],
        [InstrumentId],
		[Quantity],
		[GrossAvgPriceLocal] as TradePrice,
		[GrossPrincipalLocal] as GrossAmount,
		[NetPrincipalLocal] as NetAmount,
		[CommissionAmountLocal] as Commission,
		MiscFeesLocal as Fees,
		[LocalCurrency] as TradeCurrency,
        [TradeDate] as [LastTradeDate]
    FROM [book].[vwTradeAllocation]
	where  TradeStatus <> 'CAN'
) AS source
ON (target.[TradeAllocationId] = source.[TradeAllocationId])
WHEN MATCHED THEN 
    UPDATE SET 
	     target.[TradeId] = source.[TradeId],
        target.[PortfolioId] = source.[PortfolioId],
        target.[InstrumentId] = source.[InstrumentId],
        target.[Quantity] = source.[Quantity],
        target.TradePrice = source.TradePrice,
        target.GrossAmount = source.GrossAmount,
		target.IsSwap = source.IsSwap,
        target.NetAmount = source.NetAmount,
        target.Commission = source.Commission,
        target.Fees = source.Fees,
        target.TradeCurrency = source.TradeCurrency,
        target.[LastTradeDate] = source.[LastTradeDate]
       
WHEN NOT MATCHED BY TARGET THEN
    INSERT ([TradeId]
       ,[TradeAllocationId]
      ,[PortfolioId]
      ,[InstrumentId]
	  ,[IsSwap]
      ,[Quantity]
      ,[TradePrice]
      ,[GrossAmount]
      ,[NetAmount]
      ,[Commission]
      ,[Fees]
      ,[TradeCurrency]
      ,[LastTradeDate]
    )
    VALUES (SOURCE.[TradeId]
        ,SOURCE.[TradeAllocationId]
      ,SOURCE.[PortfolioId]
      ,SOURCE.[InstrumentId]
	  ,SOURCE.[IsSwap]
      ,SOURCE.[Quantity]
      ,SOURCE.[TradePrice]
      ,SOURCE.[GrossAmount]
      ,SOURCE.[NetAmount]
      ,SOURCE.[Commission]
      ,SOURCE.[Fees]
      ,SOURCE.[TradeCurrency]
      ,SOURCE.[LastTradeDate]
    )WHEN NOT MATCHED BY SOURCE THEN DELETE;


END
GO
/****** Object:  StoredProcedure [port].[spUpdateInstruments]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [port].[spUpdateInstruments]
AS
BEGIN
    MERGE INTO [port].Instrument AS target
    USING (
        SELECT 
            [InstrumentId],
            [Symbol],
            [Name],
            [InstrumentType],
            [MarketSectorDes],
            [Currency]
        FROM [instr].[vwInstrument]
    ) AS source ON (target.[InstrumentId] = source.[InstrumentId])

    WHEN MATCHED THEN
        UPDATE SET
            target.[Symbol] = source.[Symbol],
            target.[Name] = source.[Name],
            target.[InstrumentType] = source.[InstrumentType],
            target.[MarketSector] = source.[MarketSectorDes],
            target.[Currency] = source.[Currency]

    WHEN NOT MATCHED BY TARGET THEN
        INSERT (
            [InstrumentId],
            [Symbol],
            [Name],
            [InstrumentType],
            [MarketSector],
            [Currency]
        )
        VALUES (
            source.[InstrumentId],
            source.[Symbol],
            source.[Name],
            source.[InstrumentType],
            source.[MarketSectorDes],
            source.[Currency]
        )

    WHEN NOT MATCHED BY SOURCE THEN
        DELETE;
END
GO
/****** Object:  StoredProcedure [port].[spUpdateTrades]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [port].[spUpdateTrades]

AS
BEGIN

MERGE INTO [port].[TradeAllocation] AS target
USING (SELECT [TradeAllocationId]
             ,alloc.[TradeId]
             ,[PortfolioId]
			 ,trd.InstrumentId
			 ,trd.TradeCurrency
             ,[Quantity]
             ,[Price]
             ,[GrossAmount]
             ,alloc.[NetAmount]
             ,[Commission]
             ,[Fees]
             ,[PositionSide]
             ,[TradingAccount]
			 ,trd.TradeDate
       FROM [trd].[TradeAllocation] alloc
	   JOIN trd.Trade trd on trd.TradeId =alloc.TradeId) AS source
ON (target.[TradeAllocationId] = source.[TradeAllocationId])

WHEN MATCHED THEN 
    UPDATE SET target.[PortfolioId] = source.[PortfolioId],
               target.[InstrumentId] = source.InstrumentId,  -- Assuming this mapping
               target.[Quantity] = source.[Quantity],
               target.[TradePrice] = source.[Price],
               target.[GrossAmount] = source.[GrossAmount],
               target.[NetAmount] = source.[NetAmount],
               target.[Commission] = source.[Commission],
               target.[Fees] = source.[Fees],
               target.[TradeCurrency] = source.[TradeCurrency],  -- Assuming this mapping
               target.[LastTradeDate] = source.TradeDate
			   -- Or whatever date you want to use

WHEN NOT MATCHED BY TARGET THEN
    INSERT ([TradeAllocationId], [PortfolioId], [InstrumentId], [Quantity], [TradePrice], [GrossAmount], 
            [NetAmount], [Commission], [Fees], [TradeCurrency], [LastTradeDate])
    VALUES (source.[TradeAllocationId], source.[PortfolioId], source.InstrumentId, source.[Quantity], 
            source.[Price], source.[GrossAmount], source.[NetAmount], source.[Commission], 
            source.[Fees], source.[TradeCurrency], source.TradeDate)  -- Adjust date as needed
 WHEN NOT MATCHED BY SOURCE THEN
     DELETE;

EXEC [port].[spComputePositions]

END
GO
/****** Object:  StoredProcedure [port].[ZZZ_spComputePositions]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [port].[ZZZ_spComputePositions]

AS
BEGIN
DECLARE @CutoffDate DATE = DATEADD(DAY, -10, CAST(GETDATE() AS DATE));
WITH DateRange AS (
    -- Generates a list of dates from the first trade until today
    SELECT cast (MIN(LastTradeDate) as date ) AS DateValue
    FROM [port].TradeAllocation 
	where  LastTradeDate >= @CutoffDate
    UNION ALL
    SELECT DATEADD(DAY, 1, DateValue)
    FROM DateRange 
    WHERE DateValue <cast ( GETDATE()as date )
), allPositions as(
SELECT 
    dr.DateValue AS PositionDate,
    PortfolioId,
    alloc.InstrumentId,
    ins.InstrumentType,
    ins.[Name] AS InstrumentName,
    ins.Symbol,
    SUM(Quantity) AS Quantity,
	SUM(Quantity*TradePrice) as PositionValueLocal,
   CASE WHEN SUM(Quantity) =0 THEN 0 
   ELSE SUM(Quantity*TradePrice)/SUM(Quantity) END as AvgTradePriceLocal,
    Sum(GrossAmount) as GrossTotalCostLocal,
    Sum(Commission) as TotalCommissionLocal,
    Sum(NetAmount) as NetTotalCostLocal,
    MAX(TradeAllocationId) as LastTradeAllocationId,
    CAST(MAX(LastTradeDate) as date) as LastTradeDate,
    MAX(LastTradeDate) AS LastTradeDateTime,
    GETUTCDATE() as PositionDateTimeUtc,
    TradeCurrency AS TradeCurrency
FROM 
    DateRange dr
CROSS JOIN [port].TradeAllocation alloc 
JOIN [port].Instrument ins on ins.InstrumentId = alloc.InstrumentId
WHERE 
    alloc.LastTradeDate <= dr.DateValue  -- to get the state of the position as of that date
GROUP BY 
    dr.DateValue,
    PortfolioId,
    alloc.InstrumentId,
	ins.InstrumentType,
    ins.[Name], 
    ins.Symbol,
    TradeCurrency
), CTE_Positions as(
SELECT PositionDate,
    PortfolioId,
    InstrumentId,
    Symbol,
	 InstrumentType,
   InstrumentName,
     Quantity,
	 PositionValueLocal,
   AvgTradePriceLocal as AvgEntryPriceLocal,
   TotalCommissionLocal,
    GrossTotalCostLocal,
     NetTotalCostLocal,
    LastTradeAllocationId,
     LastTradeDate,
    LastTradeDateTime,
     PositionDateTimeUtc,
    TradeCurrency,
	LAG([PositionDate]) OVER (PARTITION BY [PortfolioId], [InstrumentId] ORDER BY [PositionDate]) AS PreviousPositionDate
	from allPositions )

MERGE INTO [port].[ZZZ_Position] AS Target
USING (
SELECT 
    cur.[PortfolioId]
  , cur.[InstrumentId]
  , cur.Symbol
  , cur.InstrumentType
  , cur.InstrumentName
  , cur.[Quantity] AS Quantity
  , cur.AvgEntryPriceLocal AS AvgEntryPriceLocal
  ,cur.PositionValueLocal as PositionValueLocal
  ,cur.TotalCommissionLocal as TotalCommissionLocal
  , cur.[GrossTotalCostLocal] AS GrossTotalCostLocal
  , cur.[NetTotalCostLocal] AS NetTotalCostLocal
  , cur.[LastTradeAllocationId] AS LastTradeAllocationId
  , cur.[PositionDate] AS PositionDate
  , cur.[TradeCurrency]
  , ISNULL(prev.[Quantity],cur.[Quantity]) AS PreviousQuantity
  , ISNULL(prev.AvgEntryPriceLocal,cur.AvgEntryPriceLocal) AS PreviousAvgEntryPriceLocal
  , ISNULL(prev.[PositionValueLocal],cur.[PositionValueLocal]) AS PreviousPositionValueLocal
  , ISNULL(prev.[GrossTotalCostLocal],cur.[GrossTotalCostLocal])  AS PreviousGrossTotalCostLocal
  , ISNULL(prev.[NetTotalCostLocal],cur.[NetTotalCostLocal])  AS PreviousNetTotalCostLocal
  , prev.[PositionDate] AS PreviousPositionDate
FROM 
    CTE_Positions cur
LEFT JOIN 
    CTE_Positions prev ON cur.[PortfolioId] = prev.[PortfolioId]
                       AND cur.[InstrumentId] = prev.[InstrumentId]
                       AND cur.PreviousPositionDate = prev.[PositionDate]

       ) AS Source
ON (Target.[PortfolioId] = Source.[PortfolioId] 
    AND Target.[InstrumentId] = Source.[InstrumentId]
    AND Target.[PositionDate] = Source.[PositionDate]
    AND Target.[Currency] = Source.[TradeCurrency])
WHEN MATCHED THEN 
    UPDATE SET
        Target.[Quantity] = Source.[Quantity],
        Target.[AvgEntryPriceLocal] = Source.[AvgEntryPriceLocal],
		Target.[PositionValueLocal] = Source.[PositionValueLocal],
        Target.[GrossTotalCostLocal] = Source.[GrossTotalCostLocal],
        Target.[NetTotalCostLocal] = Source.[NetTotalCostLocal],
        Target.[LastTradeAllocationId] = Source.[LastTradeAllocationId],
		Target.[PreviousQuantity] = Source.[PreviousQuantity],
        Target.[PreviousAvgEntryPriceLocal] = Source.[PreviousAvgEntryPriceLocal],
	    Target.[PreviousPositionValueLocal] = Source.[PreviousPositionValueLocal],
        Target.[PreviousGrossTotalCostLocal] = Source.[PreviousGrossTotalCostLocal],
        Target.[PreviousNetTotalCostLocal] = Source.[PreviousNetTotalCostLocal],
		Target.[PreviousPositionDate] = Source.[PreviousPositionDate],
		Target.[TotalCommissionLocal]= Source.[TotalCommissionLocal]
WHEN NOT MATCHED BY TARGET THEN
    INSERT ([PortfolioId], 
            [InstrumentId], 
            [Quantity], 
            [AvgEntryPriceLocal], 
			[PositionValueLocal],
            [GrossTotalCostLocal], 
            [NetTotalCostLocal], 
            [LastTradeAllocationId], 
            [PositionDate], 
            [Currency],
			[PreviousQuantity],
			[PreviousAvgEntryPriceLocal],
			[PreviousPositionValueLocal],
			[PreviousGrossTotalCostLocal],
			[PreviousNetTotalCostLocal],
			[PreviousPositionDate],
			TotalCommissionLocal)
    VALUES (Source.[PortfolioId], 
            Source.[InstrumentId], 
            Source.[Quantity], 
            Source.[AvgEntryPriceLocal], 
			Source.[PositionValueLocal],
            Source.[GrossTotalCostLocal], 
            Source.[NetTotalCostLocal], 
            Source.[LastTradeAllocationId], 
            Source.[PositionDate], 
            Source.[TradeCurrency],
			 Source.[PreviousQuantity],
			 Source.[PreviousPositionValueLocal],
			 Source.[PreviousAvgEntryPriceLocal],
			 Source.[PreviousGrossTotalCostLocal],
			 Source.[PreviousNetTotalCostLocal],
			Source.[PreviousPositionDate],
			TotalCommissionLocal)

	 OPTION (MAXRECURSION 1000);
	 EXEC [port].spPropagateUpdatePositions
END
GO
/****** Object:  StoredProcedure [port].[ZZZ_spComputePositionsAll]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [port].[ZZZ_spComputePositionsAll]

AS
BEGIN
WITH DateRange AS (
    -- Generates a list of dates from the first trade until today
    SELECT cast (MIN(LastTradeDate) as date ) AS DateValue
    FROM [port].TradeAllocation 
    UNION ALL
    SELECT DATEADD(DAY, 1, DateValue)
    FROM DateRange 
    WHERE DateValue <cast ( GETDATE()as date )
), allPositions as(
SELECT 
    dr.DateValue AS PositionDate,
    PortfolioId,
    alloc.InstrumentId,
    ins.InstrumentType,
    ins.[Name] AS InstrumentName,
    ins.Symbol,
    SUM(Quantity) AS Quantity,
	SUM(Quantity*TradePrice) as PositionValueLocal,
   CASE WHEN SUM(Quantity) =0 THEN 0 
   ELSE SUM(Quantity*TradePrice)/SUM(Quantity) END as AvgTradePriceLocal,
    Sum(GrossAmount) as GrossTotalCostLocal,
    Sum(Commission) as TotalCommissionLocal,
    Sum(NetAmount) as NetTotalCostLocal,
    MAX(TradeAllocationId) as LastTradeAllocationId,
    CAST(MAX(LastTradeDate) as date) as LastTradeDate,
    MAX(LastTradeDate) AS LastTradeDateTime,
    GETUTCDATE() as PositionDateTimeUtc,
    TradeCurrency AS TradeCurrency
FROM 
    DateRange dr
CROSS JOIN [port].TradeAllocation alloc 
JOIN [port].Instrument ins on ins.InstrumentId = alloc.InstrumentId
WHERE 
    alloc.LastTradeDate <= dr.DateValue  -- to get the state of the position as of that date
GROUP BY 
    dr.DateValue,
    PortfolioId,
    alloc.InstrumentId,
	ins.InstrumentType,
    ins.[Name], 
    ins.Symbol,
    TradeCurrency
), CTE_Positions as(
SELECT PositionDate,
    PortfolioId,
    InstrumentId,
    Symbol,
	 InstrumentType,
   InstrumentName,
     Quantity,
	 PositionValueLocal,
   AvgTradePriceLocal as AvgEntryPriceLocal,
   TotalCommissionLocal,
    GrossTotalCostLocal,
     NetTotalCostLocal,
    LastTradeAllocationId,
     LastTradeDate,
    LastTradeDateTime,
     PositionDateTimeUtc,
    TradeCurrency,
	LAG([PositionDate]) OVER (PARTITION BY [PortfolioId], [InstrumentId] ORDER BY [PositionDate]) AS PreviousPositionDate
	from allPositions )

MERGE INTO [port].[ZZZ_Position] AS Target
USING (
SELECT 
    cur.[PortfolioId]
  , cur.[InstrumentId]
  , cur.Symbol
  , cur.InstrumentType
  , cur.InstrumentName
  , cur.[Quantity] AS Quantity
  , cur.AvgEntryPriceLocal AS AvgEntryPriceLocal
  ,cur.PositionValueLocal as PositionValueLocal
  ,cur.TotalCommissionLocal as TotalCommissionLocal
  , cur.[GrossTotalCostLocal] AS GrossTotalCostLocal
  , cur.[NetTotalCostLocal] AS NetTotalCostLocal
  , cur.[LastTradeAllocationId] AS LastTradeAllocationId
  , cur.[PositionDate] AS PositionDate
  , cur.[TradeCurrency]
  , ISNULL(prev.[Quantity],cur.[Quantity]) AS PreviousQuantity
  , ISNULL(prev.AvgEntryPriceLocal,cur.AvgEntryPriceLocal) AS PreviousAvgEntryPriceLocal
  , ISNULL(prev.[PositionValueLocal],cur.[PositionValueLocal]) AS PreviousPositionValueLocal
  , ISNULL(prev.[GrossTotalCostLocal],cur.[GrossTotalCostLocal])  AS PreviousGrossTotalCostLocal
  , ISNULL(prev.[NetTotalCostLocal],cur.[NetTotalCostLocal])  AS PreviousNetTotalCostLocal
  , prev.[PositionDate] AS PreviousPositionDate
FROM 
    CTE_Positions cur
LEFT JOIN 
    CTE_Positions prev ON cur.[PortfolioId] = prev.[PortfolioId]
                       AND cur.[InstrumentId] = prev.[InstrumentId]
                       AND cur.PreviousPositionDate = prev.[PositionDate]

       ) AS Source
ON (Target.[PortfolioId] = Source.[PortfolioId] 
    AND Target.[InstrumentId] = Source.[InstrumentId]
    AND Target.[PositionDate] = Source.[PositionDate]
    AND Target.[Currency] = Source.[TradeCurrency])
WHEN MATCHED THEN 
    UPDATE SET
        Target.[Quantity] = Source.[Quantity],
        Target.[AvgEntryPriceLocal] = Source.[AvgEntryPriceLocal],
		Target.[PositionValueLocal] = Source.[PositionValueLocal],
        Target.[GrossTotalCostLocal] = Source.[GrossTotalCostLocal],
        Target.[NetTotalCostLocal] = Source.[NetTotalCostLocal],
        Target.[LastTradeAllocationId] = Source.[LastTradeAllocationId],
		Target.[PreviousQuantity] = Source.[PreviousQuantity],
        Target.[PreviousAvgEntryPriceLocal] = Source.[PreviousAvgEntryPriceLocal],
	    Target.[PreviousPositionValueLocal] = Source.[PreviousPositionValueLocal],
        Target.[PreviousGrossTotalCostLocal] = Source.[PreviousGrossTotalCostLocal],
        Target.[PreviousNetTotalCostLocal] = Source.[PreviousNetTotalCostLocal],
		Target.[PreviousPositionDate] = Source.[PreviousPositionDate],
		Target.[TotalCommissionLocal]= Source.[TotalCommissionLocal]
WHEN NOT MATCHED BY TARGET THEN
    INSERT ([PortfolioId], 
            [InstrumentId], 
            [Quantity], 
            [AvgEntryPriceLocal], 
			[PositionValueLocal],
            [GrossTotalCostLocal], 
            [NetTotalCostLocal], 
            [LastTradeAllocationId], 
            [PositionDate], 
            [Currency],
			[PreviousQuantity],
			[PreviousAvgEntryPriceLocal],
			[PreviousPositionValueLocal],
			[PreviousGrossTotalCostLocal],
			[PreviousNetTotalCostLocal],
			[PreviousPositionDate],
			TotalCommissionLocal)
    VALUES (Source.[PortfolioId], 
            Source.[InstrumentId], 
            Source.[Quantity], 
            Source.[AvgEntryPriceLocal], 
			Source.[PositionValueLocal],
            Source.[GrossTotalCostLocal], 
            Source.[NetTotalCostLocal], 
            Source.[LastTradeAllocationId], 
            Source.[PositionDate], 
            Source.[TradeCurrency],
			 Source.[PreviousQuantity],
			 Source.[PreviousPositionValueLocal],
			 Source.[PreviousAvgEntryPriceLocal],
			 Source.[PreviousGrossTotalCostLocal],
			 Source.[PreviousNetTotalCostLocal],
			Source.[PreviousPositionDate],
			TotalCommissionLocal)
 WHEN NOT MATCHED BY SOURCE THEN
     DELETE
	 OPTION (MAXRECURSION 1000);
	 EXEC [port].spPropagateUpdatePositions
END
GO
/****** Object:  StoredProcedure [port].[ZZZ_spPropagateUpdatePositions]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [port].[ZZZ_spPropagateUpdatePositions]

AS
BEGIN

-- Execute the procedures
EXEC dbo.spExecuteProcAcrossSchemas 'ZZZ_spUpdatePositions'

END


GO
/****** Object:  StoredProcedure [pos].[spUpdateBookedTrades]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [pos].[spUpdateBookedTrades]

AS
BEGIN

MERGE INTO [pos].[TradeAllocation] AS target
USING (
    SELECT  
        [TradeAllocationId],
        [TradeId],
        [PortfolioId],
        [InstrumentId],
        [TradeDate],
        [IsSwap],
       
        [Isin],
        [Sedol],
        [Cusip],
        [SecurityName],
        [Quantity],
        [NominalQuantity],
        [LocalCurrency],
        [BaseCurrency],
        [GrossAvgPriceLocal],
        [GrossAvgPriceBase],
        [NetAvgPriceLocal],
        [NetAvgPriceBase],
        [CommissionAmountLocal],
        [CommissionAmountBase],
        [GrossTradeValueLocal],
        [NetTradeValueLocal],
        [GrossTradeValueBase],
        [NetTradeValueBase],
        [GrossPrincipalLocal],
        [NetPrincipalLocal],
        [GrossPrincipalBase],
        [NetPrincipalBase],
        [LocalToBaseFxRate],
        [LocalToSettleFxRate]
    FROM [book].[vwTradeAllocation]
		where  TradeStatus <> 'CAN'
) AS source
ON (target.[TradeAllocationId] = source.[TradeAllocationId])
WHEN MATCHED THEN 
    UPDATE SET 
        target.[TradeId] = source.[TradeId],
        target.[PortfolioId] = source.[PortfolioId],
        target.[InstrumentId] = source.[InstrumentId],
        target.[TradeDate] = source.[TradeDate],
        target.[IsSwap] = source.[IsSwap],

        target.[Isin] = source.[Isin],
        target.[Sedol] = source.[Sedol],
        target.[Cusip] = source.[Cusip],
        target.[SecurityName] = source.[SecurityName],
        target.[Quantity] = source.[Quantity],
        target.[NominalQuantity] = source.[NominalQuantity],
        target.[LocalCurrency] = source.[LocalCurrency],
        target.[BaseCurrency] = source.[BaseCurrency],
        target.[GrossAvgPriceLocal] = source.[GrossAvgPriceLocal],
        target.[GrossAvgPriceBase] = source.[GrossAvgPriceBase],
        target.[NetAvgPriceLocal] = source.[NetAvgPriceLocal],
        target.[NetAvgPriceBase] = source.[NetAvgPriceBase],
        target.[CommissionAmountLocal] = source.[CommissionAmountLocal],
        target.[CommissionAmountBase] = source.[CommissionAmountBase],
        target.[GrossTradeValueLocal] = source.[GrossTradeValueLocal],
        target.[NetTradeValueLocal] = source.[NetTradeValueLocal],
        target.[GrossTradeValueBase] = source.[GrossTradeValueBase],
        target.[NetTradeValueBase] = source.[NetTradeValueBase],
        target.[GrossPrincipalLocal] = source.[GrossPrincipalLocal],
        target.[NetPrincipalLocal] = source.[NetPrincipalLocal],
        target.[GrossPrincipalBase] = source.[GrossPrincipalBase],
        target.[NetPrincipalBase] = source.[NetPrincipalBase],
        target.[LocalToBaseFxRate] = source.[LocalToBaseFxRate],
        target.[LocalToSettleFxRate] = source.[LocalToSettleFxRate]
WHEN NOT MATCHED BY TARGET THEN
    INSERT (
        [TradeAllocationId],
        [TradeId],
        [PortfolioId],
        [InstrumentId],
        [TradeDate],
        [IsSwap],
 
        [Isin],
        [Sedol],
        [Cusip],
        [SecurityName],
        [Quantity],
        [NominalQuantity],
        [LocalCurrency],
        [BaseCurrency],
        [GrossAvgPriceLocal],
        [GrossAvgPriceBase],
        [NetAvgPriceLocal],
        [NetAvgPriceBase],
        [CommissionAmountLocal],
        [CommissionAmountBase],
        [GrossTradeValueLocal],
        [NetTradeValueLocal],
        [GrossTradeValueBase],
        [NetTradeValueBase],
        [GrossPrincipalLocal],
        [NetPrincipalLocal],
        [GrossPrincipalBase],
        [NetPrincipalBase],
        [LocalToBaseFxRate],
        [LocalToSettleFxRate]
    )
    VALUES (
        source.[TradeAllocationId],
        source.[TradeId],
        source.[PortfolioId],
        source.[InstrumentId],
        source.[TradeDate],
        source.[IsSwap],

        source.[Isin],
        source.[Sedol],
        source.[Cusip],
        source.[SecurityName],
        source.[Quantity],
        source.[NominalQuantity],
        source.[LocalCurrency],
        source.[BaseCurrency],
        source.[GrossAvgPriceLocal],
        source.[GrossAvgPriceBase],
        source.[NetAvgPriceLocal],
        source.[NetAvgPriceBase],
        source.[CommissionAmountLocal],
        source.[CommissionAmountBase],
        source.[GrossTradeValueLocal],
        source.[NetTradeValueLocal],
        source.[GrossTradeValueBase],
        source.[NetTradeValueBase],
        source.[GrossPrincipalLocal],
        source.[NetPrincipalLocal],
        source.[GrossPrincipalBase],
        source.[NetPrincipalBase],
        source.[LocalToBaseFxRate],
        source.[LocalToSettleFxRate]
    )WHEN NOT MATCHED BY SOURCE THEN DELETE;


END
GO
/****** Object:  StoredProcedure [pos].[spUpdateInstruments]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [pos].[spUpdateInstruments]
AS
BEGIN
    MERGE INTO [pos].Instrument AS target
    USING (
        SELECT 
            [InstrumentId],
            [Symbol],
            [Name],
            [InstrumentType],
            [MarketSectorDes],
            [Currency]
        FROM [instr].[vwInstrument]
    ) AS source ON (target.[InstrumentId] = source.[InstrumentId])

    WHEN MATCHED THEN
        UPDATE SET
            target.[Symbol] = source.[Symbol],
            target.[Name] = source.[Name],
            target.[InstrumentType] = source.[InstrumentType],
            target.[MarketSector] = source.[MarketSectorDes],
            target.[Currency] = source.[Currency]

    WHEN NOT MATCHED BY TARGET THEN
        INSERT (
            [InstrumentId],
            [Symbol],
            [Name],
            [InstrumentType],
            [MarketSector],
            [Currency]
        )
        VALUES (
            source.[InstrumentId],
            source.[Symbol],
            source.[Name],
            source.[InstrumentType],
            source.[MarketSectorDes],
            source.[Currency]
        );

   
END
GO
/****** Object:  StoredProcedure [pos].[spUpdatePositionForTest]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [pos].[spUpdatePositionForTest]
AS
BEGIN

WITH DateRange AS (
    -- Generates a list of dates from the first trade until today
    SELECT cast (MIN(TradeDate) as date ) AS DateValue
    FROM [pos].TradeAllocation 
    UNION ALL
    SELECT DATEADD(DAY, 1, DateValue)
    FROM DateRange 
    WHERE DateValue <cast ( GETDATE()as date )
), allPositions as(
SELECT 
      [PortfolioId]
	  ,dr.DateValue as PositionDate
      ,alloc.[InstrumentId]
      ,Max([TradeDate]) as LastTradeDate
      ,[IsSwap]
     
      ,sum([Quantity]) as [Quantity]
      ,sum([NominalQuantity]) as [NominalQuantity]
      ,[LocalCurrency]
      ,[BaseCurrency]
      ,sum([CommissionAmountLocal]) as [CommissionAmountLocal]
      ,sum([CommissionAmountBase]) as [CommissionAmountBase]
      ,sum([GrossTradeValueLocal]) as GrossTotalCostLocal
      ,sum([NetTradeValueLocal]) as NetTotalCostLocal
      ,sum([GrossTradeValueBase])as GrossTotalCostBase
      ,sum([NetTradeValueBase])as NetTotalCostBase
      ,sum([GrossPrincipalLocal])as GrossPrincipalLocal
      ,sum([NetPrincipalLocal])as NetPrincipalLocal
      ,sum([GrossPrincipalBase])as GrossPrincipalBase
      ,sum([NetPrincipalBase])as NetPrincipalBase
   
FROM 
    DateRange dr
CROSS JOIN [pos].TradeAllocation alloc 
JOIN [port].Instrument ins on ins.InstrumentId = alloc.InstrumentId
WHERE 
    alloc.TradeDate <= dr.DateValue  -- to get the state of the position as of that date
GROUP BY 
    dr.DateValue,
    PortfolioId,
	alloc.IsSwap,
	alloc.BaseCurrency,
    alloc.InstrumentId,
	ins.InstrumentType,
    ins.[Name], 
    ins.Symbol,
    LocalCurrency
), CTE_Positions as(
SELECT [PortfolioId]
	  , PositionDate
      ,[InstrumentId]
      , LastTradeDate
      ,[IsSwap]
      ,[Quantity]
      ,[NominalQuantity]
      ,[LocalCurrency]
      ,[BaseCurrency]
      ,IIF(Quantity <> 0,GrossTotalCostLocal/Quantity, 0) as [GrossEntryPriceLocal]
      ,IIF(Quantity  <> 0,GrossTotalCostBase/Quantity, 0) as [GrossEntryPriceBase]
      ,IIF(Quantity  <> 0,NetTotalCostLocal/Quantity, 0) as [NetEntryPriceLocal]
	  ,IIF(Quantity  <> 0,NetTotalCostBase/Quantity, 0) as [NetEntryPriceBase]
      ,[CommissionAmountLocal]
      ,[CommissionAmountBase]
      ,GrossTotalCostLocal
      , NetTotalCostLocal
      , GrossTotalCostBase
      ,NetTotalCostBase
      , GrossPrincipalLocal
      , NetPrincipalLocal
      , GrossPrincipalBase
      , NetPrincipalBase
	from allPositions )

select * from CTE_Positions

 OPTION (MAXRECURSION 0);



   
END
GO
/****** Object:  StoredProcedure [rebal].[spUpdateInstruments]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [rebal].[spUpdateInstruments]
AS
BEGIN

    MERGE INTO rebal.Instrument AS target
    USING (
        SELECT 
       [InstrumentId]
      ,[Symbol]
      ,[InstrumentType]
      ,[Currency]
  FROM [instr].[vwInstrument]
		
    ) AS source ON (target.[InstrumentId] = source.[InstrumentId])

    WHEN NOT MATCHED BY TARGET THEN
        INSERT ( [InstrumentId]
      ,[Symbol]
      ,[InstrumentType]
	  ,[Currency])
        VALUES ( source.[InstrumentId]
      ,source.[Symbol]
      ,source.[InstrumentType]
      ,source.[Currency]) WHEN NOT MATCHED BY SOURCE THEN
        DELETE;
END
GO
/****** Object:  StoredProcedure [risk].[spUpdateInstruments]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [risk].[spUpdateInstruments]
AS
BEGIN
    MERGE INTO [risk].Instrument AS target
    USING (
        SELECT
            [InstrumentId],
            [Symbol],
            [InstrumentType],
            [Currency]
        FROM [instr].[vwInstrument]
    ) AS source ON (target.[InstrumentId] = source.[InstrumentId])

    WHEN MATCHED THEN
        UPDATE SET
            target.[Symbol] = source.[Symbol],
            target.[InstrumentType] = source.[InstrumentType],
            target.[Currency] = source.[Currency]

    WHEN NOT MATCHED BY TARGET THEN
        INSERT (
            [InstrumentId],
            [Symbol],
            [InstrumentType],
            [Currency]
        )
        VALUES (
            source.[InstrumentId],
            source.[Symbol],
            source.[InstrumentType],
            source.[Currency]
        )

    WHEN NOT MATCHED BY SOURCE THEN
        DELETE;
END
GO
/****** Object:  StoredProcedure [roll].[spPropagateFutureContractRollInfo]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO










-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [roll].[spPropagateFutureContractRollInfo]

AS
BEGIN

-- Execute the procedures
EXEC dbo.spExecuteProcAcrossSchemas 'spUpdateFutureContractRollInfo'

END


GO
/****** Object:  StoredProcedure [roll].[spUpdateFutureContracts]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [roll].[spUpdateFutureContracts]
AS
MERGE INTO [roll].[FutureContract] AS target
USING [instr].[vwFutureContract] AS source
ON target.[FutureContractId] = source.[FutureContractId]

-- When records are matched, update them
WHEN MATCHED THEN 
UPDATE SET 
    target.[Symbol] = source.[Symbol],
    target.[GenericFutureId] = source.[GenericFutureId],
    target.[LastTradeDate] = source.[LastTradeDate],
    target.[FirstNoticeDate] = source.[FirstNoticeDate],
    target.[FirstDeliveryDate] = source.[FirstDeliveryDate],
    target.[RollDate] = source.[RollDate]

-- When no records are matched, insert a new record
WHEN NOT MATCHED BY TARGET THEN 
INSERT (
    [FutureContractId],
    [Symbol],
    [GenericFutureId],
    [LastTradeDate],
    [FirstNoticeDate],
    [FirstDeliveryDate],
    [RollDate]
)
VALUES (
    source.[FutureContractId],
    source.[Symbol],
    source.[GenericFutureId],
    source.[LastTradeDate],
    source.[FirstNoticeDate],
    source.[FirstDeliveryDate],
    source.[RollDate]
)
WHEN NOT MATCHED BY SOURCE THEN 
delete;


GO
/****** Object:  StoredProcedure [roll].[spUpdateFutureCurrentContracts]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [roll].[spUpdateFutureCurrentContracts]
AS
WITH currentcontractinfo AS (
    SELECT 
        fcri.GenericFutureId,
        fcri.FutureContractId,
        fcri.Volume,
        fcri.Symbol,
        fcri.VolumeRank,
        fcri.RollingPeriodStart,
        fcri.RollingPeriodEnd,
        fcri.DayToFirstRollingDate,
        fcri.DayToLastRollingDate,
        fcri.IsRollingPeriod
    FROM [roll].[vwFutureContractRollInfo2] fcri
    INNER JOIN [roll].FutureCurrentContract fcc ON fcc.FutureContractId = fcri.FutureContractId
),
computedcurrentcontract AS (
    SELECT 
        fcri.GenericFutureId,
        fcri.FutureContractId,
        fcri.Volume,
        fcri.Symbol,
        fcri.VolumeRank,
        fcri.RollingPeriodStart,
        fcri.RollingPeriodEnd,
        fcri.DayToFirstRollingDate,
        fcri.DayToLastRollingDate,
        fcri.IsRollingPeriod
    FROM [roll].[vwFutureContractRollInfo2] fcri
    LEFT JOIN currentcontractinfo fcc ON fcc.FutureContractId = fcri.FutureContractId
    WHERE fcri.VolumeRank = 1 AND (fcri.RollingPeriodEnd > fcc.RollingPeriodEnd OR fcc.GenericFutureId IS NULL)
)
MERGE INTO [roll].FutureCurrentContract AS TARGET
USING computedcurrentcontract AS SOURCE
ON TARGET.GenericFutureId = SOURCE.GenericFutureId
WHEN MATCHED THEN 
    UPDATE SET 
        TARGET.FutureContractId = SOURCE.FutureContractId
WHEN NOT MATCHED BY TARGET THEN
    INSERT (GenericFutureId, FutureContractId)
    VALUES (SOURCE.GenericFutureId, SOURCE.FutureContractId);


GO
/****** Object:  StoredProcedure [roll].[spUpdateFxForwards]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [roll].[spUpdateFxForwards]
AS
MERGE INTO [roll].[FxForward] AS target
USING [instr].[vwFxForward] AS source
ON target.[FxForwardId] = source.[FxForwardId]

-- When records are matched, update them
WHEN MATCHED THEN 
UPDATE SET 
    target.[Symbol] = source.[Symbol],
    target.[CurrencyPairId] = source.[CurrencyPairId],
    target.[MaturityDate] = source.[MaturityDate]

-- When no records are matched, insert a new record
WHEN NOT MATCHED BY TARGET THEN 
INSERT (
    [FxForwardId],
    [Symbol],
    [CurrencyPairId],
    [MaturityDate]
)
VALUES (
    source.[FxForwardId],
    source.[Symbol],
    source.[CurrencyPairId],
    source.[MaturityDate]
)
WHEN NOT MATCHED BY SOURCE THEN 
delete;


GO
/****** Object:  StoredProcedure [roll].[spUpdateInstruments]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [roll].[spUpdateInstruments]
AS
BEGIN
EXEC [roll].spUpdateFutureContracts;
EXEC [roll].spUpdateFxForwards;
END
GO
/****** Object:  StoredProcedure [roll].[spUpdatePositions]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [roll].[spUpdatePositions]
AS
BEGIN
MERGE INTO [roll].[Position] AS target
USING (
    SELECT [PortfolioId],
	ISNULL(fc.GenericFutureId, fx.CurrencyPairId) as GenericId,
    pos.[InstrumentId],
    [Quantity],
    [PositionDate],
    [Currency],
	[IsSwap]
    FROM [port].[vwLastOpenPosition] pos
    LEFT JOIN [roll].[FutureContract] fc ON pos.[InstrumentId] = fc.[FutureContractId]
    LEFT JOIN [roll].[FxForward] fx ON pos.[InstrumentId] = fx.[FxForwardId]
    WHERE fc.[FutureContractId] IS NOT NULL OR fx.[FxForwardId] IS NOT NULL
) AS source
ON target.[PortfolioId] = source.[PortfolioId] AND target.[ContractId] = source.[InstrumentId] AND Target.IsSwap = Source.IsSwap

-- When records are matched, update them
WHEN MATCHED THEN 
UPDATE SET 
    target.[Quantity] = source.[Quantity],
    target.[PositionDate] = source.[PositionDate],
    target.[Currency] = source.[Currency],
	target.[GenericId]=source.[GenericId]

-- When no records are matched, insert a new record
WHEN NOT MATCHED BY TARGET THEN 
INSERT (
    [PortfolioId],
    [ContractId],
	[GenericId],
    [Quantity],
    [PositionDate],
    [Currency],
	[IsSwap]
)
VALUES (
    source.[PortfolioId],
    source.[InstrumentId],
	source.[GenericId],
    source.[Quantity],
    source.[PositionDate],
    source.[Currency],
	Source.[IsSwap]
)
WHEN NOT MATCHED BY SOURCE THEN 
DELETE;
END
GO
/****** Object:  StoredProcedure [roll].[spUpdateVolumeData]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [roll].[spUpdateVolumeData]
AS
BEGIN TRANSACTION;
WITH volumes AS(
SELECT fc.GenericFutureId
		,vd.InstrumentId AS FutureContractId
      ,[LastUpdateDate]
	  , vd.Volume1Day
  FROM [mktdata].[VolumeData] vd
  JOIN roll.FutureContract fc ON fc.FutureContractId = vd.InstrumentId
), LastVolumeDate AS(
SELECT GenericFutureId
      ,max([LastUpdateDate]) AS LastVolumeDate
  FROM volumes vol
  GROUP BY  GenericFutureId
  ), lastvolumes AS(
  SELECT
	    vol.GenericFutureId,
		vol.FutureContractId,
        vol.Volume1Day AS Volume,
        vol.LastUpdateDate
    FROM
         volumes vol
		 JOIN LastVolumeDate lvd ON lvd.GenericFutureId = vol.GenericFutureId and lvd.LastVolumeDate =vol.LastUpdateDate)
MERGE INTO roll.FutureContract AS target
USING lastvolumes AS source
ON target.FutureContractId = source.FutureContractId
WHEN MATCHED THEN 
    UPDATE SET target.Volume = source.Volume;

WITH volumes AS(
SELECT fc.GenericFutureId
		,vd.InstrumentId AS FutureContractId
      ,[LastUpdateDate]
	  , vd.Volume1Day
  FROM [mktdata].[VolumeData] vd
  JOIN roll.FutureContract fc ON fc.FutureContractId = vd.InstrumentId
), LastVolumeDate AS(
SELECT GenericFutureId
      ,max([LastUpdateDate]) AS LastVolumeDate
  FROM volumes vol
  GROUP BY  GenericFutureId
  ), lastvolumes AS(
  SELECT
	    vol.GenericFutureId,
		vol.FutureContractId,
        vol.Volume1Day AS Volume,
        vol.LastUpdateDate
    FROM
         volumes vol
		 JOIN LastVolumeDate lvd ON lvd.GenericFutureId = vol.GenericFutureId and lvd.LastVolumeDate =vol.LastUpdateDate)
UPDATE roll.FutureContract
SET Volume = NULL
WHERE NOT EXISTS (
    SELECT 1
    FROM lastvolumes lv
    WHERE lv.FutureContractId = roll.FutureContract.FutureContractId
);

EXEC [roll].[spPropagateFutureContractRollInfo]
EXEC [roll].[spUpdateFutureCurrentContracts];
COMMIT TRANSACTION;

GO
/****** Object:  StoredProcedure [trans].[spUpdateBookedTrades]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [trans].[spUpdateBookedTrades]

AS
BEGIN
MERGE INTO [trans].[BookedTradeAllocation] AS target
USING (
    SELECT 
        [TradeAllocationId]
        ,[TradeId]
        ,[TradeStatus]
        ,[InstrumentId]
        ,[Symbol]
        ,[TradeSide]
        ,[TradeDate]
        ,[Exchange]
        ,[IsSwap]
        ,[InstrumentType]
        ,[TradeInstrumentType]
        ,[YellowKey]
        ,[ExecutionDesk]
        ,[ExecutionBroker]
        ,[ExecutionAccount]
        ,[Isin]
        ,[Sedol]
        ,[Cusip]
		,[PriceScalingFactor]
        ,[SecurityName]
        ,[LocalExchangeSymbol]
        ,[PortfolioId]
        ,[PositionSide]
        ,[Quantity]
        ,[ContractMultiplier]
        ,[NominalQuantity]
        ,[LocalCurrency]
        ,[BaseCurrency]
        ,[SettlementCurrency]
        ,[CommissionValue]
        ,[CommissionType]
        ,[GrossAvgPriceLocal]
        ,[PriceCommissionLocal]
        ,[NetAvgPriceLocal]
        ,[GrossAvgPriceBase]
        ,[PriceCommissionBase]
        ,[NetAvgPriceBase]
        ,[GrossAvgPriceSettle]
        ,[PriceCommissionSettle]
        ,[NetAvgPriceSettle]
        ,[CommissionAmountLocal]
        ,[CommissionAmountBase]
        ,[CommissionAmountSettle]
        ,[MiscFeesLocal]
        ,[MiscFeesBase]
        ,[MiscFeesSettle]
        ,[GrossTradeValueLocal]
        ,[NetTradeValueLocal]
        ,[GrossTradeValueBase]
        ,[NetTradeValueBase]
        ,[GrossTradeValueSettle]
        ,[NetTradeValueSettle]
        ,[GrossPrincipalLocal]
        ,[NetPrincipalLocal]
        ,[GrossPrincipalBase]
        ,[NetPrincipalBase]
        ,[GrossPrincipalSettle]
        ,[NetPrincipalSettle]
        ,[SettlementDate]
        ,[LocalToBaseFxRate]
        ,[LocalToSettleFxRate]
        ,[PrimeBroker]
        ,[ClearingBroker]
        ,[ClearingAccount]
        ,[Custodian]
        ,[EmsxOrderId]
        ,[OrderReferenceId]
        ,[OrderQuantity] as [BlockOrderQuantity]
        ,[OrderAllocationQuantity]
        ,[OrderAllocationNominalQuantity]
        ,[ExecutionType]
        ,'' as [Notes]
        ,[TraderName]
        ,[TraderUuid]
	
        ,[LastCorrectedOnUtc]
        ,[CanceledOnUtc]
        ,[BookedOnUtc]
    FROM [book].[vwTradeAllocation]
) AS source
ON target.TradeAllocationId = source.TradeAllocationId
WHEN MATCHED THEN 
    UPDATE SET
        target.TradeId = source.TradeId,
        target.TradeStatus = source.TradeStatus,
        target.InstrumentId = source.InstrumentId,
        target.Symbol = source.Symbol,
        target.TradeSide = source.TradeSide,
        target.TradeDate = source.TradeDate,
        target.Exchange = source.Exchange,
        target.IsSwap = source.IsSwap,
        target.InstrumentType = source.InstrumentType,
        target.TradeInstrumentType = source.TradeInstrumentType,
        target.YellowKey = source.YellowKey,
        target.ExecutionDesk = source.ExecutionDesk,
        target.ExecutionBroker = source.ExecutionBroker,
        target.ExecutionAccount = source.ExecutionAccount,
        target.Isin = source.Isin,
        target.Sedol = source.Sedol,
        target.Cusip = source.Cusip,
        target.SecurityName = source.SecurityName,
        target.LocalExchangeSymbol = source.LocalExchangeSymbol,
        target.PortfolioId = source.PortfolioId,
        target.PositionSide = source.PositionSide,
        target.Quantity = source.Quantity,
        target.ContractMultiplier = source.ContractMultiplier,
		target.[PriceScalingFactor] = source.[PriceScalingFactor],
        target.NominalQuantity = source.NominalQuantity,
        target.LocalCurrency = source.LocalCurrency,
        target.BaseCurrency = source.BaseCurrency,
        target.SettlementCurrency = source.SettlementCurrency,
        target.CommissionValue = source.CommissionValue,
        target.CommissionType = source.CommissionType,
        target.GrossAvgPriceLocal = source.GrossAvgPriceLocal,
        target.PriceCommissionLocal = source.PriceCommissionLocal,
        target.NetAvgPriceLocal = source.NetAvgPriceLocal,
        target.GrossAvgPriceBase = source.GrossAvgPriceBase,
        target.PriceCommissionBase = source.PriceCommissionBase,
        target.NetAvgPriceBase = source.NetAvgPriceBase,
        target.GrossAvgPriceSettle = source.GrossAvgPriceSettle,
        target.PriceCommissionSettle = source.PriceCommissionSettle,
        target.NetAvgPriceSettle = source.NetAvgPriceSettle,
        target.CommissionAmountLocal = source.CommissionAmountLocal,
        target.CommissionAmountBase = source.CommissionAmountBase,
        target.CommissionAmountSettle = source.CommissionAmountSettle,
        target.MiscFeesLocal = source.MiscFeesLocal,
        target.MiscFeesBase = source.MiscFeesBase,
        target.MiscFeesSettle = source.MiscFeesSettle,
        target.GrossTradeValueLocal = source.GrossTradeValueLocal,
        target.NetTradeValueLocal = source.NetTradeValueLocal,
        target.GrossTradeValueBase = source.GrossTradeValueBase,
        target.NetTradeValueBase = source.NetTradeValueBase,
        target.GrossTradeValueSettle = source.GrossTradeValueSettle,
        target.NetTradeValueSettle = source.NetTradeValueSettle,
        target.GrossPrincipalLocal = source.GrossPrincipalLocal,
        target.NetPrincipalLocal = source.NetPrincipalLocal,
        target.GrossPrincipalBase = source.GrossPrincipalBase,
        target.NetPrincipalBase = source.NetPrincipalBase,
        target.GrossPrincipalSettle = source.GrossPrincipalSettle,
        target.NetPrincipalSettle = source.NetPrincipalSettle,
        target.SettlementDate = source.SettlementDate,
        target.LocalToBaseFxRate = source.LocalToBaseFxRate,
        target.LocalToSettleFxRate = source.LocalToSettleFxRate,
        target.PrimeBroker = source.PrimeBroker,
        target.ClearingBroker = source.ClearingBroker,
        target.ClearingAccount = source.ClearingAccount,
        target.Custodian = source.Custodian,
        target.EmsxOrderId = source.EmsxOrderId,
        target.OrderReferenceId = source.OrderReferenceId,
        target.BlockOrderQuantity = source.BlockOrderQuantity,
        target.OrderAllocationQuantity = source.OrderAllocationQuantity,
        target.OrderAllocationNominalQuantity = source.OrderAllocationNominalQuantity,
        target.ExecutionType = source.ExecutionType,
        target.Notes = source.Notes,
        target.TraderName = source.TraderName,
        target.TraderUuid = source.TraderUuid,
        target.LastCorrectedOnUtc = source.LastCorrectedOnUtc,
        target.CanceledOnUtc = source.CanceledOnUtc,
        target.BookedOnUtc = source.BookedOnUtc
WHEN NOT MATCHED BY TARGET THEN 
    INSERT (
        TradeAllocationId, TradeId, TradeStatus, InstrumentId, Symbol, TradeSide, TradeDate, Exchange, IsSwap,
        InstrumentType, TradeInstrumentType, YellowKey, ExecutionDesk, ExecutionBroker, ExecutionAccount, Isin, Sedol, Cusip,
        SecurityName, LocalExchangeSymbol, PortfolioId, PositionSide, Quantity, ContractMultiplier,[PriceScalingFactor], NominalQuantity,
        LocalCurrency, BaseCurrency, SettlementCurrency, CommissionValue, CommissionType, GrossAvgPriceLocal, 
        PriceCommissionLocal, NetAvgPriceLocal, GrossAvgPriceBase, PriceCommissionBase, NetAvgPriceBase, GrossAvgPriceSettle, 
        PriceCommissionSettle, NetAvgPriceSettle, CommissionAmountLocal, CommissionAmountBase, CommissionAmountSettle, 
        MiscFeesLocal, MiscFeesBase, MiscFeesSettle, GrossTradeValueLocal, NetTradeValueLocal, GrossTradeValueBase, 
        NetTradeValueBase, GrossTradeValueSettle, NetTradeValueSettle, GrossPrincipalLocal, NetPrincipalLocal, GrossPrincipalBase,
        NetPrincipalBase, GrossPrincipalSettle, NetPrincipalSettle, SettlementDate, LocalToBaseFxRate, LocalToSettleFxRate, 
        PrimeBroker, ClearingBroker, ClearingAccount, Custodian, EmsxOrderId, OrderReferenceId, BlockOrderQuantity,
        OrderAllocationQuantity, OrderAllocationNominalQuantity, ExecutionType, Notes, TraderName, TraderUuid,
        LastCorrectedOnUtc, CanceledOnUtc, BookedOnUtc
    )
    VALUES (
        source.TradeAllocationId, source.TradeId, source.TradeStatus, source.InstrumentId, source.Symbol, source.TradeSide,
        source.TradeDate, source.Exchange, source.IsSwap, source.InstrumentType, source.TradeInstrumentType, source.YellowKey,
        source.ExecutionDesk, source.ExecutionBroker, source.ExecutionAccount, source.Isin, source.Sedol, source.Cusip,
        source.SecurityName, source.LocalExchangeSymbol, source.PortfolioId, source.PositionSide, source.Quantity,
        source.ContractMultiplier,source.[PriceScalingFactor], source.NominalQuantity, source.LocalCurrency, source.BaseCurrency, source.SettlementCurrency,
        source.CommissionValue, source.CommissionType, source.GrossAvgPriceLocal, source.PriceCommissionLocal,
        source.NetAvgPriceLocal, source.GrossAvgPriceBase, source.PriceCommissionBase, source.NetAvgPriceBase, source.GrossAvgPriceSettle,
        source.PriceCommissionSettle, source.NetAvgPriceSettle, source.CommissionAmountLocal, source.CommissionAmountBase,
        source.CommissionAmountSettle, source.MiscFeesLocal, source.MiscFeesBase, source.MiscFeesSettle, source.GrossTradeValueLocal,
        source.NetTradeValueLocal, source.GrossTradeValueBase, source.NetTradeValueBase, source.GrossTradeValueSettle, 
        source.NetTradeValueSettle, source.GrossPrincipalLocal, source.NetPrincipalLocal, source.GrossPrincipalBase, 
        source.NetPrincipalBase, source.GrossPrincipalSettle, source.NetPrincipalSettle, source.SettlementDate, 
        source.LocalToBaseFxRate, source.LocalToSettleFxRate, source.PrimeBroker, source.ClearingBroker, source.ClearingAccount, 
        source.Custodian, source.EmsxOrderId, source.OrderReferenceId, source.BlockOrderQuantity, source.OrderAllocationQuantity,
        source.OrderAllocationNominalQuantity, source.ExecutionType, source.Notes, source.TraderName, source.TraderUuid,
        source.LastCorrectedOnUtc, source.CanceledOnUtc, source.BookedOnUtc
    )

WHEN NOT MATCHED BY SOURCE THEN DELETE ;




END
GO
/****** Object:  StoredProcedure [trans].[spUpdateFxRates]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [trans].[spUpdateFxRates]
AS
BEGIN
    MERGE INTO [trans].FxRate AS target
    USING (
       SELECT [BaseCurrency]
      ,[QuoteCurrency]
      ,[LastValue]     
      ,[LastUpdateDate]
  FROM [mktdata].[vwLastFxRate]
    ) AS source ON (target.[BaseCurrency] = source.[BaseCurrency] AND target.[QuoteCurrency] = source.[QuoteCurrency] )

    WHEN MATCHED THEN
        UPDATE SET
            target.[Value] = source.[LastValue]

    WHEN NOT MATCHED BY TARGET THEN
        INSERT (
          [BaseCurrency]
      ,[QuoteCurrency]
      ,[Value]
      ,[Date]
        )
        VALUES (
            source.[BaseCurrency],
            source.[QuoteCurrency],
            source.[LastValue],
            source.[LastUpdateDate]
        );

END
GO
/****** Object:  StoredProcedure [trans].[spUpdateInstrumentPricings]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [trans].[spUpdateInstrumentPricings]
AS
BEGIN
    MERGE INTO [trans].InstrumentPricing AS target
    USING (
        SELECT
            [InstrumentId],
            [LastPriceEod],
            [LastUpdateDateEod],
            [Currency]
        FROM [mktdata].[vwLastPriceEod]
    ) AS source ON (target.[InstrumentId] = source.[InstrumentId] )

    WHEN MATCHED THEN
        UPDATE SET
            target.[Price] = source.[LastPriceEod],
            target.[Currency] = source.[Currency],
			target.[Date]=source.[LastUpdateDateEod]
    WHEN NOT MATCHED BY TARGET THEN
        INSERT (
            [InstrumentId],
            [Price],
            [Currency],
            [Date]
        )
        VALUES (
            source.[InstrumentId],
            source.[LastPriceEod],
            source.[Currency],
            source.[LastUpdateDateEod]
        )
		WHEN NOT MATCHED BY SOURCE THEN
		DELETE;
   
END
GO
/****** Object:  StoredProcedure [trans].[spUpdateInstruments]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [trans].[spUpdateInstruments]
AS
BEGIN


    MERGE INTO [trans].Instrument AS target
    USING (
        SELECT 
       [InstrumentId]
      ,[Symbol]
      ,ins.[Name]
	  ,[ISIN]
      ,[BbgUniqueId]
      ,[InstrumentType]
      ,[MarketSectorDes]
      ,[Exchange]
      ,[PrimaryMIC]
      ,[Currency]
      ,[QuoteCurrency]
	  ,gen.GenericFutureId
      ,CASE WHEN fut.LastTradeDate is not null THEN fut.LastTradeDate 
	        WHEN fwd.MaturityDate is not null THEN fwd.MaturityDate 
			ELSE NULL END as MaturityDate
      ,[PriceScalingFactor]
	  ,gen.PointValue as FuturePointValue
	  ,fut.ContractYear as FutureContractYear
	  ,fut.FutureContractMonthId as FutureContractMonth
  FROM [instr].[vwInstrument] ins
  LEFT JOIN instr.FutureContract fut on fut.FutureContractId = ins.[InstrumentId]
  LEFT JOIN instr.GenericFuture gen on gen.GenericFutureId =fut.GenericFutureId
  LEFT JOIN instr.FxForward fwd on fwd.FxForwardId = ins.[InstrumentId]
		
    ) AS source ON (target.[InstrumentId] = source.[InstrumentId])

   WHEN MATCHED THEN
        UPDATE SET
            target.[InstrumentType] = source.[InstrumentType],
            target.[Symbol] = source.[Symbol],
            target.[Name] = source.[Name],
            target.[Currency] = source.[Currency],
            target.[BbgUniqueId] = source.[BbgUniqueId],
			target.[ISIN] = source.[ISIN],
		    target.[MarketSector] = source.[MarketSectorDes],
		 	target.[Exchange] = source.[Exchange],
			target.[PrimaryMIC] = source.[PrimaryMIC],
			target.[QuoteCurrency] = source.[QuoteCurrency],
			target.[PriceScalingFactor] = source.[PriceScalingFactor],
			target.MaturityDate = source.MaturityDate,
		    target.FuturePointValue = source.FuturePointValue,
			target.GenericFutureId = source.GenericFutureId,
			target.FutureContractMonth = source.FutureContractMonth,
			target.FutureContractYear = source.FutureContractYear
    WHEN NOT MATCHED BY TARGET THEN
        INSERT (
               [InstrumentId]
			  ,[Symbol]
			  ,[Name]
			  ,[ISIN]
			  ,[BbgUniqueId]
			  ,[InstrumentType]
			  ,[MarketSector]
			  ,[Exchange]
			  ,[PrimaryMIC]
			  ,[Currency]
			  ,[QuoteCurrency]
			  ,[PriceScalingFactor]
			  ,[MaturityDate]
			  ,FuturePointValue
			  ,GenericFutureId
			  ,FutureContractMonth
			  ,FutureContractYear
        )
        VALUES (
                 source.[InstrumentId]
				  ,source.[Symbol]
				  ,source.[Name]
				  ,source.[ISIN]
				  ,source.[BbgUniqueId]
				  ,source.[InstrumentType]
				  ,source.[MarketSectorDes]
				  ,source.[Exchange]
				  ,source.[PrimaryMIC]
				  ,source.[Currency]
				  ,source.[QuoteCurrency]
				   ,source.[PriceScalingFactor]
			  ,source.[MaturityDate]
			  ,source.[FuturePointValue]
			  ,source.GenericFutureId
			    ,source.FutureContractMonth
			  ,source.FutureContractYear
        )
		    WHEN NOT MATCHED BY SOURCE THEN
        DELETE;


END
GO
/****** Object:  StoredProcedure [trans].[spUpdateMarketData]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [trans].[spUpdateMarketData]
AS
BEGIN
EXEC [trans].[spUpdateFxRates]
EXEC [trans].[spUpdateInstrumentPricings]

END
GO
/****** Object:  StoredProcedure [trans].[spUpdateTrades]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [trans].[spUpdateTrades]
AS
BEGIN TRY
BEGIN TRANSACTION; 
MERGE INTO trans.Trade AS Target
USING (SELECT [TradeId]
      ,[OrderId]
      ,[RebalancingId]
      ,[EmsxSequence]
      ,[EmsxOrderCreatedOn]
      ,[InstrumentId]
      ,[ExchangeCode]
      ,[Sedol]
      ,[BuySellIndicator]
      ,[OrderQuantity]
      ,[FilledQuantity]
      ,[AvgPrice]
      ,[DayAveragePrice]
      ,[TradeCurrency]
      ,[TradeDate]
      ,[Principal]
      ,[NetAmount]
      ,[SettlementDate]
      ,[SettlementCurrency]
      ,[BrokerCommission]
      ,[CommissionRate]
      ,[MiscFees]
      ,[Notes]
      ,[Trader]
      ,[BrokerCode]
      ,[TradeDesk]
      ,[IsCfd]
	  ,IsFutureSwap
      ,[ExecutionChannel]
      ,[CreatedOn]
      ,[TotalCharges]
      ,[FxemTradeId]
      ,[FxemOrderId]
      ,[TradeStatus]
      ,[FxCurrency1]
      ,[FXCurrency1Amount]
      ,[FxCurrency2]
      ,[FXCurrency2Amount]
      ,[BookedOn]
	  ,[LocalToSettleFxRate]
  FROM [trd].[Trade]) AS Source
ON Target.TradeId = Source.TradeId
WHEN MATCHED THEN
UPDATE SET
    Target.OrderId = Source.OrderId,
    Target.RebalancingId = Source.RebalancingId,
    Target.EmsxSequence = Source.EmsxSequence,
    Target.EmsxOrderCreatedOn = Source.EmsxOrderCreatedOn,
    Target.InstrumentId = Source.InstrumentId,
    Target.ExchangeCode = Source.ExchangeCode,
    Target.Sedol = Source.Sedol,
    Target.BuySellIndicator = Source.BuySellIndicator,
    Target.OrderQuantity = Source.OrderQuantity,
    Target.FilledQuantity = Source.FilledQuantity,
    Target.AvgPrice = Source.AvgPrice,
    Target.DayAveragePrice = Source.DayAveragePrice,
    Target.TradeCurrency = Source.TradeCurrency,
    Target.TradeDate = Source.TradeDate,
    Target.Principal = Source.Principal,
    Target.NetAmount = Source.NetAmount,
    Target.SettlementDate = Source.SettlementDate,
    Target.SettlementCurrency = Source.SettlementCurrency,
    Target.BrokerCommission = Source.BrokerCommission,
    Target.CommissionRate = Source.CommissionRate,
    Target.MiscFees = Source.MiscFees,
    Target.Notes = Source.Notes,
    Target.Trader = Source.Trader,
    Target.BrokerCode = Source.BrokerCode,
    Target.TradeDesk = Source.TradeDesk,
    Target.IsCfd = Source.IsCfd,
    Target.ExecutionChannel = Source.ExecutionChannel,
    Target.CreatedOn = Source.CreatedOn,
    Target.TotalCharges = Source.TotalCharges,
    Target.FxemTradeId = Source.FxemTradeId,
    Target.FxemOrderId = Source.FxemOrderId,
    Target.TradeStatus = Source.TradeStatus,
    Target.FxCurrency1 = Source.FxCurrency1,
    Target.FXCurrency1Amount = Source.FXCurrency1Amount,
    Target.FxCurrency2 = Source.FxCurrency2,
    Target.FXCurrency2Amount = Source.FXCurrency2Amount,
    Target.BookedOn = Source.BookedOn,
	Target.IsFutureSwap = Source.IsFutureSwap,
	Target.[LocalToSettleFxRate] = Source.[LocalToSettleFxRate]
	WHEN NOT MATCHED THEN
INSERT (
    [TradeId],
    [OrderId],
    [RebalancingId],
    [EmsxSequence],
    [EmsxOrderCreatedOn],
    [InstrumentId],
    [ExchangeCode],
    [Sedol],
    [BuySellIndicator],
    [OrderQuantity],
    [FilledQuantity],
    [AvgPrice],
    [DayAveragePrice],
    [TradeCurrency],
    [TradeDate],
    [Principal],
    [NetAmount],
    [SettlementDate],
    [SettlementCurrency],
    [BrokerCommission],
    [CommissionRate],
    [MiscFees],
    [Notes],
    [Trader],
    [BrokerCode],
    [TradeDesk],
    [IsCfd],
	[IsFutureSwap],
    [ExecutionChannel],
    [CreatedOn],
    [TotalCharges],
    [FxemTradeId],
    [FxemOrderId],
    [TradeStatus],
    [FxCurrency1],
    [FXCurrency1Amount],
    [FxCurrency2],
    [FXCurrency2Amount],
   [LocalToSettleFxRate],
   [BookedOn]
	
)
VALUES (
    Source.[TradeId],
    Source.[OrderId],
    Source.[RebalancingId],
    Source.[EmsxSequence],
    Source.[EmsxOrderCreatedOn],
    Source.[InstrumentId],
    Source.[ExchangeCode],
    Source.[Sedol],
    Source.[BuySellIndicator],
    Source.[OrderQuantity],
    Source.[FilledQuantity],
    Source.[AvgPrice],
    Source.[DayAveragePrice],
    Source.[TradeCurrency],
    Source.[TradeDate],
    Source.[Principal],
    Source.[NetAmount],
    Source.[SettlementDate],
    Source.[SettlementCurrency],
    Source.[BrokerCommission],
    Source.[CommissionRate],
    Source.[MiscFees],
    Source.[Notes],
    Source.[Trader],
    Source.[BrokerCode],
    Source.[TradeDesk],
    Source.[IsCfd],
	Source.[IsFutureSwap],
    Source.[ExecutionChannel],
    Source.[CreatedOn],
    Source.[TotalCharges],
    Source.[FxemTradeId],
    Source.[FxemOrderId],
    Source.[TradeStatus],
    Source.[FxCurrency1],
    Source.[FXCurrency1Amount],
    Source.[FxCurrency2],
    Source.[FXCurrency2Amount],
    Source.[LocalToSettleFxRate],
	Source.[BookedOn]
	
);


MERGE INTO [trans].[TradeAllocation] AS target
USING [trd].[TradeAllocation] AS source
ON target.[TradeAllocationId] = source.[TradeAllocationId]

-- Update target records when matched with source
WHEN MATCHED THEN 
UPDATE SET
    target.[TradeId] = source.[TradeId],
    target.[PortfolioId] = source.[PortfolioId],
    target.[Quantity] = source.[Quantity],
    target.[Price] = source.[Price],
    target.[GrossAmount] = source.[GrossAmount],
    target.[NetAmount] = source.[NetAmount],
    target.[Commission] = source.[Commission],
    target.[Fees] = source.[Fees],
    target.[PositionSide] = source.[PositionSide],
    target.[TradingAccount] = source.[TradingAccount]

-- Insert records from source into target when not matched
WHEN NOT MATCHED BY TARGET THEN
INSERT
    ([TradeAllocationId], [TradeId], [PortfolioId], [Quantity], [Price], [GrossAmount], [NetAmount], [Commission], [Fees], [PositionSide], [TradingAccount])
VALUES 
    (source.[TradeAllocationId], source.[TradeId], source.[PortfolioId], source.[Quantity], source.[Price], source.[GrossAmount], source.[NetAmount], source.[Commission], source.[Fees], source.[PositionSide], source.[TradingAccount])

-- Optional: Delete records in the target table if they don't exist in the source table
 WHEN NOT MATCHED BY SOURCE THEN 
 DELETE;

  COMMIT TRANSACTION; -- Commit the transaction if no errors
END TRY

BEGIN CATCH
    ROLLBACK TRANSACTION; -- Rollback the transaction in case of errors

    THROW; -- Re-throw the error to ensure you see what happened
END CATCH;
GO
/****** Object:  StoredProcedure [trd].[spBookTrades]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [trd].[spBookTrades]
AS
BEGIN TRY
BEGIN TRANSACTION; 


--exec trd.spMergeEmsxTradeToBook
--exec trd.spMergeFxemTradeToBook
--exec trd.spMergeEfrpTradeToBook

exec trd.spValidateTradesToBook
-- Temporary table to store the mapping between StgTradeId and the newly generated TradeId
CREATE TABLE #TempTradeIdMap
(
    [StgTradeToBookId] INT,
    NewTradeId INT
);

    -- Merge trades and capture the newly generated TradeId or the matched one
    MERGE INTO [trd].[Trade] AS Target
    USING [trd].[StgTradeToBook] AS Source
    ON
         (Target.EmsxSequence = Source.EmsxSequence or Target.FxemTradeId = Source.FxemTradeId)


    WHEN MATCHED THEN 
    UPDATE SET
        Target.OrderId = Source.OrderId,
        Target.EmsxSequence = Source.EmsxSequence,
        Target.EmsxOrderCreatedOn = Source.EmsxOrderCreatedOn,
        Target.ExchangeCode = Source.ExchangeCode,
        Target.Sedol = Source.Sedol,
        Target.BuySellIndicator = Source.BuySellIndicator,
        Target.OrderQuantity = Source.OrderQuantity,
        Target.FilledQuantity = Source.FilledQuantity,
        Target.AvgPrice = Source.AvgPrice,
        Target.DayAveragePrice = Source.DayAveragePrice,
        Target.TradeCurrency = Source.TradeCurrency,
        Target.TradeDate = Source.TradeDate,
        Target.Principal = Source.Principal,
        Target.NetAmount = Source.NetAmount,
        Target.SettlementDate = Source.SettlementDate,
        Target.SettlementCurrency = Source.SettlementCurrency,
        Target.BrokerCommission = Source.BrokerCommission,
        Target.CommissionRate = Source.CommissionRate,
        Target.MiscFees = Source.MiscFees,
        Target.Notes = Source.Notes,
        Target.Trader = Source.Trader,
        Target.BrokerCode = Source.BrokerCode,
        Target.TradeDesk = Source.TradeDesk,
        Target.IsCfd = Source.IsCfd,
		Target.IsFutureSwap = Source.IsFutureSwap,
        Target.ExecutionChannel = Source.ExecutionChannel,
        Target.CreatedOn = Source.CreatedOn,
        Target.TotalCharges = Source.TotalCharges,
        Target.FxemTradeId = Source.FxemTradeId,
        Target.FxemOrderId = Source.FxemOrderId,
        Target.TradeStatus = Source.TradeStatus,
        Target.FxCurrency1 = Source.FxCurrency1,
        Target.FXCurrency1Amount = Source.FXCurrency1Amount,
        Target.FxCurrency2 = Source.FxCurrency2,
        Target.FXCurrency2Amount = Source.FXCurrency2Amount
WHEN NOT MATCHED THEN
INSERT (
    OrderId, RebalancingId, EmsxSequence, EmsxOrderCreatedOn, InstrumentId, ExchangeCode, 
    Sedol, BuySellIndicator, OrderQuantity, FilledQuantity, AvgPrice, DayAveragePrice, 
    TradeCurrency, TradeDate, Principal, NetAmount, SettlementDate, SettlementCurrency, 
    BrokerCommission, CommissionRate, MiscFees, Notes, Trader, BrokerCode, TradeDesk, 
    IsCfd,IsFutureSwap, ExecutionChannel, CreatedOn, TotalCharges, FxemTradeId, FxemOrderId, TradeStatus, 
    FxCurrency1, FXCurrency1Amount, FxCurrency2, FXCurrency2Amount
)
VALUES (
    Source.OrderId, Source.RebalancingId, Source.EmsxSequence, Source.EmsxOrderCreatedOn, Source.InstrumentId, Source.ExchangeCode, 
    Source.Sedol, Source.BuySellIndicator, Source.OrderQuantity, Source.FilledQuantity, Source.AvgPrice, Source.DayAveragePrice, 
    Source.TradeCurrency, Source.TradeDate, Source.Principal, Source.NetAmount, Source.SettlementDate, Source.SettlementCurrency, 
    Source.BrokerCommission, Source.CommissionRate, Source.MiscFees, Source.Notes, Source.Trader, Source.BrokerCode, Source.TradeDesk, 
    Source.IsCfd,Source.IsFutureSwap, Source.ExecutionChannel, Source.CreatedOn, Source.TotalCharges, Source.FxemTradeId, Source.FxemOrderId, Source.TradeStatus, 
    Source.FxCurrency1, Source.FXCurrency1Amount, Source.FxCurrency2, Source.FXCurrency2Amount
) OUTPUT Source.StgTradeToBookId, INSERTED.TradeId INTO #TempTradeIdMap;
-- Merge trade allocations using the mapping
MERGE INTO [trd].[TradeAllocation] AS Target
USING 
(
    SELECT
        T.NewTradeId, 
        S.PortfolioId, 
        S.Quantity, 
        S.Price,
        S.GrossAmount, 
        S.NetAmount, 
        S.Commission, 
        S.Fees, 
        S.PositionSide, 
        S.TradingAccount
    FROM [trd].[StgTradeAllocToBook] S
    JOIN #TempTradeIdMap T ON S.[StgTradeToBookId] = T.[StgTradeToBookId]
) AS Source
ON Target.TradeId = Source.NewTradeId AND Target.PortfolioId = Source.PortfolioId 
WHEN NOT MATCHED THEN
INSERT (
    TradeId, 
    PortfolioId, 
    Quantity, 
    Price, 
    GrossAmount, 
    NetAmount, 
    Commission, 
    Fees, 
    PositionSide, 
    TradingAccount
)
VALUES (
    Source.NewTradeId, 
    Source.PortfolioId, 
    Source.Quantity, 
    Source.Price,
    Source.GrossAmount, 
    Source.NetAmount, 
    Source.Commission, 
    Source.Fees, 
    Source.PositionSide, 
    Source.TradingAccount
);


SELECT[TradeId]
      ,[OrderId]
      ,[RebalancingId]
      ,[EmsxSequence]
      ,[EmsxOrderCreatedOn]
      ,[InstrumentId]
      ,[ExchangeCode]
      ,[Sedol]
      ,[BuySellIndicator]
      ,[OrderQuantity]
      ,[FilledQuantity]
      ,[AvgPrice]
      ,[DayAveragePrice]
      ,[TradeCurrency]
      ,[TradeDate]
      ,[Principal]
      ,[NetAmount]
      ,[SettlementDate]
      ,[SettlementCurrency]
      ,[BrokerCommission]
      ,[CommissionRate]
      ,[MiscFees]
      ,[Notes]
      ,[Trader]
      ,[BrokerCode]
      ,[TradeDesk]
      ,[IsCfd]
      ,[ExecutionChannel]
      ,[CreatedOn]
      ,[TotalCharges]
      ,[FxemTradeId]
      ,[FxemOrderId]
      ,[TradeStatus]
      ,[FxCurrency1]
      ,[FXCurrency1Amount]
      ,[FxCurrency2]
      ,[FXCurrency2Amount]
      ,[BookedOn]
      ,[ValidFrom]
      ,[ValidTo]
      ,[IsFutureSwap]
  FROM [trd].[Trade] trd
  JOIN #TempTradeIdMap temp on temp.NewTradeId = trd.TradeId
  EXEC [trd].[spPropagateUpdateTrades]

  delete from trd.EmsxOrder;
  delete from trd.FxemTrade;
  delete from [trd].[MSEfrpTradeAffirm]
  delete from trd.StgTradeToBook;
  COMMIT TRANSACTION; -- Commit the transaction if no errors
END TRY

BEGIN CATCH
    ROLLBACK TRANSACTION; -- Rollback the transaction in case of errors

    THROW; -- Re-throw the error to ensure you see what happened
END CATCH;
GO
/****** Object:  StoredProcedure [trd].[spImportFxemTrades]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [trd].[spImportFxemTrades]
AS
BEGIN
truncate table [trd].[FxemTrade];
INSERT INTO [trd].[FxemTrade]
(
    [FxemTradeId],
    [FxemOrderId],
    [DateTime],
    [TradeDate],
    [Status],
    [Product],
    [DealType],
    [CurrencyPair],
    [Side],
    [Amount],
    ValueDate,
    [DealCode],
    [Account],
    [AmountCcy1],
    [Ccy1],
    [AmountCcy2],
    [Ccy2],
    [Trader],
    [Commission],
    [AllInRate],
    [SpotRate],
    [FwdPoints],
    [Counterparty]
)
SELECT 
    [Trade_ID],
    [FXEM_Order_ID],
    [Date_Time],
    [Trade_Date],
    [Status],
    [Product],
    [Deal_Type],
    [Ccys],
    [Side],
    [Amount],
    cast([Value_Date] as date) as [Value_Date],
    [Deal_Code],
    [Account],
    [Amount_Ccy1],
    [Ccy],
    [Amount_Ccy2],
    [Contra_Ccy],
    [Trader],
    [Commission],
    [All_In_Rate],
    [Spot_Rate],
    [Fwd_Points],
    [Counterparty]
FROM [dbo].[EXPORT_FXFWD_TRADE_CONFIRM];
ENd
GO
/****** Object:  StoredProcedure [trd].[spIntegrateMissedExpiredTrades]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [trd].[spIntegrateMissedExpiredTrades]
AS
BEGIN
with nonbooked as (SELECT 
 cast(LEFT(RIGHT(e.[Order_ID],17),8) as int) as emsxsequence,
 t.TradeId
  FROM [dbo].[emsx_export] e
 LEFT JOIN trd.vwTrade t on t.EmsxSequence =     cast(LEFT(RIGHT(e.[Order_ID],17),8) as int)
 where t.TradeId is null and cast(e.Filled as int )>0), missedtrades as(
 select * from [dbo].[emsx_export] where  cast(LEFT(RIGHT([Order_ID],17),8) as int)  in (SELECT 
 emsxsequence
 
  FROM nonbooked))


  INSERT INTO [trd].[EmsxOrder] 
(
    [EmsxSequence],
    [OrderNumber],
    [OrderRefId],
    [Status],
    [Ticker],
    [ISIN],
    [Sedol],
    [Exchange],
    [Side],
    [Amount],
    [Filled],
    [AvgPrice],
    [DayAvgPrice],
    [LimitPrice],
    [Principal],
    [BrokerCommm],
    [CommmRate],
    [MiscFees],
    [OrderType],
    [TimeInForce],
    [Strategy],
    [HandInstruction],
    [Broker],
    [Account],
    [CfdFlag],
    [SettleCurrency],
    [SettleAmount],
    [ClearingAccount],
    [ClearingFirm],
    [BasketName],
    [CustomNote1],
    [CustomNote2],
    [CustomNote3],
    [CustomNote4],
    [CustomNote5],
    [Notes],
    [TraderUuid],
    [Trader],
    [EmsxDate],
    [PercentRemain],
    [YellowKey],
    [SettleDate],
    [TimeStamp],
    [LastFillDate]
)
SELECT 
    cast(LEFT(RIGHT([Order_ID],17),8) as int)as EmsxSequence,
    0 as OrderNumber,
	[Order_Ref_ID] AS OrderRefId,
	[Status],
	[Tkr_YKey] as Ticker,
	ISIN,
	Sedol,
	[Exch_Code]as  Exchange,
	[Side],
	cast([Qty]as int)AS Amount,
	cast([FillQty]as int) as Filled,
	cast([AvgPx]as decimal(18,6)) as AvgPrice ,
	cast([DayAvgPx]as decimal(18,6)) as [DayAvgPx],
	cast(0 as decimal(18,6))  as [LimitPrice],
	cast([Principal]as decimal(24,6)) as [Principal],
	cast(0 as decimal(12,6))as BrokerComm,
	cast([Comm_Rate] as decimal(12,6))as [Comm_Rate],
	cast(0 as decimal(12,6)) as MiscFees,
	[Order_Type] as [OrderType],
	[TIF] as [TimeInForce],
	Strategy_Name as Strategy,
	[Handling_Inst] as HandlInstruction,
	[Brkr_Code] as [Broker],
	[Account],
	IIF(Booking_Type = 'CFD', 'Y', 'N') as [CfdFlag],
	null as SettleCurrency,
	cast(0 as decimal(24,6))as SettleAmount,
	null as ClearingAccount,
	null as ClearingFirm,
	[Bskt_Name]as BasketName,
	[Custom_Note_1] as CustomNote1,
	[Custom_Note_2]as CustomNote2,
	[Custom_Note_3]as CustomNote3,
	null as CustomNote4,
	null as CustomNote5,
	null as Notes,
	31853626  as TraderUuid,
	[Trader],
	[Trade_Date] as EmsxDate,
	0 as PercentRemain,
	Mkt_Sector_Des as YellowKey,
	null as SettleDate,
	[Create_Time_As_of] AS [TimeStamp],
	null as LastFillDate
FROM missedtrades;
END
GO
/****** Object:  StoredProcedure [trd].[spMergeEfrpTradeToBook]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [trd].[spMergeEfrpTradeToBook]--To see if this information can be passed to the order or retrived from the account, no time now
AS
BEGIN TRY
BEGIN TRANSACTION; 
SELECT [TradeId]
      ,[EmsxSequence]
      ,[OrderId]
      ,[RebalancingId]
      ,[EmsxDate]
      ,[InstrumentId]
      ,[Symbol]
      ,[Side] as BuySellIndicator
      ,[PositionSide]
      ,[OrderQuantity]
      ,[FilledQuantity]
      ,[ExchangeCode]
      ,[Sedol]
      ,'MS1EFRP' as [Account]
      ,[TotalCharges]
      ,[TradeDate]
      ,[Principal]
      ,[NetAmount]
      ,[PortfolioId]
      ,[AvgPrice]
      ,[DayAvgPrice]
      ,[TradeCurrency]
      ,[OrderType]
      ,[TimeInForce]
      ,[Strategy]
      ,[HandlingInstruction]
      ,[SettlementDate]
      ,[SettlementCurrency]
      ,[BrokerCommission]
      ,[CommissionRate]
      ,[MiscFees]
      ,[Notes]
      ,[Trader]
      ,[BrokerCode]
      ,[IsCfd]
      ,[ExecutionChannel]
      ,[CreatedOn]
	  ,[TradeDesk]
	  ,0 as IsFutureSwap
	  ,1 as [LocalToSettleFxRate]
 into #tmpEfrpTradeToBook
 FROM [trd].[vwEfrpTradeToBook]
  	
-- MERGE for Trade table
MERGE INTO [trd].[StgTradeToBook] AS target
USING #tmpEfrpTradeToBook
AS source
ON target.[InstrumentId] = source.[InstrumentId] and target.[TradeDate] = source.[TradeDate] and target.[FilledQuantity] = source.[FilledQuantity] 

-- Handle updates
WHEN MATCHED THEN 
UPDATE SET 

Target.[OrderId] = Source.[OrderId],
Target.[RebalancingId] = Source.[RebalancingId],
Target.[InstrumentId] = Source.[InstrumentId],
Target.BuySellIndicator = Source.BuySellIndicator,
Target.[OrderQuantity] = Source.[OrderQuantity],
Target.[FilledQuantity] = Source.[FilledQuantity],
Target.[ExchangeCode] = Source.[ExchangeCode],
Target.[Sedol] = Source.[Sedol],
Target.[TotalCharges] = Source.[TotalCharges],
Target.[TradeDate] = Source.[TradeDate],
Target.[Principal] = Source.[Principal],
Target.[NetAmount] = Source.[NetAmount],
Target.[AvgPrice] = Source.[AvgPrice],

Target.[TradeCurrency] = Source.[TradeCurrency],
Target.[IsFutureSwap] = Source.[IsFutureSwap],

Target.[TradeDesk] = Source.[TradeDesk],
Target.[SettlementCurrency] = Source.[SettlementCurrency],
Target.[BrokerCommission] = Source.[BrokerCommission],
Target.[CommissionRate] = Source.[CommissionRate],
Target.[MiscFees] = Source.[MiscFees],
Target.[Notes] = Source.[Notes],
Target.[Trader] = Source.[Trader],
Target.[BrokerCode] = Source.[BrokerCode],
Target.[IsCfd] = Source.[IsCfd],
Target.[ExecutionChannel] = Source.[ExecutionChannel],
Target.[CreatedOn] = Source.[CreatedOn],
Target.[LocalToSettleFxRate] = Source.[LocalToSettleFxRate]


-- Handle inserts
WHEN NOT MATCHED BY TARGET THEN
   INSERT (

       [EmsxSequence]
      ,[OrderId]
      ,[RebalancingId]
      ,[InstrumentId]
      ,BuySellIndicator
      ,[OrderQuantity]
      ,[FilledQuantity]
      ,[ExchangeCode]
      ,[Sedol]
      ,[TotalCharges]
      ,[TradeDate]
      ,[Principal]
      ,[NetAmount]
      ,[AvgPrice]
      ,[TradeCurrency]
	
      ,[SettlementDate]
      ,[SettlementCurrency]
      ,[BrokerCommission]
      ,[CommissionRate]
      ,[MiscFees]
      ,[Notes]
      ,[Trader]
      ,[BrokerCode]
      ,[IsCfd]
      ,[ExecutionChannel]
      ,[CreatedOn]
	  ,[TradeDesk]
	  ,[IsFutureSwap]
	  ,[LocalToSettleFxRate]
    )
    VALUES (

Source.[EmsxSequence],
Source.[OrderId],
Source.[RebalancingId],
Source.[InstrumentId],
Source.BuySellIndicator,
Source.[OrderQuantity],
Source.[FilledQuantity],
Source.[ExchangeCode],
Source.[Sedol],
Source.[TotalCharges],
Source.[TradeDate],
Source.[Principal],
Source.[NetAmount],
Source.[AvgPrice],
Source.[TradeCurrency],
Source.[SettlementDate],
Source.[SettlementCurrency],
Source.[BrokerCommission],
Source.[CommissionRate],
Source.[MiscFees],
Source.[Notes],
Source.[Trader],
Source.[BrokerCode],
Source.[IsCfd],
Source.[ExecutionChannel],
Source.[CreatedOn],
Source.[TradeDesk],
Source.[IsFutureSwap],
Source.[LocalToSettleFxRate]
    );


-- MERGE for TradeAllocation table
MERGE INTO [trd].[StgTradeAllocToBook] AS targetAlloc
USING 
(
    SELECT distinct trd.[StgTradeToBookId],
           fxem.PortfolioId AS PortfolioId,
           fxem.FilledQuantity AS Quantity,
           fxem.[AvgPrice],
            fxem.PositionSide as PositionSide,
		   trd.BrokerCommission as Commission,
		   trd.MiscFees as Fees,
		   trd.Principal as GrossAmount,
		   trd.NetAmount as NetAmount,
           fxem.Account AS TradingAccount
    FROM #tmpEfrpTradeToBook fxem
    LEFT JOIN trd.[StgTradeToBook] trd ON trd.InstrumentId = fxem.InstrumentId and trd.TradeDate = trd.TradeDate and fxem.Account = 'MS1EFRP' and fxem.Filledquantity=trd.FilledQuantity --TODO:this mean one alloc per trade

) AS sourceAlloc
ON targetAlloc.[StgTradeToBookId] = sourceAlloc.[StgTradeToBookId]

WHEN MATCHED THEN 
UPDATE SET 
    targetAlloc.[StgTradeToBookId] = sourceAlloc.[StgTradeToBookId],
    targetAlloc.PortfolioId = sourceAlloc.PortfolioId,
    targetAlloc.[Price] = sourceAlloc.[AvgPrice],
    targetAlloc.Quantity = sourceAlloc.Quantity,
    targetAlloc.[TradingAccount] = sourceAlloc.TradingAccount,
    targetAlloc.PositionSide = sourceAlloc.PositionSide,
	targetAlloc.Commission = sourceAlloc.Commission,
	targetAlloc.Fees = sourceAlloc.Fees,
	targetAlloc.GrossAmount = sourceAlloc.GrossAmount,
	targetAlloc.NetAmount = sourceAlloc.NetAmount

WHEN NOT MATCHED BY TARGET THEN
INSERT 
(
    StgTradeToBookId,
    PortfolioId,
    [Quantity],
    [Price],
    [TradingAccount],
    PositionSide,
	Commission,
	Fees,
	NetAmount,
	GrossAmount
)
VALUES 
(
    sourceAlloc.StgTradeToBookId,
    sourceAlloc.PortfolioId,
    sourceAlloc.[Quantity],
    sourceAlloc.[AvgPrice],
    sourceAlloc.[TradingAccount],
    sourceAlloc.PositionSide,
	sourceAlloc.Commission,
	sourceAlloc.Fees,
	sourceAlloc.NetAmount,
	sourceAlloc.GrossAmount
);
 DROP TABLE #tmpEfrpTradeToBook;
COMMIT TRANSACTION; -- Commit the transaction if no errors
END TRY

BEGIN CATCH
    ROLLBACK TRANSACTION; -- Rollback the transaction in case of errors

    THROW; -- Re-throw the error to ensure you see what happened
END CATCH;
GO
/****** Object:  StoredProcedure [trd].[spMergeEmsxTradeToBook]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [trd].[spMergeEmsxTradeToBook]
AS
BEGIN TRY
BEGIN TRANSACTION; 

  SELECT [TradeId],
           [OrderId],
           [RebalancingId],
           [EmsxSequence],
           [EmsxOrderRefId],
           [EmsxDate],
           [InstrumentId],
           [ExchangeCode],
           [Sedol],
           [Account],
           [PortfolioId],
		   [PositionSide],
           [Side],
           [OrderQuantity],
           [FilledQuantity],
           [AvgPrice],
           [DayAvgPrice],
           [TradeCurrency],
           [OrderType],
           [TimeInForce],
           [Strategy],
           [HandInstruction],
           [TotalCharges],
           [TradeDate],
           [Principal],
           [NetAmount],
           [SettleDate],
           [SettleCurrency],
           [BrokerCommm],
           [CommmRate],
           [MiscFees],
           [Notes],
           [Trader],
           [Broker],
           [IsCfd],
		   [IsFutureSwap],
           [ExecutionChannel],
           [CreatedOn],
		   [LocalToSettleFxRate]
		   INTO #tmpEmsxTradeToBook
    FROM [trd].[vwEmsxTradeToBook]

-- MERGE for Trade table
MERGE INTO [trd].[StgTradeToBook] AS target
USING #tmpEmsxTradeToBook AS source
ON target.[EmsxSequence] = source.[EmsxSequence]

-- Handle updates
WHEN MATCHED THEN 
UPDATE SET 
    target.InstrumentId = source.InstrumentId,
    target.[EmsxSequence] = source.[EmsxSequence],
    target.OrderId = source.OrderId,
    target.SettlementDate = source.SettleDate,
    target.TradeDate = source.TradeDate,
    target.[TradeCurrency] = source.[TradeCurrency],
    target.[Sedol] = source.[Sedol],
    target.[ExchangeCode] = source.[ExchangeCode],
    target.[BuySellIndicator] = source.[Side],
    target.[OrderQuantity] = source.[OrderQuantity],
    target.[FilledQuantity] = source.[FilledQuantity],
    target.[AvgPrice] = source.[AvgPrice],
    target.[DayAveragePrice] = source.[DayAvgPrice],
    target.[Principal] = source.[Principal],
    target.[NetAmount] = source.[NetAmount],
    target.[BrokerCommission] = source.[BrokerCommm],
    target.[CommissionRate] = source.[CommmRate],
    target.[MiscFees] = source.[MiscFees],
    target.[Trader] = source.[Trader],
    target.[BrokerCode] = source.[Broker],
    target.[IsCfd] = source.IsCfd,
	target.IsFutureSwap = source.IsFutureSwap,
    target.[SettlementCurrency] = source.[SettleCurrency],
    target.[Notes] = source.[Notes],
    target.[TradeDesk] = source.[Broker],
	target.ExecutionChannel = source.ExecutionChannel,
	target.RebalancingId = source.RebalancingId,
	target.[LocalToSettleFxRate] = source.[LocalToSettleFxRate]
-- Handle inserts
WHEN NOT MATCHED BY TARGET THEN
INSERT 
(
    [EmsxSequence],
    OrderId,
	RebalancingId,
    InstrumentId,
    SettlementDate,
    [TradeCurrency],
    NetAmount,
    TradeDate,
    [Sedol],
    [ExchangeCode],
    [BuySellIndicator],
    [OrderQuantity],
    [FilledQuantity],
    [AvgPrice],
    [DayAveragePrice],
    [Principal],
    [BrokerCommission],
    [CommissionRate],
    [MiscFees],
    [Trader],
    [BrokerCode],
    [IsCfd],
	[IsFutureSwap],
    [SettlementCurrency],
    [Notes],
    [TradeDesk],
	TotalCharges,
	ExecutionChannel,
	[LocalToSettleFxRate]
)
VALUES 
(
    source.[EmsxSequence],
	source.OrderId,
    source.RebalancingId,
    source.InstrumentId,
    source.SettleDate,
    source.[TradeCurrency],
    source.NetAmount,
    source.[TradeDate],
    source.[Sedol],
    source.[ExchangeCode],
    source.[Side],
    source.[OrderQuantity],
    source.[FilledQuantity],
    source.[AvgPrice],
    source.[DayAvgPrice],
    source.[Principal],
    source.[BrokerCommm],
    source.[CommmRate],
    source.[MiscFees],
    source.[Trader],
    source.[Broker],
    source.[IsCfd],
	source.[IsFutureSwap],
    source.[SettleCurrency],
    source.[Notes],
    source.[Broker],
	source.TotalCharges,
	source.ExecutionChannel,
	source.[LocalToSettleFxRate]
);

-- MERGE for TradeAllocation table
MERGE INTO [trd].[StgTradeAllocToBook] AS targetAlloc
USING 
(
    SELECT distinct trd.StgTradeToBookId,
           emsx.PortfolioId AS PortfolioId,
           emsx.FilledQuantity AS Quantity,
           emsx.[AvgPrice],
           emsx.PositionSide,
		   trd.BrokerCommission as Commission,
		   trd.MiscFees as Fees,
		   trd.Principal as GrossAmount,
		   trd.NetAmount as NetAmount,
           emsx.Account AS TradingAccount
    FROM #tmpEmsxTradeToBook emsx
    LEFT JOIN trd.[StgTradeToBook] trd ON trd.EmsxSequence = emsx.EmsxSequence
    LEFT JOIN ord.[Order] o ON o.OrderId = trd.OrderId 
) AS sourceAlloc
ON targetAlloc.StgTradeToBookId = sourceAlloc.StgTradeToBookId--TODO: here we presume we have only one alloc per trade, need to be changed when launching block trading. Route must be used instead

WHEN MATCHED THEN 
UPDATE SET 
    targetAlloc.StgTradeToBookId = sourceAlloc.StgTradeToBookId,
    targetAlloc.PortfolioId = sourceAlloc.PortfolioId,
    targetAlloc.[Price] = sourceAlloc.[AvgPrice],
    targetAlloc.Quantity = sourceAlloc.Quantity,
    targetAlloc.[TradingAccount] = sourceAlloc.[TradingAccount],
    targetAlloc.PositionSide = sourceAlloc.PositionSide,
	targetAlloc.Commission = sourceAlloc.Commission,
	targetAlloc.Fees = sourceAlloc.Fees,
	targetAlloc.GrossAmount = sourceAlloc.GrossAmount,
	targetAlloc.NetAmount = sourceAlloc.NetAmount

WHEN NOT MATCHED BY TARGET THEN
INSERT 
(
    StgTradeToBookId,
    PortfolioId,
    [Quantity],
    [Price],
    [TradingAccount],
    PositionSide,
	Commission,
	Fees,
	NetAmount,
	GrossAmount
)
VALUES 
(
    sourceAlloc.StgTradeToBookId,
    sourceAlloc.PortfolioId,
    sourceAlloc.[Quantity],
    sourceAlloc.[AvgPrice],
    sourceAlloc.[TradingAccount],
    sourceAlloc.PositionSide,
	sourceAlloc.Commission,
	sourceAlloc.Fees,
	sourceAlloc.NetAmount,
	sourceAlloc.GrossAmount
);
COMMIT TRANSACTION; -- Commit the transaction if no errors
END TRY

BEGIN CATCH
    ROLLBACK TRANSACTION; -- Rollback the transaction in case of errors

    THROW; -- Re-throw the error to ensure you see what happened
END CATCH;
GO
/****** Object:  StoredProcedure [trd].[spMergeFxemTradeToBook]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [trd].[spMergeFxemTradeToBook]  --To see if this information can be passed to the order or retrived from the account, no time now
AS
BEGIN TRY
BEGIN TRANSACTION; 
SELECT [FxemOrderId]
      ,[RebalancingId]
      ,[EmsxSequence]
      ,[EmsxOrderCreatedOn]
      ,[InstrumentId]
      ,[ExchangeCode]
      ,[Sedol]
      ,[BuySellIndicator]
      ,[OrderQuantity]
      ,[FilledQuantity]
      ,[AvgPrice]
      ,[DayAveragePrice]
      ,[TradeCurrency]
      ,[Trade_Date]
      ,[Principal]
      ,[NetAmount]
      ,[SettlementDate]
      ,[SettlementCurrency]
      ,[BrokerCommission]
      ,[CommissionRate]
      ,[MiscFees]
      ,[Notes]
      ,[Trader]
      ,[BrokerCode]
      ,[TradeDesk]
      ,[IsCfd]
      ,[ExecutionChannel]
      ,[CreatedOn]
      ,[TotalCharges]
      ,[Account]
      ,[FxemTradeId]
      ,[Ccy1]
      ,[Amount_Ccy1]
      ,[Ccy2]
      ,[Amount_Ccy2]
	  ,[PositionSide]
	  ,[PortfolioId]
	 INTO #tmpFxemTradeToBook
  FROM [trd].[vwFxemTradeToBook]
  	
-- MERGE for Trade table
MERGE INTO [trd].[StgTradeToBook] AS target
USING #tmpFxemTradeToBook
AS source
ON target.[FxemTradeId] = source.[FxemTradeId]

-- Handle updates
WHEN MATCHED THEN 
UPDATE SET 
        Target.[FxemOrderId] = Source.[FxemOrderId],
        Target.[RebalancingId] = Source.[RebalancingId],
        Target.[EmsxSequence] = Source.[EmsxSequence],
        Target.[EmsxOrderCreatedOn] = Source.[EmsxOrderCreatedOn],
        Target.[InstrumentId] = Source.[InstrumentId],
        Target.[ExchangeCode] = Source.[ExchangeCode],
        Target.[Sedol] = Source.[Sedol],
        Target.[BuySellIndicator] = Source.[BuySellIndicator],
        Target.[OrderQuantity] = Source.[OrderQuantity],
        Target.[FilledQuantity] = Source.[FilledQuantity],
        Target.[AvgPrice] = Source.[AvgPrice],
        Target.[DayAveragePrice] = Source.[DayAveragePrice],
        Target.[TradeCurrency] = Source.[TradeCurrency],
        Target.[TradeDate] = Source.[Trade_Date],
        Target.[Principal] = Source.[Principal],
        Target.[NetAmount] = Source.[NetAmount],
       Target.[SettlementDate] = Source.[SettlementDate],
        Target.[SettlementCurrency] = Source.[SettlementCurrency],
        Target.[BrokerCommission] = Source.[BrokerCommission],
        Target.[CommissionRate] = Source.[CommissionRate],
        Target.[MiscFees] = Source.[MiscFees],
        Target.[Notes] = Source.[Notes],
        Target.[Trader] = Source.[Trader],
        Target.[BrokerCode] = Source.[BrokerCode],
        Target.[TradeDesk] = Source.[TradeDesk],
        Target.[IsCfd] = Source.[IsCfd],
        Target.[ExecutionChannel] = Source.[ExecutionChannel],
        Target.[CreatedOn] = Source.[CreatedOn],
        Target.[TotalCharges] = Source.[TotalCharges],
        Target.[FxemTradeId] = Source.[FxemTradeId]

-- Handle inserts
WHEN NOT MATCHED BY TARGET THEN
   INSERT (
        [FxemOrderId],
        [RebalancingId],
        [EmsxSequence],
        [EmsxOrderCreatedOn],
        [InstrumentId],
        [ExchangeCode],
        [Sedol],
        [BuySellIndicator],
        [OrderQuantity],
        [FilledQuantity],
        [AvgPrice],
        [DayAveragePrice],
        [TradeCurrency],
        [TradeDate],
        [Principal],
        [NetAmount],
        [SettlementDate],
        [SettlementCurrency],
        [BrokerCommission],
        [CommissionRate],
        [MiscFees],
        [Notes],
        [Trader],
        [BrokerCode],
        [TradeDesk],
        [IsCfd],
        [ExecutionChannel],
        [CreatedOn],
        [TotalCharges],
        [FxemTradeId],
		FxCurrency1,
		FxCurrency1Amount,
		FxCurrency2,
		FxCurrency2Amount
    )
    VALUES (
        Source.[FxemOrderId],
        Source.[RebalancingId],
        Source.[EmsxSequence],
        Source.[EmsxOrderCreatedOn],
        Source.[InstrumentId],
        Source.[ExchangeCode],
        Source.[Sedol],
        Source.[BuySellIndicator],
        Source.[OrderQuantity],
        Source.[FilledQuantity],
        Source.[AvgPrice],
        Source.[DayAveragePrice],
        Source.[TradeCurrency],
        Source.[Trade_Date],
        Source.[Principal],
        Source.[NetAmount],
        Source.[SettlementDate],
        Source.[SettlementCurrency],
        Source.[BrokerCommission],
        Source.[CommissionRate],
        Source.[MiscFees],
        Source.[Notes],
        Source.[Trader],
        Source.[BrokerCode],
        Source.[TradeDesk],
        Source.[IsCfd],
        Source.[ExecutionChannel],
        Source.[CreatedOn],
        Source.[TotalCharges],
        Source.[FxemTradeId],
		source.Ccy1,
		source.[Amount_Ccy1],
		source.Ccy2,
		source.[Amount_Ccy2]
    );


-- MERGE for TradeAllocation table
MERGE INTO [trd].[StgTradeAllocToBook] AS targetAlloc
USING 
(
    SELECT distinct trd.[StgTradeToBookId],
           fxem.PortfolioId AS PortfolioId,
           fxem.FilledQuantity AS Quantity,
           fxem.[AvgPrice],
           fxem.PositionSide as PositionSide,
		   trd.BrokerCommission as Commission,
		   trd.MiscFees as Fees,
		   trd.Principal as GrossAmount,
		   trd.NetAmount as NetAmount,
           fxem.Account AS TradingAccount
    FROM #tmpFxemTradeToBook fxem
    LEFT JOIN trd.[StgTradeToBook] trd ON trd.FxemTradeId = fxem.FxemTradeId --TODO:this mean one alloc per trade

) AS sourceAlloc
ON targetAlloc.[StgTradeToBookId] = sourceAlloc.[StgTradeToBookId]

WHEN MATCHED THEN 
UPDATE SET 
    targetAlloc.[StgTradeToBookId] = sourceAlloc.[StgTradeToBookId],
    targetAlloc.PortfolioId = sourceAlloc.PortfolioId,
    targetAlloc.[Price] = sourceAlloc.[AvgPrice],
    targetAlloc.Quantity = sourceAlloc.Quantity,
    targetAlloc.[TradingAccount] = sourceAlloc.TradingAccount,
    targetAlloc.PositionSide = sourceAlloc.PositionSide,
	targetAlloc.Commission = sourceAlloc.Commission,
	targetAlloc.Fees = sourceAlloc.Fees,
	targetAlloc.GrossAmount = sourceAlloc.GrossAmount,
	targetAlloc.NetAmount = sourceAlloc.NetAmount

WHEN NOT MATCHED BY TARGET THEN
INSERT 
(
    StgTradeToBookId,
    PortfolioId,
    [Quantity],
    [Price],
    [TradingAccount],
    PositionSide,
	Commission,
	Fees,
	NetAmount,
	GrossAmount
)
VALUES 
(
    sourceAlloc.StgTradeToBookId,
    sourceAlloc.PortfolioId,
    sourceAlloc.[Quantity],
    sourceAlloc.[AvgPrice],
    sourceAlloc.[TradingAccount],
    sourceAlloc.PositionSide,
	sourceAlloc.Commission,
	sourceAlloc.Fees,
	sourceAlloc.NetAmount,
	sourceAlloc.GrossAmount
);

 DROP TABLE #tmpFxemTradeToBook;

COMMIT TRANSACTION; -- Commit the transaction if no errors
END TRY

BEGIN CATCH
    ROLLBACK TRANSACTION; -- Rollback the transaction in case of errors
	 DROP TABLE #tmpFxemTradeToBook;
    THROW; -- Re-throw the error to ensure you see what happened
END CATCH;

GO
/****** Object:  StoredProcedure [trd].[spPropagateUpdateTrades]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO









-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [trd].[spPropagateUpdateTrades]

AS
BEGIN

-- Execute the procedures
EXEC dbo.spExecuteProcAcrossSchemas 'spUpdateTrades'

END


GO
/****** Object:  StoredProcedure [trd].[spStageTrades]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [trd].[spStageTrades]
AS
BEGIN TRY
BEGIN TRANSACTION; 


exec trd.spMergeEmsxTradeToBook
exec trd.spMergeFxemTradeToBook
exec trd.spMergeEfrpTradeToBook

  COMMIT TRANSACTION; -- Commit the transaction if no errors
END TRY

BEGIN CATCH
    ROLLBACK TRANSACTION; -- Rollback the transaction in case of errors

    THROW; -- Re-throw the error to ensure you see what happened
END CATCH;


GO
/****** Object:  StoredProcedure [trd].[spUpdateFxRates]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [trd].[spUpdateFxRates]
AS
BEGIN
    MERGE INTO [trd].FxRate AS target
    USING (
       SELECT [BaseCurrency]
      ,[QuoteCurrency]
      ,[LastValueEod]     
      ,[LastUpdateDateEod]
  FROM [mktdata].[FxRate]
    ) AS source ON (target.[BaseCurrency] = source.[BaseCurrency] AND target.[QuoteCurrency] = source.[QuoteCurrency] and target.Date = source.[LastUpdateDateEod])

    WHEN MATCHED THEN
        UPDATE SET
            target.[Value] = source.[LastValueEod],
			target.Date = source.[LastUpdateDateEod]

    WHEN NOT MATCHED BY TARGET THEN
        INSERT (
          [BaseCurrency]
      ,[QuoteCurrency]
      ,[Value]
      ,[Date]
        )
        VALUES (
            source.[BaseCurrency],
            source.[QuoteCurrency],
            source.[LastValueEod],
            source.[LastUpdateDateEod]
        );

END
GO
/****** Object:  StoredProcedure [trd].[spUpdateInstruments]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [trd].[spUpdateInstruments]
AS
BEGIN


    MERGE INTO trd.Instrument AS target
    USING (
        SELECT 
       [InstrumentId]
      ,[Symbol]
      ,[Name]
	  ,[ISIN]
      ,[BbgUniqueId]
      ,[InstrumentType]
      ,[MarketSectorDes]
      ,[Exchange]
      ,[PrimaryMIC]
      ,[Currency]
      ,[QuoteCurrency]
	  ,gen.GenericFutureId
      ,CASE WHEN fut.LastTradeDate is not null THEN fut.LastTradeDate 
	        WHEN fwd.MaturityDate is not null THEN fwd.MaturityDate 
			ELSE NULL END as MaturityDate
      ,[PriceScalingFactor]
	  ,gen.PointValue as FuturePointValue
  FROM [instr].[vwInstrument] ins
  LEFT JOIN instr.FutureContract fut on fut.FutureContractId = ins.[InstrumentId]
  LEFT JOIN instr.GenericFuture gen on gen.GenericFutureId =fut.GenericFutureId
  LEFT JOIN instr.FxForward fwd on fwd.FxForwardId = ins.[InstrumentId]
		
    ) AS source ON (target.[InstrumentId] = source.[InstrumentId])

   WHEN MATCHED THEN
        UPDATE SET
            target.[InstrumentType] = source.[InstrumentType],
            target.[Symbol] = source.[Symbol],
            target.[Name] = source.[Name],
            target.[Currency] = source.[Currency],
            target.[BbgUniqueId] = source.[BbgUniqueId],
			target.[ISIN] = source.[ISIN],
		    target.[MarketSector] = source.[MarketSectorDes],
		 	target.[Exchange] = source.[Exchange],
			target.[PrimaryMIC] = source.[PrimaryMIC],
			target.[QuoteCurrency] = source.[QuoteCurrency],
			target.[PriceScalingFactor] = source.[PriceScalingFactor],
			target.MaturityDate = source.MaturityDate,
		    target.FuturePointValue = source.FuturePointValue,
			target.GenericFutureId = source.GenericFutureId
    WHEN NOT MATCHED BY TARGET THEN
        INSERT (
               [InstrumentId]
			  ,[Symbol]
			  ,[Name]
			  ,[ISIN]
			  ,[BbgUniqueId]
			  ,[InstrumentType]
			  ,[MarketSector]
			  ,[Exchange]
			  ,[PrimaryMIC]
			  ,[Currency]
			  ,[QuoteCurrency]
			  ,[PriceScalingFactor]
			  ,[MaturityDate]
			  ,FuturePointValue
			  ,GenericFutureId
        )
        VALUES (
                 source.[InstrumentId]
				  ,source.[Symbol]
				  ,source.[Name]
				  ,source.[ISIN]
				  ,source.[BbgUniqueId]
				  ,source.[InstrumentType]
				  ,source.[MarketSectorDes]
				  ,source.[Exchange]
				  ,source.[PrimaryMIC]
				  ,source.[Currency]
				  ,source.[QuoteCurrency]
				   ,source.[PriceScalingFactor]
			  ,source.[MaturityDate]
			  ,source.[FuturePointValue]
			  ,source.GenericFutureId
        )
		    WHEN NOT MATCHED BY SOURCE THEN
        DELETE;


END
GO
/****** Object:  StoredProcedure [trd].[spUpdateTradeQuantityByTradeId]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [trd].[spUpdateTradeQuantityByTradeId]
	@trade_id int ,
    @new_quantity_value DECIMAL(18,2)  -- Adjust the data type as necessary
        -- Adjust the data type and length as necessary
AS
BEGIN
    UPDATE trd
    SET trd.OrderQuantity = @new_quantity_value, trd.FilledQuantity = @new_quantity_value,trd.TradeStatus = 'COR'
    FROM [trd].[Trade] trd
    JOIN instr.Instrument ins ON ins.InstrumentId = trd.InstrumentId
    WHERE trd.TradeId = @trade_id;

	UPDATE ta
    SET ta.Quantity = @new_quantity_value
    FROM [trd].[TradeAllocation] ta
    JOIN [trd].[Trade] trd ON ta.TradeId = trd.TradeId
    JOIN instr.Instrument ins ON ins.InstrumentId = trd.InstrumentId
    WHERE trd.TradeId = @trade_id;
END;
GO
/****** Object:  StoredProcedure [trd].[spValidateTradesToBook]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [trd].[spValidateTradesToBook]
AS
BEGIN
    SET NOCOUNT ON;
-- Initialize the error variables
 DECLARE @ErrorFlag INT;
    DECLARE @ErrorMessage NVARCHAR(MAX);
    
    -- Initialize the error variables
    DECLARE @TempErrorMessages TABLE (ErrorMessage NVARCHAR(MAX));

SET @ErrorFlag = 0;
SET @ErrorMessage = '';

-- Check InstrumentId
INSERT INTO @TempErrorMessages
SELECT 'InstrumentId is missing for StgTradeToBookId: ' + CAST(StgTradeToBookId AS NVARCHAR(50))
FROM [trd].[StgTradeToBook] 
WHERE InstrumentId IS NULL;


INSERT INTO @TempErrorMessages
SELECT 'BuySellIndicator mismatch with quantity: ' + CAST(StgTradeToBookId AS NVARCHAR(50))
FROM [trd].[StgTradeToBook] 
WHERE (BuySellIndicator = 'S' and FilledQuantity >0 or BuySellIndicator = 'S' and OrderQuantity >0)
OR (BuySellIndicator = 'B' and FilledQuantity <0 or BuySellIndicator = 'B' and OrderQuantity <0);


-- Continue for all other columns...

INSERT INTO @TempErrorMessages
SELECT 'OrderQuantity is missing for StgTradeToBookId: ' + CAST(StgTradeToBookId AS NVARCHAR(50))
FROM [trd].[StgTradeToBook] 
WHERE OrderQuantity IS NULL;

INSERT INTO @TempErrorMessages
SELECT 'FilledQuantity is missing for StgTradeToBookId: ' + CAST(FilledQuantity AS NVARCHAR(50))
FROM [trd].[StgTradeToBook] 
WHERE FilledQuantity IS NULL;

INSERT INTO @TempErrorMessages
SELECT 'AvgPrice is missing for StgTradeToBookId: ' + CAST(StgTradeToBookId AS NVARCHAR(50))
FROM [trd].[StgTradeToBook] 
WHERE AvgPrice IS NULL;

-- ... continue for all fields ...

INSERT INTO @TempErrorMessages
SELECT 'IsCfd is missing for StgTradeToBookId: ' + CAST(StgTradeToBookId AS NVARCHAR(50))
FROM [trd].[StgTradeToBook] 
WHERE IsCfd IS NULL;

INSERT INTO @TempErrorMessages
SELECT 'Principal is missing for StgTradeToBookId: ' + CAST(StgTradeToBookId AS NVARCHAR(50))
FROM [trd].[StgTradeToBook] 
WHERE Principal IS NULL;



-- After all checks, gather the error messages
SELECT @ErrorFlag = CASE WHEN COUNT(*) > 0 THEN 1 ELSE @ErrorFlag END
FROM @TempErrorMessages;

SELECT @ErrorMessage = STRING_AGG(ErrorMessage, ' ')
FROM @TempErrorMessages;


    -- At the end, if you want to return or output the error messages:
    IF @ErrorFlag = 1
    BEGIN
        RAISERROR(@ErrorMessage, 16, 1); 
        -- Adjust the error severity and state as necessary. 16 is typical for user-defined errors.
    END

END
GO
/****** Object:  StoredProcedure [val].[spComputeInstrumentValuation]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [val].[spComputeInstrumentValuation]
AS
BEGIN
WITH CTE_MarketData AS (
    SELECT distinct
        [InstrumentId],
        [LastPriceEod] AS Price,
        ISNULL(LAG([LastPriceEod], 1) OVER (PARTITION BY [InstrumentId] ORDER BY [LastUpdateDateEod]), [LastPriceEod]) AS PreviousPrice,
        ISNULL(LAG([LastUpdateDateEod], 1) OVER (PARTITION BY [InstrumentId] ORDER BY [LastUpdateDateEod]),[LastUpdateDateEod]) AS PreviousPriceDate, -- Getting the previous date
        [LastUpdateDateEod] AS PriceDate,
        [Currency]
    FROM 
        [mktdata].[MarketData]
), 
pricereturns AS (
    SELECT 
        x.[InstrumentId],
        i.Symbol,
        [Price],
        PreviousPrice,
        PriceDate,
        PreviousPriceDate,  -- Including the PreviousPriceDate in this CTE
        x.[Currency],
        CASE WHEN [Price] IS NOT NULL THEN ([Price] - PreviousPrice) / PreviousPrice ELSE NULL END AS PriceReturn,
        ISNULL(f.PointValue, 1) AS [ValuationFactor]
    FROM 
        CTE_MarketData x
        JOIN mktdata.Instrument i ON i.InstrumentId = x.InstrumentId
        LEFT JOIN val.FutureContract f ON f.FutureContractId = x.InstrumentId
)
MERGE INTO [val].[InstrumentValuation] AS target
USING (
SELECT 
    [InstrumentId],
    Symbol,
    [Price],
    PreviousPrice,
    PriceDate,
    PreviousPriceDate,  -- Including the PreviousPriceDate in the final selection
    [ValuationFactor],
    Price * [ValuationFactor] AS InstrumentValue,
    PreviousPrice * [ValuationFactor] AS PreviousInstrumentValue,

    [Currency],
    PriceReturn 
FROM 
    pricereturns
) AS source
ON (target.[InstrumentId] = source.[InstrumentId] AND target.[PriceDate] = source.[PriceDate] AND target.[Currency] = source.[Currency]  )
WHEN MATCHED THEN 
    UPDATE SET 
        target.[Price] = source.[Price],
		target.[PriceDate] = source.[PriceDate],
        target.[PreviousPrice] = source.[PreviousPrice],
        target.[PreviousPriceDate] = source.[PreviousPriceDate],
        target.[PriceReturn] = source.[PriceReturn],
        target.[InstrumentValue] = source.[InstrumentValue],
	    target.PreviousInstrumentValue = source.PreviousInstrumentValue,
		target.[ValuationFactor] = source.[ValuationFactor],
        target.[Currency] = source.[Currency]
WHEN NOT MATCHED BY TARGET THEN 
    INSERT ([InstrumentId], 
	[Price], 
	[PriceDate], 
	[PreviousPrice], 
	[PreviousPriceDate], 
	[PriceReturn], 
	[InstrumentValue],
	[ValuationFactor],
	[PreviousInstrumentValue], 
	[Currency])
    VALUES (source.[InstrumentId],
	source.[Price], 
	source.[PriceDate], 
	source.[PreviousPrice], 
	source.[PreviousPriceDate], 
	source.[PriceReturn], 
	source.[InstrumentValue],
	source.[ValuationFactor],
	source.[PreviousInstrumentValue], 
	source.[Currency]);
END
GO
/****** Object:  StoredProcedure [val].[spUpdateFutureContracts]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [val].[spUpdateFutureContracts]
AS
BEGIN
    MERGE INTO [val].FutureContract AS target
    USING (
        SELECT
            [FutureContractId],
            [PointValue],
            [QuoteCurrency]     
        FROM [instr].[vwFutureContract]
    ) AS source ON (target.[FutureContractId] = source.[FutureContractId])

    WHEN MATCHED THEN
        UPDATE SET
            target.[PointValue] = source.[PointValue],
            target.[PointValueCurrency] = source.[QuoteCurrency] -- Assuming you want to update PointValueCurrency with QuoteCurrency

    WHEN NOT MATCHED BY TARGET THEN
        INSERT ([FutureContractId], [PointValue], [PointValueCurrency])
        VALUES (source.[FutureContractId], source.[PointValue], source.[QuoteCurrency])

    WHEN NOT MATCHED BY SOURCE THEN
        DELETE;

END
GO
/****** Object:  StoredProcedure [val].[spUpdateFxRates]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [val].[spUpdateFxRates]
AS
BEGIN
    MERGE INTO [val].FxRate AS target
    USING (
       SELECT [BaseCurrency]
      ,[QuoteCurrency]
      ,[LastValueEod]     
      ,[LastUpdateDateEod]
  FROM [mktdata].[vwLastFxRateEod]
    ) AS source ON (target.[BaseCurrency] = source.[BaseCurrency] AND target.[QuoteCurrency] = source.[QuoteCurrency] )

    WHEN MATCHED THEN
        UPDATE SET
            target.[Value] = source.[LastValueEod]

    WHEN NOT MATCHED BY TARGET THEN
        INSERT (
          [BaseCurrency]
      ,[QuoteCurrency]
      ,[Value]
      ,[Date]
        )
        VALUES (
            source.[BaseCurrency],
            source.[QuoteCurrency],
            source.[LastValueEod],
            source.[LastUpdateDateEod]
        );

END
GO
/****** Object:  StoredProcedure [val].[spUpdateInstrumentPricings]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [val].[spUpdateInstrumentPricings]
AS
BEGIN
    MERGE INTO [val].InstrumentPricing AS target
    USING (
        SELECT
            [InstrumentId],
            [LastPriceEod],
            [LastUpdateDateEod],
            [Currency]
        FROM [mktdata].[vwLastPriceEod]
    ) AS source ON (target.[InstrumentId] = source.[InstrumentId] )

    WHEN MATCHED THEN
        UPDATE SET
            target.[Price] = source.[LastPriceEod],
            target.[Currency] = source.[Currency],
			target.[Date]=source.[LastUpdateDateEod]
    WHEN NOT MATCHED BY TARGET THEN
        INSERT (
            [InstrumentId],
            [Price],
            [Currency],
            [Date]
        )
        VALUES (
            source.[InstrumentId],
            source.[LastPriceEod],
            source.[Currency],
            source.[LastUpdateDateEod]
        )
		WHEN NOT MATCHED BY SOURCE THEN
		DELETE;

   
END
GO
/****** Object:  StoredProcedure [val].[spUpdateInstruments]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [val].[spUpdateInstruments]
AS
BEGIN

    MERGE INTO [val].Instrument AS target
    USING (
        SELECT
       [InstrumentId]
      ,[Symbol]
      ,[InstrumentType]
      ,[Currency]     
  FROM [instr].[vwInstrument]
    ) AS source ON (target.[InstrumentId] = source.[InstrumentId])
		 WHEN MATCHED THEN
        UPDATE SET
            target.[Symbol] = source.[Symbol],
			target.[InstrumentType] = source.[InstrumentType],
			target.[Currency]= source.[Currency]
    WHEN NOT MATCHED BY TARGET THEN
        INSERT (  [InstrumentId]
      ,[Symbol]
      ,[InstrumentType]
      ,[Currency]
      )
        VALUES ( source. [InstrumentId]
      ,source.[Symbol]
      ,source.[InstrumentType]
      ,source.[Currency]
      )
	 WHEN NOT MATCHED BY SOURCE THEN
        DELETE;
	  EXEC [val].[spUpdateFutureContracts]
END
GO
/****** Object:  StoredProcedure [val].[spUpdateMarketData]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [val].[spUpdateMarketData]
AS
BEGIN
EXEC [val].[spUpdateFxRates]
EXEC [val].[spUpdateInstrumentPricings]
--EXEC [val].[spComputeInstrumentValuation]
END
GO
/****** Object:  StoredProcedure [val].[spUpdatePositions]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [val].[spUpdatePositions]

AS
BEGIN
MERGE INTO [val].[Position] AS Target
USING (SELECT [PortfolioId]
      ,[InstrumentId]
      ,[Symbol]
	  ,[IsSwap]
      ,[InstrumentType]
      ,[InstrumentName]
      ,[Quantity]
      ,[AvgEntryPriceLocal]
      ,[GrossTotalCostLocal]
      ,[NetTotalCostLocal]
      ,[LastTradeAllocationId]
      ,[PositionDate]
      ,[Currency]as Currency
   
  FROM [port].[vwLastOpenPosition]
       ) AS Source
ON (Target.[PortfolioId] = Source.[PortfolioId] 
    AND Target.[InstrumentId] = Source.[InstrumentId]
    AND Target.[PositionDate] = Source.[PositionDate]
    AND Target.[Currency] = Source.[Currency]
	)
WHEN MATCHED THEN 
    UPDATE SET
        Target.[Quantity] = Source.[Quantity],
        Target.[AvgEntryPriceLocal] = Source.[AvgEntryPriceLocal],
        Target.[GrossTotalCostLocal] = Source.[GrossTotalCostLocal],
        Target.[NetTotalCostLocal] = Source.[NetTotalCostLocal],
		 Target.[LastTradeAllocationId] = Source.[LastTradeAllocationId],

		Target.[IsSwap] = Source.[IsSwap]

WHEN NOT MATCHED BY TARGET THEN
    INSERT ([PortfolioId], 
            [InstrumentId], 
            [Quantity], 
            [AvgEntryPriceLocal], 
            [GrossTotalCostLocal], 
            [NetTotalCostLocal], 
            [PositionDate], 
            [Currency],
			[LastTradeAllocationId],
			[IsSwap])
    VALUES (Source.[PortfolioId], 
            Source.[InstrumentId], 
            Source.[Quantity], 
            Source.[AvgEntryPriceLocal], 
            Source.[GrossTotalCostLocal], 
            Source.[NetTotalCostLocal], 
            Source.[PositionDate], 
            Source.[Currency],
			Source.[LastTradeAllocationId],
			 Source.[IsSwap])
WHEN NOT MATCHED BY SOURCE THEN
DELETE;
END
GO
/****** Object:  StoredProcedure [wght].[spUpdateInstruments]    Script Date: 6/26/2024 1:49:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [wght].[spUpdateInstruments]
AS
BEGIN

    MERGE INTO [wght].Instrument AS target
    USING (
        SELECT DISTINCT TOP 1000000 
       [InstrumentId]
      ,[Symbol]
     
  FROM [instr].[vwInstrument]
  WHERE InstrumentType in ('GENFUT', 'EQU', 'CROSS' )
		ORDER BY [InstrumentId]
    ) AS source ON (target.[InstrumentId] = source.[InstrumentId])
	 WHEN MATCHED THEN
        UPDATE SET
            target.[Symbol] = source.[Symbol]
    WHEN NOT MATCHED BY TARGET THEN
        INSERT ( [InstrumentId]
      ,[Symbol]
      )
        VALUES ( source.[InstrumentId]
      ,source.[Symbol]
      )
	 WHEN NOT MATCHED BY SOURCE THEN
        DELETE;
END
GO
ALTER DATABASE [Trading] SET  READ_WRITE 
GO
