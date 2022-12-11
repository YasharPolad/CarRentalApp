using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EFCoreRepository
{
    public class ColorRepository : GenericRepository<Color, CarRentalContext>, IColorRepository
    {
        public ColorRepository(CarRentalContext context) : base(context)
        {
        }
    }
}
