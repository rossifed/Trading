using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quantaventis.Trading.Shared.Abstractions.Dispatchers;
using Swashbuckle.AspNetCore.Annotations;
using Quantaventis.Trading.Modules.Orders.Api.Commands;
namespace Quantaventis.Trading.Modules.Orders.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    internal class OrderController : Controller
    {

        private  IDispatcher Dispatcher { get; }

        public OrderController(IDispatcher dispatcher)
        {
            Dispatcher = dispatcher;

        }

      

        [HttpPost()]
        [Route("Order/RouteByRebalId")]
        [SwaggerOperation("Route Orders By RebalId")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> RouteOrdersByRebalId(int rebalancingSessionId)
        {
            await Dispatcher.SendAsync(new RouteOrdersByRebalId(rebalancingSessionId));
            return NoContent();
        }

    }
}
