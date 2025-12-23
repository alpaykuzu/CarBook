using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CarPricings.Commands.UpdateCarPricing
{
    public class UpdateCarPricingCommandRequest : IRequest
    {
        public int CarPricingID { get; set; }
        public int CarID { get; set; }
        public int PricingID { get; set; }
        public decimal Amount { get; set; }
    }
}
