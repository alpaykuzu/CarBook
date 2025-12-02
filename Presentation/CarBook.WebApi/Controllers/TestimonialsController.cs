using CarBook.Application.Features.Testimonials.Commands.CreateTestimonial;
using CarBook.Application.Features.Testimonials.Commands.RemoveTestimonial;
using CarBook.Application.Features.Testimonials.Commands.UpdateTestimonial;
using CarBook.Application.Features.Testimonials.Queries.GetAllTestimonial;
using CarBook.Application.Features.Testimonials.Queries.GetByIdTestimonial;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TestimonialsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTestimonial()
        {
            return Ok(await _mediator.Send(new GetAllTestimonialQueryRequest()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdTestimonial(int id)
        {
            return Ok(await _mediator.Send(new GetByIdTestimonialQueryRequest(id)));
        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial([FromBody] CreateTestimonialCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTestimonial([FromBody] UpdateTestimonialCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveTestimonial(int id)
        {
            await _mediator.Send(new RemoveTestimonialCommandRequest(id));
            return Ok();
        }
    }
}
