using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quantaventis.Trading.Modules.Weights.Api.Commands;
using Quantaventis.Trading.Shared.Abstractions.Dispatchers;
using Swashbuckle.AspNetCore.Annotations;

namespace Quantaventis.Trading.Modules.Weights.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    internal class TargetAllocationController : Controller
    {

        private  IDispatcher Dispatcher { get; }

        public TargetAllocationController(IDispatcher dispatcher)
        {
            Dispatcher = dispatcher;

        }
     


        // Interface with the strategies execution world. TODO: Should not be based on files
        [HttpPost()]
        [Route("Generate")]
        [SwaggerOperation("Generate Target Allocation for given Portfolio")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(GenerateTargetAllocation command)
        {
            await Dispatcher.SendAsync(command);
            return NoContent();
        }
        // Interface with the strategies execution world. TODO: Should not be based on files
        [HttpPost()]
        [Route("GenerateFromFile")]
        [SwaggerOperation("Generate Target Allocation Specifying the file")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(GenerateTargetAllocationFromFile command)
        {
            await Dispatcher.SendAsync(command);
            return NoContent();
        }


    }
}
