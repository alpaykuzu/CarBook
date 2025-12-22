using CarBook.Application.Features.AppUsers.Queries.GetCheckAppUser;
using CarBook.Application.Tools;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator mediator;

        public LoginController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] GetCheckAppUserQueryRequest request)
        {
            var result = await mediator.Send(request);
            var tokenResponse = JwtTokenGenerator.GenerateToken(result);
            if (tokenResponse == null)
            {
                return Unauthorized();
            }
            return Ok(tokenResponse);
        }
    }
}
