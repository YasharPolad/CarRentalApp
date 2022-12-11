using Business.Abstract;
using Business.Validation;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
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
        private readonly ICarValidator _carValidator;

        public CarService(ICarRepository carRepository, ICarValidator carValidator)
        {
            _carRepository = carRepository;
            _carValidator = carValidator;
        }

        //Basic CRUD
        public void AddCar(Car car)
        {
            bool result = _carValidator.Validate(car);
            if (!result)
            {
                throw new InvalidCarException("The entered car is invalid");
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

        public List<CarDetailDto> GetCarDetails()
        {
            return _carRepository.GetAllCarDetails();
        }
    }
}
