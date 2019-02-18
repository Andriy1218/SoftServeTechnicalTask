using FluentValidation;
using SSTest2.Model;

namespace SSTest2.Validators
{
    public class OrganizationValidator : AbstractValidator<Organization>
    {
        public OrganizationValidator()
        {
            RuleFor(x => x.Id).Null().WithMessage("Request should not contain id, because it will be generated automatically");

            RuleFor(x => x.Name).NotEmpty().WithMessage("Name should not be empty")
                .Length(1, 100).WithMessage("Name has invalid length");

            RuleFor(x => x.Code).NotEmpty().WithMessage("Code should not be empty")
                .Length(1, 10).WithMessage("Code has invalid length");

            RuleFor(x => x.Owner).NotEmpty().WithMessage("Owner should not be empty")
                .Length(2, 42).WithMessage("Owner has invalid length"); ;

            RuleFor(x => x.OrganizationType).NotEmpty().WithMessage("OrganizationType should not be empty");

            RuleFor(x => x.Countries).Null().WithMessage("Countries should be added/modified via another route");
        }
    }
}
