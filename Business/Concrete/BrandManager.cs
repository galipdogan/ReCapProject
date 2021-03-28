using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
   public class BrandManager:IBrandService
   {
       IBrandDal _iBrandDal;

       public BrandManager(IBrandDal iBrandDal)
       {
           _iBrandDal = iBrandDal;
       }

       public void Add(Car car)
       {
           throw new NotImplementedException();
       }

       public void Update(Car car)
       {
           throw new NotImplementedException();
       }

       public void Delete(Car car)
       {
           throw new NotImplementedException();
       }

       public List<Brand> GetAll()
        {
            return _iBrandDal.GetAll();
        }
    }
}
