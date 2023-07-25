using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VerivoxTest.Application.Especifications.Responses;
using VerivoxTest.Application.Models.Request;

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
public class TarrifController : ControllerBase
{
    private readonly IMediator _mediator;

    private readonly ILogger<TarrifController> _logger;
    private readonly IValidator<ConsumptionComparerRequest> _validator;

    public TarrifController(IMediator mediator, ILogger<TarrifController> logger, IValidator<ConsumptionComparerRequest> validator)
    {
        _logger = logger;
        _validator = validator;
        _mediator = mediator;
    }

    [HttpGet(Name = "Compare")]

    public async Task<ActionResult> Get([FromQuery] ConsumptionComparerRequest request)
    {
        _logger.LogInformation($"Entering Compare GET on TariffController ");
        var results = _validator.Validate(request);

        //TO DO: Move this validation as part of the Middleware
        if (!results.IsValid)
        {
            var validationResponse = new ValidationResponse();

            foreach (var failure in results.Errors)
            {
                validationResponse.Messages.Add($"Property{failure.PropertyName} failed validation. Error was: { failure.ErrorMessage}");
            }

            return BadRequest(validationResponse);
        }

        return Ok(await _mediator.Send(request));
    }
}
