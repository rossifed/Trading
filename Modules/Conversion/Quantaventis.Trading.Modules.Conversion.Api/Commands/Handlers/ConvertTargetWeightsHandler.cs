using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Shared.Abstractions.Commands;
using Quantaventis.Trading.Shared.Abstractions.Commands;
using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Conversion.Api.Mappers;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Entities = Quantaventis.Trading.Modules.Conversion.Infrastructure.Entities;
using Quantaventis.Trading.Modules.Conversion.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Conversion.Api.Mappers;
using Quantaventis.Trading.Modules.Conversion.Domain;
using Quantaventis.Trading.Modules.Conversion.Domain.Model;
using Quantaventis.Trading.Modules.Conversion.Domain.Repositories;
using Quantaventis.Trading.Modules.Conversion.Api.Dto;

using Quantaventis.Trading.Modules.Conversion.Api.Mappers;
using Quantaventis.Trading.Modules.Conversion.Api.Commands;
using Quantaventis.Trading.Modules.Conversion.Domain.Services;
using Quantaventis.Trading.Modules.Conversion.Api.Events;

namespace Quantaventis.Trading.Modules.Conversion.Api.Commands.Handlers
{
    internal class ConvertTargetWeightsHandler : ICommandHandler<ConvertTargetWeights>
    {

        private IMessageBroker MessageBroker { get; }

        private ILogger<ConvertTargetWeightsHandler> Logger { get; }

        private ITargetWeightConversionService TargetWeightConversionService { get; }


        public ConvertTargetWeightsHandler(
            ITargetWeightConversionService targetWeightConversionService,
            IMessageBroker messageBroker,
            ILogger<ConvertTargetWeightsHandler> logger)
        {
            this.TargetWeightConversionService = targetWeightConversionService;

            this.MessageBroker = messageBroker;

            this.Logger = logger;
        }

     
        public async Task HandleAsync(ConvertTargetWeights command, CancellationToken cancellationToken = default)
        {

          ////  Logger.LogInformation($"Converting Target Weight for target allocation : {command.RebalancingId} ... ");

          //  IEnumerable<int> instrumentIds = command.TargetWeights.Select(x => x.InstrumentId);
          //  IEnumerable<Instrument> instruments = await InstrumentRepository.GetByIdsAsync(instrumentIds);
          //  IEnumerable<TargetWeight> targetWeights = command.TargetWeights.Map(command.PortfolioId,instruments.ToDictionary(x => x.Id));
          //  IEnumerable<TargetWeightConversion> convertedWeights = await TargetWeightConversionService.ConvertAsync(targetWeights);
                 
          //  await MessageBroker.PublishAsync(new TargetWeightsConverted(command.PortfolioId, command.RebalancingId,
          //      convertedWeights.ToDtos()));
        }

  

    }

}
