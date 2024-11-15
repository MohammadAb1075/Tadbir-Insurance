using Core.Models;
using FluentValidation;

namespace Application.Validators;

public class InsuranceCoverageValidator : AbstractValidator<InsuranceCoverageModel>
{
    public InsuranceCoverageValidator(CoverageModel coverage)
    {
        RuleFor(b => b.Amount)
            .GreaterThanOrEqualTo(coverage.MinAmount)
            .LessThanOrEqualTo(coverage.MaxAmount);
    }
}
