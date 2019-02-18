using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using SSTest2.Model;

namespace SSTest2.Validators
{
    public class OfferingValidator : AbstractValidator<Offering>
    {
        public OfferingValidator()
        {
            RuleFor(x => x.Id).Null().WithMessage("Request should not contain id, because it will be generated automatically");

            RuleFor(x => x.Name).NotEmpty().WithMessage("Name should not be empty")
                .Length(1, 100).WithMessage("Name has invalid length");

            RuleFor(x => x.FamilyId).NotEmpty().WithMessage("FamilyId should not be empty");

            RuleFor(x => x.Departments).Null().WithMessage("Departments should be added/modified via another route");
        }
    }
}
