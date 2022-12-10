using Business;
using Business.Concrete;
using DataAccess.Concrete.EFCoreRepository;
using DataAccess.Concrete.InMemoryRepository;
using Entities.Concrete;
using Entities.Validation;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarService carService = new CarService(new CarRepository(new CarRentalContext()), new CarValidator());

            while(true)
            {
                PrintMainMenu();
                var input = Console.ReadLine();

                if(input == "1")
                {
                    PrintAllCars(carService);
                    string userInput = GetMenuInput("Please enter car number or 'home' for main menu");
                    if (userInput == "home")
                    {
                        continue;
                    }
                        
                    else
                    {
                        PrintCarDetailsById(carService, int.Parse(userInput));
                        string detailUserInput = GetMenuInput("Please enter 1, 2, or 3 for update, delete and back to menu");
                        if (detailUserInput == "3")
                            continue;
                    }
                        
                }
                else if(input == "2")
                {
                    string userInput = GetMenuInput("Please enter the car number"); //validate
                    PrintCarDetailsById(carService, int.Parse(userInput));
                    string detailUserInput = GetMenuInput("Please enter 1, 2, or 3 for update, delete and back to menu");
                    if (detailUserInput == "3")
                        continue;
                }
                else if(input == "3")
                {
                    var carToAdd = AddCar();
                    try
                    {
                        carService.AddCar(carToAdd);
                    }
                    catch (InvalidCarException ex)
                    {
                        Console.WriteLine(ex.Message);
                        string userInput = GetMenuInput("Press any key to go back to main menu");
                        continue;
                    }

                }

            }

        }

        static void PrintMainMenu()
        {
            Console.Clear();
            Console.WriteLine(@"What would you like to do (Enter 1-3)?

1. List all cars
2. Show car details by id 
3. Add a new car");                 
        }

        static void PrintAllCars(CarService carService)
        {
            Console.Clear();
            carService
                .GetAllCars()
                .ForEach(car => Console.WriteLine($"{car.Id} - {car.Description}"));
        }

        static string GetMenuInput(string prompt)
        {
            Console.WriteLine(prompt);
            var input = Console.ReadLine();
            return input;
        }

        static void PrintCarDetailsById(CarService carService, int id)
        {
            Console.Clear();
            var car = carService.GetCarById(id);
            Console.WriteLine(@$"Name - {car.Description}
Price for today - {car.DailyPrice}
Year - {car.ModelYear}");
        }

        static Car AddCar()
        {
            Console.Clear();
            var car = new Car();
            car.Name = GetMenuInput("Enter car name");  
            car.ModelYear = int.Parse(GetMenuInput("Enter car year")); //Need to have validation here
            car.DailyPrice = int.Parse(GetMenuInput("Enter car price"));
            car.ColorId = int.Parse(GetMenuInput("Enter color id"));
            car.BrandId = int.Parse(GetMenuInput("Enter brand id"));
            return car;
        }
    }
}
