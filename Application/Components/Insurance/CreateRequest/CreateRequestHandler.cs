using Core.Models;
using Core.Repositories;
using Domain.Services;
using MediatR;

namespace Application.Components.Insurance.CreateRequest;

public class CreateRequestHandler(IInsuranceRequestRepository _insuranceRequestRepository, ICoverageRepository _coverageRepository) : IRequestHandler<CreateRequestParam>
{
    public async Task Handle(CreateRequestParam param, CancellationToken cancellationToken)
    {
        var receivedCoverageTypes = param.Coverages.Select(x => x.CoverageType).ToArray();
        var existCoverages = await _coverageRepository.GetAsync(receivedCoverageTypes);

        var coverages = new List<CoverageRequestModel>();
        foreach (var coverageDto in param.Coverages)
        {
            var existCoverage = existCoverages.FirstOrDefault(x => x.CoverageTypeId == coverageDto.CoverageType);

            if (!IsValidCoverageAmount(existCoverage, coverageDto.Amount))
                throw new ArgumentException("Amount out of range for the selected coverage.");

            var coverageRequestModel = CreateCoverageRequestModel(coverageDto.Amount, existCoverage);

            coverages.Add(coverageRequestModel);
        }



    }

    private bool IsValidCoverageAmount(CoverageModel coverage, decimal amount)
    {
        if (amount < coverage.MinAmount || amount > coverage.MaxAmount)
            return false;

        return true;
    }

    private static CoverageRequestModel CreateCoverageRequestModel(decimal amount, CoverageModel existCoverage)
    {
        return new CoverageRequestModel
        {
            CoverageId = existCoverage.Id,
            Amount = amount,
            Premium = existCoverage.Rate * amount
        };
    }
}
