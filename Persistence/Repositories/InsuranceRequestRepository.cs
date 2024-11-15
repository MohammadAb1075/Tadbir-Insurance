using Core.Models;
using Core.Repositories;

namespace Persistence.Repositories;

public class InsuranceRequestRepository : IInsuranceRequestRepository
{
    public Task AddAsync(InsuranceRequestModel request)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<InsuranceRequestModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}
