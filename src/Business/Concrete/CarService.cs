using Business.Abstract;
using Business.Constants;
using Business.Validation;
using Core.Utilities;
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
        public IResponse AddCar(Car car)
        {
            bool result = _carValidator.Validate(car);
            if (!result)
            {
                return new ErrorResponse(Messages.InvalidItem(typeof(Car)));
            }
            _carRepository.Add(car);
            return new SuccessResponse();
        }

        public IResponse DeleteCar(Car car)
        {
            _carRepository.Delete(car);
            return new SuccessResponse();
        }

        public IDataResponse<List<Car>> GetAllCars()
        {
            var cars = _carRepository.GetAll();
            return new SuccessDataResponse<List<Car>>(cars);
        }

        public IDataResponse<Car> GetCarById(int id)
        {
            var car = _carRepository.Get(c => c.Id == id);
            if(car == null)
            {
                return new ErrorDataResponse<Car>(Messages.ItemNotFound(typeof(Car), id));
            }
            else
            {
                return new SuccessDataResponse<Car>(car);
            }
        }

        public IResponse UpdateCar(Car car)
        {
            _carRepository.Update(car);
            return new SuccessResponse();
        }

        //Other Methods
        public IDataResponse<List<Car>> GetCarsByBrandId(int id)
        {
            var cars = _carRepository.GetAll(c => c.BrandId == id);
            return new SuccessDataResponse<List<Car>>(cars);
        }
        public IDataResponse<List<Car>> GetCarsByColorId(int id)
        {
            var cars = _carRepository.GetAll(c => c.ColorId == id);
            return new SuccessDataResponse<List<Car>>(cars);
        }

        public IDataResponse<List<CarDetailDto>> GetCarDetails()
        {
            var carDetails = _carRepository.GetAllCarDetails();
            return new SuccessDataResponse<List<CarDetailDto>>(carDetails);
        }

        public IResponse RentCar(Car car)
        {
            car.IsAvailable = false;
            _carRepository.Update(car);
            return new SuccessResponse();
        }

        public IResponse ReturnCar(Car car)
        {
            car.IsAvailable = true;
            _carRepository.Update(car);
            return new SuccessResponse();
        }
    }
}
