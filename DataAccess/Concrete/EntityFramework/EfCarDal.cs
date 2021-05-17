using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails(Expression<Func<CarDetailsDto, bool>> filter = null)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from car in context.Cars
                             join color in context.Colors on car.ColorId equals color.ColorId
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             select new CarDetailsDto()
                             {
                                 CarId = car.CarId,
                                 CarImages =
                                 (from i in context.CarImages where i.CarId == car.CarId select i.ImagePath).ToList(),
                                 Description = car.Description,
                                 CarName=car.CarName,
                                 BrandId = brand.BrandId,
                                 BrandName = brand.BrandName,
                                 ColorId = color.ColorId,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 // MinFindeksScore = car.MinFindeksScore
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
            //var result = from c in filter == null ? context.Cars : context.Cars.Where(filter)
            //             join b in context.Brands on c.BrandId equals b.BrandId
            //             join co in context.Colors on c.ColorId equals co.ColorId
            //             let image = (from carImage in context.CarImages where c.CarId == carImage.CarId select carImage.ImagePath),
            //             select new CarDetailsDto
            //             {
            //                 CarId = c.CarId,
            //                 BrandName = b.BrandName,
            //                 ColorName = co.ColorName,
            //                 CarName = c.CarName,
            //                 ModelYear = c.ModelYear,
            //                 DailyPrice = c.DailyPrice,
            //                 Description = c.Description,
            //                 ImagePath = image.Any() ? image.FirstOrDefault() : new CarImage { ImagePath = "images/default.jpg" }.ImagePath

            //             };
            //return result.ToList();
        }
    }

    //public List<CarDetailsDto> GetCarDetailsByCarId(int carId)
    //{
    //    using (ReCapProjectContext context = new ReCapProjectContext())
    //    {
    //        var result = from c in context.Cars
    //                     join b in context.Brands on c.BrandId equals b.BrandId
    //                     join clr in context.Colors on c.ColorId equals clr.ColorId
    //                     join ci in context.CarImages on c.CarId equals ci.CarId
    //                     select new CarDetailsDto
    //                     {
    //                         CarId = c.CarId,
    //                         CarName = c.CarName,
    //                         ImagePath = ci.ImagePath,
    //                         BrandName = b.BrandName,
    //                         ColorName = clr.ColorName,
    //                         DailyPrice = c.DailyPrice
    //                     };

    //        return result.ToList();
    //    }
    //}
}

