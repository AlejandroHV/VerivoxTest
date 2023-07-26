using FluentValidation;
using VerivoxTest.Application.Models.Request;

namespace VerivoxTest.Application.API.Validators
{
    public class ConsumptionComparerRequestValidator : AbstractValidator<TariffComparerRequest>
    {
        public ConsumptionComparerRequestValidator()
        {
            RuleFor(request => request.AnnualConsumption).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("Annual Consumption must be greater than 0");
        }
    }
}
