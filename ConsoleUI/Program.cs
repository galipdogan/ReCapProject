using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;


namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.CarName);
            //}
            Car car = new Car { CarId = 5, BrandId = 1, ColorId = 2, CarName = "Hilux",ModelYear=2020,DailyPrice=100 };
            carManager.Add(car);

        }
    }
}
