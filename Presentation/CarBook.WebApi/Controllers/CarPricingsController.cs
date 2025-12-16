using CarBook.Application.Features.CarPricings.Queries.GetAllCarPricingsWithCar;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarPricingsController : ControllerBase
    {
        private readonly IMediator mediator;

        public CarPricingsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCarPricingsWithCar()
        {
            return Ok(await mediator.Send(new GetAllCarPricingsWithCarQueryRequest()));
        }
    }
}
