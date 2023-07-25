using FluentValidation;
using Microsoft.AspNetCore.Identity;
using VerivoxTest.Application.API.Validators;

public class ServicesRegistration
{
    public static void RegisterServices( IServiceCollection services)
    {
        


        services.AddValidatorsFromAssemblyContaining<ConsumptionComparerRequestValidator>();

    }
}

