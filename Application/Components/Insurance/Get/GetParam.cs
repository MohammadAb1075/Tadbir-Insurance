using Core.Enums;
using MediatR;

namespace Application.Components.Insurance.Get;

public class GetParam : IRequest<ICollection<InsuranceResponse>>
{
    public string Title { get; set; }
    public ICollection<CoverageRequestDto> Coverages { get; set; }

    public class CoverageRequestDto
    {
        public CoverageType CoverageType { get; set; }
        public decimal Amount { get; set; }
    }
}
