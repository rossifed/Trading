using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Shared.Abstractions.Modules;
using Quantaventis.Trading.Modules.Valuation.Gui.Components;
using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Modules.Valuation.Gui.Dao;
using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Shared.Infrastructure;
using Quantaventis.Trading.Shared.Infrastructure.Database;
using Quantaventis.Trading.Modules.Valuation.Infrastructure.Entities;

namespace Quantaventis.Trading.Modules.Valuation.Gui
{
    internal class ValuationGuiConnector : IModuleGuiConnector
    {

        public string Abbreviation => "VAL";

        public string Description => "Module for valuation management";

        public string DisplayName => "Valuation";

        public Type MainComponentType => typeof(ValuationMainComponent);

        public string MainPageLink => @"/Module/Valuation";

        public string ModuleName => "Valuation";


         public void Register(IServiceCollection services)
        {
            services.AddDatabase<ValuationDbContext>();
            services.AddScoped<ITargetAllocationValuationDao, TargetAllocationValuationDao>()
                .AddScoped<IPortfolioDao, PortfolioDao>()
                .AddScoped<IPortfolioValuationDao, PortfolioValuationDao>();
        }

       
    }
}
