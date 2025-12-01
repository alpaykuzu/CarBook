using CarBook.Application.Features.Contacts.Commands.CreateContact;
using CarBook.Application.Features.Contacts.Commands.RemoveContact;
using CarBook.Application.Features.Contacts.Commands.UpdateContact;
using CarBook.Application.Features.Contacts.Queries.GetAllContact;
using CarBook.Application.Features.Contacts.Queries.GetByIdContact;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly GetAllContactQueryHandler _getAllContactQueryHandler;
        private readonly GetByIdContactQueryHandler _getByIdContactQueryHandler;
        private readonly CreateContactCommandHandler _createContactCommandHandler;
        private readonly UpdateContactCommandHandler _updateContactCommandHandler;
        private readonly RemoveContactCommandHandler _removeContactCommandHandler;

        public ContactsController(GetAllContactQueryHandler getAllContactQueryHandler, GetByIdContactQueryHandler getByIdContactQueryHandler, CreateContactCommandHandler createContactCommandHandler, UpdateContactCommandHandler updateContactCommandHandler, RemoveContactCommandHandler removeContactCommandHandler)
        {
            _getAllContactQueryHandler = getAllContactQueryHandler;
            _getByIdContactQueryHandler = getByIdContactQueryHandler;
            _createContactCommandHandler = createContactCommandHandler;
            _updateContactCommandHandler = updateContactCommandHandler;
            _removeContactCommandHandler = removeContactCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllContact()
        {
            return Ok(await _getAllContactQueryHandler.Handle());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdContact(int id)
        {
            return Ok(await _getByIdContactQueryHandler.Handle(new GetByIdContactQueryRequest(id)));
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] CreateContactCommandRequest request)
        {
            await _createContactCommandHandler.Handle(request);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateContact([FromBody] UpdateContactCommandRequest request)
        {
            await _updateContactCommandHandler.Handle(request);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveContact(int id)
        {
            await _removeContactCommandHandler.Handle(new RemoveContactCommandRequest(id));
            return Ok();
        }
    }
}
