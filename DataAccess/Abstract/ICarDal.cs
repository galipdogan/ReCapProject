using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        List<Car> GetAll();//Tüm Ürünleri getir
        List<Car> GetAllByBrand(int brandId);//Markasına göre getir
        List<Car> GetAllByColor(int colorId);// Rengine göre getir


    }
}
