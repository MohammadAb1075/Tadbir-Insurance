using Core.Enums;
using Core.Models;

namespace Core.Repositories;

public interface ICoverageRepository
{
    Task<ICollection<CoverageModel>> GetAsync(int[] coverageTypes);
}
