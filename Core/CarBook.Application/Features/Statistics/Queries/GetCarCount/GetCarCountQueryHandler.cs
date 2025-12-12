using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Statistics.Queries.GetCarCount
{
    internal class GetCarCountQueryHandler : IRequestHandler<GetCarCountQueryRequest, GetCarCountQueryResponse>
    {
        private readonly IRepository<Car> _repository;

        public GetCarCountQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountQueryResponse> Handle(GetCarCountQueryRequest request, CancellationToken cancellationToken)
        {
            var count =  await _repository.GetCountAsync();
            return new GetCarCountQueryResponse
            {
                CarCount = count,
            };
        }
    }
}
