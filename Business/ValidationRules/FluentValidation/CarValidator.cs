using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Description).MinimumLength(2);
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.ModelYear).GreaterThan(1900);
            RuleFor(c => c.ColorId).GreaterThan(0);
            RuleFor(c => c.BrandId).GreaterThan(0);
            //RuleFor(c => c.Description).Must(StartWithF).WithMessage(Messages.StartsWithF); // method kullanımı


        }

        private bool StartWithF(string arg)
        {
            return arg.StartsWith("F");
        }
    }
}
