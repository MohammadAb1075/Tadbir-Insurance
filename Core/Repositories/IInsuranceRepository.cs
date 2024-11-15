using Core.Models;

namespace Core.Repositories;

public interface IInsuranceRepository
{
    Task<ICollection<InsuranceModel>> GetAllAsync();
    Task InsertAsync(InsuranceModel request);
}
