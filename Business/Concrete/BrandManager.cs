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
        public List<Brand> GetAll()
        {
            return _iBrandDal.GetAll();
        }
    }
}
