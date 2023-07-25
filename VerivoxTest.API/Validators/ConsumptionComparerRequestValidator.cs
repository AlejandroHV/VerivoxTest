using FluentValidation;
using VerivoxTest.Application.Models.Request;

namespace VerivoxTest.Application.API.Validators
{
    public class ConsumptionComparerRequestValidator : AbstractValidator<ConsumptionComparerRequest>
    {
        public ConsumptionComparerRequestValidator()
        {
            RuleFor(request => request.YearlyConsumption).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Annual Consumption must be greater than 0");
        }
    }
}
