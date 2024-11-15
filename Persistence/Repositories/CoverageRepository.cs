using Core.Enums;
using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories;

public class CoverageRepository(DatabaseContext _db) : ICoverageRepository
{
    public async Task<ICollection<CoverageModel>> GetAsync(int[] coverageTypes)
    {
        return await _db.Coverages.Where(x => coverageTypes.Contains(x.CoverageTypeId))
                                  .ToArrayAsync();
    }
}
