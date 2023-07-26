using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using VerivoxTest.Application.Especifications.Responses;
using VerivoxTest.Application.Models.Request;
using VerivoxTest.Application.Models.Responses;

namespace Verivox.Controllers;

/// <summary>
/// Compares the tariff of the different or existent products on the system.
/// Given an AnnualConsumption  a calculation is executed to get the cost of the energy consumption. 
/// Controller can be used to bring the specific tariffs by Id/Name. 
/// Another get method to get an specific tariff.
/// TO DO: Add swagger attributes to improve the documentation of the API.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[SwaggerTag(description: "Get Energy Tariff, Compare Tariff")]
public class TarrifController : ControllerBase
{
    private readonly IMediator _mediator;

    private readonly ILogger<TarrifController> _logger;
    private readonly IValidator<TariffComparerRequest> _validator;

    public TarrifController(IMediator mediator, ILogger<TarrifController> logger, IValidator<TariffComparerRequest> validator)
    {
        _logger = logger;
        _validator = validator;
        _mediator = mediator;
    }

    [HttpGet(Name = "Compare")]
    [SwaggerOperation(Summary = "Returns a list of consumption cost given the anual consumption", Description = "Gets a list of an annual consumption costs of energy for the products registered in the system ordered in ascending order given an annual consumption")]
    [SwaggerResponse(200, Description = "List of consumptions with the name of the products in ascending order", Type = typeof(TariffComparerResponse))]
    [SwaggerResponse(400, Description = "Annual consumption is invalid", Type = typeof(ValidationResponse))]

    public async Task<ActionResult> Get([FromQuery, SwaggerParameter(Description = "Annual energy consumption kWh/year.", Required = true)] TariffComparerRequest request)
    {
        _logger.LogInformation($"Entering Compare GET on TariffController ");
        var results = _validator.Validate(request);

        //TO DO: Move this validation as part of the Middleware
        if (!results.IsValid)
        {
            var validationResponse = new ValidationResponse();

            foreach (var failure in results.Errors)
            {
                validationResponse.Messages.Add($"Property{failure.PropertyName} failed validation. Error was: {failure.ErrorMessage}");
            }

            return BadRequest(validationResponse);
        }

        return Ok(await _mediator.Send(request));
    }
}
