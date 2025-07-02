using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quantaventis.Trading.Modules.EmsGateway.Api.Dto;
using Quantaventis.Trading.Modules.EmsGateway.Api.Queries;
using Quantaventis.Trading.Modules.EmsGateway.Api.Commands;
using Quantaventis.Trading.Shared.Abstractions.Dispatchers;
using Swashbuckle.AspNetCore.Annotations;
using Quantaventis.Trading.Modules.EmsGateway.Api.Commands.Handlers;
using Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.Requests;
using Quantaventis.Trading.Modules.EmsGateway.Api.Queries.In;

namespace Quantaventis.Trading.Modules.EmsGateway.Api.Controllers
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

        [HttpPost()]
        [Route("EmsxOrder/CancelBasket")]
        [SwaggerOperation("Cancel EMSX Basket Orders")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CancelEmsxBasketOrders([FromBody] CancelEmsxBasket command)
        {
            await Dispatcher.SendAsync(command);
            return NoContent();
        }



        [HttpPost()]
        [Route("EmsxOrder/Cancel")]
        [SwaggerOperation("Cancel EMSX Order")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CancelEmsxOrder([FromBody] CancelEmsxOrderByRebalId command)
        {
            await Dispatcher.SendAsync(command);
            return NoContent();
        }



        [HttpPost()]
        [Route("EmsxOrder/CreateBasket")]
        [SwaggerOperation("Create EMSX Basket")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateEmsxBasket([FromBody] CreateEmsxBasket command)
        {
            await Dispatcher.SendAsync(command);
            return NoContent();
        }

     


        [HttpPost()]
        [Route("EmsxOrder/RouteBasket")]
        [SwaggerOperation("Route EMSX Basket")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> RouteEmsxBasket([FromBody] RouteEmsxBasketOrders command)
        {
            await Dispatcher.SendAsync(command);
            return NoContent();
        }

        [HttpPost()]
        [Route("EmsxOrder/Route")]
        [SwaggerOperation("Route EMSX Orders")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> RouteEmsxOrders([FromBody] RouteEmsxOrders command)
        {
            await Dispatcher.SendAsync(command);
            return NoContent();
        }

        [HttpPost()]
        [Route("EmsxOrder/CancelByRebalId")]
        [SwaggerOperation("Cancel EMSX Orders By RebalancingId")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> RouteEmsxOrders([FromBody] CancelEmsxOrderByRebalId command)
        {
            await Dispatcher.SendAsync(command);
            return NoContent();
        }

        [HttpPost()]
        [Route("EmsxOrder/Reconnect")]
        [SwaggerOperation("Reconnect to EMSX")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> ReconnectSync()
        {
            await Dispatcher.SendAsync(new TriggerEmsxOrdersSync());
            return NoContent();
        }

        [HttpPost()]
        [Route("EmsxOrder/TriggerSync")]
        [SwaggerOperation("Trigger EMSX Orders Sync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> TriggerEmsxOrdersSync()
        {
            await Dispatcher.SendAsync(new TriggerEmsxOrdersSync());
            return NoContent();
        }



        [HttpGet()]
        [Route("EMSXBasket/GetAll")]
        [SwaggerOperation("Get All Baskets")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<string>>> GetAllBasketsAsync()
        => Ok(await Dispatcher.QueryAsync(new GetAllBaskets()));

        [HttpGet()]
        [Route("EmsxOrder/GetAll")]
        [SwaggerOperation("Get All EMSX Orders")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EmsxOrderDto>>> GetAllEmsxOrdersAsync()
        => Ok(await Dispatcher.QueryAsync(new GetAllEmsxOrders()));

        [HttpGet()]
        [Route("EmsxOrder/GetByBasket")]
        [SwaggerOperation("Get EMSX Orders By Basket")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EmsxOrderDto>>> GetBasketOrdersAsync(string basketName)
            => Ok(await Dispatcher.QueryAsync(new GetBasketOrders(basketName)));

        [HttpGet()]
        [Route("EmsxOrder/GetByStatus")]
        [SwaggerOperation("Get EMSX Orders By Status")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EmsxOrderDto>>> GetEmsxOrdersByStatusAsync(string status)
          => Ok(await Dispatcher.QueryAsync(new GetEmsxOrdersByStatus(status)));



        [HttpGet()]
        [Route("EmsxOrder/GetByRefIds")]
        [SwaggerOperation("Get EMSX Orders")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EmsxOrderDto>>> GetEmsxOrdersByRefIdAsync([FromBody]GetEmsxOrdersByRefId query)
            => Ok(await Dispatcher.QueryAsync(query));

        [HttpGet()]
        [Route("EmsxOrder/GetCancelled")]
        [SwaggerOperation("Get Cancelled EMSX Orders")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EmsxOrderDto>>> GetCancelledEmsxOrdersAsync()
                => Ok(await Dispatcher.QueryAsync(new GetCancelledEmsxOrders()));

        [HttpGet()]
        [Route("EmsxOrder/GetWorking")]
        [SwaggerOperation("Get Working EMSX Orders")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EmsxOrderDto>>> GetWorkingEmsxOrdersAsync()
          => Ok(await Dispatcher.QueryAsync(new GetWorkingEmsxOrders()));

        [HttpGet()]
        [Route("EmsxOrder/GetFilled")]
        [SwaggerOperation("Get Filled EMSX Orders")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EmsxOrderDto>>> GetFilledEmsxOrdersAsync(bool includePartialFill)
          => Ok(await Dispatcher.QueryAsync(new GetFilledEmsxOrders(includePartialFill)));
    }
}
