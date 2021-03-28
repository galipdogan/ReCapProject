using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IColorService
    {
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        List<Color> GetAll();
    }
}
