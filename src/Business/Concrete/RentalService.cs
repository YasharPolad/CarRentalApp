using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly ICarService _carService;
        private readonly ICustomerRepository _customerRepository;
        public RentalService(IRentalRepository rentalRepository, 
                            ICustomerRepository customerRepository, ICarService carService)
        {
            _rentalRepository = rentalRepository;
            _customerRepository = customerRepository;
            _carService = carService;
        }

        public IResponse Rent(Car car, Customer customer, DateTime supposedReturnDate)
        {
            if(car.IsAvailable == false)
            {
                return new ErrorResponse(Messages.CarNotAvailable(car.Id));
            }
            else if(DateTime.Compare(supposedReturnDate, DateTime.UtcNow) < 0)
            {
                return new ErrorResponse(Messages.SupposedReturnDateIsSmallerThanNow());
            }

            _carService.RentCar(car);

            var rental = new Rental
            {
                CarId = car.Id,
                CustomerId = customer.Id,
                RentDate = DateTime.UtcNow,
                SupposedReturnDate = supposedReturnDate
            };
            _rentalRepository.Add(rental);
            return new SuccessResponse();
        }

        public IResponse Return(Rental rental)
        {
            var carToReturn = _carService.GetCarById(rental.CarId).Data;
            _carService.ReturnCar(carToReturn);
            rental.ReturnDate = DateTime.UtcNow;
            _rentalRepository.Update(rental);

            var customer = _customerRepository.Get(cust => cust.Id == rental.CustomerId);
            var paymentResult = MakeAPayment(CalculatePayment(rental), customer);
            
            if (paymentResult.IsSuccess)
                return new SuccessResponse();
            else
                return new ErrorResponse(); 
        }

        public IResponse MakeAPayment(decimal paymentAmount, Customer customer)
        {
            throw new NotImplementedException();
        }

        private decimal CalculatePayment(Rental rental) //What if the customer returns the car before the return date? 
        {
            var car = _carService.GetCarById(rental.CarId).Data;
            var rate = car.DailyPrice;
            if (rental.ReturnDate is null)
            {
                return 0;
            }

            var returnDate = rental.ReturnDate.GetValueOrDefault();
            var payment = returnDate.Subtract(rental.RentDate).Hours * rate;

            decimal lateReturnRate = 2 * rate; //TODO: This needs to be refactored into a constant (maybe different for different vehicle types)

            CalculateExtraPayment(rental, lateReturnRate);
            return payment;

        }

        private decimal CalculateExtraPayment(Rental rental, decimal lateReturnRate)
        {
            return rental.ReturnDate
                .GetValueOrDefault()
                .Subtract(rental.SupposedReturnDate).Hours * lateReturnRate;
        }


    }
}
