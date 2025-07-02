using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quantaventis.Trading.Shared.Abstractions.Dispatchers;
using Swashbuckle.AspNetCore.Annotations;
using Quantaventis.Trading.Modules.Orders.Api.Commands;
namespace Quantaventis.Trading.Modules.Orders.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    internal class BrokerController : Controller
    {

        private  IDispatcher Dispatcher { get; }

        public BrokerController(IDispatcher dispatcher)
        {
            Dispatcher = dispatcher;

        }
  


        //[HttpPut()]
        // [Route("Route")]
        //[SwaggerOperation("Route Orders")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult> Put(RouteOrders command)
        //{
        //    await Dispatcher.SendAsync(command);
        //    return NoContent();
        //}

    }
}
