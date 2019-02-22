using FluentValidation;
using SoftServerTechnicalTask.Domain.Model;

namespace SoftServeTechnicalTask.Application.Validators
{
    public class OrganizationValidator : AbstractValidator<Organization>
    {
        public OrganizationValidator()
        {
            //RuleFor(x => x.Id).Must(x => x == 0).WithMessage("Request should not contain id, because it will be generated automatically");

            RuleFor(x => x.Name).NotEmpty().WithMessage("Name should not be empty")
                .Length(1, 100).WithMessage("Name has invalid length");

            RuleFor(x => x.Code).NotEmpty().WithMessage("Code should not be empty")
                .Length(1, 10).WithMessage("Code has invalid length");

            RuleFor(x => x.Owner).NotEmpty().WithMessage("Owner should not be empty")
                .Length(2, 42).WithMessage("Owner has invalid length");

            RuleFor(x => x.OrganizationType).IsInEnum().WithMessage("OrganizationType has invalid value");

            RuleFor(x => x.Countries).Must(x => x == null || x.Count == 0).WithMessage("Countries should be added/modified via another route");
        }
    }
}
