using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Locations.Commands.RemoveLocation
{
    public class RemoveLocationCommandRequest : IRequest
    {
        public int Id { get; set; }

        public RemoveLocationCommandRequest(int id)
        {
            Id = id;
        }
    }
}
