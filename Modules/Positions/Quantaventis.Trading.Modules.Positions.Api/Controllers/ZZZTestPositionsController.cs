using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quantaventis.Trading.Modules.Positions.Api.Commands.In;
using Quantaventis.Trading.Modules.Positions.Api.Dto;
using Quantaventis.Trading.Modules.Positions.Api.Queries.In;
using Quantaventis.Trading.Shared.Abstractions.Dispatchers;
using Swashbuckle.AspNetCore.Annotations;

namespace Quantaventis.Trading.Modules.Positions.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    internal class ZZZTestPositionsController : Controller
    {

        private  IDispatcher Dispatcher { get; }

        public ZZZTestPositionsController(IDispatcher dispatcher)
        {
            Dispatcher = dispatcher;

        }

        // Interface with the strategies execution world. TODO: Should not be based on files
        [HttpGet()]
        [Route("Positions/GetLastByPortfolioId")]
        [SwaggerOperation("Get Last Positions by Portfolio Id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PositionDto>>> GetLastByPortfolioId(byte portfolioId)
        {
               return Ok(await Dispatcher.QueryAsync(new GetLastByPortfolioId(portfolioId)));
          
        }

        [HttpGet()]
        [Route("Positions/GetByPortfolioIdAsOf")]
        [SwaggerOperation("Get Positions by Portfolio Id as of date")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PositionDto>>> GetByPortfolioIdAsOf(byte portfolioId, DateOnly afOfDate)
        {
            return Ok(await Dispatcher.QueryAsync(new GetByPortfolioIdAsOf(portfolioId, afOfDate)));

        }


        //[HttpPost()]
        //[Route("Position/ComputeAllFromInception")]
        //[SwaggerOperation("Compute All Positions from Inception")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult> ComputeAllFromInception(ComputeAllPositionsFromInception command)
        //{
        //    await Dispatcher.SendAsync(command);
        //    return NoContent();
        //}
        [HttpPost()]
        [Route("Positions/ComputeDailyPositions")]
        [SwaggerOperation("Compute All Positions from Date")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> ComputeDailyPositions(ComputeMissingPositions command)
        {
            await Dispatcher.SendAsync(command);
            return NoContent();
        }

        [HttpPost()]
        [Route("Positions/ComputeAllFromDate")]
        [SwaggerOperation("Compute All Positions from Date")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> ComputeAllFromDate(ComputeAllPositionsFromDate command)
        {
            await Dispatcher.SendAsync(command);
            return NoContent();
        }


        [HttpPost()]
        [Route("Positions/ComputePositionsFromDate")]
        [SwaggerOperation("Compute Positions of a given instrument from date")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> ComputeAllFromDate(ComputePositionsFromDate command)
        {
            await Dispatcher.SendAsync(command);
            return NoContent();
        }

        [HttpPost()]
        [Route("Positions/ComputePositionsFromInception")]
        [SwaggerOperation("Compute Positions of a given instrument from inception")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> ComputeAllFromInception(ComputePositionsFromInception command)
        {
            await Dispatcher.SendAsync(command);
            return NoContent();
        }
    }
}
