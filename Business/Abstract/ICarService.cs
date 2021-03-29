using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetCarsByBrandId(int id);
        List<Car> GetCarsByColorId(int id);
        List<Car> GetByUnitPrice(decimal min, decimal max);
        List<CarDetailDto> GetCarDetail();
    }
}
