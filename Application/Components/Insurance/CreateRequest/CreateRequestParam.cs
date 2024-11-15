using Core.Enums;
using MediatR;

namespace Application.Components.Insurance.CreateRequest;

public class CreateRequestParam : IRequest
{
    public string Title { get; set; }
    public ICollection<CoverageRequestDto> Coverages { get; set; }

    public class CoverageRequestDto
    {
        public CoverageType CoverageType { get; set; }
        public decimal Amount { get; set; }
    }
}
