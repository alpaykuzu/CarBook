using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Pricings.Queries.GetAllPricing
{
    public class GetAllPricingQueryHandler : IRequestHandler<GetAllPricingQueryRequest, List<GetAllPricingQueryResponse>>
    {
        private readonly IRepository<Pricing> _repository;

        public GetAllPricingQueryHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllPricingQueryResponse>> Handle(GetAllPricingQueryRequest request, CancellationToken cancellationToken)
        {
            var pricings = await _repository.GetAllAsync();
            return pricings.Select(pricing => new GetAllPricingQueryResponse
            {
                PricingID = pricing.PricingID,
                Name = pricing.Name
            }).ToList();
        }
    }
}
