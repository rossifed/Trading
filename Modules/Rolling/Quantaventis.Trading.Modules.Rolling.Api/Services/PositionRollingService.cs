using Quantaventis.Trading.Modules.Rolling.Api.Events.Out;
using Quantaventis.Trading.Modules.Rolling.Api.Mappers;
using Quantaventis.Trading.Modules.Rolling.Domain.Model;
using Quantaventis.Trading.Modules.Rolling.Domain.Repositories;
using Quantaventis.Trading.Shared.Abstractions.Messaging;

namespace Quantaventis.Trading.Modules.Rolling.Domain.Services
{
    interface IPositionRollingService
    {
        Task GenerateRolloversAsync();
    }

    internal  class PositionRollingService : IPositionRollingService
    {

        private IPositionRepository PositionRepository { get; }

        private IContractRollInfoRepository ContractRollInfoRepository { get; }
        private IMessageBroker MessageBroker { get; }
        private IPositionRolloverGenerator PositionRolloverGenerator { get; }

        public PositionRollingService(IPositionRepository positionRepository, 
            IContractRollInfoRepository contractRollInfoRepository,
            IPositionRolloverGenerator positionRolloverGenerator,
            IMessageBroker messageBroker
            )
        {
            PositionRepository = positionRepository;
            ContractRollInfoRepository = contractRollInfoRepository;
            MessageBroker = messageBroker;
            PositionRolloverGenerator = positionRolloverGenerator;
        }

        public async Task GenerateRolloversAsync()
        {
            IEnumerable<Position> positions = await PositionRepository.GetAllAsync();

            IEnumerable<ContractRollInfo> contractRollInfos = await ContractRollInfoRepository.GetAllAsync();

            IEnumerable<PositionRollover> rollovers = PositionRolloverGenerator.GenerateRollovers(positions, contractRollInfos);

            await MessageBroker.PublishAsync(new PositionRolloversGenerated(rollovers.Map()));//TODO: to be extracted in domain service
        }

    }
}
