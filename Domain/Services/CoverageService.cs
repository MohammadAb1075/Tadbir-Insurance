using Core.Enums;
using Core.Models;
using Core.Repositories;

namespace Domain.Services;

internal class CoverageService(ICoverageRepository _repository) : ICoverageService
{
    //public decimal CalculatePremium(CoverageModel coverage, decimal amount)
    //{
    //    if (amount < coverage.MinAmount || amount > coverage.MaxAmount)
    //        throw new ArgumentException("Amount out of range for the selected coverage.");

    //    return amount * coverage.Rate;
    //}
    public async Task<ICollection<CoverageModel>> GetAsync(CoverageType[] coverageTypes)
    {
        return await _repository.GetAsync(coverageTypes);
    }
}
