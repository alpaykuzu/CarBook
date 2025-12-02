using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Features.Commands.RemoveFeature
{
    public class RemoveFeatureCommandHandler : IRequestHandler<RemoveFeatureCommandRequest>
    {
        private readonly IRepository<Feature> _repository;

        public RemoveFeatureCommandHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveFeatureCommandRequest request, CancellationToken cancellationToken)
        {
            var feature = await _repository.GetByIdAsync(request.Id);
            if (feature == null)
                throw new Exception("Feature not found");

            await _repository.RemoveAsync(feature);
        }
    }
}
