using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IValidator<Car> _carValidator;

        public CarService(ICarRepository carRepository, IValidator<Car> carValidator)
        {
            _carRepository = carRepository;
            _carValidator = carValidator;
        }

        //Basic CRUD
        public void AddCar(Car car)
        {
            ValidationResult result = _carValidator.Validate(car);
            if (!result.IsValid)
            {
                throw new InvalidCarException(result.Errors[0].ErrorMessage);
            }
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
            return _carRepository.Get(c => c.Id == id);
        }

        public void UpdateCar(Car car)
        {
            _carRepository.Update(car);
        }

        //Other Methods
        public List<Car> GetCarsByBrandId(int id)
        {
            return _carRepository.GetAll(c => c.BrandId == id);
        }
        public List<Car> GetCarsByColorId(int id)
        {
            return _carRepository.GetAll(c => c.ColorId == id);
        }
    }
}
