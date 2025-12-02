using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Locations.Queries.GetByIdLocation
{
    public class GetByIdLocationQueryHandler : IRequestHandler<GetByIdLocationQueryRequest, GetByIdLocationQueryResponse>
    {
        private readonly IRepository<Location> _repository;

        public GetByIdLocationQueryHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdLocationQueryResponse> Handle(GetByIdLocationQueryRequest request, CancellationToken cancellationToken)
        {
            var location = await _repository.GetByIdAsync(request.Id);
            if (location == null)
                return null; 
            
            return new GetByIdLocationQueryResponse
            {
                LocationID = location.LocationID,
                Name = location.Name
            };
        }
    }
}
