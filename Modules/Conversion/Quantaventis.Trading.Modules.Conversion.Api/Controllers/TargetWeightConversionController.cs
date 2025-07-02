using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quantaventis.Trading.Shared.Abstractions.Dispatchers;
using Quantaventis.Trading.Modules.Conversion.Api.Dto;
using Quantaventis.Trading.Modules.Conversion.Api.Commands;


namespace Quantaventis.Trading.Modules.Conversion.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    internal class TargetWeightConversionController : Controller
    {

        private  IDispatcher Dispatcher { get; }

        public TargetWeightConversionController(IDispatcher dispatcher)
        {
            Dispatcher = dispatcher;

        }
  


        [HttpPost()]
         [Route("Convert")]
        [SwaggerOperation("Convert Target Weights")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(ConvertTargetWeights command)
        {
            await Dispatcher.SendAsync(command);
            return NoContent();
        }


    }
}
