using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator:AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(c => c.Name).NotNull();
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name).MinimumLength(3);
            RuleFor(c => c.Name).MaximumLength(18);
        }
    }
}
