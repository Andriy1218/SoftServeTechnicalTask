using FluentValidation;
using SoftServerTechnicalTask.Domain.Model;

namespace SoftServeTechnicalTask.Application.Validators
{
    public class OfferingValidator : AbstractValidator<Offering>
    {
        public OfferingValidator()
        {
            RuleFor(x => x.Id).Must(x => x == 0).WithMessage("Request should not contain id, because it will be generated automatically");

            RuleFor(x => x.Name).NotEmpty().WithMessage("Name should not be empty")
                .Length(1, 100).WithMessage("Name has invalid length");

            RuleFor(x => x.FamilyId).NotEmpty().WithMessage("FamilyId should not be empty");

            RuleFor(x => x.Departments).Must(x => x == null || x.Count == 0).WithMessage("Departments should be added/modified via another route");
        }
    }
}
