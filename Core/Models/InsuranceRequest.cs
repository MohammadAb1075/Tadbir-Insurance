namespace Core.Models;

public class InsuranceRequest
{
    public int Id { get; set; }
    public string Title { get; set; }
    public List<CoverageRequest> Coverages { get; set; }
}
