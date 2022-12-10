using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Validation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.ModelYear).InclusiveBetween(1900, DateTime.Today.Year);
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.Name.Length).GreaterThanOrEqualTo(2);
        }
    }
}
