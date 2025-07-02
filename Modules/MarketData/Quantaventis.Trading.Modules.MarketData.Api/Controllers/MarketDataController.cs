using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quantaventis.Trading.Modules.MarketData.Api.Commands;
using Quantaventis.Trading.Shared.Abstractions.Dispatchers;
using Swashbuckle.AspNetCore.Annotations;

namespace Quantaventis.Trading.Modules.MarketData.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    internal class MarketDataController : Controller
    {

        private  IDispatcher Dispatcher { get; }

        public MarketDataController(IDispatcher dispatcher)
        {
            Dispatcher = dispatcher;

        }


        [HttpPost()]
        [Route("IntegrateMarketData")]
        [SwaggerOperation("Integrate MarketData")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(IntegrateMarketDataFile command)
        {
            await Dispatcher.SendAsync(command);
            return NoContent();
        }

        [HttpPost()]
        [Route("IntegrateVolumes")]
        [SwaggerOperation("Integrate Volumes")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(IntegrateVolumeDataFile command)
        {
            await Dispatcher.SendAsync(command);
            return NoContent();
        }

    }
}
