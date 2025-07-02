using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Instruments.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Commands;
using Quantaventis.Trading.Shared.Abstractions.Messaging;

namespace Quantaventis.Trading.Modules.Instruments.Api.Commands.Handlers
{
    internal class PublishContractChainsSyncHandler : ICommandHandler<PublishContractChainsSync>
    {


        private IEnumerable<IContractChainsPublisher> ContractChainsPublishers { get; }





        public PublishContractChainsSyncHandler(
           IEnumerable<IContractChainsPublisher> contractChainsPublishers)
        {
            this.ContractChainsPublishers = contractChainsPublishers;

        }


        public async Task HandleAsync(PublishContractChainsSync command, CancellationToken cancellationToken = default)
        {
            foreach (IContractChainsPublisher contractChainsPublisher in ContractChainsPublishers) {

                await contractChainsPublisher.PublishContractChainsAsync();
            }

        }

    }

}
