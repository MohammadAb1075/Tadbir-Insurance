using Azure;
using Core.Models;
using Core.Repositories;
using FluentValidation;
using FluentValidation.Results;
using Infrastrucrure.ApiResponse;
using MediatR;
using System.Threading;

namespace Application.Components.Insurance.Create;

internal class CreateHandler(ICoverageRepository _coverageRepository,
                             IInsuranceRepository _insuranceRepository,
                             IInsuranceCoverageRepository _insuranceCoverageRepository) : IRequestHandler<CreateParam, ApiResponse<string>>
{
    public async Task<ApiResponse<string>> Handle(CreateParam param, CancellationToken cancellationToken)
    { 
        var insuranceParamErrors = await ValidateInsuranceParamAsync(param);
        if(insuranceParamErrors is not null && insuranceParamErrors.Length > 0)
            return ResponseMessage.Failure(insuranceParamErrors);

        var receivedCoverageTypes = param.Coverages.Select(x => (int)x.CoverageType).ToArray();
        var existCoverages = await _coverageRepository.GetAsync(receivedCoverageTypes);

        var coverageParamErrors = await ValidateCoverageParamAsync(param.Coverages, existCoverages);
        if (coverageParamErrors is not null && coverageParamErrors.Length > 0)
            return ResponseMessage.Failure(coverageParamErrors);

        var insuranceCoverages = new List<InsuranceCoverageModel>();

        foreach (var coverageDto in param.Coverages)
        {
            var existCoverage = existCoverages.FirstOrDefault(x => x.CoverageTypeId == (int)coverageDto.CoverageType);

            var coverageRequestModel = CreateInsuranceCoverageModel(coverageDto.Amount, existCoverage);

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

        return ResponseMessage.Success();
    }

    private async Task<string[]> ValidateInsuranceParamAsync(CreateParam param)
    {
        var insuranceValidator = new CreateInsuranceValidator();

        var insuranceValidationResult = await insuranceValidator.ValidateAsync(param);

        var errorMessages = new List<string>();
        if (!insuranceValidationResult.IsValid)
        {
            var errors = insuranceValidationResult.Errors.Select(e => e.ErrorMessage).ToArray();
            errorMessages.AddRange(errors);
        }

        return [.. errorMessages];
    }

    private async Task<string[]> ValidateCoverageParamAsync(ICollection<CreateParam.CoverageParamDto> coverageDtos, ICollection<CoverageModel> existCoverages)
    {
        var errorMessages = new List<string>();
        foreach (var dto in coverageDtos)
        {
            var coverageValidator = new CreateCoverageParamValidator(existCoverages);
            var coverageValidationResult = await coverageValidator.ValidateAsync(dto);
            if (coverageValidationResult.IsValid)
                continue;

            var errors = coverageValidationResult.Errors.Select(e => e.ErrorMessage).ToArray();
            errorMessages.AddRange(errors);
        }

        return [.. errorMessages];
    }

    private InsuranceModel CreateInsuranceModel(string title, decimal totalPremium)
    {
        return new InsuranceModel
        {
            Title = title,
            TotalPremium = totalPremium
        };
    }

    private InsuranceCoverageModel CreateInsuranceCoverageModel(decimal amount, CoverageModel existCoverage)
    {
        return new InsuranceCoverageModel
        {
            CoverageId = existCoverage.Id,
            Amount = amount,
            Premium = (decimal)existCoverage.Rate * amount
        };
    }
}
