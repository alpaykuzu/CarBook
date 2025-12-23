using CarBook.Dto.BlogDtos;
using CarBook.Dto.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class BlogDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BlogDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index(int id)
        {
            ViewBag.v1 = "Bloglar";
            ViewBag.v2 = "Blog Detayı ve Yorumlar";
            ViewBag.blogId = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto)
        {
            var client = _httpClientFactory.CreateClient("CarBookClient");

            var jsonData = JsonConvert.SerializeObject(createCommentDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            await client.PostAsync(
                "https://localhost:7131/api/Comments/CreateComment",
                content);

            return RedirectToAction("Index", "BlogDetail",
                new { id = createCommentDto.BlogID });
        }
    }
}
