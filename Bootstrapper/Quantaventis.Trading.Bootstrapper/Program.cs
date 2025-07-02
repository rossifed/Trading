
using NLog;
using NLog.Extensions.Logging;
using NLog.Web;
using Quantaventis.Trading.Bootstrapper;
using Quantaventis.Trading.Shared.Infrastructure;
using Quantaventis.Trading.Shared.Infrastructure.Modules;



var builder = WebApplication.CreateBuilder(args);
LogManager.Setup().LoadConfigurationFromFile("nlog.config");
builder.Logging.ClearProviders();
builder.Logging.AddNLog();
builder.Host.UseNLog();
var logger = LogManager.GetCurrentClassLogger();
try
{
    IConfiguration configuration = builder.Configuration;
 
    // Add services to the container.
    var services = builder.Services;

    builder.Host.ConfigureModules();
    var modules = services.RegisterModules(configuration);
    services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

 
    var app = builder.Build();
    modules.UseModules(app);
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();

    }
    else
    {
        app.UseHttpsRedirection();
    }

    app.UseHttpsRedirection();


    app.UseAuthorization();

    app.MapControllers();

    app.Initialize();
    
    app.Run();


}
catch (Exception e) {
    // Handle exceptions during startup
    logger.Error("Stopped program because of an exception during startup");
    throw;

}
finally{
    NLog.LogManager.Shutdown();
}




