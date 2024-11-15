namespace Core.Models;

public class CoverageTypeModel : ModelBase
{
    public string Name { get; set; }
    public ICollection<CoverageModel> Coverages { get; set; }
}
