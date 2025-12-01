using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Contacts.Queries.GetAllContact
{
    public class GetAllContactQueryHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetAllContactQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<GetAllContactQueryResponse>> Handle()
        {
            var contacts = await _repository.GetAllAsync();
            return contacts.Select(c => new GetAllContactQueryResponse
            {
                ContactID = c.ContactID,
                Name = c.Name,
                Email = c.Email,
                Message = c.Message,
                Subject = c.Subject,
                SendDate = c.SendDate
            });
        }
    }
}
