using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EFCoreRepository
{
    public class BrandRepository : GenericRepository<Brand, CarRentalContext>, IBrandRepository
    {
        public BrandRepository(CarRentalContext context) : base(context)
        {
        }
    }
}
