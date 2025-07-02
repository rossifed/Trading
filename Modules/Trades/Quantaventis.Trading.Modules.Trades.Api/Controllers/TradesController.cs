using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quantaventis.Trading.Modules.Trades.Api.Commands;
using Quantaventis.Trading.Shared.Abstractions.Dispatchers;
using Swashbuckle.AspNetCore.Annotations;

namespace Quantaventis.Trading.Modules.Trades.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    internal class TradesController : Controller
    {

        private  IDispatcher Dispatcher { get; }

        public TradesController(IDispatcher dispatcher)
        {
            Dispatcher = dispatcher;

        }

        [HttpPost()]
        [Route("Trades/Book")]
        [SwaggerOperation("Book Trades")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> BookTrades(BookTrades command)
        {
            await Dispatcher.SendAsync(command);
            return NoContent();
        }
        [HttpPost()]
        [Route("Trades/Stage")]
        [SwaggerOperation("Stage Trades")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> BookTrades(StageTrades command)
        {
            await Dispatcher.SendAsync(command);
            return NoContent();
        }

        [HttpPost()]
        [Route("Trades/StageAndBook")]
        [SwaggerOperation("Stage and Book Trades")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> StageAndBookTrades(StageAndBookTrades command)
        {
            await Dispatcher.SendAsync(command);
            return NoContent();
        }

        [HttpPost()]
        [Route("Trades/Validate")]
        [SwaggerOperation("Validate Trades")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> ValidateTrades(ValidateTrades command)
        {
            await Dispatcher.SendAsync(command);
            return NoContent();
        }

        [HttpPost()]
        [Route("Trades/TriggerSync")]
        [SwaggerOperation("Trigger Sync Event")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> TriggerSyncEvent(TriggerTradesSyncEvent command)
        {
            await Dispatcher.SendAsync(command);
            return NoContent();
        }

        [HttpPost()]
        [Route("Trades/Import/FXEM")]
        [SwaggerOperation("Import FXEM Trades")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> ImportFxemTrades(ImportFxemTrades command)
        {
            await Dispatcher.SendAsync(command);
            return NoContent();
        }
        [HttpPost()]
        [Route("Trades/Import/EFRP")]
        [SwaggerOperation("Import MS EFRP Trades")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> ImportEfrpTrades(ImportMsEfrpTrades command)
        {
            await Dispatcher.SendAsync(command);
            return NoContent();
        }
    }
}
