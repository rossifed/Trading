using Quantaventis.Trading.Modules.Weights.Domain.Model;
using Quantaventis.Trading.Modules.Weights.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Weights.Domain.Services
{
    internal interface IContractConversionService {
        Task<IEnumerable<ConvertedWeight>> Convert(IEnumerable<ModelWeight> modelWeights, PortfolioId portfolioId);
    }
    internal class ContractConversionService : IContractConversionService
    {
        private IContractConversionRuleRepository ContractConversionRuleRepository { get; }

        public ContractConversionService(IContractConversionRuleRepository contractConversionRuleRepository)
        {
            ContractConversionRuleRepository = contractConversionRuleRepository;
        }
        public async Task<IEnumerable<ConvertedWeight>> Convert(IEnumerable<ModelWeight> modelWeights, PortfolioId portfolioId)
        {

            IEnumerable<IContractConversionRule> conversionRules = await ContractConversionRuleRepository.GetByPortfolioIdAsync(portfolioId);
            IDictionary<Instrument, ConvertedWeight> convertedWeights = new Dictionary<Instrument, ConvertedWeight>();

            foreach (ModelWeight modelWeight in modelWeights)
            {
                bool converted = false;
                Instrument instrument = modelWeight.Instrument;
                foreach (IContractConversionRule conversionRule in conversionRules)
                {

                    if (conversionRule.ApplyTo(modelWeight))
                    {
                       
                        if (convertedWeights.ContainsKey(instrument))
                            throw new InvalidOperationException($"The instrument {instrument} has already been converted.");
                        convertedWeights.Add(modelWeight.Instrument, conversionRule.Apply(modelWeight));
                        converted = true;
                    }

                }
                if (!converted)
                    convertedWeights.Add(instrument, new ConvertedWeight(modelWeight, modelWeight.Instrument, modelWeight.Weight));

            }
            if (convertedWeights.Keys.Count() != modelWeights.Count())
                throw new Exception($"Converted Weights number mismatch the number of model weights. {convertedWeights.Keys.Count()}<>{modelWeights.Count()}");

            return convertedWeights.Values;
        }
    }
    }

