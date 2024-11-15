using Core.Models;
using Core.Repositories;

namespace Persistence.Repositories;

public class InsuranceRequestRepository : IInsuranceRequestRepository
{
    public Task AddAsync(InsuranceRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<InsuranceRequest>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}
