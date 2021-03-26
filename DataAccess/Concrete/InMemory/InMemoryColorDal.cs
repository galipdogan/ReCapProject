using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryColorDal : IColorDal

    {

        private List<Color> _colors;

        public InMemoryColorDal()
        {
            _colors = new List<Color>
            {
                new Color { ColorId= 1, ColorName = "Mavi"},
                new Color {ColorId = 2, ColorName = "Beyaz"},
                new Color {ColorId = 3, ColorName = "Kırmızı"},
                new Color {ColorId = 4, ColorName = "Siyah"},
            };
        }
        public void Add(Color color)
        {
            _colors.Add(color);
        }

        public void Delete(Color color)
        {
            Color colorToDelete = _colors.SingleOrDefault(clr => clr.ColorId == color.ColorId);
            _colors.Remove(colorToDelete);
        }

        public List<Color> GetAll()
        {
            return _colors;
        }

        public void Update(Color color)
        {
            Color colorToUpdate = _colors.SingleOrDefault(clr => clr.ColorId == color.ColorId);
            colorToUpdate.ColorName = color.ColorName;
        }
    }
}
