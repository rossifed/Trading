using Quantaventis.Trading.Modules.Conversion.Domain.Model;
using Quantaventis.Trading.Modules.Conversion.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Conversion.Domain.Services
{
    internal interface ITargetWeightConversionService {
        Task<IEnumerable<TargetWeightConversion>> ConvertAsync(IEnumerable<TargetWeight> targetWeights);
    }
    internal class TargetWeightConversionService : ITargetWeightConversionService
    {
        private IContractConversionRuleRepository ContractConversionRuleRepository { get; }

        public TargetWeightConversionService(IContractConversionRuleRepository contractConversionRuleRepository)
        {
            ContractConversionRuleRepository = contractConversionRuleRepository;
        }

        private async Task<IEnumerable<TargetWeightConversion>> ConvertAsync(PortfolioId portfolioId,IEnumerable<TargetWeight> targetWeights) {
            IEnumerable<IContractConversionRule> conversionRules = await ContractConversionRuleRepository.GetByPortfolioIdAsync(portfolioId);
            IDictionary<Instrument, TargetWeightConversion> convertedWeights = new Dictionary<Instrument, TargetWeightConversion>();
            foreach (TargetWeight TargetWeight in targetWeights)
            {

                Instrument instrument = TargetWeight.Instrument;
                foreach (IContractConversionRule conversionRule in conversionRules)
                {
                    if (conversionRule.ApplyTo(TargetWeight))
                    {

                        if (convertedWeights.ContainsKey(instrument))
                            throw new InvalidOperationException($"The instrument {instrument} has already been converted.");
                    
                            TargetWeightConversion targetWeightConversion = conversionRule.Apply(TargetWeight);
                            convertedWeights.Add(TargetWeight.Instrument, targetWeightConversion);                                        
                    }
                }             
            }

          var delta =  targetWeights.Select(x => x.Instrument).Except(convertedWeights.Keys);
            if (convertedWeights.Keys.Count() != targetWeights.Count())
                throw new Exception($"Converted Weights number mismatch the number of target weights. {convertedWeights.Keys.Count()}<>{targetWeights.Count()}");

            return convertedWeights.Values;
        }
        public async Task<IEnumerable<TargetWeightConversion>> ConvertAsync(IEnumerable<TargetWeight> targetWeights)
        {
          ILookup<PortfolioId, TargetWeight> lookup =  targetWeights.ToLookup(x => x.PortfolioId);
          IEnumerable<Task<IEnumerable<TargetWeightConversion>>> tasks = lookup.Select(async x => await ConvertAsync(x.Key,x));
          IEnumerable<TargetWeightConversion>[] results =  await Task.WhenAll(tasks);
          return results.SelectMany(x => x);
        }
    }
  }

