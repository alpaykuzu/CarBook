using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Features.Commands.UpdateFeature
{
    public class UpdateFeatureCommandHandler : IRequestHandler<UpdateFeatureCommandRequest>
    {
        private readonly IRepository<Feature> _repository;

        public UpdateFeatureCommandHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFeatureCommandRequest request, CancellationToken cancellationToken)
        {
            var feature = await _repository.GetByIdAsync(request.FeatureID);
            if (feature == null)
                throw new Exception("Feature not found");
            
            feature.Name = request.Name;
            await _repository.UpdateAsync(feature);
        }
    }
}
