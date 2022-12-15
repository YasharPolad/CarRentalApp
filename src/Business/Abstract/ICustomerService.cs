using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IResponse CreateCustomer(Customer user);
        IResponse DeleteCustomer(Customer user);
        IResponse UpdateCustomer(Customer user);
        IDataResponse<Customer> GetCustomerById(int id);
        IDataResponse<List<Customer>> GetAllCustomers();
    }
}
