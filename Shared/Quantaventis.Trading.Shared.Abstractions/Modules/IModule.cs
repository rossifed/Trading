using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Quantaventis.Trading.Shared.Abstractions.Modules
{
    public interface IModule
    {
        IEnumerable<string> Policies => null;
        string Name { get; }
        void Register(IServiceCollection services);
        void Use(IApplicationBuilder app);

        void Configure(IHostBuilder hostBuilder);
    
    }
}
