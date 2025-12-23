using CarBook.Application.Features.CarFeatures.Commands.CreateCarFeature;
using CarBook.Application.Features.CarFeatures.Commands.DeleteCarFeature;
using CarBook.Application.Features.CarFeatures.Commands.UpdateCarFeature;
using CarBook.Application.Features.CarFeatures.Queries.GetCarFeatureByCar;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private readonly IMediator mediator;

        public CarFeaturesController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarFeatureByCar(int id)
        {
            return Ok(await mediator.Send(new GetCarFeatureByCarQueryRequest(id)));
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateCarFeature([FromBody] CreateCarFeatureCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCarFeature(int id)
        {
            await mediator.Send(new DeleteCarFeatureCommandRequest(id));
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateCarFeature([FromBody] UpdateCarFeatureCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
