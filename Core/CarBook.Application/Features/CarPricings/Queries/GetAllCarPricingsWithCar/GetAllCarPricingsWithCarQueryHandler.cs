using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CarPricings.Queries.GetAllCarPricingsWithCar
{
    public class GetAllCarPricingsWithCarQueryHandler : IRequestHandler<GetAllCarPricingsWithCarQueryRequest, List<GetAllCarPricingsWithCarQueryResponse>>
    {
        private readonly IRepository<CarPricing> repository;

        public GetAllCarPricingsWithCarQueryHandler(IRepository<CarPricing> repository)
        {
            this.repository = repository;
        }

        public async Task<List<GetAllCarPricingsWithCarQueryResponse>> Handle(GetAllCarPricingsWithCarQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await repository.GetQueryable()
                .Include(c => c.Car).ThenInclude(b => b.Brand)
                .Include(p => p.Pricing)
                .ToListAsync();

            var responses = new List<GetAllCarPricingsWithCarQueryResponse>();
            var check = 0;
            foreach (var item in result)
            {
                if (check == item.CarID)
                    if (item.Pricing.Name == "Saatlik")
                    {
                        responses.FirstOrDefault(r => r.CarID == item.CarID).HourlyPrice = item.Amount;
                        continue;
                    }
                    else if (item.Pricing.Name == "Günlük")
                    {
                        responses.FirstOrDefault(r => r.CarID == item.CarID).DailyPrice = item.Amount;
                        continue;
                    }
                    else if (item.Pricing.Name == "Haftalık")
                    {
                        responses.FirstOrDefault(r => r.CarID == item.CarID).WeeklyPrice = item.Amount;
                        continue;
                    }

                responses.Add(new GetAllCarPricingsWithCarQueryResponse
                {
                    BrandID = item.Car.Brand.BrandID,
                    BrandName = item.Car.Brand.Name,
                    CarID = item.CarID,
                    Model = item.Car.Model,
                    CoverImageUrl = item.Car.CoverImageUrl,
                    HourlyPrice = item.Pricing.Name == "Saatlik" ? item.Amount : 0,
                    DailyPrice = item.Pricing.Name == "Günlük" ? item.Amount : 0,
                    WeeklyPrice = item.Pricing.Name == "Haftalık" ? item.Amount : 0,
                });

                check = item.CarID;
            }
            return responses;
        }
    }
}
