using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Pricings.Commands.RemovePricing
{
    public class RemovePricingCommandRequest : IRequest
    {
        public int Id { get; set; }

        public RemovePricingCommandRequest(int id)
        {
            Id = id;
        }
    }
}
