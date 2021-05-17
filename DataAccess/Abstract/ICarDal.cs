using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.Entities;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailsDto> GetCarDetails(Expression<Func<CarDetailsDto, bool>> filter = null);
        //List<CarDetailsDto> GetCarDetailsByCarId(int carId);

    }
}
