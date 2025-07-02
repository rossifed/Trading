using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quantaventis.Trading.Modules.Portfolios.Api.Commands;
using Quantaventis.Trading.Modules.Portfolios.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Dispatchers;
using Swashbuckle.AspNetCore.Annotations;
using Quantaventis.Trading.Modules.Portfolios.Api.Queries.In;
namespace Quantaventis.Trading.Modules.Portfolios.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    internal class PositionsController : Controller
    {

        private  IDispatcher Dispatcher { get; }

        public PositionsController(IDispatcher dispatcher)
        {
            Dispatcher = dispatcher;

        }
        [HttpPost()]
        [Route("ComputeDailyPositions")]
        [SwaggerOperation("Test purpose prior release. Compute Daily Positions, to be triggered eod")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> TriggerSyncEvent(ComputeDailyPositions command)
        {
            await Dispatcher.SendAsync(command);
            return NoContent();
        }

    }
}
