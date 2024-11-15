namespace Core.Models;

public class InsuranceModel : ModelBase
{
    public string Title { get; set; }
    public decimal TotalPremium { get; set; }
    public ICollection<InsuranceCoverageModel> InsuranceCoverages { get; set; }
}
