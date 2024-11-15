namespace Core.Models;

public class CoverageModel
{
    public int Id { get; set; }
    public int CoverageTypeId { get; set; }
    public decimal MinAmount { get; set; }
    public decimal MaxAmount { get; set; }
    public double Rate { get; set; }
    public CoverageTypeModel CoverageType { get; set; }
    public ICollection<InsuranceCoverageModel> InsuranceCoverages { get; set; }
}