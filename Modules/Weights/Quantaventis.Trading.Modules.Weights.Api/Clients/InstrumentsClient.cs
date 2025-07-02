using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Weights.Api.Queries.Out;
using Quantaventis.Trading.Modules.Weights.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Modules;

namespace Quantaventis.Trading.Modules.Weights.Api.Clients
{
    internal interface IInstrumentsClient
    {

        Task<IEnumerable<InstrumentDto>> GetInstrumentsBySymbolAsync(IEnumerable<string> symbols);
    }

        internal class InstrumentsClient : IInstrumentsClient
        {
            private IModuleClient ModuleClient { get; }
            public InstrumentsClient(IModuleClient moduleClient)
            {
                ModuleClient = moduleClient;
            }


            public async Task<IEnumerable<InstrumentDto>> GetInstrumentsBySymbolAsync(IEnumerable<string> symbols)
                  => await ModuleClient.SendAsync<IEnumerable<InstrumentDto>>("Instrument/GetBySymbols", new GetInstruments(symbols));
        }
    }

