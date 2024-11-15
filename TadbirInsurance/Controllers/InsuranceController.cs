using Application.Components.Insurance.Create;
using Application.Components.Insurance.Get;
using Core.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TadbirInsurance.Controllers.Requests;

namespace TadbirInsurance.Controllers;

[Route("api/insurance")]
[ApiController]
public class InsuranceController(ISender _sender) : ControllerBase
{
    [HttpPost("create-request")]
    public async Task<IActionResult> CreateInsuranceRequest([FromBody] InsuranceRequest request)
    {
        var insuranceRequestParam = new CreateParam
        {
            Title = request.Title,
            Coverages = request.Coverages.Select(c => new CreateParam.CoverageRequestDto
            {
                CoverageType = (CoverageType)c.CoverageType,
                Amount = c.Amount
            }).ToList()
        };

        await _sender.Send(insuranceRequestParam);

        return Ok(insuranceRequestParam);
    }

    [HttpGet]
    public async Task<IActionResult> GetInsuranceRequest()
    {
        var param = new GetParam { };

        var result = await _sender.Send(param);

        return Ok(result);
    }

}