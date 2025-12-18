using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CarFeatures.Queries.GetCarFeatureByCar
{
    public class GetCarFeatureByCarQueryHandler : IRequestHandler<GetCarFeatureByCarQueryRequest, List<GetCarFeatureByCarQueryResponse>>
    {
        private readonly IRepository<CarFeature> repository;

        public GetCarFeatureByCarQueryHandler(IRepository<CarFeature> repository)
        {
            this.repository = repository;
        }

        public async Task<List<GetCarFeatureByCarQueryResponse>> Handle(GetCarFeatureByCarQueryRequest request, CancellationToken cancellationToken)
        {
            var carFeatures = repository.GetQueryable().Include(f => f.Feature)
                .Where(x => x.CarID == request.CarID);
            return carFeatures.Select(x => new GetCarFeatureByCarQueryResponse
            {
                CarFeatureID = x.CarFeatureID,
                Available = x.Available,
                CarID = x.CarID, 
                FeatureID = x.FeatureID,
                Name = x.Feature.Name
            }).ToList();
        }
    }
}
