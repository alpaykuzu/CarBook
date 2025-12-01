using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Contacts.Commands.RemoveContact
{
    public class RemoveContactCommandRequest
    {
        public int Id { get; set; }

        public RemoveContactCommandRequest(int id)
        {
            Id = id;
        }
    }
}
