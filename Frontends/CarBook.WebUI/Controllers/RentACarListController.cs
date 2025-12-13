using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.v = TempData["value"];
            return View();
        }
    }
}
