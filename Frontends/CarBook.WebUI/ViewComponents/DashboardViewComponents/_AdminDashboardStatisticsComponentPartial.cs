using CarBook.Dto.Statistics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DashboardViewComponents
{
    public class _AdminDashboardStatisticsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminDashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            //Car Count
            var responseCar = await client.GetAsync("https://localhost:7131/api/Statistics/GetCarCount");

            if (responseCar.IsSuccessStatusCode)
            {
                var jsonData = await responseCar.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultCarCountDto>(jsonData);
                ViewBag.CarCount = values.CarCount;
            }

            //Location Count
            var responseLocation = await client.GetAsync("https://localhost:7131/api/Statistics/GetLocationCount");

            if (responseLocation.IsSuccessStatusCode)
            {
                var jsonData = await responseLocation.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultLocationCountDto>(jsonData);
                ViewBag.LocationCount = values.LocationCount;
            }

            //Avarage Hourly Price
            var responseAvgHourly = await client.GetAsync("https://localhost:7131/api/Statistics/GetAvarageCarPricing/Saatlik");

            if (responseAvgHourly.IsSuccessStatusCode)
            {
                var jsonData = await responseAvgHourly.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultAvarageCarPricing>(jsonData);
                ViewBag.AvgHourlyCount = values.AvaragePrice.ToString("0.00");
            }

            //Brand Count
            var responseBrand = await client.GetAsync("https://localhost:7131/api/Statistics/GetBrandCount");

            if (responseBrand.IsSuccessStatusCode)
            {
                var jsonData = await responseBrand.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultBrandCountDto>(jsonData);
                ViewBag.BrandCount = values.BrandCount;
            }

            return View();
        }
    }
}
