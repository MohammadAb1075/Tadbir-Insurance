using Application.Components.Enums.GetCoverage;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TadbirInsurance.Controllers;

[Route("api/enums")]
public class EnumController(ISender _sender) : ControllerBase
{
    [HttpGet("coverage-type")]
    public async Task<IActionResult> GetCoverageTypeAsync()
    {
        var param = new GetCoverageEnumParam { };

        var response = await _sender.Send(param);

        return Ok(response);
    }
}
