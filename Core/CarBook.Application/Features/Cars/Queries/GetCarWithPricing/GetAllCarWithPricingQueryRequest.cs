using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Cars.Queries.GetCarWithPricing
{
    public class GetAllCarWithPricingQueryRequest
    {
        public string PricingType { get; set; }

        public GetAllCarWithPricingQueryRequest(string pricingType)
        {
            PricingType = pricingType;
        }
    }
}
