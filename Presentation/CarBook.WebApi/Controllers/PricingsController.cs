using CarBook.Application.Features.Pricings.Commands.CreatePricing;
using CarBook.Application.Features.Pricings.Commands.RemovePricing;
using CarBook.Application.Features.Pricings.Commands.UpdatePricing;
using CarBook.Application.Features.Pricings.Queries.GetAllPricing;
using CarBook.Application.Features.Pricings.Queries.GetByIdPricing;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PricingsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPricing()
        {
            return Ok(await _mediator.Send(new GetAllPricingQueryRequest()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdPricing(int id)
        {
            return Ok(await _mediator.Send(new GetByIdPricingQueryRequest(id)));
        }
        [HttpPost]
        public async Task<IActionResult> CreatePricing([FromBody] CreatePricingCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePricing([FromBody] UpdatePricingCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemovePricing(int id)
        {
            await _mediator.Send(new RemovePricingCommandRequest(id));
            return Ok();
        }
    }
}
