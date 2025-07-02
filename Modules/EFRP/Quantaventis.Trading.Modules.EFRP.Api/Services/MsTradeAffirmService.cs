using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EFRP.Domain.Model;
using Quantaventis.Trading.Modules.EFRP.Infrastructure.Dto;
using Quantaventis.Trading.Modules.EFRP.Infrastructure.Services;
using Quantaventis.Trading.Modules.EFRP.Api.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Quantaventis.Trading.Modules.EFRP.Domain.Services;
using Quantaventis.Trading.Modules.EFRP.Domain.Repositories;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Modules.EFRP.Api.Events.Out;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.EntityFrameworkCore;

namespace Quantaventis.Trading.Modules.EFRP.Api.Services
{
    internal interface IMsTradeAffirmService {

        Task OnMsTradeAffirmFile(byte portfolioId, string tradeFilePath);
    }
    internal class MsTradeAffirmService : IMsTradeAffirmService
    {
        private IMsTradeAffirmFileReader MsTradeAffirmFileReader { get; }
        private IEfrpDealAggregator EfrpDealAggregator { get; }

     private IFutureContractRepository FutureContractRepository { get; }
        private IMessageBroker MessageBroker { get; }
        private ILogger<MsTradeAffirmService> Logger { get; }

        public MsTradeAffirmService(IMsTradeAffirmFileReader msTradeAffirmFileReader, 
            IEfrpDealAggregator efrpDealAggregator, 
            IFutureContractRepository futureContractRepository,
            IMessageBroker messageBroker,
            ILogger<MsTradeAffirmService> logger)
        {
            MsTradeAffirmFileReader = msTradeAffirmFileReader;
            EfrpDealAggregator = efrpDealAggregator;
            FutureContractRepository = futureContractRepository;
            MessageBroker = messageBroker;
            Logger = logger;
        }

        public async Task OnMsTradeAffirmFile(byte portfolioId, string tradeFilePath)
        {
            Logger.LogInformation($"Processing MsTradeAffirmFile {tradeFilePath}");

            IEnumerable<TradeAffirmFutureItem> items = await MsTradeAffirmFileReader.ReadTradeAffirmFutureItemsAsync(tradeFilePath);
            Logger.LogInformation($"{items.Count()} Futures items found in {tradeFilePath}");



            IEnumerable<EfrpTrade> efrpTrades = await ProcessTradeAffirmFutureItem(items);
            await  PublishEfrpTradeExecutedEvents(portfolioId, efrpTrades);
        }

        private async Task<IEnumerable<EfrpTrade>> ProcessTradeAffirmFutureItem(IEnumerable<TradeAffirmFutureItem> items) {
          

            IEnumerable<EfrpDeal> efrpDeals = await GenerateEfrpDeal(items);
          

            IEnumerable<EfrpTrade> efrpTrades = EfrpDealAggregator.Aggregate(efrpDeals);
            return efrpTrades;
        }


        private async Task<IEnumerable<EfrpDeal>> GenerateEfrpDeal(IEnumerable<TradeAffirmFutureItem> items)
        {
            IEnumerable<FutureContract> futureContracts = await FutureContractRepository.GetAllAsync();
            IDictionary<string, FutureContract> futureContractDic = futureContracts.ToDictionary(x => x.Symbol);
            FutureContract GetfutureContrac(string bloombergSymbol)
            {
                if (futureContractDic.ContainsKey(bloombergSymbol))
                {
                    return futureContractDic[bloombergSymbol];
                }
                else
                {
                    throw new InvalidOperationException($"No FutureContract found for symbol {bloombergSymbol}");
                }
            }

            return items.Select(x => x.ToEfrpDeal(GetfutureContrac));
            
        }

        private async Task PublishEfrpTradeExecutedEvents(byte portfolioId, IEnumerable<EfrpTrade> efrpTrades) {
            foreach (var EfrpTrade in efrpTrades) {
               await  MessageBroker.PublishAsync(new EfrpTradeReceived(portfolioId, EfrpTrade.Map()));
            }
        
        }
    }
}
