using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CarPricings.Queries.GetCarPricingByCar
{
    public class GetCarPricingByCarQueryResponse
    {
        public int CarID { get; set; }
        public int DailyCarPricingID { get; set; }
        public int DailyPricingID { get; set; }
        public decimal DailyPrice { get; set; }
        public int HourlyCarPricingID { get; set; }
        public int HourlyPricingID { get; set; }
        public decimal HourlyPrice { get; set; }
        public int WeeklyCarPricingID { get; set; }
        public int WeeklyPricingID { get; set; }
        public decimal WeeklyPrice { get; set; }
    }
}
