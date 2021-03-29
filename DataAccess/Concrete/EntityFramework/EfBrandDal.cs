using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntitiyFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal :EfEntityRepositoryBase<Brand,ReCapProjectContext>, IBrandDal
    {
    }
}
