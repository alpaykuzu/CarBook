using CarBook.Application.Features.Brands.Commands.CreateBrand;
using CarBook.Application.Features.Brands.Commands.RemoveBrand;
using CarBook.Application.Features.Brands.Commands.UpdateBrand;
using CarBook.Application.Features.Brands.Queries.GetAllBrand;
using CarBook.Application.Features.Brands.Queries.GetByIdBrand;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly GetAllBrandQueryHandler _getAllBrandQueryHandler;
        private readonly GetByIdBrandQueryHandler _getByIdBrandQueryHandler;
        private readonly CreateBrandCommandHandler _createBrandCommandHandler;
        private readonly UpdateBrandCommandHandler _updateBrandCommandHandler;
        private readonly RemoveBrandCommandHandler _removeBrandCommandHandler;

        public BrandsController(GetAllBrandQueryHandler getAllBrandQueryHandler, GetByIdBrandQueryHandler getByIdBrandQueryHandler, CreateBrandCommandHandler createBrandCommandHandler, UpdateBrandCommandHandler updateBrandCommandHandler, RemoveBrandCommandHandler removeBrandCommandHandler)
        {
            _getAllBrandQueryHandler = getAllBrandQueryHandler;
            _getByIdBrandQueryHandler = getByIdBrandQueryHandler;
            _createBrandCommandHandler = createBrandCommandHandler;
            _updateBrandCommandHandler = updateBrandCommandHandler;
            _removeBrandCommandHandler = removeBrandCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBrand()
        {
            return Ok(await _getAllBrandQueryHandler.Handle());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdBrand(int id)
        {
            return Ok(await _getByIdBrandQueryHandler.Handle(new GetByIdBrandQueryRequest(id)));
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateBrand([FromBody] CreateBrandCommandRequest request)
        {
            await _createBrandCommandHandler.Handle(request);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateBrand([FromBody] UpdateBrandCommandRequest request)
        {
            await _updateBrandCommandHandler.Handle(request);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBrand(int id)
        {
            await _removeBrandCommandHandler.Handle(new RemoveBrandCommandRequest(id));
            return Ok();
        }
    }
}
