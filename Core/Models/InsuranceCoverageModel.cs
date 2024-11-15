namespace Core.Models;

public class InsuranceCoverageModel : ModelBase
{
    public int CoverageId { get; set; }
    public int InsuranceId { get; set; }
    public decimal Amount { get; set; }
    public decimal Premium { get; set; }
    public CoverageModel Coverage { get; set; }
    public InsuranceModel Insurance { get; set; }
}