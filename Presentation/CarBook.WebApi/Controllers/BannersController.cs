using CarBook.Application.Features.Abouts.Commands.CreateAbout;
using CarBook.Application.Features.Abouts.Commands.RemoveAbout;
using CarBook.Application.Features.Abouts.Commands.UpdateAbout;
using CarBook.Application.Features.Abouts.Queries.GetAllAbout;
using CarBook.Application.Features.Abouts.Queries.GetByIdAbout;
using CarBook.Application.Features.Banners.Commands.CreateBanner;
using CarBook.Application.Features.Banners.Commands.RemoveBanner;
using CarBook.Application.Features.Banners.Commands.UpdateBanner;
using CarBook.Application.Features.Banners.Queries.GetAllBanner;
using CarBook.Application.Features.Banners.Queries.GetByIdBanner;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly GetAllBannerQueryHandler _getAllBannerQueryHandler;
        private readonly GetByIdBannerQueryHandler _getByIdBannerQueryHandler;
        private readonly CreateBannerCommandHandler _createBannerCommandHandler;
        private readonly UpdateBannerCommandHandler _updateBannerCommandHandler;
        private readonly RemoveBannerCommandHandler _removeBannerCommandHandler;

        public BannersController(GetAllBannerQueryHandler getAllBannerQueryHandler, GetByIdBannerQueryHandler getByIdBannerQueryHandler, CreateBannerCommandHandler createBannerCommandHandler, UpdateBannerCommandHandler updateBannerCommandHandler, RemoveBannerCommandHandler removeBannerCommandHandler)
        {
            _getAllBannerQueryHandler = getAllBannerQueryHandler;
            _getByIdBannerQueryHandler = getByIdBannerQueryHandler;
            _createBannerCommandHandler = createBannerCommandHandler;
            _updateBannerCommandHandler = updateBannerCommandHandler;
            _removeBannerCommandHandler = removeBannerCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBanner()
        {
            return Ok(await _getAllBannerQueryHandler.Handle());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdBanner(int id)
        {
            return Ok(await _getByIdBannerQueryHandler.Handle(new GetByIdBannerQueryRequest(id)));
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateBanner([FromBody] CreateBannerCommandRequest request)
        {
            await _createBannerCommandHandler.Handle(request);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateBanner([FromBody] UpdateBannerCommandRequest request)
        {
            await _updateBannerCommandHandler.Handle(request);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBanner(int id)
        {
            await _removeBannerCommandHandler.Handle(new RemoveBannerCommandRequest(id));
            return Ok();
        }
    }
}
