using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Locations.Queries.GetAllLocation
{
    public class GetAllLocationQueryHandler : IRequestHandler<GetAllLocationQueryRequest, List<GetAllLocationQueryResponse>>
    {
        private readonly IRepository<Location> _repository;

        public GetAllLocationQueryHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllLocationQueryResponse>> Handle(GetAllLocationQueryRequest request, CancellationToken cancellationToken)
        {
            var locations = await _repository.GetAllAsync();
            return locations.Select(location => new GetAllLocationQueryResponse
            {
                LocationID = location.LocationID,
                Name = location.Name
            }).ToList();
        }
    }
}
