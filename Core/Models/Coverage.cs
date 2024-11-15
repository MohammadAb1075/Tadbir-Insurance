using Core.Enums;

namespace Core.Models;

public class Coverage
{
    public int Id { get; set; }
    public CoverageType CoverageTypeId { get; set; }
    public decimal MinAmount { get; set; }
    public decimal MaxAmount { get; set; }
    public decimal Rate { get; set; }
}