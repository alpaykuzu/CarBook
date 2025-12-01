using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Contacts.Commands.UpdateContact
{
    public class UpdateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;
        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateContactCommandRequest request)
        {
            var contact = await _repository.GetByIdAsync(request.ContactID);
            if (contact != null)
            {
                contact.Name = request.Name;
                contact.Email = request.Email;
                contact.Subject = request.Subject;
                contact.Message = request.Message;
                contact.SendDate = request.SendDate;
                await _repository.UpdateAsync(contact);
            }
        }
    }
}
