using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quantaventis.Trading.Modules.Valuation.Api.Commands;
using Quantaventis.Trading.Shared.Abstractions.Dispatchers;
using Swashbuckle.AspNetCore.Annotations;


namespace Quantaventis.Trading.Modules.Valuation.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    internal class ValuationController : Controller
    {

        private IDispatcher Dispatcher { get; }

        public ValuationController(IDispatcher dispatcher)
        {
            Dispatcher = dispatcher;

        }



        [HttpPut()]
        [Route("PortfolioValue/Update")]
        [SwaggerOperation("Update Portfolio Value")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Put(UpdatePortfolioValue command)
        {
            await Dispatcher.SendAsync(command);
            return NoContent();
        }
        [HttpPost()]
        [Route("Portfolio/ValuateAll")]
        [SwaggerOperation("Valuate All Portfolios")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(ValuateAllPortfolios command)
        {
            await Dispatcher.SendAsync(command);
            return NoContent();
        }
        [HttpPost()]
        [Route("Portfolio/Valuate")]
        [SwaggerOperation("Valuate Portfolio")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(ValuatePortfolio command)
        {
            await Dispatcher.SendAsync(command);
            return NoContent();
        }
        [HttpPost()]
        [Route("TargetAllocation/Valuate")]
        [SwaggerOperation("Valuate TargetAllocation")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(ValuateTargetAllocation command)
        {
            await Dispatcher.SendAsync(command);
            return NoContent();
        }

        [HttpPost()]
        [Route("TargetAllocation/ValuateAll")]
        [SwaggerOperation("Valuate All TargetAllocations")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(ValuateAllTargetAllocations command)
        {
            await Dispatcher.SendAsync(command);
            return NoContent();
        }
    }
}
