using CarBook.Application.Features.FooterAddresses.Commands.CreateFooterAddress;
using CarBook.Application.Features.FooterAddresses.Commands.RemoveFooterAddress;
using CarBook.Application.Features.FooterAddresses.Commands.UpdateFooterAddress;
using CarBook.Application.Features.FooterAddresses.Queries.GetAllFooterAddress;
using CarBook.Application.Features.FooterAddresses.Queries.GetByIdFooterAddress;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FooterAddressesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FooterAddressesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllFooterAddress()
        {
            return Ok(await _mediator.Send(new GetAllFooterAddressQueryRequest()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdFooterAddress(int id)
        {
            return Ok(await _mediator.Send(new GetByIdFooterAddressQueryRequest(id)));
        }
        [HttpPost]
        public async Task<IActionResult> CreateFooterAddress([FromBody] CreateFooterAddressCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFooterAddress([FromBody] UpdateFooterAddressCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveFooterAddress(int id)
        {
            await _mediator.Send(new RemoveFooterAddressCommandRequest(id));
            return Ok();
        }
    }
}
