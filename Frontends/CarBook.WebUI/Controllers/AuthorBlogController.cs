using CarBook.Dto.BlogDtos;
using CarBook.Dto.BrandDtos;
using CarBook.Dto.CarDtos;
using CarBook.Dto.CategoryDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    [Authorize(Roles = "Author")]
    public class AuthorBlogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AuthorBlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Bloglar";
            ViewBag.v2 = "Bloglarım";
            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == System.Security.Claims.ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var userId = userIdClaim.Value; 
            var client = _httpClientFactory.CreateClient("CarBookClient");

            var response = await client.GetAsync($"https://localhost:7131/api/Blogs/GetBlogsByAuthor/{userId}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBlogWithAuthorDto>>(jsonData);
                ViewBag.AuthorID = values[0].AuthorID;
                return View(values);
            }

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateBlog(int id)
        {
            ViewBag.v1 = "Bloglarım";
            ViewBag.v2 = "Yeni Blog Yayınla";
            ViewBag.AuthorID = id;
            var client = _httpClientFactory.CreateClient("CarBookClient");
            var response = await client.GetAsync("https://localhost:7131/api/Categories/GetAllCategory");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

                List<SelectListItem> categoryValues = (from item in values
                                                    select new SelectListItem
                                                    {
                                                        Text = item.Name,
                                                        Value = item.CategoryID.ToString()
                                                    }).ToList();
                ViewBag.categoryValues = categoryValues;
                return View();
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogDto createBlogDto)
        {
            var client = _httpClientFactory.CreateClient("CarBookClient");
            var jsonData = JsonConvert.SerializeObject(createBlogDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7131/api/Blogs/CreateBlog", stringContent);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> RemoveBlog(int id)
        {
            var client = _httpClientFactory.CreateClient("CarBookClient");
            var response = await client.DeleteAsync($"https://localhost:7131/api/Blogs/RemoveBlog/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateBlog(int id)
        {
            ViewBag.v1 = "Bloglarım";
            ViewBag.v2 = "Bloğunu Güncelle";
            var client = _httpClientFactory.CreateClient("CarBookClient");

            var responseBrand = await client.GetAsync("https://localhost:7131/api/Categories/GetAllCategory");

            if (responseBrand.IsSuccessStatusCode)
            {
                var jsonData = await responseBrand.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

                List<SelectListItem> categoryValues = (from item in values
                                                    select new SelectListItem
                                                    {
                                                        Text = item.Name,
                                                        Value = item.CategoryID.ToString()
                                                    }).ToList();
                ViewBag.categoryValues = categoryValues;
            }

            var responseCar = await client.GetAsync($"https://localhost:7131/api/Blogs/GetByIdBlog/{id}");

            if (responseCar.IsSuccessStatusCode)
            {
                var jsonData = await responseCar.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBlogDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBlog(UpdateBlogDto updateBlogDto)
        {
            var client = _httpClientFactory.CreateClient("CarBookClient");
            var jsonData = JsonConvert.SerializeObject(updateBlogDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PutAsync("https://localhost:7131/api/Blogs/UpdateBlog", stringContent);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(updateBlogDto);
        }
    }
}

