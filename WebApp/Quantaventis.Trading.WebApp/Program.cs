// MIT License
// Copyright (c) 2024 Federico Rossi (Quantaventis)
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

// ... previous usings ...

using Quantaventis.Trading.Shared.Infrastructure.Modules;
using Quantaventis.Trading.WebApp.Data;
using Quantaventis.Trading.WebApp;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

// Add services to the container.
var services = builder.Services;
var modules = services.RegisterModules(configuration);
builder.Host.ConfigureModules();

services.AddControllers();
services.AddCors();

// Set up CORS policy
services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        });
});

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri("https://localhost:7200") // replace with your API's base address if different
    });

// ... other service registrations ...

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();
modules.UseModules(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Use CORS policy
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
