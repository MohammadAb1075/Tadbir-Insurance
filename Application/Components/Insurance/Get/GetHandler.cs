using Core.Enums;
using Core.Repositories;
using Infrastrucrure.ApiResponse;
using MediatR;

namespace Application.Components.Insurance.Get;

internal class GetHandler(IInsuranceRepository _insuranceRepository) : IRequestHandler<GetParam, ApiResponse<InsuranceResponse[]>>
{
    public async Task<ApiResponse<InsuranceResponse[]>> Handle(GetParam param, CancellationToken cancellationToken)
    {
        var result = await _insuranceRepository.GetAllAsync();

        var response = result.Select(x => new InsuranceResponse
        {
            Title = x.Title,
            TotalPremium = x.TotalPremium,
            InsuranceCoverages = x.InsuranceCoverages.Select(y => new InsuranceCoverageResponseDto
            {
                CoverageTypeName = y.Coverage.CoverageType.Name,
                Amount = y.Amount,
                Premium = y.Premium,
            }).ToArray()
        }).ToArray();

        return ResponseMessage.Success(response);
    }
}
