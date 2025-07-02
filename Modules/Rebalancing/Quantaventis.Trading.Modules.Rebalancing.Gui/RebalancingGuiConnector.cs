using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Shared.Abstractions.Modules;
using Quantaventis.Trading.Modules.Rebalancing.Gui.Components;
using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Modules.Rebalancing.Gui.Dao;
using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Shared.Infrastructure;
using Quantaventis.Trading.Shared.Infrastructure.Database;
using Quantaventis.Trading.Modules.Rebalancing.Infrastructure.Entities;
using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Rebalancing.Gui
{
    internal class RebalancingGuiConnector : IModuleGuiConnector
    {

        public string Abbreviation => "RBL";

        public string Description => "Module for rebalancing management";

        public string DisplayName => "Rebalancing";

        public Type MainComponentType => typeof(RebalancingMainComponent);

        public string MainPageLink => @"/Module/Rebalancing";

        public string ModuleName => "Rebalancing";


         public void Register(IServiceCollection services)
        {
            services.AddDatabase<RebalancingDbContext>();
            services.AddDatabase<PortfoliosDbContext>();
            services.AddScoped<IPortfolioDriftDao, PortfolioDriftDao>()
                .AddScoped<IRebalancingSessionDao, RebalancingSessionDao>()
                .AddScoped<IPortfolioDao, PortfolioDao>();
        }

       
    }
}
