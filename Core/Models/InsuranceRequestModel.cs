namespace Core.Models;

public class InsuranceRequestModel : ModelBase
{
    public string Title { get; set; }
    public decimal TotalPremium { get; set; }
    public ICollection<CoverageRequestModel> Coverages { get; set; }
}
