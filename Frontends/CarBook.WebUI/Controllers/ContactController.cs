using CarBook.Dto.ContactDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]   
        public IActionResult Index()
        {
            ViewBag.v1 = "İletişim";
            ViewBag.v2 = "Bize Ulaşın";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient("CarBookClient");
                createContactDto.SendDate = DateTime.UtcNow;
                var jsonData = JsonConvert.SerializeObject(createContactDto);
                StringContent content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync("https://localhost:7131/api/Contacts/CreateContact", content);
                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Your message has been sent successfully.";
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while sending your message. Please try again later.");
                }
            }
            return View();
        }
    }
}
