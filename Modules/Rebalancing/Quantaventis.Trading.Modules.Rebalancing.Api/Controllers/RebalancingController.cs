using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quantaventis.Trading.Shared.Abstractions.Dispatchers;
using Quantaventis.Trading.Modules.Rebalancing.Api.Dto;
using Quantaventis.Trading.Modules.Rebalancing.Api.Commands;
using Quantaventis.Trading.Modules.Rebalancing.Api.Queries.In;

namespace Quantaventis.Trading.Modules.Rebalancing.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    internal class RebalancingController : Controller
    {

        private  IDispatcher Dispatcher { get; }

        public RebalancingController(IDispatcher dispatcher)
        {
            Dispatcher = dispatcher;

        }

        // Interface with the strategies execution world. TODO: Should not be based on files
        [HttpGet()]
        [Route("Rebalancing/GetById")]
        [SwaggerOperation("Get Rebalancing Session By Id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RebalancingSessionDto>> GetbyId(int  rebalancingSessionId)
        {
               return Ok(await Dispatcher.QueryAsync(new GetRebalancingSessionById(rebalancingSessionId)));
          
        }
        // Interface with the strategies execution world. TODO: Should not be based on files
        [HttpPost()]
        [Route("Rebalancing/ForceCancel")]
        [SwaggerOperation("Force Cancel  (!!! To be used only if all the pending orders have been cancelled)")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> ConfirmRebalancingCancelled(ForceCancel command)
        {
            await Dispatcher.SendAsync(command);
            return NoContent();
        }
        // Interface with the strategies execution world. TODO: Should not be based on files
        [HttpPost()]
        [Route("Rebalancing/Cancel")]
        [SwaggerOperation("Trigger Rebalancing Cancellation Process")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CancelRebalancing(CancelRebalancing command)
        {
            await Dispatcher.SendAsync(command);
            return NoContent();
        }

        // Interface with the strategies execution world. TODO: Should not be based on files
        [HttpPost()]
        [Route("Rebalancing/Start")]
        [SwaggerOperation("Start Rebalancing Session")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> StartRebalancing(StartRebalancing command)
        {
            await Dispatcher.SendAsync(command);
            return NoContent();
        }
    }
}
