using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EFCoreRepository
{
    public class CarRepository : GenericRepository<Car, CarRentalContext>, ICarRepository
    {
        public CarRepository(CarRentalContext context) : base(context)
        {
        }

        public List<CarDetailDto> GetAllCarDetails()
        {
            return _context.Cars
                    .Include(c => c.Color)
                    .Include(c => c.Brand)
                    .Select(c => new CarDetailDto
                    {
                        CarName = c.Name,
                        BrandName = c.Brand.Name,
                        ColorName = c.Color.Name,
                        DailyPrice = c.DailyPrice
                    }).ToList();
        }
    }
}
