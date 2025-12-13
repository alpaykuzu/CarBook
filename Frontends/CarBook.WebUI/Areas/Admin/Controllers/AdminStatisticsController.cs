using CarBook.Dto.AuthorDtos;
using CarBook.Dto.Statistics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminStatistics")]
    public class AdminStatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminStatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
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

            //Author Count
            var responseAuthor = await client.GetAsync("https://localhost:7131/api/Statistics/GetAuthorCount");

            if (responseAuthor.IsSuccessStatusCode)
            {
                var jsonData = await responseAuthor.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultAuthorCountDto>(jsonData);
                ViewBag.AuthorCount = values.AuthorCount;
            }

            //Blog Count
            var responseBlog = await client.GetAsync("https://localhost:7131/api/Statistics/GetBlogCount");

            if (responseBlog.IsSuccessStatusCode)
            {
                var jsonData = await responseBlog.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultBlogCountDto>(jsonData);
                ViewBag.BlogCount = values.BlogCount;
            }

            //Brand Count
            var responseBrand = await client.GetAsync("https://localhost:7131/api/Statistics/GetBrandCount");

            if (responseBlog.IsSuccessStatusCode)
            {
                var jsonData = await responseBrand.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultBrandCountDto>(jsonData);
                ViewBag.BrandCount = values.BrandCount;
            }

            //Avarage Hourly Price
            var responseAvgHourly = await client.GetAsync("https://localhost:7131/api/Statistics/GetAvarageCarPricing/Saatlik");

            if (responseAvgHourly.IsSuccessStatusCode)
            {
                var jsonData = await responseAvgHourly.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultAvarageCarPricing>(jsonData);
                ViewBag.AvgHourlyCount = values.AvaragePrice.ToString("0.00");
            }

            //Avarage Daily Price
            var responseAvgDaily = await client.GetAsync("https://localhost:7131/api/Statistics/GetAvarageCarPricing/Günlük");

            if (responseAvgDaily.IsSuccessStatusCode)
            {
                var jsonData = await responseAvgDaily.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultAvarageCarPricing>(jsonData);
                ViewBag.AvgDailyCount = values.AvaragePrice.ToString("0.00");
            }

            //Avarage Weekly Price
            var responseAvgWeekly = await client.GetAsync("https://localhost:7131/api/Statistics/GetAvarageCarPricing/Haftalık");

            if (responseAvgWeekly.IsSuccessStatusCode)
            {
                var jsonData = await responseAvgWeekly.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultAvarageCarPricing>(jsonData);
                ViewBag.AvgWeeklyCount = values.AvaragePrice.ToString("0.00");
            }

            //Automatic Car Count
            var responseAuto = await client.GetAsync("https://localhost:7131/api/Statistics/GetCarCountByTransmission/Automatic");

            if (responseAuto.IsSuccessStatusCode)
            {
                var jsonData = await responseAuto.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultCarCountDto>(jsonData);
                ViewBag.AutoCount = values.CarCount;
            }

            //Most Brand With Car
            var responseMostBrand = await client.GetAsync("https://localhost:7131/api/Statistics/GetMostBrandWithCar");

            if (responseMostBrand.IsSuccessStatusCode)
            {
                var jsonData = await responseMostBrand.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultMostCarBrand>(jsonData);
                ViewBag.MostBrand = values.BrandName;
            }

            //Most Blog With Comment
            var responseMostBlog = await client.GetAsync("https://localhost:7131/api/Statistics/GetMostBlogWithComment");

            if (responseMostBlog.IsSuccessStatusCode)
            {
                var jsonData = await responseMostBlog.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultMostBlogComment>(jsonData);
                ViewBag.MostBlog = values.BlogTitle;
            }

            //Car Count By Km
            var responseCarCountByKm = await client.GetAsync("https://localhost:7131/api/Statistics/GetCarCountByKm/20000");

            if (responseCarCountByKm.IsSuccessStatusCode)
            {
                var jsonData = await responseCarCountByKm.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultCarCountDto>(jsonData);
                ViewBag.CarCountByKm = values.CarCount;
            }

            //Gasoline Car Count
            var responseCarCountGasoline = await client.GetAsync("https://localhost:7131/api/Statistics/GetCarCountByFuel/Gasoline");

            if (responseCarCountGasoline.IsSuccessStatusCode)
            {
                var jsonData = await responseCarCountGasoline.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultCarCountDto>(jsonData);
                ViewBag.CarCountGasoline = values.CarCount;
            }

            //Diesel Car Count
            var responseCarCountDiesel = await client.GetAsync("https://localhost:7131/api/Statistics/GetCarCountByFuel/Diesel");

            if (responseCarCountDiesel.IsSuccessStatusCode)
            {
                var jsonData = await responseCarCountDiesel.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultCarCountDto>(jsonData);
                ViewBag.CarCountDiesel = values.CarCount;
            }


            //Car Model And Brand Max Daily Price
            var responseCarModelAndBrandMax = await client.GetAsync("https://localhost:7131/api/Statistics/GetCarByCarPricing?PricingType=Günlük&IsMax=true");

            if (responseCarModelAndBrandMax.IsSuccessStatusCode)
            {
                var jsonData = await responseCarModelAndBrandMax.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultCarByCarPricing>(jsonData);
                ViewBag.CarModelMax = values.Model;
                ViewBag.CarBrandMax = values.Brand;
            }

            //Car Model And Brand Min Daily Price
            var responseCarModelAndBrandMin = await client.GetAsync("https://localhost:7131/api/Statistics/GetCarByCarPricing?PricingType=Günlük&IsMax=false");

            if (responseCarModelAndBrandMin.IsSuccessStatusCode)
            {
                var jsonData = await responseCarModelAndBrandMin.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultCarByCarPricing>(jsonData);
                ViewBag.CarModelMin = values.Model;
                ViewBag.CarBrandMin = values.Brand;
            }

            return View();
        }
    }
}
