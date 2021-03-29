using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId  =1, BrandId = 1,CarName = "Skyline",ColorId = 1,DailyPrice =0,Description = "Gtr Sport Car", ModelYear = 2002},
                new Car{CarId =2, BrandId = 2,CarName = "Ş",ColorId = 2,DailyPrice =500,Description = "Daily Car", ModelYear = 2000},
                new Car{CarId =3, BrandId = 1,CarName = "Qashqai",ColorId = 3,DailyPrice =100,Description = "SUV Car", ModelYear = 2021},
                new Car{CarId =4, BrandId = 2,CarName = "Kartal",ColorId = 4,DailyPrice =800,Description = "Station Vagon Car", ModelYear = 1999},
            };
        }
        public void Add(Car car)
        {
            if (car.CarName.Length > 2 && car.DailyPrice > 0)
            {
                _cars.Add(car);
            }
            else
            {
                Console.WriteLine("Lütfen Bilgileri doğru giriniz.");
            }
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.CarName = car.CarName;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;

        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);//Tek bir eleman bulmaya yarar
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAllByBrand(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public List<Car> GetAllByColor(int colorId)
        {
            return _cars.Where(c => c.ColorId == colorId).ToList();

        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetail()
        {
            throw new NotImplementedException();
        }
    }
}
