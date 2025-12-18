using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CarFeatures.Commands.DeleteCarFeature
{
    public class DeleteCarFeatureCommandRequest : IRequest
    {
        public int Id { get; set; }

        public DeleteCarFeatureCommandRequest(int id)
        {
            Id = id;
        }
    }
}
