using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResponse MakeAPayment(decimal paymentAmount, Customer customer);
        IResponse Rent(Car car, Customer customer, DateTime supposedReturnDate);
        IResponse Return(Rental rental);
    }
}
