using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Modules.FXGOGateway.Api.ACL;
using Quantaventis.Trading.Modules.FXGOGateway.Api.Dto;
using Quantaventis.Trading.Modules.FXGOGateway.Api.Options;
using Quantaventis.Trading.Modules.FXGOGateway.Api.Services;
using Quantaventis.Trading.Modules.FXGOGateway.Infrastructure;
using Quantaventis.Trading.Shared.Infrastructure;

namespace Quantaventis.Trading.Modules.FXGOGateway.Api
{
    internal static class Extensions
    {
        public static IServiceCollection AddModule(this IServiceCollection services)
        {
            services.AddOptions();
            services.AddControllers();
            return services
                .AddAcl()
                .AddInfrastructure()              
            .AddServices();                     
        }
        private static IServiceCollection AddOptions(this IServiceCollection services)
        {
            var fxgoFileOptions = services.GetOptions<FXGOFileOptions>("fxgogateway:FXGOFile");
            services.AddSingleton(fxgoFileOptions);
            return services;
        }

        private static IServiceCollection AddAcl(this IServiceCollection services)
        => services.AddScoped<IOrderTranslator<EfrpOrderDto>, EfrpOrderTranslator>()
            .AddScoped<IOrderTranslator<OrderDto> , FxForwardOrderTranslator>();

        private static IServiceCollection AddServices(this IServiceCollection services)
          => services.AddScoped<IFXGOFileGenerationService<EfrpOrderDto>, EfrpFileGenerationService>()
            .AddScoped<IFXGOFileGenerationService<OrderDto>, FxForwardFileGenerationService>();
 


    }
}
