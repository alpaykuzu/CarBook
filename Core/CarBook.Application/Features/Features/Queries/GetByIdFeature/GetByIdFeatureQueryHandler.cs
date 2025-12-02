using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Features.Queries.GetByIdFeature
{
    public class GetByIdFeatureQueryHandler : IRequestHandler<GetByIdFeatureQueryRequest, GetByIdFeatureQueryResponse>
    {
        private readonly IRepository<Feature> _repository;

        public GetByIdFeatureQueryHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdFeatureQueryResponse> Handle(GetByIdFeatureQueryRequest request, CancellationToken cancellationToken)
        {
            var feature = await _repository.GetByIdAsync(request.Id);
            if (feature == null)
                return null;

            return new GetByIdFeatureQueryResponse
            {
                FeatureID = feature.FeatureID,
                Name = feature.Name
            };
        }
    }
}
