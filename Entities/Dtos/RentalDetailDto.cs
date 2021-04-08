using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using Core.Entities;

namespace Entities.Dtos
{
    public class RentalDetailDto : IDto
    {

        public int RentId { get; set; }
        public string ImagePath { get; set; }
        public string CustomerName { get; set; }
        public string CompanyName { get; set; }
        public string CarName { get; set; }
        public string ColorName { get; set; }
        public string BrandName { get; set; }
        public int ModelYear { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Description { get; set; }
        public decimal DailyPrice { get; set; }

    }
}
