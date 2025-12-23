using CarBook.Application.Features.Abouts.Commands.CreateAbout;
using CarBook.Application.Features.Abouts.Commands.RemoveAbout;
using CarBook.Application.Features.Abouts.Commands.UpdateAbout;
using CarBook.Application.Features.Abouts.Queries.GetAllAbout;
using CarBook.Application.Features.Abouts.Queries.GetByIdAbout;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly GetAllAboutQueryHandler _getAllAboutQueryHandler;
        private readonly GetByIdAboutQueryHandler _getByIdAboutQueryHandler;
        private readonly UpdateAboutCommandHandler _updateAboutCommandHandler;
        private readonly CreateAboutCommandHandler _createAboutCommandHandler;
        private readonly RemoveAboutCommandHandler _removeAboutCommandHandler;

        public AboutsController(GetAllAboutQueryHandler getAllAboutQueryHandler, GetByIdAboutQueryHandler getByIdAboutQueryHandler, UpdateAboutCommandHandler updateAboutCommandHandler, CreateAboutCommandHandler createAboutCommandHandler, RemoveAboutCommandHandler removeAboutCommandHandler)
        {
            _getAllAboutQueryHandler = getAllAboutQueryHandler;
            _getByIdAboutQueryHandler = getByIdAboutQueryHandler;
            _updateAboutCommandHandler = updateAboutCommandHandler;
            _createAboutCommandHandler = createAboutCommandHandler;
            _removeAboutCommandHandler = removeAboutCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAbout()
        {
            return Ok(await _getAllAboutQueryHandler.Handle());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAbout(int id)
        {
            return Ok(await _getByIdAboutQueryHandler.Handle(new GetByIdAboutQueryRequest(id)));
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateAbout([FromBody] CreateAboutCommandRequest request)
        {
            await _createAboutCommandHandler.Handle(request);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateAbout([FromBody] UpdateAboutCommandRequest request)
        {
            await _updateAboutCommandHandler.Handle(request);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAbout(int id)
        {
            await _removeAboutCommandHandler.Handle(new RemoveAboutCommandRequest(id));
            return Ok();
        }
    }
}
