using CarBook.Application.Features.TagClouds.Commands.CreateTagCloud;
using CarBook.Application.Features.TagClouds.Commands.RemoveTagCloud;
using CarBook.Application.Features.TagClouds.Commands.UpdateTagCloud;
using CarBook.Application.Features.TagClouds.Queries.GetAllTagCloud;
using CarBook.Application.Features.TagClouds.Queries.GetByBlogIdTagCloud;
using CarBook.Application.Features.TagClouds.Queries.GetByIdTagCloud;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TagCloudsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TagCloudsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTagCloud()
        {
            return Ok(await _mediator.Send(new GetAllTagCloudQueryRequest()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdTagCloud(int id)
        {
            return Ok(await _mediator.Send(new GetByIdTagCloudQueryRequest(id)));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByBlogIdTagCloud(int id)
        {
            return Ok(await _mediator.Send(new GetByBlogIdTagCloudQueryRequest(id)));
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateTagCloud([FromBody] CreateTagCloudCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateTagCloud([FromBody] UpdateTagCloudCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveTagCloud(int id)
        {
            await _mediator.Send(new RemoveTagCloudCommandRequest(id));
            return Ok();
        }
    }
}
