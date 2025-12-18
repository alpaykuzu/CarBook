using CarBook.Dto.BlogDtos;
using CarBook.Dto.CommentDtos;
using CarBook.Dto.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsMainComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _BlogDetailsMainComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7131/api/Blogs/GetByIdBlog/{id}");
            ViewBag.blogId = id;

            var response2 = await client.GetAsync($"https://localhost:7131/api/Comments/GetCommentCountByBlog/{id}");

            if (response2.IsSuccessStatusCode)
            {
                var jsonData = await response2.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultCommentCountDto>(jsonData);
                ViewBag.commentCount = values.CommentCount;
            }

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultBlogDto>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
