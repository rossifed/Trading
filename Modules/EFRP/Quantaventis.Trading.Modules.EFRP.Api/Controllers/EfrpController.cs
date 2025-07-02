using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quantaventis.Trading.Modules.EFRP.Api.Commands;
using Quantaventis.Trading.Modules.EFRP.Api.Dto;
using Quantaventis.Trading.Modules.EFRP.Api.Queries.In;
using Quantaventis.Trading.Shared.Abstractions.Dispatchers;
using Swashbuckle.AspNetCore.Annotations;

namespace Quantaventis.Trading.Modules.EFRP.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    internal class EfrpController : Controller
    {

        private  IDispatcher Dispatcher { get; }

        public EfrpController(IDispatcher dispatcher)
        {
            Dispatcher = dispatcher;

        }


   

        [HttpPost()]
        [Route("GetEfrpConversionInfos")]
        [SwaggerOperation("Get Efrp Conversion Infos")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EfrpConversionInfoDto>>> GetEfrpConversionInfos([FromQuery] IEnumerable<EfrpCandidateDto> efrpCandidates)
        => Ok(await Dispatcher.QueryAsync(new GetEfrpConversionInfo(efrpCandidates)));


        [HttpPost()]
        [Route("Import/MsTradeAffirm")]
        [SwaggerOperation("Import MS EFRP Trades")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> ImportEfrpTrades(ImportMsTradeAffirm command)
        {
            await Dispatcher.SendAsync(command);
            return NoContent();
        }

    }
}
