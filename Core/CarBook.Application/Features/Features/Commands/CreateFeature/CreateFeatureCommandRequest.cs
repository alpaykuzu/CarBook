using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Features.Commands.CreateFeature
{
    public class CreateFeatureCommandRequest : IRequest
    {
        public string Name { get; set; }
    }
}
