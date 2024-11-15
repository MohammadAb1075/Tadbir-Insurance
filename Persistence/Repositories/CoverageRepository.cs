using Core.Enums;
using Core.Models;
using Core.Repositories;

namespace Persistence.Repositories;

public class CoverageRepository : ICoverageRepository
{
    public Task<ICollection<CoverageModel>> GetAsync(CoverageType[] coverageTypes)
    {
        throw new NotImplementedException();
    }
}
