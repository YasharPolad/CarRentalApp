using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EFCoreRepository
{
    public class RentalRepository : GenericRepository<Rental, CarRentalContext>, IGenericRepository<Rental>
    {
        public RentalRepository(CarRentalContext context) : base(context)
        {
        }
    }
}
