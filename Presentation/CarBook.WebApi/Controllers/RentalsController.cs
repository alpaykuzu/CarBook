using CarBook.Application.Features.Rentals.Queries.GetAllRental;
using CarBook.Application.Features.Rentals.Queries.GetRentalByAppUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RentalsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRentals()
        {
            return Ok(await _mediator.Send(new GetAllRentalQueryRequest()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRentalByAppUser(int id)
        {
            return Ok(await _mediator.Send(new GetRentalByAppUserQueryRequest(id)));
        }
    }
}
