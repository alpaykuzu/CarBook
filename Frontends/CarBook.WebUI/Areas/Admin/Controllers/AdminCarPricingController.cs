using CarBook.Dto.CarPricingDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/AdminCarPricing")]
    public class AdminCarPricingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminCarPricingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.v = id;
            var client = _httpClientFactory.CreateClient("CarBookClient");
            var response = await client.GetAsync($"https://localhost:7131/api/CarPricings/GetAllCarPricingsWithCarByCarID/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultCarPricingByCarDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(UpdateCarPricingDto updateCarPricingDto)
        {
            var client = _httpClientFactory.CreateClient("CarBookClient");
            var jsonData = JsonConvert.SerializeObject(updateCarPricingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PutAsync("https://localhost:7131/api/CarPricings/UpdateCarPricing", stringContent);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminCar", new { area = "" });
            }
            return View();
        }
    }
}