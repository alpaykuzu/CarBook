using CarBook.Application.Features.Blogs.Commands.CreateBlog;
using CarBook.Application.Features.Blogs.Commands.RemoveBlog;
using CarBook.Application.Features.Blogs.Commands.UpdateBlog;
using CarBook.Application.Features.Blogs.Queries.GetAllBlog;
using CarBook.Application.Features.Blogs.Queries.GetByIdBlog;
using CarBook.Application.Features.Blogs.Queries.GetByIdBlogWithAuthor;
using CarBook.Application.Features.Blogs.Queries.GetLastBlogsWithAuthors;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BlogsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBlog()
        {
            return Ok(await _mediator.Send(new GetAllBlogQueryRequest()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdBlog(int id)
        {
            return Ok(await _mediator.Send(new GetByIdBlogQueryRequest(id)));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdBlogWithAuthor(int id)
        {
            return Ok(await _mediator.Send(new GetByIdBlogWithAuthorQueryRequest(id)));
        }
        [HttpGet]
        public async Task<IActionResult> GetLastNBlog(int number)
        {
            return Ok(await _mediator.Send(new GetLastBlogsWithAuthorsQueryRequest(number)));
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlog([FromBody] CreateBlogCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBlog([FromBody] UpdateBlogCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBlog(int id)
        {
            await _mediator.Send(new RemoveBlogCommandRequest(id));
            return Ok();
        }
    }
}
