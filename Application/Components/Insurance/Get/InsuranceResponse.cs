using Core.Enums;
using Core.Models;

namespace Application.Components.Insurance.Get;

public class InsuranceResponse
{
    public string Title { get; set; }
    public decimal TotalPremium { get; set; }
    public ICollection<InsuranceCoverageResponseDto> InsuranceCoverages { get; set; }
}

public class InsuranceCoverageResponseDto
{
    public decimal Amount { get; set; }
    public decimal Premium { get; set; }
    public string CoverageTypeName { get; set; }
}
