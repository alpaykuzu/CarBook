using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CarFeatures.Commands.UpdateCarFeature
{
    public class UpdateCarFeatureCommandRequest : IRequest
    {
        public int CarFeatureID { get; set; }
    }
}
