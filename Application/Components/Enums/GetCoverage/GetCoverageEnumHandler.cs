using Core.Enums;
using Infrastrucrure.ApiResponse;
using Infrastrucrure.Utils;
using MediatR;

namespace Application.Components.Enums.GetCoverage;

internal class GetCoverageEnumHandler : IRequestHandler<GetCoverageEnumParam, ApiResponse<CoverageEnumResponse[]>>
{
    public async Task<ApiResponse<CoverageEnumResponse[]>> Handle(GetCoverageEnumParam request, CancellationToken cancellationToken)
    {
        var result = EnumUtil.GetValues<CoverageType>();

        var response = result.Select(x => new CoverageEnumResponse
        {
            Name = x.Name,
            Value = x.Value
        }).ToArray();

        return ResponseMessage.Success(response);
    }
}
