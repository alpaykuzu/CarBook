using CarBook.Application.Features.CarPricings.Queries.GetAllCarPricingsWithCar;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CarPricings.Queries.GetCarPricingByCar
{
    public class GetCarPricingByCarQueryHandler : IRequestHandler<GetCarPricingByCarQueryRequest, GetCarPricingByCarQueryResponse>
    {
        private readonly IRepository<CarPricing> repository;

        public GetCarPricingByCarQueryHandler(IRepository<CarPricing> repository)
        {
            this.repository = repository;
        }

        public async Task<GetCarPricingByCarQueryResponse> Handle(GetCarPricingByCarQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await repository.GetQueryable()
                .Include(p => p.Pricing)
                .Where(c => c.CarID == request.CarID)
                .ToListAsync();

            var responses = new GetCarPricingByCarQueryResponse();

            foreach (var item in result)
            {
                if (item.Pricing.Name == "Saatlik")
                {
                    responses.HourlyPrice = item.Amount;
                    responses.HourlyCarPricingID = item.CarPricingID;
                    responses.HourlyPricingID = item.PricingID;
                    continue;
                }
                else if (item.Pricing.Name == "Günlük")
                {
                    responses.DailyPrice = item.Amount;
                    responses.DailyCarPricingID = item.CarPricingID;
                    responses.DailyPricingID = item.PricingID;
                    continue;
                }
                else if (item.Pricing.Name == "Haftalık")
                {
                    responses.WeeklyPrice = item.Amount;
                    responses.WeeklyCarPricingID = item.CarPricingID;
                    responses.WeeklyPricingID = item.PricingID;
                    continue;
                }
            }
            responses.CarID = request.CarID;
            return responses;
        }
    }
}
