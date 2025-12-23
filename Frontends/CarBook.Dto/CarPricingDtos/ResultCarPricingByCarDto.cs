namespace CarBook.Dto.CarPricingDtos
{
    public class ResultCarPricingByCarDto
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
