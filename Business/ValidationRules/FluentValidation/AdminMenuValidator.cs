using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class AdminMenuValidator : AbstractValidator<AdminMenu>
    {
        public AdminMenuValidator()
        {
            RuleFor(p => p.Name).MaximumLength(50);
        }
    }
}
