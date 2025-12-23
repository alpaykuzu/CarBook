using CarBook.Dto.LocationDtos;
using CarBook.Dto.ReservationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.v1 = "Araç Kiralama";
            ViewBag.v2 = "Araç Rezervasyon Formu";
            ViewBag.carID = id;

            if (TempData["book_pick_date"] != null)
            {
                ViewBag.book_pick_date = DateTime.Parse(TempData["book_pick_date"].ToString()).ToString("yyyy-MM-dd");
            }

            if (TempData["book_off_date"] != null)
            {
                ViewBag.book_off_date = DateTime.Parse(TempData["book_off_date"].ToString()).ToString("yyyy-MM-dd");
            }
            ViewBag.time_pick = TempData["time_pick"];
            ViewBag.time_off = TempData["time_off"];
            ViewBag.locationID = TempData["locationID"];

            TempData.Keep();

            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == System.Security.Claims.ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.userID = userIdClaim.Value;

            var client = _httpClientFactory.CreateClient("CarBookClient");
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
        public async Task<IActionResult> Index(CreateReservationDto createReservationDto)
        {
            var client = _httpClientFactory.CreateClient("CarBookClient");
            var jsonData = JsonConvert.SerializeObject(createReservationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7131/api/Reservations/CreateReservation", stringContent);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
