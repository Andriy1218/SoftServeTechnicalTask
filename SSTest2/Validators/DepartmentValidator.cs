using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using SoftServeTechnicalTask.Model;

namespace SoftServeTechnicalTask.Validators
{
    public class DepartmentValidator : AbstractValidator<Department>
    {
        public DepartmentValidator()
        {
            RuleFor(x => x.Id).Null().WithMessage("Request should not contain id, because it will be generated automatically");

            RuleFor(x => x.Name).NotEmpty().WithMessage("Name should not be empty")
                .Length(1, 100).WithMessage("Name has invalid length");

            RuleFor(x => x.OfferingId).NotEmpty().WithMessage("OfferingId should not be empty");
        }
    }
}
