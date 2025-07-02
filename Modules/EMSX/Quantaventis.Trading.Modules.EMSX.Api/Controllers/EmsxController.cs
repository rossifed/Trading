using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.DTO;
using Quantaventis.Trading.Modules.EMSX.Api.Queries.In;
using Quantaventis.Trading.Shared.Abstractions.Dispatchers;
using Swashbuckle.AspNetCore.Annotations;
using Quantaventis.Trading.Modules.EMSX.Api.Dto;
using Quantaventis.Trading.Modules.EMSX.Api.Commands.In;

namespace Quantaventis.Trading.Modules.EMSX.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    internal class EmsxController : Controller
    {

        private  IDispatcher Dispatcher { get; }

        public EmsxController(IDispatcher dispatcher)
        {
            Dispatcher = dispatcher;

        }

        [HttpGet()]
        [Route("Status")]
        [SwaggerOperation("Get Connection Status")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EmsxFillDto>>> GetConnectionStatusAsync()
            => Ok(await Dispatcher.QueryAsync(new GetSessionStatus()));



        [HttpGet()]
        [Route("GetFillsByOrderId")]
        [SwaggerOperation("Get Emsx Fills by Order Id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EmsxFillDto>>> GetEmsxFillsByOrderId(GetEmsxFillsByOrderId request)
            => Ok(await Dispatcher.QueryAsync(request));


        [HttpPut()]
        [Route("Reconnect")]
        [SwaggerOperation("Reconnect to EMSX API")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Reconnect()
        {
            await Dispatcher.SendAsync(new Reconnect());
            return NoContent();
        }

        [HttpPut()]
        [Route("ModifyOrder")]
        [SwaggerOperation("Modify Order")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> ModifyOrder(ModifyOrder command )
        { 
          await Dispatcher.SendAsync(command);
            return NoContent();
        }

        [HttpPut()]
        [Route("FetchFills")]
        [SwaggerOperation("Fetch Fills")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> FetchFillsByDate(FetchFillsByDate command)
        {
            await Dispatcher.SendAsync(command);
            return NoContent();
        }
        [HttpPut()]
        [Route("AssignTrader")]
        [SwaggerOperation("Assign Trader")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AssignTrade(AssignTrader command)
        {
            await Dispatcher.SendAsync(command);
            return NoContent();
        }

        [HttpPut()]
        [Route("CancelOrders")]
        [SwaggerOperation("Cancel Orders")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CancelOrder(CancelOrders command)
        {
            await Dispatcher.SendAsync(command);
            return NoContent();
        }

        [HttpPut()]
        [Route("CancelRoutes")]
        [SwaggerOperation("Cancel Routes")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CancelRoute(CancelRoutes command)
        {
            await Dispatcher.SendAsync(command);
            return NoContent();
        }


        [HttpPost()]
        [Route("CreateBasket")]
        [SwaggerOperation("Create Basket")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateBasket(CreateBasket command)
        {
            await Dispatcher.SendAsync(command);
            return NoContent();
        }


        [HttpPost()]
        [Route("CreateOrders")]
        [SwaggerOperation("Create Orders")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateOrder(CreateOrders command)
        {
            await Dispatcher.SendAsync(command);
            return NoContent();
        }

        [HttpDelete()]
        [Route("DeleteOrders")]
        [SwaggerOperation("Delete Orders")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteOrder(DeleteOrders command)
        {
            await Dispatcher.SendAsync(command);
            return NoContent();
        }


        [HttpPut()]
        [Route("RouteOrders")]
        [SwaggerOperation("Route Orders")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> RouteOrder(RouteOrders command)
        {
            await Dispatcher.SendAsync(command);
            return NoContent();
        }
    }
}
