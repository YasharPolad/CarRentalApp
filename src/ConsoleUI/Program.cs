using Business;
using Business.Concrete;
using Business.Validation;
using DataAccess.Concrete.EFCoreRepository;
using DataAccess.Concrete.InMemoryRepository;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            CarService carService = new CarService(new CarRepository(new CarRentalContext()), new CarValidator());
            Car car = new Car { Name = "X", BrandId = 1, ColorId = 2, DailyPrice = -2, ModelYear = 0 };
            var response = carService.GetCarById(10);
            Console.WriteLine(response.IsSuccess);
            Console.WriteLine(response.Message);
            Console.WriteLine(response.Data.Name);
        }
    }
}
            //while(true)
            //{
            //    PrintMainMenu();
            //    var input = Console.ReadLine();

            //    if(input == "1")
            //    {
            //        PrintAllCars(carService);
            //        string userInput = GetMenuInput("Please enter car number or 'home' for main menu");
            //        if (userInput == "home")
            //        {
            //            continue;
            //        }
                        
            //        else
            //        {
            //            PrintCarDetailsById(carService, int.Parse(userInput));
            //            string detailUserInput = GetMenuInput("Please enter 1, 2, or 3 for update, delete and back to menu");
            //            if (detailUserInput == "3")
            //                continue;
            //        }
                        
            //    }
            //    else if(input == "2")
            //    {
            //        string userInput = GetMenuInput("Please enter the car number"); //validate
            //        PrintCarDetailsById(carService, int.Parse(userInput));
            //        string detailUserInput = GetMenuInput("Please enter 1, 2, or 3 for update, delete and back to menu");
            //        if (detailUserInput == "3")
            //            continue;
            //    }
            //    else if(input == "3")
            //    {
            //        var carToAdd = AddCar();
            //        try
            //        {
            //            carService.AddCar(carToAdd);
            //        }
            //        catch (InvalidCarException ex)
            //        {
            //            Console.WriteLine(ex.Message);
            //            string userInput = GetMenuInput("Press any key to go back to main menu");
            //            continue;
            //        }

            //    }
            //    else if(input == "4")
            //    {
            //        BrandSeeder();
            //        ColorSeeder();
            //        CarSeeder();
            //        continue;
            //    }

            //}

        

//        static void PrintMainMenu()
//        {
//            Console.Clear();
//            Console.WriteLine(@"What would you like to do (Enter 1-3)?

//1. List all cars
//2. Show car details by id 
//3. Add a new car
//4. Seed the database");                 
//        }

//        static void PrintAllCars(CarService carService)
//        {
//            Console.Clear();
//            var cars = carService.GetCarDetails();

//            cars.ForEach(car => Console.WriteLine($"{car.CarName} - {car.BrandName} - {car.ColorName}"));
//        }

//        static string GetMenuInput(string prompt)
//        {
//            Console.WriteLine(prompt);
//            var input = Console.ReadLine();
//            return input;
//        }

//        static void PrintCarDetailsById(CarService carService, int id)
//        {
//            Console.Clear();
//            var car = carService.GetCarById(id);
//            Console.WriteLine(@$"Name - {car.Description}
//Price for today - {car.DailyPrice}
//Year - {car.ModelYear}");
//        }

//        static Car AddCar()
//        {
//            Console.Clear();
//            var car = new Car();
//            car.Name = GetMenuInput("Enter car name");  
//            car.ModelYear = int.Parse(GetMenuInput("Enter car year")); //Need to have validation here
//            car.DailyPrice = int.Parse(GetMenuInput("Enter car price"));
//            car.ColorId = int.Parse(GetMenuInput("Enter color id"));
//            car.BrandId = int.Parse(GetMenuInput("Enter brand id"));
//            return car;
//        }

//        static void ColorSeeder()
//        {
//            var colors = new List<Color>
//            {
//                new Color{Name = "Black"},
//                new Color{Name = "White"},
//                new Color{Name = "Red"},
//                new Color{Name = "Green"},
//                new Color{Name = "Blue"},
//                new Color{Name = "Yellow"},
//                new Color{Name = "Grey"}
//            };

//            ColorService colorService = new ColorService(new ColorRepository(new CarRentalContext()));
//            colors.ForEach(c => colorService.AddColor(c));
//        }

//        static void BrandSeeder()
//        {
//            var brands = new List<Brand>
//            {
//                new Brand{Name = "Mercedes"},
//                new Brand{Name = "BMW"},
//                new Brand{Name = "Ferrari"},
//                new Brand{Name = "Toyota"},
//                new Brand{Name = "Jeep"},
//                new Brand{Name = "Nissa"}
//            };

//            BrandService brandService = new BrandService(new BrandRepository(new CarRentalContext()));
//            brands.ForEach(b => brandService.AddBrand(b));
//        }

//        static void CarSeeder()
//        {
//            var cars = new List<Car>
//            {
//                new Car{BrandId = 2, ColorId = 2, DailyPrice = 12000, Name = "Toyota Corolla", ModelYear = 2006},
//                new Car{BrandId = 2, ColorId = 2, DailyPrice = 50000, Name = "Range Rover", ModelYear = 2010},
//                new Car{BrandId = 1, ColorId = 7, DailyPrice = 300000,Name = "Ferrari", ModelYear = 2019},
//                new Car{BrandId = 3, ColorId = 4, DailyPrice = 22000, Name = "Mitsubishi", ModelYear = 2020},
//                new Car{BrandId = 3, ColorId = 1, DailyPrice = 30000, Name = "Dodge", ModelYear = 2018},
//                new Car{BrandId = 6, ColorId = 3, DailyPrice = 15000, Name = "Nissan", ModelYear = 2009},
//            };

//            CarService carService = new CarService(new CarRepository(new CarRentalContext()), new CarValidator());
//            cars.ForEach(c => carService.AddCar(c));
//        }
//    }
//}
