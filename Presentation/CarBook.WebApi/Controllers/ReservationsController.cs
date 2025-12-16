using CarBook.Application.Features.Reservations.Commands.CreateReservation;
using CarBook.Application.Features.Reservations.Queries.GetAllReservation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ReservationsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllReservation()
        {
            return Ok(await mediator.Send(new GetAllReservationQueryRequest()));
        }
        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] CreateReservationCommandQuery request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
