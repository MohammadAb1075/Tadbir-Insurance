namespace TadbirInsurance.Controllers.Requests;

public class InsuranceRequest
{
    public string Title { get; set; }
    public ICollection<CoverageRequestDto> Coverages { get; set; }

    public class CoverageRequestDto
    {
        public int CoverageType { get; set; }
        public decimal Amount { get; set; }
    }
}
