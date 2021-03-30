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
       // Car car = new Car {CarId = 5, BrandId = 1, ColorId = 2, CarName = "Hilux", ModelYear = 2020, DailyPrice = 100};
        
        //carManager.Add(car);
       // carManager.Update(car);
            //carManager.Delete(car);
            CarTestDetail();
        }

        private static void CarTestDetail()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetail();
            if (result.Success==true)
            {
                foreach (var car in carManager.GetCarDetail().Data)
                {
                    Console.WriteLine(car.BrandName + " " + car.CarName + " " + car.ColorName + " " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }
    }
}
