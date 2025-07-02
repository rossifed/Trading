using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quantaventis.Trading.Shared.Abstractions.Dispatchers;
using Swashbuckle.AspNetCore.Annotations;
using Quantaventis.Trading.Modules.Transmission.Api.Commands;
using Quantaventis.Trading.Modules.Orders.Api.Commands;

namespace Quantaventis.Trading.Modules.Transmission.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    internal class TransmissionController : Controller
    {

        private  IDispatcher Dispatcher { get; }

        public TransmissionController(IDispatcher dispatcher)
        {
            Dispatcher = dispatcher;

        }

      

        [HttpPost()]
        [Route("Transmission/GenerateAndTransmit")]
        [SwaggerOperation("Generate And Transmit")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GenerateAndTransmit(int transmissionProfileId)
        {
            await Dispatcher.SendAsync(new GenerateAndTransmit(transmissionProfileId));
            return NoContent();
        }
        [HttpPost()]
        [Route("Transmission/GenerateAndTransmitAll")]
        [SwaggerOperation("Generate And Transmit All Files")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GenerateAndTransmitAll([FromQuery]bool forceEod = false)
        {
            await Dispatcher.SendAsync(new GenerateAndTransmitAll(forceEod));
            return NoContent();
        }
    }
}
