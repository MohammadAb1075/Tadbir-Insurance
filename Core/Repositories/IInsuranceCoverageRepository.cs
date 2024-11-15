using Core.Models;

namespace Core.Repositories;

public interface IInsuranceCoverageRepository
{
    Task InsertAsync(ICollection<InsuranceCoverageModel> models);
}
