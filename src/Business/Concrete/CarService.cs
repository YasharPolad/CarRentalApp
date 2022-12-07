using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public void AddCar(Car car)
        {
            _carRepository.Add(car);
        }

        public void DeleteCar(Car car)
        {
            _carRepository.Delete(car);
        }

        public List<Car> GetAllCars()
        {
            return _carRepository.GetAll();
        }

        public Car GetCarById(int id)
        {
            return _carRepository.Get(id);
        }

        public void UpdateCar(Car car)
        {
            _carRepository.Update(car);
        }
    }
}
