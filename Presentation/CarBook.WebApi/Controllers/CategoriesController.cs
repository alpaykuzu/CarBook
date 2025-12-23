using CarBook.Application.Features.Categories.Commands.CreateCategory;
using CarBook.Application.Features.Categories.Commands.RemoveCategory;
using CarBook.Application.Features.Categories.Commands.UpdateCategory;
using CarBook.Application.Features.Categories.Queries.GetAllCategory;
using CarBook.Application.Features.Categories.Queries.GetByIdCategory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly GetAllCategoryQueryHandler _getAllCategoryQueryHandler;
        private readonly GetByIdCategoryQueryHandler _getByIdCategoryQueryHandler;
        private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
        private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;
        private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;

        public CategoriesController(GetAllCategoryQueryHandler getAllCategoryQueryHandler, GetByIdCategoryQueryHandler getByIdCategoryQueryHandler, CreateCategoryCommandHandler createCategoryCommandHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler)
        {
            _getAllCategoryQueryHandler = getAllCategoryQueryHandler;
            _getByIdCategoryQueryHandler = getByIdCategoryQueryHandler;
            _createCategoryCommandHandler = createCategoryCommandHandler;
            _updateCategoryCommandHandler = updateCategoryCommandHandler;
            _removeCategoryCommandHandler = removeCategoryCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            return Ok(await _getAllCategoryQueryHandler.Handle());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCategory(int id)
        {
            return Ok(await _getByIdCategoryQueryHandler.Handle(new GetByIdCategoryQueryRequest(id)));
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommandRequest request)
        {
            await _createCategoryCommandHandler.Handle(request);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryCommandRequest request)
        {
            await _updateCategoryCommandHandler.Handle(request);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommandRequest(id));
            return Ok();
        }
    }
}
