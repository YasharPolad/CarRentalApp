using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EFCoreRepository
{
    public class UserRepository : GenericRepository<User, CarRentalContext>, IGenericRepository<User>
    {
        public UserRepository(CarRentalContext context) : base(context)
        {
        }
    }
}
