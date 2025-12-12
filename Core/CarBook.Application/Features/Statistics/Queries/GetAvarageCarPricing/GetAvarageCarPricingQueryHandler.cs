using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Statistics.Queries.GetAvarageCarPricing
{
    public class GetAvarageCarPricingQueryHandler : IRequestHandler<GetAvarageCarPricingQueryRequest, GetAvarageCarPricingResponse>
    {
        private readonly IRepository<CarPricing> _repository;

        public GetAvarageCarPricingQueryHandler(IRepository<CarPricing> repository)
        {
            _repository = repository;
        }

        public async Task<GetAvarageCarPricingResponse> Handle(GetAvarageCarPricingQueryRequest request, CancellationToken cancellationToken)
        {
            var avaragePrice = await _repository.GetQueryable()
                .Include(x => x.Pricing)
                .Where(p => p.Pricing.Name == request.PricingType)
                .AverageAsync(z => z.Amount);
            return new GetAvarageCarPricingResponse
            {
                AvaragePrice = avaragePrice,
            };
        }
    }
}
