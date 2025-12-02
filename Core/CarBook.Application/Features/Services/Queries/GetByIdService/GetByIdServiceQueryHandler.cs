using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Services.Queries.GetByIdService
{
    public class GetByIdServiceQueryHandler : IRequestHandler<GetByIdServiceQueryRequest, GetByIdServiceQueryResponse>
    {
        private readonly IRepository<Service> _repository;

        public GetByIdServiceQueryHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdServiceQueryResponse> Handle(GetByIdServiceQueryRequest request, CancellationToken cancellationToken)
        {
            var service = await _repository.GetByIdAsync(request.Id);
            if (service == null)
                return null;
            
            return new GetByIdServiceQueryResponse
            {
                ServiceID = service.ServiceID,
                Title = service.Title,
                Description = service.Description,
                IconUrl = service.IconUrl
            };
        }
    }
}
