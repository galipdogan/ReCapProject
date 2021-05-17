using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Entities.Dtos
{
    public class CarDetailsDto:IDto
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public int BrandId { get; set; }
        public string ColorName { get; set; }
        public int ColorId { get; set; }
        //public string ImagePath { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
        public List<string> CarImages { get; set; }
    }
}
