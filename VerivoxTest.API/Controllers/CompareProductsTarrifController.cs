using MediatR;
using Microsoft.AspNetCore.Mvc;
using VerivoxTest.Domain.Models.Entities;
using VerivoxTest.Domain.Models.Request;

namespace Verivox.Controllers;

[ApiController]
[Route("[controller]")]
public class CompareProductsTarrifController : ControllerBase
{
    private readonly IMediator _mediator;

    private readonly ILogger<CompareProductsTarrifController> _logger;

    public CompareProductsTarrifController(IMediator mediator, ILogger<CompareProductsTarrifController> logger)
    {
        _mediator = mediator;
    }

    [HttpGet(Name = "Compare")]
    
    public async Task<ActionResult> Get([FromQuery]ConsumptionComparerRequest request)
    {
       var comparison =  await _mediator.Send(request);

        return Ok(comparison);
    }
}
