using Core.Enums;
using Core.Models;

namespace Domain.Services;

public interface ICoverageService
{
    Task<ICollection<CoverageModel>> GetAsync(CoverageType[] coverageTypes);
}
