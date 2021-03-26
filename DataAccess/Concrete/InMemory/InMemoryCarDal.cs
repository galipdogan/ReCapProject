using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;


namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId  =1, BrandId = 1,CarName = "Skyline",ColorId = 1,DailyPrice =300,Description = "Gtr Sport Car", ModelYear = 2002},
                new Car{CarId =2, BrandId = 2,CarName = "Şahin",ColorId = 2,DailyPrice =500,Description = "Daily Car", ModelYear = 2000},
                new Car{CarId =3, BrandId = 1,CarName = "Qashqai",ColorId = 3,DailyPrice =100,Description = "SUV Car", ModelYear = 2021},
                new Car{CarId =4, BrandId = 2,CarName = "Kartal",ColorId = 4,DailyPrice =800,Description = "Station Vagon Car", ModelYear = 1999},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
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
    }
}
