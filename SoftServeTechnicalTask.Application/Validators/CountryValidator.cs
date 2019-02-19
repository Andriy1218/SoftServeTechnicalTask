using FluentValidation;
using SoftServerTechnicalTask.Domain.Model;

namespace SoftServeTechnicalTask.Application.Validators
{
    public class CountryValidator : AbstractValidator<Country>
    {
        public CountryValidator()
        {
            RuleFor(x => x.Id).Must(x => x == 0).WithMessage("Request should not contain id, because it will be generated automatically");

            RuleFor(x => x.Name).NotEmpty().WithMessage("Name should not be empty")
                .Length(1, 30).WithMessage("Name has invalid length");

            RuleFor(x => x.Code).NotEmpty().WithMessage("Code should not be empty")
                .Length(1, 10).WithMessage("Code has invalid length");

            RuleFor(x => x.OrganizationId).NotEmpty().WithMessage("OrganizationId should not be empty");

            RuleFor(x => x.Businesses).Must(x => x == null || x.Count == 0).WithMessage("Businesses should be added/modified via another route");
        }
    }
}
