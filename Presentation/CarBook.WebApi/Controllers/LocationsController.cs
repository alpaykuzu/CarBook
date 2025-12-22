using CarBook.Application.Features.Locations.Commands.CreateLocation;
using CarBook.Application.Features.Locations.Commands.RemoveLocation;
using CarBook.Application.Features.Locations.Commands.UpdateLocation;
using CarBook.Application.Features.Locations.Queries.GetAllLocation;
using CarBook.Application.Features.Locations.Queries.GetByIdLocation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LocationsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllLocation()
        {
            return Ok(await _mediator.Send(new GetAllLocationQueryRequest()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdLocation(int id)
        {
            return Ok(await _mediator.Send(new GetByIdLocationQueryRequest(id)));
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateLocation([FromBody] CreateLocationCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateLocation([FromBody] UpdateLocationCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveLocation(int id)
        {
            await _mediator.Send(new RemoveLocationCommandRequest(id));
            return Ok();
        }
    }
}
