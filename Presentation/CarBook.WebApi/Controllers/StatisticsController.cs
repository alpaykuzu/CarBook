using CarBook.Application.Features.Statistics.Queries.GetAuthorCount;
using CarBook.Application.Features.Statistics.Queries.GetAvarageCarPricing;
using CarBook.Application.Features.Statistics.Queries.GetBlogCount;
using CarBook.Application.Features.Statistics.Queries.GetBrandCount;
using CarBook.Application.Features.Statistics.Queries.GetCarByCarPricing;
using CarBook.Application.Features.Statistics.Queries.GetCarByFuel;
using CarBook.Application.Features.Statistics.Queries.GetCarCount;
using CarBook.Application.Features.Statistics.Queries.GetCarCountByTransmission;
using CarBook.Application.Features.Statistics.Queries.GetCarOrderByKm;
using CarBook.Application.Features.Statistics.Queries.GetLocationCount;
using CarBook.Application.Features.Statistics.Queries.GetMostBlogComment;
using CarBook.Application.Features.Statistics.Queries.GetMostCarBrand;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IMediator mediator;

        public StatisticsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]  
        public async Task<IActionResult> GetCarCount()
        {
            return Ok(await mediator.Send(new GetCarCountQueryRequest()));
        }
        [HttpGet]
        public async Task<IActionResult> GetLocationCount()
        {
            return Ok(await mediator.Send(new GetLocationCountQueryRequest()));
        }
        [HttpGet]
        public async Task<IActionResult> GetAuthorCount()
        {
            return Ok(await mediator.Send(new GetAuthorCountQueryRequest()));
        }
        [HttpGet]
        public async Task<IActionResult> GetBlogCount()
        {
            return Ok(await mediator.Send(new GetBlogCountQueryRequest()));
        }
        [HttpGet]
        public async Task<IActionResult> GetBrandCount()
        {
            return Ok(await mediator.Send(new GetBrandCountQueryRequest()));
        }
        [HttpGet("{pricingType}")]
        public async Task<IActionResult> GetAvarageCarPricing(string pricingType)
        {
            return Ok(await mediator.Send(new GetAvarageCarPricingQueryRequest(pricingType)));
        }
        [HttpGet]
        public async Task<IActionResult> GetMostBrandWithCar()
        {
            return Ok(await mediator.Send(new GetMostCarBrandQueryRequest()));
        }
        [HttpGet("{transmissionType}")]
        public async Task<IActionResult> GetCarCountByTransmission(string transmissionType)
        {
            return Ok(await mediator.Send(new GetCarCountByTransmissionQueryRequest(transmissionType)));
        }
        [HttpGet]
        public async Task<IActionResult> GetMostBlogWithComment()
        {
            return Ok(await mediator.Send(new GetMostBlogCommentQueryRequest()));
        }
        [HttpGet("{topKm}")]
        public async Task<IActionResult> GetCarCountByKm(int topKm)
        {
            return Ok(await mediator.Send(new GetCarCountByKmQueryRequest(topKm)));
        }
        [HttpGet("{fuelType}")]
        public async Task<IActionResult> GetCarCountByFuel(string fuelType)
        {
            return Ok(await mediator.Send(new GetCarCountByFuelQueryRequest(fuelType)));
        }
        [HttpGet]
        public async Task<IActionResult> GetCarByCarPricing([FromQuery] GetCarByCarPricingQueryRequest request)
        {
            return Ok(await mediator.Send(request));
        }
    }
}
