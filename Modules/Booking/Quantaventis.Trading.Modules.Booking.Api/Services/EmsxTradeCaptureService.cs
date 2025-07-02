using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Booking.Api.Dto;
using Quantaventis.Trading.Modules.Booking.Api.Mappers;
using Quantaventis.Trading.Modules.Booking.Domain.Model;
using Quantaventis.Trading.Modules.Booking.Domain.Repositories;

namespace Quantaventis.Trading.Modules.Booking.Api.Services
{
    internal interface IEmsxTradeCaptureService
    {
        Task<RawTrade> CaptureTradeAsync(EmsxTradeDto orderExecutionDto);

    }
    internal class EmsxTradeCaptureService : IEmsxTradeCaptureService
    {

        private IRawTradeRepository RawTradeRepository { get; }
        private ILogger<EmsxTradeCaptureService> Logger { get; }

        public EmsxTradeCaptureService(IRawTradeRepository executedTradeRepository, ILogger<EmsxTradeCaptureService> logger)
        {
            RawTradeRepository = executedTradeRepository;
            Logger = logger;
        }

        public async Task<RawTrade> CaptureTradeAsync(EmsxTradeDto emsxTradeDto)
        {
            Logger.LogInformation($"Capturing Emsx Trade {emsxTradeDto.Side} {emsxTradeDto.FilledQuantity} {emsxTradeDto.Symbol}..");
            RawTrade capturedTrade = emsxTradeDto.Map();
            capturedTrade = await RawTradeRepository.UpsertByEmsxOrderIdAsync(capturedTrade);
            Logger.LogInformation($"Emsx Trade {capturedTrade} Captured..");
            return capturedTrade;
        }


    }
}
