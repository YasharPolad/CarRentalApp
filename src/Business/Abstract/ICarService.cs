using Core.Utilities;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResponse<List<Car>> GetAllCars();
        IResponse AddCar(Car car);
        IResponse UpdateCar(Car car);
        IResponse DeleteCar(Car car);

        IDataResponse<List<Car>> GetCarsByColorId(int id);
        IDataResponse<List<Car>> GetCarsByBrandId(int id);
        IDataResponse<List<CarDetailDto>> GetCarDetails();
    }
}
