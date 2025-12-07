using CarBook.Application.Features.Authors.Commands.CreateAuthor;
using CarBook.Application.Features.Authors.Commands.RemoveAuthor;
using CarBook.Application.Features.Authors.Commands.UpdateAuthor;
using CarBook.Application.Features.Authors.Queries.GetAllAuthor;
using CarBook.Application.Features.Authors.Queries.GetByIdAuthor;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAuthor()
        {
            return Ok(await _mediator.Send(new GetAllAuthorQueryRequest()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAuthor(int id)
        {
            return Ok(await _mediator.Send(new GetByIdAuthorQueryRequest(id)));
        }
        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] CreateAuthorCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAuthor([FromBody] UpdateAuthorCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAuthor(int id)
        {
            await _mediator.Send(new RemoveAuthorCommandRequest(id));
            return Ok();
        }
    }
}
