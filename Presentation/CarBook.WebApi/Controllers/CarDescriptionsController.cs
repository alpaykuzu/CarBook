using CarBook.Application.Features.CarDescriptions.Queries.GetCarDescriptionByCar;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarDescriptionsController : ControllerBase
    {
        private readonly IMediator mediator;

        public CarDescriptionsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet("{carID}")]
        public async Task<IActionResult> GetCarDescriptionByCar(int carID)
        {
            var result = await mediator.Send(new GetCarDescriptionByCarQueryRequest(carID));
            return Ok(result);
        }
    }
}
