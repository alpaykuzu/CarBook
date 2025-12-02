using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Locations.Commands.UpdateLocation
{
    public class UpdateLocationCommandRequest : IRequest
    {
        public int LocationID { get; set; }
        public string Name { get; set; }
    }
}
