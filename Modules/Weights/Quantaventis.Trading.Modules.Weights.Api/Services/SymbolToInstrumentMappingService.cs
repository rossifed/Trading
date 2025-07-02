using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Weights.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Weights.Infrastructure.Entities;
using Quantaventis.Trading.Modules.Weights.Api.Exceptions;
using Quantaventis.Trading.Modules.Weights.Api.Clients;
using Quantaventis.Trading.Modules.Weights.Api.Dto;

namespace Quantaventis.Trading.Modules.Weights.Api.Services
{
    internal interface ISymbolToInstrumentMappingService
    {
        Task<IDictionary<string, Instrument>> MapAsync(IEnumerable<string> symbols);
    }
    internal class SymbolToInstrumentMappingService : ISymbolToInstrumentMappingService
    {
        private IInstrumentDao InstrumentDao { get; }
        private static string CleanSymbol(string ticker)
        {
            List<string> yellowkeys = new List<string>() { "Index", "Equity", "Curncy", "Comdty" };
            var result = ticker;
            yellowkeys.ToList().ForEach(x => result = result.Replace(x.ToLower(), x));
            return result;
        }
        public SymbolToInstrumentMappingService(IInstrumentDao instrumentDao)
        {
            this.InstrumentDao = instrumentDao;
        }
        public async Task<IDictionary<string, Instrument>> MapAsync(IEnumerable<string> symbols)
        {
            var cleanSymbols = symbols.Select(x => CleanSymbol(x));
            IEnumerable <Instrument> instruments = await this.InstrumentDao.GetBySymbolsAsync(cleanSymbols.Select(x => CleanSymbol(x)));

            IEnumerable<string> unmappedSymbols = cleanSymbols.Except(instruments.Select(x => x.Symbol));

            if (unmappedSymbols.Any())
            {
               //TODO: throw new SymbolNotFoundException(unmappedSymbols);
            }
            return instruments.ToDictionary(x => x.Symbol);
        }
    }
}
