using Core.Models;

namespace Core.Repositories;

public interface IInsuranceRequestRepository
{
    Task<ICollection<InsuranceRequestModel>> GetAllAsync();
    Task AddAsync(InsuranceRequestModel request);
}
