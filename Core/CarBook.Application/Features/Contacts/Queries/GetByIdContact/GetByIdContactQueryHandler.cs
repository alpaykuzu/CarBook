using CarBook.Application.Features.Categories.Queries.GetByIdCategory;
using CarBook.Application.Features.Contacts.Queries.GetAllContact;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Contacts.Queries.GetByIdContact
{
    public class GetByIdContactQueryHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetByIdContactQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task<GetByIdContactQueryResponse> Handle(GetByIdContactQueryRequest query)
        {
            var contact = await _repository.GetByIdAsync(query.Id);
            if (contact == null)
                return null;

            return new GetByIdContactQueryResponse
            {
                ContactID = contact.ContactID,
                Name = contact.Name,
                Email = contact.Email,
                Message = contact.Message,
                Subject = contact.Subject,
                SendDate = contact.SendDate
            };
        }
    }
}
