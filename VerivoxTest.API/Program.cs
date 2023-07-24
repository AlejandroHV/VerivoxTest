using Microsoft.AspNetCore.Hosting;
using Microsoft.OpenApi.Any;
using VerivoxTest.Application.Configurations;
using VerivoxTest.Application.Handlers;
using VerivoxTest.Infrastructure.FileDataSource;

var builder = WebApplication.CreateBuilder(args);
IConfigurationRoot config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables()
    .Build();

AppSettings? settings = config.GetRequiredSection("Settings").Get<AppSettings>();
FileContextConfig.Initialize(builder.Services);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ConsumptionComparerHandler).Assembly));
 
    
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
