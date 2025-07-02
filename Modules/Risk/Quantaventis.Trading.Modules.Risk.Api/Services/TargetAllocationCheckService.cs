using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Risk.Api.Events;
using Quantaventis.Trading.Modules.Risk.Api.Events.Handlers;
using Quantaventis.Trading.Modules.Risk.Domain.Model;
using Quantaventis.Trading.Modules.Risk.Domain.Model.Constraints;
using Quantaventis.Trading.Modules.Risk.Domain.Repositories;
using Quantaventis.Trading.Modules.Risk.Infrastructure.Repositories;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Quantaventis.Trading.Modules.Risk.Api.Services
{
    internal interface ITargetAllocationCheckService {
        Task CheckConstraintsAsync(TargetAllocation targetAllocation);
    }
    internal class TargetAllocationCheckService : ITargetAllocationCheckService
    {
        private IConstraintRepository ConstraintRepository { get; }
        private IMessageBroker MessageBroker { get; }
        private ITargetAllocationCheckRepository TargetAllocationCheckRepository { get; }
        private ILogger<TargetAllocationGeneratedHandler> Logger { get; }

        public TargetAllocationCheckService(
            IConstraintRepository constraintRepository, 
            IMessageBroker messageBroker, 
            ITargetAllocationCheckRepository targetAllocationCheckRepository, 
            ILogger<TargetAllocationGeneratedHandler> logger)
        {
            ConstraintRepository = constraintRepository;
            MessageBroker = messageBroker;
            TargetAllocationCheckRepository = targetAllocationCheckRepository;
            Logger = logger;
        }

        public async Task CheckConstraintsAsync(TargetAllocation targetAllocation) {
            Logger.LogInformation($"Checking TargetAllocation {targetAllocation.Id} Risk Constraints... ");
            IEnumerable<Constraint> constraints = await ConstraintRepository.GetByPortfolioIdAsync(targetAllocation.PortfolioId);
            Logger.LogInformation($"{constraints.Count()} constraints found... ");
            TargetAllocationCheck targetAllocationCheck = targetAllocation.Apply(constraints);
            await TargetAllocationCheckRepository.AddAsync(targetAllocationCheck);
            Logger.LogInformation($"Target Allocation {targetAllocation.Id} Constraints Breached {targetAllocationCheck.IsBreach}... ");

            await MessageBroker.PublishAsync(new TargetAllocationChecked(targetAllocation.Id, targetAllocationCheck.IsBreach));

        }
    }
}
