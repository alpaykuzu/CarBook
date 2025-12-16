using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CarPricings.Queries.GetAllCarPricingsWithCar
{
    public class GetAllCarPricingsWithCarQueryResponse
    {
        public int CarID { get; set; }
        public int BrandID { get; set; }
        public string BrandName { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public decimal DailyPrice { get; set; }
        public decimal HourlyPrice { get; set; }
        public decimal WeeklyPrice { get; set; }
    }
}
