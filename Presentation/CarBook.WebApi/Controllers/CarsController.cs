using CarBook.Application.Features.Cars.Commands.CreateCar;
using CarBook.Application.Features.Cars.Commands.RemoveCar;
using CarBook.Application.Features.Cars.Commands.UpdateCar;
using CarBook.Application.Features.Cars.Queries.GetAllCar;
using CarBook.Application.Features.Cars.Queries.GetByIdCar;
using CarBook.Application.Features.Cars.Queries.GetCarWithBrand;
using CarBook.Application.Features.Cars.Queries.GetCarWithPricing;
using CarBook.Application.Features.Cars.Queries.GetLastCarWithBrand;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly GetAllCarQueryHandler _getAllCarQueryHandler;
        private readonly GetByIdCarQueryHandler _getByIdCarQueryHandler;
        private readonly CreateCarCommandHandler _createCarCommandHandler;
        private readonly UpdateCarCommandHandler _updateCarCommandHandler;
        private readonly RemoveCarCommandHandler _removeCarCommandHandler;
        private readonly GetAllCarWithBrandQueryHandler _getCarWithBrandQueryHandler;
        private readonly GetLastCarWithBrandQueryHandler _getLastCarWithBrandQueryHandler;
        private readonly GetAllCarWithPricingQueryHandler _getCarWithPricingQueryHandler;

        public CarsController(GetAllCarQueryHandler getAllCarQueryHandler, GetByIdCarQueryHandler getByIdCarQueryHandler, CreateCarCommandHandler createCarCommandHandler, UpdateCarCommandHandler updateCarCommandHandler, RemoveCarCommandHandler removeCarCommandHandler, GetAllCarWithBrandQueryHandler getCarWithBrandQueryHandler, GetLastCarWithBrandQueryHandler getLastCarWithBrandQueryHandler, GetAllCarWithPricingQueryHandler getCarWithPricingQueryHandler)
        {
            _getAllCarQueryHandler = getAllCarQueryHandler;
            _getByIdCarQueryHandler = getByIdCarQueryHandler;
            _createCarCommandHandler = createCarCommandHandler;
            _updateCarCommandHandler = updateCarCommandHandler;
            _removeCarCommandHandler = removeCarCommandHandler;
            _getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
            _getLastCarWithBrandQueryHandler = getLastCarWithBrandQueryHandler;
            _getCarWithPricingQueryHandler = getCarWithPricingQueryHandler;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCar()
        {
            return Ok(await _getAllCarQueryHandler.Handle());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCar(int id)
        {
            return Ok(await _getByIdCarQueryHandler.Handle(new GetByIdCarQueryRequest(id)));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCarWithBrand()
        {
            return Ok(await _getCarWithBrandQueryHandler.Handle());
        }
        [HttpGet("{pricingType}")]
        public async Task<IActionResult> GetAllCarWithPricing(string pricingType)
        {
            return Ok(await _getCarWithPricingQueryHandler.Handle(new GetAllCarWithPricingQueryRequest(pricingType)));
        }
        [HttpGet("{number}")]
        public async Task<IActionResult> GetLastCarWithBrand(int number)
        {
            return Ok(await _getLastCarWithBrandQueryHandler.Handle(new GetLastCarWithBrandQueryRequest(number)));
        }
        [HttpPost]
        public async Task<IActionResult> CreateCar([FromBody] CreateCarCommandRequest request)
        {
            await _createCarCommandHandler.Handle(request);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCar([FromBody] UpdateCarCommandRequest request)
        {
            await _updateCarCommandHandler.Handle(request);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCar(int id)
        {
            await _removeCarCommandHandler.Handle(new RemoveCarCommandRequest(id));
            return Ok();
        }
    }
}
