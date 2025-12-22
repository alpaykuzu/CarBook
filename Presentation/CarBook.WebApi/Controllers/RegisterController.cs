using CarBook.Application.Features.AppUsers.Commands.RegisterAppUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IMediator mediator;

        public RegisterController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterAppUserCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
