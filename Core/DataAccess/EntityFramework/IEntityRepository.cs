using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using Core.Entities;

namespace DataAccess.Abstract
{
   public interface IEntityRepository<T>where T:class,IEntity,new()
    {
        //T yazarak kullanıcan tipi belirmesini istiyoruz ve bu şekilde farklı classlarda tek bir kodu çalıştırabiliyoruz.
        List<T> GetAll(Expression<Func<T, bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
