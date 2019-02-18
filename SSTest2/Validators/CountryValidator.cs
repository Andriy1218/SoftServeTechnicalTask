using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using SSTest2.Model;

namespace SSTest2.Validators
{
    public class CountryValidator : AbstractValidator<Country>
    {
        public CountryValidator()
        {
            RuleFor(x => x.Id).Null().WithMessage("Request should not contain id, because it will be generated automatically");

            RuleFor(x => x.Name).NotEmpty().WithMessage("Name should not be empty")
                .Length(1, 30).WithMessage("Name has invalid length");

            RuleFor(x => x.Code).NotEmpty().WithMessage("Code should not be empty")
                .Length(1, 10).WithMessage("Code has invalid length");

            RuleFor(x => x.OrganizationId).NotEmpty().WithMessage("OrganizationId should not be empty");

            RuleFor(x => x.Businesses).Null().WithMessage("Businesses should be added/modified via another route");
        }
    }
}
