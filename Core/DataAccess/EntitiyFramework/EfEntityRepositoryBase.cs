using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.Entities;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntitiyFramework
{
   public class EfEntityRepositoryBase<TEntity, TDBContext> : IEntityRepository<TEntity>
        where TEntity : class,IEntity, new()
        where TDBContext : DbContext, new()

    {
        public void Add(TEntity entity)
        {
            using (TDBContext context = new TDBContext())//Bu şekilde işi bitince bellekten atar
            {
               var addedEntity = context.Entry(entity);
                    addedEntity.State = EntityState.Added;
                    context.SaveChanges();

            }
        }

        public void Delete(TEntity entity)
        {
            using (TDBContext context = new TDBContext())
            {
                //context.Cars.Remove(context.Cars.SingleOrDefault(c => c.CarId == entity.CarId));
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TDBContext context = new TDBContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            using (TDBContext context = new TDBContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TDBContext context = new TDBContext())
            {
                //var updatedEntity = context.Cars.SingleOrDefault(c => c.CarId == entity.CarId);
                //updatedEntity.CarId = entity.CarId;
                //updatedEntity.CarName = entity.CarName;
                //updatedEntity.BrandId = entity.BrandId;
                //updatedEntity.ColorId = entity.ColorId;
                //updatedEntity.DailyPrice = entity.DailyPrice;
                //updatedEntity.ModelYear = entity.ModelYear;
                //updatedEntity.Description = entity.Description;
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
