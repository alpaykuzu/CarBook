using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Features.Queries.GetAllFeature
{
    public class GetAllFeatureQueryHandler : IRequestHandler<GetAllFeatureQueryRequest, List<GetAllFeatureQueryResponse>>
    {
        private readonly IRepository<Feature> _repository;

        public GetAllFeatureQueryHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllFeatureQueryResponse>> Handle(GetAllFeatureQueryRequest request, CancellationToken cancellationToken)
        {
            var features = await _repository.GetAllAsync();
            return features.Select(f => new GetAllFeatureQueryResponse
            {
                FeatureID = f.FeatureID,
                Name = f.Name
            }).ToList();
        }
    }
}
