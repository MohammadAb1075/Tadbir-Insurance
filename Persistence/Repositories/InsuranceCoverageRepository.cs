using Core.Models;
using Core.Repositories;
using Persistence.Context;

namespace Persistence.Repositories;

public class InsuranceCoverageRepository(DatabaseContext _db) : IInsuranceCoverageRepository
{
    public async Task InsertAsync(ICollection<InsuranceCoverageModel> models)
    {
        await _db.InsuranceCoverages.AddRangeAsync(models);

        await _db.SaveChangesAsync();
    }
}
