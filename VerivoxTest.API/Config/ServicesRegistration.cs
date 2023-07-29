using FluentValidation;
using Microsoft.AspNetCore.Identity;
using VerivoxTest.Application.API.Validators;
using VerivoxTest.Application.Especifications.Factories.Interfaces;
using VerivoxTest.Domain.Models.Entities.Interfaces;

public class ServicesRegistration
{
    public static void RegisterServices( IServiceCollection services)
    {


        services.AddSingleton<IFactory<IProduct>>();
        services.AddValidatorsFromAssemblyContaining<ConsumptionComparerRequestValidator>();

    }
}

