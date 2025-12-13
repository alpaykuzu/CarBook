using CarBook.Application.Features.RentACars.Queries.GetRentACarByLocationAndAvailable;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RentACarsController : ControllerBase
    {
        private readonly IMediator mediator;

        public RentACarsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet("{locationID}")]
        public async Task<IActionResult> GetByLocationRentACar(int locationID)
        {
            return Ok(await mediator.Send(new GetRentACarByLocationAndAvailableQueryRequest(locationID)));
        }
    }
}
