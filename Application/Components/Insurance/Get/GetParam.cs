using Core.Enums;
using Infrastrucrure.ApiResponse;
using MediatR;

namespace Application.Components.Insurance.Get;

public class GetParam : IRequest<ApiResponse<InsuranceResponse[]>>
{
    public string Title { get; set; }
    public ICollection<CoverageRequestDto> Coverages { get; set; }

    public class CoverageRequestDto
    {
        public CoverageType CoverageType { get; set; }
        public decimal Amount { get; set; }
    }
}
