using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Booking.Api.Dto;
using Quantaventis.Trading.Modules.Booking.Api.Events.Out;
using Quantaventis.Trading.Modules.Booking.Api.Mappers;
using Quantaventis.Trading.Modules.Booking.Domain.Exceptions;
using Quantaventis.Trading.Modules.Booking.Domain.Model;
using Quantaventis.Trading.Modules.Booking.Domain.Repositories;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
namespace Quantaventis.Trading.Modules.Booking.Api.Services
{
    internal interface ITradeBookingService
    {
        Task OnEmsxTradeReceived(EmsxTradeDto orderExecutionDto);
        Task BookNonBookedTradesAsync();
        Task TriggerBookedTradeSync(DateOnly tradeDate);
        Task BookTradeAsync(int tradeId, bool forceRebook = false, bool flagAsCorrected = false);
        Task BookTradeAsync(RawTrade trade, bool forceRebook = false, bool flagAsCorrected = false);
    }
    internal class TradeBookingService : ITradeBookingService
    {
        private IEmsxTradeCaptureService TradeCaptureService { get; }
        private ITradeAllocationService TradeAllocationService { get; }
        private ITradeEnrichmentService TradeEnrichmentService { get; }
        private ITradeValidationService TradeValidationService { get; }
        private IRawTradeRepository RawTradeRepository { get; }
        private IBookedTradeRepository BookedTradeRepository { get; }
        private ITradeBookingErrorRepository TradeBookingErrorRepository { get; }
        private ILogger<TradeBookingService> Logger { get; }
        private IMessageBroker MessageBroker { get; }
        public TradeBookingService(IEmsxTradeCaptureService tradeCaptureService,
            ITradeAllocationService tradeAllocationService,
            ITradeEnrichmentService tradeEnrichmentService,
            ITradeValidationService tradeValidationService,
            IRawTradeRepository executedTradeRepository,
            IBookedTradeRepository bookedTradeRepository,
            ITradeBookingErrorRepository bookingErrorRepository,
            IMessageBroker messageBroker,
            ILogger<TradeBookingService> logger)
        {
            TradeCaptureService = tradeCaptureService;
            TradeAllocationService = tradeAllocationService;
            TradeEnrichmentService = tradeEnrichmentService;
            TradeValidationService = tradeValidationService;
            RawTradeRepository = executedTradeRepository;
            BookedTradeRepository = bookedTradeRepository;
            TradeBookingErrorRepository = bookingErrorRepository;
            MessageBroker = messageBroker;
            Logger = logger;
        }

        public async Task BookTradeAsync(int tradeId, bool forceRebook = false, bool flagAsCorrected = false)
        {
            RawTrade? executedTrade = await RawTradeRepository.GetByTradeId(tradeId);
            if (executedTrade != null)
            {
                await BookTradeAsync(executedTrade, forceRebook, flagAsCorrected);
            }
            else
            {
                var msg = $"Trade {tradeId} couldn't be booked. No ExecutedTrade found for TradeId:{tradeId}";
                Logger.LogError(msg);
                throw new InvalidOperationException(msg);
            }
        }


        private async Task<BookedTrade> GenerateBookedTradeAsync(RawTrade rawTrade)
        {

            IEnumerable<RawTradeAllocation> rawTradeAllocations = await TradeAllocationService.AllocateTradeAsync(rawTrade);
            EnrichedTrade enrichedTrade = await TradeEnrichmentService.EnrichTradeAsync(rawTrade);
            IEnumerable<EnrichedTradeAllocation> enrichedTradeAllocations = await TradeEnrichmentService.EnrichTradeAllocationsAsync(enrichedTrade, rawTradeAllocations);
            return BookedTrade.New(enrichedTrade, enrichedTradeAllocations);

        }
        public async Task BookTradeAsync(RawTrade rawTrade, bool forceRebook = false, bool flagAsCorrected = false)
        {

            try
            {
                Logger.LogInformation($"Booking Trade:{rawTrade} ForceRebook:{forceRebook} FlagAsCorrected:{flagAsCorrected}");
                await TradeBookingErrorRepository.DeleteByTradeIdAsync(rawTrade.TradeId);
                BookedTrade? alreadyBookedTrade = await BookedTradeRepository.GetByTradeId(rawTrade.TradeId);
                var isAlreadyBooked = alreadyBookedTrade != null;
                if (isAlreadyBooked && !forceRebook)
                {
                    Logger.LogWarning($"Trade {rawTrade.TradeId} is already booked. No action will be done.");
                }
                else
                {
                    BookedTrade newBookedTrade = await GenerateBookedTradeAsync(rawTrade);

                    if (isAlreadyBooked && flagAsCorrected)
                        newBookedTrade = newBookedTrade.AsCorrected(true);
                    TradeValidation tradeValidation = await TradeValidationService.ValidateTradeAsync(newBookedTrade);

                    if (tradeValidation.IsSuccess())
                    {


                        await BookedTradeRepository.UpsertAsync(newBookedTrade);

                        Logger.LogWarning($"Trade {newBookedTrade} booked.");
                        await MessageBroker.PublishAsync(new TradeBooked(newBookedTrade.Map()));
                    }
                    else
                    {
                        Logger.LogError($"Trade {rawTrade.TradeId} couldn't be booked because it is not valide:");

                        foreach (var tradeValidationError in tradeValidation.TradeValidationErrors)
                        {
                            Logger.LogError(tradeValidationError.Message);
                        }
                    }

                }
            }
            catch (TradeAllocationException e)
            {
                Logger.LogError(e, $"Trade Allocation Error. TradeId:{rawTrade.TradeId}");
                TradeBookingError error = new TradeBookingError(e.TradeId, e.BookingErrorType, e.Message);
                await TradeBookingErrorRepository.CreateAsync(error);

            }
            catch (TradeEnrichmentException e)
            {
                Logger.LogError(e, $"Trade Enrichment Error. TradeId:{rawTrade.TradeId}");
                TradeBookingError error = new TradeBookingError(e.TradeId, e.BookingErrorType, e.Message);
                await TradeBookingErrorRepository.CreateAsync(error);
            }
            catch (TradeValidationException e)
            {
                Logger.LogError(e, $"Trade Validation Error. TradeId:{rawTrade.TradeId}");
                TradeBookingError error = new TradeBookingError(e.TradeId, e.BookingErrorType, e.Message);
                await TradeBookingErrorRepository.CreateAsync(error);
            }
            catch (Exception e)
            {

                Logger.LogError(e, $"Trade Booking Error. TradeId:{rawTrade.TradeId}");
                TradeBookingError error = new TradeBookingError(rawTrade.TradeId, BookingErrorType.Unkown, e.Message);
                await TradeBookingErrorRepository.CreateAsync(error);
            }
            finally
            {
                await Task.CompletedTask;
            }

        }
        public async Task OnEmsxTradeReceived(EmsxTradeDto orderExecutionDto)
        {
            RawTrade executedTrade = await TradeCaptureService.CaptureTradeAsync(orderExecutionDto);
            await BookTradeAsync(executedTrade);
        }

        public async Task BookNonBookedTradesAsync()
        {
            IEnumerable<RawTrade> nonBookedRawTrades = await RawTradeRepository.GetNonBookedAsync();
            foreach (RawTrade rawTrade in nonBookedRawTrades)
            {
                await BookTradeAsync(rawTrade);
            }
        }

        public async Task TriggerBookedTradeSync(DateOnly tradeDate)
        {
            Logger.LogInformation($"Trigger Booked Trade Sync requested. TradeDate:{tradeDate.ToString("yyyyMMdd")}");
            IEnumerable<BookedTrade> bookedTrades = await BookedTradeRepository.GetByTradeDate(tradeDate);
            await MessageBroker.PublishAsync(new BookedTradesSync(bookedTrades.Map()));
        }
    }
}
