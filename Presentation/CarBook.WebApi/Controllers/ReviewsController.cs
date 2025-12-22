using CarBook.Application.Features.Reviews.Commands.CreateReview;
using CarBook.Application.Features.Reviews.Queries.GetReviewsByCar;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ReviewsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet("{carID}")]
        public async Task<IActionResult> GetReviewByCar(int carID)
        {
            var result = await mediator.Send(new GetReviewsByCarQueryRequest(carID));
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] CreateReviewCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
