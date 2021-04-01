using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntitiyFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapProjectContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetail()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars on r.CarId equals c.CarId
                             join cu in context.Customers on r.CustomerId equals cu.CustomerId


                             select new RentalDetailDto
                             {
                                 CarName = c.CarName,
                                 CustomerName = cu.CompanyName
                             };

                return result.ToList();
            }
        }
    }
}
