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

    internal class FutureContractChainPublisher : IContractChainsPublisher
    {
        private IGenericFutureDao GenericFutureDao { get; }
        private IFutureContractDao FutureContractDao { get; }

        private IMessageBroker MessageBroker { get; }

        public FutureContractChainPublisher(IGenericFutureDao genericFutureDao,
            IFutureContractDao futureContractDao,
            IMessageBroker messageBroker)
        {
            GenericFutureDao = genericFutureDao;
            FutureContractDao = futureContractDao;
            MessageBroker = messageBroker;
        }

        public async Task PublishContractChainsAsync()
        {
            IEnumerable<GenericFuture> genericFutures = await GenericFutureDao.GetAllAsync();
            foreach (GenericFuture genericFuture in genericFutures)
            {
                await PublishContractChainAsync(genericFuture);
            }
        }


        internal async Task PublishContractChainAsync(GenericFuture genericFuture)
        {
            IEnumerable<FutureContract> futureContracts = await FutureContractDao.GetByGenericFutureIdAsync(genericFuture.GenericFutureId);
            if (futureContracts.Any())
            {
                GenericFutureDto genericFutureDto = genericFuture.Map();
                IEnumerable<FutureContractDto> futureContractDtos = futureContracts.Map();
                await MessageBroker.PublishAsync(new FutureContractChainSync(genericFutureDto, futureContractDtos));
            }
        }
    }
}
