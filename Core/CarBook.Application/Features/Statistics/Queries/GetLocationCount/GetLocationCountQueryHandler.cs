using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Statistics.Queries.GetLocationCount
{
    public class GetLocationCountQueryHandler : IRequestHandler<GetLocationCountQueryRequest, GetLocationCountQueryResponse>
    {
        private readonly IRepository<Location> _repository;

        public GetLocationCountQueryHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task<GetLocationCountQueryResponse> Handle(GetLocationCountQueryRequest request, CancellationToken cancellationToken)
        {
            var count = await _repository.GetCountAsync();
            return new GetLocationCountQueryResponse
            {
                LocationCount = count,
            };
        }
    }
}
