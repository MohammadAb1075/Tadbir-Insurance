namespace Core.Models;

public class CoverageRequestModel : ModelBase
{
    public int CoverageId { get; set; }
    public decimal Amount { get; set; }
    public decimal Premium { get; set; }
}