using Core.Enums;
using Infrastrucrure.ApiResponse;
using MediatR;

namespace Application.Components.Insurance.Create;

public class CreateParam : IRequest<ApiResponse<string>>
{
    public string Title { get; set; }
    public ICollection<CoverageParamDto> Coverages { get; set; }

    public class CoverageParamDto
    {
        public CoverageType CoverageType { get; set; }
        public decimal Amount { get; set; }
    }
}
