using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.OpenApi.Any;
using VerivoxTest.Application.API.Extensions.Middleware;
using VerivoxTest.Application.Configurations;
using VerivoxTest.Application.Handlers;
using VerivoxTest.Infrastructure.FileContext;

var builder = WebApplication.CreateBuilder(args);
var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables()
    .Build();

var settings = config.GetRequiredSection("Settings").Get<AppSettingsBinding>();

FileContextConfig.Initialize(builder.Services);
ServicesRegistration.RegisterServices(builder.Services);

builder.Services.AddControllers(option =>
{
    option.Filters.Add<ExceptionFilter>();
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(TariffComparerHandlers).Assembly));
 
    
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
