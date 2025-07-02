using Quantaventis.Trading.Modules.Instruments.Infrastructure.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;
using Quantaventis.Trading.Modules.Instruments.Api.Dto;
using Quantaventis.Trading.Modules.Instruments.Api.Mappers;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Modules.Instruments.Api.Events.Out;


namespace Quantaventis.Trading.Modules.Instruments.Api.Services
{

    internal class FxForwardContractChainPublisher : IContractChainsPublisher
    {
        private ICurrencyPairDao CurrencyPairDao { get; }
        private IFxForwardDao FxForwardDao { get; }

        private IMessageBroker MessageBroker { get; }

        public FxForwardContractChainPublisher(ICurrencyPairDao currencyPairDao,
            IFxForwardDao fxForwardDao,
            IMessageBroker messageBroker)
        {
            CurrencyPairDao = currencyPairDao;
            FxForwardDao = fxForwardDao;
            MessageBroker = messageBroker;
        }

        public async Task PublishContractChainsAsync()
        {
            IEnumerable<CurrencyPair> currencyPairs = await CurrencyPairDao.GetAllAsync();
            foreach (CurrencyPair currencyPair in currencyPairs)
            {
                await PublishContractChainAsync(currencyPair);
            }
        }


        internal async Task PublishContractChainAsync(CurrencyPair currencyPair)
        {
            IEnumerable<FxForward> fxForwards = await FxForwardDao.GetByCurrencyPairIdAsync(currencyPair.CurrencyPairId);
            if (fxForwards.Any())
            {
                CurrencyPairDto currencyPairDto = currencyPair.Map();
                IEnumerable<FxForwardDto> fxForwardDtos = fxForwards.Map();
                await MessageBroker.PublishAsync(new FxForwardChainSync(currencyPairDto, fxForwardDtos));
            }
        }
    }
}
