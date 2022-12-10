using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EFCoreRepository
{
    public class CarRepository : GenericRepository<Car, CarRentalContext>, ICarRepository
    {
        public CarRepository(CarRentalContext context) : base(context)
        {
        }
    }
}
