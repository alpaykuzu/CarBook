using CarBook.Dto.ReservationDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

[Authorize(Roles = "Admin")]
[Area("Admin")]
[Route("Admin/AdminReservation")]
public class AdminReservationController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    public AdminReservationController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient("CarBookClient");
        var response = await client.GetAsync("https://localhost:7131/api/Reservations/GetAllReservation");

        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultReservationDto>>(jsonData);
            return View(values);
        }
        return View();
    }

    [Route("ApproveReservation/{id}")]
    public async Task<IActionResult> ApproveReservation(int id)
    {
        var client = _httpClientFactory.CreateClient("CarBookClient");
        // API tarafında bu işlemin durumu güncellediğinden emin olun
        var response = await client.GetAsync($"https://localhost:7131/api/Reservations/ApproveReservation/{id}");

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return RedirectToAction("Index");
    }
}