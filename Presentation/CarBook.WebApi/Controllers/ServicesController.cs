using CarBook.Application.Features.Services.Commands.CreateService;
using CarBook.Application.Features.Services.Commands.RemoveService;
using CarBook.Application.Features.Services.Commands.UpdateService;
using CarBook.Application.Features.Services.Queries.GetAllService;
using CarBook.Application.Features.Services.Queries.GetByIdService;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ServicesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllService()
        {
            return Ok(await _mediator.Send(new GetAllServiceQueryRequest()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdService(int id)
        {
            return Ok(await _mediator.Send(new GetByIdServiceQueryRequest(id)));
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateService([FromBody] CreateServiceCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateService([FromBody] UpdateServiceCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveService(int id)
        {
            await _mediator.Send(new RemoveServiceCommandRequest(id));
            return Ok();
        }
    }
}
