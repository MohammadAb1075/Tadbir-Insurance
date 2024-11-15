using MediatR;

namespace Application.Components.Enums.GetCoverage;

public class GetCoverageEnumParam : IRequest<ICollection<CoverageEnumResponse>>
{
}
