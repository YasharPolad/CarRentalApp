using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemoryRepository
{
    public class InMemoryCarRepository : ICarRepository
    {
        private readonly List<Car> _carList;

        public InMemoryCarRepository()
        {
            _carList = new List<Car>
            {
                new Car{Id = 1, BrandId = 2, ColorId = 2, DailyPrice = 12000, Description = "Toyota Corolla", ModelYear = 2006},
                new Car{Id = 2, BrandId = 2, ColorId = 2, DailyPrice = 50000, Description = "Range Rover", ModelYear = 2010},
                new Car{Id = 3, BrandId = 1, ColorId = 2, DailyPrice = 300000, Description = "Ferrari", ModelYear = 2019},
                new Car{Id = 4, BrandId = 3, ColorId = 2, DailyPrice = 22000, Description = "Mitsubishi", ModelYear = 2020},
                new Car{Id = 5, BrandId = 3, ColorId = 1, DailyPrice = 30000, Description = "Dodge", ModelYear = 2018},
                new Car{Id = 6, BrandId = 2, ColorId = 3, DailyPrice = 15000, Description = "Nissan", ModelYear = 2009},
            };
        }

        public void Add(Car entity)
        {
            _carList.Add(entity);
        }

        public void Delete(Car entity)
        {
            var carToDelete = Get(entity.Id);
            _carList.Remove(carToDelete);
        }

        public Car Get(int id)
        {
            return _carList.Find(c => c.Id == id);
        }

        public Car Get(Expression<Func<Car, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _carList;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car entity)
        {
            var carToUpdate = Get(entity.Id);
            carToUpdate.BrandId = entity.BrandId;
            carToUpdate.ColorId = entity.ColorId;
            carToUpdate.DailyPrice = entity.DailyPrice;
            carToUpdate.Description = entity.Description;
            carToUpdate.ModelYear = entity.ModelYear;
        }
    }
}
