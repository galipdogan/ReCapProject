using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetail();

    }
}
