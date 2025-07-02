using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quantaventis.Trading.Modules.Pricing.Api.Commands;
using Quantaventis.Trading.Shared.Abstractions.Dispatchers;
using Swashbuckle.AspNetCore.Annotations;
namespace Quantaventis.Trading.Modules.Rolling.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    internal class RollingController : Controller
    {

        private  IDispatcher Dispatcher { get; }

        public RollingController(IDispatcher dispatcher)
        {
            Dispatcher = dispatcher;

        }


        [HttpPost()]
        [Route("Positions/GenerateRollovers")]
        [SwaggerOperation("Genearte Positions Rollovers")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(GeneratePositionRollovers command)
        {
            await Dispatcher.SendAsync(command);
            return NoContent();
        }

   
    }
}
