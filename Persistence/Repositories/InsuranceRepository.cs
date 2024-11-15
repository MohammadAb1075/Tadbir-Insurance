using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories;

public class InsuranceRepository(DatabaseContext _db) : IInsuranceRepository
{
    public async Task<ICollection<InsuranceModel>> GetAllAsync()
    {
        return await _db.Insurances.Include(x => x.InsuranceCoverages)
                                   .ThenInclude(y => y.Coverage)
                                   .ThenInclude(z => z.CoverageType)
                                   .ToArrayAsync();
    }

    public async Task InsertAsync(InsuranceModel model)
    {
        await _db.Insurances.AddAsync(model);

        await _db.SaveChangesAsync();
    }
}
