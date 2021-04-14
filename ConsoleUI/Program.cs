using System;
using Business.Concrete;
using Core.Entities.Concrete;
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
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            // Car car = new Car {CarId = 5, BrandId = 1, ColorId = 2, CarName = "Hilux", ModelYear = 2020, DailyPrice = 100};
            //Rental rental = new Rental {CarId = 2, CustomerId = 4, RentDate = DateTime.Today, ReturnDate =DateTime.MaxValue};
            //rentalManager.Add(rental);
            //carManager.Add(car);
            // carManager.Update(car);
            //carManager.Delete(car);
            CarTestDetail();
            
            //UserTest();
            //CustomerTest();
            //RentalDetailTest();
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            User user = new User
            {
                FirstName = "Galip",
                LastName = "Doğan",
                EMail = "galipdogan@gmail.com",
                //Password = "1234"
            };
            userManager.Add(user);
            userManager.GetAll();
        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Customer customer = new Customer { CompanyName = "Arabacılar", UserId = 1 };
            customerManager.Add(customer);
        }

        private static void RentalDetailTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
      
            var result = rentalManager.GetRentalDetail();
            if (result.Success == true)
            {
                foreach (var rental in rentalManager.GetRentalDetail().Data)
                {
                    Console.WriteLine(rental.CarName + " / " + rental.CompanyName + " / " + rental.CustomerName + " / " + rental.RentDate, rental.ReturnDate, rental.Description);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }

        private static void CarTestDetail()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetail();
            if (result.Success == true)
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

        private static void Car()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName );
                }
            }
        }
    }
}
