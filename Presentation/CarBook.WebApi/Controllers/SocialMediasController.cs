using CarBook.Application.Features.SocialMedias.Commands.CreateSocialMedia;
using CarBook.Application.Features.SocialMedias.Commands.RemoveSocialMedia;
using CarBook.Application.Features.SocialMedias.Commands.UpdateSocialMedia;
using CarBook.Application.Features.SocialMedias.Queries.GetAllSocialMedia;
using CarBook.Application.Features.SocialMedias.Queries.GetByIdSocialMedia;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SocialMediasController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SocialMediasController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSocialMedia()
        {
            return Ok(await _mediator.Send(new GetAllSocialMediaQueryRequest()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdSocialMedia(int id)
        {
            return Ok(await _mediator.Send(new GetByIdSocialMediaQueryRequest(id)));
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateSocialMedia([FromBody] CreateSocialMediaCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateSocialMedia([FromBody] UpdateSocialMediaCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveSocialMedia(int id)
        {
            await _mediator.Send(new RemoveSocialMediaCommandRequest(id));
            return Ok();
        }
    }
}
