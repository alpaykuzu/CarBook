using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Statistics.Queries.GetBrandCount
{
    public class GetBrandCountQueryHandler : IRequestHandler<GetBrandCountQueryRequest, GetBrandCountQueryResponse>
    {
        private readonly IRepository<Brand> repository;

        public GetBrandCountQueryHandler(IRepository<Brand> repository)
        {
            this.repository = repository;
        }

        public async Task<GetBrandCountQueryResponse> Handle(GetBrandCountQueryRequest request, CancellationToken cancellationToken)
        {
            var count = await repository.GetCountAsync();
            return new GetBrandCountQueryResponse
            {
                BrandCount = count,
            };
        }
    }
}
