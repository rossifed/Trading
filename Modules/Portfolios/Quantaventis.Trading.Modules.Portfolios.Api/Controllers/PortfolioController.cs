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
    internal class PortfolioController : Controller
    {

        private  IDispatcher Dispatcher { get; }

        public PortfolioController(IDispatcher dispatcher)
        {
            Dispatcher = dispatcher;

        }
        [HttpPost()]
        [Route("TriggerSync")]
        [SwaggerOperation("Trigger Sync Portfolios Event")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> TriggerSyncEvent(TriggerPortfolioSyncEvent command)
        {
            await Dispatcher.SendAsync(command);
            return NoContent();
        }

        [HttpPost()]
        [Route("Create")]
        [SwaggerOperation("Create Portfolio")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create(CreatePortfolio command)
        {
            await Dispatcher.SendAsync(command);
            return NoContent();
        }

        [HttpGet()]
        [Route("GetAll")]
        [SwaggerOperation("Get All Portfolios")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PortfolioDto>>> GetAllAsync()
        => Ok(await Dispatcher.QueryAsync<IEnumerable<PortfolioDto>>(new GetAllPortfolios()));
    }
}
