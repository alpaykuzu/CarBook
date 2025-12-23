using CarBook.Application.Features.CarPricings.Commands.CreateCarPricing;
using CarBook.Application.Features.CarPricings.Commands.UpdateCarPricing;
using CarBook.Application.Features.CarPricings.Queries.GetAllCarPricingsWithCar;
using CarBook.Application.Features.CarPricings.Queries.GetCarPricingByCar;
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
        [HttpGet("{carID}")]
        public async Task<IActionResult> GetAllCarPricingsWithCarByCarID(int carID)
        {
            return Ok(await mediator.Send(new GetCarPricingByCarQueryRequest(carID)));
        }
        [HttpPost]
        public async Task<IActionResult> CreateCarPricing([FromBody] CreateCarPricingCommandRequest createCarPricingCommandRequest)
        {
            await mediator.Send(createCarPricingCommandRequest);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCarPricing([FromBody] UpdateCarPricingCommandRequest updateCarPricingCommandRequest)
        {
            await mediator.Send(updateCarPricingCommandRequest);
            return Ok();
        }
    }
}
