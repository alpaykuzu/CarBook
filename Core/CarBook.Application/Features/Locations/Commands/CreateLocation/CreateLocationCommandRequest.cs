using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Locations.Commands.CreateLocation
{
    public class CreateLocationCommandRequest : IRequest
    {
        public string Name { get; set; }
    }
}
