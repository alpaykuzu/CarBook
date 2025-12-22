using CarBook.Dto.LocationDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/AdminLocation")]
    public class AdminLocationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminLocationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7131/api/Locations/GetAllLocation");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        [Route("CreateLocation")]
        public IActionResult CreateLocation()
        {
            return View();
        }
        [HttpPost]
        [Route("CreateLocation")]
        public async Task<IActionResult> CreateLocation(CreateLocationDto createLocationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createLocationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7131/api/Locations/CreateLocation", stringContent);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminLocation", new { area = "Admin" });
            }
            return View();
        }
        [Route("RemoveLocation/{id}")]
        public async Task<IActionResult> RemoveLocation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7131/api/Locations/RemoveLocation/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminLocation", new { area = "Admin" });
            }
            return View();
        }
        [HttpGet]
        [Route("UpdateLocation/{id}")]

        public async Task<IActionResult> UpdateLocation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseLocation = await client.GetAsync($"https://localhost:7131/api/Locations/GetByIdLocation/{id}");

            if (responseLocation.IsSuccessStatusCode)
            {
                var jsonData = await responseLocation.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateLocationDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        [Route("UpdateLocation/{id}")]
        public async Task<IActionResult> UpdateLocation(UpdateLocationDto updateLocationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateLocationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PutAsync("https://localhost:7131/api/Locations/UpdateLocation", stringContent);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminLocation", new { area = "Admin" });
            }
            return View();
        }
    }
}
