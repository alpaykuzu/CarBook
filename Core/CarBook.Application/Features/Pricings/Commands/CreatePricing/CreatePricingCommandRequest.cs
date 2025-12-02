using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Pricings.Commands.CreatePricing
{
    public class CreatePricingCommandRequest : IRequest
    {
        public string Name { get; set; }
    }
}
