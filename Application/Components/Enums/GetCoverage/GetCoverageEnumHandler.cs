using Core.Enums;
using Infrastrucrure.Utils;
using MediatR;

namespace Application.Components.Enums.GetEnum;

public class GetCoverageEnumHandler : IRequestHandler<GetCoverageEnumParam, ICollection<CoverageEnumResponse>>
{
    public async Task<ICollection<CoverageEnumResponse>> Handle(GetCoverageEnumParam request, CancellationToken cancellationToken)
    {
        var result = EnumUtil.GetValues<CoverageType>();

        var response = result.Select(x => new CoverageEnumResponse
        {
            Name = x.Name,
            Value = x.Value
        }).ToArray();

        return response;
    }
}
