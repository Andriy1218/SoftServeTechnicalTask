using FluentValidation;
using SoftServerTechnicalTask.Domain.Model;

namespace SoftServeTechnicalTask.Application.Validators
{
    public class DepartmentValidator : AbstractValidator<Department>
    {
        public DepartmentValidator()
        {
            RuleFor(x => x.Id).Must(x => x == 0).WithMessage("Request should not contain id, because it will be generated automatically");

            RuleFor(x => x.Name).NotEmpty().WithMessage("Name should not be empty")
                .Length(1, 100).WithMessage("Name has invalid length");

            RuleFor(x => x.ParentId).NotEmpty().WithMessage("ParentId should not be empty");
        }
    }
}
