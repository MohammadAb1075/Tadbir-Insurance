using Application.Components.Insurance.CreateRequest;
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
        var insuranceRequestParam = new CreateRequestParam
        {
            Title = request.Title,
            Coverages = request.Coverages.Select(c => new CreateRequestParam.CoverageRequestDto
            {
                CoverageType = (CoverageType)c.CoverageType,
                Amount = c.Amount
            }).ToList()
        };

        await _sender.Send(insuranceRequestParam);

        return Ok(insuranceRequestParam);
    }
}