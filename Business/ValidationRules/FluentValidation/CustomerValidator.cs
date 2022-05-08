using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.FirstName).MaximumLength(50);
            RuleFor(c => c.LastName).MaximumLength(50);
            RuleFor(c => c.Address).MaximumLength(255);
            RuleFor(c => c.Phone).MaximumLength(20);
            RuleFor(c => c.City).MaximumLength(50);
        }
    }
}
