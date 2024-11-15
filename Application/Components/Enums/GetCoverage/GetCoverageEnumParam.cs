using MediatR;

namespace Application.Components.Enums.GetEnum;

public class GetCoverageEnumParam() : IRequest<ICollection<CoverageEnumResponse>>
{
}
