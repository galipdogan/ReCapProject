using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract
{
   public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<RentalDetailDto>> GetRentalDetail();
    }
}
