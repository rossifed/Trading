using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Components;
using Quantaventis.Trading.Shared.Abstractions.Modules;

namespace Quantaventis.Trading.Shared.Abstractions.Modules
{
    public interface IModuleGuiConnector {
        string Abbreviation { get; }  // File name of the image for the card (assumed to be in a standard location like "/images/modules/")
        string Description { get; }  // Short description to display on the card
        string DisplayName { get; }  // Display name for the navigation menu
        Type MainComponentType { get; }  // The main Blazor component of this module
        string MainPageLink { get; }  // The main Blazor component of this module    

        string ModuleName { get; }  // The main Blazor component of this module      // ...

        void Register(IServiceCollection services);
    }
}
