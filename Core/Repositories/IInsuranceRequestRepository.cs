using Core.Models;

namespace Core.Repositories;

public interface IInsuranceRequestRepository
{
    Task<ICollection<InsuranceRequest>> GetAllAsync();
    Task AddAsync(InsuranceRequest request);
}
