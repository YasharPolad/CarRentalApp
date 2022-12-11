using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Validation
{
    public class CarValidator : ICarValidator
    {
        private List<Func<Car, bool>> carChecks = new List<Func<Car, bool>>();

        public CarValidator()
        {
            carChecks.Add(c => c.Name.Length >= 2);
            carChecks.Add(c => c.DailyPrice > 0);
        }


        public bool Validate(Car car)
        {
            return carChecks.All(check => check(car) == true);
        }
    }
}
