using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EFCoreRepository
{
    public class CustomerRepository : GenericRepository<Customer, CarRentalContext>, IGenericRepository<Customer>
    {
        public CustomerRepository(CarRentalContext context) : base(context) //TODO: Override Add method? Customers are automatically created when users are
        {
        }
    }
}
