using CarBook.Dto.RentalDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace CarBook.WebUI.Controllers
{
    public class RentalController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public RentalController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Kiralamalarım";
            ViewBag.v2 = "Onaylanmış Kiralama Geçmişiniz";

            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var client = _httpClientFactory.CreateClient("CarBookClient");
            var response = await client.GetAsync($"https://localhost:7131/api/Rentals/GetRentalByAppUser/{userId}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultRentalDto>>(jsonData);
                return View(values);
            }

            return View(new List<ResultRentalDto>());
        }
    }
}