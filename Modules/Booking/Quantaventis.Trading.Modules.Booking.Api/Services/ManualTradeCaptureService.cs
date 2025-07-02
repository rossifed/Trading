using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Booking.Api.Commands.In;
using Quantaventis.Trading.Modules.Booking.Api.Dto;
using Quantaventis.Trading.Modules.Booking.Api.Mappers;
using Quantaventis.Trading.Modules.Booking.Domain.Model;
using Quantaventis.Trading.Modules.Booking.Domain.Repositories;
using System.Text;


namespace Quantaventis.Trading.Modules.Booking.Api.Services
{
    internal interface IManualTradeCaptureService
    {
        Task CaptureManualTradeAsync(ManualTradeDto manualTrade);

    }
    internal class ManualTradeCaptureService : IManualTradeCaptureService
    {
        private IInstrumentRepository InstrumentRepository { get; }
        private IRawTradeRepository RawTradeRepository { get; }
        private ITradeAllocationService TradeAllocationService { get; }
        private ILogger<EmsxTradeCaptureService> Logger { get; }

        public ManualTradeCaptureService(
            IInstrumentRepository instrumentRepository, 
            IRawTradeRepository rawTradeRepository, 
            ITradeAllocationService tradeAllocationService, 
            ILogger<EmsxTradeCaptureService> logger)
        {
            InstrumentRepository = instrumentRepository;
            RawTradeRepository = rawTradeRepository;
            TradeAllocationService = tradeAllocationService;
            Logger = logger;
        }

        private void ValidateManualTrade (ManualTradeDto manualTrade)
        { StringBuilder sb = new StringBuilder();
            var isError = false;
            if (string.IsNullOrEmpty(manualTrade.Symbol)) { 
                isError = true;
                sb.AppendLine($"Manual Trade Creation Error: Symbol must be specified");
            }

            if (manualTrade.TradeDate == null)
            {
                isError = true;
                sb.AppendLine($"Manual Trade Creation Error: Trade Date must be specified");
            }
            if (manualTrade.ExecutionDesk == null)
            {
                isError = true;
                sb.AppendLine($"Manual Trade Creation Error: ExecutionDesk must be specified");
            }
            if (manualTrade.ExecutionAccount == null)
            {
                isError = true;
                sb.AppendLine($"Manual Trade Creation Error: ExecutionAccount must be specified");
            }
            if ( manualTrade.Quantity == 0)
            {
                isError = true;
                sb.AppendLine($"Manual Trade Creation Error: Quantity can't be 0");
            }

            if (manualTrade.Price <= 0)
            {
                isError = true;
                sb.AppendLine($"Manual Trade Creation Error: Price must be greater than 0");
            }
    
            if (manualTrade.IsCfd  && !manualTrade.Symbol.Contains("Equity"))
            {
                isError = true;
                sb.AppendLine($"Manual Trade Creation Error: Only Equities can be flagged as CFD");
            }

            if (manualTrade.PositionSide == null && !manualTrade.PositionSide.IsValidPositionSide())
            {
                isError = true;
                sb.AppendLine($"Manual Trade Creation Error: Position Side {manualTrade.PositionSide} is not valid");
            }
            if (!Currency.IsValidCurrencyCode(manualTrade.Currency) )
            {
                isError = true;
                sb.AppendLine($"Manual Trade Creation Error: Currency Code {manualTrade.Currency} is not valid");
            }

            if (isError)
            throw new InvalidOperationException(sb.ToString());


        }

        private string ExtractYellowKey(string symbol) { 
        return symbol.Split(' ').Last();
        }
        public async Task CaptureManualTradeAsync(ManualTradeDto manualTrade)
        {
            Logger.LogInformation($"Capturing Maual Trade {manualTrade.Symbol} {manualTrade.Quantity} {manualTrade.TradeDate}");
            ValidateManualTrade(manualTrade);
            Instrument? instrument = await InstrumentRepository.GetBySymbolAsync(manualTrade.Symbol);

            if (instrument == null) {
                var message = $"Manual Trade Creation Error: No Instrument with symbol:{manualTrade.Symbol} found";
                Logger.LogInformation(message);
                throw new InvalidOperationException(message);
            }
            else {

                var yellowKey = ExtractYellowKey(instrument.Symbol);
                RawTrade rawTrade = new RawTrade(0, 
                    instrument.Symbol,
                    TradeSide.FromQuantity(manualTrade.Quantity), 
                    manualTrade.Quantity, 
                    manualTrade.Price,
                    manualTrade.Currency,
                    manualTrade.TradeDate.Value,
                    manualTrade.Exchange,
                    manualTrade.ExecutionDesk,
                    manualTrade.ExecutionAccount,
                    manualTrade.IsCfd,
                    "MANUAL",
                    null,
                    new InstrumentIdentifiers(instrument.Symbol, yellowKey),
                    OrderDetails.Empty(),
                    FillsDetails.Empty());
             rawTrade =  await  RawTradeRepository.CreateAsync(rawTrade);
                Logger.LogInformation($"Raw Trade  {rawTrade} Created Manually");

               await  TradeAllocationService.ForceAllocationAsync(rawTrade.TradeId, manualTrade.PortfolioId, manualTrade.PositionSide);
            }

        }
    }
}
