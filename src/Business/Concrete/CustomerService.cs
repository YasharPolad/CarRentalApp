using Business.Abstract;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IResponse CreateCustomer(Customer customer) //TODO: Maybe you shouldn't be able to manually create customers?
        {
            _customerRepository.Add(customer);          
            return new SuccessResponse();
        }

        public IResponse DeleteCustomer(Customer customer)      
        {
            _customerRepository.Delete(customer);
            return new SuccessResponse();
        }

        public IDataResponse<List<Customer>> GetAllCustomers()
        {
            var customers = _customerRepository.GetAll();
            return new SuccessDataResponse<List<Customer>>(customers);
        }

        public IDataResponse<Customer> GetCustomerById(int id) 
        {
            var customer = _customerRepository.Get(u => u.Id == id);
            return new SuccessDataResponse<Customer>(customer);
        }

        public IResponse UpdateCustomer(Customer customer)
        {
            _customerRepository.Update(customer);
            return new SuccessResponse();
        }
    }
}
