using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quantaventis.Trading.Modules.Booking.Api.Commands.In;
using Quantaventis.Trading.Shared.Abstractions.Dispatchers;
using Swashbuckle.AspNetCore.Annotations;

namespace Quantaventis.Trading.Modules.Booking.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    internal class BookingController : Controller
    {

        private  IDispatcher Dispatcher { get; }

        public BookingController(IDispatcher dispatcher)
        {
            Dispatcher = dispatcher;

        }


   

        [HttpPost()]
        [Route("BookTrade")]
        [SwaggerOperation("Book Trade")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task BookTrade(int tradId, bool forceReBook=false, bool flagAsCorrected = false)
        => await Dispatcher.SendAsync(new BookTrade(tradId, forceReBook, flagAsCorrected));

        [HttpPost()]
        [Route("BookNonBookedTrades")]
        [SwaggerOperation("Book Non Booked Trades")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task BookTrades()
         => await Dispatcher.SendAsync(new BookNonBookedTrades());

        [HttpPut()]
        [Route("CancelTrade")]
        [SwaggerOperation("Cancel Trade")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task CancelTrade(int tradId)
     => await Dispatcher.SendAsync(new CancelTrade(tradId));

        //[HttpPut()]
        //[Route("CorrectTrade")]
        //[SwaggerOperation("Correct Trade")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task CorrectTrade(CorrectTrade correctTrade)
        //    => await Dispatcher.SendAsync(correctTrade);


        //[HttpPut()]
        //[Route("CorrectTradeAllocation")]
        //[SwaggerOperation("Correct Trade Allocation")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task CorrectTradeAllocation(CorrectTradeAllocation correctTradeAllocation)
        //    => await Dispatcher.SendAsync(correctTradeAllocation);

        [HttpPut()]
        [Route("FlagTradeAsCorrected")]
        [SwaggerOperation("Flag Trade As Corrected")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task FlagTradeAsCorrected(FlagTradeAsCorrected flagTradeAsCorrected)
          => await Dispatcher.SendAsync(flagTradeAsCorrected);

        [HttpPut()]
        [Route("FlagTradeAllocationAsCorrected")]
        [SwaggerOperation("Flag TradeAllocation As Corrected")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task FlagTradeAllocationAsCorrected(FlagTradeAllocationAsCorrected flagTradeAlllocationAsCorrected)
       => await Dispatcher.SendAsync(flagTradeAlllocationAsCorrected);


        [HttpPost()]
        [Route("TriggerSyncTradesByTradeDate")]
        [SwaggerOperation("Trigger Trade Sync Event By Trade Date")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task TriggerSyncTradesByTradeDate(TriggerSyncTradesByTradeDate command)
            => await Dispatcher.SendAsync(command);


        [HttpPost()]
        [Route("TriggerSyncTradesByInstrument")]
        [SwaggerOperation("Trigger Trade Sync Event By InstrumentId")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task TriggerSyncTradesByInstrument(TriggerSyncTradesByInstrument command)
             => await Dispatcher.SendAsync(command);

        [HttpPost()]
        [Route("TriggerSyncTradeById")]
        [SwaggerOperation("Trigger Trade Sync Event By  TradeId")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task TriggerSyncTradeById(TriggerSyncTradeById command)
       => await Dispatcher.SendAsync(command);


        [HttpPost()]
        [Route("ForceAllocation")]
        [SwaggerOperation("Force Allocation creating a RawAllocation manually")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task ForceAllocation(ForceAllocation command)
      => await Dispatcher.SendAsync(command);



        [HttpPost()]
        [Route("CreateManualTrade")]
        [SwaggerOperation("Create a Trade Manually")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task ForceAllocation(CreateManualTrade command)
      => await Dispatcher.SendAsync(command);
    }
}
