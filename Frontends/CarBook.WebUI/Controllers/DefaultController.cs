using CarBook.Dto.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7131/api/Locations/GetAllLocation");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
                List<SelectListItem> locationValues = (from item in values
                                                    select new SelectListItem
                                                    {
                                                        Text = item.Name,
                                                        Value = item.LocationID.ToString()
                                                    }).ToList();
                ViewBag.locationValues = locationValues;
            }
            return View();
        }
        [HttpPost]
        public IActionResult Index(string p)
        {
            TempData["value"] = p;
            return RedirectToAction("Index", "RentACarList");
        }
    }
}
