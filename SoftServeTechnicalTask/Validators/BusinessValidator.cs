using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using SoftServeTechnicalTask.Model;

namespace SoftServeTechnicalTask.Validators
{
    public class BusinessValidator : AbstractValidator<Business>
    {
        public BusinessValidator()
        {
            RuleFor(x => x.Id).Must(x => x == 0).WithMessage("Request should not contain id, because it will be generated automatically");

            RuleFor(x => x.Name).NotEmpty().WithMessage("Name should not be empty")
                .Length(1, 100).WithMessage("Name has invalid length");

            RuleFor(x => x.CountryId).NotEmpty().WithMessage("CountryId should not be empty");

            RuleFor(x => x.Families).Must(x => x == null || x.Count == 0).WithMessage("Families should be added/modified via another route");
        }
    }
}
