using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Services.Queries.GetAllService
{
    public class GetAllServiceQueryHandler : IRequestHandler<GetAllServiceQueryRequest, List<GetAllServiceQueryResponse>>
    {
        private readonly IRepository<Service> _repository;

        public GetAllServiceQueryHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllServiceQueryResponse>> Handle(GetAllServiceQueryRequest request, CancellationToken cancellationToken)
        {
            var services = await _repository.GetAllAsync();
            var response = services.Select(s => new GetAllServiceQueryResponse
            {
                ServiceID = s.ServiceID,
                Title = s.Title,
                Description = s.Description,
                IconUrl = s.IconUrl
            }).ToList();
            return response;
        }
    }
}
