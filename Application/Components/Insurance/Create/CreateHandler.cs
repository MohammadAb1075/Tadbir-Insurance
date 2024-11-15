using Core.Models;
using Core.Repositories;
using MediatR;

namespace Application.Components.Insurance.Create;

public class CreateHandler(ICoverageRepository _coverageRepository,
                                  IInsuranceRepository _insuranceRepository,
                                  IInsuranceCoverageRepository _insuranceCoverageRepository) : IRequestHandler<CreateParam>
{
    public async Task Handle(CreateParam param, CancellationToken cancellationToken)
    {
        var receivedCoverageTypes = param.Coverages.Select(x => (int)x.CoverageType).ToArray();
        var existCoverages = await _coverageRepository.GetAsync(receivedCoverageTypes);

        var insuranceCoverages = new List<InsuranceCoverageModel>();

        foreach (var coverageDto in param.Coverages)
        {
            var existCoverage = existCoverages.FirstOrDefault(x => x.CoverageTypeId == (int)coverageDto.CoverageType);

            if (!IsValidCoverageAmount(existCoverage, coverageDto.Amount))
                throw new ArgumentException("Amount out of range for the selected coverage.");

            var coverageRequestModel = CreateInsuranceCoverageRequestModel(coverageDto.Amount, existCoverage);

            insuranceCoverages.Add(coverageRequestModel);
        }

        var totalPremium = insuranceCoverages.Sum(x => x.Premium);
        var insuranceModel = CreateInsuranceModel(param.Title, totalPremium);

        await _insuranceRepository.InsertAsync(insuranceModel);

        foreach (var insuranceCoverage in insuranceCoverages)
        {
            insuranceCoverage.InsuranceId = insuranceModel.Id;
        }
        await _insuranceCoverageRepository.InsertAsync(insuranceCoverages);
    }

    private InsuranceModel CreateInsuranceModel(string title, decimal totalPremium)
    {
        return new InsuranceModel
        {
            Title = title,
            TotalPremium = totalPremium
        };
    }

    private bool IsValidCoverageAmount(CoverageModel coverage, decimal amount)
    {
        if (amount < coverage.MinAmount || amount > coverage.MaxAmount)
            return false;

        return true;
    }

    private InsuranceCoverageModel CreateInsuranceCoverageRequestModel(decimal amount, CoverageModel existCoverage)
    {
        return new InsuranceCoverageModel
        {
            CoverageId = existCoverage.Id,
            Amount = amount,
            Premium = (decimal)existCoverage.Rate * amount
        };
    }
}
