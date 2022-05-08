using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class AuthorityValidator : AbstractValidator<Authority>
    {
        public AuthorityValidator()
        {
            RuleFor(a => a.Name).MaximumLength(50);
        }
    }
}
