using Core.Models;
using FluentValidation;

namespace Application.Components.Insurance.Create;

internal class CreateInsuranceValidator : AbstractValidator<CreateParam>
{
    public CreateInsuranceValidator()
    {
        RuleFor(x => x.Title).NotEmpty()
                             .WithMessage("Title is required.")
                             .MaximumLength(500)
                             .WithMessage("Title cannot exceed 100 characters.");

        RuleFor(x => x.Coverages).NotEmpty()
                                 .WithMessage("At least one coverage must be provided.")
                                 .Must(x => x.Count != 0)
                                 .WithMessage("Coverages cannot be empty.");
    }
}

internal class CreateCoverageParamValidator : AbstractValidator<CreateParam.CoverageParamDto>
{
    public CreateCoverageParamValidator(ICollection<CoverageModel> existCoverages)
    {
        RuleFor(x => x.CoverageType).IsInEnum()
                                    .WithMessage($"CoverageType is invalid.");

        RuleFor(x => x.Amount).Must((dto, amount) =>
                              {
                                  var coverage = existCoverages.SingleOrDefault(c => c.CoverageTypeId == (int)dto.CoverageType);
                                  return coverage != null && IsValidAmount(coverage, amount);
                              })
                              .WithMessage((dto, amount) =>
                              {
                                  var coverage = existCoverages.SingleOrDefault(c => c.CoverageTypeId == (int)dto.CoverageType);
                                  return coverage is not null ? $"Amount out of range for coverage type {dto.CoverageType}. Must be between {coverage.MinAmount} and {coverage.MaxAmount}." : null;
                              });
    }

    private bool IsValidAmount(CoverageModel coverage, decimal amount)
    {
        if (amount < coverage.MinAmount || amount > coverage.MaxAmount)
            return false;

        return true;
    }
}

