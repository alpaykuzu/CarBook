using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Pricings.Queries.GetByIdPricing
{
    public class GetByIdPricingQueryHandler : IRequestHandler<GetByIdPricingQueryRequest, GetByIdPricingQueryResponse>
    {
        private readonly IRepository<Pricing> _repository;

        public GetByIdPricingQueryHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdPricingQueryResponse> Handle(GetByIdPricingQueryRequest request, CancellationToken cancellationToken)
        {
            var pricing = await _repository.GetByIdAsync(request.Id);
            if (pricing == null)
                return null; 
            
            var response = new GetByIdPricingQueryResponse
            {
                PricingID = pricing.PricingID,
                Name = pricing.Name,
            };
            return response;
        }
    }
}
