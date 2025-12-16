using CarBook.Dto.Statistics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultStatisticsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
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

            //Brand Count
            var responseBrand = await client.GetAsync("https://localhost:7131/api/Statistics/GetBrandCount");

            if (responseBrand.IsSuccessStatusCode)
            {
                var jsonData = await responseBrand.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultBrandCountDto>(jsonData);
                ViewBag.BrandCount = values.BrandCount;
            }

            //Gasoline Car Count
            var responseCarCountGasoline = await client.GetAsync("https://localhost:7131/api/Statistics/GetCarCountByFuel/Gasoline");

            if (responseCarCountGasoline.IsSuccessStatusCode)
            {
                var jsonData = await responseCarCountGasoline.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultCarCountDto>(jsonData);
                ViewBag.CarCountGasoline = values.CarCount;
            }

            return View();
        }
    }
}
