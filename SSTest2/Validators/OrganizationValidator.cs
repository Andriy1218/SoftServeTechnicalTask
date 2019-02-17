using FluentValidation;
using SSTest2.Model;

namespace SSTest2.Validators
{
    // ToDo: Add validators for all models
    public class OrganizationValidator : AbstractValidator<Organization>
    {
        public OrganizationValidator()
        {
            RuleFor(x => x.Id).Null().WithMessage("Request should not contain id, because it will be generated automatically");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name should not be empty").Length(1, 255).WithMessage("Name has invalid length");
            RuleFor(x => x.Countries).Null().WithMessage("Countries should be added/modified via another route");
            // ToDo: Add validations for other fields
        }
    }
}
