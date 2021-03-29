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
        Car car = new Car {CarId = 5, BrandId = 1, ColorId = 2, CarName = "Hilux", ModelYear = 2020, DailyPrice = 100};
        
        //carManager.Add(car);
        carManager.Update(car);
            //carManager.Delete(car);
           // CarTestDetail();
        }

        private static void CarTestDetail()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetail())
            {
                Console.WriteLine(car.BrandName + " " + car.CarName + " " + car.ColorName + " " + car.DailyPrice);
            }
        }
    }
}
