using CarBook.Application.Features.Statistics.Queries.GetAvarageCarPricing;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Statistics.Queries.GetCarByCarPricing
{
    public class GetCarByCarPricingQueryHandler : IRequestHandler<GetCarByCarPricingQueryRequest, GetCarByCarPricingQueryResponse>
    {
        private readonly IRepository<CarPricing> _repository;

        public GetCarByCarPricingQueryHandler(IRepository<CarPricing> repository)
        {
            _repository = repository;
        }
        public async Task<GetCarByCarPricingQueryResponse> Handle(GetCarByCarPricingQueryRequest request, CancellationToken cancellationToken)
        {
            var query = _repository.GetQueryable()
                .Include(x => x.Pricing)
                .Include(x => x.Car).ThenInclude(b => b.Brand)
                .Where(x => x.Pricing.Name == request.PricingType);

            query = request.IsMax
                ? query.OrderByDescending(x => x.Amount)
                : query.OrderBy(x => x.Amount);

            var carPricing = await query.FirstOrDefaultAsync(cancellationToken);

            if (carPricing == null)
                return null;

            return new GetCarByCarPricingQueryResponse
            {
                Brand = carPricing.Car.Brand.Name,
                Model = carPricing.Car.Model,
            };
        }

    }
}
