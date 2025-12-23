using CarBook.Application.Features.Features.Commands.CreateFeature;
using CarBook.Application.Features.Features.Commands.RemoveFeature;
using CarBook.Application.Features.Features.Commands.UpdateFeature;
using CarBook.Application.Features.Features.Queries.GetAllFeature;
using CarBook.Application.Features.Features.Queries.GetByIdFeature;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllFeature()
        {
            return Ok(await _mediator.Send(new GetAllFeatureQueryRequest()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdFeature(int id)
        {
            return Ok(await _mediator.Send(new GetByIdFeatureQueryRequest(id)));
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateFeature([FromBody] CreateFeatureCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateFeature([FromBody] UpdateFeatureCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveFeature(int id)
        {
            await _mediator.Send(new RemoveFeatureCommandRequest(id));
            return Ok();
        }
    }
}
