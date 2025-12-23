using CarBook.Dto.BrandDtos;
using CarBook.Dto.RentACarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RentACarListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Kiralama";
            ViewBag.v2 = "Araç Listesi";
            ViewBag.book_pick_date = TempData["book_pick_date"];
            ViewBag.book_off_date = TempData["book_off_date"];
            ViewBag.time_pick = TempData["time_pick"];
            ViewBag.time_off = TempData["time_off"];
            ViewBag.locationID = TempData["locationID"];

            TempData.Keep();

            var client = _httpClientFactory.CreateClient("CarBookClient");
            var response = await client.GetAsync($"https://localhost:7131/api/RentACars/GetByLocationRentACar?locationID={ViewBag.locationID}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultRentACarDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
