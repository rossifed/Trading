using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quantaventis.Trading.Shared.Abstractions.Dispatchers;
using Quantaventis.Trading.Modules.Instruments.Api.Dto;
using Quantaventis.Trading.Modules.Instruments.Api.Commands;
using Quantaventis.Trading.Modules.Instruments.Api.Queries.In;

namespace Quantaventis.Trading.Modules.Instruments.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    internal class InstrumentController : Controller
    {

        private  IDispatcher Dispatcher { get; }

        public InstrumentController(IDispatcher dispatcher)
        {
            Dispatcher = dispatcher;

        }


        [HttpPost()]
        [Route("IntegrateReftData")]
        [SwaggerOperation("Integrate ReftData")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(IntegrateRefDataFile command)
        {
            await Dispatcher.SendAsync(command);
            return NoContent();
        }


        [HttpPost()]
        [Route("UploadInstruments")]
        [SwaggerOperation("Upload Instruments")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(UploadInstruments command)
        {
            await Dispatcher.SendAsync(command);
            return NoContent();
        }


        [HttpPost()]
        [Route("PublishContractChains")]
        [SwaggerOperation("Publish Contract Chains")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(PublishContractChainsSync command)
        {
            await Dispatcher.SendAsync(command);
            return NoContent();
        }

        //[HttpGet()]
        //[Route("GetBySymbols")]
        //[SwaggerOperation("Get Instruments")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult<IEnumerable<InstrumentDto>>> GetBySymbolsAsync([FromQuery]IEnumerable<string> symbols)
        //=> Ok(await Dispatcher.QueryAsync(new GetInstrumentsBySymbols(symbols)));

        //[HttpGet()]
        //[Route("GetAll")]
        //[SwaggerOperation("Get All Instruments")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult<IEnumerable<InstrumentDto>>> GetAllAsync()
        //    => Ok(await Dispatcher.QueryAsync(new GetAllInstruments()));
    }
}
