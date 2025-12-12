using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Statistics.Queries.GetMostCarBrand
{
    public class GetMostCarBrandQueryHandler : IRequestHandler<GetMostCarBrandQueryRequest, GetMostCarBrandQueryResponse>
    {
        private readonly IRepository<Car> repository;

        public GetMostCarBrandQueryHandler(IRepository<Car> repository)
        {
            this.repository = repository;
        }

        public async Task<GetMostCarBrandQueryResponse> Handle(GetMostCarBrandQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await repository.GetQueryable()
                .GroupBy(c => new { c.BrandID, c.Brand.Name })
                .Select(g => new
                {
                    BrandName = g.Key.Name,
                    CarCount = g.Count()
                })
                .OrderByDescending(x => x.CarCount)
                .FirstOrDefaultAsync(cancellationToken);

            if (result == null)
            {
                return new GetMostCarBrandQueryResponse
                {
                    BrandName = "Veri bulunamadı"
                };
            }

            return new GetMostCarBrandQueryResponse
            {
                BrandName = result.BrandName
            };
        }

    }
}
