using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Pricings.Commands.UpdatePricing
{
    public class UpdatePricingCommandRequest : IRequest
    {
        public int PricingID { get; set; }
        public string Name { get; set; }
    }
}
