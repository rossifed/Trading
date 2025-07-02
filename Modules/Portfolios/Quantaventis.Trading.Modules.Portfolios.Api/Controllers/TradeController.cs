using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quantaventis.Trading.Modules.Portfolios.Api.Commands;
using Quantaventis.Trading.Modules.Portfolios.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Dispatchers;
using Swashbuckle.AspNetCore.Annotations;
using Quantaventis.Trading.Modules.Portfolios.Api.Queries.In;
using Quantaventis.Trading.Modules.Portfolios.Api.Events.In;

namespace Quantaventis.Trading.Modules.Portfolios.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    internal class TradeController : Controller
    {

        private  IDispatcher Dispatcher { get; }

        public TradeController(IDispatcher dispatcher)
        {
            Dispatcher = dispatcher;

        }



    }
}
