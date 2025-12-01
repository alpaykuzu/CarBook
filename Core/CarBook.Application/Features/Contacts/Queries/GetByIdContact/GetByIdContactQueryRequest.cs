using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Contacts.Queries.GetByIdContact
{
    public class GetByIdContactQueryRequest
    {
        public int Id { get; set; }

        public GetByIdContactQueryRequest(int id)
        {
            Id = id;
        }
    }
}
