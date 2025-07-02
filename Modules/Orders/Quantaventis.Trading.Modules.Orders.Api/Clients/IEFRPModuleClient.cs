using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Orders.Api.Queries.Out;
using Quantaventis.Trading.Modules.Orders.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Modules;

namespace Quantaventis.Trading.Modules.Orders.Api.Clients
{
    internal interface IEFRPModuleClient
    {
        Task<IEnumerable<EfrpConversionInfoDto>> GetEfrpConversionInfoAsync(IEnumerable<EfrpCandidateDto> efrpCandidate);
     
    }

    internal class EFRPModuleClient : IEFRPModuleClient
    {
        private IModuleClient ModuleClient { get; }
        public EFRPModuleClient(IModuleClient moduleClient) {
            ModuleClient = moduleClient;
        }

        public async Task<IEnumerable<EfrpConversionInfoDto>> GetEfrpConversionInfoAsync(IEnumerable<EfrpCandidateDto> efrpCandidates)
        => await ModuleClient.SendAsync< IEnumerable<EfrpConversionInfoDto>>("EFRP/GetEfrpConversionInfo", new GetEfrpConversionInfo(efrpCandidates));
     
    }
}
