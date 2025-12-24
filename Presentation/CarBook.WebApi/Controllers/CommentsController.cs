using CarBook.Application.Features.Comments.Commands.CreateComment;
using CarBook.Application.Features.Comments.Commands.RemoveComment;
using CarBook.Application.Features.Comments.Commands.UpdateComment;
using CarBook.Application.Features.Comments.Queries.GetAllComment;
using CarBook.Application.Features.Comments.Queries.GetAllCommentByBlog;
using CarBook.Application.Features.Comments.Queries.GetCommentCountByBlog;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllComment()
        {
            return Ok(await _mediator.Send(new GetAllCommentQueryRequest()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllCommentByBlog(int id)
        {
            return Ok(await _mediator.Send(new GetAllCommentByBlogQueryRequest(id)));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentCountByBlog(int id)
        {
            return Ok(await _mediator.Send(new GetCommentCountByBlogQueryRequest(id)));
        }
        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateComment([FromBody] UpdateCommentCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveComment(int id)
        {
            await _mediator.Send(new RemoveCommentCommandRequest(id));
            return Ok();
        }
    }
}
