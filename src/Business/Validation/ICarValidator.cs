using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validation
{
    public interface ICarValidator
    {
        bool Validate(Car car);
    }
}
