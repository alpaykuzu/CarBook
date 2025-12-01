using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Cars.Commands.RemoveCar
{
    public class RemoveCarCommandRequest
    {
        public int Id { get; set; }

        public RemoveCarCommandRequest(int id)
        {
            Id = id;
        }
    }
}
