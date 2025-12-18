using CarBook.Dto.BannerDtos;
using CarBook.Dto.BrandDtos;
using CarBook.Dto.CarDtos;
using CarBook.Dto.CarFeatureDtos;
using CarBook.Dto.FeatureDtos;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminCarFeature")]
    public class AdminCarFeatureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        int carID;

        public AdminCarFeatureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index/{id}")]
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.carID = id;
            carID = id;
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7131/api/CarFeatures/GetCarFeatureByCar/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarFeatureDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [Route("UpdateCarFeature")]
        [HttpPost]
        public async Task<IActionResult> UpdateCarFeature([FromBody] UpdateCarFeatureDto updateFeatureDto)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(updateFeatureDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PutAsync(
                "https://localhost:7131/api/CarFeatures/UpdateCarFeature",
                content
            );

            if (response.IsSuccessStatusCode)
                return Ok();

            return BadRequest();
        }
        [HttpGet]
        [Route("CreateCarFeature/{id}")]
        public async Task<IActionResult> CreateCarFeature(int id)
        {
            ViewBag.carID = id;
            ViewBag.available = true;
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7131/api/Features/GetAllFeature");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);

                List<SelectListItem> featureValues = (from item in values
                                                      select new SelectListItem
                                                      {
                                                          Text = item.Name,
                                                          Value = item.FeatureID.ToString()
                                                      }).ToList();
                ViewBag.featureValues = featureValues;
                return View();
            }
            return View();
        }
        [HttpPost]
        [Route("CreateCarFeature/{id}")]
        public async Task<IActionResult> CreateCarFeature(CreateCarFeatureDto createCarFeatureDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCarFeatureDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7131/api/CarFeatures/CreateCarFeature", stringContent);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(
                    "Index",
                    "AdminCarFeature",
                    new { area = "Admin", id = createCarFeatureDto.CarID }
                );

            }
            return View();
        }
        [Route("RemoveCarFeature/{id}")]
        public async Task<IActionResult> RemoveCarFeature(int id, int carId)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync(
                $"https://localhost:7131/api/CarFeatures/RemoveCarFeature/{id}"
            );

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(
                    "Index",
                    "AdminCarFeature",
                    new { area = "Admin", id = carId }
                );
            }

            return View();
        }

    }
}
