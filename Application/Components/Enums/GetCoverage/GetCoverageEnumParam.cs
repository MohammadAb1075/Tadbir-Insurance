using Infrastrucrure.ApiResponse;
using MediatR;

namespace Application.Components.Enums.GetCoverage;

public class GetCoverageEnumParam : IRequest<ApiResponse<CoverageEnumResponse[]>>
{
}
